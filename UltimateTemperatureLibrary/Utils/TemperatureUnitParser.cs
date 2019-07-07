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

            if (value == null || String.IsNullOrWhiteSpace(value))
            {
                return new Kelvin(Constants.AbsoluteZeroInKelvin);
            }

            value = value.Replace(',', '.');
            if ((value.Length - value.Replace(".", "").Length) > 1)
            {
                throw new FormatException("Input string has more than one comma.");
            }

            if (Double.TryParse(value, out var tempValue))
            {
                // Only number, lets assume that it is a Celsius value.
                return new Kelvin(tempValue);
            }

            // Now, the heavy lifting...
            if (!Double.TryParse(Regex.Match(value, @"[-\d.]+[eE][-+]?\d+").Value, NumberStyles.Float, CultureInfo.InvariantCulture, out tempValue) &&
                !Double.TryParse(Regex.Match(value, @"([-\d.]+)").Value, NumberStyles.Float, CultureInfo.InvariantCulture, out tempValue))
            {
                throw new FormatException("Input string has invalid numeric value.");
            }

            var unit = Scale.Identify(value);
            switch (unit)
            {
                case TemperatureScale.Kelvin:
                    return new Kelvin(tempValue);
                case TemperatureScale.Celsius:
                    return new Celsius(tempValue);
                case TemperatureScale.Fahrenheit:
                    return new Fahrenheit(tempValue);
                case TemperatureScale.Rankine:
                    return new Rankine(tempValue);
                case TemperatureScale.Delisle:
                    return new Delisle(tempValue);
                case TemperatureScale.Newton:
                    return new Newton(tempValue);
                case TemperatureScale.Réaumur:
                    return new Réaumur(tempValue);
                case TemperatureScale.Rømer:
                    return new Rømer(tempValue);
                default:
                    throw new ArgumentOutOfRangeException(nameof(unit), unit, "An invalid Scale value. Perhaps missing case?");
            }
        }
    }
}