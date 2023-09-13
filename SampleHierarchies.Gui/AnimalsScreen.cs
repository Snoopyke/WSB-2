using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Animals main screen.
/// </summary>
public sealed class AnimalsScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service.
    /// </summary>
    private IDataService _dataService;

    /// <summary>
    /// Animals screen.
    /// </summary>
    private MammalsScreen _mammalsScreen;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="animalsScreen">Animals screen</param>
    public AnimalsScreen(
        IDataService dataService,
        MammalsScreen mammalsScreen)
    {
        _dataService = dataService;
        _mammalsScreen = mammalsScreen;
    }

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            Console.Clear();
            ScreenDefinitionService.ConsoleLine("AnimalsScreen.json", 14);
            ScreenDefinitionService.ConsoleLine("AnimalsScreen.json", 0);
            ScreenDefinitionService.ConsoleLine("AnimalsScreen.json", 1);
            ScreenDefinitionService.ConsoleLine("AnimalsScreen.json", 2);
            ScreenDefinitionService.ConsoleLine("AnimalsScreen.json", 3);
            ScreenDefinitionService.ConsoleLine("AnimalsScreen.json", 4);
            ScreenDefinitionService.ConsoleLine("AnimalsScreen.json", 5);

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                AnimalsScreenChoices choice = (AnimalsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case AnimalsScreenChoices.Mammals:
                        _mammalsScreen.Show();
                        break;

                    case AnimalsScreenChoices.Read:
                        ReadFromFile();
                        Console.ReadLine();
                        break;

                    case AnimalsScreenChoices.Save:
                        SaveToFile();
                        Console.ReadLine();
                        break;

                    case AnimalsScreenChoices.Exit:
                        ScreenDefinitionService.ConsoleLine("AnimalsScreen.json", 6);
                        return;
                }
            }
            catch
            {
                ScreenDefinitionService.ConsoleLine("AnimalsScreen.json", 7);
            }
        }
    }

    #endregion // Public Methods

    #region Private Methods

    /// <summary>
    /// Save to file.
    /// </summary>
    private void SaveToFile()
    {
        try
        {
            ScreenDefinitionService.ConsoleLine("AnimalsScreen.json", 8);
            var fileName = Console.ReadLine();
            if (fileName is null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }
            _dataService.Write(fileName);
            ScreenDefinitionService.ConsoleLine("AnimalsScreen.json", 9, fileName);
        }
        catch
        {
            ScreenDefinitionService.ConsoleLine("AnimalsScreen.json", 10);
        }
    }

    /// <summary>
    /// Read data from file.
    /// </summary>
    private void ReadFromFile()
    {
        try
        {
            ScreenDefinitionService.ConsoleLine("AnimalsScreen.json", 11);
            var fileName = Console.ReadLine();
            if (fileName is null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }
            _dataService.Write(fileName);
            ScreenDefinitionService.ConsoleLine("AnimalsScreen.json", 12, fileName);
        }
        catch
        {
            ScreenDefinitionService.ConsoleLine("AnimalsScreen.json", 13);
        }
    }

    #endregion // Private Methods
}
