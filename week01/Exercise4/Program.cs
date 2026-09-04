// Note: No using directives are needed because Implicit Usings are enabled in .NET 6+.
// Core namespaces (System, System.Collections.Generic, System.Linq) are automatically imported globally.

class Program
{
    static void Main()
    {
        List<int> numbers = new();
        int userNumber;

        do
        {
            Console.Write("Enter a number (0 to quit): ");
            userNumber = int.Parse(Console.ReadLine());

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        } while (userNumber != 0);

        if (numbers.Count > 0)
        {
            Console.WriteLine($"The sum is: {numbers.Sum()}");
            Console.WriteLine($"The average is: {numbers.Average()}");
            Console.WriteLine($"The max is: {numbers.Max()}");
        }
    }
}