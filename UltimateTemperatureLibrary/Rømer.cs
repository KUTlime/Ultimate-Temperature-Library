using System;
using UltimateTemperatureLibrary.Interfaces;
using UltimateTemperatureLibrary.Utils;

// Classes related to temperature scales, units, conversion between them, thermodynamic constants etc.
namespace UltimateTemperatureLibrary
{
	/// <summary>
	/// Represents the Rømer scale unit.
	/// </summary>
	public class Rømer : TemperatureUnit, IConversionToKelvin, IConversionToCelsius, IConversionToFahrenheit, IConversionToNewton, IConversionToDelisle, IConversionToRankine, IConversionToRéaumur, IConversionToRømer
	{
		/// <summary>
		/// Initializes a new instance of Rømer class.
		/// <para>Value is set to Absolute zero.</para>
		/// </summary>
		public Rømer() => Value = Constants.AbsoluteZeroInRømer;

		/// <summary>
		/// Initializes a new instance of Rømer class using by shared interface.
		/// <para>Value is set to Absolute zero if null object is passed into constructor.</para>
		/// </summary>
		/// <param name="rømer">An object that can be converted to the Rømer unit.</param>
		public Rømer(IConversionToRømer rømer) => Value = rømer?.ToRømer()?.Value ?? Constants.AbsoluteZeroInRømer;

		/// <summary>
		/// Initializes a new instance of Rømer class using parsing from string.
		/// <para>Kelvin unit is used when no information about unit is provided in the input string.</para>
		/// <para>Value is set to Absolute zero if null object or invalid string is passed into constructor.</para>
		/// </summary>
		/// <param name="value">A string caring an information about value and unit.</param>
		public Rømer(string value)
		{
			if (value == null || string.IsNullOrWhiteSpace(value))
			{
				Value = Constants.AbsoluteZeroInRømer;
				return;
			}

			Value = Converter.Kel2Røm(TemperatureUnitParser.Parse(value)?.ToKelvin()?.Value ?? Constants.AbsoluteZeroInKelvin);
		}

		/// <summary>
		/// Initializes a new instance of Rømer class using a double value.
		/// </summary>
		/// <param name="value">An initialization value from the Rømer scale.</param>
		public Rømer(double value) => Value = value;

		/// <summary>
		/// Gets a temperature value from the Rømer scale.
		/// </summary>
		public sealed override double Value
		{
			get => base.Value;
			set
			{
				if (value < Constants.AbsoluteZeroInRømer)
				{
					if (!(Math.Abs(value - Constants.AbsoluteZeroInRømer) < OperationOverDoublePrecision.HighPrecision))
					{
						throw new ArgumentOutOfRangeException(nameof(value), value, "Input value is below the Rømer scale range.");
					}

					base.Value = Constants.AbsoluteZeroInRømer;
					return;
				}

				base.Value = value;
			}
		}

		/// <summary>
		/// Gets an array of the Rømer unit identifications for a in-string scale matching.
		/// </summary>
		protected internal override string[] RegexPatterns { get; set; } = { "Rø", "rø", "RØ", "Rømer", "rømer", "RØMER", "Ro", "ro", "Ro", "Romer", "romer", "ROMER" };

		#region Interface implementation

		/// <summary>
		/// Returns the stored temperature in Kelvin.
		/// </summary>
		/// <returns>A value in Kelvin.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Kelvin ToKelvin() => new Kelvin(Converter.Røm2Kel(Value));

		/// <summary>
		/// Returns the stored temperature in [°] Celsius.
		/// </summary>
		/// <returns>A value in Celsius.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Celsius ToCelsius() => new Celsius(Converter.Røm2Cel(Value));

		/// <summary>
		/// Returns the stored temperature in [°] Fahrenheit.
		/// </summary>
		/// <returns>A value in [°] Fahrenheit.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Fahrenheit ToFahrenheit() => new Fahrenheit(Converter.Røm2Fah(Value));

		/// <summary>
		/// Returns the stored temperature in [°] Rankine.
		/// </summary>
		/// <returns>A value in [°] Rankine.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Rankine ToRankine() => new Rankine(Converter.Røm2Ran(Value));

		/// <summary>
		/// Returns the stored temperature in [°] Delisle.
		/// </summary>
		/// <returns>A value in [°] Delisle.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Delisle ToDelisle() => new Delisle(Converter.Røm2Del(Value));

