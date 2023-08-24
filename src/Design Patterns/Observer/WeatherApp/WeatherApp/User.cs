using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WeatherApp
{
    /// <summary>
    /// Represents a user of the weather application.
    /// </summary>
    internal class User
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        public string Name { get; set; }
        private readonly WeatherData _weatherData;
        private readonly Notification _notification;

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="name">The name of the user.</param>
        /// <param name="weatherData">The weather data provider.</param>
        /// <param name="notification">The notification method to use.</param>
        public User(
            string name, 
            WeatherData weatherData, 
            Notification notification) 
        {
            Name = name;
            _weatherData = weatherData;
            _notification = notification;
        }

        /// <summary>
        /// Subscribes the user to receive weather updates.
        /// </summary>
        public void SubscribeToWeather()
        {
            _weatherData.AddSubscribers(this);
        }

        /// <summary>
        /// Unsubscribes the user from receiving weather updates.
        /// </summary>
        public void UnsubscribeFromWeather()
        {
            _weatherData.RemoveSubscriber(this);
        }

        /// <summary>
        /// Receives a weather update and gets notified.
        /// </summary>
        /// <param name="weatherUpdate">The weather update message.</param>
        public void Update(string weatherUpdate)
        {
            _notification.Notify();
            Console.WriteLine($"User {Name} received weather update: {weatherUpdate}.\n\n");
        }
    }
}
