# Weather Library

Receiving weather information from cities all around the world using OpenWeatherMap api

### Usage Example
```
using System;
using WeatherLibrary; //Our library

namespace WeatherMain
{
    class Program
    {
        static void Main(string[] args)
        {
            /*loc will hold the location we want to check the tempature*/
           Location loc = new Location();

            WeatherData wd = new WeatherData();

            /*Factory to generate objects from different REStful Web Services*/
            WeatherDataServiceFactory wdf = new WeatherDataServiceFactory();

            /*iwds will hold an object that represent the chosen REStful web service*/
            IWeatherDataService iwds;

            /*option will hold the option the user chose from the menu*/
            int option;

            while (true)
            {
                Console.WriteLine("Please choose the desired action:\n1. Check tempature\n2. Exit program\n");
                option = Int32.Parse(Console.ReadLine());
                if (option == 2)
                    System.Environment.Exit(1);
                if (option != 1)
                    continue;
                /*Getting location data from user*/
                Console.WriteLine("Please enter the country full name: ");
                loc.Country = Console.ReadLine();
                Console.WriteLine("Please enter the country code: ");
                loc.CountryCode = Console.ReadLine();
                Console.WriteLine("Please enter the city name: ");
                loc.City = Console.ReadLine();

                /*Getting the right REStful Web Service and checking the tempature and humidity*/
                iwds = wdf.GetWeatherDataService(10);
                wd = iwds.GetWeatherData(loc);
                Console.WriteLine("The tempature in " + loc.Country+" - "+loc.City + " is :  " + wd.Temapture + "C |"+" Humidity is: "+wd.Humidity+"%\n");
            }
        }
    }
}
```
### Output
![WeatherLibrary](https://user-images.githubusercontent.com/12692788/56203645-51f16180-604e-11e9-8d57-0fb20f7b0f5c.jpg)

