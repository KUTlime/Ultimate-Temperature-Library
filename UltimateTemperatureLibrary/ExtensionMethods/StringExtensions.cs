using System;
using System.Linq;

namespace UltimateTemperatureLibrary.ExtensionMethods
{
    /// <summary>
    /// A class encapsulation for string extension.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Removes all whitespace (Char.IsWhiteSpace() | True) characters from a string.
        /// </summary>
        /// <param name="input">An input string from which whitespace character should be removed.</param>
        /// <returns>A new string without whitespace characters.</returns>
        public static string RemoveAllWhitespaces(this string input)
        {
            return new string(input?.ToCharArray()
                ?.Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}