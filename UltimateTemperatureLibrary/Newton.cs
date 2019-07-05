using System;
using UltimateTemperatureLibrary.Interfaces;
using UltimateTemperatureLibrary.Utils;

// Classes related to temperature scales, units, conversion between them, thermodynamic constants etc.
namespace UltimateTemperatureLibrary
{
    /// <summary>
    /// Represents the Newton scale unit.
    /// </summary>
    public class Newton : TemperatureUnit, IConversionToKelvin, IConversionToCelsius, IConversionToFahrenheit, IConversionToNewton, IConversionToDelisle, IConversionToRankine, IConversionToRéaumur, IConversionToRømer
    {
        /// <summary>
        /// Initializes a new instance of Newton class.
        /// <para>Value is set to Absolute zero.</para>
        /// </summary>
        public Newton()
        {
            Value = Constants.AbsoluteZeroInNewton;
        }

        /// <summary>
        /// Initializes a new instance of Newton class using by shared interface.
        /// <para>Value is set to Absolute zero if null object is passed into constructor.</para>
        /// </summary>
        /// <param name="newton">An object that can be converted to the Newton unit.</param>
        public Newton(IConversionToNewton newton)
        {
            Value = newton?.ToNewton()?.Value ?? Constants.AbsoluteZeroInNewton;
        }

        /// <summary>
        /// Initializes a new instance of Newton class using parsing from string.
        /// <para>Kelvin unit is used when no information about unit is provided in the input string.</para>
        /// <para>Value is set to Absolute zero if null object or invalid string is passed into constructor.</para>
        /// </summary>
        /// <param name="value">A string caring an information about value and unit.</param>
        public Newton(string value)
        {
            if (value == null || String.IsNullOrWhiteSpace(value))
            {
                Value = Constants.AbsoluteZeroInNewton;
                return;
            }

            Value = Converter.Kel2Cel(TemperatureUnitParser.Parse(value)?.ToKelvin()?.Value ?? Constants.AbsoluteZeroInKelvin);
        }

