using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UltimateTemperatureLibrary.Interfaces;
using UltimateTemperatureLibrary.Utils;

namespace UltimateTemperatureLibrary.UnitTests
{
    public class NewtonTests
    {
        [TestClass]
        public class NewtonConstructorsTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void AbsoluteZeroEmptyConstructorTest()
            {
                var newton = new Newton();

                Assert.AreEqual(Constants.AbsoluteZeroInNewton, newton.Value, Double.Epsilon);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void OutOfRangeEmptyConstructorTest()
            {
                var newton = new Newton { Value = -500 };
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void InRangeEmptyConstructorTest()
            {
                var newton = new Newton { Value = 500 };
                Assert.AreEqual(500, newton.Value, Double.Epsilon);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void OutOfRangeDoubleConstructorTest()
            {
                var newton = new Newton(-500);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void NullAsStringPassedToConstructorTest()
            {
                var newton = new Newton((string)null);
                Assert.AreEqual(Constants.AbsoluteZeroInNewton, newton.Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void NullAsUnitPassedToConstructorTest()
            {
                var newton = new Newton((IConversionToNewton)null);
                Assert.AreEqual(Constants.AbsoluteZeroInNewton, newton.Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void OutOfRangeStringConstructorTest()
            {
                var newton = new Newton("-500");
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            [ExpectedException(typeof(FormatException))]
            public void NoValueStringConstructorTest()
            {
                var newton = new Newton(" K");
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromKelvinTest()
            {
                var kelvin = new Kelvin(100.0);
                Assert.AreEqual(kelvin.ToNewton(), new Newton(kelvin));
            }

            [TestCategory(TestCategory.IntegrationTests)]
            [TestMethod]
            public void FromOtherUnitsAsStringTest()
            {
                Assert.AreEqual(new Kelvin(100), new Newton("100 K"));
                Assert.AreEqual(new Celsius(100), new Celsius("100 °C"));
                Assert.AreEqual(new Fahrenheit(100), new Newton("100 °F"));
                Assert.AreEqual(new Rankine(100), new Newton("100 °R"));
                Assert.AreEqual(new Delisle(100), new Newton("100 °D"));
                Assert.AreEqual(new Newton(100), new Newton("100 °N"));
                Assert.AreEqual(new Réaumur(100), new Newton("100 Ré"));
                Assert.AreEqual(new Rømer(100), new Newton("100 Rø"));
            }
        }

        [TestClass]
        public class NewtonAdditionOperatorTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void NewtonAddNewtonFromNewtonTest()
            {
                double temp1 = 20;
                double temp2 = 30;
                var newton = new Newton(temp1);
                var newton2 = new Newton(temp2);

                Assert.AreEqual(expected: new Newton(temp1 + temp2), newton + newton2);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void NewtonAddNewtonFromValuesTest()
            {
                double temp1 = 20;
                double temp2 = 30;
                var newton = new Newton(temp1);
                var newton2 = new Newton(temp2);

                Assert.AreEqual(newton.Value + newton2.Value, new Newton(temp1 + temp2).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void NewtonAddNullTest()
            {
                double temp1 = 20;
                var newton = new Newton(temp1);

                Assert.AreEqual(newton.Value, (newton + null).Value);
            }
        }

        [TestClass]
        public class NewtonSubtractionOperatorTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void NewtonSubtractionNewtonFromNewtonTest()
            {
                double temp1 = 20;
                double temp2 = 30;
                var newton = new Newton(temp1);
                var newton2 = new Newton(temp2);

                Assert.AreEqual(expected: new Newton(temp1 - temp2), newton - newton2);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void NewtonSubtractionNewtonFromFromTest()
            {
                double temp1 = 20;
                double temp2 = 30;
                var newton = new Newton(temp1);
                var newton2 = new Newton(temp2);

                Assert.AreEqual(newton.Value - newton2.Value, new Newton(temp1 - temp2).Value);
            }
        }

        [TestClass]
        public class ToKelvinTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void NewtonToKelvinTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Kelvin(Converter.New2Kel(temp1)), new Newton(temp1).ToKelvin());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToKelvinTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInKelvin, new Newton(Constants.AbsoluteZeroInNewton).ToKelvin().Value);
                Assert.AreEqual(expected: Constants.MeltingPointH2OInKelvin, new Newton(Constants.MeltingPointH2OInNewton).ToKelvin().Value);
                Assert.AreEqual(expected: Constants.BoilingPointH2OInKelvin, new Newton(Constants.BoilingPointH2OInNewton).ToKelvin().Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToKelvinAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInKelvin, Newton.ToKelvin(Constants.AbsoluteZeroInNewton).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToKelvinMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInKelvin, Newton.ToKelvin(Constants.MeltingPointH2OInNewton).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToKelvinBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInKelvin, Newton.ToKelvin(Constants.BoilingPointH2OInNewton).Value);
            }
        }

        [TestClass]
        public class ToCelsiusTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void NewtonToCelsiusTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Celsius(Converter.New2Cel(temp1)), new Newton(temp1).ToCelsius());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToCelsiusTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInCelsius, new Newton(Constants.AbsoluteZeroInNewton).ToCelsius().Value);
                Assert.AreEqual(expected: Constants.MeltingPointH2OInCelsius, new Newton(Constants.MeltingPointH2OInNewton).ToCelsius().Value);
                Assert.AreEqual(expected: Constants.BoilingPointH2OInCelsius, new Newton(Constants.BoilingPointH2OInNewton).ToCelsius().Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToCelsiusAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInCelsius, Newton.ToCelsius(Constants.AbsoluteZeroInNewton).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToCelsiusMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInCelsius, Newton.ToCelsius(Constants.MeltingPointH2OInNewton).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToCelsiusBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInCelsius, Newton.ToCelsius(Constants.BoilingPointH2OInNewton).Value);
            }
        }

        [TestClass]
        public class ToFahrenheitTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void NewtonToFahrenheitTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Fahrenheit(Converter.New2Fah(temp1)), new Newton(temp1).ToFahrenheit());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToFahrenheitTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInFahrenheit, new Newton(Constants.AbsoluteZeroInNewton).ToFahrenheit().Value);
                Assert.AreEqual(expected: Constants.MeltingPointH2OInFahrenheit, new Newton(Constants.MeltingPointH2OInNewton).ToFahrenheit().Value, 1e-13);
                Assert.AreEqual(expected: Constants.BoilingPointH2OInFahrenheit, new Newton(Constants.BoilingPointH2OInNewton).ToFahrenheit().Value, 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToFahrenheitAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInFahrenheit, Newton.ToFahrenheit(Constants.AbsoluteZeroInNewton).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToFahrenheitMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInFahrenheit, Newton.ToFahrenheit(Constants.MeltingPointH2OInNewton).Value, 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToFahrenheitBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInFahrenheit, Newton.ToFahrenheit(Constants.BoilingPointH2OInNewton).Value, 1e-13);
            }
        }

