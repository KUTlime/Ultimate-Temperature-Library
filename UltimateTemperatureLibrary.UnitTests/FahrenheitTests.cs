using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UltimateTemperatureLibrary.Interfaces;
using UltimateTemperatureLibrary.Utils;

namespace UltimateTemperatureLibrary.UnitTests
{
    public class FahrenheitTests
    {
        [TestClass]
        public class FahrenheitConstructorsTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void AbsoluteZeroEmptyConstructorTest()
            {
                var fahrenheit = new Fahrenheit();

                Assert.AreEqual(Constants.AbsoluteZeroInFahrenheit, fahrenheit.Value, Double.Epsilon);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void OutOfRangeEmptyConstructorTest()
            {
                var fahrenheit = new Fahrenheit { Value = -500 };
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void InRangeEmptyConstructorTest()
            {
                var fahrenheit = new Fahrenheit { Value = 500 };
                Assert.AreEqual(500, fahrenheit.Value, Double.Epsilon);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void OutOfRangeDoubleConstructorTest()
            {
                var fahrenheit = new Fahrenheit(-500);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void NullAsStringPassedToConstructorTest()
            {
                var fahrenheit = new Fahrenheit((string)null);
                Assert.AreEqual(Constants.AbsoluteZeroInFahrenheit, fahrenheit.Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void NullAsUnitPassedToConstructorTest()
            {
                var fahrenheit = new Fahrenheit((IConversionToFahrenheit)null);
                Assert.AreEqual(Constants.AbsoluteZeroInFahrenheit, fahrenheit.Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void OutOfRangeStringConstructorTest()
            {
                var fahrenheit = new Fahrenheit("-500");
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            [ExpectedException(typeof(FormatException))]
            public void NoValueStringConstructorTest()
            {
                var fahrenheit = new Fahrenheit(" K");
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromKelvinTest()
            {
                var kelvin = new Kelvin(100.0);
                Assert.AreEqual(kelvin.ToFahrenheit(), new Fahrenheit(kelvin));
            }

            [TestCategory(TestCategory.IntegrationTests)]
            [TestMethod]
            public void FromOtherUnitsAsStringTest()
            {
                Assert.AreEqual(new Kelvin(100), new Fahrenheit("100 K"));
                Assert.AreEqual(new Celsius(100), new Celsius("100 °C"));
                Assert.AreEqual(new Fahrenheit(100), new Fahrenheit("100 °F"));
                Assert.AreEqual(new Rankine(100), new Fahrenheit("100 °R"));
                Assert.AreEqual(new Delisle(100), new Fahrenheit("100 °D"));
                Assert.AreEqual(new Newton(100), new Fahrenheit("100 °N"));
                Assert.AreEqual(new Réaumur(100), new Fahrenheit("100 Ré"));
                Assert.AreEqual(new Rømer(100), new Fahrenheit("100 Rø"));
            }
        }

        [TestClass]
        public class FahrenheitAdditionOperatorTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FahrenheitAddFahrenheitFromFahrenheitTest()
            {
                double temp1 = 20;
                double temp2 = 30;
                var fahrenheit = new Fahrenheit(temp1);
                var fahrenheit2 = new Fahrenheit(temp2);

                Assert.AreEqual(expected: new Fahrenheit(temp1 + temp2), fahrenheit + fahrenheit2);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FahrenheitAddFahrenheitFromValuesTest()
            {
                double temp1 = 20;
                double temp2 = 30;
                var fahrenheit = new Fahrenheit(temp1);
                var fahrenheit2 = new Fahrenheit(temp2);

                Assert.AreEqual(fahrenheit.Value + fahrenheit2.Value, new Fahrenheit(temp1 + temp2).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FahrenheitAddNullTest()
            {
                double temp1 = 20;
                var fahrenheit = new Fahrenheit(temp1);

                Assert.AreEqual(fahrenheit.Value, (fahrenheit + null).Value);
            }
        }

        [TestClass]
        public class FahrenheitSubtractionOperatorTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FahrenheitSubtractionFahrenheitFromFahrenheitTest()
            {
                double temp1 = 20;
                double temp2 = 30;
                var fahrenheit = new Fahrenheit(temp1);
                var fahrenheit2 = new Fahrenheit(temp2);

                Assert.AreEqual(expected: new Fahrenheit(temp1 - temp2), fahrenheit - fahrenheit2);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FahrenheitSubtractionFahrenheitFromFromTest()
            {
                double temp1 = 20;
                double temp2 = 30;
                var fahrenheit = new Fahrenheit(temp1);
                var fahrenheit2 = new Fahrenheit(temp2);

                Assert.AreEqual(fahrenheit.Value - fahrenheit2.Value, new Fahrenheit(temp1 - temp2).Value);
            }
        }

        [TestClass]
        public class ToKelvinTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FahrenheitToKelvinTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Kelvin(Converter.Fah2Kel(temp1)), new Fahrenheit(temp1).ToKelvin());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToKelvinTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInKelvin, new Fahrenheit(Constants.AbsoluteZeroInFahrenheit).ToKelvin().Value);
                Assert.AreEqual(expected: Constants.MeltingPointH2OInKelvin, new Fahrenheit(Constants.MeltingPointH2OInFahrenheit).ToKelvin().Value);
                Assert.AreEqual(expected: Constants.BoilingPointH2OInKelvin, new Fahrenheit(Constants.BoilingPointH2OInFahrenheit).ToKelvin().Value, OperationOverDoublePrecision.HighPrecision);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToKelvinAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInKelvin, Fahrenheit.ToKelvin(Constants.AbsoluteZeroInFahrenheit).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToKelvinMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInKelvin, Fahrenheit.ToKelvin(Constants.MeltingPointH2OInFahrenheit).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToKelvinBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInKelvin, Fahrenheit.ToKelvin(Constants.BoilingPointH2OInFahrenheit).Value, OperationOverDoublePrecision.HighPrecision);
            }
        }

        [TestClass]
        public class ToCelsiusTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FahrenheitToCelsiusTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Celsius(Converter.Fah2Cel(temp1)), new Fahrenheit(temp1).ToCelsius());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToCelsiusTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInCelsius, new Fahrenheit(Constants.AbsoluteZeroInFahrenheit).ToCelsius().Value);
                Assert.AreEqual(expected: Constants.MeltingPointH2OInCelsius, new Fahrenheit(Constants.MeltingPointH2OInFahrenheit).ToCelsius().Value);
                Assert.AreEqual(expected: Constants.BoilingPointH2OInCelsius, new Fahrenheit(Constants.BoilingPointH2OInFahrenheit).ToCelsius().Value, OperationOverDoublePrecision.HighPrecision);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToCelsiusAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInCelsius, Fahrenheit.ToCelsius(Constants.AbsoluteZeroInFahrenheit).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToCelsiusMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInCelsius, Fahrenheit.ToCelsius(Constants.MeltingPointH2OInFahrenheit).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToCelsiusBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInCelsius, Fahrenheit.ToCelsius(Constants.BoilingPointH2OInFahrenheit).Value, OperationOverDoublePrecision.HighPrecision);
            }
        }

