using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheaterApp
{
    /// <summary>
    /// Interface <c>IRetrieveData</c> models the methods for data retrieving 
    /// </summary>
    internal interface IRetrieveData
    {
        /// <summary>
        /// Method to get Data Weather based on Location
        /// </summary>
        /// <param name="location"></param>
        /// <returns>Weather data instance</returns>
        WeatherData GetData(string location);
    }
}
