using System;
using UltimateTemperatureLibrary.Interfaces;
using UltimateTemperatureLibrary.Utils;

// Classes related to temperature scales, units, conversion between them, thermodynamic constants etc.
namespace UltimateTemperatureLibrary
{
    /// <summary>
    /// Represents the Rankine scale unit.
    /// </summary>
    public class Rankine : TemperatureUnit, IConversionToKelvin, IConversionToCelsius, IConversionToFahrenheit, IConversionToNewton, IConversionToDelisle, IConversionToRankine, IConversionToRéaumur, IConversionToRømer
    {
        /// <summary>
        /// Initializes a new instance of Rankine class.
        /// <para>Value is set to Absolute zero.</para>
        /// </summary>
        public Rankine()
        {
            Value = Constants.AbsoluteZeroInRankine;
        }

        /// <summary>
        /// Initializes a new instance of Rankine class using by shared interface.
        /// <para>Value is set to Absolute zero if null object is passed into constructor.</para>
        /// </summary>
        /// <param name="rankine">An object that can be converted to the Rankine unit.</param>
        public Rankine(IConversionToRankine rankine)
        {
            Value = rankine?.ToRankine()?.Value ?? Constants.AbsoluteZeroInRankine;
        }

        /// <summary>
        /// Initializes a new instance of Rankine class using parsing from string.
        /// <para>Kelvin unit is used when no information about unit is provided in the input string.</para>
        /// <para>Value is set to Absolute zero if null object or invalid string is passed into constructor.</para>
        /// </summary>
        /// <param name="value">A string caring an information about value and unit.</param>
        public Rankine(string value)
        {
            if (value == null || String.IsNullOrWhiteSpace(value))
            {
                Value = Constants.AbsoluteZeroInRankine;
                return;
            }

            Value = Converter.Kel2Cel(TemperatureUnitParser.Parse(value)?.ToKelvin()?.Value ?? Constants.AbsoluteZeroInKelvin);
        }