        [TestClass]
        public class ToRankineTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void NewtonToRankineTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Rankine(Converter.New2Ran(temp1)), new Newton(temp1).ToRankine());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToRankineTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInRankine, new Newton(Constants.AbsoluteZeroInNewton).ToRankine().Value);
                Assert.AreEqual(expected: Constants.MeltingPointH2OInRankine, new Newton(Constants.MeltingPointH2OInNewton).ToRankine().Value, 1e-13);
                Assert.AreEqual(expected: Constants.BoilingPointH2OInRankine, new Newton(Constants.BoilingPointH2OInNewton).ToRankine().Value, 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRankineAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInRankine, Newton.ToRankine(Constants.AbsoluteZeroInNewton).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRankineMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInRankine, Newton.ToRankine(Constants.MeltingPointH2OInNewton).Value, 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRankineBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInRankine, Newton.ToRankine(Constants.BoilingPointH2OInNewton).Value);
            }
        }

        [TestClass]
        public class ToDelisleTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void NewtonToDelisleTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Delisle(Converter.New2Del(temp1)), new Newton(temp1).ToDelisle());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToDelisleTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInDelisle, new Newton(Constants.AbsoluteZeroInNewton).ToDelisle().Value, 1e-12);
                Assert.AreEqual(expected: Constants.MeltingPointH2OInDelisle, new Newton(Constants.MeltingPointH2OInNewton).ToDelisle().Value, 1e-12);
                Assert.AreEqual(expected: Constants.BoilingPointH2OInDelisle, new Newton(Constants.BoilingPointH2OInNewton).ToDelisle().Value, 1e-12);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToDelisleAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInDelisle, Newton.ToDelisle(Constants.AbsoluteZeroInNewton).Value, 1e-12);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToDelisleMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInDelisle, Newton.ToDelisle(Constants.MeltingPointH2OInNewton).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToDelisleBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInDelisle, Newton.ToDelisle(Constants.BoilingPointH2OInNewton).Value);
            }
        }

        [TestClass]
        public class ToNewtonTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void ValidIConversionToNewtonPassedTest()
            {
                var celsius = new Celsius(Constants.AbsoluteZeroInCelsius);
                var kelvin = new Kelvin(Constants.AbsoluteZeroInKelvin);
                var fahrenheit = new Fahrenheit(Constants.AbsoluteZeroInFahrenheit);
                var rankine = new Rankine(Constants.AbsoluteZeroInRankine);
                var delisle = new Delisle(Constants.AbsoluteZeroInDelisle);
                var newton = new Newton(Constants.AbsoluteZeroInNewton);
                var réaumur = new Réaumur(Constants.AbsoluteZeroInRéaumur);
                var rømer = new Rømer(Constants.AbsoluteZeroInRømer);
                Assert.AreEqual(Constants.AbsoluteZeroInNewton, Newton.ToNewton(kelvin).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInNewton, Newton.ToNewton(celsius).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInNewton, Newton.ToNewton(fahrenheit).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInNewton, Newton.ToNewton(rankine).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInNewton, Newton.ToNewton(delisle).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInNewton, Newton.ToNewton(newton).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInNewton, Newton.ToNewton(réaumur).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInNewton, Newton.ToNewton(rømer).Value);
            }
        }

        [TestClass]
        public class ToRéaumurTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void NewtonToRéaumurTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Réaumur(Converter.New2Réau(temp1)), new Newton(temp1).ToRéaumur());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToRéaumurTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInRéaumur, new Newton(Constants.AbsoluteZeroInNewton).ToRéaumur().Value, 1e-13);
                Assert.AreEqual(expected: Constants.MeltingPointH2OInRéaumur, new Newton(Constants.MeltingPointH2OInNewton).ToRéaumur().Value, 1e-13);
                Assert.AreEqual(expected: Constants.BoilingPointH2OInRéaumur, new Newton(Constants.BoilingPointH2OInNewton).ToRéaumur().Value, 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRéaumurAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInRéaumur, Newton.ToRéaumur(Constants.AbsoluteZeroInNewton).Value, 1e-13);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRéaumurMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInRéaumur, Newton.ToRéaumur(Constants.MeltingPointH2OInNewton).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRéaumurBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInRéaumur, Newton.ToRéaumur(Constants.BoilingPointH2OInNewton).Value);
            }
        }

        [TestClass]
        public class ToRømerTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void NewtonToRømerTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Rømer(Converter.New2Røm(temp1)), new Newton(temp1).ToRømer());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToRømerTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInRømer, new Newton(Constants.AbsoluteZeroInNewton).ToRømer().Value);
                Assert.AreEqual(expected: Constants.MeltingPointH2OInRømer, new Newton(Constants.MeltingPointH2OInNewton).ToRømer().Value);
                Assert.AreEqual(expected: Constants.BoilingPointH2OInRømer, new Newton(Constants.BoilingPointH2OInNewton).ToRømer().Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRømerAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInRømer, Newton.ToRømer(Constants.AbsoluteZeroInNewton).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRømerMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInRømer, Newton.ToRømer(Constants.MeltingPointH2OInNewton).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRømerBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInRømer, Newton.ToRømer(Constants.BoilingPointH2OInNewton).Value);
            }
        }

        [TestClass]
        public class RegexPatternsTests : Newton
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void SetupNewUnitsTest()
            {
                var newton = new RegexPatternsTests { RegexPatterns = new[] { "N" } };
                // Alternative would be protected internal setter.

                Assert.AreEqual(newton.RegexPatterns[0], "N");
            }
        }

        [TestClass]
        public class ToStringTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void DegreeNewtonTest()
            {
                var newton = new Fahrenheit(Constants.MeltingPointH2OInKelvin);

                Assert.AreEqual($"{newton.Value} °{newton.RegexPatterns[0]}", newton.ToString());
            }
        }

        [TestClass]
        public class NewtonComplexOperationTests
        {
            [TestCategory(TestCategory.IntegrationTests)]
            [TestMethod]
            public void DemoTest()
            {
                // Unit creation
                var newton = new Newton(Constants.MeltingPointH2OInNewton);
                Assert.AreEqual(Constants.MeltingPointH2OInNewton, newton.Value);

                newton = new Newton("50.8 °N");
                Assert.AreEqual(new Newton(50.8), newton);

                newton = new Newton("0 K");
                Assert.AreEqual(new Kelvin(Constants.AbsoluteZeroInKelvin), newton);


                var fahrenheit = new Fahrenheit(Constants.MeltingPointH2OInFahrenheit);
                var newton2 = new Newton(fahrenheit);
                Assert.AreEqual(fahrenheit, newton2);


                // Arithmetic
                var newton3 = newton + newton2;
                Assert.AreEqual(Constants.AbsoluteZeroInNewton, newton3.Value);
                var newton4 = newton + fahrenheit;
                Assert.AreEqual(Constants.AbsoluteZeroInNewton, newton4.Value);
                newton3 = newton2 - newton;
                Assert.AreEqual(-Constants.AbsoluteZeroInNewton, newton3.Value);
                newton4 = newton2 - fahrenheit;
                Assert.AreEqual(Constants.MeltingPointH2OInNewton, newton4.Value);

                newton3.Value = 20;
                newton4.Value = 30;

                newton3 += newton4;
                Assert.AreEqual(50, newton3.Value);
                newton3 -= newton4;
                Assert.AreEqual(20, newton3.Value);

                // OOP Conversion
                newton = new Newton(fahrenheit.ToNewton());
                Assert.AreEqual(newton, fahrenheit);
                newton = Newton.ToNewton(fahrenheit);
                Assert.AreEqual(fahrenheit, newton);

                double someTemperatureInNewton = Converter.Ran2New(Constants.BoilingPointH2OInRankine);
                double newValueInKelvin = Newton.ToKelvin(someTemperatureInNewton).Value;
                Assert.AreEqual(someTemperatureInNewton, Converter.Kel2New(newValueInKelvin), OperationOverDoublePrecision.HighPrecision);

                // Comparison
                newton.Value = 20;
                newton2.Value = 20;

                Assert.AreEqual(newton, newton2);

                newton = new Newton(Constants.AbsoluteZeroInNewton);
                fahrenheit = new Fahrenheit(Constants.AbsoluteZeroInFahrenheit);

                Assert.AreEqual(newton, fahrenheit);
            }
        }
    }
}
