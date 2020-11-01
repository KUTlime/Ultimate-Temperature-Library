using System;
using UltimateTemperatureLibrary.Interfaces;
using UltimateTemperatureLibrary.Utils;

// Classes related to temperature scales, units, conversion between them, thermodynamic constants etc.
namespace UltimateTemperatureLibrary
{
	/// <summary>
	/// Represents the Réaumur scale unit.
	/// </summary>
	public class Réaumur : TemperatureUnit, IConversionToKelvin, IConversionToCelsius, IConversionToFahrenheit, IConversionToNewton, IConversionToDelisle, IConversionToRankine, IConversionToRéaumur, IConversionToRømer
	{
		/// <summary>
		/// Initializes a new instance of Réaumur class.
		/// <para>Value is set to Absolute zero.</para>
		/// </summary>
		public Réaumur() => Value = Constants.AbsoluteZeroInRéaumur;

		/// <summary>
		/// Initializes a new instance of Réaumur class using by shared interface.
		/// <para>Value is set to Absolute zero if null object is passed into constructor.</para>
		/// </summary>
		/// <param name="réaumur">An object that can be converted to the Réaumur unit.</param>
		public Réaumur(IConversionToRéaumur réaumur) => Value = réaumur?.ToRéaumur()?.Value ?? Constants.AbsoluteZeroInRéaumur;

		/// <summary>
		/// Initializes a new instance of Réaumur class using parsing from string.
		/// <para>Kelvin unit is used when no information about unit is provided in the input string.</para>
		/// <para>Value is set to Absolute zero if null object or invalid string is passed into constructor.</para>
		/// </summary>
		/// <param name="value">A string caring an information about value and unit.</param>
		public Réaumur(string value)
		{
			if (value == null || string.IsNullOrWhiteSpace(value))
			{
				Value = Constants.AbsoluteZeroInRéaumur;
				return;
			}

			Value = Converter.Kel2Réau(TemperatureUnitParser.Parse(value)?.ToKelvin()?.Value ?? Constants.AbsoluteZeroInKelvin);
		}

		/// <summary>
		/// Initializes a new instance of Réaumur class using a double value.
		/// </summary>
		/// <param name="value">An initialization value from the Réaumur scale.</param>
		public Réaumur(double value) => Value = value;

		/// <summary>
		/// Gets a temperature value from the Réaumur scale.
		/// </summary>
		public sealed override double Value
		{
			get => base.Value;
			set
			{
				if (value < Constants.AbsoluteZeroInRéaumur)
				{
					if (!(Math.Abs(value - Constants.AbsoluteZeroInRéaumur) < OperationOverDoublePrecision.HighPrecision))
					{
						throw new ArgumentOutOfRangeException(nameof(value), value, "Input value is below the Réaumur scale range.");
					}

					base.Value = Constants.AbsoluteZeroInRéaumur;
					return;
				}

				base.Value = value;
			}
		}

		/// <summary>
		/// Gets an array of the Réaumur unit identifications for a in-string scale matching.
		/// </summary>
		protected internal override string[] RegexPatterns { get; set; } = { "Re", "Ré", "re", "ré", "Réau", "Reau", "réau", "reau", "RÉAU", "REAU", "Réaumur", "Reaumur", "réaumur", "reaumur", "RÉAUMUR", "REAUMUR" };

		#region Interface implementation

		/// <summary>
		/// Returns the stored temperature in Kelvin.
		/// </summary>
		/// <returns>A value in Kelvin.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Kelvin ToKelvin() => new Kelvin(Converter.Réau2Kel(Value));

		/// <summary>
		/// Returns the stored temperature in [°] Celsius.
		/// </summary>
		/// <returns>A value in [°] Celsius.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Celsius ToCelsius() => new Celsius(Converter.Réau2Cel(Value));

		/// <summary>
		/// Returns the stored temperature in [°] Fahrenheit.
		/// </summary>
		/// <returns>A value in [°] Fahrenheit.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Fahrenheit ToFahrenheit() => new Fahrenheit(Converter.Réau2Fah(Value));

		/// <summary>
		/// Returns the stored temperature in [°] Rankine.
		/// </summary>
		/// <returns>A value in [°] Rankine.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Rankine ToRankine() => new Rankine(Converter.Réau2Ran(Value));

		/// <summary>
		/// Returns the stored temperature in [°] Delisle.
		/// </summary>
		/// <returns>A value in [°] Delisle.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Delisle ToDelisle() => new Delisle(Converter.Réau2Del(Value));

