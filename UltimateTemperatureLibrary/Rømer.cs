using System;
using UltimateTemperatureLibrary.Interfaces;

namespace UltimateTemperatureLibrary
{
    public class Rømer : TemperatureUnit, IConversionToKelvin
    {
        public Rømer(double value)
        {
            throw new System.NotImplementedException();
        }

        public Rømer()
        {
            Value = Constants.AbsoluteZeroInRømer;
        }

        public Rømer(IConversionToRømer temperature)
        {
            throw new NotImplementedException();
        }

        public sealed override double Value
        {
            get => base.Value;
            set
            {
                if (value < Constants.AbsoluteZeroInCelsius)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Input value is below the Rømer scale range.");
                }

                base.Value = value;
            }
        }


        public override string[] RegexPatterns { get; protected set; } =
        {
            "Rø", "rø", "Ro", "ro", "Rømer", "rømer", "Romer" ,"romer"
        };

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