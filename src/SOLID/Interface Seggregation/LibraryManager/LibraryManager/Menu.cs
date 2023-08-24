using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
    /// <summary>
    /// Class <c>Menu</c> Handles The User options and actions
    /// </summary>
    internal class Menu
    {
        /// <summary>
        /// Initialises a list of books with some default values
        /// </summary>
        /// <returns></returns>
        public List<IBook> AppStart()
        {
            List<IBook> books = new List<IBook>()
            {
                new BasicBook(100, "Carte1", Status.InStock),
                new BasicBook(200, "Carte2", Status.CheckedOut),
                new RenewableBook(300, "Carte3", Status.InStock),
                new RenewableBook(400, "Carte4", Status.CheckedOut),
                new ReservableBook(500, "Carte5", Status.InStock),
                new ReservableBook(600, "Carte6", Status.CheckedOut)

            };
            return books;
        }

        /// <summary>
        /// Displays the Menu 
        /// </summary>
        public void ShowMenu()
        {
            Console.WriteLine("Choose an option: ");
            Console.WriteLine("1. Checkout a book");
            Console.WriteLine("2. Return book");
            Console.WriteLine("3. Reserve book");
            Console.WriteLine("4. Renew book");
            Console.WriteLine("5. Show all books");
            Console.WriteLine("6. Exit");
        }

        /// <summary>
        /// Manages the user input to perform the desired actions
        /// </summary>
        public void HandleUserOptions(List<IBook> books)
        {
            ShowMenu();
            Console.WriteLine("Insert the number of the option you want: ");
            var opt = int.Parse(Console.ReadLine());
            switch (opt)
            {
                case 1:
                    HandleCheckout(books);                    
                    break;
                case 2:
                    HandleReturn(books);
                    break;
                case 3:
                    HandleReserve(books);
                    break;
                case 4:
                    HandleRenew(books);
                    break;
                case 5:
                    ShowAllBooks(books); 
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

        /// <summary>
        /// Handles the checkout method
        /// </summary>
        /// <param Name="books"></param>
        public void HandleCheckout(List<IBook> books)
        {
            Console.WriteLine("Insert the Name of the book you want to check out:");
            var name = Console.ReadLine().Trim();

            foreach(var book in books)
            {
                if (book.Name.Equals(name) && book.BookStatus.Equals(Status.InStock))
                {
                    book.Checkout();
                    Console.WriteLine(book.ToString());
                    return;
                }
                if(book.Name.Equals(name) && !book.BookStatus.Equals(Status.CheckedOut))
                {
                    Console.WriteLine("Book already checked out.");
                    return;
                }   
            }
            Console.WriteLine("Book not found.");
            return;
        }

        /// <summary>
        /// Handles the return method
        /// </summary>
        /// <param Name="books"></param>
        public void HandleReturn(List<IBook> books)
        {
            Console.WriteLine("Insert the Name of the book you want to return:");
            var name = Console.ReadLine().Trim();

            foreach (var book in books)
            {
                if (book.Name.Equals(name) && book.BookStatus.Equals(Status.CheckedOut))
                {
                    book.Return();
                    return;
                }
                if (book.Name.Equals(name) && book.BookStatus.Equals(Status.InStock))
                {
                    Console.WriteLine("Book already returned.");
                    return;
                }
            }
            Console.WriteLine("Book not found.");
            return;
        }

        /// <summary>
        /// Handles the reserve method
        /// </summary>
        /// <param Name="books"></param>
        public void HandleReserve(List<IBook> books)
        {
            Console.WriteLine("Insert the Name of the book you want to reserve:");
            var name = Console.ReadLine().Trim();

            foreach (var book in books)
            {
                if (book.Name.Equals(name) && book is IReserveBook reserveBook)
                {
                    reserveBook.Reserve();
                    Console.WriteLine(reserveBook.ToString());
                    return;
                }
                else if (book.Name.Equals(name) && !(book is IReserveBook))
                {
                    Console.WriteLine("Sorry, the book is not reservable.");
                    return;
                }
            }
            Console.WriteLine("Book not found.");
            return;
        }

        /// <summary>
        /// Handles the renew method
        /// </summary>
        /// <param Name="books"></param>
        public void HandleRenew(List<IBook> books)
        {
            Console.WriteLine("Insert the Name of the book you want to renew:");
            var name = Console.ReadLine().Trim();

            foreach (var book in books)
            {
                if (book.Name.Equals(name) && book is IRenewBook renewBook)
                {
                    renewBook.Renew();
                    Console.WriteLine(renewBook.ToString());
                    return;
                }
                else if (book.Name.Equals(name) && !(book is IRenewBook))
                {
                    Console.WriteLine("Sorry, the book is not renewable.");
                    return;
                }
            }
            Console.WriteLine("Book not found.");
            return;
        }

        /// <summary>
        /// Displays all the books
        /// </summary>
        /// <param Name="books"></param>
        public void ShowAllBooks(List<IBook> books)
        {
            foreach(var book in books)
            {
                Console.WriteLine(book.ToString());
            }
        }
    }
}
