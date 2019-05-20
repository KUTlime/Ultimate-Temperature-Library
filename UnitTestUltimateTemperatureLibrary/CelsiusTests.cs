using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UltimateTemperatureLibrary;

namespace UnitTestUltimateTemperatureLibrary
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
        }
    }
}
