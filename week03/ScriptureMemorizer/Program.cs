using System;

class Program
{
    static void Main(string[] args)
    {
       
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the LORD with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";

        Scripture scripture = new Scripture(reference, text);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            // Check if all words are hidden; end program after displaying full hidden state
            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine("\nPress Enter to continue or type 'quit' to finish:");
            string input = Console.ReadLine();

            if (input.Trim().ToLower() == "quit")
            {
                break;
            }

            // Hides 3 random visible words on each step
            scripture.HideRandomWords(3);
        }
    }
}