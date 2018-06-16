
namespace WeatherLibrary
{
    public class Location
    {
        public string countryCode;
        public string country;
        public string city;

        public Location()
        {
            this.countryCode = null;
            this.country = null;
            this.city = null;
        }

        public string CountryCode { get => countryCode; set => countryCode = value; }
        public string Country { get => country; set => country = value; }
        public string City { get => city; set => city = value; }       
    }
}
