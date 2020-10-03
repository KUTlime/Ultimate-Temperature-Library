# Ultimate Temperature Library
> The ultimate temperature library for .NET! One library to rule them all! 

# Introduction
The Ultimate Temperature Library brings complex functionality when working with temperatures to .NET world. Kelvin, Celsius, Fahrenheit, Rankine, Delisle, Newton, Réaumur and Rømer in one library!


# Main features
- Implements **all** temperature scales
- .NET Standard 1.0 (multiplatform use)
- Well tested (+10000 UTs)
- Source link support
- OOP approach (type safety when manipulation is in place)
- Flexible parsing from string
- Double2Double convertor 
- Thermophysical constants
- Accuracy at least to 12 decimal places, 13 decimal places mostly.
- Well documented.

# CI/CD status
|Build & Test | Publish to NuGet.org |
|-|-|
| [![Build Status](https://kutlime.visualstudio.com/Ultimate%20Temperature%20Library/_apis/build/status/Build%20%26%20Test?branchName=master)](https://kutlime.visualstudio.com/Ultimate%20Temperature%20Library/_build/latest?definitionId=4&branchName=master) | [![Build Status](https://kutlime.visualstudio.com/Ultimate%20Temperature%20Library/_apis/build/status/Publish%20to%20NuGet.org?branchName=master)](https://kutlime.visualstudio.com/Ultimate%20Temperature%20Library/_build/latest?definitionId=5&branchName=master) |

# Basic use
```csharp
// Unit constructions
var celsius = new Celsius(); // Absolute zero is used when an empty unit constructor is called.
celsius = new Celsius(20.0);  // Double value interpreted as 20 °C.
celsius = new Celsius(Constants.MeltingPointH2OInCelsius); // A thermo-physical constant used as double.
celsius = new Celsius("50.8 °C");  // String parsing with some Celsius scale value and unit...
celsius = new Celsius("-273.15 K"); // ...or any another unit that is transferred appropriately.
var celsius1 = new Celsius(celsius); // Directly from other unit...
var celsius2 = new Celsius(new Kelvin(Constants.MeltingPointH2OInKelvin)); // ...or any another unit.
var kelvin = new Kelvin(Constants.MeltingPointH2OInKelvin); // Same applies to other unit ctors...
var delisle = new Delisle("100 °Ré");


// Double value extraction from units
double celsiusAsDouble = celsius.Value;  // Use Value property.


// Arithmetics(T2 = T1 +/- ΔT)
var celsius3 = celsius + celsius1;  // Same unit...
var celsius4 = celsius + kelvin;    // ...or any unit with any another unit.
celsius3 = celsius - celsius1;      // Same for subtraction...
celsius4 = celsius - kelvin;

celsius3.Value = 20;   // Direct manipulation with temperature value.
celsius4.Value = 30;   // Direct manipulation with temperature value.

celsius3 += celsius4;  // Compound operators are also provided...
celsius3 -= celsius4;  // ... same for subtraction.


// Double-to-double conversion (28 different methods are provided)
double valueInFahrenheit = Converter.Ran2Fah(Constants.BoilingPointH2OInRankine);


// OOP Conversion
var fahrenheit = celsius.ToFahrenheit(); // From an instance.
var newton = Celsius.ToNewton(fahrenheit); // Static conversion.


// Extraction of converted temperature as double
var delisle = new Delisle().
double value = delisle.Value;  // Absolute zero in Delisle is returned.


// Static conversion from a Rømer value as double to a Celsius instance and double extraction
var rømer = new Rømer();
double cel = Rømer.ToCelsius(rømer.Value).Value; 


// Comparison
celsius3.Value = 20;
celsius4.Value = 20;

if (celsius3 == celsius4)
{
	// ...
}

celsius = new Celsius(Constants.AbsoluteZeroInCelsius);
kelvin = new Kelvin(Constants.AbsoluteZeroInKelvin);

if (celsius == kelvin)
{
	// ...
}


// Test for correctness when Value property is updated
celsius.Value = -500; // Throws an exception.

// And same behaviour applies to Kelvin, Celsius, Fahrenheit, Rankine, Delisle, Newton, Réaumur and Rømer.
```


# Notes

## Addition/Subtraction and temperature difference (ΔT) implementation
Temperature is the intensive quantity. A mixture of two objects or substances with same temperatures result in a mixture with same temperature, ergo it doesn’t make any sense to add two temperatures. Same applies to subtraction of two object with same temperature or two temperature itself.

![equation](https://latex.codecogs.com/gif.latex?\forall&space;\left&space;(&space;T_1&space;=&space;T_2&space;\right&space;):&space;T_1&space;=&space;T_1&space;&plus;&space;T_2&space;\Leftrightarrow&space;T_2&space;=&space;T_1&space;&plus;&space;T_2)

On the other hand, it makes sense to add/subtract the temperature and the temperature difference.

![equation](http://latex.codecogs.com/gif.latex?\dpi{100}&space;\forall&space;(\Delta&space;T&space;=&space;T_2&space;-&space;T_1):&space;T_2&space;=&space;T_1&space;&plus;&space;\Delta&space;T&space;\Leftrightarrow&space;T_1&space;=&space;T_2&space;-&space;\Delta&space;T)

If you add two temperatures, the second temperature unit is interpreted as ΔT and it is added to the first temperature. If the second temperature is negative, the magnitude of the second temperature is subtracted from the first temperature.

![equation](http://latex.codecogs.com/gif.latex?\dpi{100}&space;\newline&space;\forall&space;(\Delta&space;T&space;>&space;T_{Ref_{lower}}):&space;T_2&space;=&space;T_1&space;&plus;&space;\Delta&space;T&space;\Rightarrow&space;T_2&space;>&space;T_1&space;\newline&space;\forall&space;(\Delta&space;T&space;<&space;T_{Ref_{lower}}):&space;T_2&space;=&space;T_1&space;&plus;&space;\Delta&space;T&space;\Rightarrow&space;T_2&space;<&space;T_1&space;&space;)

If you subtract two temperatures, you will receive the temperature difference in the corresponding unit.

## ToString override
Every unit except Kelvin is denoted as [° PrimaryUnitID] by default. Kelvin is denoted as [K]. This PrimaryUnitID is stored in `RegexPatterns` property and its override also ToString() behaviour.

All units supports a double `ToString()` formating. Overloaded `ToString(string format)`, `ToString(IFormatProvider provider)` and `ToString(string format, IFormatProvider provider)` are provided to consumers of UTL.

## Interface implementation
Every single temperature scale unit implements IConversionToUNIT, where UNIT stands for Kelvin, Celsius, Fahrenheit, Rankine, Delisle, Newton, Réaumur and Rømer, to be able to convert and compare with any another unit.


# FAQ
## Why no Addition/Subtraction with integers/double?
```csharp
// Consider following code:
var celsius = new Celsius(20); // Totally OK. We're interpreting 20 as potential Celsius temperature value.
var celsius_result = celsius + celsius; // Still OK. Type safety in place.
celsius_result = celsius + 20; // Not OK. High possibility of human error. Is 20 really 20 °C?

// Use following construction instead:
celsius_result = celsius + new Celsius(20);
```

## What is the order of unit parsing?
Strings are parsed for unit in following order and sub-order by default:

1. Kelvin (K, Kel, Kelvin, kel, kelvin, KELVIN)
2. Celsius (C, Cel, CEL, cel, Celsius, celsius, CELSIUS)
3. Fahrenheit (F, Fahrenheit, Fah, fahrenheit, fah, FAHRENHEIT)
4. Rankine (R, Ra, Ran, Rankine, ra, ran, rankine, RANKINE)
5. Delisle (D, De, Delisle, DELISLE, delisle )
6. Newton (N, Newton, newton, NEWTON)
7. Réaumur (Re, Ré, re, ré, Réau, Reau, réau, reau, RÉAU, REAU, Réaumur, Reaumur, réaumur, reaumur, RÉAUMUR, REAUMUR)
8. Rømer (Rø, rø, RØ, Rømer, rømer, RØMER, Ro, ro, Ro, Romer, romer, ROMER)

If no unit is present in string with valid float number, **Kelvin unit** is used.

## What is ø and how to type ø?
ø is Latin Small Letter O with Stroke, see Links. You can type it as ALT+0216 for lowercase ø and ALT+0248 for the uppercase Ø but it depends on your OS character setup. See [this](http://www.fileformat.info/tip/microsoft/enter_unicode.htm) or [this](https://support.office.com/en-us/article/insert-ascii-or-unicode-latin-based-symbols-and-characters-d13f58d3-7bcb-44a7-a4d5-972ee12e50e0) link.

## Why only addition and subtraction between units is implemented?
Multiplication/division doesn't really make any physical sense with temperature as an intensity quantity.

# Links
[Temperature Wikipedia](https://en.wikipedia.org/wiki/Temperature)<br>
[Conversion of temperature units Wikipedia](https://en.wikipedia.org/wiki/Conversion_of_units_of_temperature)<br>
[Kelvin scale Wikipedia](https://en.wikipedia.org/wiki/Kelvin)<br>
[Celsius scale Wikipedia](https://en.wikipedia.org/wiki/Celsius)<br>
[Rankine scale Wikipedia](https://en.wikipedia.org/wiki/Rankine_scale)<br>
[Delisle scale Wikipedia](https://en.wikipedia.org/wiki/Delisle_scale)<br>
[Newton scale Wikipedia](https://en.wikipedia.org/wiki/Newton_scale)<br>
[Réaumur scale Wikipedia](https://en.wikipedia.org/wiki/R%C3%A9aumur_scale)<br>
[Rømer scale Wikipedia](https://en.wikipedia.org/wiki/R%C3%B8mer_scale)<br>
[Latin Small Letter O with Stroke](https://unicode-table.com/en/00F8/)<br>
[Latin Capital Letter O with Stroke](https://unicode-table.com/en/00D8/)<br>
