using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    internal abstract class FormatStrategy
    {
        /// <summary>
        /// Applies the specified formatting to the text.
        /// </summary>
        public abstract void Format();

        /// <summary>
        /// Removes the applied formatting from the text.
        /// </summary>
        public void Unformat()
        {
            Console.WriteLine("\x1b[0mText formatting removed.\x1b[0m");
        }
    }
}
