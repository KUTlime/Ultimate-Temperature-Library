using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UltimateTemperatureLibrary.Interfaces;

namespace UltimateTemperatureLibrary.UnitTests
{
    public class CelsiusTests
    {
        [TestClass]
        public class CelsiusConstructorsTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void AbsoluteZeroEmptyConstructorTest()
            {
                var celsius = new Celsius();

                Assert.AreEqual(Constants.AbsoluteZeroInCelsius, celsius.Value, Double.Epsilon);
            }


            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void OutOfRangeEmptyConstructorTest()
            {
                var celsius = new Celsius { Value = -500 };
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void InRangeEmptyConstructorTest()
            {
                var celsius = new Celsius { Value = 500 };
                Assert.AreEqual(500, celsius.Value, Double.Epsilon);
            }


            [TestCategory(TestCategory.BasicTests)]
            [DataTestMethod]
            [DataRow((UInt32)1, 0.0, 0.0, DisplayName = "Lower Reference Temperature")]
            [DataRow((UInt32)2, 100, 100.0, DisplayName = "Upper Reference Temperature")]
            [DataRow((UInt32)3, -273.15, Constants.AbsoluteZeroInCelsius, DisplayName = "Absolute zero")]
            [DataRow((UInt32)4, 1000, 1000, DisplayName = "Some big value ")]
            public void DoubleConstructorTests(UInt32 testNumber, double expectedValue, double inputValue)
            {
                var celsius = new Celsius(inputValue);

                Assert.AreEqual(expectedValue, celsius.Value, Double.Epsilon);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void OutOfRangeDoubleConstructorTest()
            {
                var celsius = new Celsius(-500);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void NullAsStringPassedToConstructorTest()
            {
                var celsius = new Celsius((string)null);
                Assert.AreEqual(Constants.AbsoluteZeroInCelsius, celsius.Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void NullAsUnitPassedToConstructorTest()
            {
                var celsius = new Celsius((IConversionToCelsius)null);
                Assert.AreEqual(Constants.AbsoluteZeroInCelsius, celsius.Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void OutOfRangeStringConstructorTest()
            {
                var celsius = new Celsius("-500");
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromKelvinTest()
            {
                var kelvin = new Kelvin(100.0);
                Assert.AreEqual(kelvin.ToCelsius(), new Celsius(kelvin));
            }

            [TestCategory(TestCategory.BasicTests)]
            [DataTestMethod]
            [DataRow((UInt32)1, (double)-251.65, "21.5", (double)1e-13)]
            [DataRow((UInt32)2, (double)-251.65, "21.5 ", (double)1e-13)]
            [DataRow((UInt32)3, (double)-251.65, " 21.5", (double)1e-13)]
            [DataRow((UInt32)4, (double)-251.65, " 21.5  ", (double)1e-13)]
            [DataRow((UInt32)5, (double)21.5, "21.5 °C", (double)1e-13)]
            [DataRow((UInt32)6, (double)21.5, "21.5  °C", (double)1e-13)]
            [DataRow((UInt32)7, (double)21.5, "21.5°C", (double)1e-13)]
            [DataRow((UInt32)8, (double)21.5, "21.5° C", (double)1e-13)]
            [DataRow((UInt32)9, (double)21.5, "21.5°  C", (double)1e-13)]
            [DataRow((UInt32)10, (double)21.5, "21.5 ° C", (double)1e-13)]
            [DataRow((UInt32)11, (double)21.5, "21.5  ° C", (double)1e-13)]
            [DataRow((UInt32)12, (double)21.5, "21.5  °  C", (double)1e-13)]
            [DataRow((UInt32)13, (double)21.5, "21.5°  C", (double)1e-13)]
            [DataRow((UInt32)14, (double)21.5, "21.5 C", (double)1e-13)]
            [DataRow((UInt32)15, (double)21.5, "21.5C", (double)1e-13)]
            [DataRow((UInt32)16, (double)21.5, "21.5  C", (double)1e-13)]
            [DataRow((UInt32)17, (double)21.5, "21.5 °Celsius", (double)1e-13)]
            [DataRow((UInt32)18, (double)21.5, "21.5°Celsius", (double)1e-13)]
            [DataRow((UInt32)19, (double)21.5, "21.5 ° Celsius", (double)1e-13)]
            [DataRow((UInt32)20, (double)21.5, "21.5° Celsius", (double)1e-13)]
            [DataRow((UInt32)21, (double)21.5, "21.5   °Celsius", (double)1e-13)]
            [DataRow((UInt32)22, (double)21.5, "21.5   °   Celsius", (double)1e-13)]
            [DataRow((UInt32)23, (double)21.5, "21.5°   Celsius", (double)1e-13)]
            [DataRow((UInt32)24, (double)21.5, "21.5 °Cel", (double)1e-13)]
            [DataRow((UInt32)25, (double)21.5, "21.5°Cel", (double)1e-13)]
            [DataRow((UInt32)26, (double)21.5, "21.5 ° Cel", (double)1e-13)]
            [DataRow((UInt32)27, (double)21.5, "21.5° Cel", (double)1e-13)]
            [DataRow((UInt32)28, (double)21.5, "21.5   °Cel", (double)1e-13)]
            [DataRow((UInt32)29, (double)21.5, "21.5   °   Cel", (double)1e-13)]
            [DataRow((UInt32)30, (double)21.5, "21.5°   Cel", (double)1e-13)]
            [DataRow((UInt32)31, (double)21.5, " 21.5 °C", (double)1e-13)]
            [DataRow((UInt32)32, (double)21.5, " 21.5  °C", (double)1e-13)]
            [DataRow((UInt32)33, (double)21.5, " 21.5°C", (double)1e-13)]
            [DataRow((UInt32)34, (double)21.5, " 21.5° C", (double)1e-13)]
            [DataRow((UInt32)35, (double)21.5, " 21.5°  C", (double)1e-13)]
            [DataRow((UInt32)36, (double)21.5, " 21.5 ° C", (double)1e-13)]
            [DataRow((UInt32)37, (double)21.5, " 21.5  ° C", (double)1e-13)]
            [DataRow((UInt32)38, (double)21.5, " 21.5  °  C", (double)1e-13)]
            [DataRow((UInt32)39, (double)21.5, " 21.5°  C", (double)1e-13)]
            [DataRow((UInt32)40, (double)21.5, " 21.5 C", (double)1e-13)]
            [DataRow((UInt32)41, (double)21.5, " 21.5C", (double)1e-13)]
            [DataRow((UInt32)42, (double)21.5, " 21.5  C", (double)1e-13)]
            [DataRow((UInt32)43, (double)21.5, " 21.5 °Celsius", (double)1e-13)]
            [DataRow((UInt32)44, (double)21.5, " 21.5°Celsius", (double)1e-13)]
            [DataRow((UInt32)45, (double)21.5, " 21.5 ° Celsius", (double)1e-13)]
            [DataRow((UInt32)46, (double)21.5, " 21.5° Celsius", (double)1e-13)]
            [DataRow((UInt32)47, (double)21.5, " 21.5   °Celsius", (double)1e-13)]
            [DataRow((UInt32)48, (double)21.5, " 21.5   °   Celsius", (double)1e-13)]
            [DataRow((UInt32)49, (double)21.5, " 21.5°   Celsius", (double)1e-13)]
            [DataRow((UInt32)50, (double)21.5, " 21.5 °Cel", (double)1e-13)]
            [DataRow((UInt32)51, (double)21.5, " 21.5°Cel", (double)1e-13)]
            [DataRow((UInt32)52, (double)21.5, " 21.5 ° Cel", (double)1e-13)]
            [DataRow((UInt32)53, (double)21.5, " 21.5° Cel", (double)1e-13)]
            [DataRow((UInt32)54, (double)21.5, " 21.5   °Cel", (double)1e-13)]
            [DataRow((UInt32)55, (double)21.5, " 21.5   °   Cel", (double)1e-13)]
            [DataRow((UInt32)56, (double)21.5, " 21.5°   Cel", (double)1e-13)] // Here is the current end.
            [DataRow((UInt32)57, (double)-251.65, "21.5", (double)1e-13)]
            [DataRow((UInt32)58, (double)-251.65, "21.5 ", (double)1e-13)]
            [DataRow((UInt32)59, (double)-251.65, " 21.5", (double)1e-13)]
            [DataRow((UInt32)60, (double)-251.65, " 21.5  ", (double)1e-13)]
            [DataRow((UInt32)61, (double)21.5, "21.5 °C", (double)1e-13)]
            [DataRow((UInt32)62, (double)21.5, "21.5  °C", (double)1e-13)]
            [DataRow((UInt32)63, (double)21.5, "21.5°C", (double)1e-13)]
            [DataRow((UInt32)64, (double)21.5, "21.5° C", (double)1e-13)]
            [DataRow((UInt32)65, (double)21.5, "21.5°  C", (double)1e-13)]
            [DataRow((UInt32)66, (double)21.5, "21.5 ° C", (double)1e-13)]
            [DataRow((UInt32)67, (double)21.5, "21.5  ° C", (double)1e-13)]
            [DataRow((UInt32)68, (double)21.5, "21.5  °  C", (double)1e-13)]
            [DataRow((UInt32)69, (double)21.5, "21.5°  C", (double)1e-13)]
            [DataRow((UInt32)70, (double)21.5, "21.5 C", (double)1e-13)]
            [DataRow((UInt32)71, (double)21.5, "21.5C", (double)1e-13)]
            [DataRow((UInt32)72, (double)21.5, "21.5  C", (double)1e-13)]
            [DataRow((UInt32)73, (double)21.5, "21.5 °Celsius", (double)1e-13)]
            [DataRow((UInt32)74, (double)21.5, "21.5°Celsius", (double)1e-13)]
            [DataRow((UInt32)75, (double)21.5, "21.5 ° Celsius", (double)1e-13)]
            [DataRow((UInt32)76, (double)21.5, "21.5° Celsius", (double)1e-13)]
            [DataRow((UInt32)77, (double)21.5, "21.5   °Celsius", (double)1e-13)]
            [DataRow((UInt32)78, (double)21.5, "21.5   °   Celsius", (double)1e-13)]
            [DataRow((UInt32)79, (double)21.5, "21.5°   Celsius", (double)1e-13)]
            [DataRow((UInt32)80, (double)21.5, "21.5 °Cel", (double)1e-13)]
            [DataRow((UInt32)81, (double)21.5, "21.5°Cel", (double)1e-13)]
            [DataRow((UInt32)82, (double)21.5, "21.5 ° Cel", (double)1e-13)]
            [DataRow((UInt32)83, (double)21.5, "21.5° Cel", (double)1e-13)]
            [DataRow((UInt32)84, (double)21.5, "21.5   °Cel", (double)1e-13)]
            [DataRow((UInt32)85, (double)21.5, "21.5   °   Cel", (double)1e-13)]
            [DataRow((UInt32)86, (double)21.5, "21.5°   Cel", (double)1e-13)]
            [DataRow((UInt32)87, (double)21.5, " 21.5 °C", (double)1e-13)]
            [DataRow((UInt32)88, (double)21.5, " 21.5  °C", (double)1e-13)]
            [DataRow((UInt32)89, (double)21.5, " 21.5°C", (double)1e-13)]
            [DataRow((UInt32)90, (double)21.5, " 21.5° C", (double)1e-13)]
            [DataRow((UInt32)91, (double)21.5, " 21.5°  C", (double)1e-13)]
            [DataRow((UInt32)92, (double)21.5, " 21.5 ° C", (double)1e-13)]
            [DataRow((UInt32)93, (double)21.5, " 21.5  ° C", (double)1e-13)]
            [DataRow((UInt32)94, (double)21.5, " 21.5  °  C", (double)1e-13)]
            [DataRow((UInt32)95, (double)21.5, " 21.5°  C", (double)1e-13)]
            [DataRow((UInt32)96, (double)21.5, " 21.5 C", (double)1e-13)]
            [DataRow((UInt32)97, (double)21.5, " 21.5C", (double)1e-13)]
            [DataRow((UInt32)98, (double)21.5, " 21.5  C", (double)1e-13)]
            [DataRow((UInt32)99, (double)21.5, " 21.5 °Celsius", (double)1e-13)]
            [DataRow((UInt32)100, (double)21.5, " 21.5°Celsius", (double)1e-13)]
            [DataRow((UInt32)101, (double)21.5, " 21.5 ° Celsius", (double)1e-13)]
            [DataRow((UInt32)102, (double)21.5, " 21.5° Celsius", (double)1e-13)]
            [DataRow((UInt32)103, (double)21.5, " 21.5   °Celsius", (double)1e-13)]
            [DataRow((UInt32)104, (double)21.5, " 21.5   °   Celsius", (double)1e-13)]
            [DataRow((UInt32)105, (double)21.5, " 21.5°   Celsius", (double)1e-13)]
            [DataRow((UInt32)106, (double)21.5, " 21.5 °Cel", (double)1e-13)]
            [DataRow((UInt32)107, (double)21.5, " 21.5°Cel", (double)1e-13)]
            [DataRow((UInt32)108, (double)21.5, " 21.5 ° Cel", (double)1e-13)]
            [DataRow((UInt32)109, (double)21.5, " 21.5° Cel", (double)1e-13)]
            [DataRow((UInt32)110, (double)21.5, " 21.5   °Cel", (double)1e-13)]
            [DataRow((UInt32)111, (double)21.5, " 21.5   °   Cel", (double)1e-13)]
            [DataRow((UInt32)112, (double)21.5, " 21.5°   Cel", (double)1e-13)]
            public void StringParsingConstructorTests(UInt32 testNumber, double expectedTemp, string value, double delta)
            {
                var celsius = new Celsius(value);
                Assert.AreEqual(expectedTemp, celsius.Value, delta);
            }


        }

        [TestClass]
        public class CelsiusAdditionOperatorTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void CelsiusAddCelsiusFromCelsiusTest()
            {
                double temp1 = 20;
                double temp2 = 30;
                var celsius = new Celsius(temp1);
                var celsius2 = new Celsius(temp2);

                Assert.AreEqual(expected: new Celsius(temp1 + temp2), celsius + celsius2);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void CelsiusAddCelsiusFromFromTest()
            {
                double temp1 = 20;
                double temp2 = 30;
                var celsius = new Celsius(temp1);
                var celsius2 = new Celsius(temp2);

                Assert.AreEqual(celsius.Value + celsius2.Value, new Celsius(temp1 + temp2).Value);
            }
        }

        [TestClass]
        public class CelsiusSubtractionOperatorTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void CelsiusSubtractionCelsiusFromCelsiusTest()
            {
                double temp1 = 20;
                double temp2 = 30;
                var celsius = new Celsius(temp1);
                var celsius2 = new Celsius(temp2);

                Assert.AreEqual(expected: new Celsius(temp1 - temp2), celsius - celsius2);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void CelsiusSubtractionCelsiusFromFromTest()
            {
                double temp1 = 20;
                double temp2 = 30;
                var celsius = new Celsius(temp1);
                var celsius2 = new Celsius(temp2);

                Assert.AreEqual(celsius.Value - celsius2.Value, new Celsius(temp1 - temp2).Value);
            }
        }

        [TestClass]
        public class ToKelvinTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void CelsiusToKelvinTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Kelvin(Converter.Cel2Kel(temp1)), new Celsius(temp1).ToKelvin());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToCelsiusTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInKelvin, new Celsius(Constants.BoilingPointH2OInCelsius).ToKelvin());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToKelvinAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInKelvin, Celsius.ToKelvin(Constants.AbsoluteZeroInCelsius));
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToKelvinMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInKelvin, Celsius.ToKelvin(Constants.MeltingPointH2OInCelsius));
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToKelvinBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInKelvin, Celsius.ToKelvin(Constants.BoilingPointH2OInCelsius));
            }
        }

