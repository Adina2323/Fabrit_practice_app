using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    /// <summary>
    /// Represents a formatting strategy to apply italic formatting to text.
    /// </summary>
    internal class ItalicFormatStrategy : FormatStrategy
    {
        /// <summary>
        /// Applies italic formatting to the text.
        /// </summary>
        public override void Format()
        {
            Console.WriteLine("Text format added \u001b[3m ITALIC.\x1b[3m");
        }

    }
}
