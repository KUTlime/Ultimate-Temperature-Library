using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UltimateTemperatureLibrary.Interfaces;
using UltimateTemperatureLibrary.Utils;

namespace UltimateTemperatureLibrary.UnitTests
{
    public class RéaumurTests
    {
        [TestClass]
        public class RéaumurConstructorsTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void AbsoluteZeroEmptyConstructorTest()
            {
                var réaumur = new Réaumur();

                Assert.AreEqual(Constants.AbsoluteZeroInRéaumur, réaumur.Value, Double.Epsilon);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void OutOfRangeEmptyConstructorTest()
            {
                var réaumur = new Réaumur { Value = -500 };
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void InRangeEmptyConstructorTest()
            {
                var réaumur = new Réaumur { Value = 500 };
                Assert.AreEqual(500, réaumur.Value, Double.Epsilon);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void OutOfRangeDoubleConstructorTest()
            {
                var réaumur = new Réaumur(-500);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void NullAsStringPassedToConstructorTest()
            {
                var réaumur = new Réaumur((string)null);
                Assert.AreEqual(Constants.AbsoluteZeroInRéaumur, réaumur.Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void NullAsUnitPassedToConstructorTest()
            {
                var réaumur = new Réaumur((IConversionToRéaumur)null);
                Assert.AreEqual(Constants.AbsoluteZeroInRéaumur, réaumur.Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void OutOfRangeStringConstructorTest()
            {
                var réaumur = new Réaumur("-500");
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            [ExpectedException(typeof(FormatException))]
            public void NoValueStringConstructorTest()
            {
                var réaumur = new Réaumur(" K");
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromKelvinTest()
            {
                var kelvin = new Kelvin(100.0);
                Assert.AreEqual(kelvin.ToRéaumur(), new Réaumur(kelvin));
            }

            [TestCategory(TestCategory.IntegrationTests)]
            [TestMethod]
            public void FromOtherUnitsAsStringTest()
            {
                Assert.AreEqual(new Kelvin(100), new Réaumur("100 K"));
                Assert.AreEqual(new Celsius(100), new Celsius("100 °C"));
                Assert.AreEqual(new Fahrenheit(100), new Réaumur("100 °F"));
                Assert.AreEqual(new Rankine(100), new Réaumur("100 °R"));
                Assert.AreEqual(new Delisle(100), new Réaumur("100 °D"));
                Assert.AreEqual(new Newton(100), new Réaumur("100 °N"));
                Assert.AreEqual(new Réaumur(100), new Réaumur("100 Ré"));
                Assert.AreEqual(new Rømer(100), new Réaumur("100 Rø"));
            }
        }

        [TestClass]
        public class RéaumurAdditionOperatorTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void RéaumurAddRéaumurFromRéaumurTest()
            {
                double temp1 = 20;
                double temp2 = 30;
                var réaumur = new Réaumur(temp1);
                var réaumur2 = new Réaumur(temp2);

                Assert.AreEqual(expected: new Réaumur(temp1 + temp2), réaumur + réaumur2);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void RéaumurAddRéaumurFromValuesTest()
            {
                double temp1 = 20;
                double temp2 = 30;
                var réaumur = new Réaumur(temp1);
                var réaumur2 = new Réaumur(temp2);

                Assert.AreEqual(réaumur.Value + réaumur2.Value, new Réaumur(temp1 + temp2).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void RéaumurAddNullTest()
            {
                double temp1 = 20;
                var réaumur = new Réaumur(temp1);

                Assert.AreEqual(réaumur.Value, (réaumur + null).Value);
            }
        }

        [TestClass]
        public class RéaumurSubtractionOperatorTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void RéaumurSubtractionRéaumurFromRéaumurTest()
            {
                double temp1 = 20;
                double temp2 = 30;
                var réaumur = new Réaumur(temp1);
                var réaumur2 = new Réaumur(temp2);

                Assert.AreEqual(expected: new Réaumur(temp1 - temp2), réaumur - réaumur2);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void RéaumurSubtractionRéaumurFromFromTest()
            {
                double temp1 = 20;
                double temp2 = 30;
                var réaumur = new Réaumur(temp1);
                var réaumur2 = new Réaumur(temp2);

                Assert.AreEqual(réaumur.Value - réaumur2.Value, new Réaumur(temp1 - temp2).Value);
            }
        }

        [TestClass]
        public class ToKelvinTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void RéaumurToKelvinTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Kelvin(Converter.Réau2Kel(temp1)), new Réaumur(temp1).ToKelvin());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToKelvinTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInKelvin, new Réaumur(Constants.AbsoluteZeroInRéaumur).ToKelvin().Value);
                Assert.AreEqual(expected: Constants.MeltingPointH2OInKelvin, new Réaumur(Constants.MeltingPointH2OInRéaumur).ToKelvin().Value);
                Assert.AreEqual(expected: Constants.BoilingPointH2OInKelvin, new Réaumur(Constants.BoilingPointH2OInRéaumur).ToKelvin().Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToKelvinAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInKelvin, Réaumur.ToKelvin(Constants.AbsoluteZeroInRéaumur).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToKelvinMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInKelvin, Réaumur.ToKelvin(Constants.MeltingPointH2OInRéaumur).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToKelvinBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInKelvin, Réaumur.ToKelvin(Constants.BoilingPointH2OInRéaumur).Value);
            }
        }

        [TestClass]
        public class ToCelsiusTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void RéaumurToCelsiusTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Celsius(Converter.Réau2Cel(temp1)), new Réaumur(temp1).ToCelsius());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToCelsiusTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInCelsius, new Réaumur(Constants.AbsoluteZeroInRéaumur).ToCelsius().Value);
                Assert.AreEqual(expected: Constants.MeltingPointH2OInCelsius, new Réaumur(Constants.MeltingPointH2OInRéaumur).ToCelsius().Value);
                Assert.AreEqual(expected: Constants.BoilingPointH2OInCelsius, new Réaumur(Constants.BoilingPointH2OInRéaumur).ToCelsius().Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToCelsiusAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInCelsius, Réaumur.ToCelsius(Constants.AbsoluteZeroInRéaumur).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToCelsiusMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInCelsius, Réaumur.ToCelsius(Constants.MeltingPointH2OInRéaumur).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToCelsiusBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInCelsius, Réaumur.ToCelsius(Constants.BoilingPointH2OInRéaumur).Value);
            }
        }

        [TestClass]
        public class ToFahrenheitTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void RéaumurToFahrenheitTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Fahrenheit(Converter.Réau2Fah(temp1)), new Réaumur(temp1).ToFahrenheit());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToFahrenheitTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInFahrenheit, new Réaumur(Constants.AbsoluteZeroInRéaumur).ToFahrenheit().Value);
                Assert.AreEqual(expected: Constants.MeltingPointH2OInFahrenheit, new Réaumur(Constants.MeltingPointH2OInRéaumur).ToFahrenheit().Value, 1e-13);
                Assert.AreEqual(expected: Constants.BoilingPointH2OInFahrenheit, new Réaumur(Constants.BoilingPointH2OInRéaumur).ToFahrenheit().Value, 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToFahrenheitAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInFahrenheit, Réaumur.ToFahrenheit(Constants.AbsoluteZeroInRéaumur).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToFahrenheitMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInFahrenheit, Réaumur.ToFahrenheit(Constants.MeltingPointH2OInRéaumur).Value, 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToFahrenheitBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInFahrenheit, Réaumur.ToFahrenheit(Constants.BoilingPointH2OInRéaumur).Value, 1e-13);
            }
        }

