using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matasano.Set1
{
    public class Challenge2
    {
        public static string FixedXOR(string input1, string input2)
        {
            var b1 = Utilities.BytesFromHex(input1);
            var b2 = Utilities.BytesFromHex(input2);
            var xord = Utilities.XOR(b1, b2);
            return Utilities.HexFromBytes(xord);
        }
    }
}
