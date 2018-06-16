using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherLibrary.Tests
{
    [TestClass()]
    public class WeatherDataServiceTests
    {
        [TestMethod()]
        public void FirstCharToUpperTest()
        {
            WeatherDataServiceFactory wdf = new WeatherDataServiceFactory();
            IWeatherDataService iwds = wdf.GetWeatherDataService(10);
            string test = iwds.FirstCharToUpper("united states");
            Assert.Equals(test, "United States");
        }

        [TestMethod()]
        public void checkCityAndCountryTest()
        {
            Location loc = new Location();
            loc.Country = "Israel";
            loc.CountryCode = "il";
            loc.City = "holon";
            WeatherDataServiceFactory wdf = new WeatherDataServiceFactory();
            IWeatherDataService iwds = wdf.GetWeatherDataService(10);
            bool test = iwds.checkCityAndCountry(loc);
            Assert.Equals(test, true);
        }

        [TestMethod()]
        public void GetWeatherDataTest()
        {
            Location loc = new Location();
            loc.Country = "Israel";
            loc.CountryCode = "il";
            loc.City = "holon";
            WeatherDataServiceFactory wdf = new WeatherDataServiceFactory();
            IWeatherDataService iwds = wdf.GetWeatherDataService(10);
            WeatherData wd = iwds.GetWeatherData(loc);
            Assert.AreNotEqual(wd.Temapture, -99);
            Assert.AreNotEqual(wd.Humidity, -99);
        }
    }
}