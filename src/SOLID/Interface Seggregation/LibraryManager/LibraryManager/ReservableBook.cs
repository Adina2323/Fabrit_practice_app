using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
    internal class ReservableBook:IBook,IReserveBook
    {
        /// <summary>
        /// Property <c> Name </c> represents the Name of the book
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Property <c> Pages </c> represents the number of Pages of the book
        /// </summary>
        public int Pages { get; set; }

        /// <summary>
        /// Property <c> Status </c> represents the Status of the book
        /// </summary>
        public Status BookStatus { get; set; }

        /// <summary>
        /// Property <c> IsReserved </c> is true if the book is reserved, false otherwise
        /// </summary>
        public bool IsReserved { get; set; }

        /// <summary>
        /// Constructs an object with the given parameters
        /// </summary>
        /// <param Name="Pages"></param>
        /// <param Name="name"></param>
        /// <param Name="Status"></param>
        public ReservableBook(int pages,string name, Status status) 
        {
            Pages = pages;
            Name = name;
            BookStatus = status;
            IsReserved = false;
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
        /// Method to reserve a book 
        /// </summary>
        public void Reserve()
        {
            IsReserved = true;
        }

        /// <summary>
        /// Writes the books in a easier to read format
        /// </summary>
        /// <returns>a string containg book info</returns>
        public override string ToString()
        {
            if (IsReserved)
            {
                return $"Book: {Name}\nNumber of Pages: {Pages}\nStatus: {BookStatus}\nReserved\nNot renewable\n";
            }
            else 
            {
                return $"Book: {Name}\nNumber of Pages: {Pages}\nStatus: {BookStatus}\nAvailable for reservation\nNot renewable\n";
            }

        }
    }

}
