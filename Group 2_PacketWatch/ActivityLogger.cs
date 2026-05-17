using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Group_2_PacketWatch
{
    public static class ActivityLogger
    {
        public static void Log(string action, string details)
        {
            if (Session.UserId == 0) return; 

            string sql = @"INSERT INTO user_activity_log
                           (user_id, action, details, ip_address)
                           VALUES (@uid, @action, @details, @ip)";

            DBHelper.ExecuteNonQuery(sql,
                new MySqlParameter("@uid", Session.UserId),
                new MySqlParameter("@action", action),
                new MySqlParameter("@details", details),
                new MySqlParameter("@ip", Session.IpAddress ?? "127.0.0.1"));
        }
    }
}
