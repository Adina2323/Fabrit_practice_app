using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    /// <summary>
    /// Represents a notification that can be sent to users.
    /// </summary>
    internal abstract class Notification
    {
        /// <summary>
        /// Notifies the user.
        /// </summary>
        public abstract void  Notify();
    }
}
