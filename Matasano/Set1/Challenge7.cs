using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Matasano.Set1
{
    public class Challenge7
    {
        public static string DecryptAES128ECB(string base64Input, string key)
        {
            var keyBytes = Encoding.ASCII.GetBytes(key);
            var dataBytes = Convert.FromBase64String(base64Input);
            var decrypted = DecryptAES128ECB(dataBytes, keyBytes);
            return Encoding.ASCII.GetString(decrypted);
        }

        public static byte[] DecryptAES128ECB(byte[] data, byte[] key)
        {
            var aes = GetAesManaged(key);
            var decryptor = aes.CreateDecryptor();
            return decryptor.TransformFinalBlock(data, 0, data.Length);
        }

        private static AesManaged GetAesManaged(byte[] key)
        {
            return new AesManaged
            {
                KeySize = 128,
                Key = key,
                BlockSize = 128,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.None,
                IV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };
        }

        public static byte[] EncryptAES128ECB(byte[] data, byte[] key)
        {
            var aes = GetAesManaged(key);
            var encryptor = aes.CreateEncryptor();
            return encryptor.TransformFinalBlock(data, 0, data.Length);
        }
    }
}
