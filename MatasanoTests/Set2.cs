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
        }

        [TestMethod]
        public void Challenge1NoPadding()
        {
            var bytes = Encoding.ASCII.GetBytes("YELLOW SUBMARINE");

            var noPadding = Matasano.Set2.Challenge1.PKCS7Pad(bytes, 16);
            CollectionAssert.AreEqual(bytes, noPadding);
        }

        [TestMethod]
        public void Challenge1PadSmallerThanInput()
        {
            var bytes = Encoding.ASCII.GetBytes("YELLOW SUBMARINE");

            var padded = Matasano.Set2.Challenge1.PKCS7Pad(bytes, 7);
            var paddedText = Encoding.ASCII.GetString(padded);
            Assert.AreEqual("YELLOW SUBMARINE\x05\x05\x05\x05\x05", paddedText);
        }

        [TestMethod]
        public void Challenge2BlockEncryptor()
        {
            var plaintext = "sixteenbyteslong";
            var key = "YELLOW SUBMARINE";
            var textBytes = Encoding.ASCII.GetBytes(plaintext);
            var keyBytes = Encoding.ASCII.GetBytes(key);
            var encrypted = Matasano.Set1.Challenge7.EncryptAES128ECB(textBytes, keyBytes);
            var decrypted = Matasano.Set1.Challenge7.DecryptAES128ECB(encrypted, keyBytes);
            CollectionAssert.AreEqual(textBytes, decrypted);
        }

        [TestMethod]
        public void Challenge2()
        {
            var ch2Data = Set2Data.Challenge2.Replace(Environment.NewLine, "");
            var bytes = Convert.FromBase64String(ch2Data);
            var key = Encoding.ASCII.GetBytes("YELLOW SUBMARINE");
            var decrypted = Matasano.Set2.Challenge2.DecryptCBC(bytes, key);
            var decText = Encoding.ASCII.GetString(decrypted);
            var firstLine = decText.Split('\n')[0];

            Assert.AreEqual("I'm back and I'm ringin' the bell ", firstLine);

            var encrypted = Matasano.Set2.Challenge2.EncryptCBC(decrypted, key);
            CollectionAssert.AreEqual(bytes, encrypted);
        }
    }
}
