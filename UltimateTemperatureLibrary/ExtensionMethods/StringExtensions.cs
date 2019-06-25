using System;
using System.Linq;

namespace UltimateTemperatureLibrary.ExtensionMethods
{
    public static class StringExtensions
    {
        public static string RemoveAllWhitespaces(this string input)
        {
            return new string(input?.ToCharArray()
                ?.Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}