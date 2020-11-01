using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UltimateTemperatureLibrary.Interfaces;
using UltimateTemperatureLibrary.Utils;

namespace UltimateTemperatureLibrary.UnitTests
{
	public class RømerTests
	{
		[TestClass]
		public class RømerConstructorsTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void AbsoluteZeroEmptyConstructorTest()
			{
				var rømer = new Rømer();

				Assert.AreEqual(Constants.AbsoluteZeroInRømer, rømer.Value, double.Epsilon);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void OutOfRangeEmptyConstructorTest()
			{
				var rømer = new Rømer { Value = -500 };
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void InRangeEmptyConstructorTest()
			{
				var rømer = new Rømer { Value = 500 };
				Assert.AreEqual(500, rømer.Value, double.Epsilon);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void OutOfRangeDoubleConstructorTest()
			{
				var rømer = new Rømer(-500);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void NullAsStringPassedToConstructorTest()
			{
				var rømer = new Rømer((string) null);
				Assert.AreEqual(Constants.AbsoluteZeroInRømer, rømer.Value);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void NullAsUnitPassedToConstructorTest()
			{
				var rømer = new Rømer((IConversionToRømer) null);
				Assert.AreEqual(Constants.AbsoluteZeroInRømer, rømer.Value);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void OutOfRangeStringConstructorTest()
			{
				var rømer = new Rømer("-500");
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			[ExpectedException(typeof(FormatException))]
			public void NoValueStringConstructorTest()
			{
				var rømer = new Rømer(" K");
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void FromKelvinTest()
			{
				var kelvin = new Kelvin(100.0);
				Assert.AreEqual(kelvin.ToRømer(), new Rømer(kelvin));
			}

			[TestCategory(TestCategory.IntegrationTests)]
			[TestMethod]
			public void FromOtherUnitsAsStringTest()
			{
				Assert.AreEqual(new Kelvin(100), new Rømer("100 K"));
				Assert.AreEqual(new Celsius(100), new Celsius("100 °C"));
				Assert.AreEqual(new Fahrenheit(100), new Rømer("100 °F"));
				Assert.AreEqual(new Rankine(100), new Rømer("100 °R"));
				Assert.AreEqual(new Delisle(100), new Rømer("100 °D"));
				Assert.AreEqual(new Newton(100), new Rømer("100 °N"));
				Assert.AreEqual(new Réaumur(100), new Rømer("100 Ré"));
				Assert.AreEqual(new Rømer(100), new Rømer("100 Rø"));
			}
		}

		[TestClass]
		public class RømerAdditionOperatorTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void RømerAddRømerFromRømerTest()
			{
				double temp1 = 20;
				double temp2 = 30;
				var rømer = new Rømer(temp1);
				var rømer2 = new Rømer(temp2);

				Assert.AreEqual(expected: new Rømer(temp1 + temp2), rømer + rømer2);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void RømerAddRømerFromValuesTest()
			{
				double temp1 = 20;
				double temp2 = 30;
				var rømer = new Rømer(temp1);
				var rømer2 = new Rømer(temp2);

				Assert.AreEqual(rømer.Value + rømer2.Value, new Rømer(temp1 + temp2).Value);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void RømerAddNullTest()
			{
				double temp1 = 20;
				var rømer = new Rømer(temp1);

				Assert.AreEqual(rømer.Value, (rømer + null).Value);
			}
		}

		[TestClass]
		public class RømerSubtractionOperatorTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void RømerSubtractionRømerFromRømerTest()
			{
				double temp1 = 20;
				double temp2 = 30;
				var rømer = new Rømer(temp1);
				var rømer2 = new Rømer(temp2);

				Assert.AreEqual(expected: new Rømer(temp1 - temp2), rømer - rømer2);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void RømerSubtractionRømerFromFromTest()
			{
				double temp1 = 20;
				double temp2 = 30;
				var rømer = new Rømer(temp1);
				var rømer2 = new Rømer(temp2);

				Assert.AreEqual(rømer.Value - rømer2.Value, new Rømer(temp1 - temp2).Value);
			}
		}

		[TestClass]
		public class ToKelvinTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void RømerToKelvinTest()
			{
				double temp1 = 20;

				Assert.AreEqual(expected: new Kelvin(Converter.Røm2Kel(temp1)), new Rømer(temp1).ToKelvin());
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void FromDoubleToKelvinTest()
			{
				Assert.AreEqual(expected: Constants.AbsoluteZeroInKelvin, new Rømer(Constants.AbsoluteZeroInRømer).ToKelvin().Value);
				Assert.AreEqual(expected: Constants.MeltingPointH2OInKelvin, new Rømer(Constants.MeltingPointH2OInRømer).ToKelvin().Value);
				Assert.AreEqual(expected: Constants.BoilingPointH2OInKelvin, new Rømer(Constants.BoilingPointH2OInRømer).ToKelvin().Value);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToKelvinAbsoluteZeroTest() => Assert.AreEqual(expected: Constants.AbsoluteZeroInKelvin, Rømer.ToKelvin(Constants.AbsoluteZeroInRømer).Value);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToKelvinMeltingPointTest() => Assert.AreEqual(expected: Constants.MeltingPointH2OInKelvin, Rømer.ToKelvin(Constants.MeltingPointH2OInRømer).Value);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToKelvinBoilingPointTest() => Assert.AreEqual(expected: Constants.BoilingPointH2OInKelvin, Rømer.ToKelvin(Constants.BoilingPointH2OInRømer).Value);
		}

		[TestClass]
		public class ToCelsiusTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void RømerToCelsiusTest()
			{
				double temp1 = 20;

				Assert.AreEqual(expected: new Celsius(Converter.Røm2Cel(temp1)), new Rømer(temp1).ToCelsius());
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void FromDoubleToCelsiusTest()
			{
				Assert.AreEqual(expected: Constants.AbsoluteZeroInCelsius, new Rømer(Constants.AbsoluteZeroInRømer).ToCelsius().Value);
				Assert.AreEqual(expected: Constants.MeltingPointH2OInCelsius, new Rømer(Constants.MeltingPointH2OInRømer).ToCelsius().Value);
				Assert.AreEqual(expected: Constants.BoilingPointH2OInCelsius, new Rømer(Constants.BoilingPointH2OInRømer).ToCelsius().Value);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToCelsiusAbsoluteZeroTest() => Assert.AreEqual(expected: Constants.AbsoluteZeroInCelsius, Rømer.ToCelsius(Constants.AbsoluteZeroInRømer).Value);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToCelsiusMeltingPointTest() => Assert.AreEqual(expected: Constants.MeltingPointH2OInCelsius, Rømer.ToCelsius(Constants.MeltingPointH2OInRømer).Value);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToCelsiusBoilingPointTest() => Assert.AreEqual(expected: Constants.BoilingPointH2OInCelsius, Rømer.ToCelsius(Constants.BoilingPointH2OInRømer).Value);
		}

		[TestClass]
		public class ToFahrenheitTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void RømerToFahrenheitTest()
			{
				double temp1 = 20;

				Assert.AreEqual(expected: new Fahrenheit(Converter.Røm2Fah(temp1)), new Rømer(temp1).ToFahrenheit());
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void FromDoubleToFahrenheitTest()
			{
				Assert.AreEqual(expected: Constants.AbsoluteZeroInFahrenheit, new Rømer(Constants.AbsoluteZeroInRømer).ToFahrenheit().Value);
				Assert.AreEqual(expected: Constants.MeltingPointH2OInFahrenheit, new Rømer(Constants.MeltingPointH2OInRømer).ToFahrenheit().Value, 1e-13);
				Assert.AreEqual(expected: Constants.BoilingPointH2OInFahrenheit, new Rømer(Constants.BoilingPointH2OInRømer).ToFahrenheit().Value, 1e-13);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToFahrenheitAbsoluteZeroTest() => Assert.AreEqual(expected: Constants.AbsoluteZeroInFahrenheit, Rømer.ToFahrenheit(Constants.AbsoluteZeroInRømer).Value);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToFahrenheitMeltingPointTest() => Assert.AreEqual(expected: Constants.MeltingPointH2OInFahrenheit, Rømer.ToFahrenheit(Constants.MeltingPointH2OInRømer).Value, 1e-13);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToFahrenheitBoilingPointTest() => Assert.AreEqual(expected: Constants.BoilingPointH2OInFahrenheit, Rømer.ToFahrenheit(Constants.BoilingPointH2OInRømer).Value, 1e-13);
		}

		[TestClass]
		public class ToRankineTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void RømerToRankineTest()
			{
				double temp1 = 20;

				Assert.AreEqual(expected: new Rankine(Converter.Røm2Ran(temp1)), new Rømer(temp1).ToRankine());
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void FromDoubleToRankineTest()
			{
				Assert.AreEqual(expected: Constants.AbsoluteZeroInRankine, new Rømer(Constants.AbsoluteZeroInRømer).ToRankine().Value);
				Assert.AreEqual(expected: Constants.MeltingPointH2OInRankine, new Rømer(Constants.MeltingPointH2OInRømer).ToRankine().Value, 1e-13);
				Assert.AreEqual(expected: Constants.BoilingPointH2OInRankine, new Rømer(Constants.BoilingPointH2OInRømer).ToRankine().Value, 1e-13);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToRankineAbsoluteZeroTest() => Assert.AreEqual(expected: Constants.AbsoluteZeroInRankine, Rømer.ToRankine(Constants.AbsoluteZeroInRømer).Value);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToRankineMeltingPointTest() => Assert.AreEqual(expected: Constants.MeltingPointH2OInRankine, Rømer.ToRankine(Constants.MeltingPointH2OInRømer).Value, 1e-13);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToRankineBoilingPointTest() => Assert.AreEqual(expected: Constants.BoilingPointH2OInRankine, Rømer.ToRankine(Constants.BoilingPointH2OInRømer).Value);
		}

		[TestClass]
		public class ToDelisleTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void RømerToDelisleTest()
			{
				double temp1 = 20;

				Assert.AreEqual(expected: new Delisle(Converter.Røm2Del(temp1)), new Rømer(temp1).ToDelisle());
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void FromDoubleToDelisleTest()
			{
				Assert.AreEqual(expected: Constants.AbsoluteZeroInDelisle, new Rømer(Constants.AbsoluteZeroInRømer).ToDelisle().Value, 1e-12);
				Assert.AreEqual(expected: Constants.MeltingPointH2OInDelisle, new Rømer(Constants.MeltingPointH2OInRømer).ToDelisle().Value, 1e-12);
				Assert.AreEqual(expected: Constants.BoilingPointH2OInDelisle, new Rømer(Constants.BoilingPointH2OInRømer).ToDelisle().Value, 1e-12);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToDelisleAbsoluteZeroTest() => Assert.AreEqual(expected: Constants.AbsoluteZeroInDelisle, Rømer.ToDelisle(Constants.AbsoluteZeroInRømer).Value, 1e-12);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToDelisleMeltingPointTest() => Assert.AreEqual(expected: Constants.MeltingPointH2OInDelisle, Rømer.ToDelisle(Constants.MeltingPointH2OInRømer).Value);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToDelisleBoilingPointTest() => Assert.AreEqual(expected: Constants.BoilingPointH2OInDelisle, Rømer.ToDelisle(Constants.BoilingPointH2OInRømer).Value);
		}

		[TestClass]
		public class ToNewtonTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void RømerToNewtonTest()
			{
				double temp1 = 20;

				Assert.AreEqual(expected: new Newton(Converter.Røm2New(temp1)), new Rømer(temp1).ToNewton());
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void FromDoubleToNewtonTest()
			{
				Assert.AreEqual(expected: Constants.AbsoluteZeroInNewton, new Rømer(Constants.AbsoluteZeroInRømer).ToNewton().Value, 1e-13);
				Assert.AreEqual(expected: Constants.MeltingPointH2OInNewton, new Rømer(Constants.MeltingPointH2OInRømer).ToNewton().Value, 1e-13);
				Assert.AreEqual(expected: Constants.BoilingPointH2OInNewton, new Rømer(Constants.BoilingPointH2OInRømer).ToNewton().Value, 1e-13);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToNewtonAbsoluteZeroTest() => Assert.AreEqual(expected: Constants.AbsoluteZeroInNewton, Rømer.ToNewton(Constants.AbsoluteZeroInRømer).Value, 1e-13);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToNewtonMeltingPointTest() => Assert.AreEqual(expected: Constants.MeltingPointH2OInNewton, Rømer.ToNewton(Constants.MeltingPointH2OInRømer).Value);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToNewtonBoilingPointTest() => Assert.AreEqual(expected: Constants.BoilingPointH2OInNewton, Rømer.ToNewton(Constants.BoilingPointH2OInRømer).Value);
		}

		[TestClass]
		public class ToRéaumurTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void RømerToRéaumurTest()
			{
				double temp1 = 20;

				Assert.AreEqual(expected: new Réaumur(Converter.Røm2Réau(temp1)), new Rømer(temp1).ToRéaumur());
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void FromDoubleToRéaumurTest()
			{
				Assert.AreEqual(expected: Constants.AbsoluteZeroInRéaumur, new Rømer(Constants.AbsoluteZeroInRømer).ToRéaumur().Value, 1e-13);
				Assert.AreEqual(expected: Constants.MeltingPointH2OInRéaumur, new Rømer(Constants.MeltingPointH2OInRømer).ToRéaumur().Value, 1e-13);
				Assert.AreEqual(expected: Constants.BoilingPointH2OInRéaumur, new Rømer(Constants.BoilingPointH2OInRømer).ToRéaumur().Value, 1e-13);
			}

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToRéaumurAbsoluteZeroTest() => Assert.AreEqual(expected: Constants.AbsoluteZeroInRéaumur, Rømer.ToRéaumur(Constants.AbsoluteZeroInRømer).Value, 1e-13);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToRéaumurMeltingPointTest() => Assert.AreEqual(expected: Constants.MeltingPointH2OInRéaumur, Rømer.ToRéaumur(Constants.MeltingPointH2OInRømer).Value);

			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void StaticFromDoubleToRéaumurBoilingPointTest() => Assert.AreEqual(expected: Constants.BoilingPointH2OInRéaumur, Rømer.ToRéaumur(Constants.BoilingPointH2OInRømer).Value);
		}

		[TestClass]
		public class ToRømerTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void ValidIConversionToRømerPassedTest()
			{
				var celsius = new Celsius(Constants.AbsoluteZeroInCelsius);
				var kelvin = new Kelvin(Constants.AbsoluteZeroInKelvin);
				var fahrenheit = new Fahrenheit(Constants.AbsoluteZeroInFahrenheit);
				var rankine = new Rankine(Constants.AbsoluteZeroInRankine);
				var delisle = new Delisle(Constants.AbsoluteZeroInDelisle);
				var newton = new Newton(Constants.AbsoluteZeroInNewton);
				var réaumur = new Réaumur(Constants.AbsoluteZeroInRéaumur);
				var rømer = new Rømer(Constants.AbsoluteZeroInRømer);
				Assert.AreEqual(Constants.AbsoluteZeroInRømer, Rømer.ToRømer(kelvin).Value);
				Assert.AreEqual(Constants.AbsoluteZeroInRømer, Rømer.ToRømer(celsius).Value);
				Assert.AreEqual(Constants.AbsoluteZeroInRømer, Rømer.ToRømer(fahrenheit).Value);
				Assert.AreEqual(Constants.AbsoluteZeroInRømer, Rømer.ToRømer(rankine).Value);
				Assert.AreEqual(Constants.AbsoluteZeroInRømer, Rømer.ToRømer(delisle).Value);
				Assert.AreEqual(Constants.AbsoluteZeroInRømer, Rømer.ToRømer(newton).Value);
				Assert.AreEqual(Constants.AbsoluteZeroInRømer, Rømer.ToRømer(réaumur).Value);
				Assert.AreEqual(Constants.AbsoluteZeroInRømer, Rømer.ToRømer(rømer).Value);
			}
		}

		[TestClass]
		public class RegexPatternsTests : Rømer
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void SetupNewUnitsTest()
			{
				var rømer = new RegexPatternsTests { RegexPatterns = new[] { "Rø" } };
				// Alternative would be protected internal setter.

				Assert.AreEqual(rømer.RegexPatterns[0], "Rø");
			}
		}

		[TestClass]
		public class ToStringTests
		{
			[TestCategory(TestCategory.BasicTests)]
			[TestMethod]
			public void DegreeRømerTest()
			{
				var rømer = new Fahrenheit(Constants.MeltingPointH2OInKelvin);

				Assert.AreEqual($"{rømer.Value} °{rømer.RegexPatterns[0]}", rømer.ToString());
			}
		}

		[TestClass]
		public class RømerComplexOperationTests
		{
			[TestCategory(TestCategory.IntegrationTests)]
			[TestMethod]
			public void DemoTest()
			{
				// Unit creation
				var rømer = new Rømer(Constants.MeltingPointH2OInRømer);
				Assert.AreEqual(Constants.MeltingPointH2OInRømer, rømer.Value);

				rømer = new Rømer("50.8 °Rø");
				Assert.AreEqual(new Rømer(50.8), rømer);

				rømer = new Rømer("0 K");
				Assert.AreEqual(new Kelvin(Constants.AbsoluteZeroInKelvin), rømer);


				var fahrenheit = new Fahrenheit(Constants.MeltingPointH2OInFahrenheit);
				var rømer2 = new Rømer(fahrenheit);
				Assert.AreEqual(fahrenheit, rømer2);


				// Arithmetic
				var rømer3 = rømer + rømer2;
				Assert.AreEqual(Constants.AbsoluteZeroInRømer + Constants.MeltingPointH2OInRømer, rømer3.Value);
				var rømer4 = rømer + fahrenheit;
				Assert.AreEqual(Constants.AbsoluteZeroInRømer + Constants.MeltingPointH2OInRømer, rømer4.Value);
				rømer3 = rømer2 - rømer;
				Assert.AreEqual(-Constants.AbsoluteZeroInRømer + Constants.MeltingPointH2OInRømer, rømer3.Value);
				rømer4 = rømer2 - fahrenheit;
				Assert.AreEqual(0.0, rømer4.Value);

				rømer3.Value = 20;
				rømer4.Value = 30;

				rømer3 += rømer4;
				Assert.AreEqual(50, rømer3.Value);
				rømer3 -= rømer4;
				Assert.AreEqual(20, rømer3.Value);

				// OOP Conversion
				rømer = new Rømer(fahrenheit.ToRømer());
				Assert.AreEqual(rømer, fahrenheit);
				rømer = Rømer.ToRømer(fahrenheit);
				Assert.AreEqual(fahrenheit, rømer);

				double someTemperatureInRømer = Converter.Ran2Røm(Constants.BoilingPointH2OInRankine);
				double newValueInKelvin = Rømer.ToKelvin(someTemperatureInRømer).Value;
				Assert.AreEqual(someTemperatureInRømer, Converter.Kel2Røm(newValueInKelvin), OperationOverDoublePrecision.HighPrecision);

				// Comparison
				rømer.Value = 20;
				rømer2.Value = 20;

				Assert.AreEqual(rømer, rømer2);

				rømer = new Rømer(Constants.AbsoluteZeroInRømer);
				fahrenheit = new Fahrenheit(Constants.AbsoluteZeroInFahrenheit);

				Assert.AreEqual(rømer, fahrenheit);
			}
		}
	}
}
