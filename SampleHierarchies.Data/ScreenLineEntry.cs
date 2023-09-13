using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Data
{
    /// <summary>
    /// Screen line entry class
    /// </summary>
    public class ScreenLineEntry
    {
        /// <summary>
        /// Props
        /// </summary>
        public ConsoleColor BgColor = ConsoleColor.Black;
        public ConsoleColor FrColor = ConsoleColor.White;
        public string? Text { get; set; }
    }
}
