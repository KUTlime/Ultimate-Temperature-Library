﻿using System;
using UltimateTemperatureLibrary.Interfaces;
using UltimateTemperatureLibrary.Utils;

// Classes related to temperature scales, units, conversion between them, thermodynamic constants etc.
namespace UltimateTemperatureLibrary
{
    /// <summary>
    /// Represents the Celsius scale unit.
    /// </summary>
    public class Celsius : TemperatureUnit, IConversionToKelvin, IConversionToCelsius, IConversionToFahrenheit, IConversionToNewton, IConversionToDelisle, IConversionToRankine, IConversionToRéaumur, IConversionToRømer
    {
        /// <summary>
        /// Initializes a new instance of Celsius class.
        /// <para>Value is set to Absolute zero.</para>
        /// </summary>
        public Celsius()
        {
            Value = Constants.AbsoluteZeroInCelsius;
        }

        /// <summary>
        /// Initializes a new instance of Celsius class using by shared interface.
        /// <para>Value is set to Absolute zero if null object is passed into constructor.</para>
        /// </summary>
        /// <param name="celsius">An unit object transformable to the Celsius scale.</param>
        public Celsius(IConversionToCelsius celsius)
        {
            Value = celsius?.ToCelsius()?.Value ?? Constants.AbsoluteZeroInKelvin;
        }

        /// <summary>
        /// Initializes a new instance of Celsius class using parsing from string.
        /// <para>Kelvin unit is used when no information about unit is provided in the input string.</para>
        /// <para>Value is set to Absolute zero if null object or invalid string is passed into constructor.</para>
        /// </summary>
        /// <param name="value">A string caring an information about value and unit.</param>
        public Celsius(string value)
        {
            if (value == null || String.IsNullOrWhiteSpace(value))
            {
                Value = Constants.AbsoluteZeroInCelsius;
                return;
            }

            Value = Converter.Kel2Cel(TemperatureUnitParser.Parse(value)?.ToKelvin()?.Value ?? Constants.AbsoluteZeroInKelvin);
        }

        /// <summary>
        /// Initializes a new instance of Celsius class using a double value.
        /// </summary>
        /// <param name="value">An initialization value in the Celsius scale.</param>
        public Celsius(double value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets a temperature value in the Celsius scale.
        /// </summary>
        public sealed override double Value
        {
            get => base.Value;
            set
            {
                if (value < Constants.AbsoluteZeroInCelsius)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Input value is below the Celsius scale range.");
                }

                base.Value = value;
            }
        }

        /// <summary>
        /// Gets an array of the Celsius unit identifications for a in-string scale matching.
        /// </summary>
        public override string[] RegexPatterns { get; protected set; } = { "C", "Cel", "Celsius", "celsius" };

        /// <summary>
        /// Return stored temperature value in the Kelvin scale.
        /// </summary>
        /// <returns>A stored Celsius value transformed to Kelvin.</returns>
        protected override double GetValueInKelvin()
        {
            return Converter.Cel2Kel(Value);
        }

        #region Interface implementation

        /// <summary>
        /// Returns the stored temperature in Kelvin.
        /// </summary>
        /// <returns>A value in Kelvin.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Kelvin ToKelvin()
        {
            return new Kelvin(Converter.Cel2Kel(Value));
        }

        /// <summary>
        /// Returns the stored temperature in Celsius, aka itself.
        /// </summary>
        /// <returns>A value in Celsius (a reference to itself).</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        /// <remarks>Interface is implemented because of +/- implementation.</remarks>
        public Celsius ToCelsius()
        {
            return this;
        }

        /// <summary>
        /// Returns the stored temperature in [°] Fahrenheit.
        /// </summary>
        /// <returns>A value in [°] Fahrenheit.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Fahrenheit ToFahrenheit()
        {
            return new Fahrenheit(Converter.Cel2Fah(Value));
        }

        /// <summary>
        /// Returns the stored temperature in [°] Rankine.
        /// </summary>
        /// <returns>A value in [°] Rankine.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Rankine ToRankine()
        {
            return new Rankine(Converter.Cel2Ran(Value));
        }

        /// <summary>
        /// Returns the stored temperature in [°] Delisle.
        /// </summary>
        /// <returns>A value in [°] Delisle.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Delisle ToDelisle()
        {
            return new Delisle(Converter.Cel2Del(Value));
        }

        /// <summary>
        /// Returns the stored temperature in [°] Newton.
        /// </summary>
        /// <returns>A value in [°] Newton.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Newton ToNewton()
        {
            return new Newton(Converter.Cel2New(Value));
        }

        /// <summary>
        /// Returns the stored temperature in [°] Réaumur.
        /// </summary>
        /// <returns>A value in [°] Réaumur.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Réaumur ToRéaumur()
        {
            return new Réaumur(Converter.Cel2Réau(Value));
        }

        /// <summary>
        /// Returns the stored temperature in [°] Rømer.
        /// </summary>
        /// <returns>A value in Rømer.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Rømer ToRømer()
        {
            return new Rømer(Converter.Cel2Røm(Value));
        }
        #endregion

        #region Static methods