        [TestClass]
        public class ToCelsiusTests
        {

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToCelsiusAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInCelsius, Celsius.ToCelsius(new Kelvin(Constants.AbsoluteZeroInKelvin)).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToCelsiusMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInCelsius, Celsius.ToCelsius(new Kelvin(Constants.MeltingPointH2OInKelvin)).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToCelsiusBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInCelsius, Celsius.ToCelsius(new Kelvin(Constants.BoilingPointH2OInKelvin)).Value);
            }
        }

        [TestClass]
        public class ToFahrenheitTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void CelsiusToFahrenheitTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Fahrenheit(Converter.Cel2Fah(temp1)), new Celsius(temp1).ToFahrenheit());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToFahrenheitTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInFahrenheit, new Celsius(Constants.BoilingPointH2OInCelsius).ToFahrenheit());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToFahrenheitAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInFahrenheit, Celsius.ToFahrenheit(Constants.AbsoluteZeroInCelsius));
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToFahrenheitMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInFahrenheit, Celsius.ToFahrenheit(Constants.MeltingPointH2OInCelsius));
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToFahrenheitBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInFahrenheit, Celsius.ToFahrenheit(Constants.BoilingPointH2OInCelsius));
            }
        }

        [TestClass]
        public class ToRankineTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void CelsiusToRankineTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Rankine(Converter.Cel2Ran(temp1)), new Celsius(temp1).ToRankine());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToRankineTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInRankine, new Celsius(Constants.BoilingPointH2OInCelsius).ToRankine());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRankineAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInRankine, Celsius.ToRankine(Constants.AbsoluteZeroInCelsius));
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRankineMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInRankine, Celsius.ToRankine(Constants.MeltingPointH2OInCelsius));
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRankineBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInRankine, Celsius.ToRankine(Constants.BoilingPointH2OInCelsius));
            }
        }

        [TestClass]
        public class ToDelisleTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void CelsiusToDelisleTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Delisle(Converter.Cel2Del(temp1)), new Celsius(temp1).ToDelisle());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToDelisleTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInDelisle, new Celsius(Constants.BoilingPointH2OInCelsius).ToDelisle());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToDelisleAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInDelisle, Celsius.ToDelisle(Constants.AbsoluteZeroInCelsius));
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToDelisleMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInDelisle, Celsius.ToDelisle(Constants.MeltingPointH2OInCelsius));
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToDelisleBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInDelisle, Celsius.ToDelisle(Constants.BoilingPointH2OInCelsius));
            }
        }

        [TestClass]
        public class ToNewtonTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void CelsiusToNewtonTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Newton(Converter.Cel2New(temp1)), new Celsius(temp1).ToNewton());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToNewtonTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInNewton, new Celsius(Constants.BoilingPointH2OInCelsius).ToNewton());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToNewtonAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInNewton, Celsius.ToNewton(Constants.AbsoluteZeroInCelsius));
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToNewtonMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInNewton, Celsius.ToNewton(Constants.MeltingPointH2OInCelsius));
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToNewtonBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInNewton, Celsius.ToNewton(Constants.BoilingPointH2OInCelsius));
            }
        }

        [TestClass]
        public class ToRéaumurTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void CelsiusToRéaumurTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Réaumur(Converter.Cel2Réau(temp1)), new Celsius(temp1).ToRéaumur());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToRéaumurTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInRéaumur, new Celsius(Constants.BoilingPointH2OInCelsius).ToRéaumur());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRéaumurAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInRéaumur, Celsius.ToRéaumur(Constants.AbsoluteZeroInCelsius));
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRéaumurMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInRéaumur, Celsius.ToRéaumur(Constants.MeltingPointH2OInCelsius));
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRéaumurBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInRéaumur, Celsius.ToRéaumur(Constants.BoilingPointH2OInCelsius));
            }
        }

        [TestClass]
        public class ToRømerTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void CelsiusToRømerTest()
            {
                double temp1 = 20;

                Assert.AreEqual(expected: new Rømer(Converter.Cel2Røm(temp1)), new Celsius(temp1).ToRømer());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void FromDoubleToRømerTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInRømer, new Celsius(Constants.BoilingPointH2OInCelsius).ToRømer());
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRømerAbsoluteZeroTest()
            {
                Assert.AreEqual(expected: Constants.AbsoluteZeroInRømer, Celsius.ToRømer(Constants.AbsoluteZeroInCelsius));
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRømerMeltingPointTest()
            {
                Assert.AreEqual(expected: Constants.MeltingPointH2OInRømer, Celsius.ToRømer(Constants.MeltingPointH2OInCelsius));
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticFromDoubleToRømerBoilingPointTest()
            {
                Assert.AreEqual(expected: Constants.BoilingPointH2OInRømer, Celsius.ToRømer(Constants.BoilingPointH2OInCelsius));
            }
        }
    }
}
