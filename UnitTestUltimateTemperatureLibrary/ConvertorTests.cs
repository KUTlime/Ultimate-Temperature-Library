using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UltimateTemperatureLibrary;

namespace UnitTestUltimateTemperatureLibrary
{
    public class ConvertorTests
    {
        [TestClass]
        public class Cel2FahTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void AbsoluteZeroTest()
            {
                Assert.AreEqual(Constants.AbsoluteZeroInFahrenheit, Converter.Cel2Fah(Constants.AbsoluteZeroInCelsius), Double.Epsilon);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void H20MeltingPointTest()
            {
                Assert.AreEqual(Constants.MeltingPointH2OInFahrenheit, Converter.Cel2Fah(Constants.MeltingPointH2OInCelsius), Double.Epsilon);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void H20BoilingPointTest()
            {
                Assert.AreEqual(Constants.BoilingPointH2OInFahrenheit, Converter.Cel2Fah(Constants.BoilingPointH2OInCelsius), Double.Epsilon);
            }
        }

        [TestClass]
        public class Cel2KelTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void AbsoluteZeroTest()
            {
                Assert.AreEqual(Constants.AbsoluteZeroInKelvin, Converter.Cel2Kel(Constants.AbsoluteZeroInCelsius), Double.Epsilon);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void H20MeltingPointTest()
            {
                Assert.AreEqual(Constants.MeltingPointH2OInKelvin, Converter.Cel2Kel(Constants.MeltingPointH2OInCelsius), Double.Epsilon);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void H20BoilingPointTest()
            {
                Assert.AreEqual(Constants.BoilingPointH2OInKelvin, Converter.Cel2Kel(Constants.BoilingPointH2OInCelsius), Double.Epsilon);
            }
        }
    }
}