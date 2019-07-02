using System;
using UltimateTemperatureLibrary.Interfaces;

namespace UltimateTemperatureLibrary
{
    public class Réaumur : TemperatureUnit, IConversionToKelvin
    {
        public Réaumur(double value)
        {
            throw new System.NotImplementedException();
        }

        public Réaumur()
        {
            Value = Constants.AbsoluteZeroInRéaumur;
        }

        public Réaumur(IConversionToRéaumur temperature)
        {
            throw new NotImplementedException();
        }

        public sealed override double Value
        {
            get => base.Value;
            set
            {
                if (value < Constants.AbsoluteZeroInRéaumur)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Input value is below the Réaumur scale range.");
                }

                base.Value = value;
            }
        }

        public override string[] RegexPatterns { get; protected set; } = { "Re", "Ré", "re", "ré", "Réau", "Reau", "Réaumur", "Reaumur", "réaumur", "reaumur" };

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