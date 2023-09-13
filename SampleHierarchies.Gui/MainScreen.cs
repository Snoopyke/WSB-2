using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Application main screen.
/// </summary>
public sealed class MainScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service.
    /// </summary>

    /// <summary>
    /// Animals screen.
    /// </summary>
    private readonly AnimalsScreen _animalsScreen;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="animalsScreen">Animals screen</param>
    public MainScreen(
        AnimalsScreen animalsScreen)
    {
        _animalsScreen = animalsScreen;
    }
    
    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            Console.Clear();
            ScreenDefinitionService.ConsoleLine("MainScreen.json", 7);
            ScreenDefinitionService.ConsoleLine("MainScreen.json", 0);
            ScreenDefinitionService.ConsoleLine("MainScreen.json", 1);
            ScreenDefinitionService.ConsoleLine("MainScreen.json", 2);
            ScreenDefinitionService.ConsoleLine("MainScreen.json", 4);

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                MainScreenChoices choice = (MainScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case MainScreenChoices.Animals:
                        _animalsScreen.Show();
                        break;

                    case MainScreenChoices.Exit:
                        ScreenDefinitionService.ConsoleLine("MainScreen.json", 5);
                        return;
                }
            }
            catch
            {
                ScreenDefinitionService.ConsoleLine("MainScreen.json", 6);
            }
        }
    }

    #endregion // Public Methods
}