﻿using System;
using UltimateTemperatureLibrary.Interfaces;
using UltimateTemperatureLibrary.Utils;

// Classes related to temperature scales, units, conversion between them, thermodynamic constants etc.
namespace UltimateTemperatureLibrary
{
	/// <summary>
	/// Represents the Kelvin scale unit.
	/// </summary>
	public class Kelvin : TemperatureUnit, IConversionToKelvin, IConversionToCelsius, IConversionToFahrenheit, IConversionToNewton, IConversionToDelisle, IConversionToRankine, IConversionToRéaumur, IConversionToRømer
	{
		/// <summary>
		/// Initializes a new instance of Kelvin class.
		/// <para>Value is set to Absolute zero.</para>
		/// </summary>
		public Kelvin() => Value = Constants.AbsoluteZeroInKelvin;

		/// <summary>
		/// Initializes a new instance of Kelvin class using by shared interface.
		/// <para>Value is set to Absolute zero if null object is passed into constructor.</para>
		/// </summary>
		/// <param name="kelvin">An object that can be converted to the Kelvin unit.</param>
		public Kelvin(IConversionToKelvin kelvin) => Value = kelvin?.ToKelvin()?.Value ?? Constants.AbsoluteZeroInKelvin;

		/// <summary>
		/// Initializes a new instance of Kelvin class using parsing from string.
		/// <para>Kelvin unit is also used when no information about unit is provided in the input string.</para>
		/// <para>Value is set to Absolute zero if null object or invalid string is passed into constructor.</para>
		/// </summary>
		/// <param name="value">A string caring an information about value and unit.</param>
		public Kelvin(string value)
		{
			if (value == null || string.IsNullOrWhiteSpace(value))
			{
				Value = Constants.AbsoluteZeroInKelvin;
				return;
			}

			Value = TemperatureUnitParser.Parse(value)?.ToKelvin()?.Value ?? Constants.AbsoluteZeroInKelvin;
		}

		/// <summary>
		/// Initializes a new instance of Kelvin class using a double value.
		/// </summary>
		/// <param name="value">An initialization value from the Kelvin scale.</param>
		public Kelvin(double value) => Value = value;

		/// <summary>
		/// Gets a temperature value from the Kelvin scale.
		/// </summary>
		public sealed override double Value
		{
			get => base.Value;
			set
			{
				if (value < Constants.AbsoluteZeroInKelvin)
				{
					if (!(Math.Abs(value - Constants.AbsoluteZeroInKelvin) < OperationOverDoublePrecision.HighPrecision))
					{
						throw new ArgumentOutOfRangeException(nameof(value), value, "Kelvin can't be less than zero. Absolute zero = 0 K.");
					}

					base.Value = Constants.AbsoluteZeroInKelvin;
					return;
				}

				base.Value = value;
			}
		}

		/// <summary>
		/// Gets an array of the Kelvin unit identifications for a in-string scale matching.
		/// </summary>
		protected internal override string[] RegexPatterns { get; set; } = { "K", "Kel", "Kelvin", "kel", "kelvin", "KELVIN" };

		/// <summary>
		/// Converts the temperature numeric value of this instance to its equivalent string representation.
		/// </summary>
		/// <returns>The string representation of the value of this instance with the temperature scale identification.</returns>
		public override string ToString() => $"{Value} {RegexPatterns[0]}";

		/// <summary>
		/// Converts the temperature numeric value of this instance to its equivalent string representation using the specified format.
		/// </summary>
		/// <returns>The string representation of the value of this instance with the temperature scale identification.</returns>
		/// <param name="format">A numeric format string.</param>
		public new string ToString(string format) => $"{Value.ToString(format)} {RegexPatterns[0]}";

		/// <summary>
		/// Converts the temperature numeric value of this instance to its equivalent string representation using the specified culture-specific format information.
		/// </summary>
		/// <returns>The string representation of the value of this instance with the temperature scale identification.</returns>
		public new string ToString(IFormatProvider provider) => $"{Value.ToString(provider)} {RegexPatterns[0]}";

		/// <summary>
		/// Converts the temperature numeric value of this instance to its equivalent string representation using the specified format and culture-specific format information.
		/// </summary>
		/// <returns>The string representation of the value of this instance with the temperature scale identification.</returns>
		/// <param name="format">A numeric format string.</param>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param>
		public new string ToString(string format, IFormatProvider provider) => $"{Value.ToString(format, provider)} °{RegexPatterns[0]}";

		#region Interface implementation

		/// <summary>
		/// Returns the stored temperature in Kelvin, aka itself.
		/// </summary>
		/// <returns>A value in Kelvin (a reference to itself).</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		/// <remarks>Interface is implemented because of +/- implementation.</remarks>
		public Kelvin ToKelvin() => this;

		/// <summary>
		/// Returns the stored temperature in Kelvin.
		/// </summary>
		/// <returns>A value in [°] Celsius.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Celsius ToCelsius() => new Celsius(Converter.Kel2Cel(Value));

