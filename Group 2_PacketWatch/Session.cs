using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_2_PacketWatch
{
    public static class Session
    {
        public static int UserId { get; set; }
        public static string Username { get; set; }
        public static string Role { get; set; }
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static string IpAddress { get; set; }

        public static void Clear()
        {
            UserId = 0;
            Username = null;
            Role = null;
            FirstName = null;
            LastName = null;
            IpAddress = null;
        }
    }
}
