using System;

namespace UltimateTemperatureLibrary
{
    /// <summary>
    /// Provides a shared functionality for all temperature units.
    /// </summary>
    public abstract class TemperatureUnit
    {
        /// <summary>
        /// Returns a string that represents an interval double value.
        /// </summary>
        /// <returns>An internal double value in form of string.</returns>
        public override string ToString()
        {
            return Value.ToString();
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return Value.Equals(obj);
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        /// <summary>
        /// An internal value storage.
        /// </summary>
        public virtual Double Value { get; set; }

        /// <summary>
        /// Returns a temperature value in Kelvins.
        /// </summary>
        /// <returns>A temp value in Kelvins.</returns>
        /// <remarks>On internal use in operators.</remarks>
        protected abstract Double GetValueInKelvin();

    }
}
