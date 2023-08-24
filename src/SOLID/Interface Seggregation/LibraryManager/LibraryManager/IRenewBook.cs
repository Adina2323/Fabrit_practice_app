using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
    /// <summary>
    /// Interface <c>IRenewBook</c> models a renewable book
    /// </summary>
    internal interface IRenewBook : IBook
    {
        /// <summary>
        /// Property<c>IsRenewed</c>true if is renewed, false otherwise
        /// </summary>
        bool IsRenewed { set;get; }

        /// <summary>
        /// Method to Renew a book
        /// </summary>
        void Renew();

    }
}
