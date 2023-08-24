using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    /// <summary>
    /// Represents a text editor that applies and removes formatting using a specified strategy.
    /// </summary>
    internal class TextEditor
    {
        private FormatStrategy _formatStrategy;

        /// <summary>
        /// Sets the formatting strategy to be used by the text editor.
        /// </summary>
        /// <param name="formatStrategy">The formatting strategy to be set.</param>
        public void setStrategy(FormatStrategy formatStrategy)
        {
            _formatStrategy = formatStrategy;
        }

        /// <summary>
        /// Executes the current formatting strategy to apply formatting.
        /// </summary>
        public void executeFormat()
        {
            _formatStrategy.Format();
        }

        /// <summary>
        /// Removes the formatting applied using the current strategy.
        /// </summary>
        public void removeFormat()
        {
            _formatStrategy.Unformat();
        }

    }
}