		/// <summary>
		/// Returns the stored temperature in [°] Fahrenheit.
		/// </summary>
		/// <returns>A value in [°] Fahrenheit.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Fahrenheit ToFahrenheit() => new Fahrenheit(Converter.Kel2Fah(Value));

		/// <summary>
		/// Returns the stored temperature in [°] Rankine.
		/// </summary>
		/// <returns>A value in [°] Rankine.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Rankine ToRankine() => new Rankine(Converter.Kel2Ran(Value));

		/// <summary>
		/// Returns the stored temperature in [°] Delisle.
		/// </summary>
		/// <returns>A value in [°] Delisle.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Delisle ToDelisle() => new Delisle(Converter.Kel2Del(Value));

		/// <summary>
		/// Returns the stored temperature in [°] Newton.
		/// </summary>
		/// <returns>A value in [°] Newton.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Newton ToNewton() => new Newton(Converter.Kel2New(Value));

		/// <summary>
		/// Returns the stored temperature in [°] Réaumur.
		/// </summary>
		/// <returns>A value in [°] Réaumur.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Réaumur ToRéaumur() => new Réaumur(Converter.Kel2Réau(Value));

		/// <summary>
		/// Returns the stored temperature in [°] Rømer.
		/// </summary>
		/// <returns>A value in Rømer.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Rømer ToRømer() => new Rømer(Converter.Kel2Røm(Value));

		#endregion

		#region Static methods

		/// <summary>
		/// Returns an entry temperature in Kelvin.
		/// </summary>
		/// <param name="kelvin">An input temperature object that can be converter to the Kelvin unit.</param>
		/// <returns>A value in Kelvin.</returns>
		/// <remarks>Use .Value property to get temperature as double.</remarks>
		public static new Kelvin ToKelvin(IConversionToKelvin kelvin) => kelvin is Kelvin validKelvin ? validKelvin : new Kelvin(kelvin);

		/// <summary>
		/// Returns an entry temperature in [°] Celsius.
		/// </summary>
		/// <param name="value">An input double value in Kelvin.</param>
		/// <returns>A value [°] Celsius.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Celsius ToCelsius(double value) => new Celsius(Converter.Kel2Cel(value));

		/// <summary>
		/// Returns an entry temperature in [°] Fahrenheit.
		/// </summary>
		/// <param name="value">An input double value in Kelvin.</param>
		/// <returns>A value in [°] Fahrenheit.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Fahrenheit ToFahrenheit(double value) => new Fahrenheit(Converter.Kel2Fah(value));

		/// <summary>
		/// Returns an entry temperature in [°] Rankine.
		/// </summary>
		/// <param name="value">An input double value in Kelvin.</param>
		/// <returns>A value in [°] Rankine.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Rankine ToRankine(double value) => new Rankine(Converter.Kel2Ran(value));

		/// <summary>
		/// Returns an entry temperature in [°] Delisle.
		/// </summary>
		/// <param name="value">An input double value in Kelvin.</param>
		/// <returns>A value in [°] Delisle.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Delisle ToDelisle(double value) => new Delisle(Converter.Kel2Del(value));

		/// <summary>
		/// Returns an entry temperature in [°] Newton.
		/// </summary>
		/// <param name="value">An input double value in Kelvin.</param>
		/// <returns>A value in [°] Newton.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Newton ToNewton(double value) => new Newton(Converter.Kel2New(value));

		/// <summary>
		/// Returns an entry temperature in [°] Réaumur.
		/// </summary>
		/// <param name="value">An input double value in Kelvin.</param>
		/// <returns>A value in [°] Réaumur.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Réaumur ToRéaumur(double value) => new Réaumur(Converter.Kel2Réau(value));

		/// <summary>
		/// Returns an entry temperature in [°] Rømer.
		/// </summary>
		/// <param name="value">An input double value in Kelvin.</param>
		/// <returns>A value in Rømer.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Rømer ToRømer(double value) => new Rømer(Converter.Kel2Røm(value));

		#endregion

		#region Operators

		/// <summary>
		/// Adds a Kelvin scale unit with any another temperature scale unit.
		/// </summary>
		/// <param name="kelvin">A temperature in Kelvin.</param>
		/// <param name="b">An object providing a temperature value and a scale type.</param>
		/// <returns>An addition of the Kelvin and any another temperature scale unit.</returns>
		public static Kelvin operator +(Kelvin kelvin, IConversionToKelvin b) => new Kelvin((kelvin?.Value ?? Constants.AbsoluteZeroInKelvin) + (b?.ToKelvin()?.Value ?? Constants.AbsoluteZeroInKelvin));

		/// <summary>
		/// Subtract a Kelvin scale unit with any another temperature scale unit.
		/// </summary>
		/// <param name="kelvin">A temperature in Kelvin.</param>
		/// <param name="b">An object providing a temperature value and a scale type.</param>
		/// <returns>An subtraction of the Kelvin and any another temperature scale unit.</returns>
		public static Kelvin operator -(Kelvin kelvin, IConversionToKelvin b) => new Kelvin((kelvin?.Value ?? Constants.AbsoluteZeroInKelvin) - (b?.ToKelvin()?.Value ?? Constants.AbsoluteZeroInKelvin));

		#endregion
	}
}