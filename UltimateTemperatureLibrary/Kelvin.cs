using System;
using UltimateTemperatureLibrary.Interfaces;

namespace UltimateTemperatureLibrary
{
    public class Kelvin : TemperatureUnit, IConversionToKelvin, IConversionToCelsius
    {
        public Kelvin()
        {
            Value = Constants.AbsoluteZeroInKelvin;
        }

        public sealed override double Value
        {
            get => base.Value;
            set
            {
                if (value < Constants.AbsoluteZeroInKelvin)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Kelvin can't be less than zero. Absolute zero = 0 K.");
                }

                base.Value = value;
            }
        }

        public override string[] RegexPatterns { get; protected set; } = { "K", "Kel", "Kelvin", "k", "kel", "kelvine" };

        public Kelvin(double value)
        {
            Value = value;
        }

        public Kelvin(IConversionToKelvin temperature)
        {
            throw new NotImplementedException();
        }

        public Kelvin ToKelvin()
        {
            return this;
        }

        public Celsius ToCelsius()
        {
            return new Celsius(Converter.Kel2Cel(Value));
        }
    }
}