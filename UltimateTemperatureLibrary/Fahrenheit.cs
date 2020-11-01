using System;
using UltimateTemperatureLibrary.Interfaces;
using UltimateTemperatureLibrary.Utils;

// Classes related to temperature scales, units, conversion between them, thermodynamic constants etc.
namespace UltimateTemperatureLibrary
{
	/// <summary>
	/// Represents the Fahrenheit scale unit.
	/// </summary>
	public class Fahrenheit : TemperatureUnit, IConversionToKelvin, IConversionToCelsius, IConversionToFahrenheit, IConversionToNewton, IConversionToDelisle, IConversionToRankine, IConversionToRéaumur, IConversionToRømer
	{
		/// <summary>
		/// Initializes a new instance of Fahrenheit class.
		/// <para>Value is set to Absolute zero.</para>
		/// </summary>
		public Fahrenheit() => Value = Constants.AbsoluteZeroInFahrenheit;

		/// <summary>
		/// Initializes a new instance of Fahrenheit class using by shared interface.
		/// <para>Value is set to Absolute zero if null object is passed into constructor.</para>
		/// </summary>
		/// <param name="fahrenheit">An object that can be converted to the Fahrenheit unit.</param>
		public Fahrenheit(IConversionToFahrenheit fahrenheit) => Value = fahrenheit?.ToFahrenheit()?.Value ?? Constants.AbsoluteZeroInFahrenheit;

		/// <summary>
		/// Initializes a new instance of Fahrenheit class using parsing from string.
		/// <para>Kelvin unit is used when no information about unit is provided in the input string.</para>
		/// <para>Value is set to Absolute zero if null object or invalid string is passed into constructor.</para>
		/// </summary>
		/// <param name="value">A string caring an information about value and unit.</param>
		public Fahrenheit(string value)
		{
			if (value == null || string.IsNullOrWhiteSpace(value))
			{
				Value = Constants.AbsoluteZeroInFahrenheit;
				return;
			}

			Value = Converter.Kel2Fah(TemperatureUnitParser.Parse(value)?.ToKelvin()?.Value ?? Constants.AbsoluteZeroInKelvin);
		}

		/// <summary>
		/// Initializes a new instance of Fahrenheit class using a double value.
		/// </summary>
		/// <param name="value">An initialization value from the Fahrenheit scale.</param>
		public Fahrenheit(double value) => Value = value;

		/// <summary>
		/// Gets a temperature value from the Fahrenheit scale.
		/// </summary>
		public sealed override double Value
		{
			get => base.Value;
			set
			{
				if (value < Constants.AbsoluteZeroInFahrenheit)
				{
					if (!(Math.Abs(value - Constants.AbsoluteZeroInFahrenheit) < OperationOverDoublePrecision.HighPrecision))
					{
						throw new ArgumentOutOfRangeException(nameof(value), value, "Input value is below the Fahrenheit scale range.");
					}

					base.Value = Constants.AbsoluteZeroInFahrenheit;
					return;
				}

				base.Value = value;
			}
		}

		/// <summary>
		/// Gets an array of the Fahrenheit unit identifications for a in-string scale matching.
		/// </summary>
		protected internal override string[] RegexPatterns { get; set; } = { "F", "Fahrenheit", "Fah", "fahrenheit", "fah", "FAHRENHEIT" };

		#region Interface implementation

		/// <summary>
		/// Returns the stored temperature in Kelvin.
		/// </summary>
		/// <returns>A value in Kelvin.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Kelvin ToKelvin() => new Kelvin(Converter.Fah2Kel(Value));

		/// <summary>
		/// Returns the stored temperature in [°] Fahrenheit, aka itself.
		/// </summary>
		/// <returns>A value in [°] Fahrenheit (a reference to itself).</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		/// <remarks>Interface is implemented because of +/- implementation.</remarks>
		public Celsius ToCelsius() => new Celsius(Converter.Fah2Cel(Value));

		/// <summary>
		/// Returns the stored temperature in [°] Fahrenheit.
		/// </summary>
		/// <returns>A value in [°] Fahrenheit.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Fahrenheit ToFahrenheit() => this;

		/// <summary>
		/// Returns the stored temperature in [°] Rankine.
		/// </summary>
		/// <returns>A value in [°] Rankine.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Rankine ToRankine() => new Rankine(Converter.Fah2Ran(Value));

		/// <summary>
		/// Returns the stored temperature in [°] Delisle.
		/// </summary>
		/// <returns>A value in [°] Delisle.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Delisle ToDelisle() => new Delisle(Converter.Fah2Del(Value));

		/// <summary>
		/// Returns the stored temperature in [°] Newton.
		/// </summary>
		/// <returns>A value in [°] Newton.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Newton ToNewton() => new Newton(Converter.Fah2New(Value));

