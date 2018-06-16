using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;

namespace WeatherLibrary
{
    //Implemented as singletone design pattern
    public class WeatherDataService : IWeatherDataService
    {
        private static WeatherDataService instance;
        private WeatherDataService() { }
        public static WeatherDataService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WeatherDataService();
                }
                return instance;
            }
        }

        /*Return a WeatherData object that holds the tempature of the desired location*/
        public WeatherData GetWeatherData(Location location)
        {
            dynamic data;
            location.Country = FirstCharToUpper(location.Country); //First char to upper case
            location.City = FirstCharToUpper(location.City); //First char to upper case
            bool validation = checkCityAndCountry(location);
            if (validation == false)
            {
                throw new CityNotFoundException("City not found.");
            }
            WebClient client = new WebClient();
            WeatherData weather = new WeatherData();
            string first = "http://api.openweathermap.org/data/2.5/weather?q=" ;
            string second = "&APPID=c89903b8e6c7eb03b19cb8592cfe402a";
            string finalString = first + location.City + "," + location.CountryCode + second;
            try
            {
                var json = client.DownloadString(finalString);
                data = JObject.Parse(json);
                float temp = data.main.temp;
                int humidity = data.main.humidity;
                temp = temp - 273.15f;
                weather.Temapture = temp;
                weather.Humidity = humidity;
            }
            catch(NoConnectionException e)
            {
                Console.WriteLine(e.Source);
            }

            return weather;
        }
        
        /*Return a string with the first char in every word as uppercase char*/
        public string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            input = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
            return input;
        }

        /*return true if the country and city was found, else throws the appropriate exception*/
        public bool checkCityAndCountry(Location tmpLoc)
        {
            StreamReader r = new StreamReader("CountryAndCityList.json");
            string json = r.ReadToEnd();
            var test = JObject.Parse(json);
            JArray items = (JArray)test[tmpLoc.Country];
            if (items == null)
            {
                throw new CountryNotFoundException("Country not found.");
            }
            int length = items.Count;
            for (int i = 0; i < length; i++)
            {
                if (String.Equals(tmpLoc.City, (string)items[i]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

