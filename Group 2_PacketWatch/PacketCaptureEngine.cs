using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using MySql.Data.MySqlClient;
using SharpPcap;
using SharpPcap.LibPcap;
using PacketDotNet;

namespace Group_2_PacketWatch
{
    public static class PacketCaptureEngine
    {
        private static ILiveDevice _device;
        public static bool IsCapturing { get; private set; }
        private static int _packetCount = 0;

        public static string[] GetDeviceNames()
        {
            var devices = CaptureDeviceList.Instance;
            if (devices.Count == 0) return new string[0];
            string[] names = new string[devices.Count];
            for (int i = 0; i < devices.Count; i++)
                names[i] = devices[i].Description ?? $"Device {i}";
            return names;
        }

        public static void StartCapture(int deviceIndex)
        {
            if (IsCapturing) return;

            try
            {
                CaptureDeviceList.New();
                var devices = CaptureDeviceList.Instance;

                if (devices.Count == 0)
                    throw new Exception("No network devices found.");

                if (deviceIndex >= devices.Count)
                    deviceIndex = 0;

                _device = devices[deviceIndex] as ILiveDevice;
                if (_device == null)
                    throw new Exception("Selected device is not a live capture device.");

                _device.Open(DeviceModes.Promiscuous, 1000);
                _device.OnPacketArrival += OnPacketArrival;
                _device.StartCapture();
                IsCapturing = true;

                System.IO.File.AppendAllText(@"C:\PacketWatchLog.txt",
                    $"{DateTime.Now} - Capture started on [{deviceIndex}]: {_device.Description}\n");
            }
            catch (Exception ex)
            {
                IsCapturing = false;
                System.IO.File.AppendAllText(@"C:\PacketWatchLog.txt",
                    $"{DateTime.Now} - StartCapture ERROR: {ex.Message}\n");
                throw;
            }
        }

        public static void StopCapture()
        {
            if (!IsCapturing || _device == null) return;
            try
            {
                _device.StopCapture();
                _device.OnPacketArrival -= OnPacketArrival;
                _device.Close();
            }
            catch { }
            finally
            {
                _device = null;
                IsCapturing = false;
                _packetCount = 0;
            }
        }

        private static void OnPacketArrival(object sender, PacketCapture e)
        {
            _packetCount++;

            if (_packetCount % 10 == 0)
            {
                System.IO.File.AppendAllText(
                    @"C:\PacketWatchLog.txt",
                    $"{DateTime.Now} - {_packetCount} raw packets received so far\n");
            }

            RawCapture raw = e.GetPacket();
            ThreadPool.QueueUserWorkItem(_ => ProcessRawPacket(raw));
        }

        private static void ProcessRawPacket(RawCapture rawPacket)
        {
            try
            {
                var packet = Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);
                var ipPacket = packet.Extract<IPPacket>();

                if (ipPacket == null) return;

                string srcIp = ipPacket.SourceAddress.ToString();
                string dstIp = ipPacket.DestinationAddress.ToString();
                string proto = ipPacket.Protocol.ToString();
                int srcPort = 0;
                int dstPort = 0;
                int size = rawPacket.Data.Length;
                string flags = "";

                var tcpPacket = packet.Extract<TcpPacket>();
                if (tcpPacket != null)
                {
                    srcPort = tcpPacket.SourcePort;
                    dstPort = tcpPacket.DestinationPort;
                    flags = tcpPacket.Flags.ToString();
                }

                var udpPacket = packet.Extract<UdpPacket>();
                if (udpPacket != null)
                {
                    srcPort = udpPacket.SourcePort;
                    dstPort = udpPacket.DestinationPort;
                }

                long packetId = InsertPacket(srcIp, dstIp, srcPort, dstPort, proto, size, flags);
                if (packetId <= 0) return;

                InsertPacketLog(packetId, proto, srcIp, srcPort, dstIp, dstPort);

                CheckAndCreateAlert(packetId, srcIp, dstIp, proto, dstPort);
            }
            catch
            {
                // Silently ignore malformed or unreadable packets
            }
        }

        private static long InsertPacket(string srcIp, string dstIp,
                                          int srcPort, int dstPort,
                                          string proto, int size, string flags)
        {
            string sql = @"INSERT INTO packets
                           (source_ip, destination_ip, source_port, destination_port,
                            protocol, packet_size, flags)
                           VALUES
                           (@sip, @dip, @sp, @dp, @proto, @size, @flags);
                           SELECT LAST_INSERT_ID();";

            object result = DBHelper.ExecuteScalar(sql,
                new MySqlParameter("@sip", srcIp),
                new MySqlParameter("@dip", dstIp),
                new MySqlParameter("@sp", srcPort),
                new MySqlParameter("@dp", dstPort),
                new MySqlParameter("@proto", proto),
                new MySqlParameter("@size", size),
                new MySqlParameter("@flags", flags));

            return result != null ? Convert.ToInt64(result) : 0;
        }

        private static void InsertPacketLog(long packetId, string proto,
                                     string srcIp, int srcPort,
                                     string dstIp, int dstPort)
        {
            string sql = @"INSERT INTO packet_logs (packet_id, action, details)
                   VALUES (@pid, 'CAPTURED', @details)";

            DBHelper.ExecuteNonQuery(sql,
                new MySqlParameter("@pid", packetId),
                new MySqlParameter("@details", $"{proto} {srcIp}:{srcPort} -> {dstIp}:{dstPort}"));
        }

        private static void CheckAndCreateAlert(long packetId, string srcIp,
                                                 string dstIp, string proto, int dstPort)
        {
            string rulesSql = "SELECT * FROM detection_rules WHERE is_enabled = TRUE";
            var rules = DBHelper.ExecuteQuery(rulesSql);

            foreach (System.Data.DataRow rule in rules.Rows)
            {
                string patternType = rule["pattern_type"].ToString();
                string patternValue = rule["pattern_value"].ToString();
                bool matched = false;

                if (patternType == "protocol" &&
                    proto.Equals(patternValue, StringComparison.OrdinalIgnoreCase))
                    matched = true;

                if (patternType == "port" &&
                    int.TryParse(patternValue, out int rulePort) &&
                    dstPort == rulePort)
                    matched = true;

                if (!matched) continue;

                string alertSql = @"INSERT INTO alerts
                    (rule_id, packet_id, source_ip, destination_ip,
                     severity_level, alert_message, details)
                    VALUES
                    (@rid, @pid, @sip, @dip, @sev, @msg, @det)";

                DBHelper.ExecuteNonQuery(alertSql,
                    new MySqlParameter("@rid", rule["rule_id"]),
                    new MySqlParameter("@pid", packetId),
                    new MySqlParameter("@sip", srcIp),
                    new MySqlParameter("@dip", dstIp),
                    new MySqlParameter("@sev", rule["severity_level"].ToString()),
                    new MySqlParameter("@msg", rule["rule_name"].ToString()),
                    new MySqlParameter("@det", rule["description"].ToString()));
            }
        }
    }
}
