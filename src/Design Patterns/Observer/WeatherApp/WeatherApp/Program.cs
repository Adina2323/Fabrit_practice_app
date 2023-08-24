using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
 
    internal class Program
    {
        /// <summary>
        /// The main program entry point.
        /// </summary>
        static void Main(string[] args)
        {
            var newYorkWeather = new NewYorkWeatherData();
            var londonWeather = new LondonWeatherData();
            var sydneyWeather = new SydneyWeatherData();

            var textNotification = new TextNotification();
            var appNotification = new AppNotification();
            var emailNotification = new EmailNotification();

            var user1 = new User("Human1", newYorkWeather, appNotification);
            user1.SubscribeToWeather();

            var user11 = new User("Human11", newYorkWeather, appNotification);
            user11.SubscribeToWeather();

            var user111 = new User("Human111", newYorkWeather, appNotification);
            user111.SubscribeToWeather();

            var user2 = new User("Human2", londonWeather, textNotification);
            user2.SubscribeToWeather();

            var user3 = new User("Human3", sydneyWeather, emailNotification);
            user3.SubscribeToWeather();

            user1.Update("weather2");
            user2.Update("weather2");
            user3.Update("weather2");
            user11.UnsubscribeFromWeather();

            newYorkWeather.UpdateWeather("\tweather1");
            londonWeather.UpdateWeather("\tweather1");
            sydneyWeather.UpdateWeather("\tweather1");

            Console.ReadKey();
        }
    }
}
