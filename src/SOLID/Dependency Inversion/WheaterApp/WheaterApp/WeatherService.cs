using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheaterApp
{
    /// <summary>
    /// Class <c>WeatherService</c> responsible for weather data retrieve
    /// </summary>
    internal class WeatherService
    {
        /// <summary>
        /// Property<c>retrieveData</c> instance of the interface used for data retrieving 
        /// </summary>
        private IRetrieveData _retrieveData;

        /// <summary>
        /// Initializes the parameter with the given object 
        /// </summary>
        /// <param name="retrieveData"></param>
        public WeatherService(IRetrieveData retrieveData)
        {
            _retrieveData = retrieveData;
        }

        /// <summary>
        /// Method to get Weather based on the Location
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public WeatherData GetWeather(string location)
        {
            return _retrieveData.GetData(location);
        }
    }
}
