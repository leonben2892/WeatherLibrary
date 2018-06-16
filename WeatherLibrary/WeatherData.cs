
namespace WeatherLibrary
{
    public class WeatherData
    {
        private float temapture;
        private float humidity;

        public WeatherData()
        {
            this.temapture = -99;
            this.humidity = -99;
        }

        public float Temapture { get => temapture; set => temapture = value; }
        public float Humidity { get => humidity; set => humidity = value; }
    }
}
