using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleHierarchies.Services;

namespace SampleHierarchies.Tests
{
    [TestClass]
    public class ScreenDefinitionServiceTests
    {
        [TestMethod]

        // Test for testion ScreenDefinitionService.ConsoleLine()

        public void ShowScreenContent_ValidArguments_DisplaysContent()
        {
            // Arrange
            string jsonPath = "JsonForUnitTests.json";
            int lineNr = 0;
            string predictText = "This is text for test";
            string result;
            ConsoleColor predictBgColor = ConsoleColor.Black;
            ConsoleColor predictFrColor = ConsoleColor.Gray;
            StringWriter reader = new StringWriter();

            // Act
            Console.SetOut(reader);
            ScreenDefinitionService.ConsoleLine(jsonPath, lineNr);

            result = reader.ToString().Trim();
            predictText.Trim();
            // Assert
            Assert.IsTrue(result == predictText && Console.BackgroundColor == predictBgColor && Console.ForegroundColor == predictFrColor);
        }
    }
}