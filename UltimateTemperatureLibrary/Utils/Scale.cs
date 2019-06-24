using System;
using System.Text.RegularExpressions;
using UltimateTemperatureLibrary.Enums;

namespace UltimateTemperatureLibrary.Utils
{
    internal static class Scale
    {

        internal static TemperatureScale Identify(string scale)
        {
            if (scale == null || String.IsNullOrWhiteSpace(scale))
            {
                throw new ArgumentException("An input string has invalid scale identification.");
            }

            #region Kelvin identification
            if (TryMatchUnit(new Kelvin()))
            {
                return TemperatureScale.Kelvin;
            }
            #endregion

            #region Celsius identification

            if (TryMatchUnit(new Celsius()))
            {
                return TemperatureScale.Celsius;
            }
            #endregion

            #region Fahrenheit identification
            if (TryMatchUnit(new Fahrenheit()))
            {
                return TemperatureScale.Fahrenheit;
            }
            #endregion

            #region Rankine identification
            if (TryMatchUnit(new Rankine()))
            {
                return TemperatureScale.Rankine;
            }
            #endregion

            #region Delisle identification
            if (TryMatchUnit(new Delisle()))
            {
                return TemperatureScale.Delisle;
            }
            #endregion

            #region Newton identification
            if (TryMatchUnit(new Newton()))
            {
                return TemperatureScale.Newton;
            }
            #endregion

            #region Réaumur identification
            if (TryMatchUnit(new Réaumur()))
            {
                return TemperatureScale.Delisle;
            }
            #endregion

            #region Rømer identification
            if (TryMatchUnit(new Rømer()))
            {
                return TemperatureScale.Rømer;
            }
            #endregion

            string GetRegexPattern(TemperatureUnit unit)
            {
                return unit.RegexPatterRaw == String.Empty ? "\\b" + String.Join("\\b|\\b", unit.RegexPatterns) + "\\b" : unit.RegexPatterRaw;
            }

            bool TryMatchUnit(TemperatureUnit unit)
            {
                string matchPatter = GetRegexPattern(unit);

                return (Regex.Match(Regex.Match(scale, @"(\D*)$").Value, matchPatter).Success ||
                        Regex.Match(scale, matchPatter).Success);

            }

            return TemperatureScale.Kelvin;
        }
    }


}