using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matasano.Set2
{
    public class Challenge2
    {
        public static byte[] EncryptCBC(byte[] data, byte[] key)
        {
            var keySize = 16;
            if (key.Length != keySize)
                throw new ArgumentOutOfRangeException("key.Length");

            data = Challenge1.PKCS7Pad(data, keySize);
            var output = new byte[data.Length];

            var iv = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var block = new byte[keySize];
            for(var i = 0; i < data.Length; i += keySize)
            {
                Array.Copy(data, i, block, 0, keySize);
                block = Utilities.XOR(block, iv);
                iv = Set1.Challenge7.EncryptAES128ECB(block, key);
                Array.Copy(iv, 0, output, i, keySize);
            }

            return output;
        }

        public static byte[] DecryptCBC(byte[] data, byte[] key)
        {
            var keySize = 16;
            if (key.Length != keySize)
                throw new ArgumentOutOfRangeException("key.Length");
            if (data.Length % keySize != 0)
                throw new ArgumentOutOfRangeException("data.Length");

            var output = new byte[data.Length];
            var iv = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var block = new byte[keySize];
            for(var i = 0; i < data.Length; i += keySize)
            {
                Array.Copy(data, i, block, 0, keySize);
                var decBlock = Set1.Challenge7.DecryptAES128ECB(block, key);
                var plaintext = Utilities.XOR(decBlock, iv);
                Array.Copy(plaintext, 0, output, i, keySize);
                Array.Copy(block, iv, keySize);
            }

            return output;
        }
    }
}
