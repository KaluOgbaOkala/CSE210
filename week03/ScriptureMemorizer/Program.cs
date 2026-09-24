class Program
{
    static void Main(string[] args)
    {
        // Creativity: I added a scripture library that allows the user
        // to choose from multiple scriptures. I also improved the
        // random word hiding so already-hidden words are not selected again.

        Console.WriteLine("Scripture Memorizer");
        Console.WriteLine();
        Console.WriteLine("Choose a scripture:");
        Console.WriteLine("1. John 3:16");
        Console.WriteLine("2. Proverbs 3:5-6");
        Console.WriteLine("3. Philippians 4:13");
        Console.WriteLine();
        Console.Write("Enter your choice: ");

        string choice = Console.ReadLine();

        Reference reference;
        string text;

        if (choice == "1")
        {
            reference = new Reference("John", 3, 16);
            text = "For God so loved the world that he gave his only begotten Son";
        }
        else if (choice == "2")
        {
            reference = new Reference("Proverbs", 3, 5, 6);
            text = "Trust in the Lord with all thine heart and lean not unto thine own understanding";
        }
        else if (choice == "3")
        {
            reference = new Reference("Philippians", 4, 13);
            text = "I can do all things through Christ which strengtheneth me";
        }
        else
        {
            Console.WriteLine("Invalid choice. The program will end.");
            return;
        }

        Scripture scripture = new Scripture(reference, text);

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine();
            Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(2);
        }

        Console.Clear();

        Console.WriteLine(scripture.GetDisplayText());
    }
}