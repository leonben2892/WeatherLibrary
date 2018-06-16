
namespace WeatherLibrary
{
    public interface IWeatherDataService
    {
        WeatherData GetWeatherData(Location location);
        string FirstCharToUpper(string input);
        bool checkCityAndCountry(Location tmpLoc);
    }
}