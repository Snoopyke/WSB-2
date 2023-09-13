using System;

namespace SampleHierarchies.Data
{
    /// <summary>
    /// Screen Defition class
    /// </summary>
    public class ScreenDefinition
    {
        /// <summary>
        /// Props
        /// </summary>
        public List<ScreenLineEntry> LineEntries { get; set; } = new List<ScreenLineEntry>();
    }
}
