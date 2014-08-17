using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matasano.Set1
{
    public class Challenge6
    {
        public static string BreakRepeatingKeyXOR(string base64Input)
        {
            var bytes = Convert.FromBase64String(base64Input);
            var keySizeCandidates = CheckKeySizes(bytes).OrderBy(r => r.Score).Take(5).Select(s => s.KeySize);
            var decrypted = GetKeys(bytes, keySizeCandidates).OrderByDescending(s => s.Score).First();
            return decrypted.Text;
        }

        private static IEnumerable<TextScore> GetKeys(byte[] bytes, IEnumerable<int> keySizes)
        {
            foreach(var keySize in keySizes)
            {
                var key = GetKey(bytes, keySize);
                var decrypted = Encoding.ASCII.GetString(Utilities.XOR(bytes, key));
                yield return new TextScore(decrypted, key);
            }
        }

        private static byte[] GetKey(byte[] bytes, int keySize)
        {
            var blocks = new byte[keySize][];
            var mod = bytes.Length % keySize;
            for(var i = 0; i < keySize; i++)
            {
                var length = mod == 0 || i < mod ? keySize : keySize - 1;
                blocks[i] = new byte[length];
                for(var j = 0; j < length; j++)
                {
                    blocks[i][j] = bytes[j * keySize + i];
                }
            }

            var key = new byte[keySize];
            for(var i = 0; i < keySize; i++)
            {
                var score = Challenge3.DecodeSingleByteXORCipher(blocks[i]);
                key[i] = score.Cipher[0];
            }

            return key;
        }

        private static IEnumerable<KeySizeCheckResults> CheckKeySizes(byte[] bytes)
        {
            for (var keySize = 2; keySize <= 40; keySize++)
            {
                var hamming = PermutatedHamming(bytes, keySize, 5);
                var finalScore = hamming / keySize;
                yield return new KeySizeCheckResults { KeySize = keySize, Score = finalScore };
            }
        }

        private static double PermutatedHamming(byte[] bytes, int keySize, int depth)
        {
            var count = depth * (depth - 1) / 2;
            var hamming = 0.0;
            for(var i = 0; i < depth; i++)
            {
                for(var j = i + 1; j < depth; j++)
                {
                    hamming += (double)HammingDistance(bytes, i * keySize, bytes, j * keySize, keySize) / count;
                }
            }

            return hamming;
        }

        private class KeySizeCheckResults
        {
            public int KeySize { get; set; }
            public double Score { get; set; }
        }

        public static int HammingDistance(byte[] b1, int index1, byte[] b2, int index2, int length)
        {
            var count = 0;
            for(int i = index1, j = index2; i < index1 + length; i++, j++)
            {
                var xord = b1[i] ^ b2[j];
                for(var k = 0; k < 8; k++)
                {
                    if ((xord & 1) == 1)
                        count++;
                    xord >>= 1;
                }
            }
            return count;
        }

        public static int HammingDistance(byte[] b1, byte[] b2)
        {
            return HammingDistance(b1, 0, b2, 0, b1.Length);
        }

        public static int HammingDistance(string input1, string input2)
        {
            var b1 = Encoding.ASCII.GetBytes(input1);
            var b2 = Encoding.ASCII.GetBytes(input2);
            return HammingDistance(b1, b2);
        }
    }
}
