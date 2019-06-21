﻿namespace UltimateTemperatureLibrary
{
    /// <summary>
    /// Provides a complex double-to-double conversion between all temperature units.
    /// </summary>
    public static class Converter
    {
        /// <summary>
        /// Converts a double value in Celsius to double value in Kelvin.
        /// </summary>
        /// <param name="value">A value in Celsius.</param>
        /// <returns>A value in Kelvin.</returns>
        public static double Cel2Kel(double value)
        {
            return value + Constants.MeltingPointH2OInKelvin;
        }

        /// <summary>
        /// Converts a double value in Celsius to double value in Fahrenheit.
        /// </summary>
        /// <param name="value">A value in Celsius.</param>
        /// <returns>A value in Fahrenheit.</returns>
        public static double Cel2Fah(double value)
        {
            return Kel2Fah(Cel2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Celsius to double value in Rankine.
        /// </summary>
        /// <param name="value">A value in Celsius.</param>
        /// <returns>A value in Rankine.</returns>
        public static double Cel2Ran(double value)
        {
            return Kel2Ran(Cel2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Celsius to double value in Delisle.
        /// </summary>
        /// <param name="value">A value in Celsius.</param>
        /// <returns>A value in Delisle.</returns>
        public static double Cel2Del(double value)
        {
            return Kel2Del(Cel2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Celsius to double value in Newton.
        /// </summary>
        /// <param name="value">A value in Celsius.</param>
        /// <returns>A value in Newton.</returns>
        public static double Cel2New(double value)
        {
            return Kel2New(Cel2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Celsius to double value in Réaumur.
        /// </summary>
        /// <param name="value">A value in Celsius.</param>
        /// <returns>A value in Réaumur.</returns>
        public static double Cel2Réau(double value)
        {
            return Kel2Réau(Cel2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Celsius to double value in Rømer.
        /// </summary>
        /// <param name="value">A value in Celsius.</param>
        /// <returns>A value in Rømer.</returns>
        public static double Cel2Røm(double value)
        {
            return Kel2Røm(Cel2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Fahrenheit to double value in Kelvin.
        /// </summary>
        /// <param name="value">A value in Fahrenheit.</param>
        /// <returns>A value in Kelvin.</returns>
        public static double Fah2Kel(double value)
        {
            return (value - Constants.AbsoluteZeroInFahrenheit) * 5.0 / 9.0;
        }

        /// <summary>
        /// Converts a double value in Fahrenheit to double value in Celsius.
        /// </summary>
        /// <param name="value">A value in Fahrenheit.</param>
        /// <returns>A value in Celsius.</returns>
        public static double Fah2Cel(double value)
        {
            return Kel2Cel(Fah2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Fahrenheit to double value in Rankine.
        /// </summary>
        /// <param name="value">A value in Fahrenheit.</param>
        /// <returns>A value in Rankine.</returns>
        public static double Fah2Ran(double value)
        {
            return Kel2Ran(Fah2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Fahrenheit to double value in Delisle.
        /// </summary>
        /// <param name="value">A value in Fahrenheit.</param>
        /// <returns>A value in Delisle.</returns>
        public static double Fah2Del(double value)
        {
            return Kel2Del(Fah2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Fahrenheit to double value in Newton.
        /// </summary>
        /// <param name="value">A value in Fahrenheit.</param>
        /// <returns>A value in Newton.</returns>
        public static double Fah2New(double value)
        {
            return Kel2New(Fah2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Fahrenheit to double value in Réaumur.
        /// </summary>
        /// <param name="value">A value in Fahrenheit.</param>
        /// <returns>A value in Réaumur.</returns>
        public static double Fah2Réau(double value)
        {
            return Kel2Réau(Fah2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Fahrenheit to double value in Rømer.
        /// </summary>
        /// <param name="value">A value in Fahrenheit.</param>
        /// <returns>A value in Rømer.</returns>
        public static double Fah2Røm(double value)
        {
            return Kel2Røm(Fah2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Kelvin to double value in Celsius.
        /// </summary>
        /// <param name="value">A value in Kelvin.</param>
        /// <returns>A value in Celsius.</returns>
        public static double Kel2Cel(double value)
        {
            return value - Constants.MeltingPointH2OInKelvin;
        }

        /// <summary>
        /// Converts a double value in Kelvin to double value in Fahrenheit.
        /// </summary>
        /// <param name="value">A value in Kelvin.</param>
        /// <returns>A value in Fahrenheit.</returns>
        public static double Kel2Fah(double value)
        {
            return value * 1.8 + Constants.AbsoluteZeroInFahrenheit;
        }

        /// <summary>
        /// Converts a double value in Kelvin to double value in Rankine.
        /// </summary>
        /// <param name="value">A value in Kelvin.</param>
        /// <returns>A value in Rankine.</returns>
        public static double Kel2Ran(double value)
        {
            return value * 1.8;
        }

        /// <summary>
        /// Converts a double value in Kelvin to double value in Delisle.
        /// </summary>
        /// <param name="value">A value in Kelvin.</param>
        /// <returns>A value in Delisle.</returns>
        /// <seealso cref="https://en.wikipedia.org/wiki/Delisle_scale"/>
        public static double Kel2Del(double value)
        {
            return (Constants.BoilingPointH2OInKelvin - value) * 1.5;
        }

        /// <summary>
        /// Converts a double value in Kelvin to double value in Newton.
        /// </summary>
        /// <param name="value">A value in Kelvin.</param>
        /// <returns>A value in Newton.</returns>
        public static double Kel2New(double value)
        {
            return (value - Constants.MeltingPointH2OInKelvin) * 33.0 / 100.0;
        }

        /// <summary>
        /// Converts a double value in Kelvin to double value in Réaumur.
        /// </summary>
        /// <param name="value">A value in Kelvin.</param>
        /// <returns>A value in Réaumur.</returns>
        public static double Kel2Réau(double value)
        {
            return (value - Constants.MeltingPointH2OInKelvin) * 0.8;
        }

        /// <summary>
        /// Converts a double value in Kelvin to double value in Rømer.
        /// </summary>
        /// <param name="value">A value in Kelvin.</param>
        /// <returns>A value in Rømer.</returns>
        public static double Kel2Røm(double value)
        {
            return (value - Constants.MeltingPointH2OInKelvin) * 21.0 / 40.0 + 7.5;
        }

        /// <summary>
        /// Converts a double value in Rankine to double value in Kelvine.
        /// </summary>
        /// <param name="value">A value in Rankine.</param>
        /// <returns>A value in Celsius.</returns>
        public static double Ran2Kel(double value)
        {
            return value * 5.0 / 9.0;
        }

        /// <summary>
        /// Converts a double value in Rankine to double value in Celsius.
        /// </summary>
        /// <param name="value">A value in Rankine.</param>
        /// <returns>A value in Celsius.</returns>
        public static double Ran2Cel(double value)
        {
            return Kel2Cel(Ran2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Rankine to double value in Fahrenheit.
        /// </summary>
        /// <param name="value">A value in Rankine.</param>
        /// <returns>A value in Fahrenheit.</returns>
        public static double Ran2Fah(double value)
        {
            return Kel2Fah(Ran2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Rankine to double value in Delisle.
        /// </summary>
        /// <param name="value">A value in Rankine.</param>
        /// <returns>A value in Delisle.</returns>
        public static double Ran2Del(double value)
        {
            return Kel2Del(Ran2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Rankine to double value in Newton.
        /// </summary>
        /// <param name="value">A value in Rankine.</param>
        /// <returns>A value in Newton.</returns>
        public static double Ran2New(double value)
        {
            return Kel2New(Ran2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Rankine to double value in Réaumur.
        /// </summary>
        /// <param name="value">A value in Rankine.</param>
        /// <returns>A value in Réaumur.</returns>
        public static double Ran2Réau(double value)
        {
            return Kel2Réau(Ran2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Rankine to double value in Rømer.
        /// </summary>
        /// <param name="value">A value in Rankine.</param>
        /// <returns>A value in Rømer.</returns>
        public static double Ran2Røm(double value)
        {
            return Kel2Røm(Ran2Kel(value));
        }


        /// <summary>
        /// Converts a double value in Delisle to double value in Kelvin.
        /// </summary>
        /// <param name="value">A value in Delisle.</param>
        /// <returns>A value in Kelvin.</returns>
        public static double Del2Kel(double value)
        {
            return Constants.BoilingPointH2OInKelvin - value * 2.0 / 3.0;
        }

        /// <summary>
        /// Converts a double value in Delisle to double value in Celsius.
        /// </summary>
        /// <param name="value">A value in Delisle.</param>
        /// <returns>A value in Celsius.</returns>
        public static double Del2Cel(double value)
        {
            return Kel2Cel(Del2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Delisle to double value in Fahrenheit.
        /// </summary>
        /// <param name="value">A value in Delisle.</param>
        /// <returns>A value in Fahrenheit.</returns>
        public static double Del2Fah(double value)
        {
            return Kel2Fah(Del2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Delisle to double value in Rankine.
        /// </summary>
        /// <param name="value">A value in Delisle.</param>
        /// <returns>A value in Rankine.</returns>
        public static double Del2Ran(double value)
        {
            return Kel2Ran(Del2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Delisle to double value in Newton.
        /// </summary>
        /// <param name="value">A value in Delisle.</param>
        /// <returns>A value in Newton.</returns>
        public static double Del2New(double value)
        {
            return Kel2New(Del2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Delisle to double value in Réaumur.
        /// </summary>
        /// <param name="value">A value in Delisle.</param>
        /// <returns>A value in Réaumur.</returns>
        public static double Del2Réau(double value)
        {
            return Kel2Réau(Del2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Delisle to double value in Rømer.
        /// </summary>
        /// <param name="value">A value in Delisle.</param>
        /// <returns>A value in Rømer.</returns>
        public static double Del2Røm(double value)
        {
            return Kel2Røm(Del2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Newton to double value in Kelvin.
        /// </summary>
        /// <param name="value">A value in Newton.</param>
        /// <returns>A value in Kelvin.</returns>
        public static double New2Kel(double value)
        {
            return value * 100.0 / 33.0 + Constants.MeltingPointH2OInKelvin;
        }

        /// <summary>
        /// Converts a double value in Newton to double value in Celsius.
        /// </summary>
        /// <param name="value">A value in Newton.</param>
        /// <returns>A value in Celsius.</returns>
        public static double New2Cel(double value)
        {
            return Kel2Cel(New2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Newton to double value in Fahrenheit.
        /// </summary>
        /// <param name="value">A value in Newton.</param>
        /// <returns>A value in Fahrenheit.</returns>
        public static double New2Fah(double value)
        {
            return Kel2Fah(New2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Newton to double value in Rankine.
        /// </summary>
        /// <param name="value">A value in Newton.</param>
        /// <returns>A value in Rankine.</returns>
        public static double New2Ran(double value)
        {
            return Kel2Ran(New2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Newton to double value in Delisle.
        /// </summary>
        /// <param name="value">A value in Newton.</param>
        /// <returns>A value in Delisle.</returns>
        public static double New2Del(double value)
        {
            return Kel2Del(New2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Newton to double value in Réaumur.
        /// </summary>
        /// <param name="value">A value in Newton.</param>
        /// <returns>A value in Réaumur.</returns>
        public static double New2Réau(double value)
        {
            return Kel2Réau(New2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Newton to double value in Rømer.
        /// </summary>
        /// <param name="value">A value in Newton.</param>
        /// <returns>A value in Rømer.</returns>
        public static double New2Røm(double value)
        {
            return Kel2Røm(New2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Réaumur to double value in Kelvin.
        /// </summary>
        /// <param name="value">A value in Réaumur.</param>
        /// <returns>A value in Kelvin.</returns>
        public static double Réau2Kel(double value)
        {
            return value * 1.25 + Constants.MeltingPointH2OInKelvin;
        }

        /// <summary>
        /// Converts a double value in Réaumur to double value in Celsius.
        /// </summary>
        /// <param name="value">A value in Réaumur.</param>
        /// <returns>A value in Celsius.</returns>
        public static double Réau2Cel(double value)
        {
            return Kel2Cel(Réau2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Réaumur to double value in Fahrenheit.
        /// </summary>
        /// <param name="value">A value in Réaumur.</param>
        /// <returns>A value in Fahrenheit.</returns>
        public static double Réau2Fah(double value)
        {
            return Kel2Fah(Réau2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Réaumur to double value in Rankine.
        /// </summary>
        /// <param name="value">A value in Réaumur.</param>
        /// <returns>A value in Rankine.</returns>
        public static double Réau2Ran(double value)
        {
            return Kel2Ran(Réau2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Réaumur to double value in Delisle.
        /// </summary>
        /// <param name="value">A value in Réaumur.</param>
        /// <returns>A value in Delisle.</returns>
        public static double Réau2Del(double value)
        {
            return Kel2Del(Réau2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Réaumur to double value in Newton.
        /// </summary>
        /// <param name="value">A value in Réaumur.</param>
        /// <returns>A value in Newton.</returns>
        public static double Réau2New(double value)
        {
            return Kel2New(Réau2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Réaumur to double value in Rømer.
        /// </summary>
        /// <param name="value">A value in Réaumur.</param>
        /// <returns>A value in Rømer.</returns>
        public static double Réau2Røm(double value)
        {
            return Kel2Røm(Réau2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Rømer to double value in Kelvin.
        /// </summary>
        /// <param name="value">A value inRømer.</param>
        /// <returns>A value in Kelvin.</returns>
        public static double Røm2Kel(double value)
        {
            return (value - 7.5) * 40.0 / 21.0 + Constants.MeltingPointH2OInKelvin;
        }

        /// <summary>
        /// Converts a double value in Rømer to double value in Celsius.
        /// </summary>
        /// <param name="value">A value inRømer.</param>
        /// <returns>A value in Celsius.</returns>
        public static double Røm2Cel(double value)
        {
            return Kel2Cel(Røm2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Rømer to double value in Fahrenheit.
        /// </summary>
        /// <param name="value">A value inRømer.</param>
        /// <returns>A value in Fahrenheit.</returns>
        public static double Røm2Fah(double value)
        {
            return Kel2Fah(Røm2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Rømer to double value in Rankine.
        /// </summary>
        /// <param name="value">A value inRømer.</param>
        /// <returns>A value in Rankine.</returns>
        public static double Røm2Ran(double value)
        {
            return Kel2Ran(Røm2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Rømer to double value in Delisle.
        /// </summary>
        /// <param name="value">A value inRømer.</param>
        /// <returns>A value in Delisle.</returns>
        public static double Røm2Del(double value)
        {
            return Kel2Del(Røm2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Rømer to double value in Newton.
        /// </summary>
        /// <param name="value">A value inRømer.</param>
        /// <returns>A value in Newton.</returns>
        public static double Røm2New(double value)
        {
            return Kel2New(Røm2Kel(value));
        }

        /// <summary>
        /// Converts a double value in Rømer to double value in Réaumur.
        /// </summary>
        /// <param name="value">A value inRømer.</param>
        /// <returns>A value in Réaumur.</returns>
        public static double Røm2Réau(double value)
        {
            return Kel2Réau(Røm2Kel(value));
        }
    }
}