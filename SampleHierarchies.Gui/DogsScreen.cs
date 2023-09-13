using SampleHierarchies.Data;
using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data.Mammals;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Mammals main screen.
/// </summary>
public sealed class DogsScreen : Screen
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
    public DogsScreen(IDataService dataService)
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
            ScreenDefinitionService.ConsoleLine("DogsScreen.json", 25);
            ScreenDefinitionService.ConsoleLine("DogsScreen.json", 0);
            ScreenDefinitionService.ConsoleLine("DogsScreen.json", 1);
            ScreenDefinitionService.ConsoleLine("DogsScreen.json", 2);
            ScreenDefinitionService.ConsoleLine("DogsScreen.json", 3);
            ScreenDefinitionService.ConsoleLine("DogsScreen.json", 4);
            ScreenDefinitionService.ConsoleLine("DogsScreen.json", 5);
            ScreenDefinitionService.ConsoleLine("DogsScreen.json", 6);

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                DogsScreenChoices choice = (DogsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case DogsScreenChoices.List:
                        ListDogs();
                        Console.ReadLine();
                        break;

                    case DogsScreenChoices.Create:
                        AddDog();
                        Console.ReadLine();
                        break;

                    case DogsScreenChoices.Delete: 
                        DeleteDog();
                        Console.ReadLine();
                        break;

                    case DogsScreenChoices.Modify:
                        EditDogMain();
                        Console.ReadLine();
                        break;

                    case DogsScreenChoices.Exit:
                        ScreenDefinitionService.ConsoleLine("DogsScreen.json", 7);
                        Console.ReadLine();

                        return;
                }
            }
            catch
            {
                ScreenDefinitionService.ConsoleLine("DogsScreen.json", 8);
            }
        }
    }

    #endregion // Public Methods

    #region Private Methods

    /// <summary>
    /// List all dogs.
    /// </summary>
    private void ListDogs()
    {
        Console.WriteLine();
        if (_dataService?.Animals?.Mammals?.Dogs is not null &&
            _dataService.Animals.Mammals.Dogs.Count > 0)
        {
            ScreenDefinitionService.ConsoleLine("DogsScreen.json", 9);
            int i = 1;
            foreach (Dog dog in _dataService.Animals.Mammals.Dogs)
            {
                ScreenDefinitionService.ConsoleLine("DogsScreen.json", 10, i.ToString());
                dog.Display();
                i++;
            }
        }
        else
        {
            ScreenDefinitionService.ConsoleLine("DogsScreen.json", 11);
        }
    }

    /// <summary>
    /// Add a dog.
    /// </summary>
    private void AddDog()
    {
        try
        {
            Dog dog = AddEditDog();
            _dataService?.Animals?.Mammals?.Dogs?.Add(dog);
            ScreenDefinitionService.ConsoleLine("DogsScreen.json", 12, dog.Name);
        }
        catch
        {
            ScreenDefinitionService.ConsoleLine("DogsScreen.json", 13);
        }
    }

    /// <summary>
    /// Deletes a dog.
    /// </summary>
    private void DeleteDog()
    {
        try
        {
            ScreenDefinitionService.ConsoleLine("DogsScreen.json", 14);
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Dog? dog = (Dog?)(_dataService?.Animals?.Mammals?.Dogs
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (dog is not null)
            {
                _dataService?.Animals?.Mammals?.Dogs?.Remove(dog);
                ScreenDefinitionService.ConsoleLine("DogsScreen.json", 15, dog.Name);
            }
            else
            {
                ScreenDefinitionService.ConsoleLine("DogsScreen.json", 16);
            }
        }
        catch
        {
            ScreenDefinitionService.ConsoleLine("DogsScreen.json", 17);
        }
    }

    /// <summary>
    /// Edits an existing dog after choice made.
    /// </summary>
    private void EditDogMain()
    {
        try
        {
            ScreenDefinitionService.ConsoleLine("DogsScreen.json", 18);
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Dog? dog = (Dog?)(_dataService?.Animals?.Mammals?.Dogs
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (dog is not null)
            {
                Dog dogEdited = AddEditDog();
                dog.Copy(dogEdited);
                ScreenDefinitionService.ConsoleLine("DogsScreen.json", 19);
                dog.Display();
            }
            else
            {
                ScreenDefinitionService.ConsoleLine("DogsScreen.json", 20);
            }
        }
        catch
        {
            ScreenDefinitionService.ConsoleLine("DogsScreen.json", 21);
        }
    }

    /// <summary>
    /// Adds/edit specific dog.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    private Dog AddEditDog()
    {
        ScreenDefinitionService.ConsoleLine("DogsScreen.json", 22);
        string? name = Console.ReadLine();
        ScreenDefinitionService.ConsoleLine("DogsScreen.json", 23);
        string? ageAsString = Console.ReadLine();
        ScreenDefinitionService.ConsoleLine("DogsScreen.json", 24);
        string? breed = Console.ReadLine();

        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        if (ageAsString is null)
        {
            throw new ArgumentNullException(nameof(ageAsString));
        }
        if (breed is null)
        {
            throw new ArgumentNullException(nameof(breed));
        }
        int age = Int32.Parse(ageAsString);
        Dog dog = new Dog(name, age, breed);

        return dog;
    }

    #endregion // Private Methods
}
