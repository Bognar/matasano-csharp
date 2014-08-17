using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matasano
{
    public static class Utilities
    {
        public static byte[] XOR(byte[] input1, byte input2)
        {
            var buffer = new byte[input1.Length];
            for (var i = 0; i < buffer.Length; i++)
                buffer[i] = (byte)(input1[i] ^ input2);

            return buffer;
        }

        public static byte[] XOR(byte[] input, byte[] cypher)
        {
            var buffer = new byte[input.Length];
            for (var i = 0; i < buffer.Length; i++)
            {
                buffer[i] = (byte)(input[i] ^ cypher[i%cypher.Length]);
            }

            return buffer;
        }

        public static string HexFromBytes(byte[] bytes)
        {
            return BitConverter.ToString(bytes).Replace("-", "");
        }

        public static string Base64FromHex(string hex)
        {
            var bytes = BytesFromHex(hex);
            return Convert.ToBase64String(bytes);
        }

        public static byte[] BytesFromHex(string hex)
        {
            if (hex.Length % 2 != 0)
                throw new ArgumentOutOfRangeException();

            var buffer = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i += 2)
            {
                buffer[i / 2] = byte.Parse(hex.Substring(i, 2), NumberStyles.HexNumber);
            }

            return buffer;
        }
    }
}
