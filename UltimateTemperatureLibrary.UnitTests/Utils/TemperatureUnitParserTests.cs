using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UltimateTemperatureLibrary.Utils;

namespace UltimateTemperatureLibrary.UnitTests.Utils
{
    public class TemperatureUnitParserTests
    {
        [TestClass]
        public class ParseTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void InvalidScaleStringTest()
            {
                Assert.AreEqual(new Kelvin(), TemperatureUnitParser.Parse((string)null));
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            [ExpectedException(typeof(FormatException))]
            public void InvalidFormatStringTest()
            {
                TemperatureUnitParser.Parse("33,33,33");
            }

            [TestCategory(TestCategory.BasicTests)]
            [DataTestMethod]
            [DataRow((UInt32)1, "0 K", DisplayName = "K unit ID")]
            [DataRow((UInt32)2, "-273.15 °C", DisplayName = "C unit ID")]
            [DataRow((UInt32)3, "-459.67 °F", DisplayName = "F unit ID")]
            [DataRow((UInt32)4, "0 °R", DisplayName = "R unit ID")]
            [DataRow((UInt32)5, "0 °Ra", DisplayName = "Ra unit ID")]
            [DataRow((UInt32)6, "559.725 °D", DisplayName = "D unit ID")]
            [DataRow((UInt32)7, "-90.1395 °N", DisplayName = "N unit ID")]
            [DataRow((UInt32)8, "-218.52 °Ré", DisplayName = "Re unit ID")]
            [DataRow((UInt32)9, "-218.52 °Re", DisplayName = "Re unit ID")]
            [DataRow((UInt32)10, "-135.90375 °Rø", DisplayName = "Rø unit ID")]

            public void UnitIdentificationTest(UInt32 testNumber, string stringToParse)
            {
                Assert.AreEqual(Constants.AbsoluteZeroInKelvin, TemperatureUnitParser.Parse(stringToParse).ToKelvin().Value);
            }
        }
    }
}
