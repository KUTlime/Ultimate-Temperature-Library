﻿using System;
using UltimateTemperatureLibrary.Interfaces;
using UltimateTemperatureLibrary.Utils;

namespace UltimateTemperatureLibrary
{
	/// <summary>
	/// Provides a shared functionality for all temperature units.
	/// </summary>
	public abstract class TemperatureUnit : IEquatable<TemperatureUnit>
	{

		/// <summary>
		/// Converts the temperature numeric value of this instance to its equivalent string representation.
		/// </summary>
		/// <returns>The string representation of the value of this instance with the temperature scale identification.</returns>
		public override string ToString() => $"{Value} °{RegexPatterns[0]}";

		/// <summary>
		/// Converts the temperature numeric value of this instance to its equivalent string representation using the specified format.
		/// </summary>
		/// <returns>The string representation of the value of this instance with the temperature scale identification.</returns>
		/// <param name="format">A numeric format string.</param>
		public string ToString(string format) => $"{Value.ToString(format)} °{RegexPatterns[0]}";

		/// <summary>
		/// Converts the temperature numeric value of this instance to its equivalent string representation using the specified culture-specific format information.
		/// </summary>
		/// <returns>The string representation of the value of this instance with the temperature scale identification.</returns>
		public string ToString(IFormatProvider provider) => $"{Value.ToString(provider)} °{RegexPatterns[0]}";

		/// <summary>
		/// Converts the temperature numeric value of this instance to its equivalent string representation using the specified format and culture-specific format information.
		/// </summary>
		/// <returns>The string representation of the value of this instance with the temperature scale identification.</returns>
		/// <param name="format">A numeric format string.</param>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param>
		public string ToString(string format, IFormatProvider provider) => $"{Value.ToString(format, provider)} °{RegexPatterns[0]}";

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <returns>True if the specified object is equal to the current object; otherwise, false.</returns>
		public override bool Equals(object obj) =>
			obj switch
			{
				null => false,
				TemperatureUnit temp when ReferenceEquals(this, temp) => true,
				TemperatureUnit unit => Equals((IConversionToKelvin) this, (IConversionToKelvin) unit),
				_ => false
			};

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns>True if the specified object is equal to the current object; otherwise, false.</returns>
		public bool Equals(TemperatureUnit other) =>
			other switch
			{
				null => false,
				{ } temp when ReferenceEquals(this, temp) => true,
				_ => Equals((IConversionToKelvin) this, (IConversionToKelvin) other)
			};

		/// <summary>
		/// Determines whether the specified temperature objects are equal. Different scales are transformed appropriately.
		/// </summary>
		/// <param name="left">A left hand side operand for equality comparision that can be converter to Kelvin.</param>
		/// <param name="right">A right hand side operand for equality comparision that can be converted to Kelvin.</param>
		/// <returns>A true if the temperature objects represent a same temperature intensity, false otherwise.</returns>
		public static bool Equals(IConversionToKelvin left, IConversionToKelvin right) => Equals(left.ToKelvin().Value, right.ToKelvin().Value) || Math.Abs(left.ToKelvin().Value - right.ToKelvin().Value) < OperationOverDoublePrecision.HighPrecision;

		/// <summary>
		/// Determines whether the specified temperature objects are equal. Different scales are transformed appropriately.
		/// </summary>
		/// <param name="left">A left hand side operand for equality comparision.</param>
		/// <param name="right">A right hand side operand for equality comparision.</param>
		/// <returns></returns>
		public static bool operator ==(TemperatureUnit left, TemperatureUnit right) => Equals((IConversionToKelvin) left, (IConversionToKelvin) right);

		/// <summary>
		/// Determines whether the specified temperature objects are not equal. Different scales are transformed appropriately.
		/// </summary>
		/// <param name="left">A left hand side operand for inequality comparision.</param>
		/// <param name="right">A right hand side operand for inequality comparision.</param>
		/// <returns></returns>
		public static bool operator !=(TemperatureUnit left, TemperatureUnit right) => !Equals((IConversionToKelvin) left, (IConversionToKelvin) right);

		/// <summary>
		/// Serves as the default hash function.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode() => Value.GetHashCode();

		/// <summary>
		/// An internal value storage.
		/// </summary>
		public virtual Double Value { get; set; }

		/// <summary>
		/// Gets or sets Regex patterns which are used for unit parsing from string.
		/// </summary>
		protected internal virtual string[] RegexPatterns { get; set; } = { string.Empty };

		/// <summary>
		/// Gets or sets an user Regex pattern which are used for unit parsing from string.
		/// <para>This overrides the RegexPatterns property.</para>
		/// </summary>
		protected internal virtual string RegexPatternRaw { get; set; } = string.Empty;

		#region Static methods

		/// <summary>
		/// Returns an entry temperature in Kelvin.
		/// </summary>
		/// <param name="temperature">An input temperature object that can be converter to the Kelvin unit.</param>
		/// <returns>A value in Kelvin.</returns>
		/// <remarks>Use .Value property to get temperature as double.</remarks>
		public static Kelvin ToKelvin(IConversionToKelvin temperature) => new Kelvin(temperature);

		/// <summary>
		/// Returns an entry temperature in Kelvin.
		/// </summary>
		/// <param name="temperature">An input temperature string with valid value and unit that can be converter to the Kelvin unit.</param>
		/// <returns>A value in Kelvin.</returns>
		/// <remarks>Use .Value property to get temperature as double.</remarks>
		public static Kelvin ToKelvin(string temperature) => new Kelvin(temperature);

