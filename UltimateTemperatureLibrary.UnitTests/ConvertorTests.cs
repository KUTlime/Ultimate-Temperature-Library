using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UltimateTemperatureLibrary.Utils;

namespace UltimateTemperatureLibrary.UnitTests
{
	public class ConvertorTests
	{
		[TestClass]
		public class Cel2KelTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInKelvin, Converter.Cel2Kel(Constants.AbsoluteZeroInCelsius), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInKelvin, Converter.Cel2Kel(Constants.MeltingPointH2OInCelsius), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInKelvin, Converter.Cel2Kel(Constants.BoilingPointH2OInCelsius), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[DataTestMethod]
			[DataRow((UInt32) 1, (double) 184, (double) -89.15, "The lowest measured temp on Earth.")]
			[DataRow((UInt32) 2, (double) 255.37, (double) -17.78, "The Fahrenheit's mixture of ice and salt")]
			[DataRow((UInt32) 3, (double) 288, (double) 14.85, "The average temperature of the Earth surface.")]
			[DataRow((UInt32) 4, (double) 309.95, (double) 36.8, "The average human body temperature.")]
			[DataRow((UInt32) 5, (double) 331, (double) 57.85, "The highest measured temperature on Earth.")]
			[DataRow((UInt32) 6, (double) 1941, (double) 1667.85, "The melting point of titanium.")]
			[DataRow((UInt32) 7, (double) 5800, (double) 5526.85, "The temperature of the Sun surface.")]
			public void WikiListTemperatureTest(UInt32 testNumber, double tempInKelvin, double tempInCelsius, string testDescription) => Assert.AreEqual(tempInKelvin, Converter.Cel2Kel(tempInCelsius), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Fah2KelTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInKelvin, Converter.Fah2Kel(Constants.AbsoluteZeroInFahrenheit), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInKelvin, Converter.Fah2Kel(Constants.MeltingPointH2OInFahrenheit), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInKelvin, Converter.Fah2Kel(Constants.BoilingPointH2OInFahrenheit), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[DataTestMethod]
			[DataRow((UInt32) 1, (double) 184, (double) -128.47, "The lowest measured temp on Earth.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 2, (double) 255.372222222222, (double) 0, "The Fahrenheit's mixture of ice and salt", OperationOverDoublePrecision.MiddlePrecision)]
			[DataRow((UInt32) 3, (double) 288, (double) 58.73, "The average temperature of the Earth surface.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 4, (double) 309.95, (double) 98.24, "The average human body temperature.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 5, (double) 331, (double) 136.13, "The highest measured temperature on Earth.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 6, (double) 1941, (double) 3034.13, "The melting point of titanium.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 7, (double) 5800, (double) 9980.33, "The temperature of the Sun surface.", OperationOverDoublePrecision.HighPrecision)]
			public void WikiListTemperatureTest(UInt32 testNumber, double tempInKelvin, double tempInFahrenheit, string testDescription, double delta) => Assert.AreEqual(tempInKelvin, Converter.Fah2Kel(tempInFahrenheit), delta);
		}

		[TestClass]
		public class Ran2KelTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInKelvin, Converter.Ran2Kel(Constants.AbsoluteZeroInRankine), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInKelvin, Converter.Ran2Kel(Constants.MeltingPointH2OInRankine), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInKelvin, Converter.Ran2Kel(Constants.BoilingPointH2OInRankine), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[DataTestMethod]
			[DataRow((UInt32) 1, (double) 184, (double) 331.2, "The lowest measured temp on Earth.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 2, (double) 255.37, (double) 459.666, "The Fahrenheit's mixture of ice and salt", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 3, (double) 288, (double) 518.4, "The average temperature of the Earth surface.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 4, (double) 309.95, (double) 557.91, "The average human body temperature.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 5, (double) 331, (double) 595.8, "The highest measured temperature on Earth.", OperationOverDoublePrecision.MiddlePrecision)]
			[DataRow((UInt32) 6, (double) 1941, (double) 3493.8, "The melting point of titanium.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 7, (double) 5800, (double) 10440, "The temperature of the Sun surface.", OperationOverDoublePrecision.HighPrecision)]
			public void WikiListTemperatureTest(UInt32 testNumber, double tempInKelvin, double tempInRankine, string testDescription, double delta) => Assert.AreEqual(tempInKelvin, Converter.Ran2Kel(tempInRankine), delta);
		}

		[TestClass]
		public class Del2KelTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInKelvin, Converter.Del2Kel(Constants.AbsoluteZeroInDelisle), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInKelvin, Converter.Del2Kel(Constants.MeltingPointH2OInDelisle), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInKelvin, Converter.Del2Kel(Constants.BoilingPointH2OInDelisle), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[DataTestMethod]
			[DataRow((UInt32) 1, (double) 184, (double) 283.725, "The lowest measured temp on Earth.", (double) OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 2, (double) 255.37, (double) 176.67, "The Fahrenheit's mixture of ice and salt", (double) OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 3, (double) 288, (double) 127.725, "The average temperature of the Earth surface.", (double) OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 4, (double) 309.95, (double) 94.8, "The average human body temperature.", (double) OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 5, (double) 331, (double) 63.225, "The highest measured temperature on Earth.", (double) OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 6, (double) 1941, (double) -2351.775, "The melting point of titanium.", (double) OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 7, (double) 5800, (double) -8140.275, "The temperature of the Sun surface.", (double) OperationOverDoublePrecision.MiddlePrecision)] // We can't beat the difference 9,something e-13.
			public void WikiListTemperatureTest(UInt32 testNumber, double tempInKelvin, double tempInDelisle, string testDescription, double delta) => Assert.AreEqual(tempInKelvin, Converter.Del2Kel(tempInDelisle), delta);
		}

		[TestClass]
		public class New2KelTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInKelvin, Converter.New2Kel(Constants.AbsoluteZeroInNewton), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInKelvin, Converter.New2Kel(Constants.MeltingPointH2OInNewton), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInKelvin, Converter.New2Kel(Constants.BoilingPointH2OInNewton), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[DataTestMethod]
			[DataRow((UInt32) 1, (double) 184, (double) -29.4195, "The lowest measured temp on Earth.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 2, (double) 255.37, (double) -5.8674, "The Fahrenheit's mixture of ice and salt", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 3, (double) 288, (double) 4.9005, "The average temperature of the Earth surface.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 4, (double) 309.95, (double) 12.144, "The average human body temperature.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 5, (double) 331, (double) 19.0905, "The highest measured temperature on Earth.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 6, (double) 1941, (double) 550.3905, "The melting point of titanium.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 7, (double) 5800, (double) 1823.8605, "The temperature of the Sun surface.", OperationOverDoublePrecision.MiddlePrecision)]
			public void WikiListTemperatureTest(UInt32 testNumber, double tempInKelvin, double tempInNewton, string testDescription, double delta) => Assert.AreEqual(tempInKelvin, Converter.New2Kel(tempInNewton), delta);
		}

		[TestClass]
		public class Réau2KelTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInKelvin, Converter.Réau2Kel(Constants.AbsoluteZeroInRéaumur), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInKelvin, Converter.Réau2Kel(Constants.MeltingPointH2OInRéaumur), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInKelvin, Converter.Réau2Kel(Constants.BoilingPointH2OInRéaumur), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[DataTestMethod]
			[DataRow((UInt32) 1, (double) 184, (double) -71.32, "The lowest measured temp on Earth.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 2, (double) 255.37, (double) -14.224, "The Fahrenheit's mixture of ice and salt", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 3, (double) 288, (double) 11.88, "The average temperature of the Earth surface.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 4, (double) 309.95, (double) 29.44, "The average human body temperature.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 5, (double) 331, (double) 46.28, "The highest measured temperature on Earth.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 6, (double) 1941, (double) 1334.28, "The melting point of titanium.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 7, (double) 5800, (double) 4421.48, "The temperature of the Sun surface.", OperationOverDoublePrecision.MiddlePrecision)]
			public void WikiListTemperatureTest(UInt32 testNumber, double tempInKelvin, double tempInNewton, string testDescription, double delta) => Assert.AreEqual(tempInKelvin, Converter.Réau2Kel(tempInNewton), delta);
		}

		[TestClass]
		public class Røm2KelTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInKelvin, Converter.Røm2Kel(Constants.AbsoluteZeroInRømer), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInKelvin, Converter.Røm2Kel(Constants.MeltingPointH2OInRømer), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInKelvin, Converter.Røm2Kel(Constants.BoilingPointH2OInRømer), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[DataTestMethod]
			[DataRow((UInt32) 1, (double) 184, (double) -39.30375, "The lowest measured temp on Earth.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 2, (double) 255.37, (double) -1.8345, "The Fahrenheit's mixture of ice and salt", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 3, (double) 288, (double) 15.29625, "The average temperature of the Earth surface.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 4, (double) 309.95, (double) 26.82, "The average human body temperature.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 5, (double) 331, (double) 37.87125, "The highest measured temperature on Earth.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 6, (double) 1941, (double) 883.12125, "The melting point of titanium.", OperationOverDoublePrecision.MiddlePrecision)]
			[DataRow((UInt32) 7, (double) 5800, (double) 2909.09625, "The temperature of the Sun surface.", OperationOverDoublePrecision.HighPrecision)]
			public void WikiListTemperatureTest(UInt32 testNumber, double tempInKelvin, double tempInRømer, string testDescription, double delta) => Assert.AreEqual(tempInKelvin, Converter.Røm2Kel(tempInRømer), delta);
		}

		[TestClass]
		public class Kel2CelTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInCelsius, Converter.Kel2Cel(Constants.AbsoluteZeroInKelvin), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInCelsius, Converter.Kel2Cel(Constants.MeltingPointH2OInKelvin), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInCelsius, Converter.Kel2Cel(Constants.BoilingPointH2OInKelvin), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[DataTestMethod]
			[DataRow((UInt32) 1, (double) 184, (double) -89.15, "The lowest measured temp on Earth.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 2, (double) 255.372222222222, (double) -17.77777777778, "The Fahrenheit's mixture of ice and salt", 1e-11)]
			[DataRow((UInt32) 3, (double) 288, (double) 14.85, "The average temperature of the Earth surface.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 4, (double) 309.95, (double) 36.8, "The average human body temperature.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 5, (double) 331, (double) 57.85, "The highest measured temperature on Earth.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 6, (double) 1941, (double) 1667.85, "The melting point of titanium.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 7, (double) 5800, (double) 5526.85, "The temperature of the Sun surface.", OperationOverDoublePrecision.HighPrecision)]
			public void WikiListTemperatureTest(UInt32 testNumber, double tempInKelvin, double tempInCelsius, string testDesciption, double delta) => Assert.AreEqual(tempInCelsius, Converter.Kel2Cel(tempInKelvin), delta);
		}

		[TestClass]
		public class Kel2FahTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInFahrenheit, Converter.Kel2Fah(Constants.AbsoluteZeroInKelvin), OperationOverDoublePrecision.MiddlePrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInFahrenheit, Converter.Kel2Fah(Constants.MeltingPointH2OInKelvin), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInFahrenheit, Converter.Kel2Fah(Constants.BoilingPointH2OInKelvin), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[DataTestMethod]
			[DataRow((UInt32) 1, (double) 184, (double) -128.47, "The lowest measured temp on Earth.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 2, (double) 255.372222222222, (double) 0, "The Fahrenheit's mixture of ice and salt", OperationOverDoublePrecision.MiddlePrecision)]
			[DataRow((UInt32) 3, (double) 288, (double) 58.73, "The average temperature of the Earth surface.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 4, (double) 309.95, (double) 98.24, "The average human body temperature.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 5, (double) 331, (double) 136.13, "The highest measured temperature on Earth.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 6, (double) 1941, (double) 3034.13, "The melting point of titanium.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 7, (double) 5800, (double) 9980.33, "The temperature of the Sun surface.", OperationOverDoublePrecision.HighPrecision)]
			public void WikiListTemperatureTest(UInt32 testNumber, double tempInKelvin, double tempInFahrenheit, string testDescription, double delta) => Assert.AreEqual(tempInFahrenheit, Converter.Kel2Fah(tempInKelvin), delta);
		}

		[TestClass]
		public class Kel2RanTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInRankine, Converter.Kel2Ran(Constants.AbsoluteZeroInKelvin), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInRankine, Converter.Kel2Ran(Constants.MeltingPointH2OInKelvin), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInRankine, Converter.Kel2Ran(Constants.BoilingPointH2OInKelvin), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[DataTestMethod]
			[DataRow((UInt32) 1, (double) 184, (double) 331.2, "The lowest measured temp on Earth.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 2, (double) 255.37, (double) 459.666, "The Fahrenheit's mixture of ice and salt", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 3, (double) 288, (double) 518.4, "The average temperature of the Earth surface.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 4, (double) 309.95, (double) 557.91, "The average human body temperature.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 5, (double) 331, (double) 595.8, "The highest measured temperature on Earth.", OperationOverDoublePrecision.MiddlePrecision)]
			[DataRow((UInt32) 6, (double) 1941, (double) 3493.8, "The melting point of titanium.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 7, (double) 5800, (double) 10440, "The temperature of the Sun surface.", OperationOverDoublePrecision.HighPrecision)]
			public void WikiListTemperatureTest(UInt32 testNumber, double tempInKelvin, double tempInRankine, string testDescption, double delta) => Assert.AreEqual(tempInRankine, Converter.Kel2Ran(tempInKelvin), delta);
		}

		[TestClass]
		public class Kel2DelTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInDelisle, Converter.Kel2Del(Constants.AbsoluteZeroInKelvin), OperationOverDoublePrecision.MiddlePrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInDelisle, Converter.Kel2Del(Constants.MeltingPointH2OInKelvin), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInDelisle, Converter.Kel2Del(Constants.BoilingPointH2OInKelvin), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[DataTestMethod]
			[DataRow((UInt32) 1, (double) 184, (double) 283.725, "The lowest measured temp on Earth.", (double) OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 2, (double) 255.37, (double) 176.67, "The Fahrenheit's mixture of ice and salt", (double) OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 3, (double) 288, (double) 127.725, "The average temperature of the Earth surface.", (double) OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 4, (double) 309.95, (double) 94.8, "The average human body temperature.", (double) OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 5, (double) 331, (double) 63.225, "The highest measured temperature on Earth.", (double) OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 6, (double) 1941, (double) -2351.775, "The melting point of titanium.", (double) OperationOverDoublePrecision.MiddlePrecision)]
			[DataRow((UInt32) 7, (double) 5800, (double) -8140.275, "The temperature of the Sun surface.", (double) OperationOverDoublePrecision.MiddlePrecision)] // We can't beat the difference 9,something e-13.
			public void WikiListTemperatureTest(UInt32 testNumber, double tempInKelvin, double tempInDelisle, string testDescription, double delta) => Assert.AreEqual(tempInDelisle, Converter.Kel2Del(tempInKelvin), delta);
		}

		[TestClass]
		public class Kel2NewTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInNewton, Converter.Kel2New(Constants.AbsoluteZeroInKelvin), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInNewton, Converter.Kel2New(Constants.MeltingPointH2OInKelvin), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInNewton, Converter.Kel2New(Constants.BoilingPointH2OInKelvin), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[DataTestMethod]
			[DataRow((UInt32) 1, (double) 184, (double) -29.4195, "The lowest measured temp on Earth.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 2, (double) 255.37, (double) -5.8674, "The Fahrenheit's mixture of ice and salt", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 3, (double) 288, (double) 4.9005, "The average temperature of the Earth surface.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 4, (double) 309.95, (double) 12.144, "The average human body temperature.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 5, (double) 331, (double) 19.0905, "The highest measured temperature on Earth.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 6, (double) 1941, (double) 550.3905, "The melting point of titanium.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 7, (double) 5800, (double) 1823.8605, "The temperature of the Sun surface.", OperationOverDoublePrecision.MiddlePrecision)]
			public void WikiListTemperatureTest(UInt32 testNumber, double tempInKelvin, double tempInNewton, string testDescription, double delta) => Assert.AreEqual(tempInNewton, Converter.Kel2New(tempInKelvin), delta);
		}

		[TestClass]
		public class Kel2RéauTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInRéaumur, Converter.Kel2Réau(Constants.AbsoluteZeroInKelvin), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInRéaumur, Converter.Kel2Réau(Constants.MeltingPointH2OInKelvin), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInRéaumur, Converter.Kel2Réau(Constants.BoilingPointH2OInKelvin), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[DataTestMethod]
			[DataRow((UInt32) 1, (double) 184, (double) -71.32, "The lowest measured temp on Earth.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 2, (double) 255.37, (double) -14.224, "The Fahrenheit's mixture of ice and salt", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 3, (double) 288, (double) 11.88, "The average temperature of the Earth surface.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 4, (double) 309.95, (double) 29.44, "The average human body temperature.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 5, (double) 331, (double) 46.28, "The highest measured temperature on Earth.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 6, (double) 1941, (double) 1334.28, "The melting point of titanium.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 7, (double) 5800, (double) 4421.48, "The temperature of the Sun surface.", OperationOverDoublePrecision.MiddlePrecision)]
			public void WikiListTemperatureTest(UInt32 testNumber, double tempInKelvin, double tempInRéaumur, string testDescription, double delta) => Assert.AreEqual(tempInRéaumur, Converter.Kel2Réau(tempInKelvin), delta);
		}

		[TestClass]
		public class Kel2RømTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInRømer, Converter.Kel2Røm(Constants.AbsoluteZeroInKelvin), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInRømer, Converter.Kel2Røm(Constants.MeltingPointH2OInKelvin), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInRømer, Converter.Kel2Røm(Constants.BoilingPointH2OInKelvin), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[DataTestMethod]
			[DataRow((UInt32) 1, (double) 184, (double) -39.30375, "The lowest measured temp on Earth.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 2, (double) 255.37, (double) -1.8345, "The Fahrenheit's mixture of ice and salt", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 3, (double) 288, (double) 15.29625, "The average temperature of the Earth surface.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 4, (double) 309.95, (double) 26.82, "The average human body temperature.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 5, (double) 331, (double) 37.87125, "The highest measured temperature on Earth.", OperationOverDoublePrecision.HighPrecision)]
			[DataRow((UInt32) 6, (double) 1941, (double) 883.12125, "The melting point of titanium.", OperationOverDoublePrecision.MiddlePrecision)]
			[DataRow((UInt32) 7, (double) 5800, (double) 2909.09625, "The temperature of the Sun surface.", OperationOverDoublePrecision.MiddlePrecision)]
			public void WikiListTemperatureTest(UInt32 testNumber, double tempInKelvin, double tempInRømer, string testDescription, double delta) => Assert.AreEqual(tempInRømer, Converter.Kel2Røm(tempInKelvin), delta);
		}

		[TestClass]
		public class Cel2FahTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInFahrenheit, Converter.Cel2Fah(Constants.AbsoluteZeroInCelsius), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInFahrenheit, Converter.Cel2Fah(Constants.MeltingPointH2OInCelsius), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInFahrenheit, Converter.Cel2Fah(Constants.BoilingPointH2OInCelsius), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Cel2RanTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInRankine, Converter.Cel2Ran(Constants.AbsoluteZeroInCelsius), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInRankine, Converter.Cel2Ran(Constants.MeltingPointH2OInCelsius), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInRankine, Converter.Cel2Ran(Constants.BoilingPointH2OInCelsius), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Cel2DelTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInDelisle, Converter.Cel2Del(Constants.AbsoluteZeroInCelsius), OperationOverDoublePrecision.MiddlePrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInDelisle, Converter.Cel2Del(Constants.MeltingPointH2OInCelsius), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInDelisle, Converter.Cel2Del(Constants.BoilingPointH2OInCelsius), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Cel2NewTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInNewton, Converter.Cel2New(Constants.AbsoluteZeroInCelsius), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInNewton, Converter.Cel2New(Constants.MeltingPointH2OInCelsius), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInNewton, Converter.Cel2New(Constants.BoilingPointH2OInCelsius), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Cel2RéauTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInRéaumur, Converter.Cel2Réau(Constants.AbsoluteZeroInCelsius), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInRéaumur, Converter.Cel2Réau(Constants.MeltingPointH2OInCelsius), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInRéaumur, Converter.Cel2Réau(Constants.BoilingPointH2OInCelsius), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Cel2RømTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInRømer, Converter.Cel2Røm(Constants.AbsoluteZeroInCelsius), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInRømer, Converter.Cel2Røm(Constants.MeltingPointH2OInCelsius), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInRømer, Converter.Cel2Røm(Constants.BoilingPointH2OInCelsius), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Fah2CelTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInCelsius, Converter.Fah2Cel(Constants.AbsoluteZeroInFahrenheit), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInCelsius, Converter.Fah2Cel(Constants.MeltingPointH2OInFahrenheit), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInCelsius, Converter.Fah2Cel(Constants.BoilingPointH2OInFahrenheit), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Fah2RanTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInRankine, Converter.Fah2Ran(Constants.AbsoluteZeroInFahrenheit), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInRankine, Converter.Fah2Ran(Constants.MeltingPointH2OInFahrenheit), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInRankine, Converter.Fah2Ran(Constants.BoilingPointH2OInFahrenheit), OperationOverDoublePrecision.MiddlePrecision);
		}

		[TestClass]
		public class Fah2DelTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInDelisle, Converter.Fah2Del(Constants.AbsoluteZeroInFahrenheit), OperationOverDoublePrecision.MiddlePrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInDelisle, Converter.Fah2Del(Constants.MeltingPointH2OInFahrenheit), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInDelisle, Converter.Fah2Del(Constants.BoilingPointH2OInFahrenheit), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Fah2NewTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInNewton, Converter.Fah2New(Constants.AbsoluteZeroInFahrenheit), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInNewton, Converter.Fah2New(Constants.MeltingPointH2OInFahrenheit), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInNewton, Converter.Fah2New(Constants.BoilingPointH2OInFahrenheit), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Fah2RéauTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInRéaumur, Converter.Fah2Réau(Constants.AbsoluteZeroInFahrenheit), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInRéaumur, Converter.Fah2Réau(Constants.MeltingPointH2OInFahrenheit), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInRéaumur, Converter.Fah2Réau(Constants.BoilingPointH2OInFahrenheit), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Fah2RømTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInRømer, Converter.Fah2Røm(Constants.AbsoluteZeroInFahrenheit), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInRømer, Converter.Fah2Røm(Constants.MeltingPointH2OInFahrenheit), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInRømer, Converter.Fah2Røm(Constants.BoilingPointH2OInFahrenheit), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Ran2CelTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInCelsius, Converter.Ran2Cel(Constants.AbsoluteZeroInRankine), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInCelsius, Converter.Ran2Cel(Constants.MeltingPointH2OInRankine), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInCelsius, Converter.Ran2Cel(Constants.BoilingPointH2OInRankine), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Ran2FahTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInFahrenheit, Converter.Ran2Fah(Constants.AbsoluteZeroInRankine), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInFahrenheit, Converter.Ran2Fah(Constants.MeltingPointH2OInRankine), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInFahrenheit, Converter.Ran2Fah(Constants.BoilingPointH2OInRankine), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Ran2DelTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInDelisle, Converter.Ran2Del(Constants.AbsoluteZeroInRankine), OperationOverDoublePrecision.MiddlePrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInDelisle, Converter.Ran2Del(Constants.MeltingPointH2OInRankine), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInDelisle, Converter.Ran2Del(Constants.BoilingPointH2OInRankine), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Ran2NewTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInNewton, Converter.Ran2New(Constants.AbsoluteZeroInRankine), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInNewton, Converter.Ran2New(Constants.MeltingPointH2OInRankine), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInNewton, Converter.Ran2New(Constants.BoilingPointH2OInRankine), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Ran2RéauTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInRéaumur, Converter.Ran2Réau(Constants.AbsoluteZeroInRankine), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInRéaumur, Converter.Ran2Réau(Constants.MeltingPointH2OInRankine), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInRéaumur, Converter.Ran2Réau(Constants.BoilingPointH2OInRankine), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Ran2RømTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInRømer, Converter.Ran2Røm(Constants.AbsoluteZeroInRankine), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInRømer, Converter.Ran2Røm(Constants.MeltingPointH2OInRankine), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInRømer, Converter.Ran2Røm(Constants.BoilingPointH2OInRankine), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Del2CelTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInCelsius, Converter.Del2Cel(Constants.AbsoluteZeroInDelisle), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInCelsius, Converter.Del2Cel(Constants.MeltingPointH2OInDelisle), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInCelsius, Converter.Del2Cel(Constants.BoilingPointH2OInDelisle), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Del2FahTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInFahrenheit, Converter.Del2Fah(Constants.AbsoluteZeroInDelisle), OperationOverDoublePrecision.MiddlePrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInFahrenheit, Converter.Del2Fah(Constants.MeltingPointH2OInDelisle), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInFahrenheit, Converter.Del2Fah(Constants.BoilingPointH2OInDelisle), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Del2RanTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInRankine, Converter.Del2Ran(Constants.AbsoluteZeroInDelisle), OperationOverDoublePrecision.MiddlePrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInRankine, Converter.Del2Ran(Constants.MeltingPointH2OInDelisle), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInRankine, Converter.Del2Ran(Constants.BoilingPointH2OInDelisle), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Del2NewTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInNewton, Converter.Del2New(Constants.AbsoluteZeroInDelisle), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInNewton, Converter.Del2New(Constants.MeltingPointH2OInDelisle), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInNewton, Converter.Del2New(Constants.BoilingPointH2OInDelisle), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Del2RéauTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInRéaumur, Converter.Del2Réau(Constants.AbsoluteZeroInDelisle), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInRéaumur, Converter.Del2Réau(Constants.MeltingPointH2OInDelisle), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInRéaumur, Converter.Del2Réau(Constants.BoilingPointH2OInDelisle), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Del2RømTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInRømer, Converter.Del2Røm(Constants.AbsoluteZeroInDelisle), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInRømer, Converter.Del2Røm(Constants.MeltingPointH2OInDelisle), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInRømer, Converter.Del2Røm(Constants.BoilingPointH2OInDelisle), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class New2CelTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInCelsius, Converter.New2Cel(Constants.AbsoluteZeroInNewton), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInCelsius, Converter.New2Cel(Constants.MeltingPointH2OInNewton), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInCelsius, Converter.New2Cel(Constants.BoilingPointH2OInNewton), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class New2FahTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInFahrenheit, Converter.New2Fah(Constants.AbsoluteZeroInNewton), OperationOverDoublePrecision.MiddlePrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInFahrenheit, Converter.New2Fah(Constants.MeltingPointH2OInNewton), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInFahrenheit, Converter.New2Fah(Constants.BoilingPointH2OInNewton), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class New2RanTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInRankine, Converter.New2Ran(Constants.AbsoluteZeroInNewton), OperationOverDoublePrecision.MiddlePrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInRankine, Converter.New2Ran(Constants.MeltingPointH2OInNewton), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInRankine, Converter.New2Ran(Constants.BoilingPointH2OInNewton), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class New2DelTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInDelisle, Converter.New2Del(Constants.AbsoluteZeroInNewton), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInDelisle, Converter.New2Del(Constants.MeltingPointH2OInNewton), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInDelisle, Converter.New2Del(Constants.BoilingPointH2OInNewton), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class New2RéauTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInRéaumur, Converter.New2Réau(Constants.AbsoluteZeroInNewton), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInRéaumur, Converter.New2Réau(Constants.MeltingPointH2OInNewton), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInRéaumur, Converter.New2Réau(Constants.BoilingPointH2OInNewton), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class New2RømTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInRømer, Converter.New2Røm(Constants.AbsoluteZeroInNewton), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInRømer, Converter.New2Røm(Constants.MeltingPointH2OInNewton), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInRømer, Converter.New2Røm(Constants.BoilingPointH2OInNewton), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Réau2CelTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInCelsius, Converter.Réau2Cel(Constants.AbsoluteZeroInRéaumur), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInCelsius, Converter.Réau2Cel(Constants.MeltingPointH2OInRéaumur), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInCelsius, Converter.Réau2Cel(Constants.BoilingPointH2OInRéaumur), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Réau2FahTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInFahrenheit, Converter.Réau2Fah(Constants.AbsoluteZeroInRéaumur), OperationOverDoublePrecision.MiddlePrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInFahrenheit, Converter.Réau2Fah(Constants.MeltingPointH2OInRéaumur), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInFahrenheit, Converter.Réau2Fah(Constants.BoilingPointH2OInRéaumur), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Réau2RanTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInRankine, Converter.Réau2Ran(Constants.AbsoluteZeroInRéaumur), OperationOverDoublePrecision.MiddlePrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInRankine, Converter.Réau2Ran(Constants.MeltingPointH2OInRéaumur), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInRankine, Converter.Réau2Ran(Constants.BoilingPointH2OInRéaumur), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Réau2DelTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInDelisle, Converter.Réau2Del(Constants.AbsoluteZeroInRéaumur), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInDelisle, Converter.Réau2Del(Constants.MeltingPointH2OInRéaumur), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInDelisle, Converter.Réau2Del(Constants.BoilingPointH2OInRéaumur), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Réau2NewTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInNewton, Converter.Réau2New(Constants.AbsoluteZeroInRéaumur), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInNewton, Converter.Réau2New(Constants.MeltingPointH2OInRéaumur), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInNewton, Converter.Réau2New(Constants.BoilingPointH2OInRéaumur), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Réau2RømTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInRømer, Converter.Réau2Røm(Constants.AbsoluteZeroInRéaumur), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInRømer, Converter.Réau2Røm(Constants.MeltingPointH2OInRéaumur), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInRømer, Converter.Réau2Røm(Constants.BoilingPointH2OInRéaumur), OperationOverDoublePrecision.HighPrecision);
		}
		[TestClass]
		public class Røm2CelTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInCelsius, Converter.Røm2Cel(Constants.AbsoluteZeroInRømer), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInCelsius, Converter.Røm2Cel(Constants.MeltingPointH2OInRømer), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInCelsius, Converter.Røm2Cel(Constants.BoilingPointH2OInRømer), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Røm2FahTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInFahrenheit, Converter.Røm2Fah(Constants.AbsoluteZeroInRømer), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInFahrenheit, Converter.Røm2Fah(Constants.MeltingPointH2OInRømer), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInFahrenheit, Converter.Røm2Fah(Constants.BoilingPointH2OInRømer), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Røm2RanTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInRankine, Converter.Røm2Ran(Constants.AbsoluteZeroInRømer), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInRankine, Converter.Røm2Ran(Constants.MeltingPointH2OInRømer), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInRankine, Converter.Røm2Ran(Constants.BoilingPointH2OInRømer), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Røm2DelTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInDelisle, Converter.Røm2Del(Constants.AbsoluteZeroInRømer), OperationOverDoublePrecision.MiddlePrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInDelisle, Converter.Røm2Del(Constants.MeltingPointH2OInRømer), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInDelisle, Converter.Røm2Del(Constants.BoilingPointH2OInRømer), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Røm2NewTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInNewton, Converter.Røm2New(Constants.AbsoluteZeroInRømer), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInNewton, Converter.Røm2New(Constants.MeltingPointH2OInRømer), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInNewton, Converter.Røm2New(Constants.BoilingPointH2OInRømer), OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class Røm2RéauTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroTest() => Assert.AreEqual(Constants.AbsoluteZeroInRéaumur, Converter.Røm2Réau(Constants.AbsoluteZeroInRømer), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20MeltingPointTest() => Assert.AreEqual(Constants.MeltingPointH2OInRéaumur, Converter.Røm2Réau(Constants.MeltingPointH2OInRømer), OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void H20BoilingPointTest() => Assert.AreEqual(Constants.BoilingPointH2OInRéaumur, Converter.Røm2Réau(Constants.BoilingPointH2OInRømer), OperationOverDoublePrecision.HighPrecision);
		}
	}
}
