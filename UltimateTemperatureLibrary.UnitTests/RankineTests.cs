using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UltimateTemperatureLibrary.Interfaces;
using UltimateTemperatureLibrary.Utils;

namespace UltimateTemperatureLibrary.UnitTests
{
    public class RankineTests
    {
        [TestClass]
        public class RankineConstructorsTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void AbsoluteZeroEmptyConstructorTest()
            {
                var rankine = new Rankine();

                Assert.AreEqual(Constants.AbsoluteZeroInRankine, rankine.Value, Double.Epsilon);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void OutOfRangeEmptyConstructorTest()
            {
                var rankine = new Rankine { Value = -500 };
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void InRangeEmptyConstructorTest()
            {
                var rankine = new Rankine { Value = 500 };
                Assert.AreEqual(500, rankine.Value, Double.Epsilon);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void OutOfRangeDoubleConstructorTest()
            {
                var rankine = new Rankine(-500);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void NullAsStringPassedToConstructorTest()
            {
                var rankine = new Rankine((string)null);
                Assert.AreEqual(Constants.AbsoluteZeroInRankine, rankine.Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void NullAsUnitPassedToConstructorTest()
            {
                var rankine = new Rankine((IConversionToRankine)null);
                Assert.AreEqual(Constants.AbsoluteZeroInRankine, rankine.Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void OutOfRangeStringConstructorTest()
            {
                var rankine = new Rankine("-500");
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            [ExpectedException(typeof(FormatException))]
            public void NoValueStringConstructorTest()
            {
                var rankine = new Rankine(" K");
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromKelvinTest()
            {
                var kelvin = new Kelvin(100.0);
                Assert.AreEqual(kelvin.ToRankine(), new Rankine(kelvin));
            }

            [TestCategory(TestCategory.IntegrationTests)]
            [TestMethod]
            public void FromOtherUnitsAsStringTest()
            {
                Assert.AreEqual(new Kelvin(100), new Rankine("100 K"));
                Assert.AreEqual(new Celsius(100), new Celsius("100 °C"));
                Assert.AreEqual(new Fahrenheit(100), new Rankine("100 °F"));
                Assert.AreEqual(new Rankine(100), new Rankine("100 °R"));
                Assert.AreEqual(new Delisle(100), new Rankine("100 °D"));
                Assert.AreEqual(new Newton(100), new Rankine("100 °N"));
                Assert.AreEqual(new Réaumur(100), new Rankine("100 Ré"));
                Assert.AreEqual(new Rømer(100), new Rankine("100 Rø"));
            }
        }

        [TestClass]
        public class RankineAdditionOperatorTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void RankineAddRankineFromRankineTest()
            {
                double temp1 = 20;
                double temp2 = 30;
                var rankine = new Rankine(temp1);
                var rankine2 = new Rankine(temp2);

                Assert.AreEqual(expected: new Rankine(temp1 + temp2), rankine + rankine2);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void RankineAddRankineFromValuesTest()
            {
                double temp1 = 20;
                double temp2 = 30;
                var rankine = new Rankine(temp1);
                var rankine2 = new Rankine(temp2);

                Assert.AreEqual(rankine.Value + rankine2.Value, new Rankine(temp1 + temp2).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void RankineAddNullTest()
            {
                double temp1 = 20;
                var rankine = new Rankine(temp1);

                Assert.AreEqual(rankine.Value, (rankine + null).Value);
            }
        }

        [TestClass]
        public class RankineSubtractionOperatorTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void RankineSubtractionRankineFromRankineTest()
            {
                double temp1 = 20;
                double temp2 = 30;
                var rankine = new Rankine(temp1);
                var rankine2 = new Rankine(temp2);

                Assert.AreEqual(expected: new Rankine(temp2 - temp1), rankine2 - rankine);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void RankineSubtractionRankineFromFromTest()
            {
                double temp1 = 20;
                double temp2 = 30;
                var rankine = new Rankine(temp1);
                var rankine2 = new Rankine(temp2);

                Assert.AreEqual(rankine2.Value - rankine.Value, new Rankine(temp2 - temp1).Value);
            }
        }

        [TestClass]
        public class ToKelvinTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void RankineToKelvinTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Kelvin(Converter.Ran2Kel(temp1)), new Rankine(temp1).ToKelvin());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToKelvinTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInKelvin, new Rankine(Constants.AbsoluteZeroInRankine).ToKelvin().Value);
                Assert.AreEqual(expected: Constants.MeltingPointH2OInKelvin, new Rankine(Constants.MeltingPointH2OInRankine).ToKelvin().Value);
                Assert.AreEqual(expected: Constants.BoilingPointH2OInKelvin, new Rankine(Constants.BoilingPointH2OInRankine).ToKelvin().Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToKelvinAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInKelvin, Rankine.ToKelvin(Constants.AbsoluteZeroInRankine).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToKelvinMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInKelvin, Rankine.ToKelvin(Constants.MeltingPointH2OInRankine).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToKelvinBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInKelvin, Rankine.ToKelvin(Constants.BoilingPointH2OInRankine).Value);
            }
        }

        [TestClass]
        public class ToCelsiusTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void RankineToCelsiusTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Celsius(Converter.Ran2Cel(temp1)), new Rankine(temp1).ToCelsius());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToCelsiusTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInCelsius, new Rankine(Constants.AbsoluteZeroInRankine).ToCelsius().Value);
                Assert.AreEqual(expected: Constants.MeltingPointH2OInCelsius, new Rankine(Constants.MeltingPointH2OInRankine).ToCelsius().Value);
                Assert.AreEqual(expected: Constants.BoilingPointH2OInCelsius, new Rankine(Constants.BoilingPointH2OInRankine).ToCelsius().Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToCelsiusAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInCelsius, Rankine.ToCelsius(Constants.AbsoluteZeroInRankine).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToCelsiusMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInCelsius, Rankine.ToCelsius(Constants.MeltingPointH2OInRankine).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToCelsiusBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInCelsius, Rankine.ToCelsius(Constants.BoilingPointH2OInRankine).Value);
            }
        }

        [TestClass]
        public class ToFahrenheitTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void RankineToFahrenheitTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Fahrenheit(Converter.Ran2Fah(temp1)), new Rankine(temp1).ToFahrenheit());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToFahrenheitTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInFahrenheit, new Rankine(Constants.AbsoluteZeroInRankine).ToFahrenheit().Value);
                Assert.AreEqual(expected: Constants.MeltingPointH2OInFahrenheit, new Rankine(Constants.MeltingPointH2OInRankine).ToFahrenheit().Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(expected: Constants.BoilingPointH2OInFahrenheit, new Rankine(Constants.BoilingPointH2OInRankine).ToFahrenheit().Value, OperationOverDoublePrecision.HighPrecision);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToFahrenheitAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInFahrenheit, Rankine.ToFahrenheit(Constants.AbsoluteZeroInRankine).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToFahrenheitMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInFahrenheit, Rankine.ToFahrenheit(Constants.MeltingPointH2OInRankine).Value, OperationOverDoublePrecision.HighPrecision);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToFahrenheitBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInFahrenheit, Rankine.ToFahrenheit(Constants.BoilingPointH2OInRankine).Value, OperationOverDoublePrecision.HighPrecision);
            }
        }

        [TestClass]
        public class ToRankineTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void ValidIConversionToRankinePassedTest()
            {
                var celsius = new Celsius(Constants.AbsoluteZeroInCelsius);
                var kelvin = new Kelvin(Constants.AbsoluteZeroInKelvin);
                var fahrenheit = new Fahrenheit(Constants.AbsoluteZeroInFahrenheit);
                var rankine = new Rankine(Constants.AbsoluteZeroInRankine);
                var delisle = new Delisle(Constants.AbsoluteZeroInDelisle);
                var newton = new Newton(Constants.AbsoluteZeroInNewton);
                var réaumur = new Réaumur(Constants.AbsoluteZeroInRéaumur);
                var rømer = new Rømer(Constants.AbsoluteZeroInRømer);
                Assert.AreEqual(Constants.AbsoluteZeroInRankine, Rankine.ToRankine(kelvin).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRankine, Rankine.ToRankine(celsius).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRankine, Rankine.ToRankine(fahrenheit).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRankine, Rankine.ToRankine(rankine).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRankine, Rankine.ToRankine(delisle).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRankine, Rankine.ToRankine(newton).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRankine, Rankine.ToRankine(réaumur).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRankine, Rankine.ToRankine(rømer).Value);
            }
        }


        [TestClass]
        public class ToDelisleTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void RankineToDelisleTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Delisle(Converter.Ran2Del(temp1)), new Rankine(temp1).ToDelisle());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToDelisleTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInDelisle, new Rankine(Constants.AbsoluteZeroInRankine).ToDelisle().Value, 1e-12);
                Assert.AreEqual(expected: Constants.MeltingPointH2OInDelisle, new Rankine(Constants.MeltingPointH2OInRankine).ToDelisle().Value, 1e-12);
                Assert.AreEqual(expected: Constants.BoilingPointH2OInDelisle, new Rankine(Constants.BoilingPointH2OInRankine).ToDelisle().Value, 1e-12);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToDelisleAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInDelisle, Rankine.ToDelisle(Constants.AbsoluteZeroInRankine).Value, 1e-12);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToDelisleMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInDelisle, Rankine.ToDelisle(Constants.MeltingPointH2OInRankine).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToDelisleBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInDelisle, Rankine.ToDelisle(Constants.BoilingPointH2OInRankine).Value);
            }
        }

        [TestClass]
        public class ToNewtonTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void RankineToNewtonTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Newton(Converter.Ran2New(temp1)), new Rankine(temp1).ToNewton());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToNewtonTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInNewton, new Rankine(Constants.AbsoluteZeroInRankine).ToNewton().Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(expected: Constants.MeltingPointH2OInNewton, new Rankine(Constants.MeltingPointH2OInRankine).ToNewton().Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(expected: Constants.BoilingPointH2OInNewton, new Rankine(Constants.BoilingPointH2OInRankine).ToNewton().Value, OperationOverDoublePrecision.HighPrecision);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToNewtonAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInNewton, Rankine.ToNewton(Constants.AbsoluteZeroInRankine).Value, OperationOverDoublePrecision.HighPrecision);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToNewtonMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInNewton, Rankine.ToNewton(Constants.MeltingPointH2OInRankine).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToNewtonBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInNewton, Rankine.ToNewton(Constants.BoilingPointH2OInRankine).Value);
            }
        }

        [TestClass]
        public class ToRéaumurTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void RankineToRéaumurTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Réaumur(Converter.Ran2Réau(temp1)), new Rankine(temp1).ToRéaumur());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToRéaumurTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInRéaumur, new Rankine(Constants.AbsoluteZeroInRankine).ToRéaumur().Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(expected: Constants.MeltingPointH2OInRéaumur, new Rankine(Constants.MeltingPointH2OInRankine).ToRéaumur().Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(expected: Constants.BoilingPointH2OInRéaumur, new Rankine(Constants.BoilingPointH2OInRankine).ToRéaumur().Value, OperationOverDoublePrecision.HighPrecision);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRéaumurAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInRéaumur, Rankine.ToRéaumur(Constants.AbsoluteZeroInRankine).Value, OperationOverDoublePrecision.HighPrecision);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRéaumurMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInRéaumur, Rankine.ToRéaumur(Constants.MeltingPointH2OInRankine).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRéaumurBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInRéaumur, Rankine.ToRéaumur(Constants.BoilingPointH2OInRankine).Value);
            }
        }

        [TestClass]
        public class ToRømerTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void RankineToRømerTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Rømer(Converter.Ran2Røm(temp1)), new Rankine(temp1).ToRømer());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToRømerTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInRømer, new Rankine(Constants.AbsoluteZeroInRankine).ToRømer().Value);
                Assert.AreEqual(expected: Constants.MeltingPointH2OInRømer, new Rankine(Constants.MeltingPointH2OInRankine).ToRømer().Value);
                Assert.AreEqual(expected: Constants.BoilingPointH2OInRømer, new Rankine(Constants.BoilingPointH2OInRankine).ToRømer().Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRømerAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInRømer, Rankine.ToRømer(Constants.AbsoluteZeroInRankine).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRømerMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInRømer, Rankine.ToRømer(Constants.MeltingPointH2OInRankine).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRømerBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInRømer, Rankine.ToRømer(Constants.BoilingPointH2OInRankine).Value);
            }
        }

        [TestClass]
        public class RegexPatternsTests : Rankine
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void SetupNewUnitsTest()
            {
                var rankine = new RegexPatternsTests { RegexPatterns = new[] { "F" } };
                // Alternative would be protected internal setter.

                Assert.AreEqual(rankine.RegexPatterns[0], "F");
            }
        }

        [TestClass]
        public class ToStringTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void DegreeRankineTest()
            {
                var rankine = new Fahrenheit(Constants.MeltingPointH2OInKelvin);

                Assert.AreEqual($"{rankine.Value} °{rankine.RegexPatterns[0]}", rankine.ToString());
            }
        }

        [TestClass]
        public class RankineComplexOperationTests
        {
            [TestCategory(TestCategory.IntegrationTests)]
            [TestMethod]
            public void DemoTest()
            {
                // Unit creation
                var rankine = new Rankine(Constants.MeltingPointH2OInRankine);
                Assert.AreEqual(Constants.MeltingPointH2OInRankine, rankine.Value);

                rankine = new Rankine("50.8 °R");
                Assert.AreEqual(new Rankine(50.8), rankine);

                rankine = new Rankine("0 K");
                Assert.AreEqual(new Kelvin(Constants.AbsoluteZeroInKelvin), rankine);


                var fahrenheit = new Fahrenheit(Constants.MeltingPointH2OInFahrenheit);
                var rankine2 = new Rankine(fahrenheit);
                Assert.AreEqual(fahrenheit, rankine2);


                // Arithmetic
                var rankine3 = rankine + rankine2;
                Assert.AreEqual(Constants.MeltingPointH2OInRankine, rankine3.Value, OperationOverDoublePrecision.HighPrecision);
                var rankine4 = rankine + fahrenheit;
                Assert.AreEqual(Constants.MeltingPointH2OInRankine, rankine4.Value, OperationOverDoublePrecision.HighPrecision);
                rankine3 = rankine2 - rankine;
                Assert.AreEqual(Constants.MeltingPointH2OInRankine, rankine3.Value, OperationOverDoublePrecision.HighPrecision);
                rankine4 = rankine2 - fahrenheit;
                Assert.AreEqual(Constants.AbsoluteZeroInRankine, rankine4.Value);

                rankine3.Value = 20;
                rankine4.Value = 30;

                rankine3 += rankine4;
                Assert.AreEqual(50, rankine3.Value);
                rankine3 -= rankine4;
                Assert.AreEqual(20, rankine3.Value);

                // OOP Conversion
                rankine = new Rankine(fahrenheit.ToRankine());
                Assert.AreEqual(rankine, fahrenheit);
                rankine = Rankine.ToRankine(fahrenheit);
                Assert.AreEqual(fahrenheit, rankine);

                double someTemperatureInRankine = Converter.Ran2Fah(Constants.BoilingPointH2OInRankine);
                double newValueInKelvin = Rankine.ToKelvin(someTemperatureInRankine).Value;
                Assert.AreEqual(someTemperatureInRankine, Converter.Kel2Ran(newValueInKelvin), OperationOverDoublePrecision.HighPrecision);

                // Comparison
                rankine.Value = 20;
                rankine2.Value = 20;

                Assert.AreEqual(rankine, rankine2);

                rankine = new Rankine(Constants.AbsoluteZeroInKelvin);
                fahrenheit = new Fahrenheit(Constants.AbsoluteZeroInFahrenheit);

                Assert.AreEqual(rankine, fahrenheit);
            }
        }
    }
}
