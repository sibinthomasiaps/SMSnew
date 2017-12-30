using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMSnew
{
    public class encodecode
    {
        public static string Encode(string encodeme)
        {
            byte[] encoded = System.Text.Encoding.UTF8.GetBytes(encodeme);
            return Convert.ToBase64String(encoded);
        }

        public static string Decode(string decodeMe)
        {
            byte[] encoded = Convert.FromBase64String(decodeMe);
            return System.Text.Encoding.UTF8.GetString(encoded);
        }
    }
}