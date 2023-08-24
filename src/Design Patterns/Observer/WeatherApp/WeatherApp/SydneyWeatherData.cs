using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    /// <summary>
    /// Represents weather data for Sydney.
    /// </summary>
    internal class SydneyWeatherData:WeatherData
    {
        private string _currentWeather;

        /// <summary>
        /// Updates the weather data for Sydney and notifies subscribers.
        /// </summary>
        /// <param name="weatherUpdate">The weather update to apply.</param>
        public override void UpdateWeather(string weatherUpdate)
        {
            _currentWeather = "Sydney" + weatherUpdate;
            NotifySubscribers(_currentWeather);
        }
    }
}
