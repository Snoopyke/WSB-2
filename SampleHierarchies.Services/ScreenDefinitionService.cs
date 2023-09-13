using Newtonsoft.Json;
using SampleHierarchies.Data;
using SampleHierarchies.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Services
{
    /// <summary>
    /// Screen definition service
    /// </summary>
    public static class ScreenDefinitionService
    {
        /// method used to read json and show lines
        public static void ConsoleLine(string jsonPath, int id, string argument = "")
        {
            try
            {
                ScreenDefinition screens = Load(jsonPath);
                if (screens == null) { throw new NullReferenceException(); }
                if (screens.LineEntries.Count < 0 || screens.LineEntries.Count < 0) throw new InvalidDataException();
                Console.BackgroundColor = screens.LineEntries[id].BgColor;
                Console.ForegroundColor = screens.LineEntries[id].FrColor;
                if (argument != "") Console.WriteLine(screens.LineEntries[id].Text?.Replace("arg", argument));
                if (argument == "") Console.WriteLine(screens.LineEntries[id].Text);

                Console.ResetColor();
            }
            catch
            {
                Console.WriteLine("Error while showing line");
            }
        }

        #region Private Methods

        /// method used to load json
        private static ScreenDefinition Load (string jsonFileName)
        {
            try
            {
                if (!File.Exists(jsonFileName)) throw new FileNotFoundException();
                string jsonContent = File.ReadAllText(jsonFileName);
                var screenDefinition = JsonConvert.DeserializeObject<ScreenDefinition>(jsonContent);
                if (screenDefinition == null) throw new NullReferenceException();
                return screenDefinition;
            }
            catch
            {
                Console.WriteLine("Failed to successfully serialize json");
                return new ScreenDefinition();
            }

        }
        #endregion // Private methods
    }
}
