class Program
{
    static void Main()
    {
        string first = GetInput("What is your first name? ");
        string last = GetInput("What is your last name? ");

        Console.WriteLine($"Your name is {last}, {first} {last}.");
    }

    static string GetInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }
}