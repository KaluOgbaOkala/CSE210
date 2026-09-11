using System;

Journal journal = new Journal();
PromptGenerator prompts = new PromptGenerator();

Console.WriteLine("Welcome to the Journal Program!");

string choice = "";

while (choice != "5")
{
    Console.WriteLine("\nPlease select one of the following choices:");

    Console.WriteLine("1. Write");
    Console.WriteLine("2. Display");
    Console.WriteLine("3. Save");
    Console.WriteLine("4. Load");
    Console.WriteLine("5. Quit");

    Console.Write("What would you like to do? ");
    choice = Console.ReadLine();

    Console.WriteLine();

    if (choice == "1")
    {
        string prompt = prompts.GetRandomPrompt();

        Console.WriteLine(prompt);
        Console.Write("Your answer: ");
        string answer = Console.ReadLine();

        Entry entry = new Entry();
        entry._date = DateTime.Now.ToShortDateString();
        entry._promptText = prompt;
        entry._entryText = answer;

        journal._entries.Add(entry);

        Console.WriteLine("Journal entry added!");
    }
    else if (choice == "2")
    {
        Console.WriteLine("Displaying journal entries:");
        foreach (Entry entry in journal._entries)
        {
            Console.WriteLine($"Date: {entry._date}");
            Console.WriteLine($"Prompt: {entry._promptText}");
            Console.WriteLine($"Entry: {entry._entryText}");
            Console.WriteLine();
        }
    }
    else if (choice == "3")
{
    Console.Write("Enter the filename: ");
    string filename = Console.ReadLine();

    journal.SaveToFile(filename);

    Console.WriteLine("Journal saved successfully!");
}

    else if (choice == "4")
{
    Console.Write("Enter the filename: ");
    string filename = Console.ReadLine();

    journal.LoadFromFile(filename);

    Console.WriteLine("Journal loaded successfully!");
}
    else if (choice == "5")
    {
        Console.WriteLine("Goodbye!");
    }
    else
    {
        Console.WriteLine("Invalid choice. Please select 1-5.");
    }
}
