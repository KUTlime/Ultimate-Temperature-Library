using System;
using UltimateTemperatureLibrary.Interfaces;

namespace UltimateTemperatureLibrary
{
    public class Delisle : TemperatureUnit, IConversionToKelvin
    {
        public Delisle(double value)
        {
            throw new System.NotImplementedException();
        }

        public Delisle()
        {
            Value = Constants.AbsoluteZeroInDelisle;
        }

        public sealed override double Value
        {
            get => base.Value;
            set
            {
                if (value < Constants.AbsoluteZeroInDelisle)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Input value is below the Delisle scale range.");
                }

                base.Value = value;
            }
        }

        public override string[] RegexPatterns { get; protected set; } = { "D", "De", "d", "de" };

        public Celsius ToCelsius()
        {
            throw new System.NotImplementedException();
        }

        public Kelvin ToKelvin()
        {
            throw new System.NotImplementedException();
        }

        public Fahrenheit ToFahrenheit()
        {
            throw new System.NotImplementedException();
        }

        public Rankine ToRankine()
        {
            throw new System.NotImplementedException();
        }

        public Delisle ToDelisle()
        {
            throw new System.NotImplementedException();
        }

        public Newton ToNewton()
        {
            throw new System.NotImplementedException();
        }

        public Réaumur ToRéaumur()
        {
            throw new System.NotImplementedException();
        }

        public Rømer ToRømer()
        {
            throw new System.NotImplementedException();
        }

        protected override double GetValueInKelvin()
        {
            throw new System.NotImplementedException();
        }
    }
}