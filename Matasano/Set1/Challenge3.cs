using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matasano.Set1
{
    public class Challenge3
    {
        public static TextScore DecodeSingleByteXORCipher(string hex)
        {
            var bytes = Utilities.BytesFromHex(hex);
            return DecodeSingleByteXORCipher(bytes);
        }

        public static TextScore DecodeSingleByteXORCipher(byte[] bytes)
        {
            return GetAllStringScores(bytes).OrderByDescending(s => s.Score).First();
        }

        private static IEnumerable<TextScore> GetAllStringScores(byte[] bytes)
        {
            for (int i = 0; i < 256; i++)
            {
                yield return GetSingleByteXORScore(bytes, (byte)i);
            }
        }

        public static TextScore GetSingleByteXORScore(string hex, byte cipher)
        {
            var inputBytes = Utilities.BytesFromHex(hex);
            return GetSingleByteXORScore(inputBytes, cipher);
        }

        public static TextScore GetSingleByteXORScore(byte[] input, byte cipher)
        {
            var xord = Utilities.XOR(input, cipher);
            var xordText = Encoding.ASCII.GetString(xord);
            return new TextScore(xordText, new byte[] { cipher });
        }
    }

    public class TextScore
    {
        public TextScore(string text, byte[] cipher)
        {
            Text = text;
            Score = ScoreText(text);
            Cipher = cipher;
        }

        public int Score { get; private set; }
        public string Text { get; private set; }
        public byte[] Cipher { get; private set; }

        public static int ScoreText(string input)
        {
            int count = 0;
            int val;
            foreach (var ltr in input.ToLower())
            {
                if (!_frequency.TryGetValue(ltr, out val))
                    val = -5;
                count += val;
            }

            return count;
        }

        private static readonly Dictionary<char, int> _frequency = new Dictionary<char, int>
            {
                {'a', 8},{'b', 2},{'c', 3},{'d', 4},{'e', 13},
                {'f', 2},{'g', 2},{'h', 6},{'i', 7},{'j', 0},
                {'k', 1},{'l', 4},{'m', 3},{'n', 7},{'o', 8},
                {'p', 2},{'q', 0},{'r', 6},{'s', 6},{'t', 9},
                {'u', 3},{'v', 1},{'w', 2},{'x', 0},{'y', 2},
                {'z', 0},{'\n', 4},{' ', 10}, {'\'', 1}, {'"', 1}
            };
    }
}
