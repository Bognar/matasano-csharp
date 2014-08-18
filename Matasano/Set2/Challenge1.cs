using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matasano.Set2
{
    public class Challenge1
    {
        public static byte[] PKCS7Pad(byte[] input, int blockSize)
        {
            var mod = input.Length % blockSize;
            var padCount = blockSize - mod;
            var outLength = input.Length + (mod == 0 ? 0 : blockSize - mod);
            var output = new byte[outLength];
            Array.Copy(input, output, input.Length);

            for(var i = input.Length; i < output.Length; i++)
            {
                output[i] = (byte)padCount;
            }

            return output;
        }
    }
}
