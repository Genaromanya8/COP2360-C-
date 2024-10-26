using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, List<string>> dictionary = PopulateDictionary(); 

        while (true)
        {
            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1: Display Dictionary Contents");
            Console.WriteLine("2: Remove a Key");
            Console.WriteLine("3: Add a New Key and Value");
            Console.WriteLine("4: Add a Value to an Existing Key");
            Console.WriteLine("5: Sort the Keys");
            Console.WriteLine("6: Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayDictionaryContents(dictionary);
                    break;
                case "2":
                    Console.Write("Enter the key to remove: ");
                    string keyToRemove = Console.ReadLine();
                    RemoveKey(dictionary, keyToRemove);
                    break;
                case "3":
                    Console.Write("Enter the new key: ");
                    string newKey = Console.ReadLine();
                    Console.Write("Enter the value (comma-separated if multiple): ");
                    string[] values = Console.ReadLine().Split(',');
                    AddNewKeyValue(dictionary, newKey, new List<string>(Array.ConvertAll(values, v => v.Trim())));
                    break;
                case "4":
                    Console.Write("Enter the existing key: ");
                    string existingKey = Console.ReadLine();
                    Console.Write("Enter the value to add: ");
                    string valueToAdd = Console.ReadLine();
                    AddValueToExistingKey(dictionary, existingKey, valueToAdd);
                    break;
                case "5":
                    SortKeys(dictionary);
                    break;
                case "6":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
}
    static Dictionary<string, List<string>> PopulateDictionary()
    {
        return new Dictionary<string, List<string>>
        {
            { "Sports", new List<string> { "Soccer", "Football", "Basketball", "Baseball", "Golf" } },
             { "Country", new List<string> { "United States", "Cuba","Mexico", "Uruguay", "France" } },
            { "Vegetable", new List<string> { "Carrot", "Broccoli", "Potatoe", "Spinach", "Eggplant" } }
        };
    }
    static void DisplayDictionaryContents(Dictionary<string, List<string>> dictionary)
    {
        Console.WriteLine("Displaying Dictionary Contents:");
        foreach (var kvp in dictionary)
        {
            Console.WriteLine($"{kvp.Key}: {string.Join(", ", kvp.Value)}");
        }
    }

    static void RemoveKey(Dictionary<string, List<string>> dictionary, string key)
    {
        if (dictionary.Remove(key))
        {
            Console.WriteLine($"Removed key: {key}");
        }
        else
        {
            Console.WriteLine($"Key '{key}' not found.");
        }
    }

    static void AddNewKeyValue(Dictionary<string, List<string>> dictionary, string key, List<string> value)
    {
        if (!dictionary.ContainsKey(key))
        {
            dictionary[key] = value;
            Console.WriteLine($"Added: {key}: {string.Join(", ", value)}");
        }
        else
        {
            Console.WriteLine($"Key '{key}' already exists.");
        }
    }

    static void AddValueToExistingKey(Dictionary<string, List<string>> dictionary, string key, string value)
    {
        if (dictionary.ContainsKey(key))
        {
            dictionary[key].Add(value);
            Console.WriteLine($"Added value '{value}' to key '{key}'");
        }
        else
        {
            Console.WriteLine($"Key '{key}' not found.");
        }
    }

    static void SortKeys(Dictionary<string, List<string>> dictionary)
    {
        var sortedKeys = new List<string>(dictionary.Keys);
        sortedKeys.Sort();
        Console.WriteLine("Sorted Keys: " + string.Join(", ", sortedKeys));
    }
}

