using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Mammals main screen.
/// </summary>
public sealed class MammalsScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Animals screen.
    /// </summary>
    private readonly DogsScreen _dogsScreen;
    private readonly AntelopeScreen _antelopeScreen;
    private readonly WhaleScreen _whaleScreen;
    private readonly QuokkaScreen _qokkaScreen;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="dogsScreen">Dogs screen</param>
    public MammalsScreen(DogsScreen dogsScreen, AntelopeScreen antelopeScreen, WhaleScreen whaleScreen, QuokkaScreen qokkaScreen)
    {
        _dogsScreen = dogsScreen;
        _antelopeScreen = antelopeScreen;
        _whaleScreen = whaleScreen;
        _qokkaScreen = qokkaScreen;
    }

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            Console.Clear();
            ScreenDefinitionService.ConsoleLine("MammalsScreen.json", 9);
            ScreenDefinitionService.ConsoleLine("MammalsScreen.json", 0);
            ScreenDefinitionService.ConsoleLine("MammalsScreen.json", 1);
            ScreenDefinitionService.ConsoleLine("MammalsScreen.json", 2);
            ScreenDefinitionService.ConsoleLine("MammalsScreen.json", 3);
            ScreenDefinitionService.ConsoleLine("MammalsScreen.json", 4);
            ScreenDefinitionService.ConsoleLine("MammalsScreen.json", 5);
            ScreenDefinitionService.ConsoleLine("MammalsScreen.json", 6);

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                MammalsScreenChoices choice = (MammalsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case MammalsScreenChoices.Dogs:
                        _dogsScreen.Show(); break;
                    case MammalsScreenChoices.Antelope:
                        _antelopeScreen.Show(); break;
                    case MammalsScreenChoices.Quokka:
                        _qokkaScreen.Show(); break;
                    case MammalsScreenChoices.Whale:
                        _whaleScreen.Show(); break;
                    case MammalsScreenChoices.Exit:
                        ScreenDefinitionService.ConsoleLine("MammalsScreen.json", 7);
                        return;
                }
            }
            catch
            {
                ScreenDefinitionService.ConsoleLine("MammalsScreen.json", 8);
            }
        }
    }

    #endregion // Public Methods
}
