namespace UltimateTemperatureLibrary.Interfaces
{
    /// <summary>
    /// Represents a Celsius scale convertible object.
    /// </summary>
    public interface IConversionToCelsius
    {
        /// <summary>
        /// Returns temperature converted to the Celsius unit.
        /// </summary>
        /// <returns>A temperature converted to the Celsius unit.</returns>
        Celsius ToCelsius();
    }
}