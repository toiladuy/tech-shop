using System.Security.Cryptography;
using System.Text;
using System;

namespace Shop.Utils
{
    public class SignUtils
    {
        public static string SignSHA256(string message, string key)
        {
            byte[] keyByte = Encoding.UTF8.GetBytes(key);
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                string hex = BitConverter.ToString(hashmessage);
                //hex = hex.Replace("-", "").ToLower();
                hex = Convert.ToBase64String(hashmessage);
                return hex;

            }
        }
    }
}
