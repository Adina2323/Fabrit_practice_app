using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    /// <summary>
    /// Represents a formatting strategy to apply bold formatting to text.
    /// </summary>
    internal class BoldFormatStrategy : FormatStrategy
    {
        /// <summary>
        /// Applies bold formatting to the text.
        /// </summary>
        public override void Format()
        {
            Console.WriteLine("Text formatting added \u001b[1m BOLD.\x1b[1m");
        }

    }
}
