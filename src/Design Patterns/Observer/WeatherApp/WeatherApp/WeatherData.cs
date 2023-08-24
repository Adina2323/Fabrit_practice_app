using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    /// <summary>
    /// Abstract class representing weather data.
    /// </summary>
    internal abstract class WeatherData
    {

        private List<User> _subscribers = new List<User>();

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherData"/> class.
        /// </summary>
        public WeatherData()
        {
            _subscribers = new List<User>();
        }

        /// <summary>
        /// Adds a subscriber to the weather data.
        /// </summary>
        /// <param name="subscriber">The subscriber to add.</param>
        public void AddSubscribers(User subscriber)
        {
            _subscribers.Add(subscriber);
        }

        /// <summary>
        /// Removes a subscriber from the weather data.
        /// </summary>
        /// <param name="subscriber">The subscriber to remove.</param>
        public void RemoveSubscriber(User subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        /// <summary>
        /// Notifies all subscribers with the provided weather update.
        /// </summary>
        /// <param name="weatherUpdate">The weather update to send.</param>
        public void NotifySubscribers(string weatherUpdate)
        {
            _subscribers.ForEach(subscriber => subscriber.Update(weatherUpdate));
        }

        /// <summary>
        /// Updates the weather data with the given weather update.
        /// </summary>
        /// <param name="weatherUpdate">The weather update to apply.</param>
        public abstract void UpdateWeather(string weatherUpdate);
    }
}
