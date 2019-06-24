using System;
using UltimateTemperatureLibrary.Interfaces;
using UltimateTemperatureLibrary.Utils;

namespace UltimateTemperatureLibrary
{
    public class Celsius : TemperatureUnit, IConversionToFahrenheit, IConversionToKelvin, IConversionToNewton, IConversionToDelisle, IConversionToRankine, IConversionToRéaumur, IConversionToRømer
    {
        public Celsius()
        {
            Value = Constants.AbsoluteZeroInCelsius;
        }

        public Celsius(string value)
        {
            if (value == null || String.IsNullOrWhiteSpace(value))
            {
                Value = Constants.AbsoluteZeroInCelsius;
                return;
            }

            Value = Converter.Kel2Cel(TemperatureUnitParser.Parse(value).ToKelvin().Value);
        }

        public Celsius(double value)
        {
            Value = value;
        }

        public sealed override double Value
        {
            get => base.Value;
            set
            {
                if (value < Constants.AbsoluteZeroInCelsius)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Input value is below the Celsius scale range.");
                }

                base.Value = value;
            }
        }

        public override string[] RegexPatterns { get; protected set; } = { "C", "Cel", "Celsius", "celsius" };

        protected override double GetValueInKelvin()
        {
            return Converter.Cel2Kel(Value);
        }

        #region Interface implementation
        /// <summary>
        /// Returns the stored temperature in Kelvin.
        /// </summary>
        /// <returns>A value in Kelvin.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Kelvin ToKelvin()
        {
            return new Kelvin(Converter.Cel2Kel(Value));
        }

        /// <summary>
        /// Returns the stored temperature in [°] Fahrenheit.
        /// </summary>
        /// <returns>A value in [°] Fahrenheit.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Fahrenheit ToFahrenheit()
        {
            return new Fahrenheit(Converter.Cel2Fah(Value));
        }

        /// <summary>
        /// Returns the stored temperature in [°] Rankine.
        /// </summary>
        /// <returns>A value in [°] Rankine.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Rankine ToRankine()
        {
            return new Rankine(Converter.Cel2Ran(Value));
        }

        /// <summary>
        /// Returns the stored temperature in [°] Delisle.
        /// </summary>
        /// <returns>A value in [°] Delisle.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Delisle ToDelisle()
        {
            return new Delisle(Converter.Cel2Del(Value));
        }

        /// <summary>
        /// Returns the stored temperature in [°] Newton.
        /// </summary>
        /// <returns>A value in [°] Newton.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Newton ToNewton()
        {
            return new Newton(Converter.Cel2New(Value));
        }

        /// <summary>
        /// Returns the stored temperature in [°] Réaumur.
        /// </summary>
        /// <returns>A value in [°] Réaumur.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Réaumur ToRéaumur()
        {
            return new Réaumur(Converter.Cel2Réau(Value));
        }

        /// <summary>
        /// Returns the stored temperature in [°] Rømer.
        /// </summary>
        /// <returns>A value in Rømer.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public Rømer ToRømer()
        {
            return new Rømer(Converter.Cel2Røm(Value));
        }
        #endregion
        #region Static methods
        /// <summary>
        /// Returns an entry temperature in Kelvin.
        /// </summary>
        /// <returns>A value in Kelvin.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Kelvin ToKelvin(double value)
        {
            return new Kelvin(Converter.Cel2Kel(new Celsius(value).Value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Fahrenheit.
        /// </summary>
        /// <returns>A value in [°] Fahrenheit.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Fahrenheit ToFahrenheit(double value)
        {
            return new Fahrenheit(Converter.Cel2Fah(new Celsius(value).Value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Rankine.
        /// </summary>
        /// <returns>A value in [°] Rankine.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Rankine ToRankine(double value)
        {
            return new Rankine(Converter.Cel2Ran(new Celsius(value).Value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Delisle.
        /// </summary>
        /// <returns>A value in [°] Delisle.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Delisle ToDelisle(double value)
        {
            return new Delisle(Converter.Cel2Del(new Celsius(value).Value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Newton.
        /// </summary>
        /// <returns>A value in [°] Newton.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Newton ToNewton(double value)
        {
            return new Newton(Converter.Cel2New(new Celsius(value).Value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Réaumur.
        /// </summary>
        /// <returns>A value in [°] Réaumur.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Réaumur ToRéaumur(double value)
        {
            return new Réaumur(Converter.Cel2Réau(new Celsius(value).Value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Rømer.
        /// </summary>
        /// <returns>A value in Rømer.</returns>
        /// <remarks>Use .Value property to get double value.</remarks>
        public static Rømer ToRømer(double value)
        {
            return new Rømer(Converter.Cel2Røm(new Celsius(value).Value));
        }

        /// <summary>
        /// Returns an entry temperature in Kelvin.
        /// </summary>
        /// <returns>A value in Kelvin.</returns>
        /// <remarks>Use .Value property to get IConversionToKelvin temp.</remarks>
        public static Kelvin ToKelvin(IConversionToKelvin temp)
        {
            return new Kelvin((temp.ToKelvin().Value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Fahrenheit.
        /// </summary>
        /// <returns>A value in [°] Fahrenheit.</returns>
        /// <remarks>Use .Value property to get IConversionToKelvin temp.</remarks>
        public static Fahrenheit ToFahrenheit(IConversionToKelvin temp)
        {
            return new Fahrenheit(Converter.Kel2Fah(temp.ToKelvin().Value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Rankine.
        /// </summary>
        /// <returns>A value in [°] Rankine.</returns>
        /// <remarks>Use .Value property to get IConversionToKelvin temp.</remarks>
        public static Rankine ToRankine(IConversionToKelvin temp)
        {
            return new Rankine(Converter.Kel2Ran(temp.ToKelvin().Value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Delisle.
        /// </summary>
        /// <returns>A value in [°] Delisle.</returns>
        /// <remarks>Use .Value property to get IConversionToKelvin temp.</remarks>
        public static Delisle ToDelisle(IConversionToKelvin temp)
        {
            return new Delisle(Converter.Kel2Del(temp.ToKelvin().Value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Newton.
        /// </summary>
        /// <returns>A value in [°] Newton.</returns>
        /// <remarks>Use .Value property to get IConversionToKelvin temp.</remarks>
        public static Newton ToNewton(IConversionToKelvin temp)
        {
            return new Newton(Converter.Kel2New(temp.ToKelvin().Value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Réaumur.
        /// </summary>
        /// <returns>A value in [°] Réaumur.</returns>
        /// <remarks>Use .Value property to get IConversionToKelvin temp.</remarks>
        public static Réaumur ToRéaumur(IConversionToKelvin temp)
        {
            return new Réaumur(Converter.Kel2Réau(temp.ToKelvin().Value));
        }

        /// <summary>
        /// Returns an entry temperature in [°] Rømer.
        /// </summary>
        /// <returns>A value in Rømer.</returns>
        /// <remarks>Use .Value property to get IConversionToKelvin temp.</remarks>
        public static Rømer ToRømer(IConversionToKelvin temp)
        {
            return new Rømer(Converter.Kel2Røm(temp.ToKelvin().Value));
        }
        #endregion
    }
}