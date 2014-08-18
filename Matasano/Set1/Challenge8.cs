using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matasano.Set1
{
    public class Challenge8
    {
        public static string DetectAESECB(string[] inputs)
        {
            // Is this cheating? Checking for duplicates seems to work, unfortunately I don't have a way to verify the results
            foreach(var input in inputs)
            {
                var set = new HashSet<string>();
                for(var i = 0; i < input.Length; i += 32)
                {
                    if (!set.Add(input.Substring(i, 32)))
                    {
                        return input;
                    }
                }
            }
            throw new Exception("No duplicates found");
        }
    }
}
