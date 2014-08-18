using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatasanoTests
{
    [TestClass]
    public class Set2
    {
        [TestMethod]
        public void Challenge1()
        {
            var bytes = Encoding.ASCII.GetBytes("YELLOW SUBMARINE");
            var padded = Matasano.Set2.Challenge1.PKCS7Pad(bytes, 20);
            var paddedText = Encoding.ASCII.GetString(padded);
            Assert.AreEqual("YELLOW SUBMARINE\x04\x04\x04\x04", paddedText);

            var noPadding = Matasano.Set2.Challenge1.PKCS7Pad(bytes, 16);
            CollectionAssert.AreEqual(noPadding, bytes);
        }
    }
}
