using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, List<string>> dictionary = PopulateDictionary();

        // Infinite loop that keeps displaying the menu until the user exits.
        while (true) 
        {
            // Displays the available menu options to the user.
            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1: Display Dictionary Contents");
            Console.WriteLine("2: Remove a Key");
            Console.WriteLine("3: Add a New Key and Value");
            Console.WriteLine("4: Add a Value to an Existing Key");
            Console.WriteLine("5: Sort the Keys");
            Console.WriteLine("6: Exit");

            // Gets the users menu choice as a string
            string choice = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(choice) || !"123456".Contains(choice)) // Checks if user input is valid(non-empty and outside of 1-6).
            {
                Console.WriteLine("Invalid choice, please enter a number from 1 to 6."); 
                continue; // If invalid input, continue to the next iteration of the loop
            }

            // Switch statement to handle the user's choice
            switch (choice)
            {
                case "1":
                    // Displays Dictionary Contents
                    DisplayDictionaryContents(dictionary);
                    break;
                case "2":
                    // Asks the user which key they want to remove
                    Console.Write("Enter the key to remove: ");
                    string keyToRemove = Console.ReadLine().ToLower(); // Convert to lowercase for case-insensitive comparison
                    // Calls a method to remove the key
                    RemoveKey(dictionary, keyToRemove); 
                    break;
                case "3":
                    // Asks the user which key or value they want to add
                    Console.Write("Enter the new key: ");
                    string newKey = Console.ReadLine().ToLower(); // Convert to lowercase for case-insensitive comparison
                    Console.Write("Enter the value (comma-separated if multiple): ");
                    string[] values = Console.ReadLine().Split(','); // Split input into an array by commas
                    // Call method to add new key-value pair
                    AddNewKeyValue(dictionary, newKey, new List<string>(Array.ConvertAll(values, v => v.Trim())));
                    break;
                case "4":
                    // Ask for the existing key and the new value to add
                    Console.Write("Enter the existing key: ");
                    string existingKey = Console.ReadLine().ToLower(); // Convert to lowercase for case-insensitive comparison
                    Console.Write("Enter the value to add: ");
                    string valueToAdd = Console.ReadLine();
                    // Call method to add a value to the existing key
                    AddValueToExistingKey(dictionary, existingKey, valueToAdd);
                    break;
                case "5":
                    // Call method to sort and display keys
                    SortKeys(dictionary);
                    break;
                case "6":
                    // Exit the program with a friendly message
                    Console.WriteLine("Exiting... Have a great day!");
                    return;
                default:
                    // Handle invalid menu choice 
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }

    // Method to populate the dictionary with some initial data
    static Dictionary<string, List<string>> PopulateDictionary()
    {
        // Return a new dictionary with predefined keys and values
        return new Dictionary<string, List<string>>
        {
            { "sports", new List<string> { "Soccer", "Football", "Basketball", "Baseball", "Golf" } },    // Key "sports" with list of values
            { "country", new List<string> { "United States", "Cuba", "Mexico", "Uruguay", "France" } },  // Key "country" with list of values
            { "vegetable", new List<string> { "Carrot", "Broccoli", "Potato", "Spinach", "Eggplant" } } // Key "vegetable" with list of values
        };
    }

    // Method to display the contents of the dictionary
    static void DisplayDictionaryContents(Dictionary<string, List<string>> dictionary)
    {
        Console.WriteLine("Displaying Dictionary Contents:");
        // Loop through each key-value pair in the dictionary and display them
        foreach (var kvp in dictionary)
        {
            // Print the key and the list of values as a comma-separated string
            Console.WriteLine($"{kvp.Key}: {string.Join(", ", kvp.Value)}");
        }
    }

    // Method to remove a key from the dictionary
    static void RemoveKey(Dictionary<string, List<string>> dictionary, string key)
    {
        // Attempt to remove the key, and check if successful
        if (dictionary.Remove(key))
        {
            Console.WriteLine($"Removed key: {key}");
        }
        else
        {
            Console.WriteLine($"Key '{key}' not found."); // Inform the user if the key was not found
        }
    }

    // Method to add a new key-value pair to the dictionary
    static void AddNewKeyValue(Dictionary<string, List<string>> dictionary, string key, List<string> value)
    {
        // Check if the key already exists in the dictionary
        if (!dictionary.ContainsKey(key))
        {
            dictionary[key] = value; // Add the new key and its list of values
            Console.WriteLine($"Added: {key}: {string.Join(", ", value)}");
        }
        else
        {
            Console.WriteLine($"Key '{key}' already exists."); // Inform the user if the key already exists
        }
    }

    // Method to add a value to an existing key in the dictionary
    static void AddValueToExistingKey(Dictionary<string, List<string>> dictionary, string key, string value)
    {
        // Check if the key exists in the dictionary
        if (dictionary.ContainsKey(key))
        {
            // Check if the value is not already in the list
            if (!dictionary[key].Contains(value))
            {
                dictionary[key].Add(value); // Add the new value to the list
                Console.WriteLine($"Added value '{value}' to key '{key}'");
            }
            else
            {
                Console.WriteLine($"Value '{value}' already exists for key '{key}'."); // Inform the user if the value already exists
            }
        }
        else
        {
            Console.WriteLine($"Key '{key}' not found."); // Inform the user if the key was not found
        }
    }

    // Method to sort and display the keys in the dictionary
    static void SortKeys(Dictionary<string, List<string>> dictionary)
    {
        // Create a list of the keys, then sort them
        var sortedKeys = new List<string>(dictionary.Keys);
        sortedKeys.Sort();
        // Display the sorted keys
        Console.WriteLine("Sorted Keys: " + string.Join(", ", sortedKeys));
    }
}
