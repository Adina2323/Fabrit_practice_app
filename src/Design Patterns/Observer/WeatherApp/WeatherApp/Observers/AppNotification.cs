using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    /// <summary>
    /// Represents an app notification that can be sent to users.
    /// </summary>
    internal class AppNotification : Notification
    {
        /// <summary>
        /// Notifies the user with an app notification.
        /// </summary>
        public override void Notify()
        {
            Console.WriteLine("An app notification has been sent!");
        }
    }
}
