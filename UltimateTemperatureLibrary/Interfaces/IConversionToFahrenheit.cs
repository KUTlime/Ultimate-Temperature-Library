namespace UltimateTemperatureLibrary.Interfaces
{
    /// <summary>
    /// Represents a Fahrenheit scale convertible object.
    /// </summary>
    public interface IConversionToFahrenheit
    {
        /// <summary>
        /// Returns temperature converted to the Fahrenheit unit.
        /// </summary>
        /// <returns>A temperature converted to the Fahrenheit unit.</returns>
        Fahrenheit ToFahrenheit();
    }
}