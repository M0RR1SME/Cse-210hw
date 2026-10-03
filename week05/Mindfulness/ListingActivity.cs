using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity() 
        : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _count = 0;
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt inspired this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        GetRandomPrompt();

        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        List<string> items = GetListFromUser();
        _count = items.Count;

        Console.WriteLine($"You listed {_count} items!");

        DisplayEndingMessage();
    }

    private void GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);

        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($"--- {_prompts[index]} ---");
    }

    private List<string> GetListFromUser()
    {
        List<string> userList = new List<string>();
        int duration = GetDuration();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            
            // Console.ReadLine blocking check with time limit
            while (!Console.KeyAvailable && DateTime.Now < endTime)
            {
                Thread.Sleep(50);
            }

            if (Console.KeyAvailable)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    userList.Add(input);
                }
            }
        }

        return userList;
    }
}