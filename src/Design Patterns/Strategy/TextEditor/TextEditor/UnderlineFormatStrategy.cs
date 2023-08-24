using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    /// <summary>
    /// Represents a formatting strategy to apply underline formatting to text.
    /// </summary>
    internal class UnderlineFormatStrategy : FormatStrategy
    {
        /// <summary>
        /// Applies underline formatting to the text.
        /// </summary>
        public override void Format()
        {
            Console.WriteLine("Text format added \u001b[4mUNDERLINE\x1b[4m");
        }

    }
}
