using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matasano.Set1
{
    public class Challenge4
    {
        public static TextScore FindDecodedText(string[] inputs)
        {
            return inputs.Select(i => Challenge3.DecodeSingleByteXORCipher(i)).OrderByDescending(s => s.Score).First();
        }
    }
}
