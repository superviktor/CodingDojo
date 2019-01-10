using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals.Tests
{
    [TestClass]
    public class RomanNumeralsTests
    {
        [TestMethod]
        public void GetRomanKnownNumeralsLessThen10()
        {
            var romanNumeral = new RomanNumeral(1);
            Assert.AreEqual(romanNumeral.RomanValue, "I");

            romanNumeral = new RomanNumeral(5);
            Assert.AreEqual(romanNumeral.RomanValue, "V");

            romanNumeral = new RomanNumeral(10);
            Assert.AreEqual(romanNumeral.RomanValue, "X");
        }
        [TestMethod]
        public void GetRomanNumeralsLessThanKnown()
        {
            var romanNumeral = new RomanNumeral(4);
            Assert.AreEqual(romanNumeral.RomanValue, "IV");

            romanNumeral = new RomanNumeral(9);
            Assert.AreEqual(romanNumeral.RomanValue, "IX");
        }

        [TestMethod]
        public void GetRomanNumeralsMoreThanKnown()
        {
            var romanNumeral = new RomanNumeral(3);
            Assert.AreEqual(romanNumeral.RomanValue, "III");

            romanNumeral = new RomanNumeral(6);
            Assert.AreEqual(romanNumeral.RomanValue, "VI");

            romanNumeral = new RomanNumeral(8);
            Assert.AreEqual(romanNumeral.RomanValue, "VII");
        }
    }
}
