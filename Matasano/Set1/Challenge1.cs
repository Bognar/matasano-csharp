using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matasano.Set1
{
    public class Challenge1
    {
        public static string HexToBase64(string hex)
        {
            return Utilities.Base64FromHex(hex);
        }
    }
}
