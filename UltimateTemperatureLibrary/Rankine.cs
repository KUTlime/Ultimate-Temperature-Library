using System;
using UltimateTemperatureLibrary.Interfaces;

namespace UltimateTemperatureLibrary
{
    public class Rankine : TemperatureUnit, IConversionToKelvin
    {
        public Rankine(double value)
        {
            throw new System.NotImplementedException();
        }

        public Rankine()
        {
            Value = Constants.AbsoluteZeroInRankine;
        }

        public Rankine(IConversionToRankine temperature)
        {
            throw new NotImplementedException();
        }

        public sealed override double Value
        {
            get => base.Value;
            set
            {
                if (value < Constants.AbsoluteZeroInRankine)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Input value is below the Rankine scale range.");
                }

                base.Value = value;
            }
        }

        public override string[] RegexPatterns { get; protected set; } = { "R", "Ra", "Ran", "Rankine", "r", "ra", "ran", "rankine" };

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
    }
}