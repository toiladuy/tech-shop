using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Shop.Utils
{
    public class PasswordUtils
    {
        public static string Encrypt(string rawText)
        {
            string EncryptionKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
            byte[] rawBytes = Encoding.Unicode.GetBytes(rawText);
            string encryptedText = "";
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(rawBytes, 0, rawBytes.Length);
                        cs.Close();
                    }
                    encryptedText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptedText;
        }
    }
}
