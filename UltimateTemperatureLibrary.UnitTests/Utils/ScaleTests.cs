using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UltimateTemperatureLibrary.Enums;
using UltimateTemperatureLibrary.Utils;

namespace UltimateTemperatureLibrary.UnitTests.Utils
{
    [TestClass]
    public class ScaleTests
    {
        [TestClass]
        public class IdentifyMethodTests
        {

            [TestCategory(TestCategory.BasicTests)]
            [DataTestMethod]
            [DataRow((UInt32)1, "C", DisplayName = "C unit ID")]
            [DataRow((UInt32)2, "Cel", DisplayName = "Cel unit ID")]
            [DataRow((UInt32)3, "cel", DisplayName = "cel unit ID")]
            [DataRow((UInt32)4, "Celsius", DisplayName = "Celsius unit ID")]
            [DataRow((UInt32)5, "celsius", DisplayName = "celsius unit ID")]
            public void CelsiusIdentificationTest(UInt32 testNumber, string testDescription)
            {
                Assert.AreEqual(TemperatureScale.Celsius, Scale.Identify(testDescription));
            }

            [TestCategory(TestCategory.BasicTests)]
            [DataTestMethod]
            [DataRow((UInt32)1, "K", DisplayName = "K unit ID")]
            [DataRow((UInt32)2, "Kel", DisplayName = "Kel unit ID")]
            [DataRow((UInt32)3, "kel", DisplayName = "kel unit ID")]
            [DataRow((UInt32)4, "Kelvin", DisplayName = "Kelvin unit ID")]
            [DataRow((UInt32)5, "kelvin", DisplayName = "kelvin unit ID")]
            [DataRow((UInt32)6, "KELVIN", DisplayName = "KELVIN unit ID")]
            public void KelvinIdentificationTest(UInt32 testNumber, string testDescription)
            {
                Assert.AreEqual(TemperatureScale.Kelvin, Scale.Identify(testDescription));
            }

            [TestCategory(TestCategory.BasicTests)]
            [DataTestMethod]
            [DataRow((UInt32)1, "F", DisplayName = "F unit ID")]
            [DataRow((UInt32)2, "Fah", DisplayName = "Fah unit ID")]
            [DataRow((UInt32)3, "fah", DisplayName = "fah unit ID")]
            [DataRow((UInt32)4, "Fahrenheit", DisplayName = "Fahrenheit unit ID")]
            [DataRow((UInt32)5, "fahrenheit", DisplayName = "fahrenheit unit ID")]
            [DataRow((UInt32)6, "FAHRENHEIT", DisplayName = "FAHRENHEIT unit ID")]
            public void FahrenheitIdentificationTest(UInt32 testNumber, string testDescription)
            {
                Assert.AreEqual(TemperatureScale.Fahrenheit, Scale.Identify(testDescription));
            }

            [TestCategory(TestCategory.BasicTests)]
            [DataTestMethod]
            [DataRow((UInt32)1, "R", DisplayName = "R unit ID")]
            [DataRow((UInt32)2, "Ra", DisplayName = "Ra unit ID")]
            [DataRow((UInt32)3, "Ran", DisplayName = "Ran unit ID")]
            [DataRow((UInt32)4, "Rankine", DisplayName = "Rankine unit ID")]
            [DataRow((UInt32)5, "ra", DisplayName = "ra unit ID")]
            [DataRow((UInt32)6, "ran", DisplayName = "ran unit ID")]
            [DataRow((UInt32)7, "rankine", DisplayName = "rankine unit ID")]
            [DataRow((UInt32)8, "RANKINE", DisplayName = "RANKINE unit ID")]
            public void RankineIdentificationTest(UInt32 testNumber, string testDescription)
            {
                Assert.AreEqual(TemperatureScale.Rankine, Scale.Identify(testDescription));
            }

