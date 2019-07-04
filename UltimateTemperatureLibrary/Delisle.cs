using System;
using UltimateTemperatureLibrary.Interfaces;
using UltimateTemperatureLibrary.Utils;

// Classes related to temperature scales, units, conversion between them, thermodynamic constants etc.
namespace UltimateTemperatureLibrary
{
    /// <summary>
    /// Represents the Delisle scale unit.
    /// </summary>
    public class Delisle : TemperatureUnit, IConversionToKelvin, IConversionToCelsius, IConversionToFahrenheit, IConversionToNewton, IConversionToDelisle, IConversionToRankine, IConversionToRéaumur, IConversionToRømer
    {
        /// <summary>
        /// Initializes a new instance of Delisle class.
        /// <para>Value is set to Absolute zero.</para>
        /// </summary>
        public Delisle()
        {
            Value = Constants.AbsoluteZeroInDelisle;
        }

        /// <summary>
        /// Initializes a new instance of Delisle class using by shared interface.
        /// <para>Value is set to Absolute zero if null object is passed into constructor.</para>
        /// </summary>
        /// <param name="delisle">An object that can be converted to the Delisle unit.</param>
        public Delisle(IConversionToDelisle delisle)
        {
            Value = delisle?.ToDelisle()?.Value ?? Constants.AbsoluteZeroInDelisle;
        }

        /// <summary>
        /// Initializes a new instance of Delisle class using parsing from string.
        /// <para>Kelvin unit is used when no information about unit is provided in the input string.</para>
        /// <para>Value is set to Absolute zero if null object or invalid string is passed into constructor.</para>
        /// </summary>
        /// <param name="value">A string caring an information about value and unit.</param>
        public Delisle(string value)
        {
            if (value == null || String.IsNullOrWhiteSpace(value))
            {
                Value = Constants.AbsoluteZeroInDelisle;
                return;
            }

            Value = Converter.Kel2Cel(TemperatureUnitParser.Parse(value)?.ToKelvin()?.Value ?? Constants.AbsoluteZeroInKelvin);
        }

