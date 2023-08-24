using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheaterApp
{
    /// <summary>
    /// Class <c>WeatherAPI</c> retrieves weather information 
    /// </summary>
    internal class WeatherAPI:IRetrieveData
    {
        /// <summary>
        /// Method creates the WeatherData instance with the information received and returns it
        /// </summary>
        /// <param name="location"></param>
        /// <returns>WeatherData</returns>
        public WeatherData GetData(string location)
        {
            var weatherData = new WeatherData()
            {
                Location = location,
                Temperature = 0,
                Humidity = 0,
                Description = string.Empty
            };
            return weatherData; 
        }
    }
}