		/// <summary>
		/// Returns the stored temperature in [°] Newton.
		/// </summary>
		/// <returns>A value in [°] Newton.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Newton ToNewton() => new Newton(Converter.Réau2New(Value));

		/// <summary>
		/// Returns the stored temperature in [°] Réaumur, aka itself.
		/// </summary>
		/// <returns>A value in [°] Réaumur (a reference to itself).</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		/// <remarks>Interface is implemented because of +/- implementation.</remarks>
		public Réaumur ToRéaumur() => this;

		/// <summary>
		/// Returns the stored temperature in [°] Rømer.
		/// </summary>
		/// <returns>A value in Rømer.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Rømer ToRømer() => new Rømer(Converter.Réau2Røm(Value));

		#endregion

		#region Static methods

		/// <summary>
		/// Returns an entry temperature in Kelvin.
		/// </summary>
		/// <param name="value">An input double value in [°] Réaumur.</param>
		/// <returns>A value in Kelvin.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Kelvin ToKelvin(double value) => new Kelvin(Converter.Réau2Kel(value));

		/// <summary>
		/// Returns an entry temperature in [°] Celsius.
		/// </summary>
		/// <param name="value">An input double value in [°] Réaumur.</param>
		/// <returns>A value in [°] Celsius.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Celsius ToCelsius(double value) => new Celsius(Converter.Réau2Cel(value));

		/// <summary>
		/// Returns an entry temperature in [°] Fahrenheit.
		/// </summary>
		/// <param name="value">An input double value in [°] Réaumur.</param>
		/// <returns>A value in [°] Fahrenheit.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Fahrenheit ToFahrenheit(double value) => new Fahrenheit(Converter.Réau2Fah(value));

		/// <summary>
		/// Returns an entry temperature in [°] Rankine.
		/// </summary>
		/// <param name="value">An input double value in [°] Réaumur.</param>
		/// <returns>A value in [°] Rankine.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Rankine ToRankine(double value) => new Rankine(Converter.Réau2Ran(value));

		/// <summary>
		/// Returns an entry temperature in [°] Delisle.
		/// </summary>
		/// <param name="value">An input double value in [°] Réaumur.</param>
		/// <returns>A value in [°] Delisle.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Delisle ToDelisle(double value) => new Delisle(Converter.Réau2Del(value));

		/// <summary>
		/// Returns an entry temperature in [°] Newton.
		/// </summary>
		/// <param name="value">An input double value in [°] Réaumur.</param>
		/// <returns>A value in [°] Newton.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Newton ToNewton(double value) => new Newton(Converter.Réau2New(value));

		/// <summary>
		/// Returns an entry temperature in [°] Rømer.
		/// </summary>
		/// <param name="value">An input double value in [°] Réaumur.</param>
		/// <returns>A value in Rømer.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Rømer ToRømer(double value) => new Rømer(Converter.Réau2Røm(value));

		/// <summary>
		/// Returns an entry temperature in [°] Réaumur.
		/// </summary>
		/// <param name="réaumur">An input temperature object that can be converter to the Réaumur unit.</param>
		/// <returns>A value in [°] Réaumur.</returns>
		/// <remarks>Use .Value property to get temperature as double.</remarks>
		public static new Réaumur ToRéaumur(IConversionToRéaumur réaumur) => réaumur is Réaumur validRéaumur ? validRéaumur : new Réaumur(réaumur);

		#endregion

		#region Operators

		/// <summary>
		/// Adds a Réaumur scale unit with any another temperature scale unit.
		/// </summary>
		/// <param name="réaumur">A temperature in Réaumur.</param>
		/// <param name="b">An object providing a temperature value and a scale type.</param>
		/// <returns>An addition of the Réaumur and any another temperature scale unit.</returns>
		public static Réaumur operator +(Réaumur réaumur, IConversionToRéaumur b) =>
			new Réaumur(
				(réaumur?.Value ?? Constants.AbsoluteZeroInRéaumur) +
				(b?.ToRéaumur()?.Value ?? 0.0)
			);

		/// <summary>
		/// Subtract a Réaumur scale unit with any another temperature scale unit.
		/// </summary>
		/// <param name="réaumur">A temperature in Réaumur.</param>
		/// <param name="b">An object providing a temperature value and a scale type.</param>
		/// <returns>An subtraction of the Réaumur and any another temperature scale unit.</returns>
		public static Réaumur operator -(Réaumur réaumur, IConversionToRéaumur b) =>
			new Réaumur(
				(réaumur?.Value ?? Constants.AbsoluteZeroInRéaumur) -
				(b?.ToRéaumur()?.Value ?? 0.0)
			);

		#endregion
	}
}