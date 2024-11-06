/* Calculate Celsius given the current temperature in Fahrenheit */

int fahrenheit = 94;
decimal convetTempToCelsius = (fahrenheit - 32) * (5m/9);

Console.WriteLine($"The fahrenheit temperature of {fahrenheit} is: {Math.Round(convetTempToCelsius, 1)} celsius");
