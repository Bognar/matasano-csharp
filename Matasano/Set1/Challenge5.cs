using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matasano.Set1
{
    public class Challenge5
    {
        public static string RepeatingKeyXOR(string input, string cypher)
        {
            var b1 = Encoding.ASCII.GetBytes(input);
            var b2 = Encoding.ASCII.GetBytes(cypher);
            var xord = Utilities.XOR(b1, b2);
            return Utilities.HexFromBytes(xord);
        }
    }
}
