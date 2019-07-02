using System;
using UltimateTemperatureLibrary.Interfaces;

namespace UltimateTemperatureLibrary
{
    public class Fahrenheit : TemperatureUnit, IConversionToKelvin
    {
        public Fahrenheit()
        {
            Value = Constants.AbsoluteZeroInFahrenheit;
        }

        public sealed override double Value
        {
            get => base.Value;
            set
            {
                if (value < Constants.AbsoluteZeroInFahrenheit)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Input value is below the Fahrenheit scale range.");
                }

                base.Value = value;
            }
        }

        public override string[] RegexPatterns { get; protected set; } =
            {"F", "Fahrenheit", "Fah", "f", "fahrenheit", "fah"};

        public Fahrenheit(double value)
        {
            throw new NotImplementedException();
        }

        public Fahrenheit(IConversionToFahrenheit temperature)
        {
            throw new NotImplementedException();
        }

        public Kelvin ToKelvin()
        {
            throw new NotImplementedException();
        }
    }
}