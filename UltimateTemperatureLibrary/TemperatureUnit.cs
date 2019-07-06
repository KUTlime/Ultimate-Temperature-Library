﻿using System;
using UltimateTemperatureLibrary.Interfaces;

namespace UltimateTemperatureLibrary
{
    /// <summary>
    /// Provides a shared functionality for all temperature units.
    /// </summary>
    public abstract class TemperatureUnit : IEquatable<TemperatureUnit>
    {

        /// <summary>
        /// Returns a string that represents an interval double value.
        /// </summary>
        /// <returns>An internal double value in form of string.</returns>
        public override string ToString()
        {
            return $"{Value.ToString()} °{RegexPatterns[0]}";
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case null:
                    return false;
                case TemperatureUnit temp when ReferenceEquals(this, obj):
                    return true;
                case TemperatureUnit unit:
                    return Equals((IConversionToKelvin)this, (IConversionToKelvin)unit);
                default:
                    return false;
            }
        }


        public bool Equals(TemperatureUnit other)
        {
            switch (other)
            {
                case null:
                    return false;
                case TemperatureUnit temp when ReferenceEquals(this, other):
                    return true;
                default:
                    return Equals((IConversionToKelvin)this, (IConversionToKelvin)other);
            }
        }

        public static bool Equals(IConversionToKelvin left, IConversionToKelvin right)
        {
            return Equals(left.ToKelvin().Value, right.ToKelvin().Value);
        }

        public static bool operator ==(TemperatureUnit left, TemperatureUnit right)
        {
            return Equals((IConversionToKelvin)left, (IConversionToKelvin)right);
        }

        public static bool operator !=(TemperatureUnit left, TemperatureUnit right)
        {
            return !Equals((IConversionToKelvin)left, (IConversionToKelvin)right);
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
        /// Gets or sets Regex patterns which are used for unit parsing from string.
        /// </summary>
        public virtual string[] RegexPatterns { get; protected set; } = { String.Empty };

        /// <summary>
        /// Gets or sets an user Regex pattern which are used for unit parsing from string.
        /// <para>This overrides the RegexPatterns property.</para>
        /// </summary>
        public virtual string RegexPatternRaw { get; protected set; } = String.Empty;

        #region Static methods

        /// <summary>
        /// Returns an entry temperature in Kelvin.
        /// </summary>
        /// <param name="temperature">An input temperature object that can be converter to the Kelvin unit.</param>
        /// <returns>A value in Kelvin.</returns>
        /// <remarks>Use .Value property to get temperature as double.</remarks>
        public static Kelvin ToKelvin(IConversionToKelvin temperature)
        {
            return new Kelvin(temperature);
        }

        /// <summary>
        /// Returns an entry temperature in [°] Celsius.
        /// </summary>
        /// <param name="temperature">An input temperature object that can be converter to the Celsius unit.</param>
        /// <returns>A value in Celsius.</returns>
        /// <remarks>Use .Value property to get temperature as double.</remarks>
        public static Celsius ToCelsius(IConversionToCelsius temperature)
        {
            return new Celsius(temperature);
        }

        /// <summary>
        /// Returns an entry temperature in [°] Fahrenheit.
        /// </summary>
        /// <param name="temperature">An input temperature object that can be converter to the Fahrenheit unit.</param>
        /// <returns>A value in [°] Fahrenheit.</returns>
        /// <remarks>Use .Value property to get temperature as double.</remarks>
        public static Fahrenheit ToFahrenheit(IConversionToFahrenheit temperature)
        {
            return new Fahrenheit(temperature);
        }

        /// <summary>
        /// Returns an entry temperature in [°] Rankine.
        /// </summary>
        /// <param name="temperature">An input temperature object that can be converter to the Rankine unit.</param>
        /// <returns>A value in [°] Rankine.</returns>
        /// <remarks>Use .Value property to get temperature as double.</remarks>
        public static Rankine ToRankine(IConversionToRankine temperature)
        {
            return new Rankine(temperature);
        }

        /// <summary>
        /// Returns an entry temperature in [°] Delisle.
        /// </summary>
        /// <param name="temperature">An input temperature object that can be converter to the Delisle unit.</param>
        /// <returns>A value in [°] Delisle.</returns>
        /// <remarks>Use .Value property to get temperature as double.</remarks>
        public static Delisle ToDelisle(IConversionToDelisle temperature)
        {
            return new Delisle(temperature);
        }

        /// <summary>
        /// Returns an entry temperature in [°] Newton.
        /// </summary>
        /// <param name="temperature">An input temperature object that can be converter to the Newton unit.</param>
        /// <returns>A value in [°] Newton.</returns>
        /// <remarks>Use .Value property to get temperature as double.</remarks>
        public static Newton ToNewton(IConversionToNewton temperature)
        {
            return new Newton(temperature);
        }

        /// <summary>
        /// Returns an entry temperature in [°] Réaumur.
        /// </summary>
        /// <param name="temperature">An input temperature object that can be converter to the Réaumur unit.</param>
        /// <returns>A value in [°] Réaumur.</returns>
        /// <remarks>Use .Value property to get temperature as double.</remarks>
        public static Réaumur ToRéaumur(IConversionToRéaumur temperature)
        {
            return new Réaumur(temperature);
        }

        /// <summary>
        /// Returns an entry temperature in [°] Rømer.
        /// </summary>
        /// <param name="temperature">An input temperature object that can be converter to the Rømer unit.</param>
        /// <returns>A value in [°] Rømer.</returns>
        /// <remarks>Use .Value property to get temperature as double.</remarks>
        public static Rømer ToRømer(IConversionToRømer temperature)
        {
            return new Rømer(temperature);
        }


        #endregion

    }
}
