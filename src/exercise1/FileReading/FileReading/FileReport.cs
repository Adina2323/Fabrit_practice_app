using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace FileReading
{
    /// <summary>
    /// Class <c> FileReport </c> models the file report.
    /// </summary>
    public class FileReport
    {
        /// <value>
        /// Property <c>fileText</c> represents the file's contents.
        /// </value>

        string FileText { get; set; }

        /// <value>
        /// Property <c>filePath</c> represents the file's contents.
        /// </value>
        string FilePath { get; set; }

        /// <summary>
        /// A constructor that initializes the new FileReport to
        /// (<paramref name="fileText"/>,<paramref name="filePath"/>)
        /// </summary>
        /// <param name="fileText"></param>
        /// <param name="filePath"></param>
        public FileReport(string fileText, string filePath)
        {
            FilePath = filePath;
            FileText = fileText;
        }

        /// <summary>
        /// The method generates the report in the Console.
        /// </summary>
        public void GenerateReport()
        {
            Console.WriteLine($"Here is your report for the file on the path:\"{FilePath}\"");
            Console.WriteLine($"The number of lines in the file is: {LinesOfTextCount()}");
            Console.WriteLine($"The size file is: {GetSizeOfFile()}");
            Console.WriteLine($"The number of pargraphs is: {GetNumberOfParagraphs()}");
            Console.WriteLine($"The number of words in the file is: {GetNumberOfWords()}");
            Console.WriteLine($"The number of unique words is: {GetNumberOfUniqueWords()}");
            var mostFrequentWords = GetMostFrequentWords();
            Console.WriteLine($"The most frequent word/s is/are: \"{string.Join(", ", mostFrequentWords)}\"");
            var longestWords = GetLongestWords();
            Console.WriteLine($"The longest word/s in the file is/are: \"{string.Join(", ", longestWords)}\"");
            Console.WriteLine("Press anything to go back to the menu.");
        }

        /// <summary>
        /// This method counts the number of lines in the file. 
        /// </summary>
        /// <returns>An integer with the number of lines.</returns>
        public int LinesOfTextCount()
        {
            var pattern = @"\n";
            var noLines = 0;

            // Use Regex.Matches to find all occurrences of the pattern in the text.
            var matches = Regex.Matches(FileText, pattern);

            noLines = matches.Count + 1;
            return noLines;
        }

        /// <summary>
        /// This method gets the size of the file.
        /// </summary>
        /// <returns>The size of the file in a double value.</returns>
        public double GetSizeOfFile()
        {
            try
            {
                var file = new FileInfo(FilePath);
                return file.Length;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error in File reading.{e}");
                return -1;
            }

        }

        /// <summary>
        /// This method gets the number of paragraphs
        /// </summary>
        /// <returns>An integer with the number of paragraphs.</returns>
        public int GetNumberOfParagraphs()
        {
            var pattern = @"(?<=\n\s*\n)";

            // Use Regex.Matches to find all occurrences of the pattern in the text.
            var matches = Regex.Matches(FileText, pattern);

            return matches.Count;
        }

        /// <summary>
        /// This method gets the number of words.
        /// </summary>
        /// <returns>An integer with the number of words.</returns>
        public int GetNumberOfWords()
        {
            var words = FileText.Split(new char[] { ' ', '\t', '\n', '\r', '.', ',', '!', '?', ':', ';', '(', ')', '[', ']', '{', '}' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        /// <summary>
        /// This method gets the number of unique words.
        /// </summary>
        /// <returns>An integer with the number of unique words.</returns>
        public int GetNumberOfUniqueWords()
        {
            var words = FileText.Split(new char[] { ' ', '\t', '\n', '\r', '.', ',', '!', '?', ':', ';', '(', ')', '[', ']', '{', '}' }, StringSplitOptions.RemoveEmptyEntries);
            var uniqueWords = new HashSet<string>();

            foreach (var word in words)
            {
                if (!uniqueWords.Contains(word))
                {
                    uniqueWords.Add(word);
                }
            }
            return uniqueWords.Count;
        }

        /// <summary>
        /// This method find the words with the biggest number of occurances.
        /// </summary>
        /// <returns>A list of strings with the words that appear most frequent.</returns>
        public List<string> GetMostFrequentWords()
        {
            var maxFrequency = 0;
            var words = FileText.Split(new char[] { ' ', '\t', '\n', '\r', '.', ',', '!', '?', ':', ';', '(', ')', '[', ']', '{', '}' }, StringSplitOptions.RemoveEmptyEntries);
            var mostFrequentWords = new List<string>();
            var wordFrequency = new Dictionary<string, int>();

            foreach (string word in words)
            {

                if (string.IsNullOrEmpty(word))
                {
                    continue;
                }

                if (wordFrequency.ContainsKey(word))
                {
                    wordFrequency[word]++;
                }
                else
                {
                    wordFrequency[word] = 1;
                }
            }

            foreach (var frequency in wordFrequency.Values)
            {
                if (frequency > maxFrequency)
                {
                    maxFrequency = frequency;
                }
            }

            foreach (var pair in wordFrequency)
            {
                if (pair.Value == maxFrequency)
                {
                    mostFrequentWords.Add(pair.Key);
                }
            }
            return mostFrequentWords;
        }

        /// <summary>
        /// This method finds the longest words.
        /// </summary>
        /// <returns>A list of strings with the words that are the longest.</returns>
        public List<string> GetLongestWords()
        {
            var words = FileText.Split(new char[] { ' ', '\t', '\n', '\r', '.', ',', '!', '?', ':', ';', '(', ')', '[', ']', '{', '}' }, StringSplitOptions.RemoveEmptyEntries);
            var maxLength = 0;
            var longestWords = new List<string>();

            foreach (var word in words)
            {
                if (!string.IsNullOrEmpty(word))
                {
                    if (word.Length > maxLength)
                    {
                        maxLength = word.Length;
                        longestWords.Clear();
                        longestWords.Add(word);
                    }
                    else if (word.Length == maxLength)
                    {
                        longestWords.Add(word);
                    }
                }
            }
            return longestWords;
        }
    }
}
