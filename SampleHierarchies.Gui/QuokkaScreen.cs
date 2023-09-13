using SampleHierarchies.Data;
using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data.Mammals;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui
{
    /// <summary>
    /// Quokka's screen.
    /// </summary>
    public sealed class QuokkaScreen : Screen
    {
        #region Properties And Ctor

        /// <summary>
        /// Data service.
        /// </summary>
        private IDataService _dataService;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="dataService">Data service reference</param>
        public QuokkaScreen(IDataService dataService)
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
                ScreenDefinitionService.ConsoleLine("QuokkaScreen.json", 27);
                ScreenDefinitionService.ConsoleLine("QuokkaScreen.json", 0);
                ScreenDefinitionService.ConsoleLine("QuokkaScreen.json", 1);
                ScreenDefinitionService.ConsoleLine("QuokkaScreen.json", 2);
                ScreenDefinitionService.ConsoleLine("QuokkaScreen.json", 3);
                ScreenDefinitionService.ConsoleLine("QuokkaScreen.json", 4);
                ScreenDefinitionService.ConsoleLine("QuokkaScreen.json", 5);
                ScreenDefinitionService.ConsoleLine("QuokkaScreen.json", 6);

                string? choiceAsString = Console.ReadLine();

                // Validate choice
                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    QuokkaScreenChoices choice = (QuokkaScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case QuokkaScreenChoices.List:
                            ListQuokka();
                            Console.ReadLine();
                            break;

                        case QuokkaScreenChoices.Create:
                            AddQuokka();
                            Console.ReadLine();
                            break;

                        case QuokkaScreenChoices.Delete:
                            DeleteQuokka();
                            Console.ReadLine();
                            break;

                        case QuokkaScreenChoices.Modify:
                            EditQuokkaMain();
                            Console.ReadLine();
                            break;

                        case QuokkaScreenChoices.Exit:
                            ScreenDefinitionService.ConsoleLine("QuokkaScreen.json", 7);
                            Console.ReadLine();
                            return;
                    }
                }
                catch
                {   
                    ScreenDefinitionService.ConsoleLine("QuokkaScreen.json", 8);
                }
            }
        }

        #endregion // Public Methods

        #region Private Methods

        /// <summary>
        /// List all quokka's.
        /// </summary>
        private void ListQuokka()
        {
            Console.WriteLine();
            if (_dataService?.Animals?.Mammals?.Quokkas is not null &&
                _dataService.Animals.Mammals.Quokkas.Count > 0)
            {
                ScreenDefinitionService.ConsoleLine("QuokkaScreen.json", 9);
                int i = 1;
                foreach (Quokka quokka in _dataService.Animals.Mammals.Quokkas)
                {
                    ScreenDefinitionService.ConsoleLine("QuokkaScreen.json", 10, i.ToString());
                    quokka.Display();
                    i++;
                }
            }
            else
            {
                ScreenDefinitionService.ConsoleLine("QuokkaScreen.json", 11);
            }
        }

        /// <summary>
        /// Add a quokka.
        /// </summary>
        private void AddQuokka()
        {
            try
            {
                Quokka quokka = AddEditQuokka();
                _dataService?.Animals?.Mammals?.Quokkas?.Add(quokka);
                ScreenDefinitionService.ConsoleLine("QuokkaScreen.json", 12, quokka.Name);
            }
            catch
            {
                ScreenDefinitionService.ConsoleLine("QuokkaScreen.json", 13);
            }
        }

        /// <summary>
        /// Deletes a quokka.
        /// </summary>
        private void DeleteQuokka()
        {
            try
            {
                ScreenDefinitionService.ConsoleLine("QuokkaScreen.json", 14);
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Quokka? quokka = (Quokka?)(_dataService?.Animals?.Mammals?.Quokkas
                    ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (quokka is not null)
                {
                    _dataService?.Animals?.Mammals?.Quokkas?.Remove(quokka);
                    ScreenDefinitionService.ConsoleLine("QuokkaScreen.json", 15, quokka.Name);
                }
                else
                {
                    ScreenDefinitionService.ConsoleLine("QuokkaScreen.json", 16);
                }
            }
            catch
            {   
                ScreenDefinitionService.ConsoleLine("QuokkaScreen.json", 17);
            }
        }

        /// <summary>
        /// Edits an existing quokka after choice made.
        /// </summary>
        private void EditQuokkaMain()
        {
            try
            {
                ScreenDefinitionService.ConsoleLine("QuokkaScreen.json", 18);
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Quokka? quokka = (Quokka?)(_dataService?.Animals?.Mammals?.Quokkas?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (quokka is not null)
                {
                    Quokka quokkaEdited = AddEditQuokka();
                    quokka.Copy(quokkaEdited);
                    ScreenDefinitionService.ConsoleLine("QuokkaScreen.json", 19);
                    quokka.Display();
                }
                else
                {
                    ScreenDefinitionService.ConsoleLine("QuokkaScreen.json", 20);
                }
            }
            catch
            {
                ScreenDefinitionService.ConsoleLine("QuokkaScreen.json", 21);
            }
        }

        /// <summary>
        /// Adds/edit specific quokka.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private Quokka AddEditQuokka()
        {
            ScreenDefinitionService.ConsoleLine("QuokkaScreen.json", 22);
            string? name = Console.ReadLine();
            ScreenDefinitionService.ConsoleLine("QuokkaScreen.json", 23);
            string? ageAsString = Console.ReadLine();
            ScreenDefinitionService.ConsoleLine("QuokkaScreen.json", 24);
            string? habitat = Console.ReadLine();
            ScreenDefinitionService.ConsoleLine("QuokkaScreen.json", 25);
            string? weightAsString = Console.ReadLine();
            ScreenDefinitionService.ConsoleLine("QuokkaScreen.json", 26);
            string? socialBehavior = Console.ReadLine();

            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (ageAsString is null)
            {
                throw new ArgumentNullException(nameof(ageAsString));
            }
            if (habitat is null)
            {
                throw new ArgumentNullException(nameof(habitat));
            }
            if (weightAsString is null)
            {
                throw new ArgumentNullException(nameof(weightAsString));
            }
            if (socialBehavior is null)
            {
                throw new ArgumentNullException(nameof(socialBehavior));
            }
            int age = int.Parse(ageAsString);
            int weight = int.Parse(weightAsString);

            Quokka quokka = new Quokka(name, age, habitat, weight, socialBehavior);
            return quokka;
        }

        #endregion // Private Methods
    }
}
