using System;
using UltimateTemperatureLibrary.Interfaces;

namespace UltimateTemperatureLibrary
{
    public class Newton : TemperatureUnit, IConversionToKelvin
    {
        public Newton(double value)
        {
            throw new System.NotImplementedException();
        }

        public Newton()
        {
            Value = Constants.AbsoluteZeroInNewton;
        }

        public Newton(IConversionToNewton temperature)
        {
            throw new NotImplementedException();
        }

        public sealed override double Value
        {
            get => base.Value;
            set
            {
                if (value < Constants.AbsoluteZeroInNewton)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Input value is below the Newton scale range.");
                }

                base.Value = value;
            }
        }

        public override string[] RegexPatterns { get; protected set; } = { "N", "Newton", "n", "newton" };

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