        /// <summary>
        /// Returns an entry temperature in Kelvin.
        /// </summary>
        /// <returns>A value in Kelvin.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Kelvin ToKelvin(double value)
        {
            return new Kelvin(Converter.Cel2Kel(new Celsius(value).Value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Fahrenheit.
        /// </summary>
        /// <returns>A value in [°] Fahrenheit.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Fahrenheit ToFahrenheit(double value)
        {
            return new Fahrenheit(Converter.Cel2Fah(new Celsius(value).Value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Rankine.
        /// </summary>
        /// <returns>A value in [°] Rankine.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Rankine ToRankine(double value)
        {
            return new Rankine(Converter.Cel2Ran(new Celsius(value).Value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Delisle.
        /// </summary>
        /// <returns>A value in [°] Delisle.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Delisle ToDelisle(double value)
        {
            return new Delisle(Converter.Cel2Del(new Celsius(value).Value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Newton.
        /// </summary>
        /// <returns>A value in [°] Newton.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Newton ToNewton(double value)
        {
            return new Newton(Converter.Cel2New(new Celsius(value).Value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Réaumur.
        /// </summary>
        /// <returns>A value in [°] Réaumur.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Réaumur ToRéaumur(double value)
        {
            return new Réaumur(Converter.Cel2Réau(new Celsius(value).Value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Rømer.
        /// </summary>
        /// <returns>A value in Rømer.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Rømer ToRømer(double value)
        {
            return new Rømer(Converter.Cel2Røm(new Celsius(value).Value));
        }

        /// <summary>
        /// Returns an entry temperature in Kelvin.
        /// </summary>
        /// <returns>A value in Kelvin.</returns>
        /// <remarks>Use .Value property to get IConversionToKelvin temp.</remarks>
        public static Kelvin ToKelvin(IConversionToKelvin temp)
        {
            return new Kelvin((temp.ToKelvin().Value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Fahrenheit.
        /// </summary>
        /// <returns>A value in [°] Fahrenheit.</returns>
        /// <remarks>Use .Value property to get IConversionToKelvin temp.</remarks>
        public static Fahrenheit ToFahrenheit(IConversionToKelvin temp)
        {
            return new Fahrenheit(Converter.Kel2Fah(temp.ToKelvin().Value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Rankine.
        /// </summary>
        /// <returns>A value in [°] Rankine.</returns>
        /// <remarks>Use .Value property to get IConversionToKelvin temp.</remarks>
        public static Rankine ToRankine(IConversionToKelvin temp)
        {
            return new Rankine(Converter.Kel2Ran(temp.ToKelvin().Value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Delisle.
        /// </summary>
        /// <returns>A value in [°] Delisle.</returns>
        /// <remarks>Use .Value property to get IConversionToKelvin temp.</remarks>
        public static Delisle ToDelisle(IConversionToKelvin temp)
        {
            return new Delisle(Converter.Kel2Del(temp.ToKelvin().Value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Newton.
        /// </summary>
        /// <returns>A value in [°] Newton.</returns>
        /// <remarks>Use .Value property to get IConversionToKelvin temp.</remarks>
        public static Newton ToNewton(IConversionToKelvin temp)
        {
            return new Newton(Converter.Kel2New(temp.ToKelvin().Value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Réaumur.
        /// </summary>
        /// <returns>A value in [°] Réaumur.</returns>
        /// <remarks>Use .Value property to get IConversionToKelvin temp.</remarks>
        public static Réaumur ToRéaumur(IConversionToKelvin temp)
        {
            return new Réaumur(Converter.Kel2Réau(temp.ToKelvin().Value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Rømer.
        /// </summary>
        /// <returns>A value in Rømer.</returns>
        /// <remarks>Use .Value property to get IConversionToKelvin temp.</remarks>
        public static Rømer ToRømer(IConversionToKelvin temp)
        {
            return new Rømer(Converter.Kel2Røm(temp.ToKelvin().Value));
        }

        #endregion

        #region Operators

        /// <summary>
        /// Adds a Celsius scale unit with any another temperature scale unit.
        /// </summary>
        /// <param name="celsius">A temperature in Celsius.</param>
        /// <param name="b">An object providing a temperature value and a scale type.</param>
        /// <returns>An addition of the Celsius and any another temperature scale unit.</returns>
        public static Celsius operator +(Celsius celsius, IConversionToCelsius b)
        {
            return new Celsius((celsius?.Value ?? Constants.AbsoluteZeroInCelsius) + (b?.ToCelsius()?.Value ?? Constants.AbsoluteZeroInCelsius));
        }

        /// <summary>
        /// Subtract a Celsius scale unit with any another temperature scale unit.
        /// </summary>
        /// <param name="celsius">A temperature in Celsius.</param>
        /// <param name="b">An object providing a temperature value and a scale type.</param>
        /// <returns>An subtraction of the Celsius and any another temperature scale unit.</returns>
        public static Celsius operator -(Celsius celsius, IConversionToCelsius b)
        {
            return new Celsius((celsius?.Value ?? Constants.AbsoluteZeroInCelsius) - (b?.ToCelsius()?.Value ?? Constants.AbsoluteZeroInCelsius));
        }

        #endregion
    }
}