        /// <summary>
        /// Initializes a new instance of Rankine class using a double value.
        /// </summary>
        /// <param name="value">An initialization value from the Rankine scale.</param>
        public Rankine(double value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets a temperature value from the Rankine scale.
        /// </summary>
        public sealed override double Value
        {
            get => base.Value;
            set
            {
                if (value < Constants.AbsoluteZeroInRankine)
                {
                    if (!(Math.Abs(value - Constants.AbsoluteZeroInRankine) < OperationOverDoublePrecision.HighPrecision))
                    {
                        throw new ArgumentOutOfRangeException(nameof(value), value, "Input value is below the Rankine scale range.");
                    }

                    base.Value = Constants.AbsoluteZeroInRankine;
                    return;
                }

                base.Value = value;
            }
        }

        /// <summary>
        /// Gets an array of the Rankine unit identifications for a in-string scale matching.
        /// </summary>
        public override string[] RegexPatterns { get; protected set; } = { "R", "Ra", "Ran", "Rankine", "ra", "ran", "rankine", "RANKINE" };

        #region Interface implementation

        /// <summary>
        /// Returns the stored temperature in Kelvin.
        /// </summary>
        /// <returns>A value in Kelvin.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Kelvin ToKelvin()
        {
            return new Kelvin(Converter.Ran2Kel(Value));
        }

        /// <summary>
        /// Returns the stored temperature in [°] Celsius.
        /// </summary>
        /// <returns>A value in [°] Celsius.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Celsius ToCelsius()
        {
            return new Celsius(Converter.Ran2Cel(Value));
        }

        /// <summary>
        /// Returns the stored temperature in [°] Fahrenheit.
        /// </summary>
        /// <returns>A value in [°] Fahrenheit.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Fahrenheit ToFahrenheit()
        {
            return new Fahrenheit(Converter.Ran2Fah(Value));
        }

        /// <summary>
        /// Returns the stored temperature in [°] Rankine, aka itself.
        /// </summary>
        /// <returns>A value in [°] Rankine (a reference to itself).</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        /// <remarks>Interface is implemented because of +/- implementation.</remarks>
        public Rankine ToRankine()
        {
            return this;
        }

        /// <summary>
        /// Returns the stored temperature in [°] Delisle.
        /// </summary>
        /// <returns>A value in [°] Delisle.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Delisle ToDelisle()
        {
            return new Delisle(Converter.Ran2Del(Value));
        }

        /// <summary>
        /// Returns the stored temperature in [°] Newton.
        /// </summary>
        /// <returns>A value in [°] Newton.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Newton ToNewton()
        {
            return new Newton(Converter.Ran2New(Value));
        }

        /// <summary>
        /// Returns the stored temperature in [°] Réaumur.
        /// </summary>
        /// <returns>A value in [°] Réaumur.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Réaumur ToRéaumur()
        {
            return new Réaumur(Converter.Ran2Réau(Value));
        }

        /// <summary>
        /// Returns the stored temperature in [°] Rømer.
        /// </summary>
        /// <returns>A value in Rømer.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Rømer ToRømer()
        {
            return new Rømer(Converter.Ran2Røm(Value));
        }
        #endregion

        #region Static methods

        /// <summary>
        /// Returns an entry temperature in Kelvin.
        /// </summary>
        /// <param name="value">An input double value in [°] Rankine.</param>
        /// <returns>A value in Kelvin.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Kelvin ToKelvin(double value)
        {
            return new Kelvin(Converter.Ran2Kel(value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Celsius.
        /// </summary>
        /// <param name="value">An input double value in [°] Celsius.</param>
        /// <returns>A value in [°] Rankine.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Celsius ToCelsius(double value)
        {
            return new Celsius(Converter.Ran2Cel(value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Fahrenheit.
        /// </summary>
        /// <param name="value">An input double value in [°] Rankine.</param>
        /// <returns>A value in [°] Fahrenheit.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Fahrenheit ToFahrenheit(double value)
        {
            return new Fahrenheit(Converter.Ran2Fah(value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Rankine.
        /// </summary>
        /// <param name="rankine">An input temperature object that can be converter to the Rankine unit.</param>
        /// <returns>A value in [°] Rankine.</returns>
        /// <remarks>Use .Value property to get temperature as double.</remarks>
        public static new Rankine ToRankine(IConversionToRankine rankine)
        {
            if (rankine is Rankine validRankine)
            {
                return validRankine;
            }
            return new Rankine(rankine);
        }

        /// <summary>
        /// Returns an entry temperature in [°] Delisle.
        /// </summary>
        /// <param name="value">An input double value in [°] Rankine.</param>
        /// <returns>A value in [°] Delisle.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Delisle ToDelisle(double value)
        {
            return new Delisle(Converter.Ran2Del(value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Newton.
        /// </summary>
        /// <param name="value">An input double value in [°] Rankine.</param>
        /// <returns>A value in [°] Newton.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Newton ToNewton(double value)
        {
            return new Newton(Converter.Ran2New(value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Réaumur.
        /// </summary>
        /// <param name="value">An input double value in [°] Rankine.</param>
        /// <returns>A value in [°] Réaumur.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Réaumur ToRéaumur(double value)
        {
            return new Réaumur(Converter.Ran2Réau(value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Rømer.
        /// </summary>
        /// <param name="value">An input double value in [°] Rankine.</param>
        /// <returns>A value in Rømer.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Rømer ToRømer(double value)
        {
            return new Rømer(Converter.Ran2Røm(value));
        }

        #endregion

        #region Operators

        /// <summary>
        /// Adds a Rankine scale unit with any another temperature scale unit.
        /// </summary>
        /// <param name="rankine">A temperature in Rankine.</param>
        /// <param name="b">An object providing a temperature value and a scale type.</param>
        /// <returns>An addition of the Rankine and any another temperature scale unit.</returns>
        public static Rankine operator +(Rankine rankine, IConversionToRankine b)
        {
            return new Rankine((rankine?.Value ?? Constants.AbsoluteZeroInRankine) + (b?.ToRankine()?.Value ?? 0.0));
        }

        /// <summary>
        /// Subtract a Rankine scale unit with any another temperature scale unit.
        /// </summary>
        /// <param name="rankine">A temperature in Rankine.</param>
        /// <param name="b">An object providing a temperature value and a scale type.</param>
        /// <returns>An subtraction of the Rankine and any another temperature scale unit.</returns>
        public static Rankine operator -(Rankine rankine, IConversionToRankine b)
        {
            return new Rankine((rankine?.Value ?? Constants.AbsoluteZeroInRankine) - (b?.ToRankine()?.Value ?? 0.0));
        }

        #endregion
    }
}