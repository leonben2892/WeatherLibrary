
namespace WeatherLibrary
{
    //Implemented as factory design pattern
    public class WeatherDataServiceFactory
    {
        const int OPEN_WEATHER_MAP = 10;

        /*This method will return an object from the right REStful Web Service class*/
        public IWeatherDataService GetWeatherDataService(int weatherService)
        {
            if (OPEN_WEATHER_MAP == weatherService)
                return WeatherDataService.Instance;
            return null;
        }
    }
}
