using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UltimateTemperatureLibrary.UnitTests")]
namespace UltimateTemperatureLibrary.Enums
{
    internal enum TemperatureScale
    {
        /// <summary>
        /// A [°] Kelvin temperature scale.
        /// </summary>
        Kelvin = 1,

        /// <summary>
        /// A [°] Celsius temperature scale.
        /// </summary>
        Celsius = 2,

        /// <summary>
        /// A [°] Fahrenheit temperature scale.
        /// </summary>
        Fahrenheit = 3,

        /// <summary>
        /// A [°] Rankine temperature scale.
        /// </summary>
        Rankine = 4,

        /// <summary>
        /// A [°] Delisle temperature scale.
        /// </summary>
        Delisle = 5,

        /// <summary>
        /// A [°] Newton temperature scale.
        /// </summary>
        Newton = 6,

        /// <summary>
        /// A [°] Réaumur temperature scale.
        /// </summary>
        Réaumur = 7,

        /// <summary>
        /// A [°] Rømer temperature scale.
        /// </summary>
        Rømer = 8,
    }
}