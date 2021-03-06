﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using UltimateTemperatureLibrary.Interfaces;
using UltimateTemperatureLibrary.Utils;

namespace UltimateTemperatureLibrary.UnitTests
{
    public class TemperatureUnitTests
    {
        [TestClass]
        public class ToKelvinTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void ValidAbsoluteZeroInKelvinPassedTest()
            {
                var celsius = new Celsius(Constants.AbsoluteZeroInCelsius);
                var kelvin = new Kelvin(Constants.AbsoluteZeroInKelvin);
                var fahrenheit = new Fahrenheit(Constants.AbsoluteZeroInFahrenheit);
                var rankine = new Rankine(Constants.AbsoluteZeroInRankine);
                var delisle = new Delisle(Constants.AbsoluteZeroInDelisle);
                var newton = new Newton(Constants.AbsoluteZeroInNewton);
                var réaumur = new Réaumur(Constants.AbsoluteZeroInRéaumur);
                var rømer = new Rømer(Constants.AbsoluteZeroInRømer);

                Assert.AreEqual(Constants.AbsoluteZeroInKelvin, TemperatureUnit.ToKelvin(kelvin).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInKelvin, TemperatureUnit.ToKelvin(celsius).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInKelvin, TemperatureUnit.ToKelvin(fahrenheit).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInKelvin, TemperatureUnit.ToKelvin(rankine).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInKelvin, TemperatureUnit.ToKelvin(delisle).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInKelvin, TemperatureUnit.ToKelvin(newton).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInKelvin, TemperatureUnit.ToKelvin(réaumur).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInKelvin, TemperatureUnit.ToKelvin(rømer).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void ValidMeltingPointH2OInKelvinPassedTest()
            {
                var celsius = new Celsius(Constants.MeltingPointH2OInCelsius);
                var kelvin = new Kelvin(Constants.MeltingPointH2OInKelvin);
                var fahrenheit = new Fahrenheit(Constants.MeltingPointH2OInFahrenheit);
                var rankine = new Rankine(Constants.MeltingPointH2OInRankine);
                var delisle = new Delisle(Constants.MeltingPointH2OInDelisle);
                var newton = new Newton(Constants.MeltingPointH2OInNewton);
                var réaumur = new Réaumur(Constants.MeltingPointH2OInRéaumur);
                var rømer = new Rømer(Constants.MeltingPointH2OInRømer);
                Assert.AreEqual(Constants.MeltingPointH2OInKelvin, TemperatureUnit.ToKelvin(kelvin).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInKelvin, TemperatureUnit.ToKelvin(celsius).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInKelvin, TemperatureUnit.ToKelvin(fahrenheit).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInKelvin, TemperatureUnit.ToKelvin(rankine).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInKelvin, TemperatureUnit.ToKelvin(delisle).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInKelvin, TemperatureUnit.ToKelvin(newton).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInKelvin, TemperatureUnit.ToKelvin(réaumur).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInKelvin, TemperatureUnit.ToKelvin(rømer).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void ValidBoilingPointH2OInKelvinPassedTest()
            {
                var celsius = new Celsius(Constants.BoilingPointH2OInCelsius);
                var kelvin = new Kelvin(Constants.BoilingPointH2OInKelvin);
                var fahrenheit = new Fahrenheit(Constants.BoilingPointH2OInFahrenheit);
                var rankine = new Rankine(Constants.BoilingPointH2OInRankine);
                var delisle = new Delisle(Constants.BoilingPointH2OInDelisle);
                var newton = new Newton(Constants.BoilingPointH2OInNewton);
                var réaumur = new Réaumur(Constants.BoilingPointH2OInRéaumur);
                var rømer = new Rømer(Constants.BoilingPointH2OInRømer);
                Assert.AreEqual(Constants.BoilingPointH2OInKelvin, TemperatureUnit.ToKelvin(kelvin).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInKelvin, TemperatureUnit.ToKelvin(celsius).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInKelvin, TemperatureUnit.ToKelvin(fahrenheit).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.BoilingPointH2OInKelvin, TemperatureUnit.ToKelvin(rankine).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInKelvin, TemperatureUnit.ToKelvin(delisle).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInKelvin, TemperatureUnit.ToKelvin(newton).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInKelvin, TemperatureUnit.ToKelvin(réaumur).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInKelvin, TemperatureUnit.ToKelvin(rømer).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticConversionFromStringTest()
            {
                Assert.AreEqual(new Kelvin("0 K"), TemperatureUnit.ToKelvin("0 K"));
                Assert.AreEqual(new Kelvin("0 °C"), TemperatureUnit.ToKelvin("0 °C"));
                Assert.AreEqual(new Kelvin("0 °F"), TemperatureUnit.ToKelvin("0 °F"));
                Assert.AreEqual(new Kelvin("0 °R"), TemperatureUnit.ToKelvin("0 °R"));
                Assert.AreEqual(new Kelvin("0 °D"), TemperatureUnit.ToKelvin("0 °D"));
                Assert.AreEqual(new Kelvin("0 °N"), TemperatureUnit.ToKelvin("0 °N"));
                Assert.AreEqual(new Kelvin("0 °Ré"), TemperatureUnit.ToKelvin("0 °Ré"));
                Assert.AreEqual(new Kelvin("0 °Rø"), TemperatureUnit.ToKelvin("0 °Rø"));
            }
        }

        [TestClass]
        public class ToCelsiusTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void ValidAbsoluteZeroInCelsiusPassedTest()
            {
                var celsius = new Celsius(Constants.AbsoluteZeroInCelsius);
                var kelvin = new Kelvin(Constants.AbsoluteZeroInKelvin);
                var fahrenheit = new Fahrenheit(Constants.AbsoluteZeroInFahrenheit);
                var rankine = new Rankine(Constants.AbsoluteZeroInRankine);
                var delisle = new Delisle(Constants.AbsoluteZeroInDelisle);
                var newton = new Newton(Constants.AbsoluteZeroInNewton);
                var réaumur = new Réaumur(Constants.AbsoluteZeroInRéaumur);
                var rømer = new Rømer(Constants.AbsoluteZeroInRømer);
                Assert.AreEqual(Constants.AbsoluteZeroInCelsius, TemperatureUnit.ToCelsius(kelvin).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInCelsius, TemperatureUnit.ToCelsius(celsius).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInCelsius, TemperatureUnit.ToCelsius(fahrenheit).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInCelsius, TemperatureUnit.ToCelsius(rankine).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInCelsius, TemperatureUnit.ToCelsius(delisle).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInCelsius, TemperatureUnit.ToCelsius(newton).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInCelsius, TemperatureUnit.ToCelsius(réaumur).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInCelsius, TemperatureUnit.ToCelsius(rømer).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void ValidMeltingPointH2OInCelsiusPassedTest()
            {
                var celsius = new Celsius(Constants.MeltingPointH2OInCelsius);
                var kelvin = new Kelvin(Constants.MeltingPointH2OInKelvin);
                var fahrenheit = new Fahrenheit(Constants.MeltingPointH2OInFahrenheit);
                var rankine = new Rankine(Constants.MeltingPointH2OInRankine);
                var delisle = new Delisle(Constants.MeltingPointH2OInDelisle);
                var newton = new Newton(Constants.MeltingPointH2OInNewton);
                var réaumur = new Réaumur(Constants.MeltingPointH2OInRéaumur);
                var rømer = new Rømer(Constants.MeltingPointH2OInRømer);
                Assert.AreEqual(Constants.MeltingPointH2OInCelsius, TemperatureUnit.ToCelsius(kelvin).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInCelsius, TemperatureUnit.ToCelsius(celsius).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInCelsius, TemperatureUnit.ToCelsius(fahrenheit).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInCelsius, TemperatureUnit.ToCelsius(rankine).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInCelsius, TemperatureUnit.ToCelsius(delisle).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInCelsius, TemperatureUnit.ToCelsius(newton).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInCelsius, TemperatureUnit.ToCelsius(réaumur).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInCelsius, TemperatureUnit.ToCelsius(rømer).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void ValidBoilingPointH2OInCelsiusPassedTest()
            {
                var celsius = new Celsius(Constants.BoilingPointH2OInCelsius);
                var kelvin = new Kelvin(Constants.BoilingPointH2OInKelvin);
                var fahrenheit = new Fahrenheit(Constants.BoilingPointH2OInFahrenheit);
                var rankine = new Rankine(Constants.BoilingPointH2OInRankine);
                var delisle = new Delisle(Constants.BoilingPointH2OInDelisle);
                var newton = new Newton(Constants.BoilingPointH2OInNewton);
                var réaumur = new Réaumur(Constants.BoilingPointH2OInRéaumur);
                var rømer = new Rømer(Constants.BoilingPointH2OInRømer);
                Assert.AreEqual(Constants.BoilingPointH2OInCelsius, TemperatureUnit.ToCelsius(kelvin).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInCelsius, TemperatureUnit.ToCelsius(celsius).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInCelsius, TemperatureUnit.ToCelsius(fahrenheit).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.BoilingPointH2OInCelsius, TemperatureUnit.ToCelsius(rankine).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInCelsius, TemperatureUnit.ToCelsius(delisle).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInCelsius, TemperatureUnit.ToCelsius(newton).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInCelsius, TemperatureUnit.ToCelsius(réaumur).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInCelsius, TemperatureUnit.ToCelsius(rømer).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticConversionFromStringTest()
            {
                Assert.AreEqual(new Celsius("0 K"), TemperatureUnit.ToCelsius("0 K"));
                Assert.AreEqual(new Celsius("0 °C"), TemperatureUnit.ToCelsius("0 °C"));
                Assert.AreEqual(new Celsius("0 °F"), TemperatureUnit.ToCelsius("0 °F"));
                Assert.AreEqual(new Celsius("0 °R"), TemperatureUnit.ToCelsius("0 °R"));
                Assert.AreEqual(new Celsius("0 °D"), TemperatureUnit.ToCelsius("0 °D"));
                Assert.AreEqual(new Celsius("0 °N"), TemperatureUnit.ToCelsius("0 °N"));
                Assert.AreEqual(new Celsius("0 °Ré"), TemperatureUnit.ToCelsius("0 °Ré"));
                Assert.AreEqual(new Celsius("0 °Rø"), TemperatureUnit.ToCelsius("0 °Rø"));
            }
        }

        [TestClass]
        public class ToFahrenheitTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void ValidAbsoluteZeroInFahrenheitPassedTest()
            {
                var celsius = new Celsius(Constants.AbsoluteZeroInCelsius);
                var kelvin = new Kelvin(Constants.AbsoluteZeroInKelvin);
                var fahrenheit = new Fahrenheit(Constants.AbsoluteZeroInFahrenheit);
                var rankine = new Rankine(Constants.AbsoluteZeroInRankine);
                var delisle = new Delisle(Constants.AbsoluteZeroInDelisle);
                var newton = new Newton(Constants.AbsoluteZeroInNewton);
                var réaumur = new Réaumur(Constants.AbsoluteZeroInRéaumur);
                var rømer = new Rømer(Constants.AbsoluteZeroInRømer);
                Assert.AreEqual(Constants.AbsoluteZeroInFahrenheit, TemperatureUnit.ToFahrenheit(kelvin).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInFahrenheit, TemperatureUnit.ToFahrenheit(celsius).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInFahrenheit, TemperatureUnit.ToFahrenheit(fahrenheit).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInFahrenheit, TemperatureUnit.ToFahrenheit(rankine).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInFahrenheit, TemperatureUnit.ToFahrenheit(delisle).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInFahrenheit, TemperatureUnit.ToFahrenheit(newton).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInFahrenheit, TemperatureUnit.ToFahrenheit(réaumur).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInFahrenheit, TemperatureUnit.ToFahrenheit(rømer).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void ValidMeltingPointH2OInFahrenheitPassedTest()
            {
                var celsius = new Celsius(Constants.MeltingPointH2OInCelsius);
                var kelvin = new Kelvin(Constants.MeltingPointH2OInKelvin);
                var fahrenheit = new Fahrenheit(Constants.MeltingPointH2OInFahrenheit);
                var rankine = new Rankine(Constants.MeltingPointH2OInRankine);
                var delisle = new Delisle(Constants.MeltingPointH2OInDelisle);
                var newton = new Newton(Constants.MeltingPointH2OInNewton);
                var réaumur = new Réaumur(Constants.MeltingPointH2OInRéaumur);
                var rømer = new Rømer(Constants.MeltingPointH2OInRømer);
                Assert.AreEqual(Constants.MeltingPointH2OInFahrenheit, TemperatureUnit.ToFahrenheit(kelvin).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.MeltingPointH2OInFahrenheit, TemperatureUnit.ToFahrenheit(celsius).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.MeltingPointH2OInFahrenheit, TemperatureUnit.ToFahrenheit(fahrenheit).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.MeltingPointH2OInFahrenheit, TemperatureUnit.ToFahrenheit(rankine).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.MeltingPointH2OInFahrenheit, TemperatureUnit.ToFahrenheit(delisle).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.MeltingPointH2OInFahrenheit, TemperatureUnit.ToFahrenheit(newton).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.MeltingPointH2OInFahrenheit, TemperatureUnit.ToFahrenheit(réaumur).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.MeltingPointH2OInFahrenheit, TemperatureUnit.ToFahrenheit(rømer).Value, OperationOverDoublePrecision.HighPrecision);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void ValidBoilingPointH2OInFahrenheitPassedTest()
            {
                var celsius = new Celsius(Constants.BoilingPointH2OInCelsius);
                var kelvin = new Kelvin(Constants.BoilingPointH2OInKelvin);
                var fahrenheit = new Fahrenheit(Constants.BoilingPointH2OInFahrenheit);
                var rankine = new Rankine(Constants.BoilingPointH2OInRankine);
                var delisle = new Delisle(Constants.BoilingPointH2OInDelisle);
                var newton = new Newton(Constants.BoilingPointH2OInNewton);
                var réaumur = new Réaumur(Constants.BoilingPointH2OInRéaumur);
                var rømer = new Rømer(Constants.BoilingPointH2OInRømer);
                Assert.AreEqual(Constants.BoilingPointH2OInFahrenheit, TemperatureUnit.ToFahrenheit(kelvin).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.BoilingPointH2OInFahrenheit, TemperatureUnit.ToFahrenheit(celsius).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.BoilingPointH2OInFahrenheit, TemperatureUnit.ToFahrenheit(fahrenheit).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.BoilingPointH2OInFahrenheit, TemperatureUnit.ToFahrenheit(rankine).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.BoilingPointH2OInFahrenheit, TemperatureUnit.ToFahrenheit(delisle).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.BoilingPointH2OInFahrenheit, TemperatureUnit.ToFahrenheit(newton).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.BoilingPointH2OInFahrenheit, TemperatureUnit.ToFahrenheit(réaumur).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.BoilingPointH2OInFahrenheit, TemperatureUnit.ToFahrenheit(rømer).Value, OperationOverDoublePrecision.HighPrecision);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticConversionFromStringTest()
            {
                Assert.AreEqual(new Fahrenheit("0 K"), TemperatureUnit.ToFahrenheit("0 K"));
                Assert.AreEqual(new Fahrenheit("0 °C"), TemperatureUnit.ToFahrenheit("0 °C"));
                Assert.AreEqual(new Fahrenheit("0 °F"), TemperatureUnit.ToFahrenheit("0 °F"));
                Assert.AreEqual(new Fahrenheit("0 °R"), TemperatureUnit.ToFahrenheit("0 °R"));
                Assert.AreEqual(new Fahrenheit("0 °D"), TemperatureUnit.ToFahrenheit("0 °D"));
                Assert.AreEqual(new Fahrenheit("0 °N"), TemperatureUnit.ToFahrenheit("0 °N"));
                Assert.AreEqual(new Fahrenheit("0 °Ré"), TemperatureUnit.ToFahrenheit("0 °Ré"));
                Assert.AreEqual(new Fahrenheit("0 °Rø"), TemperatureUnit.ToFahrenheit("0 °Rø"));
            }
        }

        [TestClass]
        public class ToRankineTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void ValidAbsoluteZeroInRankinePassedTest()
            {
                var celsius = new Celsius(Constants.AbsoluteZeroInCelsius);
                var kelvin = new Kelvin(Constants.AbsoluteZeroInKelvin);
                var fahrenheit = new Fahrenheit(Constants.AbsoluteZeroInFahrenheit);
                var rankine = new Rankine(Constants.AbsoluteZeroInRankine);
                var delisle = new Delisle(Constants.AbsoluteZeroInDelisle);
                var newton = new Newton(Constants.AbsoluteZeroInNewton);
                var réaumur = new Réaumur(Constants.AbsoluteZeroInRéaumur);
                var rømer = new Rømer(Constants.AbsoluteZeroInRømer);
                Assert.AreEqual(Constants.AbsoluteZeroInRankine, TemperatureUnit.ToRankine(kelvin).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRankine, TemperatureUnit.ToRankine(celsius).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRankine, TemperatureUnit.ToRankine(fahrenheit).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRankine, TemperatureUnit.ToRankine(rankine).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRankine, TemperatureUnit.ToRankine(delisle).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRankine, TemperatureUnit.ToRankine(newton).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRankine, TemperatureUnit.ToRankine(réaumur).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRankine, TemperatureUnit.ToRankine(rømer).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void ValidMeltingPointH2OInRankinePassedTest()
            {
                var celsius = new Celsius(Constants.MeltingPointH2OInCelsius);
                var kelvin = new Kelvin(Constants.MeltingPointH2OInKelvin);
                var fahrenheit = new Fahrenheit(Constants.MeltingPointH2OInFahrenheit);
                var rankine = new Rankine(Constants.MeltingPointH2OInRankine);
                var delisle = new Delisle(Constants.MeltingPointH2OInDelisle);
                var newton = new Newton(Constants.MeltingPointH2OInNewton);
                var réaumur = new Réaumur(Constants.MeltingPointH2OInRéaumur);
                var rømer = new Rømer(Constants.MeltingPointH2OInRømer);
                Assert.AreEqual(Constants.MeltingPointH2OInRankine, TemperatureUnit.ToRankine(kelvin).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.MeltingPointH2OInRankine, TemperatureUnit.ToRankine(celsius).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.MeltingPointH2OInRankine, TemperatureUnit.ToRankine(fahrenheit).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.MeltingPointH2OInRankine, TemperatureUnit.ToRankine(rankine).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.MeltingPointH2OInRankine, TemperatureUnit.ToRankine(delisle).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.MeltingPointH2OInRankine, TemperatureUnit.ToRankine(newton).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.MeltingPointH2OInRankine, TemperatureUnit.ToRankine(réaumur).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.MeltingPointH2OInRankine, TemperatureUnit.ToRankine(rømer).Value, OperationOverDoublePrecision.HighPrecision);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void ValidBoilingPointH2OInRankinePassedTest()
            {
                var celsius = new Celsius(Constants.BoilingPointH2OInCelsius);
                var kelvin = new Kelvin(Constants.BoilingPointH2OInKelvin);
                var fahrenheit = new Fahrenheit(Constants.BoilingPointH2OInFahrenheit);
                var rankine = new Rankine(Constants.BoilingPointH2OInRankine);
                var delisle = new Delisle(Constants.BoilingPointH2OInDelisle);
                var newton = new Newton(Constants.BoilingPointH2OInNewton);
                var réaumur = new Réaumur(Constants.BoilingPointH2OInRéaumur);
                var rømer = new Rømer(Constants.BoilingPointH2OInRømer);
                Assert.AreEqual(Constants.BoilingPointH2OInRankine, TemperatureUnit.ToRankine(kelvin).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.BoilingPointH2OInRankine, TemperatureUnit.ToRankine(celsius).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.BoilingPointH2OInRankine, TemperatureUnit.ToRankine(fahrenheit).Value, OperationOverDoublePrecision.MiddlePrecision);
                Assert.AreEqual(Constants.BoilingPointH2OInRankine, TemperatureUnit.ToRankine(rankine).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.BoilingPointH2OInRankine, TemperatureUnit.ToRankine(delisle).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.BoilingPointH2OInRankine, TemperatureUnit.ToRankine(newton).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.BoilingPointH2OInRankine, TemperatureUnit.ToRankine(réaumur).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.BoilingPointH2OInRankine, TemperatureUnit.ToRankine(rømer).Value, OperationOverDoublePrecision.HighPrecision);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticConversionFromStringTest()
            {
                Assert.AreEqual(new Rankine("0 K"), TemperatureUnit.ToRankine("0 K"));
                Assert.AreEqual(new Rankine("0 °C"), TemperatureUnit.ToRankine("0 °C"));
                Assert.AreEqual(new Rankine("0 °F"), TemperatureUnit.ToRankine("0 °F"));
                Assert.AreEqual(new Rankine("0 °R"), TemperatureUnit.ToRankine("0 °R"));
                Assert.AreEqual(new Rankine("0 °D"), TemperatureUnit.ToRankine("0 °D"));
                Assert.AreEqual(new Rankine("0 °N"), TemperatureUnit.ToRankine("0 °N"));
                Assert.AreEqual(new Rankine("0 °Ré"), TemperatureUnit.ToRankine("0 °Ré"));
                Assert.AreEqual(new Rankine("0 °Rø"), TemperatureUnit.ToRankine("0 °Rø"));
            }
        }

        [TestClass]
        public class ToDelisleTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void ValidAbsoluteZeroInDelislePassedTest()
            {
                var celsius = new Celsius(Constants.AbsoluteZeroInCelsius);
                var kelvin = new Kelvin(Constants.AbsoluteZeroInKelvin);
                var fahrenheit = new Fahrenheit(Constants.AbsoluteZeroInFahrenheit);
                var rankine = new Rankine(Constants.AbsoluteZeroInRankine);
                var delisle = new Delisle(Constants.AbsoluteZeroInDelisle);
                var newton = new Newton(Constants.AbsoluteZeroInNewton);
                var réaumur = new Réaumur(Constants.AbsoluteZeroInRéaumur);
                var rømer = new Rømer(Constants.AbsoluteZeroInRømer);
                Assert.AreEqual(Constants.AbsoluteZeroInDelisle, TemperatureUnit.ToDelisle(kelvin).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInDelisle, TemperatureUnit.ToDelisle(celsius).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInDelisle, TemperatureUnit.ToDelisle(fahrenheit).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInDelisle, TemperatureUnit.ToDelisle(rankine).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInDelisle, TemperatureUnit.ToDelisle(delisle).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInDelisle, TemperatureUnit.ToDelisle(newton).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInDelisle, TemperatureUnit.ToDelisle(réaumur).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInDelisle, TemperatureUnit.ToDelisle(rømer).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void ValidMeltingPointH2OInDelislePassedTest()
            {
                var celsius = new Celsius(Constants.MeltingPointH2OInCelsius);
                var kelvin = new Kelvin(Constants.MeltingPointH2OInKelvin);
                var fahrenheit = new Fahrenheit(Constants.MeltingPointH2OInFahrenheit);
                var rankine = new Rankine(Constants.MeltingPointH2OInRankine);
                var delisle = new Delisle(Constants.MeltingPointH2OInDelisle);
                var newton = new Newton(Constants.MeltingPointH2OInNewton);
                var réaumur = new Réaumur(Constants.MeltingPointH2OInRéaumur);
                var rømer = new Rømer(Constants.MeltingPointH2OInRømer);
                Assert.AreEqual(Constants.MeltingPointH2OInDelisle, TemperatureUnit.ToDelisle(kelvin).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInDelisle, TemperatureUnit.ToDelisle(celsius).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInDelisle, TemperatureUnit.ToDelisle(fahrenheit).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInDelisle, TemperatureUnit.ToDelisle(rankine).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInDelisle, TemperatureUnit.ToDelisle(delisle).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInDelisle, TemperatureUnit.ToDelisle(newton).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInDelisle, TemperatureUnit.ToDelisle(réaumur).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInDelisle, TemperatureUnit.ToDelisle(rømer).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void ValidBoilingPointH2OInDelislePassedTest()
            {
                var celsius = new Celsius(Constants.BoilingPointH2OInCelsius);
                var kelvin = new Kelvin(Constants.BoilingPointH2OInKelvin);
                var fahrenheit = new Fahrenheit(Constants.BoilingPointH2OInFahrenheit);
                var rankine = new Rankine(Constants.BoilingPointH2OInRankine);
                var delisle = new Delisle(Constants.BoilingPointH2OInDelisle);
                var newton = new Newton(Constants.BoilingPointH2OInNewton);
                var réaumur = new Réaumur(Constants.BoilingPointH2OInRéaumur);
                var rømer = new Rømer(Constants.BoilingPointH2OInRømer);
                Assert.AreEqual(Constants.BoilingPointH2OInDelisle, TemperatureUnit.ToDelisle(kelvin).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInDelisle, TemperatureUnit.ToDelisle(celsius).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInDelisle, TemperatureUnit.ToDelisle(fahrenheit).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.BoilingPointH2OInDelisle, TemperatureUnit.ToDelisle(rankine).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInDelisle, TemperatureUnit.ToDelisle(delisle).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInDelisle, TemperatureUnit.ToDelisle(newton).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInDelisle, TemperatureUnit.ToDelisle(réaumur).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInDelisle, TemperatureUnit.ToDelisle(rømer).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticConversionFromStringTest()
            {
                Assert.AreEqual(new Delisle("0 K"), TemperatureUnit.ToDelisle("0 K"));
                Assert.AreEqual(new Delisle("0 °C"), TemperatureUnit.ToDelisle("0 °C"));
                Assert.AreEqual(new Delisle("0 °F"), TemperatureUnit.ToDelisle("0 °F"));
                Assert.AreEqual(new Delisle("0 °R"), TemperatureUnit.ToDelisle("0 °R"));
                Assert.AreEqual(new Delisle("0 °D"), TemperatureUnit.ToDelisle("0 °D"));
                Assert.AreEqual(new Delisle("0 °N"), TemperatureUnit.ToDelisle("0 °N"));
                Assert.AreEqual(new Delisle("0 °Ré"), TemperatureUnit.ToDelisle("0 °Ré"));
                Assert.AreEqual(new Delisle("0 °Rø"), TemperatureUnit.ToDelisle("0 °Rø"));
            }
        }

        [TestClass]
        public class ToNewtonTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void ValidAbsoluteZeroInNewtonPassedTest()
            {
                var celsius = new Celsius(Constants.AbsoluteZeroInCelsius);
                var kelvin = new Kelvin(Constants.AbsoluteZeroInKelvin);
                var fahrenheit = new Fahrenheit(Constants.AbsoluteZeroInFahrenheit);
                var rankine = new Rankine(Constants.AbsoluteZeroInRankine);
                var delisle = new Delisle(Constants.AbsoluteZeroInDelisle);
                var newton = new Newton(Constants.AbsoluteZeroInNewton);
                var réaumur = new Réaumur(Constants.AbsoluteZeroInRéaumur);
                var rømer = new Rømer(Constants.AbsoluteZeroInRømer);
                Assert.AreEqual(Constants.AbsoluteZeroInNewton, TemperatureUnit.ToNewton(kelvin).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInNewton, TemperatureUnit.ToNewton(celsius).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInNewton, TemperatureUnit.ToNewton(fahrenheit).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInNewton, TemperatureUnit.ToNewton(rankine).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInNewton, TemperatureUnit.ToNewton(delisle).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInNewton, TemperatureUnit.ToNewton(newton).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInNewton, TemperatureUnit.ToNewton(réaumur).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInNewton, TemperatureUnit.ToNewton(rømer).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void ValidMeltingPointH2OInNewtonPassedTest()
            {
                var celsius = new Celsius(Constants.MeltingPointH2OInCelsius);
                var kelvin = new Kelvin(Constants.MeltingPointH2OInKelvin);
                var fahrenheit = new Fahrenheit(Constants.MeltingPointH2OInFahrenheit);
                var rankine = new Rankine(Constants.MeltingPointH2OInRankine);
                var delisle = new Delisle(Constants.MeltingPointH2OInDelisle);
                var newton = new Newton(Constants.MeltingPointH2OInNewton);
                var réaumur = new Réaumur(Constants.MeltingPointH2OInRéaumur);
                var rømer = new Rømer(Constants.MeltingPointH2OInRømer);
                Assert.AreEqual(Constants.MeltingPointH2OInNewton, TemperatureUnit.ToNewton(kelvin).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInNewton, TemperatureUnit.ToNewton(celsius).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInNewton, TemperatureUnit.ToNewton(fahrenheit).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInNewton, TemperatureUnit.ToNewton(rankine).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInNewton, TemperatureUnit.ToNewton(delisle).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInNewton, TemperatureUnit.ToNewton(newton).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInNewton, TemperatureUnit.ToNewton(réaumur).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInNewton, TemperatureUnit.ToNewton(rømer).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void ValidBoilingPointH2OInNewtonPassedTest()
            {
                var celsius = new Celsius(Constants.BoilingPointH2OInCelsius);
                var kelvin = new Kelvin(Constants.BoilingPointH2OInKelvin);
                var fahrenheit = new Fahrenheit(Constants.BoilingPointH2OInFahrenheit);
                var rankine = new Rankine(Constants.BoilingPointH2OInRankine);
                var delisle = new Delisle(Constants.BoilingPointH2OInDelisle);
                var newton = new Newton(Constants.BoilingPointH2OInNewton);
                var réaumur = new Réaumur(Constants.BoilingPointH2OInRéaumur);
                var rømer = new Rømer(Constants.BoilingPointH2OInRømer);
                Assert.AreEqual(Constants.BoilingPointH2OInNewton, TemperatureUnit.ToNewton(kelvin).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInNewton, TemperatureUnit.ToNewton(celsius).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInNewton, TemperatureUnit.ToNewton(fahrenheit).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.BoilingPointH2OInNewton, TemperatureUnit.ToNewton(rankine).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInNewton, TemperatureUnit.ToNewton(delisle).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInNewton, TemperatureUnit.ToNewton(newton).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInNewton, TemperatureUnit.ToNewton(réaumur).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInNewton, TemperatureUnit.ToNewton(rømer).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticConversionFromStringTest()
            {
                Assert.AreEqual(new Newton("0 K"), TemperatureUnit.ToNewton("0 K"));
                Assert.AreEqual(new Newton("0 °C"), TemperatureUnit.ToNewton("0 °C"));
                Assert.AreEqual(new Newton("0 °F"), TemperatureUnit.ToNewton("0 °F"));
                Assert.AreEqual(new Newton("0 °R"), TemperatureUnit.ToNewton("0 °R"));
                Assert.AreEqual(new Newton("0 °D"), TemperatureUnit.ToNewton("0 °D"));
                Assert.AreEqual(new Newton("0 °N"), TemperatureUnit.ToNewton("0 °N"));
                Assert.AreEqual(new Newton("0 °Ré"), TemperatureUnit.ToNewton("0 °Ré"));
                Assert.AreEqual(new Newton("0 °Rø"), TemperatureUnit.ToNewton("0 °Rø"));
            }
        }

        [TestClass]
        public class ToRéaumurTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void ValidAbsoluteZeroInRéaumurPassedTest()
            {
                var celsius = new Celsius(Constants.AbsoluteZeroInCelsius);
                var kelvin = new Kelvin(Constants.AbsoluteZeroInKelvin);
                var fahrenheit = new Fahrenheit(Constants.AbsoluteZeroInFahrenheit);
                var rankine = new Rankine(Constants.AbsoluteZeroInRankine);
                var delisle = new Delisle(Constants.AbsoluteZeroInDelisle);
                var newton = new Newton(Constants.AbsoluteZeroInNewton);
                var réaumur = new Réaumur(Constants.AbsoluteZeroInRéaumur);
                var rømer = new Rømer(Constants.AbsoluteZeroInRømer);
                Assert.AreEqual(Constants.AbsoluteZeroInRéaumur, TemperatureUnit.ToRéaumur(kelvin).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRéaumur, TemperatureUnit.ToRéaumur(celsius).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRéaumur, TemperatureUnit.ToRéaumur(fahrenheit).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRéaumur, TemperatureUnit.ToRéaumur(rankine).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRéaumur, TemperatureUnit.ToRéaumur(delisle).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRéaumur, TemperatureUnit.ToRéaumur(newton).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRéaumur, TemperatureUnit.ToRéaumur(réaumur).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRéaumur, TemperatureUnit.ToRéaumur(rømer).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void ValidMeltingPointH2OInRéaumurPassedTest()
            {
                var celsius = new Celsius(Constants.MeltingPointH2OInCelsius);
                var kelvin = new Kelvin(Constants.MeltingPointH2OInKelvin);
                var fahrenheit = new Fahrenheit(Constants.MeltingPointH2OInFahrenheit);
                var rankine = new Rankine(Constants.MeltingPointH2OInRankine);
                var delisle = new Delisle(Constants.MeltingPointH2OInDelisle);
                var newton = new Newton(Constants.MeltingPointH2OInNewton);
                var réaumur = new Réaumur(Constants.MeltingPointH2OInRéaumur);
                var rømer = new Rømer(Constants.MeltingPointH2OInRømer);
                Assert.AreEqual(Constants.MeltingPointH2OInRéaumur, TemperatureUnit.ToRéaumur(kelvin).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInRéaumur, TemperatureUnit.ToRéaumur(celsius).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInRéaumur, TemperatureUnit.ToRéaumur(fahrenheit).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInRéaumur, TemperatureUnit.ToRéaumur(rankine).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInRéaumur, TemperatureUnit.ToRéaumur(delisle).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInRéaumur, TemperatureUnit.ToRéaumur(newton).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInRéaumur, TemperatureUnit.ToRéaumur(réaumur).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInRéaumur, TemperatureUnit.ToRéaumur(rømer).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void ValidBoilingPointH2OInRéaumurPassedTest()
            {
                var celsius = new Celsius(Constants.BoilingPointH2OInCelsius);
                var kelvin = new Kelvin(Constants.BoilingPointH2OInKelvin);
                var fahrenheit = new Fahrenheit(Constants.BoilingPointH2OInFahrenheit);
                var rankine = new Rankine(Constants.BoilingPointH2OInRankine);
                var delisle = new Delisle(Constants.BoilingPointH2OInDelisle);
                var newton = new Newton(Constants.BoilingPointH2OInNewton);
                var réaumur = new Réaumur(Constants.BoilingPointH2OInRéaumur);
                var rømer = new Rømer(Constants.BoilingPointH2OInRømer);
                Assert.AreEqual(Constants.BoilingPointH2OInRéaumur, TemperatureUnit.ToRéaumur(kelvin).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInRéaumur, TemperatureUnit.ToRéaumur(celsius).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInRéaumur, TemperatureUnit.ToRéaumur(fahrenheit).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.BoilingPointH2OInRéaumur, TemperatureUnit.ToRéaumur(rankine).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInRéaumur, TemperatureUnit.ToRéaumur(delisle).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInRéaumur, TemperatureUnit.ToRéaumur(newton).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInRéaumur, TemperatureUnit.ToRéaumur(réaumur).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInRéaumur, TemperatureUnit.ToRéaumur(rømer).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticConversionFromStringTest()
            {
                Assert.AreEqual(new Réaumur("0 K"), TemperatureUnit.ToRéaumur("0 K"));
                Assert.AreEqual(new Réaumur("0 °C"), TemperatureUnit.ToRéaumur("0 °C"));
                Assert.AreEqual(new Réaumur("0 °F"), TemperatureUnit.ToRéaumur("0 °F"));
                Assert.AreEqual(new Réaumur("0 °R"), TemperatureUnit.ToRéaumur("0 °R"));
                Assert.AreEqual(new Réaumur("0 °D"), TemperatureUnit.ToRéaumur("0 °D"));
                Assert.AreEqual(new Réaumur("0 °N"), TemperatureUnit.ToRéaumur("0 °N"));
                Assert.AreEqual(new Réaumur("0 °Ré"), TemperatureUnit.ToRéaumur("0 °Ré"));
                Assert.AreEqual(new Réaumur("0 °Rø"), TemperatureUnit.ToRéaumur("0 °Rø"));
            }
        }

        [TestClass]
        public class ToRømerTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void ValidAbsoluteZeroInRømerPassedTest()
            {
                var celsius = new Celsius(Constants.AbsoluteZeroInCelsius);
                var kelvin = new Kelvin(Constants.AbsoluteZeroInKelvin);
                var fahrenheit = new Fahrenheit(Constants.AbsoluteZeroInFahrenheit);
                var rankine = new Rankine(Constants.AbsoluteZeroInRankine);
                var delisle = new Delisle(Constants.AbsoluteZeroInDelisle);
                var newton = new Newton(Constants.AbsoluteZeroInNewton);
                var réaumur = new Réaumur(Constants.AbsoluteZeroInRéaumur);
                var rømer = new Rømer(Constants.AbsoluteZeroInRømer);
                Assert.AreEqual(Constants.AbsoluteZeroInRømer, TemperatureUnit.ToRømer(kelvin).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRømer, TemperatureUnit.ToRømer(celsius).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRømer, TemperatureUnit.ToRømer(fahrenheit).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRømer, TemperatureUnit.ToRømer(rankine).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRømer, TemperatureUnit.ToRømer(delisle).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRømer, TemperatureUnit.ToRømer(newton).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRømer, TemperatureUnit.ToRømer(réaumur).Value);
                Assert.AreEqual(Constants.AbsoluteZeroInRømer, TemperatureUnit.ToRømer(rømer).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void ValidMeltingPointH2OInRømerPassedTest()
            {
                var celsius = new Celsius(Constants.MeltingPointH2OInCelsius);
                var kelvin = new Kelvin(Constants.MeltingPointH2OInKelvin);
                var fahrenheit = new Fahrenheit(Constants.MeltingPointH2OInFahrenheit);
                var rankine = new Rankine(Constants.MeltingPointH2OInRankine);
                var delisle = new Delisle(Constants.MeltingPointH2OInDelisle);
                var newton = new Newton(Constants.MeltingPointH2OInNewton);
                var réaumur = new Réaumur(Constants.MeltingPointH2OInRéaumur);
                var rømer = new Rømer(Constants.MeltingPointH2OInRømer);
                Assert.AreEqual(Constants.MeltingPointH2OInRømer, TemperatureUnit.ToRømer(kelvin).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInRømer, TemperatureUnit.ToRømer(celsius).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInRømer, TemperatureUnit.ToRømer(fahrenheit).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInRømer, TemperatureUnit.ToRømer(rankine).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInRømer, TemperatureUnit.ToRømer(delisle).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInRømer, TemperatureUnit.ToRømer(newton).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInRømer, TemperatureUnit.ToRømer(réaumur).Value);
                Assert.AreEqual(Constants.MeltingPointH2OInRømer, TemperatureUnit.ToRømer(rømer).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void ValidBoilingPointH2OInRømerPassedTest()
            {
                var celsius = new Celsius(Constants.BoilingPointH2OInCelsius);
                var kelvin = new Kelvin(Constants.BoilingPointH2OInKelvin);
                var fahrenheit = new Fahrenheit(Constants.BoilingPointH2OInFahrenheit);
                var rankine = new Rankine(Constants.BoilingPointH2OInRankine);
                var delisle = new Delisle(Constants.BoilingPointH2OInDelisle);
                var newton = new Newton(Constants.BoilingPointH2OInNewton);
                var réaumur = new Réaumur(Constants.BoilingPointH2OInRéaumur);
                var rømer = new Rømer(Constants.BoilingPointH2OInRømer);
                Assert.AreEqual(Constants.BoilingPointH2OInRømer, TemperatureUnit.ToRømer(kelvin).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInRømer, TemperatureUnit.ToRømer(celsius).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInRømer, TemperatureUnit.ToRømer(fahrenheit).Value, OperationOverDoublePrecision.HighPrecision);
                Assert.AreEqual(Constants.BoilingPointH2OInRømer, TemperatureUnit.ToRømer(rankine).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInRømer, TemperatureUnit.ToRømer(delisle).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInRømer, TemperatureUnit.ToRømer(newton).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInRømer, TemperatureUnit.ToRømer(réaumur).Value);
                Assert.AreEqual(Constants.BoilingPointH2OInRømer, TemperatureUnit.ToRømer(rømer).Value);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void StaticConversionFromStringTest()
            {
                Assert.AreEqual(new Rømer("0 K"), TemperatureUnit.ToRømer("0 K"));
                Assert.AreEqual(new Rømer("0 °C"), TemperatureUnit.ToRømer("0 °C"));
                Assert.AreEqual(new Rømer("0 °F"), TemperatureUnit.ToRømer("0 °F"));
                Assert.AreEqual(new Rømer("0 °R"), TemperatureUnit.ToRømer("0 °R"));
                Assert.AreEqual(new Rømer("0 °D"), TemperatureUnit.ToRømer("0 °D"));
                Assert.AreEqual(new Rømer("0 °N"), TemperatureUnit.ToRømer("0 °N"));
                Assert.AreEqual(new Rømer("0 °Ré"), TemperatureUnit.ToRømer("0 °Ré"));
                Assert.AreEqual(new Rømer("0 °Rø"), TemperatureUnit.ToRømer("0 °Rø"));
            }
        }

        [TestClass]
        public class EqualityTests
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void OneCelsiusEqualityTest()
            {
                var celsius = new Celsius(Constants.AbsoluteZeroInCelsius);
                Assert.AreEqual(true, celsius.Equals(celsius));
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void TwoCelsiusEqualityTest()
            {
                var celsius = new Celsius(Constants.AbsoluteZeroInCelsius);
                var celsius2 = new Celsius(Constants.AbsoluteZeroInCelsius);
                Assert.AreEqual(true, celsius.Equals(celsius2));
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void TwoCelsiusWithSameTemperatureEqualityTest()
            {
                var celsius = new Celsius(Constants.AbsoluteZeroInCelsius);
                var celsius2 = new Celsius(Constants.AbsoluteZeroInCelsius);
                Assert.AreEqual(true, celsius == celsius2);
                Assert.AreEqual(false, celsius != celsius2);
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void NullEqualityTest()
            {
                var celsius = new Celsius(Constants.AbsoluteZeroInCelsius);
                Assert.AreEqual(false, celsius.Equals(null));
                Assert.AreEqual(false, celsius.Equals((object)null));
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void CelsiusWithKelvinEqualityTest()
            {
                var celsius = new Celsius(Constants.AbsoluteZeroInCelsius);
                var kelvin = new Kelvin(Constants.AbsoluteZeroInKelvin);
                Assert.AreEqual(true, celsius.Equals(kelvin));
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void CelsiusWithUnitEqualityTest()
            {
                var celsius = new Celsius(Constants.AbsoluteZeroInCelsius);
                IConversionToKelvin kelvin = new Kelvin(Constants.AbsoluteZeroInKelvin);
                Assert.AreEqual(true, celsius.Equals(kelvin));
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void CelsiusWithSameRefferenceAsUnitEqualityTest()
            {
                var celsius = new Celsius(Constants.AbsoluteZeroInCelsius);
                IConversionToKelvin kelvin = celsius;
                Assert.AreEqual(true, celsius.Equals(kelvin));
            }

            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void UnitWithSomeNonUnitObjEqualityTest()
            {
                var celsius = new Celsius(Constants.AbsoluteZeroInCelsius);
                Assert.AreEqual(false, celsius.Equals(new object()));
            }
        }

        [TestClass]
        public class ToStringTests : TemperatureUnit
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void BaseTostringTest()
            {
                double someTemperature = 20;
                var unit = new ToStringTests() { Value = someTemperature };
                Assert.AreEqual($"{someTemperature} °", unit.ToString());
            }


        }

        [TestClass]
        public class GetHashCodeTests : TemperatureUnit
        {
            [TestCategory(TestCategory.BasicTests)]
            [TestMethod]
            public void BaseGetHashCodeTest()
            {
                double someTemperature = 20;
                var unit = new ToStringTests() { Value = someTemperature };
                Assert.AreEqual(someTemperature.GetHashCode(), unit.GetHashCode());
            }


        }
    }
}