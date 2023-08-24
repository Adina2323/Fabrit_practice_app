using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    /// <summary>
    /// Represents a menu for interacting with a text editor's formatting options.
    /// </summary>
    internal class Menu
    {
        BoldFormatStrategy boldFormatStrategy = new BoldFormatStrategy();
        ItalicFormatStrategy italicFormatStrategy = new ItalicFormatStrategy();
        UnderlineFormatStrategy underlineFormatStrategy = new UnderlineFormatStrategy();

        /// <summary>
        /// Displays the available formatting options in the menu.
        /// </summary>
        private void ShowMenu()
        {
            Console.WriteLine("Welcome to the text editor! What kind of font would you like?");
            Console.WriteLine("1. Bold");
            Console.WriteLine("2. Underline");
            Console.WriteLine("3. Italic");
            Console.WriteLine("4. Remove Formatting");
            Console.WriteLine("5. Exit\n\n");
        }

        /// <summary>
        /// Displays the menu options for choosing text formatting and handles user input.
        /// </summary>
        public void HandleUserInput()
        {
            ShowMenu();
            var textEditor = new TextEditor();
            Console.WriteLine("Insert the option you want, or just write text to see the formatting taking place.");
            int.TryParse(Console.ReadLine(), out var opt);
            switch (opt)
            {
                case 1:
                    HandleBoldOption(textEditor);
                    break;
                case 2:
                    HandleUnderlineOption(textEditor);
                    break;
                case 3:
                    HandleItalicOption(textEditor);
                    break;
                case 4:
                    HandleRemoveFormatting(textEditor);
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Retry.");
                    break;

            }
        }

        /// <summary>
        /// Applies the bold formatting strategy to the provided text editor.
        /// </summary>
        /// <param name="textEditor">The text editor to apply formatting to.</param>
        private void HandleBoldOption(TextEditor textEditor)
        {
            textEditor.setStrategy(boldFormatStrategy);
            textEditor.executeFormat();
        }

        /// <summary>
        /// Applies the italic formatting strategy to the provided text editor.
        /// </summary>
        /// <param name="textEditor">The text editor to apply formatting to.</param>
        private void HandleItalicOption(TextEditor textEditor)
        {
            textEditor.setStrategy(italicFormatStrategy);
            textEditor.executeFormat();
        }

        /// <summary>
        /// Applies the underline formatting strategy to the provided text editor.
        /// </summary>
        /// <param name="textEditor">The text editor to apply formatting to.</param>
        private void HandleUnderlineOption(TextEditor textEditor)
        {
            textEditor.setStrategy(underlineFormatStrategy);
            textEditor.executeFormat();
        }

        /// <summary>
        /// Removes formatting from the provided text editor.
        /// </summary>
        /// <param name="textEditor">The text editor to remove formatting from.</param>
        private void HandleRemoveFormatting(TextEditor textEditor)
        {
            textEditor.setStrategy(boldFormatStrategy);
            textEditor.removeFormat();
        }
    }
}
