using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    /// <summary>
    /// Represents an email notification that can be sent to users.
    /// </summary>
    internal class EmailNotification : Notification
    {
        /// <summary>
        /// Notifies the user with an email.
        /// </summary>
        public override void Notify()
        {
            Console.WriteLine("An email has been sent!");
        }
    }
}
