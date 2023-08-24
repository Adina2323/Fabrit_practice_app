using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
    enum Status
    {
        InStock,
        CheckedOut
    }

    /// <summary>
    /// Interface <c>IBook</c> handles the basic kind of book 
    /// </summary>
    internal interface IBook
    {
        /// <summary>
        /// Property <c> Name </c> represents the Name of the book
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Property <c> Pages </c> represents the number of Pages of the book
        /// </summary>
        int Pages { get; set; }

        /// <summary>
        /// Property <c> BookStatus </c> represents the status of the book.
        /// </summary>
        Status BookStatus { get; set; }

        /// <summary>
        /// Method to CheckOut a book
        /// </summary>
        void Checkout();

        /// <summary>
        /// Method to return a book
        /// </summary>
        void Return();

    }
}
