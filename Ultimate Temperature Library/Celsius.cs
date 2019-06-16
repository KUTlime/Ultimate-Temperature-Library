using System;
using System.Globalization;

namespace UltimateTemperatureLibrary
{
    public class Celsius : TemperatureUnit
    {
        public Celsius()
        {
            Value = Constants.AbsoluteZeroInCelsius;
        }

        public Celsius(string value)
        {
        }

        public Celsius(double value) : this(value.ToString(CultureInfo.InvariantCulture))
        {

        }

        public static bool TryParse(string value, ref Celsius celsius)
        {

            if (String.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            value = value.Trim();

            celsius.Value = Double.Parse(value);

            return true;
        }

        public sealed override double Value
        {
            get => base.Value;
            set
            {
                if (value < Constants.AbsoluteZeroInCelsius)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Input value is below the Celsius unit range.");
                }

                base.Value = value;
            }
        }

        protected override double GetValueInKelvin()
        {
            return Converter.Cel2Kel(Value);
        }


        public Celsius ToCelsius()
        {
            return this;
        }

        public static Kelvin ToKelvin()
        {
            throw new NotImplementedException();
        }


        public Fahrenheit ToFahrenheit()
        {
            throw new NotImplementedException();
        }

        public Rankine ToRankine()
        {
            throw new NotImplementedException();
        }

        public Delisle ToDelisle()
        {
            throw new NotImplementedException();
        }

        public Newton ToNewton()
        {
            throw new NotImplementedException();
        }

        public Réaumur ToRéaumur()
        {
            throw new NotImplementedException();
        }

        public Rømer ToRømer()
        {
            throw new NotImplementedException();
        }
    }
}