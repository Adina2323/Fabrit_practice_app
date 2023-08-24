using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheaterApp
{
    /// <summary>
    /// Class <c>WeatherData</c> models the information received by API
    /// </summary>
    internal class WeatherData
    {
        /// <summary>
        /// Property <c>Location</c> represents the Location of the weather information
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Property <c>Location</c> represents the Temperature
        /// </summary>
        public double Temperature { get; set; }

        /// <summary>
        /// Property <c>Location</c> represents the Humidity in the Location
        /// </summary>
        public double Humidity { get; set; }

        /// <summary>
        /// Property <c>Location</c> represents the Description of the weather forcast
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Writes the Weather Data in a readable format
        /// </summary>
        /// <returns>string with the readable format</returns>
        public override string ToString()
        {
            return $"Weather Data for: {Location}\nTemperature: {Temperature}\nHumidity: {Humidity}\nDescription: {Description}\n";
        }
    }
}
