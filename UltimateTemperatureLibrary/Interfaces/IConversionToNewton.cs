namespace UltimateTemperatureLibrary.Interfaces
{
    /// <summary>
    /// Represents a Newton scale convertible object.
    /// </summary>
    public interface IConversionToNewton
    {
        /// <summary>
        /// Returns temperature converted to the Newton unit.
        /// </summary>
        /// <returns>A temperature converted to the Newton unit.</returns>
        Newton ToNewton();
    }
}