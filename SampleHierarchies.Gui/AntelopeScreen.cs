using SampleHierarchies.Data;
using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui
{
    /// <summary>
    /// Antelope's screen.
    /// </summary>
    public sealed class AntelopeScreen : Screen
    {
        #region Properties And Ctor

        /// <summary>
        /// Data service.
        /// </summary>
        private readonly IDataService _dataService;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="dataService">Data service reference</param>
        public AntelopeScreen(IDataService dataService)
        {
            _dataService = dataService;
        }

        #endregion Properties And Ctor

        #region Public Methods

        /// <inheritdoc/>
        public override void Show()
        {
            while (true)
            {
                Console.Clear();
                ScreenDefinitionService.ConsoleLine("AntelopeScreen.json", 27);
                ScreenDefinitionService.ConsoleLine("AntelopeScreen.json", 0);
                ScreenDefinitionService.ConsoleLine("AntelopeScreen.json", 1);
                ScreenDefinitionService.ConsoleLine("AntelopeScreen.json", 2);
                ScreenDefinitionService.ConsoleLine("AntelopeScreen.json", 3);
                ScreenDefinitionService.ConsoleLine("AntelopeScreen.json", 4);
                ScreenDefinitionService.ConsoleLine("AntelopeScreen.json", 5);
                ScreenDefinitionService.ConsoleLine("AntelopeScreen.json", 6);

                string? choiceAsString = Console.ReadLine();

                // Validate choice
                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    AntelopeScreenChoices choice = (AntelopeScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case AntelopeScreenChoices.List:
                            ListAntelope();
                            Console.ReadLine();
                            break;

                        case AntelopeScreenChoices.Create:
                            AddAntelope();
                            Console.ReadLine();

                            break;

                        case AntelopeScreenChoices.Delete:
                            DeleteAntelope();
                            Console.ReadLine();

                            break;

                        case AntelopeScreenChoices.Modify:
                            EditAntelopeMain();
                            Console.ReadLine();
                            break;

                        case AntelopeScreenChoices.Exit:
                            ScreenDefinitionService.ConsoleLine("AntelopeScreen.json", 7);
                            Console.ReadLine();
                            return;
                    }
                }
                catch
                {
                    ScreenDefinitionService.ConsoleLine("AntelopeScreen.json", 8);
                }
            }
        }

        #endregion // Public Methods

        #region Private Methods

        /// <summary>
        /// List all antelopes.
        /// </summary>
        private void ListAntelope()
        {
            Console.WriteLine();
            if (_dataService?.Animals?.Mammals?.Antelopes is not null &&
                _dataService.Animals.Mammals.Antelopes.Count > 0)
            {
                ScreenDefinitionService.ConsoleLine("AntelopeScreen.json", 9);
                int i = 1;
                foreach (Antelope antelope in _dataService.Animals.Mammals.Antelopes)
                {
                    ScreenDefinitionService.ConsoleLine("AntelopeScreen.json", 10, i.ToString());
                    antelope.Display();
                    i++;
                }
            }
            else
            {
                ScreenDefinitionService.ConsoleLine("AntelopeScreen.json", 11);
            }
        }

        /// <summary>
        /// Add an antelope.
        /// </summary>
        private void AddAntelope()
        {
            try
            {
                Antelope antelope = AddEditAntelope();
                _dataService?.Animals?.Mammals?.Antelopes?.Add(antelope);
                ScreenDefinitionService.ConsoleLine("AntelopeScreen.json", 12, antelope.Name);
            }
            catch
            {
                ScreenDefinitionService.ConsoleLine("AntelopeScreen.json", 13);
            }
        }

        /// <summary>
        /// Deletes an antelope.
        /// </summary>
        private void DeleteAntelope()
        {
            try
            {
                ScreenDefinitionService.ConsoleLine("AntelopeScreen.json", 14);
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Antelope? antelope = (Antelope?)(_dataService?.Animals?.Mammals?.Antelopes
                    ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (antelope is not null)
                {
                    _dataService?.Animals?.Mammals?.Antelopes?.Remove(antelope);
                    ScreenDefinitionService.ConsoleLine("AntelopeScreen.json", 15, antelope.Name);
                }
                else
                {
                    ScreenDefinitionService.ConsoleLine("AntelopeScreen.json", 16);
                }
            }
            catch
            {
                ScreenDefinitionService.ConsoleLine("AntelopeScreen.json", 17);
            }
        }

        /// <summary>
        /// Edits an existing antelope after choice made.
        /// </summary>
        private void EditAntelopeMain()
        {
            try
            {
                ScreenDefinitionService.ConsoleLine("AntelopeScreen.json", 18);
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Antelope? antelope = (Antelope?)(_dataService?.Animals?.Mammals?.Antelopes?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (antelope is not null)
                {
                    Antelope antelopeEdited = AddEditAntelope();
                    antelope.Copy(antelopeEdited);
                    ScreenDefinitionService.ConsoleLine("AntelopeScreen.json", 19);
                    antelope.Display();
                }
                else
                {
                    ScreenDefinitionService.ConsoleLine("AntelopeScreen.json", 20);
                }
            }
            catch
            {
                ScreenDefinitionService.ConsoleLine("AntelopeScreen.json", 21);
            }
        }

        /// <summary>
        /// Adds/edits specific antelope.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private Antelope AddEditAntelope()
        {
            ScreenDefinitionService.ConsoleLine("AntelopeScreen.json", 22);
            string? name = Console.ReadLine();
            ScreenDefinitionService.ConsoleLine("AntelopeScreen.json", 23);
            string? ageAsString = Console.ReadLine();
            ScreenDefinitionService.ConsoleLine("AntelopeScreen.json", 24);
            string? lifeSpanAsString = Console.ReadLine();
            ScreenDefinitionService.ConsoleLine("AntelopeScreen.json", 25);
            string? socialStructure = Console.ReadLine();
            ScreenDefinitionService.ConsoleLine("AntelopeScreen.json", 26);
            string? diet = Console.ReadLine();

            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (ageAsString is null)
            {
                throw new ArgumentNullException(nameof(ageAsString));
            }
            if (lifeSpanAsString is null)
            {
                throw new ArgumentNullException(nameof(lifeSpanAsString));
            }
            if (socialStructure is null)
            {
                throw new ArgumentNullException(nameof(socialStructure));
            }
            if (diet is null)
            {
                throw new ArgumentNullException(nameof(diet));
            }
            int age = Int32.Parse(ageAsString);
            int lifeSpan= Int32.Parse(lifeSpanAsString);
            Antelope antelope = new Antelope(name, age, lifeSpan, socialStructure, diet);
            return antelope;
        }

        #endregion // Private Methods
    }
}