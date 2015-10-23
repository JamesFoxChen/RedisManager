using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisMessageQueue
{
    public static class ExtensionUtil
    {
        public static byte[] ToBytes(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return null;

            byte[] byteArray = Encoding.Default.GetBytes(str);
            return byteArray;
        }

        public static string ToStr(this byte[] bytes)
        {
            if (bytes == null)
                return null;

            string str = Encoding.Default.GetString(bytes);
            return str;
        }

        public static string[] ToStrArray(this byte[][] bytes)
        {
            if (bytes == null)
                return null;

            if (bytes.Length < 2)
                return null;

            string[] strArr = new string[2] { "", "" };
            strArr[0] = Encoding.Default.GetString(bytes[0]);
            strArr[1] = Encoding.Default.GetString(bytes[1]);
            return strArr;
        }
    }
}
