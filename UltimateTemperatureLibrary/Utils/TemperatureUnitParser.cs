using System;
using System.Globalization;
using System.Text.RegularExpressions;
using UltimateTemperatureLibrary.Enums;
using UltimateTemperatureLibrary.Interfaces;

namespace UltimateTemperatureLibrary.Utils
{
	/// <summary>
	/// Provides from string to temperature unit parser.
	/// </summary>
	public class TemperatureUnitParser
	{
		/// <summary>
		/// Returns a temperature unit converted from input string.
		/// </summary>
		/// <param name="value">A string for value and unit parsing.</param>
		/// <returns>An object convertible to the Kelvin unit.</returns>
		public static IConversionToKelvin Parse(string value)
		{
			//value = value.RemoveAllWhitespaces();

			if (value == null || string.IsNullOrWhiteSpace(value))
			{
				return new Kelvin(Constants.AbsoluteZeroInKelvin);
			}

			value = value.Replace(',', '.');
			if ((value.Length - value.Replace(".", "").Length) > 1)
			{
				throw new FormatException("Input string has more than one comma.");
			}

			if (double.TryParse(value, out double tempValue))
			{
				// Only number, lets assume that it is a Celsius value.
				return new Kelvin(tempValue);
			}

			// Now, the heavy lifting...
			if (!double.TryParse(Regex.Match(value, @"[-\d.]+[eE][-+]?\d+").Value, NumberStyles.Float, CultureInfo.InvariantCulture, out tempValue) &&
				!double.TryParse(Regex.Match(value, @"([-\d.]+)").Value, NumberStyles.Float, CultureInfo.InvariantCulture, out tempValue))
			{
				throw new FormatException("Input string has invalid numeric value.");
			}

			var unit = Scale.Identify(value);
			return unit switch
			{
				TemperatureScale.Kelvin => new Kelvin(tempValue),
				TemperatureScale.Celsius => new Celsius(tempValue),
				TemperatureScale.Fahrenheit => new Fahrenheit(tempValue),
				TemperatureScale.Rankine => new Rankine(tempValue),
				TemperatureScale.Delisle => new Delisle(tempValue),
				TemperatureScale.Newton => new Newton(tempValue),
				TemperatureScale.Réaumur => new Réaumur(tempValue),
				TemperatureScale.Rømer => new Rømer(tempValue),
				_ => throw new ArgumentOutOfRangeException(nameof(unit), unit,
					"An invalid Scale value. Perhaps missing case?")
			};
		}
	}
}