		/// <summary>
		/// Returns the stored temperature in [°] Newton.
		/// </summary>
		/// <returns>A value in [°] Newton.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Newton ToNewton() => new Newton(Converter.Røm2New(Value));

		/// <summary>
		/// Returns the stored temperature in [°] Réaumur.
		/// </summary>
		/// <returns>A value in [°] Réaumur.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Réaumur ToRéaumur() => new Réaumur(Converter.Røm2Réau(Value));

		/// <summary>
		/// Returns the stored temperature in [°] Rømer, aka itself.
		/// </summary>
		/// <returns>A value in [°] Rømer (a reference to itself).</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		/// <remarks>Interface is implemented because of +/- implementation.</remarks>
		public Rømer ToRømer() => this;

		#endregion

		#region Static methods

		/// <summary>
		/// Returns an entry temperature in Kelvin.
		/// </summary>
		/// <param name="value">An input double value in [°] Rømer.</param>
		/// <returns>A value in Kelvin.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Kelvin ToKelvin(double value) => new Kelvin(Converter.Røm2Kel(value));

		/// <summary>
		/// Returns an entry temperature in [°] Celsius.
		/// </summary>
		/// <param name="value">An input double value in [°] Rømer.</param>
		/// <returns>A value in Celsius.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Celsius ToCelsius(double value) => new Celsius(Converter.Røm2Cel(value));

		/// <summary>
		/// Returns an entry temperature in [°] Fahrenheit.
		/// </summary>
		/// <param name="value">An input double value in [°] Rømer.</param>
		/// <returns>A value in [°] Fahrenheit.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Fahrenheit ToFahrenheit(double value) => new Fahrenheit(Converter.Røm2Fah(value));

		/// <summary>
		/// Returns an entry temperature in [°] Rankine.
		/// </summary>
		/// <param name="value">An input double value in [°] Rømer.</param>
		/// <returns>A value in [°] Rankine.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Rankine ToRankine(double value) => new Rankine(Converter.Røm2Ran(value));

		/// <summary>
		/// Returns an entry temperature in [°] Delisle.
		/// </summary>
		/// <param name="value">An input double value in [°] Rømer.</param>
		/// <returns>A value in [°] Delisle.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Delisle ToDelisle(double value) => new Delisle(Converter.Røm2Del(value));

		/// <summary>
		/// Returns an entry temperature in [°] Newton.
		/// </summary>
		/// <param name="value">An input double value in [°] Rømer.</param>
		/// <returns>A value in [°] Newton.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Newton ToNewton(double value) => new Newton(Converter.Røm2New(value));

		/// <summary>
		/// Returns an entry temperature in [°] Réaumur.
		/// </summary>
		/// <param name="value">An input double value in [°] Rømer.</param>
		/// <returns>A value in [°] Réaumur.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Réaumur ToRéaumur(double value) => new Réaumur(Converter.Røm2Réau(value));

		/// <summary>
		/// Returns an entry temperature in [°] Rømer.
		/// </summary>
		/// <param name="rømer">An input temperature object that can be converter to the Rømer unit.</param>
		/// <returns>A value in [°] Rømer.</returns>
		/// <remarks>Use .Value property to get temperature as double.</remarks>
		public static new Rømer ToRømer(IConversionToRømer rømer) => rømer is Rømer validRømer ? validRømer : new Rømer(rømer);

		#endregion

		#region Operators

		/// <summary>
		/// Adds a Rømer scale unit with any another temperature scale unit.
		/// </summary>
		/// <param name="rømer">A temperature in Rømer.</param>
		/// <param name="b">An object providing a temperature value and a scale type.</param>
		/// <returns>An addition of the Rømer and any another temperature scale unit.</returns>
		public static Rømer operator +(Rømer rømer, IConversionToRømer b) =>
			new Rømer(
				(rømer?.Value ?? Constants.AbsoluteZeroInRømer) +
				(b?.ToRømer()?.Value ?? 0.0)
			);

		/// <summary>
		/// Subtract a Rømer scale unit with any another temperature scale unit.
		/// </summary>
		/// <param name="rømer">A temperature in Rømer.</param>
		/// <param name="b">An object providing a temperature value and a scale type.</param>
		/// <returns>An subtraction of the Rømer and any another temperature scale unit.</returns>
		public static Rømer operator -(Rømer rømer, IConversionToRømer b) =>
			new Rømer(
				(rømer?.Value ?? Constants.AbsoluteZeroInRømer) -
				(b?.ToRømer()?.Value ?? 0.0)
			);

		#endregion
	}
}