using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
    /// <summary>
    /// Interface <c>IReserveBook</c> models a reservable book
    /// </summary>
    internal interface IReserveBook:IBook
    {
        /// <summary>
        /// Property<c>IsReserved</c> is true if the book is reserved, false otherwise
        /// </summary>
        bool IsReserved { get; set; }

        /// <summary>
        /// MEthod to reserve a book
        /// </summary>
        void Reserve();
    }
}
