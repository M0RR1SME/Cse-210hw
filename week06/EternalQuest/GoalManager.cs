using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("  (No goals created yet)");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string typeChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (typeChoice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());

                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());

                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type selected.");
                break;
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals to record!");
            return;
        }

        Console.WriteLine("The goals are:");
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");

        if (int.TryParse(Console.ReadLine(), out int choiceIndex) && choiceIndex > 0 && choiceIndex <= _goals.Count)
        {
            Goal selectedGoal = _goals[choiceIndex - 1];

            if (selectedGoal.IsComplete())
            {
                Console.WriteLine("This goal is already complete!");
                return;
            }

            selectedGoal.RecordEvent();
            int pointsEarned = selectedGoal.GetPoints();

            // Bonus logic for checklist goals
            if (selectedGoal is ChecklistGoal checklistGoal)
            {
                if (checklistGoal.IsComplete())
                {
                    pointsEarned += checklistGoal.GetBonus();
                    Console.WriteLine($"*** Congratulations! You completed the entire checklist and earned a bonus of {checklistGoal.GetBonus()} points! ***");
                }
            }

            _score += pointsEarned;
            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
            Console.WriteLine($"You now have {_score} points.");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals successfully saved!");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found!");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        if (lines.Length == 0) return;

        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split(':');

            if (parts.Length < 2) continue;

            string goalType = parts[0];
            string[] data = parts[1].Split(',');

            if (goalType == "SimpleGoal")
            {
                string name = data[0];
                string description = data[1];
                int points = int.Parse(data[2]);
                bool isComplete = bool.Parse(data[3]);

                _goals.Add(new SimpleGoal(name, description, points, isComplete));
            }
            else if (goalType == "EternalGoal")
            {
                string name = data[0];
                string description = data[1];
                int points = int.Parse(data[2]);

                _goals.Add(new EternalGoal(name, description, points));
            }
            else if (goalType == "ChecklistGoal")
            {
                string name = data[0];
                string description = data[1];
                int points = int.Parse(data[2]);
                int bonus = int.Parse(data[3]);
                int target = int.Parse(data[4]);
                int amountCompleted = int.Parse(data[5]);

                _goals.Add(new ChecklistGoal(name, description, points, target, bonus, amountCompleted));
            }
        }

        Console.WriteLine("Goals successfully loaded!");
    }
}