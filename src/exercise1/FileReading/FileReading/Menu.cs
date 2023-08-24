using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FileReading
{
    /// <summary>
    /// Class <c>Menu</c> models the menu.
    /// </summary>
    public class Menu
    { 
        /// <summary>
        /// Displays the options for the user.
        /// </summary>
        public void ShowMenuOptions()
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Read File Synchronous");
            Console.WriteLine("2. Read File Asynchronous");
            Console.WriteLine("3. Read File Both Synchronous and Asynchronous");
            Console.WriteLine("4. Exit.\n");
            Console.WriteLine();
            Console.Write("Insert the number of the preffered choice:");
        }

        /// <summary>
        /// Handles the cases for each option.
        /// </summary>
        public async Task HandleMenu()
        {
            ShowMenuOptions();
            var opt = int.Parse(Console.ReadLine());
            switch(opt)
            {
                case 1: ReadSync();
                    break;
                case 2: await ReadAsync();
                    break;
                case 3: await ReadSyncAndAsync();
                    break;
                case 4: Environment.Exit(0);
                    break;
                default: Console.WriteLine("The option is invalid. Remember, the option needs to be a number from 1 to 4.");
                    break;
            }
        }

        /// <summary>
        /// Handles the option for synchronous reading
        /// </summary>
        public void ReadSync()
        {
            var fileReader = new FileReader();
            Console.WriteLine("\nEnter the path to the file: ");
            var filePath = Console.ReadLine();

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var fileText = fileReader.ReadFileSync(filePath);
            var report = new FileReport(fileText, filePath);


            stopwatch.Stop();
            Console.WriteLine($"\nThe file was read in: {stopwatch.Elapsed.TotalMilliseconds} miliseconds.\n");
            report.GenerateReport();
        }

        /// <summary>
        /// Handles the option for asynchronous reading.
        /// </summary>
        public async Task ReadAsync()
        {
            var fileReader = new FileReader();
            Console.WriteLine("\nEnter the path to the file: ");
            var filePath = Console.ReadLine();

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var fileText = await fileReader.ReadFileAsync(filePath);
            stopwatch.Stop();
            var report = new FileReport(fileText, filePath);

            Console.WriteLine($"\nThe file was read in: {stopwatch.Elapsed.TotalMilliseconds} miliseconds.\n");
            report.GenerateReport();
        }

        /// <summary>
        /// Handles the reading for sync and async reading.
        /// </summary>
        public async Task ReadSyncAndAsync()
        {
            var fileReader = new FileReader();
            Console.WriteLine("\nEnter the path to the file: ");
            var filePath = Console.ReadLine();

            var stopwatchSync = new Stopwatch();
            stopwatchSync.Start();
            fileReader.ReadFileSync(filePath);
            stopwatchSync.Stop();

            var stopwatchAsync = new Stopwatch();
            stopwatchAsync.Start();
            var fileText = await fileReader.ReadFileAsync(filePath);
            stopwatchAsync.Stop();

            Console.WriteLine($"\nThe file was read synchronous in: {stopwatchSync.Elapsed.TotalMilliseconds} miliseconds and asynchronous in: {stopwatchAsync.Elapsed.TotalMilliseconds} miliseconds.\n");
            var report = new FileReport(fileText, filePath);
            report.GenerateReport();
        }
    }
}
