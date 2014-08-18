using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Matasano.Set1;
using Matasano;
using System.Text;

namespace MatasanoTests
{
    [TestClass]
    public class Set1
    {
        [TestMethod]
        public void Challenge1()
        {
            var b64 = Matasano.Set1.Challenge1.HexToBase64("49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d");
            Assert.AreEqual("SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t", b64);
        }

        [TestMethod]
        public void Challenge2()
        {
            var xord = Matasano.Set1.Challenge2.FixedXOR("1c0111001f010100061a024b53535009181c", "686974207468652062756c6c277320657965");
            Assert.IsTrue(string.Equals("746865206b696420646f6e277420706c6179", xord, StringComparison.CurrentCultureIgnoreCase));
        }

        [TestMethod]
        public void Challenge3()
        {
            var decodedScore = Matasano.Set1.Challenge3.DecodeSingleByteXORCipher("1b37373331363f78151b7f2b783431333d78397828372d363c78373e783a393b3736");
            Assert.AreEqual("Cooking MC's like a pound of bacon", decodedScore.Text);
        }

        [TestMethod]
        public void Challenge4()
        {
            var c4Lines = Set1Data.Challenge4.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var decodedScore = Matasano.Set1.Challenge4.FindDecodedText(c4Lines);
            Assert.AreEqual("Now that the party is jumping\n", decodedScore.Text);
        }

        [TestMethod]
        public void Challenge5()
        {
            var text = "Burning 'em, if you ain't quick and nimble\nI go crazy when I hear a cymbal";
            var expected = "0b3637272a2b2e63622c2e69692a23693a2a3c6324202d623d63343c2a26226324272765272a282b2f20430a652e2c652a3124333a653e2b2027630c692b20283165286326302e27282f";
            var encHex = Matasano.Set1.Challenge5.RepeatingKeyXOR(text, "ICE");
            Assert.IsTrue(string.Equals(expected, encHex, StringComparison.CurrentCultureIgnoreCase));
        }

        [TestMethod]
        public void Challenge6HammingDistance()
        {
            var distance = Matasano.Set1.Challenge6.HammingDistance("this is a test", "wokka wokka!!!");
            Assert.AreEqual(37, distance);
        }

        [TestMethod]
        public void Challenge6()
        {
            var c6Data = Set1Data.Challenge6.Replace(Environment.NewLine, "");
            var decrypted = Matasano.Set1.Challenge6.BreakRepeatingKeyXOR(c6Data);
            var firstLine = decrypted.Split('\n')[0];
            Assert.AreEqual("I'm back and I'm ringin' the bell ", firstLine);
        }

        [TestMethod]
        public void Challenge7()
        {
            var c7Data = Set1Data.Challenge7.Replace(Environment.NewLine, "");
            var decrypted = Matasano.Set1.Challenge7.DecryptAES128ECB(c7Data, "YELLOW SUBMARINE");
            var firstLine = decrypted.Split('\n')[0];
            Assert.AreEqual("I'm back and I'm ringin' the bell ", firstLine);
        }
    }
}
