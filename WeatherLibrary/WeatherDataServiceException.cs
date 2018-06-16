using System;

namespace WeatherLibrary
{
    public class CountryNotFoundException : Exception
    {
        /// <summary>
        /// Create the exception with description
        /// </summary>
        /// <param name="message">Exception description</param>
        public CountryNotFoundException(String message)
          : base(message)
        {
        }
    }

    public class CityNotFoundException : Exception
    {
        /// <summary>
        /// Create the exception with description
        /// </summary>
        /// <param name="message">Exception description</param>
        public CityNotFoundException(String message)
          : base(message)
        {
        }
    }

    public class NoConnectionException : Exception
    {
        /// <summary>
        /// Create the exception with description
        /// </summary>
        /// <param name="message">Exception description</param>
        public NoConnectionException(String message)
          : base(message)
        {
        }
    }
}