            [TestCategory(TestCategory.BasicTests)]
            [DataTestMethod]
            [DataRow((UInt32)1, "D", DisplayName = "D unit ID")]
            [DataRow((UInt32)2, "Delisle", DisplayName = "Delisle unit ID")]
            [DataRow((UInt32)3, "delisle", DisplayName = "delisle unit ID")]
            [DataRow((UInt32)4, "DELISLE", DisplayName = "DELISLE unit ID")]
            [DataRow((UInt32)5, "De", DisplayName = "De unit ID")]
            public void DelisleIdentificationTest(UInt32 testNumber, string testDescription)
            {
                Assert.AreEqual(TemperatureScale.Delisle, Scale.Identify(testDescription));
            }

            [TestCategory(TestCategory.BasicTests)]
            [DataTestMethod]
            [DataRow((UInt32)1, "N", DisplayName = "N unit ID")]
            [DataRow((UInt32)2, "Newton", DisplayName = "Newton unit ID")]
            [DataRow((UInt32)3, "newton", DisplayName = "newton unit ID")]
            [DataRow((UInt32)4, "NEWTON", DisplayName = "NEWTON unit ID")]
            public void NewtonIdentificationTest(UInt32 testNumber, string testDescription)
            {
                Assert.AreEqual(TemperatureScale.Newton, Scale.Identify(testDescription));
            }

            [TestCategory(TestCategory.BasicTests)]
            [DataTestMethod]
            [DataRow((UInt32)1, "Re", DisplayName = "Re unit ID")]
            [DataRow((UInt32)2, "Ré", DisplayName = "Re unit ID")]
            [DataRow((UInt32)3, "re", DisplayName = "re unit ID")]
            [DataRow((UInt32)4, "ré", DisplayName = "ré unit ID")]
            [DataRow((UInt32)5, "Réaumur", DisplayName = "Réaumur unit ID")]
            [DataRow((UInt32)6, "réaumur", DisplayName = "réaumur unit ID")]
            [DataRow((UInt32)7, "RÉAUMUR", DisplayName = "RÉAUMUR unit ID")]
            [DataRow((UInt32)8, "Reaumur", DisplayName = "Reaumur unit ID")]
            [DataRow((UInt32)9, "reaumur", DisplayName = "reaumur unit ID")]
            [DataRow((UInt32)10, "REAUMUR", DisplayName = "REAUMUR unit ID")]
            [DataRow((UInt32)11, "Réau", DisplayName = "Réau unit ID")]
            [DataRow((UInt32)12, "réau", DisplayName = "réau unit ID")]
            [DataRow((UInt32)13, "RÉAU", DisplayName = "RÉAU unit ID")]
            [DataRow((UInt32)14, "Reau", DisplayName = "Reau unit ID")]
            [DataRow((UInt32)15, "reau", DisplayName = "reau unit ID")]
            [DataRow((UInt32)16, "REAU", DisplayName = "REAU unit ID")]

            public void RéaumurIdentificationTest(UInt32 testNumber, string testDescription)
            {
                Assert.AreEqual(TemperatureScale.Réaumur, Scale.Identify(testDescription));
            }

            [TestCategory(TestCategory.BasicTests)]
            [DataTestMethod]
            [DataRow((UInt32)1, "Rø", DisplayName = "Rø unit ID")]
            [DataRow((UInt32)2, "rø", DisplayName = "rø unit ID")]
            [DataRow((UInt32)3, "RØ", DisplayName = "RØ unit ID")]
            [DataRow((UInt32)4, "Rømer", DisplayName = "Rømer unit ID")]
            [DataRow((UInt32)5, "rømer", DisplayName = "rømer unit ID")]
            [DataRow((UInt32)6, "RØMER", DisplayName = "RØMER unit ID")]
            public void RømerIdentificationTest(UInt32 testNumber, string testDescription)
            {
                Assert.AreEqual(TemperatureScale.Rømer, Scale.Identify(testDescription));
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void InvalidScaleStringTest()
            {
                Scale.Identify((string)null);
            }
        }
    }
}