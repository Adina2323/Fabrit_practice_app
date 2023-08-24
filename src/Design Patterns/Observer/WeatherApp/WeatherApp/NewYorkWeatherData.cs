using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    /// <summary>
    /// Represents weather data for NewYork.
    /// </summary>
    internal class NewYorkWeatherData : WeatherData
    {
        private string _currentWeather;

        /// <summary>
        /// Updates the weather data for NewYork and notifies subscribers.
        /// </summary>
        /// <param name="weatherUpdate">The weather update to apply.</param>
        public override void UpdateWeather(string weatherUpdate)
        {
            _currentWeather = "New York" + weatherUpdate;
            NotifySubscribers(_currentWeather);
        }
    }
}
