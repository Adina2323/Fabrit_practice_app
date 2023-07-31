using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReading
{
    /// <summary>
    /// Class <c>FileReader</c> handles the methods for reading a file in sync and async manner.
    /// </summary>
    internal class FileReader
    {
        /// <summary>
        /// This method reads a file synchronous.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns> A string containing all the text from the file. </returns>
        public string ReadFileSync(string filePath) 
        {
            try
            {
                using(var streamReader = new StreamReader(filePath))
                {
                    var fileText = streamReader.ReadToEnd();
                    return fileText;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in file reading: " + ex.ToString());
                return string.Empty;
            }
        }

        /// <summary>
        /// This method reads a file asynchronous.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns> A string containing all the text from the file. </returns>
        public async Task<string> ReadFileAsync(string filePath)
        {
            try
            {
                using(var streamReader = new StreamReader(filePath))
                {
                    var fileText = await streamReader.ReadToEndAsync();
                    return fileText;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error in file reading: " + ex.ToString());
                return string.Empty;
            }
        }
    }
}
