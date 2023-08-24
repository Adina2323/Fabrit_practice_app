using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
    /// <summary>
    /// Class<c>BasicBook</c>models a simple book
    /// </summary>
    internal class BasicBook:IBook
    {
        /// <summary>
        /// Property <c> Name </c> represents the Name of the book
        /// </summary>
        public string Name {  get; set; }

        /// <summary>
        /// Property <c> Pages </c> represents the number of Pages of the book
        /// </summary>
        public int Pages { get; set; }


        /// <summary>
        /// Property <c> BookStatus </c> represents the Status of the book
        /// </summary>
        public Status BookStatus { get; set; }

        /// <summary>
        /// Constructs an object with the given parameters
        /// </summary>
        /// <param Name="Pages"></param>
        /// <param Name="name"></param>
        /// <param Name="Status"></param>
        public BasicBook(
            int pages,
            string name ,
            Status boookStatus) 
        {
            Pages = pages;
            Name = name;
            BookStatus = boookStatus;

        }
        /// <summary>
        /// Method to check out a book 
        /// </summary>
        public void Checkout()
        {
            BookStatus = Status.CheckedOut;

        }

        /// <summary>
        /// Method to return a book 
        /// </summary>
        public void Return()
        {
            BookStatus = Status.InStock;
        }

        /// <summary>
        /// Writes the books in a easier to read format
        /// </summary>
        /// <returns>a string containg book info</returns>
        public override string ToString()
        {
            return $"Book: {Name}\nNumber of Pages: {Pages}\nStatus: {BookStatus}\nNot Reservable\nNot Renewable\n";
        }
    }
}