        [TestClass]
        public class ToFahrenheitTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void ValidIConversionToFahrenheitPassedTest()
            {
                var celsius = new Celsius(Constants.AbsoluteZeroInCelsius);
                var kelvin = new Kelvin(Constants.AbsoluteZeroInKelvin);
                var fahrenheit = new Fahrenheit(Constants.AbsoluteZeroInFahrenheit);
                var rankine = new Rankine(Constants.AbsoluteZeroInRankine);
                var delisle = new Delisle(Constants.AbsoluteZeroInDelisle);
                var newton = new Newton(Constants.AbsoluteZeroInNewton);
                var réaumur = new Réaumur(Constants.AbsoluteZeroInRéaumur);
                var rømer = new Rømer(Constants.AbsoluteZeroInRømer);
                Assert.AreEqual(Constants.AbsoluteZeroInFahrenheit, Fahrenheit.ToFahrenheit(kelvin).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInFahrenheit, Fahrenheit.ToFahrenheit(celsius).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInFahrenheit, Fahrenheit.ToFahrenheit(fahrenheit).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInFahrenheit, Fahrenheit.ToFahrenheit(rankine).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInFahrenheit, Fahrenheit.ToFahrenheit(delisle).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInFahrenheit, Fahrenheit.ToFahrenheit(newton).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInFahrenheit, Fahrenheit.ToFahrenheit(réaumur).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInFahrenheit, Fahrenheit.ToFahrenheit(rømer).Value);
            }
        }

