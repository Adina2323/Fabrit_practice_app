using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    /// <summary>
    /// Represents a text notification that can be sent to users.
    /// </summary>
    internal class TextNotification : Notification
    {
        /// <summary>
        /// Notifies the user with a text message.
        /// </summary>
        public override void Notify()
        {
            Console.WriteLine("A text message has been sent! ");
        }
    }
}
