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
            [DataRow((UInt32)1, "C")]
            [DataRow((UInt32)2, "Cel")]
            [DataRow((UInt32)3, "Celsius")]
            public void CelsiusIdentificationTest(UInt32 testNumber, string testDescription)
            {
                Assert.AreEqual(TemperatureScale.Celsius, Scale.Identify(testDescription));
            }
        }
    }
}