		/// <summary>
		/// Returns the stored temperature in [°] Réaumur.
		/// </summary>
		/// <returns>A value in [°] Réaumur.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Réaumur ToRéaumur() => new Réaumur(Converter.Fah2Réau(Value));

		/// <summary>
		/// Returns the stored temperature in [°] Rømer.
		/// </summary>
		/// <returns>A value in Rømer.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public Rømer ToRømer() => new Rømer(Converter.Fah2Røm(Value));

		#endregion

		#region Static methods

		/// <summary>
		/// Returns an entry temperature in Kelvin.
		/// </summary>
		/// <param name="value">An input double value in [°] Fahrenheit.</param>
		/// <returns>A value in Kelvin.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Kelvin ToKelvin(double value) => new Kelvin(Converter.Fah2Kel(value));

		/// <summary>
		/// Returns an entry temperature in [°] Fahrenheit.
		/// </summary>
		/// <param name="value">An input double value in [°] Fahrenheit.</param>
		/// <returns>A value in [°] Celsius.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Celsius ToCelsius(double value) => new Celsius(Converter.Fah2Cel(value));

		/// <summary>
		/// Returns an entry temperature in [°] Fahrenheit.
		/// </summary>
		/// <param name="fahrenheit">An input temperature object that can be converter to the Fahrenheit unit.</param>
		/// <returns>A value in [°] Fahrenheit.</returns>
		/// <remarks>Use .Value property to get temperature as double.</remarks>
		public static new Fahrenheit ToFahrenheit(IConversionToFahrenheit fahrenheit) => fahrenheit is Fahrenheit validFahrenheit ? validFahrenheit : new Fahrenheit(fahrenheit);

		/// <summary>
		/// Returns an entry temperature in [°] Rankine.
		/// </summary>
		/// <param name="value">An input double value in [°] Fahrenheit.</param>
		/// <returns>A value in [°] Rankine.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Rankine ToRankine(double value) => new Rankine(Converter.Fah2Ran(value));

		/// <summary>
		/// Returns an entry temperature in [°] Delisle.
		/// </summary>
		/// <param name="value">An input double value in [°] Fahrenheit.</param>
		/// <returns>A value in [°] Delisle.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Delisle ToDelisle(double value) => new Delisle(Converter.Fah2Del(value));

		/// <summary>
		/// Returns an entry temperature in [°] Newton.
		/// </summary>
		/// <param name="value">An input double value in [°] Fahrenheit.</param>
		/// <returns>A value in [°] Newton.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Newton ToNewton(double value) => new Newton(Converter.Fah2New(value));

		/// <summary>
		/// Returns an entry temperature in [°] Réaumur.
		/// </summary>
		/// <param name="value">An input double value in [°] Fahrenheit.</param>
		/// <returns>A value in [°] Réaumur.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Réaumur ToRéaumur(double value) => new Réaumur(Converter.Fah2Réau(value));

		/// <summary>
		/// Returns an entry temperature in [°] Rømer.
		/// </summary>
		/// <param name="value">An input double value in [°] Fahrenheit.</param>
		/// <returns>A value in Rømer.</returns>
		/// <remarks>Use .Value property to get double value.</remarks>
		public static Rømer ToRømer(double value) => new Rømer(Converter.Fah2Røm(value));

		#endregion

		#region Operators

		/// <summary>
		/// Adds a Fahrenheit scale unit with any another temperature scale unit.
		/// </summary>
		/// <param name="fahrenheit">A temperature in Fahrenheit.</param>
		/// <param name="b">An object providing a temperature value and a scale type.</param>
		/// <returns>An addition of the Fahrenheit and any another temperature scale unit.</returns>
		public static Fahrenheit operator +(Fahrenheit fahrenheit, IConversionToFahrenheit b) =>
			new Fahrenheit(
				(fahrenheit?.Value ?? Constants.AbsoluteZeroInFahrenheit) +
				(b?.ToFahrenheit()?.Value ?? 0.0)
			);

		/// <summary>
		/// Subtract a Fahrenheit scale unit with any another temperature scale unit.
		/// </summary>
		/// <param name="fahrenheit">A temperature in Fahrenheit.</param>
		/// <param name="b">An object providing a temperature value and a scale type.</param>
		/// <returns>An subtraction of the Fahrenheit and any another temperature scale unit.</returns>
		public static Fahrenheit operator -(Fahrenheit fahrenheit, IConversionToFahrenheit b) =>
			new Fahrenheit(
				(fahrenheit?.Value ?? Constants.AbsoluteZeroInFahrenheit) -
				(b?.ToFahrenheit()?.Value ?? 0.0)
			);

		#endregion
	}
}