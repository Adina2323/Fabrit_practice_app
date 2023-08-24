using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheaterApp
{
    internal class Program
    {
        /// <summary>
        /// Method to test the functionalities
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var weatherAPI = new WeatherAPI();
            var weatherService = new WeatherService(weatherAPI);

            var location = "Cluj";
            var weatherData = weatherService.GetWeather(location);
            Console.WriteLine(weatherData.ToString());
            Console.ReadKey();

        
        }
    }
}
