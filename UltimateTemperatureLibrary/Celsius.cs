using System;
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
		public Celsius() => Value = Constants.AbsoluteZeroInCelsius;

		/// <summary>
		/// Initializes a new instance of Celsius class using by shared interface.
		/// <para>Value is set to Absolute zero if null object is passed into constructor.</para>
		/// </summary>
		/// <param name="celsius">An object that can be converted to the Celsius unit.</param>
		public Celsius(IConversionToCelsius celsius) => Value = celsius?.ToCelsius()?.Value ?? Constants.AbsoluteZeroInCelsius;

		/// <summary>
		/// Initializes a new instance of Celsius class using parsing from string.
		/// <para>Kelvin unit is used when no information about unit is provided in the input string.</para>
		/// <para>Value is set to Absolute zero if null object or invalid string is passed into constructor.</para>
		/// </summary>
		/// <param name="value">A string caring an information about value and unit.</param>
		public Celsius(string value)
		{
			if (value == null || string.IsNullOrWhiteSpace(value))
			{
				Value = Constants.AbsoluteZeroInCelsius;
				return;
			}

			Value = Converter.Kel2Cel(TemperatureUnitParser.Parse(value)?.ToKelvin()?.Value ?? Constants.AbsoluteZeroInKelvin);
		}

		/// <summary>
		/// Initializes a new instance of Celsius class using a double value.
		/// </summary>
		/// <param name="value">An initialization value from the Celsius scale.</param>
		public Celsius(double value) => Value = value;

		/// <summary>
		/// Gets a temperature value from the Celsius scale.
		/// </summary>
		public sealed override double Value
		{
			get => base.Value;
			set
			{
				if (value < Constants.AbsoluteZeroInCelsius)
				{
					if (!(Math.Abs(value - Constants.AbsoluteZeroInCelsius) < OperationOverDoublePrecision.HighPrecision))
					{
						throw new ArgumentOutOfRangeException(nameof(value), value, "Input value is below the Celsius scale range.");
					}

					base.Value = Constants.AbsoluteZeroInCelsius;
					return;
				}

				base.Value = value;
			}
		}

		/// <summary>
		/// Gets an array of the Celsius unit identifications for a in-string scale matching.
		/// </summary>
		protected internal override string[] RegexPatterns { get; set; } = { "C", "Cel", "CEL", "cel", "Celsius", "celsius", "CELSIUS" };

		#region Interface implementation

		/// <summary>
		/// Returns the stored temperature in Kelvin.
		/// </summary>
		/// <returns>A value in Kelvin.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Kelvin ToKelvin() => new Kelvin(Converter.Cel2Kel(Value));

		/// <summary>
		/// Returns the stored temperature in [°] Celsius, aka itself.
		/// </summary>
		/// <returns>A value in [°] Celsius (a reference to itself).</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		/// <remarks>Interface is implemented because of +/- implementation.</remarks>
		public Celsius ToCelsius() => this;

		/// <summary>
		/// Returns the stored temperature in [°] Fahrenheit.
		/// </summary>
		/// <returns>A value in [°] Fahrenheit.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Fahrenheit ToFahrenheit() => new Fahrenheit(Converter.Cel2Fah(Value));

		/// <summary>
		/// Returns the stored temperature in [°] Rankine.
		/// </summary>
		/// <returns>A value in [°] Rankine.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Rankine ToRankine() => new Rankine(Converter.Cel2Ran(Value));

		/// <summary>
		/// Returns the stored temperature in [°] Delisle.
		/// </summary>
		/// <returns>A value in [°] Delisle.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Delisle ToDelisle() => new Delisle(Converter.Cel2Del(Value));

		/// <summary>
		/// Returns the stored temperature in [°] Newton.
		/// </summary>
		/// <returns>A value in [°] Newton.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Newton ToNewton() => new Newton(Converter.Cel2New(Value));

		/// <summary>
		/// Returns the stored temperature in [°] Réaumur.
		/// </summary>
		/// <returns>A value in [°] Réaumur.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Réaumur ToRéaumur() => new Réaumur(Converter.Cel2Réau(Value));

		/// <summary>
		/// Returns the stored temperature in [°] Rømer.
		/// </summary>
		/// <returns>A value in Rømer.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Rømer ToRømer() => new Rømer(Converter.Cel2Røm(Value));

		#endregion

		#region Static methods

		/// <summary>
		/// Returns an entry temperature in Kelvin.
		/// </summary>
		/// <param name="value">An input double value in [°] Celsius.</param>
		/// <returns>A value in Kelvin.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Kelvin ToKelvin(double value) => new Kelvin(Converter.Cel2Kel(value));

		/// <summary>
		/// Returns an entry temperature in [°] Celsius.
		/// </summary>
		/// <param name="celsius">An input temperature object that can be converter to the Celsius unit.</param>
		/// <returns>A value in [°] Celsius.</returns>
		/// <remarks>Use .Value property to get temperature as double.</remarks>
		public static new Celsius ToCelsius(IConversionToCelsius celsius) => celsius is Celsius validCelsius ? validCelsius : new Celsius(celsius);

		/// <summary>
		/// Returns an entry temperature in [°] Fahrenheit.
		/// </summary>
		/// <param name="value">An input double value in [°] Celsius.</param>
		/// <returns>A value in [°] Fahrenheit.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Fahrenheit ToFahrenheit(double value) => new Fahrenheit(Converter.Cel2Fah(value));

		/// <summary>
		/// Returns an entry temperature in [°] Rankine.
		/// </summary>
		/// <param name="value">An input double value in [°] Celsius.</param>
		/// <returns>A value in [°] Rankine.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Rankine ToRankine(double value) => new Rankine(Converter.Cel2Ran(value));

		/// <summary>
		/// Returns an entry temperature in [°] Delisle.
		/// </summary>
		/// <param name="value">An input double value in [°] Celsius.</param>
		/// <returns>A value in [°] Delisle.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Delisle ToDelisle(double value) => new Delisle(Converter.Cel2Del(value));

		/// <summary>
		/// Returns an entry temperature in [°] Newton.
		/// </summary>
		/// <param name="value">An input double value in [°] Celsius.</param>
		/// <returns>A value in [°] Newton.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Newton ToNewton(double value) => new Newton(Converter.Cel2New(value));

		/// <summary>
		/// Returns an entry temperature in [°] Réaumur.
		/// </summary>
		/// <param name="value">An input double value in [°] Celsius.</param>
		/// <returns>A value in [°] Réaumur.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Réaumur ToRéaumur(double value) => new Réaumur(Converter.Cel2Réau(value));

		/// <summary>
		/// Returns an entry temperature in [°] Rømer.
		/// </summary>
		/// <param name="value">An input double value in [°] Celsius.</param>
		/// <returns>A value in Rømer.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Rømer ToRømer(double value) => new Rømer(Converter.Cel2Røm(value));

		#endregion

		#region Operators

		/// <summary>
		/// Adds a Celsius scale unit with any another temperature scale unit.
		/// </summary>
		/// <param name="celsius">A temperature in Celsius.</param>
		/// <param name="b">An object providing a temperature value and a scale type.</param>
		/// <returns>An addition of the Celsius and any another temperature scale unit.</returns>
		public static Celsius operator +(Celsius celsius, IConversionToCelsius b) =>
			new Celsius(
				(celsius?.Value ?? Constants.AbsoluteZeroInCelsius) +
				(b?.ToCelsius()?.Value ?? 0.0)
			);

		/// <summary>
		/// Subtract a Celsius scale unit with any another temperature scale unit.
		/// </summary>
		/// <param name="celsius">A temperature in Celsius.</param>
		/// <param name="b">An object providing a temperature value and a scale type.</param>
		/// <returns>An subtraction of the Celsius and any another temperature scale unit.</returns>
		public static Celsius operator -(Celsius celsius, IConversionToCelsius b) =>
			new Celsius(
				(celsius?.Value ?? Constants.AbsoluteZeroInCelsius) -
				(b?.ToCelsius()?.Value ?? 0.0)
			);

		#endregion
	}
}