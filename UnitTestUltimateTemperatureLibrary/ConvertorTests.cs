using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UltimateTemperatureLibrary;

namespace UnitTestUltimateTemperatureLibrary
{
    public class ConvertorTests
    {
        [TestClass]
        public class Cel2KelTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void AbsoluteZeroTest()
            {
                Assert.AreEqual(Constants.AbsoluteZeroInKelvin, Converter.Cel2Kel(Constants.AbsoluteZeroInCelsius), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void H20MeltingPointTest()
            {
                Assert.AreEqual(Constants.MeltingPointH2OInKelvin, Converter.Cel2Kel(Constants.MeltingPointH2OInCelsius), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void H20BoilingPointTest()
            {
                Assert.AreEqual(Constants.BoilingPointH2OInKelvin, Converter.Cel2Kel(Constants.BoilingPointH2OInCelsius), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [DataTestMethod]
            [DataRow((UInt32)1, (double)184, (double)-89.15, "The lowest measured temp on Earth.")]
            [DataRow((UInt32)2, (double)255.37, (double)-17.78, "The Fahrenheit's mixture of ice and salt")]
            [DataRow((UInt32)3, (double)288, (double)14.85, "The average temperature of the Earth surface.")]
            [DataRow((UInt32)4, (double)309.95, (double)36.8, "The average human body temperature.")]
            [DataRow((UInt32)5, (double)331, (double)57.85, "The highest measured temperature on Earth.")]
            [DataRow((UInt32)6, (double)1941, (double)1667.85, "The melting point of titanium.")]
            [DataRow((UInt32)7, (double)5800, (double)5526.85, "The temperature of the Sun surface.")]
            public void WikiListTemperatureTest(UInt32 testNumber, double tempInKelvin, double tempInCelsius, string testDescription)
            {
                Assert.AreEqual(tempInKelvin, Converter.Cel2Kel(tempInCelsius), 1e-13);
            }
        }

        [TestClass]
        public class Fah2KelTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void AbsoluteZeroTest()
            {
                Assert.AreEqual(Constants.AbsoluteZeroInKelvin, Converter.Fah2Kel(Constants.AbsoluteZeroInFahrenheit), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void H20MeltingPointTest()
            {
                Assert.AreEqual(Constants.MeltingPointH2OInKelvin, Converter.Fah2Kel(Constants.MeltingPointH2OInFahrenheit), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void H20BoilingPointTest()
            {
                Assert.AreEqual(Constants.BoilingPointH2OInKelvin, Converter.Fah2Kel(Constants.BoilingPointH2OInFahrenheit), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [DataTestMethod]
            [DataRow((UInt32)1, (double)184, (double)-128.47, "The lowest measured temp on Earth.", 1e-13)]
            [DataRow((UInt32)2, (double)255.372222222222, (double)0, "The Fahrenheit's mixture of ice and salt", 1e-12)]
            [DataRow((UInt32)3, (double)288, (double)58.73, "The average temperature of the Earth surface.", 1e-13)]
            [DataRow((UInt32)4, (double)309.95, (double)98.24, "The average human body temperature.", 1e-13)]
            [DataRow((UInt32)5, (double)331, (double)136.13, "The highest measured temperature on Earth.", 1e-13)]
            [DataRow((UInt32)6, (double)1941, (double)3034.13, "The melting point of titanium.", 1e-13)]
            [DataRow((UInt32)7, (double)5800, (double)9980.33, "The temperature of the Sun surface.", 1e-13)]
            public void WikiListTemperatureTest(UInt32 testNumber, double tempInKelvin, double tempInFahrenheit, string testDescription, double delta)
            {
                Assert.AreEqual(tempInKelvin, Converter.Fah2Kel(tempInFahrenheit), delta);
            }
        }

        [TestClass]
        public class Ran2KelTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void AbsoluteZeroTest()
            {
                Assert.AreEqual(Constants.AbsoluteZeroInKelvin, Converter.Ran2Kel(Constants.AbsoluteZeroInRankine), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void H20MeltingPointTest()
            {
                Assert.AreEqual(Constants.MeltingPointH2OInKelvin, Converter.Ran2Kel(Constants.MeltingPointH2OInRankine), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void H20BoilingPointTest()
            {
                Assert.AreEqual(Constants.BoilingPointH2OInKelvin, Converter.Ran2Kel(Constants.BoilingPointH2OInRankine), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [DataTestMethod]
            [DataRow((UInt32)1, (double)184, (double)331.2, "The lowest measured temp on Earth.", 1e-13)]
            [DataRow((UInt32)2, (double)255.37, (double)459.666, "The Fahrenheit's mixture of ice and salt", 1e-13)]
            [DataRow((UInt32)3, (double)288, (double)518.4, "The average temperature of the Earth surface.", 1e-13)]
            [DataRow((UInt32)4, (double)309.95, (double)557.91, "The average human body temperature.", 1e-13)]
            [DataRow((UInt32)5, (double)331, (double)595.8, "The highest measured temperature on Earth.", 1e-12)]
            [DataRow((UInt32)6, (double)1941, (double)3493.8, "The melting point of titanium.", 1e-13)]
            [DataRow((UInt32)7, (double)5800, (double)10440, "The temperature of the Sun surface.", 1e-13)]
            public void WikiListTemperatureTest(UInt32 testNumber, double tempInKelvin, double tempInRankine, string testDescription, double delta)
            {
                Assert.AreEqual(tempInKelvin, Converter.Ran2Kel(tempInRankine), delta);
            }
        }

        [TestClass]
        public class Del2KelTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void AbsoluteZeroTest()
            {
                Assert.AreEqual(Constants.AbsoluteZeroInKelvin, Converter.Del2Kel(Constants.AbsoluteZeroInDelisle), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void H20MeltingPointTest()
            {
                Assert.AreEqual(Constants.MeltingPointH2OInKelvin, Converter.Del2Kel(Constants.MeltingPointH2OInDelisle), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void H20BoilingPointTest()
            {
                Assert.AreEqual(Constants.BoilingPointH2OInKelvin, Converter.Del2Kel(Constants.BoilingPointH2OInDelisle), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [DataTestMethod]
            [DataRow((UInt32)1, (double)184, (double)283.725, "The lowest measured temp on Earth.", (double)1e-13)]
            [DataRow((UInt32)2, (double)255.37, (double)176.67, "The Fahrenheit's mixture of ice and salt", (double)1e-13)]
            [DataRow((UInt32)3, (double)288, (double)127.725, "The average temperature of the Earth surface.", (double)1e-13)]
            [DataRow((UInt32)4, (double)309.95, (double)94.8, "The average human body temperature.", (double)1e-13)]
            [DataRow((UInt32)5, (double)331, (double)63.225, "The highest measured temperature on Earth.", (double)1e-13)]
            [DataRow((UInt32)6, (double)1941, (double)-2351.775, "The melting point of titanium.", (double)1e-13)]
            [DataRow((UInt32)7, (double)5800, (double)-8140.275, "The temperature of the Sun surface.", (double)1e-12)] // We can't beat the difference 9,something e-13.
            public void WikiListTemperatureTest(UInt32 testNumber, double tempInKelvin, double tempInDelisle, string testDescription, double delta)
            {
                Assert.AreEqual(tempInKelvin, Converter.Del2Kel(tempInDelisle), delta);
            }
        }

        [TestClass]
        public class New2KelTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void AbsoluteZeroTest()
            {
                Assert.AreEqual(Constants.AbsoluteZeroInKelvin, Converter.New2Kel(Constants.AbsoluteZeroInNewton), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void H20MeltingPointTest()
            {
                Assert.AreEqual(Constants.MeltingPointH2OInKelvin, Converter.New2Kel(Constants.MeltingPointH2OInNewton), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void H20BoilingPointTest()
            {
                Assert.AreEqual(Constants.BoilingPointH2OInKelvin, Converter.New2Kel(Constants.BoilingPointH2OInNewton), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [DataTestMethod]
            [DataRow((UInt32)1, (double)184, (double)-29.4195, "The lowest measured temp on Earth.", 1e-13)]
            [DataRow((UInt32)2, (double)255.37, (double)-5.8674, "The Fahrenheit's mixture of ice and salt", 1e-13)]
            [DataRow((UInt32)3, (double)288, (double)4.9005, "The average temperature of the Earth surface.", 1e-13)]
            [DataRow((UInt32)4, (double)309.95, (double)12.144, "The average human body temperature.", 1e-13)]
            [DataRow((UInt32)5, (double)331, (double)19.0905, "The highest measured temperature on Earth.", 1e-13)]
            [DataRow((UInt32)6, (double)1941, (double)550.3905, "The melting point of titanium.", 1e-13)]
            [DataRow((UInt32)7, (double)5800, (double)1823.8605, "The temperature of the Sun surface.", 1e-12)]
            public void WikiListTemperatureTest(UInt32 testNumber, double tempInKelvin, double tempInNewton, string testDescription, double delta)
            {
                Assert.AreEqual(tempInKelvin, Converter.New2Kel(tempInNewton), delta);
            }
        }

        [TestClass]
        public class Réau2KelTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void AbsoluteZeroTest()
            {
                Assert.AreEqual(Constants.AbsoluteZeroInKelvin, Converter.Réau2Kel(Constants.AbsoluteZeroInRéaumur), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void H20MeltingPointTest()
            {
                Assert.AreEqual(Constants.MeltingPointH2OInKelvin, Converter.Réau2Kel(Constants.MeltingPointH2OInRéaumur), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void H20BoilingPointTest()
            {
                Assert.AreEqual(Constants.BoilingPointH2OInKelvin, Converter.Réau2Kel(Constants.BoilingPointH2OInRéaumur), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [DataTestMethod]
            [DataRow((UInt32)1, (double)184, (double)-71.32, "The lowest measured temp on Earth.", 1e-13)]
            [DataRow((UInt32)2, (double)255.37, (double)-14.224, "The Fahrenheit's mixture of ice and salt", 1e-13)]
            [DataRow((UInt32)3, (double)288, (double)11.88, "The average temperature of the Earth surface.", 1e-13)]
            [DataRow((UInt32)4, (double)309.95, (double)29.44, "The average human body temperature.", 1e-13)]
            [DataRow((UInt32)5, (double)331, (double)46.28, "The highest measured temperature on Earth.", 1e-13)]
            [DataRow((UInt32)6, (double)1941, (double)1334.28, "The melting point of titanium.", 1e-13)]
            [DataRow((UInt32)7, (double)5800, (double)4421.48, "The temperature of the Sun surface.", 1e-12)]
            public void WikiListTemperatureTest(UInt32 testNumber, double tempInKelvin, double tempInNewton, string testDescription, double delta)
            {
                Assert.AreEqual(tempInKelvin, Converter.Réau2Kel(tempInNewton), delta);
            }
        }

        [TestClass]
        public class Røm2KelTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void AbsoluteZeroTest()
            {
                Assert.AreEqual(Constants.AbsoluteZeroInKelvin, Converter.Røm2Kel(Constants.AbsoluteZeroInRømer), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void H20MeltingPointTest()
            {
                Assert.AreEqual(Constants.MeltingPointH2OInKelvin, Converter.Røm2Kel(Constants.MeltingPointH2OInRømer), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void H20BoilingPointTest()
            {
                Assert.AreEqual(Constants.BoilingPointH2OInKelvin, Converter.Røm2Kel(Constants.BoilingPointH2OInRømer), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [DataTestMethod]
            [DataRow((UInt32)1, (double)184, (double)-39.30375, "The lowest measured temp on Earth.", 1e-13)]
            [DataRow((UInt32)2, (double)255.37, (double)-1.8345, "The Fahrenheit's mixture of ice and salt", 1e-13)]
            [DataRow((UInt32)3, (double)288, (double)15.29625, "The average temperature of the Earth surface.", 1e-13)]
            [DataRow((UInt32)4, (double)309.95, (double)26.82, "The average human body temperature.", 1e-13)]
            [DataRow((UInt32)5, (double)331, (double)37.87125, "The highest measured temperature on Earth.", 1e-13)]
            [DataRow((UInt32)6, (double)1941, (double)883.12125, "The melting point of titanium.", 1e-12)]
            [DataRow((UInt32)7, (double)5800, (double)2909.09625, "The temperature of the Sun surface.", 1e-13)]
            public void WikiListTemperatureTest(UInt32 testNumber, double tempInKelvin, double tempInNewton, string testDescription, double delta)
            {
                Assert.AreEqual(tempInKelvin, Converter.Røm2Kel(tempInNewton), delta);
            }
        }

        [TestClass]
        public class Kel2CelTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void AbsoluteZeroTest()
            {
                Assert.AreEqual(Constants.AbsoluteZeroInCelsius, Converter.Kel2Cel(Constants.AbsoluteZeroInKelvin), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void H20MeltingPointTest()
            {
                Assert.AreEqual(Constants.MeltingPointH2OInCelsius, Converter.Kel2Cel(Constants.MeltingPointH2OInKelvin), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void H20BoilingPointTest()
            {
                Assert.AreEqual(Constants.BoilingPointH2OInCelsius, Converter.Kel2Cel(Constants.BoilingPointH2OInKelvin), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [DataTestMethod]
            [DataRow((UInt32)1, (double)184, (double)-89.15, "The lowest measured temp on Earth.", 1e-13)]
            [DataRow((UInt32)2, (double)255.372222222222, (double)-17.77777777778, "The Fahrenheit's mixture of ice and salt", 1e-11)]
            [DataRow((UInt32)3, (double)288, (double)14.85, "The average temperature of the Earth surface.", 1e-13)]
            [DataRow((UInt32)4, (double)309.95, (double)36.8, "The average human body temperature.", 1e-13)]
            [DataRow((UInt32)5, (double)331, (double)57.85, "The highest measured temperature on Earth.", 1e-13)]
            [DataRow((UInt32)6, (double)1941, (double)1667.85, "The melting point of titanium.", 1e-13)]
            [DataRow((UInt32)7, (double)5800, (double)5526.85, "The temperature of the Sun surface.", 1e-13)]
            public void WikiListTemperatureTest(UInt32 testNumber, double tempInKelvin, double tempInCelsius, string testDesciption, double delta)
            {
                Assert.AreEqual(tempInCelsius, Converter.Kel2Cel(tempInKelvin), delta);
            }
        }

        [TestClass]
        public class Kel2FahTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void AbsoluteZeroTest()
            {
                Assert.AreEqual(Constants.AbsoluteZeroInFahrenheit, Converter.Kel2Fah(Constants.AbsoluteZeroInKelvin), 1e-12);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void H20MeltingPointTest()
            {
                Assert.AreEqual(Constants.MeltingPointH2OInFahrenheit, Converter.Kel2Fah(Constants.MeltingPointH2OInKelvin), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void H20BoilingPointTest()
            {
                Assert.AreEqual(Constants.BoilingPointH2OInFahrenheit, Converter.Kel2Fah(Constants.BoilingPointH2OInKelvin), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [DataTestMethod]
            [DataRow((UInt32)1, (double)184, (double)-128.47, "The lowest measured temp on Earth.", 1e-13)]
            [DataRow((UInt32)2, (double)255.372222222222, (double)0, "The Fahrenheit's mixture of ice and salt", 1e-12)]
            [DataRow((UInt32)3, (double)288, (double)58.73, "The average temperature of the Earth surface.", 1e-13)]
            [DataRow((UInt32)4, (double)309.95, (double)98.24, "The average human body temperature.", 1e-13)]
            [DataRow((UInt32)5, (double)331, (double)136.13, "The highest measured temperature on Earth.", 1e-13)]
            [DataRow((UInt32)6, (double)1941, (double)3034.13, "The melting point of titanium.", 1e-13)]
            [DataRow((UInt32)7, (double)5800, (double)9980.33, "The temperature of the Sun surface.", 1e-13)]
            public void WikiListTemperatureTest(UInt32 testNumber, double tempInKelvin, double tempInFahrenheit, string testDescription, double delta)
            {
                Assert.AreEqual(tempInFahrenheit, Converter.Kel2Fah(tempInKelvin), delta);
            }
        }

        [TestClass]
        public class Kel2RanTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void AbsoluteZeroTest()
            {
                Assert.AreEqual(Constants.AbsoluteZeroInRankine, Converter.Kel2Ran(Constants.AbsoluteZeroInKelvin), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void H20MeltingPointTest()
            {
                Assert.AreEqual(Constants.MeltingPointH2OInRankine, Converter.Kel2Ran(Constants.MeltingPointH2OInKelvin), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void H20BoilingPointTest()
            {
                Assert.AreEqual(Constants.BoilingPointH2OInRankine, Converter.Kel2Ran(Constants.BoilingPointH2OInKelvin), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [DataTestMethod]
            [DataRow((UInt32)1, (double)184, (double)331.2, "The lowest measured temp on Earth.", 1e-13)]
            [DataRow((UInt32)2, (double)255.37, (double)459.666, "The Fahrenheit's mixture of ice and salt", 1e-13)]
            [DataRow((UInt32)3, (double)288, (double)518.4, "The average temperature of the Earth surface.", 1e-13)]
            [DataRow((UInt32)4, (double)309.95, (double)557.91, "The average human body temperature.", 1e-13)]
            [DataRow((UInt32)5, (double)331, (double)595.8, "The highest measured temperature on Earth.", 1e-12)]
            [DataRow((UInt32)6, (double)1941, (double)3493.8, "The melting point of titanium.", 1e-13)]
            [DataRow((UInt32)7, (double)5800, (double)10440, "The temperature of the Sun surface.", 1e-13)]
            public void WikiListTemperatureTest(UInt32 testNumber, double tempInKelvin, double tempInRankine, string testDescption, double delta)
            {
                Assert.AreEqual(tempInRankine, Converter.Kel2Ran(tempInKelvin), delta);
            }
        }

        [TestClass]
        public class Kel2DelTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void AbsoluteZeroTest()
            {
                Assert.AreEqual(Constants.AbsoluteZeroInDelisle, Converter.Kel2Del(Constants.AbsoluteZeroInKelvin), 1e-12);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void H20MeltingPointTest()
            {
                Assert.AreEqual(Constants.MeltingPointH2OInDelisle, Converter.Kel2Del(Constants.MeltingPointH2OInKelvin), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void H20BoilingPointTest()
            {
                Assert.AreEqual(Constants.BoilingPointH2OInDelisle, Converter.Kel2Del(Constants.BoilingPointH2OInKelvin), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [DataTestMethod]
            [DataRow((UInt32)1, (double)184, (double)283.5, "The lowest measured temp on Earth.", 1e-13)]
            [DataRow((UInt32)2, (double)255.37, (double)176.67, "The Fahrenheit's mixture of ice and salt", 1e-13)]
            [DataRow((UInt32)3, (double)288, (double)127.5, "The average temperature of the Earth surface.", 1e-13)]
            [DataRow((UInt32)4, (double)309.95, (double)94.8, "The average human body temperature.", 1e-13)]
            [DataRow((UInt32)5, (double)331, (double)63, "The highest measured temperature on Earth.", 1e-13)]
            [DataRow((UInt32)6, (double)1941, (double)-2352, "The melting point of titanium.", 1e-13)]
            [DataRow((UInt32)7, (double)5800, (double)-10440, "The temperature of the Sun surface.", 1e-13)]
            public void WikiListTemperatureTest(UInt32 testNumber, double tempInKelvin, double tempInDelisle, string testDescription, double delta)
            {
                Assert.AreEqual(tempInKelvin, Converter.Kel2Del(tempInDelisle), 1e-13);
            }
        }

        [TestClass]
        public class Kel2NewTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void AbsoluteZeroTest()
            {
                Assert.AreEqual(Constants.AbsoluteZeroInNewton, Converter.Kel2New(Constants.AbsoluteZeroInKelvin), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void H20MeltingPointTest()
            {
                Assert.AreEqual(Constants.MeltingPointH2OInNewton, Converter.Kel2New(Constants.MeltingPointH2OInKelvin), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void H20BoilingPointTest()
            {
                Assert.AreEqual(Constants.BoilingPointH2OInNewton, Converter.Kel2New(Constants.BoilingPointH2OInKelvin), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [DataTestMethod]
            [DataRow((UInt32)1, (double)184, (double)-29.4195, "The lowest measured temp on Earth.", 1e-13)]
            [DataRow((UInt32)2, (double)255.37, (double)-5.8674, "The Fahrenheit's mixture of ice and salt", 1e-13)]
            [DataRow((UInt32)3, (double)288, (double)4.9005, "The average temperature of the Earth surface.", 1e-13)]
            [DataRow((UInt32)4, (double)309.95, (double)12.144, "The average human body temperature.", 1e-13)]
            [DataRow((UInt32)5, (double)331, (double)19.0905, "The highest measured temperature on Earth.", 1e-13)]
            [DataRow((UInt32)6, (double)1941, (double)550.3905, "The melting point of titanium.", 1e-13)]
            [DataRow((UInt32)7, (double)5800, (double)1823.8605, "The temperature of the Sun surface.", 1e-12)]
            public void WikiListTemperatureTest(UInt32 testNumber, double tempInKelvin, double tempInNewton, string testDescription, double delta)
            {
                Assert.AreEqual(tempInNewton, Converter.Kel2New(tempInKelvin), delta);
            }
        }

        [TestClass]
        public class Kel2RéauTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void AbsoluteZeroTest()
            {
                Assert.AreEqual(Constants.AbsoluteZeroInRéaumur, Converter.Kel2Réau(Constants.AbsoluteZeroInKelvin), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void H20MeltingPointTest()
            {
                Assert.AreEqual(Constants.MeltingPointH2OInRéaumur, Converter.Kel2Réau(Constants.MeltingPointH2OInKelvin), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void H20BoilingPointTest()
            {
                Assert.AreEqual(Constants.BoilingPointH2OInRéaumur, Converter.Kel2Réau(Constants.BoilingPointH2OInKelvin), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [DataTestMethod]
            [DataRow((UInt32)1, (double)184, (double)-71.32, "The lowest measured temp on Earth.", 1e-13)]
            [DataRow((UInt32)2, (double)255.37, (double)-14.224, "The Fahrenheit's mixture of ice and salt", 1e-13)]
            [DataRow((UInt32)3, (double)288, (double)11.88, "The average temperature of the Earth surface.", 1e-13)]
            [DataRow((UInt32)4, (double)309.95, (double)29.44, "The average human body temperature.", 1e-13)]
            [DataRow((UInt32)5, (double)331, (double)46.28, "The highest measured temperature on Earth.", 1e-13)]
            [DataRow((UInt32)6, (double)1941, (double)1334.28, "The melting point of titanium.", 1e-13)]
            [DataRow((UInt32)7, (double)5800, (double)4421.48, "The temperature of the Sun surface.", 1e-12)]
            public void WikiListTemperatureTest(UInt32 testNumber, double tempInKelvin, double tempInRéaumur, string testDescription, double delta)
            {
                Assert.AreEqual(tempInRéaumur, Converter.Kel2Réau(tempInKelvin), delta);
            }
        }

        [TestClass]
        public class Kel2RømTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void AbsoluteZeroTest()
            {
                Assert.AreEqual(Constants.AbsoluteZeroInRømer, Converter.Kel2Røm(Constants.AbsoluteZeroInKelvin), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void H20MeltingPointTest()
            {
                Assert.AreEqual(Constants.MeltingPointH2OInRømer, Converter.Kel2Røm(Constants.MeltingPointH2OInKelvin), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void H20BoilingPointTest()
            {
                Assert.AreEqual(Constants.BoilingPointH2OInRømer, Converter.Kel2Røm(Constants.BoilingPointH2OInKelvin), 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [DataTestMethod]
            [DataRow((UInt32)1, (double)184, (double)-39.30375, "The lowest measured temp on Earth.", 1e-13)]
            [DataRow((UInt32)2, (double)255.37, (double)-1.8345, "The Fahrenheit's mixture of ice and salt", 1e-13)]
            [DataRow((UInt32)3, (double)288, (double)15.29625, "The average temperature of the Earth surface.", 1e-13)]
            [DataRow((UInt32)4, (double)309.95, (double)26.82, "The average human body temperature.", 1e-13)]
            [DataRow((UInt32)5, (double)331, (double)37.87125, "The highest measured temperature on Earth.", 1e-13)]
            [DataRow((UInt32)6, (double)1941, (double)883.12125, "The melting point of titanium.", 1e-12)]
            [DataRow((UInt32)7, (double)5800, (double)2909.09625, "The temperature of the Sun surface.", 1e-13)]
            public void WikiListTemperatureTest(UInt32 testNumber, double tempInKelvin, double tempInRømer, string testDescription, double delta)
            {
                Assert.AreEqual(tempInRømer, Converter.Kel2Røm(tempInKelvin), delta);
            }
        }
    }
}