		/// <summary>
		/// Returns an entry temperature in [°] Celsius.
		/// </summary>
		/// <param name="temperature">An input temperature object that can be converter to the Celsius unit.</param>
		/// <returns>A value in Celsius.</returns>
		/// <remarks>Use .Value property to get temperature as double.</remarks>
		public static Celsius ToCelsius(IConversionToCelsius temperature) => new Celsius(temperature);

		/// <summary>
		/// Returns an entry temperature in [°] Celsius.
		/// </summary>
		/// <param name="temperature">An input temperature string with valid value and unit that can be converter to the Celsius unit.</param>
		/// <returns>A value in Celsius.</returns>
		/// <remarks>Use .Value property to get temperature as double.</remarks>
		public static Celsius ToCelsius(string temperature) => new Celsius(temperature);

		/// <summary>
		/// Returns an entry temperature in [°] Fahrenheit.
		/// </summary>
		/// <param name="temperature">An input temperature object that can be converter to the Fahrenheit unit.</param>
		/// <returns>A value in [°] Fahrenheit.</returns>
		/// <remarks>Use .Value property to get temperature as double.</remarks>
		public static Fahrenheit ToFahrenheit(IConversionToFahrenheit temperature) => new Fahrenheit(temperature);

		/// <summary>
		/// Returns an entry temperature in [°] Fahrenheit.
		/// </summary>
		/// <param name="temperature">An input temperature string with valid value and unit that can be converter to the Fahrenheit unit.</param>
		/// <returns>A value in [°] Fahrenheit.</returns>
		/// <remarks>Use .Value property to get temperature as double.</remarks>
		public static Fahrenheit ToFahrenheit(string temperature) => new Fahrenheit(temperature);

		/// <summary>
		/// Returns an entry temperature in [°] Rankine.
		/// </summary>
		/// <param name="temperature">An input temperature object that can be converter to the Rankine unit.</param>
		/// <returns>A value in [°] Rankine.</returns>
		/// <remarks>Use .Value property to get temperature as double.</remarks>
		public static Rankine ToRankine(IConversionToRankine temperature) => new Rankine(temperature);

		/// <summary>
		/// Returns an entry temperature in [°] Rankine.
		/// </summary>
		/// <param name="temperature">An input temperature string with valid value and unit that can be converter to the Rankine unit.</param>
		/// <returns>A value in [°] Rankine.</returns>
		/// <remarks>Use .Value property to get temperature as double.</remarks>
		public static Rankine ToRankine(string temperature) => new Rankine(temperature);

		/// <summary>
		/// Returns an entry temperature in [°] Delisle.
		/// </summary>
		/// <param name="temperature">An input temperature object that can be converter to the Delisle unit.</param>
		/// <returns>A value in [°] Delisle.</returns>
		/// <remarks>Use .Value property to get temperature as double.</remarks>
		public static Delisle ToDelisle(IConversionToDelisle temperature) => new Delisle(temperature);

		/// <summary>
		/// Returns an entry temperature in [°] Delisle.
		/// </summary>
		/// <param name="temperature">An input temperature string with valid value and unit that can be converter to the Delisle unit.</param>
		/// <returns>A value in [°] Delisle.</returns>
		/// <remarks>Use .Value property to get temperature as double.</remarks>
		public static Delisle ToDelisle(string temperature) => new Delisle(temperature);

		/// <summary>
		/// Returns an entry temperature in [°] Newton.
		/// </summary>
		/// <param name="temperature">An input temperature object that can be converter to the Newton unit.</param>
		/// <returns>A value in [°] Newton.</returns>
		/// <remarks>Use .Value property to get temperature as double.</remarks>
		public static Newton ToNewton(IConversionToNewton temperature) => new Newton(temperature);

		/// <summary>
		/// Returns an entry temperature in [°] Newton.
		/// </summary>
		/// <param name="temperature">An input temperature string with valid value and unit that can be converter to the Newton unit.</param>
		/// <returns>A value in [°] Newton.</returns>
		/// <remarks>Use .Value property to get temperature as double.</remarks>
		public static Newton ToNewton(string temperature) => new Newton(temperature);

		/// <summary>
		/// Returns an entry temperature in [°] Réaumur.
		/// </summary>
		/// <param name="temperature">An input temperature object that can be converter to the Réaumur unit.</param>
		/// <returns>A value in [°] Réaumur.</returns>
		/// <remarks>Use .Value property to get temperature as double.</remarks>
		public static Réaumur ToRéaumur(IConversionToRéaumur temperature) => new Réaumur(temperature);

		/// <summary>
		/// Returns an entry temperature in [°] Réaumur.
		/// </summary>
		/// <param name="temperature">An input temperature string with valid value and unit that can be converter to the Réaumur unit.</param>
		/// <returns>A value in [°] Réaumur.</returns>
		/// <remarks>Use .Value property to get temperature as double.</remarks>
		public static Réaumur ToRéaumur(string temperature) => new Réaumur(temperature);

		/// <summary>
		/// Returns an entry temperature in [°] Rømer.
		/// </summary>
		/// <param name="temperature">An input temperature object that can be converter to the Rømer unit.</param>
		/// <returns>A value in [°] Rømer.</returns>
		/// <remarks>Use .Value property to get temperature as double.</remarks>
		public static Rømer ToRømer(IConversionToRømer temperature) => new Rømer(temperature);

		/// <summary>
		/// Returns an entry temperature in [°] Rømer.
		/// </summary>
		/// <param name="temperature">An input temperature string with valid value and unit that can be converter to the Rømer unit.</param>
		/// <returns>A value in [°] Rømer.</returns>
		/// <remarks>Use .Value property to get temperature as double.</remarks>
		public static Rømer ToRømer(string temperature) => new Rømer(temperature);

		#endregion

	}
}