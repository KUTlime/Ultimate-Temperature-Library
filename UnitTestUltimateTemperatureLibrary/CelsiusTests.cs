using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
            [DataRow(-273.15, 0.0, DisplayName = "Lower Reference Temperature")]
            [DataRow(-373.15, 100.0, DisplayName = "Upper Reference Temperature")]
            [DataRow(0.0, Constants.AbsoluteZeroInCelsius, DisplayName = "Absolute zero")]
            [DataRow(1000, 1000, DisplayName = "Some big value ")]
            public void DoubleConstructorTests(double expectedValue, double inputValue)
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
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void OutOfRangeStringConstructorTest()
            {
                var celsius = new Celsius("-500");
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
    }
}
