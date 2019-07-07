namespace UltimateTemperatureLibrary.Interfaces
{
    /// <summary>
    /// Represents a Kelvin scale convertible object.
    /// </summary>
    public interface IConversionToKelvin
    {
        /// <summary>
        /// Returns temperature converted to the Kelvin unit.
        /// </summary>
        /// <returns>A temperature converted to the Kelvin unit.</returns>
        Kelvin ToKelvin();
    }
}