using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UltimateTemperatureLibrary.Interfaces;
using UltimateTemperatureLibrary.Utils;

namespace UltimateTemperatureLibrary.UnitTests
{
	public class KelvinTests
	{
		[TestClass]
		public class KelvinConstructorsTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroEmptyConstructorTest()
			{
				var kelvin = new Kelvin();

				Assert.AreEqual(Constants.AbsoluteZeroInKelvin, kelvin.Value, double.Epsilon);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void OutOfRangeEmptyConstructorTest()
			{
				var kelvin = new Kelvin { Value = -500 };
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void InRangeEmptyConstructorTest()
			{
				var kelvin = new Kelvin { Value = 500 };
				Assert.AreEqual(500, kelvin.Value, double.Epsilon);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void OutOfRangeDoubleConstructorTest()
			{
				var kelvin = new Kelvin(-500);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void NullAsStringPassedToConstructorTest()
			{
				var kelvin = new Kelvin((string) null);
				Assert.AreEqual(Constants.AbsoluteZeroInKelvin, kelvin.Value);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void NullAsUnitPassedToConstructorTest()
			{
				var kelvin = new Kelvin((IConversionToKelvin) null);
				Assert.AreEqual(Constants.AbsoluteZeroInKelvin, kelvin.Value);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void OutOfRangeStringConstructorTest()
			{
				var kelvin = new Kelvin("-500");
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			[ExpectedException(typeof(FormatException))]
			public void NoValueStringConstructorTest()
			{
				var kelvin = new Kelvin(" K");
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void FromCelsiusTest()
			{
				var celsius = new Celsius(100.0);
				Assert.AreEqual(celsius.ToKelvin(), new Kelvin(celsius));
			}

			[TestCategory(TestCategory.IntegrationTests)]
			[TestMethod]
			public void FromOtherUnitsAsStringTest()
			{
				Assert.AreEqual(new Kelvin(100), new Kelvin("100 K"));
				Assert.AreEqual(new Celsius(100), new Celsius("100 °C"));
				Assert.AreEqual(new Fahrenheit(100), new Kelvin("100 °F"));
				Assert.AreEqual(new Rankine(100), new Kelvin("100 °R"));
				Assert.AreEqual(new Delisle(100), new Kelvin("100 °D"));
				Assert.AreEqual(new Newton(100), new Kelvin("100 °N"));
				Assert.AreEqual(new Réaumur(100), new Kelvin("100 Ré"));
				Assert.AreEqual(new Rømer(100), new Kelvin("100 Rø"));
			}
		}

		[TestClass]
		public class KelvinAdditionOperatorTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void KelvinAddKelvinFromKelvinTest()
			{
				double temp1 = 20;
				double temp2 = 30;
				var kelvin = new Kelvin(temp1);
				var kelvin2 = new Kelvin(temp2);

				Assert.AreEqual(expected: new Kelvin(temp1 + temp2), kelvin + kelvin2);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void KelvinAddKelvinFromValuesTest()
			{
				double temp1 = 20;
				double temp2 = 30;
				var kelvin = new Kelvin(temp1);
				var kelvin2 = new Kelvin(temp2);

				Assert.AreEqual(kelvin.Value + kelvin2.Value, new Kelvin(temp1 + temp2).Value);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void KelvinAddNullTest()
			{
				double temp1 = 20;
				var kelvin = new Kelvin(temp1);

				Assert.AreEqual(kelvin.Value, (kelvin + null).Value);
			}
		}

		[TestClass]
		public class KelvinSubtractionOperatorTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void KelvinSubtractionKelvinFromKelvinTest()
			{
				double temp1 = 20;
				double temp2 = 30;
				var kelvin = new Kelvin(temp1);
				var kelvin2 = new Kelvin(temp2);

				Assert.AreEqual(expected: new Kelvin(temp2 - temp1), kelvin2 - kelvin);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void KelvinSubtractionKelvinFromFromTest()
			{
				double temp1 = 20;
				double temp2 = 30;
				var kelvin = new Kelvin(temp1);
				var kelvin2 = new Kelvin(temp2);

				Assert.AreEqual(kelvin2.Value - kelvin.Value, new Kelvin(temp2 - temp1).Value);
			}
		}

		[TestClass]
		public class ToKelvinTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void ValidKelvinPassedTest()
			{
				var celsius = new Celsius(Constants.AbsoluteZeroInCelsius);
				var kelvin = new Kelvin(Constants.AbsoluteZeroInKelvin);
				var fahrenheit = new Fahrenheit(Constants.AbsoluteZeroInFahrenheit);
				var rankine = new Rankine(Constants.AbsoluteZeroInRankine);
				var delisle = new Delisle(Constants.AbsoluteZeroInDelisle);
				var newton = new Newton(Constants.AbsoluteZeroInNewton);
				var réaumur = new Réaumur(Constants.AbsoluteZeroInRéaumur);
				var rømer = new Rømer(Constants.AbsoluteZeroInRømer);
				Assert.AreEqual(Constants.AbsoluteZeroInKelvin, Kelvin.ToKelvin(kelvin).Value);
				Assert.AreEqual(Constants.AbsoluteZeroInKelvin, Kelvin.ToKelvin(celsius).Value);
				Assert.AreEqual(Constants.AbsoluteZeroInKelvin, Kelvin.ToKelvin(fahrenheit).Value);
				Assert.AreEqual(Constants.AbsoluteZeroInKelvin, Kelvin.ToKelvin(rankine).Value);
				Assert.AreEqual(Constants.AbsoluteZeroInKelvin, Kelvin.ToKelvin(delisle).Value);
				Assert.AreEqual(Constants.AbsoluteZeroInKelvin, Kelvin.ToKelvin(newton).Value);
				Assert.AreEqual(Constants.AbsoluteZeroInKelvin, Kelvin.ToKelvin(réaumur).Value);
				Assert.AreEqual(Constants.AbsoluteZeroInKelvin, Kelvin.ToKelvin(rømer).Value);
			}
		}

		[TestClass]
		public class ToCelsiusTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void KelvinToCelsiusTest()
			{
				double temp1 = 20;

				Assert.AreEqual(expected: new Celsius(Converter.Kel2Cel(temp1)), new Kelvin(temp1).ToCelsius());
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void FromDoubleToCelsiusTest()
			{
				Assert.AreEqual(expected: Constants.AbsoluteZeroInCelsius, new Kelvin(Constants.AbsoluteZeroInKelvin).ToCelsius().Value, 1e-12);
				Assert.AreEqual(expected: Constants.MeltingPointH2OInCelsius, new Kelvin(Constants.MeltingPointH2OInKelvin).ToCelsius().Value, 1e-12);
				Assert.AreEqual(expected: Constants.BoilingPointH2OInCelsius, new Kelvin(Constants.BoilingPointH2OInKelvin).ToCelsius().Value, 1e-12);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToCelsiusAbsoluteZeroTest() => Assert.AreEqual(expected: Constants.AbsoluteZeroInCelsius, Kelvin.ToCelsius(Constants.AbsoluteZeroInKelvin).Value, 1e-12);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToCelsiusMeltingPointTest() => Assert.AreEqual(expected: Constants.MeltingPointH2OInCelsius, Kelvin.ToCelsius(Constants.MeltingPointH2OInKelvin).Value);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToCelsiusBoilingPointTest() => Assert.AreEqual(expected: Constants.BoilingPointH2OInCelsius, Kelvin.ToCelsius(Constants.BoilingPointH2OInKelvin).Value);
		}

		[TestClass]
		public class ToFahrenheitTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void KelvinToFahrenheitTest()
			{
				double temp1 = 20;

				Assert.AreEqual(expected: new Fahrenheit(Converter.Kel2Fah(temp1)), new Kelvin(temp1).ToFahrenheit());
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void FromDoubleToFahrenheitTest()
			{
				Assert.AreEqual(expected: Constants.AbsoluteZeroInFahrenheit, new Kelvin(Constants.AbsoluteZeroInKelvin).ToFahrenheit().Value);
				Assert.AreEqual(expected: Constants.MeltingPointH2OInFahrenheit, new Kelvin(Constants.MeltingPointH2OInKelvin).ToFahrenheit().Value, 1e-13);
				Assert.AreEqual(expected: Constants.BoilingPointH2OInFahrenheit, new Kelvin(Constants.BoilingPointH2OInKelvin).ToFahrenheit().Value, 1e-13);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToFahrenheitAbsoluteZeroTest() => Assert.AreEqual(expected: Constants.AbsoluteZeroInFahrenheit, Kelvin.ToFahrenheit(Constants.AbsoluteZeroInKelvin).Value);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToFahrenheitMeltingPointTest() => Assert.AreEqual(expected: Constants.MeltingPointH2OInFahrenheit, Kelvin.ToFahrenheit(Constants.MeltingPointH2OInKelvin).Value, 1e-13);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToFahrenheitBoilingPointTest() => Assert.AreEqual(expected: Constants.BoilingPointH2OInFahrenheit, Kelvin.ToFahrenheit(Constants.BoilingPointH2OInKelvin).Value, 1e-13);
		}

		[TestClass]
		public class ToRankineTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void KelvinToRankineTest()
			{
				double temp1 = 20;

				Assert.AreEqual(expected: new Rankine(Converter.Kel2Ran(temp1)), new Kelvin(temp1).ToRankine());
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void FromDoubleToRankineTest()
			{
				Assert.AreEqual(expected: Constants.AbsoluteZeroInRankine, new Kelvin(Constants.AbsoluteZeroInKelvin).ToRankine().Value);
				Assert.AreEqual(expected: Constants.MeltingPointH2OInRankine, new Kelvin(Constants.MeltingPointH2OInKelvin).ToRankine().Value, 1e-13);
				Assert.AreEqual(expected: Constants.BoilingPointH2OInRankine, new Kelvin(Constants.BoilingPointH2OInKelvin).ToRankine().Value, 1e-13);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToRankineAbsoluteZeroTest() => Assert.AreEqual(expected: Constants.AbsoluteZeroInRankine, Kelvin.ToRankine(Constants.AbsoluteZeroInKelvin).Value);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToRankineMeltingPointTest() => Assert.AreEqual(expected: Constants.MeltingPointH2OInRankine, Kelvin.ToRankine(Constants.MeltingPointH2OInKelvin).Value, 1e-13);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToRankineBoilingPointTest() => Assert.AreEqual(expected: Constants.BoilingPointH2OInRankine, Kelvin.ToRankine(Constants.BoilingPointH2OInKelvin).Value);
		}

		[TestClass]
		public class ToDelisleTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void KelvinToDelisleTest()
			{
				double temp1 = 20;

				Assert.AreEqual(expected: new Delisle(Converter.Kel2Del(temp1)), new Kelvin(temp1).ToDelisle());
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void FromDoubleToDelisleTest()
			{
				Assert.AreEqual(expected: Constants.AbsoluteZeroInDelisle, new Kelvin(Constants.AbsoluteZeroInKelvin).ToDelisle().Value, 1e-12);
				Assert.AreEqual(expected: Constants.MeltingPointH2OInDelisle, new Kelvin(Constants.MeltingPointH2OInKelvin).ToDelisle().Value, 1e-12);
				Assert.AreEqual(expected: Constants.BoilingPointH2OInDelisle, new Kelvin(Constants.BoilingPointH2OInKelvin).ToDelisle().Value, 1e-12);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToDelisleAbsoluteZeroTest() => Assert.AreEqual(expected: Constants.AbsoluteZeroInDelisle, Kelvin.ToDelisle(Constants.AbsoluteZeroInKelvin).Value, 1e-12);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToDelisleMeltingPointTest() => Assert.AreEqual(expected: Constants.MeltingPointH2OInDelisle, Kelvin.ToDelisle(Constants.MeltingPointH2OInKelvin).Value);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToDelisleBoilingPointTest() => Assert.AreEqual(expected: Constants.BoilingPointH2OInDelisle, Kelvin.ToDelisle(Constants.BoilingPointH2OInKelvin).Value);
		}

		[TestClass]
		public class ToNewtonTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void KelvinToNewtonTest()
			{
				double temp1 = 20;

				Assert.AreEqual(expected: new Newton(Converter.Kel2New(temp1)), new Kelvin(temp1).ToNewton());
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void FromDoubleToNewtonTest()
			{
				Assert.AreEqual(expected: Constants.AbsoluteZeroInNewton, new Kelvin(Constants.AbsoluteZeroInKelvin).ToNewton().Value, 1e-13);
				Assert.AreEqual(expected: Constants.MeltingPointH2OInNewton, new Kelvin(Constants.MeltingPointH2OInKelvin).ToNewton().Value, 1e-13);
				Assert.AreEqual(expected: Constants.BoilingPointH2OInNewton, new Kelvin(Constants.BoilingPointH2OInKelvin).ToNewton().Value, 1e-13);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToNewtonAbsoluteZeroTest() => Assert.AreEqual(expected: Constants.AbsoluteZeroInNewton, Kelvin.ToNewton(Constants.AbsoluteZeroInKelvin).Value, 1e-13);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToNewtonMeltingPointTest() => Assert.AreEqual(expected: Constants.MeltingPointH2OInNewton, Kelvin.ToNewton(Constants.MeltingPointH2OInKelvin).Value);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToNewtonBoilingPointTest() => Assert.AreEqual(expected: Constants.BoilingPointH2OInNewton, Kelvin.ToNewton(Constants.BoilingPointH2OInKelvin).Value);
		}

		[TestClass]
		public class ToRéaumurTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void KelvinToRéaumurTest()
			{
				double temp1 = 20;

				Assert.AreEqual(expected: new Réaumur(Converter.Kel2Réau(temp1)), new Kelvin(temp1).ToRéaumur());
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void FromDoubleToRéaumurTest()
			{
				Assert.AreEqual(expected: Constants.AbsoluteZeroInRéaumur, new Kelvin(Constants.AbsoluteZeroInKelvin).ToRéaumur().Value, 1e-13);
				Assert.AreEqual(expected: Constants.MeltingPointH2OInRéaumur, new Kelvin(Constants.MeltingPointH2OInKelvin).ToRéaumur().Value, 1e-13);
				Assert.AreEqual(expected: Constants.BoilingPointH2OInRéaumur, new Kelvin(Constants.BoilingPointH2OInKelvin).ToRéaumur().Value, 1e-13);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToRéaumurAbsoluteZeroTest() => Assert.AreEqual(expected: Constants.AbsoluteZeroInRéaumur, Kelvin.ToRéaumur(Constants.AbsoluteZeroInKelvin).Value, 1e-13);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToRéaumurMeltingPointTest() => Assert.AreEqual(expected: Constants.MeltingPointH2OInRéaumur, Kelvin.ToRéaumur(Constants.MeltingPointH2OInKelvin).Value);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToRéaumurBoilingPointTest() => Assert.AreEqual(expected: Constants.BoilingPointH2OInRéaumur, Kelvin.ToRéaumur(Constants.BoilingPointH2OInKelvin).Value);
		}

		[TestClass]
		public class ToRømerTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void KelvinToRømerTest()
			{
				double temp1 = 20;

				Assert.AreEqual(expected: new Rømer(Converter.Kel2Røm(temp1)), new Kelvin(temp1).ToRømer());
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void FromDoubleToRømerTest()
			{
				Assert.AreEqual(expected: Constants.AbsoluteZeroInRømer, new Kelvin(Constants.AbsoluteZeroInKelvin).ToRømer().Value);
				Assert.AreEqual(expected: Constants.MeltingPointH2OInRømer, new Kelvin(Constants.MeltingPointH2OInKelvin).ToRømer().Value);
				Assert.AreEqual(expected: Constants.BoilingPointH2OInRømer, new Kelvin(Constants.BoilingPointH2OInKelvin).ToRømer().Value);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToRømerAbsoluteZeroTest() => Assert.AreEqual(expected: Constants.AbsoluteZeroInRømer, Kelvin.ToRømer(Constants.AbsoluteZeroInKelvin).Value);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToRømerMeltingPointTest() => Assert.AreEqual(expected: Constants.MeltingPointH2OInRømer, Kelvin.ToRømer(Constants.MeltingPointH2OInKelvin).Value);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToRømerBoilingPointTest() => Assert.AreEqual(expected: Constants.BoilingPointH2OInRømer, Kelvin.ToRømer(Constants.BoilingPointH2OInKelvin).Value);
		}
	}

	[TestClass]
	public class RegexPatternsTests : Kelvin
	{
		[TestCategory(TestCategory.BasicTests)]
		[TestMethod]
		public void SetupNewUnitsTest()
		{
			var celsius = new RegexPatternsTests { RegexPatterns = new[] { "K" } };
			// Alternative would be protected internal setter.

			Assert.AreEqual(celsius.RegexPatterns[0], "K");
		}
	}

	[TestClass]
	public class ToStringTests
	{
		[TestCategory(TestCategory.BasicTests)]
		[TestMethod]
		public void DegreeCelsiusTest()
		{
			var kelvin = new Kelvin(Constants.MeltingPointH2OInKelvin);

			Assert.AreEqual($"{kelvin.Value} {kelvin.RegexPatterns[0]}", kelvin.ToString());
		}
	}

	[TestClass]
	public class KelvinComplexOperationTests
	{
		[TestCategory(TestCategory.IntegrationTests)]
		[TestMethod]
		public void DemoTest()
		{
			// Unit creation
			var kelvin = new Kelvin(Constants.MeltingPointH2OInKelvin);
			Assert.AreEqual(Constants.MeltingPointH2OInKelvin, kelvin.Value);

			kelvin = new Kelvin("50.8 °K");
			Assert.AreEqual(new Kelvin(50.8), kelvin);

			kelvin = new Kelvin("0 K");
			Assert.AreEqual(new Kelvin(Constants.AbsoluteZeroInKelvin), kelvin);


			var celsius = new Celsius(Constants.MeltingPointH2OInCelsius);
			var kelvin2 = new Kelvin(celsius);
			Assert.AreEqual(celsius, kelvin2);


			// Arithmetic
			var kelvin3 = kelvin + kelvin2;
			Assert.AreEqual(Constants.MeltingPointH2OInKelvin, kelvin3.Value);
			var kelvin4 = kelvin + celsius;
			Assert.AreEqual(Constants.MeltingPointH2OInKelvin, kelvin4.Value);
			kelvin3 = kelvin2 - kelvin;
			Assert.AreEqual(Constants.MeltingPointH2OInKelvin, kelvin3.Value);
			kelvin4 = kelvin2 - celsius;
			Assert.AreEqual(Constants.AbsoluteZeroInKelvin, kelvin4.Value);

			kelvin3.Value = 20;
			kelvin4.Value = 30;

			kelvin3 += kelvin4;
			Assert.AreEqual(50, kelvin3.Value);
			kelvin3 -= kelvin4;
			Assert.AreEqual(20, kelvin3.Value);

			// OOP Conversion
			var fahrenheit = new Fahrenheit(kelvin.ToFahrenheit());
			Assert.AreEqual(fahrenheit, kelvin);
			kelvin = Kelvin.ToKelvin(fahrenheit);
			Assert.AreEqual(fahrenheit, kelvin);

			double someTemperatureValueInFahrenheit = Converter.Ran2Fah(Constants.BoilingPointH2OInRankine);
			double newValueInKelvin = Fahrenheit.ToKelvin(someTemperatureValueInFahrenheit).Value;
			Assert.AreEqual(someTemperatureValueInFahrenheit, Converter.Kel2Fah(newValueInKelvin), OperationOverDoublePrecision.HighPrecision);

			// Comparison
			kelvin.Value = 20;
			kelvin2.Value = 20;

			Assert.AreEqual(kelvin, kelvin2);

			kelvin = new Kelvin(Constants.AbsoluteZeroInKelvin);
			celsius = new Celsius(Constants.AbsoluteZeroInCelsius);

			Assert.AreEqual(kelvin, celsius);
		}
	}
}