        [TestClass]
        public class ToRankineTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FahrenheitToRankineTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Rankine(Converter.Fah2Ran(temp1)), new Fahrenheit(temp1).ToRankine());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToRankineTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInRankine, new Fahrenheit(Constants.AbsoluteZeroInFahrenheit).ToRankine().Value);
                Assert.AreEqual(expected: Constants.MeltingPointH2OInRankine, new Fahrenheit(Constants.MeltingPointH2OInFahrenheit).ToRankine().Value, OperationOverDoublePrecision.MiddlePrecision);
                Assert.AreEqual(expected: Constants.BoilingPointH2OInRankine, new Fahrenheit(Constants.BoilingPointH2OInFahrenheit).ToRankine().Value, OperationOverDoublePrecision.MiddlePrecision);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRankineAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInRankine, Fahrenheit.ToRankine(Constants.AbsoluteZeroInFahrenheit).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRankineMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInRankine, Fahrenheit.ToRankine(Constants.MeltingPointH2OInFahrenheit).Value, 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRankineBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInRankine, Fahrenheit.ToRankine(Constants.BoilingPointH2OInFahrenheit).Value, OperationOverDoublePrecision.MiddlePrecision);
            }
        }

        [TestClass]
        public class ToDelisleTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FahrenheitToDelisleTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Delisle(Converter.Fah2Del(temp1)), new Fahrenheit(temp1).ToDelisle());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToDelisleTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInDelisle, new Fahrenheit(Constants.AbsoluteZeroInFahrenheit).ToDelisle().Value, 1e-12);
                Assert.AreEqual(expected: Constants.MeltingPointH2OInDelisle, new Fahrenheit(Constants.MeltingPointH2OInFahrenheit).ToDelisle().Value, 1e-12);
                Assert.AreEqual(expected: Constants.BoilingPointH2OInDelisle, new Fahrenheit(Constants.BoilingPointH2OInFahrenheit).ToDelisle().Value, 1e-12);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToDelisleAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInDelisle, Fahrenheit.ToDelisle(Constants.AbsoluteZeroInFahrenheit).Value, 1e-12);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToDelisleMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInDelisle, Fahrenheit.ToDelisle(Constants.MeltingPointH2OInFahrenheit).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToDelisleBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInDelisle, Fahrenheit.ToDelisle(Constants.BoilingPointH2OInFahrenheit).Value, OperationOverDoublePrecision.HighPrecision);
            }
        }

        [TestClass]
        public class ToNewtonTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FahrenheitToNewtonTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Newton(Converter.Fah2New(temp1)), new Fahrenheit(temp1).ToNewton());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToNewtonTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInNewton, new Fahrenheit(Constants.AbsoluteZeroInFahrenheit).ToNewton().Value, 1e-13);
                Assert.AreEqual(expected: Constants.MeltingPointH2OInNewton, new Fahrenheit(Constants.MeltingPointH2OInFahrenheit).ToNewton().Value, 1e-13);
                Assert.AreEqual(expected: Constants.BoilingPointH2OInNewton, new Fahrenheit(Constants.BoilingPointH2OInFahrenheit).ToNewton().Value, 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToNewtonAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInNewton, Fahrenheit.ToNewton(Constants.AbsoluteZeroInFahrenheit).Value, 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToNewtonMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInNewton, Fahrenheit.ToNewton(Constants.MeltingPointH2OInFahrenheit).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToNewtonBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInNewton, Fahrenheit.ToNewton(Constants.BoilingPointH2OInFahrenheit).Value, OperationOverDoublePrecision.HighPrecision);
            }
        }

        [TestClass]
        public class ToRéaumurTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FahrenheitToRéaumurTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Réaumur(Converter.Fah2Réau(temp1)), new Fahrenheit(temp1).ToRéaumur());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToRéaumurTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInRéaumur, new Fahrenheit(Constants.AbsoluteZeroInFahrenheit).ToRéaumur().Value, 1e-13);
                Assert.AreEqual(expected: Constants.MeltingPointH2OInRéaumur, new Fahrenheit(Constants.MeltingPointH2OInFahrenheit).ToRéaumur().Value, 1e-13);
                Assert.AreEqual(expected: Constants.BoilingPointH2OInRéaumur, new Fahrenheit(Constants.BoilingPointH2OInFahrenheit).ToRéaumur().Value, 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRéaumurAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInRéaumur, Fahrenheit.ToRéaumur(Constants.AbsoluteZeroInFahrenheit).Value, 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRéaumurMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInRéaumur, Fahrenheit.ToRéaumur(Constants.MeltingPointH2OInFahrenheit).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRéaumurBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInRéaumur, Fahrenheit.ToRéaumur(Constants.BoilingPointH2OInFahrenheit).Value, OperationOverDoublePrecision.HighPrecision);
            }
        }

        [TestClass]
        public class ToRømerTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FahrenheitToRømerTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Rømer(Converter.Fah2Røm(temp1)), new Fahrenheit(temp1).ToRømer());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToRømerTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInRømer, new Fahrenheit(Constants.AbsoluteZeroInFahrenheit).ToRømer().Value);
                Assert.AreEqual(expected: Constants.MeltingPointH2OInRømer, new Fahrenheit(Constants.MeltingPointH2OInFahrenheit).ToRømer().Value);
                Assert.AreEqual(expected: Constants.BoilingPointH2OInRømer, new Fahrenheit(Constants.BoilingPointH2OInFahrenheit).ToRømer().Value, OperationOverDoublePrecision.HighPrecision);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRømerAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInRømer, Fahrenheit.ToRømer(Constants.AbsoluteZeroInFahrenheit).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRømerMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInRømer, Fahrenheit.ToRømer(Constants.MeltingPointH2OInFahrenheit).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRømerBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInRømer, Fahrenheit.ToRømer(Constants.BoilingPointH2OInFahrenheit).Value, OperationOverDoublePrecision.HighPrecision);
            }
        }

        [TestClass]
        public class RegexPatternsTests : Fahrenheit
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void SetupNewUnitsTest()
            {
                var fahrenheit = new RegexPatternsTests { RegexPatterns = new[] { "F" } };
                // Alternative would be protected internal setter.

                Assert.AreEqual(fahrenheit.RegexPatterns[0], "F");
            }
        }

        [TestClass]
        public class ToStringTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void DegreeFahrenheitTest()
            {
                var fahrenheit = new Fahrenheit(Constants.MeltingPointH2OInKelvin);

                Assert.AreEqual($"{fahrenheit.Value} °{fahrenheit.RegexPatterns[0]}", fahrenheit.ToString());
            }
        }

        [TestClass]
        public class FahrenheitComplexOperationTests
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


                var fahrenheit = new Fahrenheit(Constants.MeltingPointH2OInFahrenheit);
                var kelvin2 = new Kelvin(fahrenheit);
                Assert.AreEqual(fahrenheit, kelvin2);


                // Arithmetic
                var kelvin3 = kelvin + kelvin2;
                Assert.AreEqual(Constants.MeltingPointH2OInKelvin, kelvin3.Value);
                var kelvin4 = kelvin + fahrenheit;
                Assert.AreEqual(Constants.MeltingPointH2OInKelvin, kelvin4.Value);
                kelvin3 = kelvin2 - kelvin;
                Assert.AreEqual(Constants.MeltingPointH2OInKelvin, kelvin3.Value);
                kelvin4 = kelvin2 - fahrenheit;
                Assert.AreEqual(Constants.AbsoluteZeroInKelvin, kelvin4.Value);

                kelvin3.Value = 20;
                kelvin4.Value = 30;

                kelvin3 += kelvin4;
                Assert.AreEqual(50, kelvin3.Value);
                kelvin3 -= kelvin4;
                Assert.AreEqual(20, kelvin3.Value);

                // OOP Conversion
                var celsius = new Celsius(fahrenheit.ToCelsius());
                Assert.AreEqual(celsius, fahrenheit);
                kelvin = Kelvin.ToKelvin(fahrenheit);
                Assert.AreEqual(fahrenheit, kelvin);

                double someTemperatureValueInFahrenheit = Converter.Ran2Fah(Constants.BoilingPointH2OInRankine);
                double newValueInKelvin = Fahrenheit.ToKelvin(someTemperatureValueInFahrenheit).Value;
                Assert.AreEqual(someTemperatureValueInFahrenheit, Converter.Kel2Fah(newValueInKelvin),
                    OperationOverDoublePrecision.HighPrecision);

                // Comparison
                kelvin.Value = 20;
                kelvin2.Value = 20;

                Assert.AreEqual(kelvin, kelvin2);

                kelvin = new Kelvin(Constants.AbsoluteZeroInKelvin);
                fahrenheit = new Fahrenheit(Constants.AbsoluteZeroInFahrenheit);

                Assert.AreEqual(kelvin, fahrenheit);
            }
        }
    }
}
