using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UltimateTemperatureLibrary.Interfaces;
using UltimateTemperatureLibrary.Utils;

namespace UltimateTemperatureLibrary.UnitTests
{
	public class DelisleTests
	{
		[TestClass]
		public class DelisleConstructorsTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroEmptyConstructorTest()
			{
				var delisle = new Delisle();

				Assert.AreEqual(Constants.AbsoluteZeroInDelisle, delisle.Value, double.Epsilon);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void OutOfRangeEmptyConstructorTest()
			{
				var delisle = new Delisle { Value = 600 };
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void InRangeEmptyConstructorTest()
			{
				var delisle = new Delisle { Value = 500 };
				Assert.AreEqual(500, delisle.Value, double.Epsilon);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void OutOfRangeDoubleConstructorTest()
			{
				var delisle = new Delisle(600);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void NullAsStringPassedToConstructorTest()
			{
				var delisle = new Delisle((string) null);
				Assert.AreEqual(Constants.AbsoluteZeroInDelisle, delisle.Value);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void NullAsUnitPassedToConstructorTest()
			{
				var delisle = new Delisle((IConversionToDelisle) null);
				Assert.AreEqual(Constants.AbsoluteZeroInDelisle, delisle.Value);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void OutOfRangeStringConstructorTest()
			{
				var delisle = new Delisle("-500");
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			[ExpectedException(typeof(FormatException))]
			public void NoValueStringConstructorTest()
			{
				var delisle = new Delisle(" K");
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void FromKelvinTest()
			{
				var kelvin = new Kelvin(100.0);
				Assert.AreEqual(kelvin.ToDelisle(), new Delisle(kelvin));
			}

			[TestCategory(TestCategory.IntegrationTests)]
			[TestMethod]
			public void FromOtherUnitsAsStringTest()
			{
				Assert.AreEqual(new Kelvin(100), new Delisle("100 K"));
				Assert.AreEqual(new Celsius(100), new Celsius("100 °C"));
				Assert.AreEqual(new Fahrenheit(100), new Delisle("100 °F"));
				Assert.AreEqual(new Rankine(100), new Delisle("100 °R"));
				Assert.AreEqual(new Delisle(100), new Delisle("100 °D"));
				Assert.AreEqual(new Newton(100), new Delisle("100 °N"));
				Assert.AreEqual(new Réaumur(100), new Delisle("100 Ré"));
				Assert.AreEqual(new Rømer(100), new Delisle("100 Rø"));
			}
		}

		[TestClass]
		public class DelisleAdditionOperatorTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void DelisleAddDelisleFromDelisleTest()
			{
				double temp1 = 20;
				double temp2 = 30;
				var delisle = new Delisle(temp1);
				var delisle2 = new Delisle(temp2);

				Assert.AreEqual(expected: new Delisle(temp1 + temp2), delisle + delisle2);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void DelisleAddDelisleFromValuesTest()
			{
				double temp1 = 20;
				double temp2 = 30;
				var delisle = new Delisle(temp1);
				var delisle2 = new Delisle(temp2);

				Assert.AreEqual(delisle.Value + delisle2.Value, new Delisle(temp1 + temp2).Value);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void DelisleAddNullTest()
			{
				double temp1 = 20;
				var delisle = new Delisle(temp1);

				Assert.AreEqual(delisle.Value, (delisle + null).Value);
			}
		}

		[TestClass]
		public class DelisleSubtractionOperatorTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void DelisleSubtractionDelisleFromDelisleTest()
			{
				double temp1 = 20;
				double temp2 = -30;
				var delisle = new Delisle(temp1);
				var delisle2 = new Delisle(temp2);

				Assert.AreEqual(expected: new Delisle(temp1 + temp2), delisle - delisle2);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void DelisleSubtractionDelisleFromFromTest()
			{
				double temp1 = 20;
				double temp2 = 30;
				var delisle = new Delisle(temp1);
				var delisle2 = new Delisle(temp2);

				Assert.AreEqual(delisle.Value - delisle2.Value, new Delisle(temp1 - temp2).Value);
			}
		}

		[TestClass]
		public class ToKelvinTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void DelisleToKelvinTest()
			{
				double temp1 = 20;

				Assert.AreEqual(expected: new Kelvin(Converter.Del2Kel(temp1)), new Delisle(temp1).ToKelvin());
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void FromDoubleToKelvinTest()
			{
				Assert.AreEqual(expected: Constants.AbsoluteZeroInKelvin, new Delisle(Constants.AbsoluteZeroInDelisle).ToKelvin().Value);
				Assert.AreEqual(expected: Constants.MeltingPointH2OInKelvin, new Delisle(Constants.MeltingPointH2OInDelisle).ToKelvin().Value);
				Assert.AreEqual(expected: Constants.BoilingPointH2OInKelvin, new Delisle(Constants.BoilingPointH2OInDelisle).ToKelvin().Value);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToKelvinAbsoluteZeroTest() => Assert.AreEqual(expected: Constants.AbsoluteZeroInKelvin, Delisle.ToKelvin(Constants.AbsoluteZeroInDelisle).Value);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToKelvinMeltingPointTest() => Assert.AreEqual(expected: Constants.MeltingPointH2OInKelvin, Delisle.ToKelvin(Constants.MeltingPointH2OInDelisle).Value);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToKelvinBoilingPointTest() => Assert.AreEqual(expected: Constants.BoilingPointH2OInKelvin, Delisle.ToKelvin(Constants.BoilingPointH2OInDelisle).Value);
		}

		[TestClass]
		public class ToCelsiusTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void DelisleToCelsiusTest()
			{
				double temp1 = 20;

				Assert.AreEqual(expected: new Celsius(Converter.Del2Cel(temp1)), new Delisle(temp1).ToCelsius());
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void FromDoubleToCelsiusTest()
			{
				Assert.AreEqual(expected: Constants.AbsoluteZeroInCelsius, new Delisle(Constants.AbsoluteZeroInDelisle).ToCelsius().Value);
				Assert.AreEqual(expected: Constants.MeltingPointH2OInCelsius, new Delisle(Constants.MeltingPointH2OInDelisle).ToCelsius().Value);
				Assert.AreEqual(expected: Constants.BoilingPointH2OInCelsius, new Delisle(Constants.BoilingPointH2OInDelisle).ToCelsius().Value);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToCelsiusAbsoluteZeroTest() => Assert.AreEqual(expected: Constants.AbsoluteZeroInCelsius, Delisle.ToCelsius(Constants.AbsoluteZeroInDelisle).Value);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToCelsiusMeltingPointTest() => Assert.AreEqual(expected: Constants.MeltingPointH2OInCelsius, Delisle.ToCelsius(Constants.MeltingPointH2OInDelisle).Value);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToCelsiusBoilingPointTest() => Assert.AreEqual(expected: Constants.BoilingPointH2OInCelsius, Delisle.ToCelsius(Constants.BoilingPointH2OInDelisle).Value);
		}

		[TestClass]
		public class ToFahrenheitTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void DelisleToFahrenheitTest()
			{
				double temp1 = 20;

				Assert.AreEqual(expected: new Fahrenheit(Converter.Del2Fah(temp1)), new Delisle(temp1).ToFahrenheit());
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void FromDoubleToFahrenheitTest()
			{
				Assert.AreEqual(expected: Constants.AbsoluteZeroInFahrenheit, new Delisle(Constants.AbsoluteZeroInDelisle).ToFahrenheit().Value);
				Assert.AreEqual(expected: Constants.MeltingPointH2OInFahrenheit, new Delisle(Constants.MeltingPointH2OInDelisle).ToFahrenheit().Value, OperationOverDoublePrecision.HighPrecision);
				Assert.AreEqual(expected: Constants.BoilingPointH2OInFahrenheit, new Delisle(Constants.BoilingPointH2OInDelisle).ToFahrenheit().Value, OperationOverDoublePrecision.HighPrecision);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToFahrenheitAbsoluteZeroTest() => Assert.AreEqual(expected: Constants.AbsoluteZeroInFahrenheit, Delisle.ToFahrenheit(Constants.AbsoluteZeroInDelisle).Value);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToFahrenheitMeltingPointTest() => Assert.AreEqual(expected: Constants.MeltingPointH2OInFahrenheit, Delisle.ToFahrenheit(Constants.MeltingPointH2OInDelisle).Value, OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToFahrenheitBoilingPointTest() => Assert.AreEqual(expected: Constants.BoilingPointH2OInFahrenheit, Delisle.ToFahrenheit(Constants.BoilingPointH2OInDelisle).Value, OperationOverDoublePrecision.HighPrecision);
		}

		[TestClass]
		public class ToRankineTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void DelisleToRankineTest()
			{
				double temp1 = 20;

				Assert.AreEqual(expected: new Rankine(Converter.Del2Ran(temp1)), new Delisle(temp1).ToRankine());
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void FromDoubleToRankineTest()
			{
				Assert.AreEqual(expected: Constants.AbsoluteZeroInRankine, new Delisle(Constants.AbsoluteZeroInDelisle).ToRankine().Value);
				Assert.AreEqual(expected: Constants.MeltingPointH2OInRankine, new Delisle(Constants.MeltingPointH2OInDelisle).ToRankine().Value, OperationOverDoublePrecision.HighPrecision);
				Assert.AreEqual(expected: Constants.BoilingPointH2OInRankine, new Delisle(Constants.BoilingPointH2OInDelisle).ToRankine().Value, OperationOverDoublePrecision.HighPrecision);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToRankineAbsoluteZeroTest() => Assert.AreEqual(expected: Constants.AbsoluteZeroInRankine, Delisle.ToRankine(Constants.AbsoluteZeroInDelisle).Value);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToRankineMeltingPointTest() => Assert.AreEqual(expected: Constants.MeltingPointH2OInRankine, Delisle.ToRankine(Constants.MeltingPointH2OInDelisle).Value, OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToRankineBoilingPointTest() => Assert.AreEqual(expected: Constants.BoilingPointH2OInRankine, Delisle.ToRankine(Constants.BoilingPointH2OInDelisle).Value);
		}

		[TestClass]
		public class ToDelisleTests
		{

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void ValidIConversionToDelislePassedTest()
			{
				var celsius = new Celsius(Constants.AbsoluteZeroInCelsius);
				var kelvin = new Kelvin(Constants.AbsoluteZeroInKelvin);
				var fahrenheit = new Fahrenheit(Constants.AbsoluteZeroInFahrenheit);
				var rankine = new Rankine(Constants.AbsoluteZeroInRankine);
				var delisle = new Delisle(Constants.AbsoluteZeroInDelisle);
				var newton = new Newton(Constants.AbsoluteZeroInNewton);
				var réaumur = new Réaumur(Constants.AbsoluteZeroInRéaumur);
				var rømer = new Rømer(Constants.AbsoluteZeroInRømer);
				Assert.AreEqual(Constants.AbsoluteZeroInDelisle, Delisle.ToDelisle(kelvin).Value);
				Assert.AreEqual(Constants.AbsoluteZeroInDelisle, Delisle.ToDelisle(celsius).Value);
				Assert.AreEqual(Constants.AbsoluteZeroInDelisle, Delisle.ToDelisle(fahrenheit).Value);
				Assert.AreEqual(Constants.AbsoluteZeroInDelisle, Delisle.ToDelisle(rankine).Value);
				Assert.AreEqual(Constants.AbsoluteZeroInDelisle, Delisle.ToDelisle(delisle).Value);
				Assert.AreEqual(Constants.AbsoluteZeroInDelisle, Delisle.ToDelisle(newton).Value);
				Assert.AreEqual(Constants.AbsoluteZeroInDelisle, Delisle.ToDelisle(réaumur).Value);
				Assert.AreEqual(Constants.AbsoluteZeroInDelisle, Delisle.ToDelisle(rømer).Value);
			}
		}

		[TestClass]
		public class ToNewtonTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void DelisleToNewtonTest()
			{
				double temp1 = 20;

				Assert.AreEqual(expected: new Newton(Converter.Del2New(temp1)), new Delisle(temp1).ToNewton());
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void FromDoubleToNewtonTest()
			{
				Assert.AreEqual(expected: Constants.AbsoluteZeroInNewton, new Delisle(Constants.AbsoluteZeroInDelisle).ToNewton().Value, OperationOverDoublePrecision.HighPrecision);
				Assert.AreEqual(expected: Constants.MeltingPointH2OInNewton, new Delisle(Constants.MeltingPointH2OInDelisle).ToNewton().Value, OperationOverDoublePrecision.HighPrecision);
				Assert.AreEqual(expected: Constants.BoilingPointH2OInNewton, new Delisle(Constants.BoilingPointH2OInDelisle).ToNewton().Value, OperationOverDoublePrecision.HighPrecision);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToNewtonAbsoluteZeroTest() => Assert.AreEqual(expected: Constants.AbsoluteZeroInNewton, Delisle.ToNewton(Constants.AbsoluteZeroInDelisle).Value, OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToNewtonMeltingPointTest() => Assert.AreEqual(expected: Constants.MeltingPointH2OInNewton, Delisle.ToNewton(Constants.MeltingPointH2OInDelisle).Value);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToNewtonBoilingPointTest() => Assert.AreEqual(expected: Constants.BoilingPointH2OInNewton, Delisle.ToNewton(Constants.BoilingPointH2OInDelisle).Value);
		}

		[TestClass]
		public class ToRéaumurTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void DelisleToRéaumurTest()
			{
				double temp1 = 20;

				Assert.AreEqual(expected: new Réaumur(Converter.Del2Réau(temp1)), new Delisle(temp1).ToRéaumur());
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void FromDoubleToRéaumurTest()
			{
				Assert.AreEqual(expected: Constants.AbsoluteZeroInRéaumur, new Delisle(Constants.AbsoluteZeroInDelisle).ToRéaumur().Value, OperationOverDoublePrecision.HighPrecision);
				Assert.AreEqual(expected: Constants.MeltingPointH2OInRéaumur, new Delisle(Constants.MeltingPointH2OInDelisle).ToRéaumur().Value, OperationOverDoublePrecision.HighPrecision);
				Assert.AreEqual(expected: Constants.BoilingPointH2OInRéaumur, new Delisle(Constants.BoilingPointH2OInDelisle).ToRéaumur().Value, OperationOverDoublePrecision.HighPrecision);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToRéaumurAbsoluteZeroTest() => Assert.AreEqual(expected: Constants.AbsoluteZeroInRéaumur, Delisle.ToRéaumur(Constants.AbsoluteZeroInDelisle).Value, OperationOverDoublePrecision.HighPrecision);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToRéaumurMeltingPointTest() => Assert.AreEqual(expected: Constants.MeltingPointH2OInRéaumur, Delisle.ToRéaumur(Constants.MeltingPointH2OInDelisle).Value);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToRéaumurBoilingPointTest() => Assert.AreEqual(expected: Constants.BoilingPointH2OInRéaumur, Delisle.ToRéaumur(Constants.BoilingPointH2OInDelisle).Value);
		}

		[TestClass]
		public class ToRømerTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void DelisleToRømerTest()
			{
				double temp1 = 20;

				Assert.AreEqual(expected: new Rømer(Converter.Del2Røm(temp1)), new Delisle(temp1).ToRømer());
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void FromDoubleToRømerTest()
			{
				Assert.AreEqual(expected: Constants.AbsoluteZeroInRømer, new Delisle(Constants.AbsoluteZeroInDelisle).ToRømer().Value);
				Assert.AreEqual(expected: Constants.MeltingPointH2OInRømer, new Delisle(Constants.MeltingPointH2OInDelisle).ToRømer().Value);
				Assert.AreEqual(expected: Constants.BoilingPointH2OInRømer, new Delisle(Constants.BoilingPointH2OInDelisle).ToRømer().Value);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToRømerAbsoluteZeroTest() => Assert.AreEqual(expected: Constants.AbsoluteZeroInRømer, Delisle.ToRømer(Constants.AbsoluteZeroInDelisle).Value);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToRømerMeltingPointTest() => Assert.AreEqual(expected: Constants.MeltingPointH2OInRømer, Delisle.ToRømer(Constants.MeltingPointH2OInDelisle).Value);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToRømerBoilingPointTest() => Assert.AreEqual(expected: Constants.BoilingPointH2OInRømer, Delisle.ToRømer(Constants.BoilingPointH2OInDelisle).Value);
		}

		[TestClass]
		public class RegexPatternsTests : Delisle
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void SetupNewUnitsTest()
			{
				var delisle = new RegexPatternsTests { RegexPatterns = new[] { "D" } };
				// Alternative would be protected internal setter.

				Assert.AreEqual(delisle.RegexPatterns[0], "D");
			}
		}

		[TestClass]
		public class ToStringTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void DegreeDelisleTest()
			{
				var delisle = new Fahrenheit(Constants.MeltingPointH2OInKelvin);

				Assert.AreEqual($"{delisle.Value} °{delisle.RegexPatterns[0]}", delisle.ToString());
			}
		}

		[TestClass]
		public class DelisleComplexOperationTests
		{
			[TestCategory(TestCategory.IntegrationTests)]
			[TestMethod]
			public void DemoTest()
			{
				// Unit creation
				var delisle = new Delisle(Constants.MeltingPointH2OInDelisle);
				Assert.AreEqual(Constants.MeltingPointH2OInDelisle, delisle.Value);

				delisle = new Delisle("50.8 °D");
				Assert.AreEqual(new Delisle(50.8), delisle);

				delisle = new Delisle("273.15 K");
				Assert.AreEqual(new Kelvin(Constants.MeltingPointH2OInKelvin), delisle);


				var fahrenheit = new Fahrenheit(Constants.MeltingPointH2OInFahrenheit);
				var delisle2 = new Delisle(fahrenheit);
				Assert.AreEqual(fahrenheit, delisle2);


				// Arithmetic
				var delisle3 = delisle + delisle2;
				Assert.AreEqual(2 * Constants.MeltingPointH2OInDelisle, delisle3.Value);
				var delisle4 = delisle + fahrenheit;
				Assert.AreEqual(2 * Constants.MeltingPointH2OInDelisle, delisle4.Value);
				delisle3 = delisle2 - delisle;
				Assert.AreEqual(2 * Constants.MeltingPointH2OInDelisle, delisle3.Value);
				delisle4 = delisle2 - fahrenheit;
				Assert.AreEqual(2 * Constants.MeltingPointH2OInDelisle, delisle4.Value);

				delisle3.Value = 20;
				delisle4.Value = 30;

				delisle3 += delisle4;
				Assert.AreEqual(50, delisle3.Value);
				delisle3 -= delisle4;
				Assert.AreEqual(80, delisle3.Value);

				// OOP Conversion
				delisle = new Delisle(fahrenheit.ToDelisle());
				Assert.AreEqual(delisle, fahrenheit);
				delisle = Delisle.ToDelisle(fahrenheit);
				Assert.AreEqual(fahrenheit, delisle);

				double someTemperatureInDelisle = Converter.Fah2Del(Constants.BoilingPointH2OInFahrenheit);
				double newValueInKelvin = Delisle.ToKelvin(someTemperatureInDelisle).Value;
				Assert.AreEqual(someTemperatureInDelisle, Converter.Kel2Del(newValueInKelvin), OperationOverDoublePrecision.HighPrecision);

				// Comparison
				delisle.Value = 20;
				delisle2.Value = 20;

				Assert.AreEqual(delisle, delisle2);

				delisle = new Delisle(Constants.AbsoluteZeroInDelisle);
				fahrenheit = new Fahrenheit(Constants.AbsoluteZeroInFahrenheit);

				Assert.AreEqual(delisle, fahrenheit);
			}
		}
	}
}