        /// <summary>
        /// Initializes a new instance of Newton class using a double value.
        /// </summary>
        /// <param name="value">An initialization value from the Newton scale.</param>
        public Newton(double value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets a temperature value from the Newton scale.
        /// </summary>
        public sealed override double Value
        {
            get => base.Value;
            set
            {
                if (value < Constants.AbsoluteZeroInNewton)
                {
                    if (!(Math.Abs(value - Constants.AbsoluteZeroInNewton) < OperationOverDoublePrecision.HighPrecision))
                    {
                        throw new ArgumentOutOfRangeException(nameof(value), value, "Input value is below the Newton scale range.");
                    }

                    base.Value = Constants.AbsoluteZeroInNewton;
                    return;
                }

                base.Value = value;
            }
        }

        /// <summary>
        /// Gets an array of the Newton unit identifications for a in-string scale matching.
        /// </summary>
        public override string[] RegexPatterns { get; protected set; } = { "N", "Newton", "newton", "NEWTON" };

        #region Interface implementation

        /// <summary>
        /// Returns the stored temperature in Kelvin.
        /// </summary>
        /// <returns>A value in Kelvin.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Kelvin ToKelvin()
        {
            return new Kelvin(Converter.New2Kel(Value));
        }

        /// <summary>
        /// Returns the stored temperature in [°] Celsius.
        /// </summary>
        /// <returns>A value in [°] Celsius.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Celsius ToCelsius()
        {
            return new Celsius(Converter.New2Cel(Value));
        }

        /// <summary>
        /// Returns the stored temperature in [°] Fahrenheit.
        /// </summary>
        /// <returns>A value in [°] Fahrenheit.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Fahrenheit ToFahrenheit()
        {
            return new Fahrenheit(Converter.New2Fah(Value));
        }

        /// <summary>
        /// Returns the stored temperature in [°] Rankine.
        /// </summary>
        /// <returns>A value in [°] Rankine.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Rankine ToRankine()
        {
            return new Rankine(Converter.New2Ran(Value));
        }

        /// <summary>
        /// Returns the stored temperature in [°] Delisle.
        /// </summary>
        /// <returns>A value in [°] Delisle.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Delisle ToDelisle()
        {
            return new Delisle(Converter.New2Del(Value));
        }

        /// <summary>
        /// Returns the stored temperature in [°] Newton, aka itself.
        /// </summary>
        /// <returns>A value in [°] Newton (a reference to itself).</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        /// <remarks>Interface is implemented because of +/- implementation.</remarks>
        public Newton ToNewton()
        {
            return this;
        }

        /// <summary>
        /// Returns the stored temperature in [°] Réaumur.
        /// </summary>
        /// <returns>A value in [°] Réaumur.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Réaumur ToRéaumur()
        {
            return new Réaumur(Converter.New2Réau(Value));
        }

        /// <summary>
        /// Returns the stored temperature in [°] Rømer.
        /// </summary>
        /// <returns>A value in Rømer.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Rømer ToRømer()
        {
            return new Rømer(Converter.New2Røm(Value));
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns an entry temperature in Kelvin.
        /// </summary>
        /// <param name="value">An input double value in [°] Newton.</param>
        /// <returns>A value in Kelvin.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Kelvin ToKelvin(double value)
        {
            return new Kelvin(Converter.New2Kel(value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Celsius.
        /// </summary>
        /// <param name="value">An input double value in [°] Newton.</param>
        /// <returns>A value in [°] Celsius.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Celsius ToCelsius(double value)
        {
            return new Celsius(Converter.New2Cel(value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Fahrenheit.
        /// </summary>
        /// <param name="value">An input double value in [°] Newton.</param>
        /// <returns>A value in [°] Fahrenheit.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Fahrenheit ToFahrenheit(double value)
        {
            return new Fahrenheit(Converter.New2Fah(value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Rankine.
        /// </summary>
        /// <param name="value">An input double value in [°] Newton.</param>
        /// <returns>A value in [°] Rankine.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Rankine ToRankine(double value)
        {
            return new Rankine(Converter.New2Ran(value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Delisle.
        /// </summary>
        /// <param name="value">An input double value in [°] Newton.</param>
        /// <returns>A value in [°] Delisle.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Delisle ToDelisle(double value)
        {
            return new Delisle(Converter.New2Del(value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Newton.
        /// </summary>
        /// <param name="newton">An input temperature object that can be converter to the Newton unit.</param>
        /// <returns>A value in [°] Newton.</returns>
        /// <remarks>Use .Value property to get temperature as double.</remarks>
        public static new Newton ToNewton(IConversionToNewton newton)
        {
            if (newton is Newton validNewton)
            {
                return validNewton;
            }
            return new Newton(newton);
        }

        /// <summary>
        /// Returns an entry temperature in [°] Réaumur.
        /// </summary>
        /// <param name="value">An input double value in [°] Newton.</param>
        /// <returns>A value in [°] Réaumur.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Réaumur ToRéaumur(double value)
        {
            return new Réaumur(Converter.New2Réau(value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Rømer.
        /// </summary>
        /// <param name="value">An input double value in [°] Newton.</param>
        /// <returns>A value in Rømer.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Rømer ToRømer(double value)
        {
            return new Rømer(Converter.New2Røm(value));
        }

        #endregion

        #region Operators

        /// <summary>
        /// Adds a Newton scale unit with any another temperature scale unit.
        /// </summary>
        /// <param name="newton">A temperature in Newton.</param>
        /// <param name="b">An object providing a temperature value and a scale type.</param>
        /// <returns>An addition of the Newton and any another temperature scale unit.</returns>
        public static Newton operator +(Newton newton, IConversionToNewton b)
        {
            return new Newton((newton?.Value ?? Constants.AbsoluteZeroInNewton) + (b?.ToNewton()?.Value ?? 0.0));
        }

        /// <summary>
        /// Subtract a Newton scale unit with any another temperature scale unit.
        /// </summary>
        /// <param name="newton">A temperature in Newton.</param>
        /// <param name="b">An object providing a temperature value and a scale type.</param>
        /// <returns>An subtraction of the Newton and any another temperature scale unit.</returns>
        public static Newton operator -(Newton newton, IConversionToNewton b)
        {
            return new Newton((newton?.Value ?? Constants.AbsoluteZeroInNewton) - (b?.ToNewton()?.Value ?? 0.0));
        }

        #endregion
    }
}