        /// <summary>
        /// Initializes a new instance of Delisle class using a double value.
        /// </summary>
        /// <param name="value">An initialization value from the Delisle scale.</param>
        public Delisle(double value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets a temperature value from the Delisle scale.
        /// </summary>
        public sealed override double Value
        {
            get => base.Value;
            set
            {
                if (value > Constants.AbsoluteZeroInDelisle)
                {
                    if (!(Math.Abs(value - Constants.AbsoluteZeroInDelisle) < OperationOverDoublePrecision.HighPrecision))
                    {
                        throw new ArgumentOutOfRangeException(nameof(value), value, "Input value is below the Delisle scale range.");
                    }

                    base.Value = Constants.AbsoluteZeroInDelisle;
                    return;
                }

                base.Value = value;
            }
        }

        /// <summary>
        /// Gets an array of the Delisle unit identifications for a in-string scale matching.
        /// </summary>
        public override string[] RegexPatterns { get; protected set; } = { "D", "De", "d", "de" };

        #region Interface implementation

        /// <summary>
        /// Returns the stored temperature in Kelvin.
        /// </summary>
        /// <returns>A value in Kelvin.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Kelvin ToKelvin()
        {
            return new Kelvin(Converter.Del2Kel(Value));
        }

        /// <summary>
        /// Returns the stored temperature in [°] Celsius.
        /// </summary>
        /// <returns>A value in [°] Celsius.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Celsius ToCelsius()
        {
            return new Celsius(Converter.Del2Cel(Value));
        }

        /// <summary>
        /// Returns the stored temperature in [°] Fahrenheit.
        /// </summary>
        /// <returns>A value in [°] Fahrenheit.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Fahrenheit ToFahrenheit()
        {
            return new Fahrenheit(Converter.Del2Fah(Value));
        }

        /// <summary>
        /// Returns the stored temperature in [°] Rankine.
        /// </summary>
        /// <returns>A value in [°] Rankine.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Rankine ToRankine()
        {
            return new Rankine(Converter.Del2Ran(Value));
        }

        /// <summary>
        /// Returns the stored temperature in [°] Delisle, aka itself.
        /// </summary>
        /// <returns>A value in [°] Delisle (a reference to itself).</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        /// <remarks>Interface is implemented because of +/- implementation.</remarks>
        public Delisle ToDelisle()
        {
            return this;
        }

        /// <summary>
        /// Returns the stored temperature in [°] Newton.
        /// </summary>
        /// <returns>A value in [°] Newton.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Newton ToNewton()
        {
            return new Newton(Converter.Del2New(Value));
        }

        /// <summary>
        /// Returns the stored temperature in [°] Réaumur.
        /// </summary>
        /// <returns>A value in [°] Réaumur.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Réaumur ToRéaumur()
        {
            return new Réaumur(Converter.Del2Réau(Value));
        }

        /// <summary>
        /// Returns the stored temperature in [°] Rømer.
        /// </summary>
        /// <returns>A value in Rømer.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Rømer ToRømer()
        {
            return new Rømer(Converter.Del2Røm(Value));
        }
        #endregion

        #region Static methods

        /// <summary>
        /// Returns an entry temperature in Kelvin.
        /// </summary>
        /// <param name="value">An input double value in [°] Delisle.</param>
        /// <returns>A value in Kelvin.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Kelvin ToKelvin(double value)
        {
            return new Kelvin(Converter.Del2Kel(value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Celsius.
        /// </summary>
        /// <param name="value">An input double value in [°] Delisle.</param>
        /// <returns>A value in [°] Celsius.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Celsius ToCelsius(double value)
        {
            return new Celsius(Converter.Del2Cel(value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Fahrenheit.
        /// </summary>
        /// <param name="value">An input double value in [°] Delisle.</param>
        /// <returns>A value in [°] Fahrenheit.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Fahrenheit ToFahrenheit(double value)
        {
            return new Fahrenheit(Converter.Del2Fah(value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Rankine.
        /// </summary>
        /// <param name="value">An input double value in [°] Delisle.</param>
        /// <returns>A value in [°] Rankine.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Rankine ToRankine(double value)
        {
            return new Rankine(Converter.Del2Ran(value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Delisle.
        /// </summary>
        /// <param name="delisle">An input temperature object that can be converter to the Delisle unit.</param>
        /// <returns>A value in [°] Delisle.</returns>
        /// <remarks>Use .Value property to get temperature as double.</remarks>
        public static new Delisle ToDelisle(IConversionToDelisle delisle)
        {
            if (delisle is Delisle validDelisle)
            {
                return validDelisle;
            }
            return new Delisle(delisle);
        }

        /// <summary>
        /// Returns an entry temperature in [°] Newton.
        /// </summary>
        /// <param name="value">An input double value in [°] Delisle.</param>
        /// <returns>A value in [°] Newton.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Newton ToNewton(double value)
        {
            return new Newton(Converter.Del2New(value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Réaumur.
        /// </summary>
        /// <param name="value">An input double value in [°] Delisle.</param>
        /// <returns>A value in [°] Réaumur.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Réaumur ToRéaumur(double value)
        {
            return new Réaumur(Converter.Del2Réau(value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Rømer.
        /// </summary>
        /// <param name="value">An input double value in [°] Delisle.</param>
        /// <returns>A value in Rømer.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Rømer ToRømer(double value)
        {
            return new Rømer(Converter.Del2Røm(value));
        }

        #endregion

        #region Operators

        /// <summary>
        /// Adds a Delisle scale unit with any another temperature scale unit.
        /// </summary>
        /// <param name="delisle">A temperature in Delisle.</param>
        /// <param name="b">An object providing a temperature value and a scale type.</param>
        /// <returns>An addition of the Delisle and any another temperature scale unit.</returns>
        public static Delisle operator +(Delisle delisle, IConversionToDelisle b)
        {
            return new Delisle((delisle?.Value ?? Constants.AbsoluteZeroInDelisle) + (b?.ToDelisle()?.Value ?? 0.0));
        }

        /// <summary>
        /// Subtract a Delisle scale unit with any another temperature scale unit.
        /// </summary>
        /// <param name="delisle">A temperature in Delisle.</param>
        /// <param name="b">An object providing a temperature value and a scale type.</param>
        /// <returns>An subtraction of the Delisle and any another temperature scale unit.</returns>
        public static Delisle operator -(Delisle delisle, IConversionToDelisle b)
        {
            return new Delisle((delisle?.Value ?? Constants.AbsoluteZeroInDelisle) - (b?.ToDelisle()?.Value ?? 0.0));
        }

        #endregion
    }
}