        [TestClass]
        public class ToRankineTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void RéaumurToRankineTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Rankine(Converter.Réau2Ran(temp1)), new Réaumur(temp1).ToRankine());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToRankineTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInRankine, new Réaumur(Constants.AbsoluteZeroInRéaumur).ToRankine().Value);
                Assert.AreEqual(expected: Constants.MeltingPointH2OInRankine, new Réaumur(Constants.MeltingPointH2OInRéaumur).ToRankine().Value, 1e-13);
                Assert.AreEqual(expected: Constants.BoilingPointH2OInRankine, new Réaumur(Constants.BoilingPointH2OInRéaumur).ToRankine().Value, 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRankineAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInRankine, Réaumur.ToRankine(Constants.AbsoluteZeroInRéaumur).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRankineMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInRankine, Réaumur.ToRankine(Constants.MeltingPointH2OInRéaumur).Value, 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRankineBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInRankine, Réaumur.ToRankine(Constants.BoilingPointH2OInRéaumur).Value);
            }
        }

        [TestClass]
        public class ToDelisleTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void RéaumurToDelisleTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Delisle(Converter.Réau2Del(temp1)), new Réaumur(temp1).ToDelisle());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToDelisleTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInDelisle, new Réaumur(Constants.AbsoluteZeroInRéaumur).ToDelisle().Value, 1e-12);
                Assert.AreEqual(expected: Constants.MeltingPointH2OInDelisle, new Réaumur(Constants.MeltingPointH2OInRéaumur).ToDelisle().Value, 1e-12);
                Assert.AreEqual(expected: Constants.BoilingPointH2OInDelisle, new Réaumur(Constants.BoilingPointH2OInRéaumur).ToDelisle().Value, 1e-12);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToDelisleAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInDelisle, Réaumur.ToDelisle(Constants.AbsoluteZeroInRéaumur).Value, 1e-12);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToDelisleMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInDelisle, Réaumur.ToDelisle(Constants.MeltingPointH2OInRéaumur).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToDelisleBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInDelisle, Réaumur.ToDelisle(Constants.BoilingPointH2OInRéaumur).Value);
            }
        }

        [TestClass]
        public class ToNewtonTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void RéaumurToNewtonTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Newton(Converter.Réau2New(temp1)), new Réaumur(temp1).ToNewton());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToNewtonTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInNewton, new Réaumur(Constants.AbsoluteZeroInRéaumur).ToNewton().Value, 1e-13);
                Assert.AreEqual(expected: Constants.MeltingPointH2OInNewton, new Réaumur(Constants.MeltingPointH2OInRéaumur).ToNewton().Value, 1e-13);
                Assert.AreEqual(expected: Constants.BoilingPointH2OInNewton, new Réaumur(Constants.BoilingPointH2OInRéaumur).ToNewton().Value, 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToNewtonAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInNewton, Réaumur.ToNewton(Constants.AbsoluteZeroInRéaumur).Value, 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToNewtonMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInNewton, Réaumur.ToNewton(Constants.MeltingPointH2OInRéaumur).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToNewtonBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInNewton, Réaumur.ToNewton(Constants.BoilingPointH2OInRéaumur).Value);
            }
        }

        [TestClass]
        public class ToRéaumurTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void ValidIConversionToRéaumurPassedTest()
            {
                var celsius = new Celsius(Constants.AbsoluteZeroInCelsius);
                var kelvin = new Kelvin(Constants.AbsoluteZeroInKelvin);
                var fahrenheit = new Fahrenheit(Constants.AbsoluteZeroInFahrenheit);
                var rankine = new Rankine(Constants.AbsoluteZeroInRankine);
                var delisle = new Delisle(Constants.AbsoluteZeroInDelisle);
                var newton = new Newton(Constants.AbsoluteZeroInNewton);
                var réaumur = new Réaumur(Constants.AbsoluteZeroInRéaumur);
                var rømer = new Rømer(Constants.AbsoluteZeroInRømer);
                Assert.AreEqual(Constants.AbsoluteZeroInRéaumur, Réaumur.ToRéaumur(kelvin).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRéaumur, Réaumur.ToRéaumur(celsius).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRéaumur, Réaumur.ToRéaumur(fahrenheit).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRéaumur, Réaumur.ToRéaumur(rankine).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRéaumur, Réaumur.ToRéaumur(delisle).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRéaumur, Réaumur.ToRéaumur(newton).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRéaumur, Réaumur.ToRéaumur(réaumur).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRéaumur, Réaumur.ToRéaumur(rømer).Value);
            }
        }

        [TestClass]
        public class ToRømerTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void RéaumurToRømerTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Rømer(Converter.Réau2Røm(temp1)), new Réaumur(temp1).ToRømer());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToRømerTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInRømer, new Réaumur(Constants.AbsoluteZeroInRéaumur).ToRømer().Value);
                Assert.AreEqual(expected: Constants.MeltingPointH2OInRømer, new Réaumur(Constants.MeltingPointH2OInRéaumur).ToRømer().Value);
                Assert.AreEqual(expected: Constants.BoilingPointH2OInRømer, new Réaumur(Constants.BoilingPointH2OInRéaumur).ToRømer().Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRømerAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInRømer, Réaumur.ToRømer(Constants.AbsoluteZeroInRéaumur).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRømerMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInRømer, Réaumur.ToRømer(Constants.MeltingPointH2OInRéaumur).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRømerBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInRømer, Réaumur.ToRømer(Constants.BoilingPointH2OInRéaumur).Value);
            }
        }

        [TestClass]
        public class RegexPatternsTests : Réaumur
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void SetupNewUnitsTest()
            {
                var réaumur = new RegexPatternsTests { RegexPatterns = new[] { "Ré" } };
                // Alternative would be protected internal setter.

                Assert.AreEqual(réaumur.RegexPatterns[0], "Ré");
            }
        }

        [TestClass]
        public class ToStringTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void DegreeRéaumurTest()
            {
                var réaumur = new Fahrenheit(Constants.MeltingPointH2OInKelvin);

                Assert.AreEqual($"{réaumur.Value} °{réaumur.RegexPatterns[0]}", réaumur.ToString());
            }
        }

        [TestClass]
        public class RéaumurComplexOperationTests
        {
            [TestCategory(TestCategory.IntegrationTests)]
            [TestMethod]
            public void DemoTest()
            {
                // Unit creation
                var réaumur = new Réaumur(Constants.MeltingPointH2OInRéaumur);
                Assert.AreEqual(Constants.MeltingPointH2OInRéaumur, réaumur.Value);

                réaumur = new Réaumur("50.8 °Ré");
                Assert.AreEqual(new Réaumur(50.8), réaumur);

                réaumur = new Réaumur("0 K");
                Assert.AreEqual(new Kelvin(Constants.AbsoluteZeroInKelvin), réaumur);


                var fahrenheit = new Fahrenheit(Constants.MeltingPointH2OInFahrenheit);
                var réaumur2 = new Réaumur(fahrenheit);
                Assert.AreEqual(fahrenheit, réaumur2);


                // Arithmetic
                var réaumur3 = réaumur + réaumur2;
                Assert.AreEqual(Constants.AbsoluteZeroInRéaumur, réaumur3.Value);
                var réaumur4 = réaumur + fahrenheit;
                Assert.AreEqual(Constants.AbsoluteZeroInRéaumur, réaumur4.Value);
                réaumur3 = réaumur2 - réaumur;
                Assert.AreEqual(-Constants.AbsoluteZeroInRéaumur, réaumur3.Value);
                réaumur4 = réaumur2 - fahrenheit;
                Assert.AreEqual(Constants.MeltingPointH2OInRéaumur, réaumur4.Value);

                réaumur3.Value = 20;
                réaumur4.Value = 30;

                réaumur3 += réaumur4;
                Assert.AreEqual(50, réaumur3.Value);
                réaumur3 -= réaumur4;
                Assert.AreEqual(20, réaumur3.Value);

                // OOP Conversion
                réaumur = new Réaumur(fahrenheit.ToRéaumur());
                Assert.AreEqual(réaumur, fahrenheit);
                réaumur = Réaumur.ToRéaumur(fahrenheit);
                Assert.AreEqual(fahrenheit, réaumur);

                double someTemperatureInRéaumur = Converter.Ran2Réau(Constants.BoilingPointH2OInRankine);
                double newValueInKelvin = Réaumur.ToKelvin(someTemperatureInRéaumur).Value;
                Assert.AreEqual(someTemperatureInRéaumur, Converter.Kel2Réau(newValueInKelvin), OperationOverDoublePrecision.HighPrecision);

                // Comparison
                réaumur.Value = 20;
                réaumur2.Value = 20;

                Assert.AreEqual(réaumur, réaumur2);

                réaumur = new Réaumur(Constants.AbsoluteZeroInRéaumur);
                fahrenheit = new Fahrenheit(Constants.AbsoluteZeroInFahrenheit);

                Assert.AreEqual(réaumur, fahrenheit);
            }
        }
    }
}
