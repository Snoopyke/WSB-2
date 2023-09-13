using SampleHierarchies.Data;
using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui
{
    /// <summary>
    /// Whale's screen.
    /// </summary>
    public sealed class WhaleScreen : Screen
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
        public WhaleScreen(IDataService dataService)
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
                ScreenDefinitionService.ConsoleLine("WhaleScreen.json", 27);
                ScreenDefinitionService.ConsoleLine("WhaleScreen.json", 0);
                ScreenDefinitionService.ConsoleLine("WhaleScreen.json", 1);
                ScreenDefinitionService.ConsoleLine("WhaleScreen.json", 2);
                ScreenDefinitionService.ConsoleLine("WhaleScreen.json", 3);
                ScreenDefinitionService.ConsoleLine("WhaleScreen.json", 4);
                ScreenDefinitionService.ConsoleLine("WhaleScreen.json", 5);
                ScreenDefinitionService.ConsoleLine("WhaleScreen.json", 6);

                string? choiceAsString = Console.ReadLine();

                // Validate choice
                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    WhaleScreenChoices choice = (WhaleScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case WhaleScreenChoices.List:
                            ListWhale();
                            Console.ReadLine();
                            break;

                        case WhaleScreenChoices.Create:
                            AddWhale();
                            Console.ReadLine();
                            break;

                        case WhaleScreenChoices.Delete:
                            DeleteWhale();
                            Console.ReadLine();
                            break;

                        case WhaleScreenChoices.Modify:
                            EditWhaleMain();
                            Console.ReadLine();
                            break;

                        case WhaleScreenChoices.Exit:
                            ScreenDefinitionService.ConsoleLine("WhaleScreen.json", 7);
                            Console.ReadLine();
                            return;
                    }
                }
                catch
                {
                    ScreenDefinitionService.ConsoleLine("WhaleScreen.json", 8);
                }
            }
        }

        #endregion // Public Methods

        #region Private Methods

        /// <summary>
        /// List all whale's.
        /// </summary>
        private void ListWhale()
        {
            Console.WriteLine();
            if (_dataService?.Animals?.Mammals?.Whales is not null &&
                _dataService.Animals.Mammals.Whales.Count > 0)
            {
                ScreenDefinitionService.ConsoleLine("WhaleScreen.json", 9);
                int i = 1;
                foreach (Whale whale in _dataService.Animals.Mammals.Whales)
                {
                    ScreenDefinitionService.ConsoleLine("WhaleScreen.json", 10, i.ToString());
                    whale.Display();
                    i++;
                }
            }
            else
            {
                ScreenDefinitionService.ConsoleLine("WhaleScreen.json", 11);
            }
        }

        /// <summary>
        /// Add a whale.
        /// </summary>
        private void AddWhale()
        {
            try
            {
                Whale whale = AddEditWhale();
                _dataService?.Animals?.Mammals?.Whales?.Add(whale);
                ScreenDefinitionService.ConsoleLine("WhaleScreen.json", 12, whale.Name);
            }
            catch
            {
                ScreenDefinitionService.ConsoleLine("WhaleScreen.json", 13);
            }
        }

        /// <summary>
        /// Deletes a whale.
        /// </summary>
        private void DeleteWhale()
        {
            try
            {
                ScreenDefinitionService.ConsoleLine("WhaleScreen.json", 14);
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Whale? whale = (Whale?)(_dataService?.Animals?.Mammals?.Whales
                    ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (whale is not null)
                {
                    _dataService?.Animals?.Mammals?.Whales?.Remove(whale);
                    ScreenDefinitionService.ConsoleLine("WhaleScreen.json", 15, whale.Name);
                }
                else
                {
                    ScreenDefinitionService.ConsoleLine("WhaleScreen.json", 16);
                }
            }
            catch
            {
                ScreenDefinitionService.ConsoleLine("WhaleScreen.json", 17);
            }
        }

        /// <summary>
        /// Edits an existing whale after choice made.
        /// </summary>
        private void EditWhaleMain()
        {
            try
            {
                ScreenDefinitionService.ConsoleLine("WhaleScreen.json", 18);
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Whale? whale = (Whale?)(_dataService?.Animals?.Mammals?.Whales?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (whale is not null)
                {
                    Whale whaleEdited = AddEditWhale();
                    whale.Copy(whaleEdited);
                    ScreenDefinitionService.ConsoleLine("WhaleScreen.json", 19);
                    whale.Display();
                }
                else
                {
                    ScreenDefinitionService.ConsoleLine("WhaleScreen.json", 20);
                }
            }
            catch
            {
                ScreenDefinitionService.ConsoleLine("WhaleScreen.json", 21);
            }
        }

        /// <summary>
        /// Adds/edit specific whale.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private Whale AddEditWhale()
        {
            ScreenDefinitionService.ConsoleLine("WhaleScreen.json", 22);
            string? name = Console.ReadLine();
            ScreenDefinitionService.ConsoleLine("WhaleScreen.json", 23);
            string? ageAsString = Console.ReadLine();
            ScreenDefinitionService.ConsoleLine("WhaleScreen.json", 24);
            string? reproduction = Console.ReadLine();
            ScreenDefinitionService.ConsoleLine("WhaleScreen.json", 25);
            string? sound = Console.ReadLine();
            ScreenDefinitionService.ConsoleLine("WhaleScreen.json", 26);
            string? migrationPatterns = Console.ReadLine();

            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (ageAsString is null)
            {
                throw new ArgumentNullException(nameof(ageAsString));
            }
            if (reproduction is null)
            {
                throw new ArgumentNullException(nameof(sound));
            }
            if (sound is null)
            {
                throw new ArgumentNullException(nameof(sound));
            }
            if (migrationPatterns is null)
            {
                throw new ArgumentNullException(nameof(migrationPatterns));
            }
            int age = Int32.Parse(ageAsString);
            Whale whale = new Whale(name, age, reproduction, sound, migrationPatterns);
            return whale;
        }

        #endregion // Private Methods
    }
}
