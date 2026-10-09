using System;
using System.Collections.Generic;
using System.IO;

class Program
{
static List<Goal> _goals = new List<Goal>();
static int _score = 0;

static void Main(string[] args)
{
    Console.WriteLine("Welcome to Eternal Quest!");

    string choice = "";

    while (choice != "6")
    {
        Console.WriteLine();
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine();
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Save Goals");
        Console.WriteLine("4. Load Goals");
        Console.WriteLine("5. Record Event");
        Console.WriteLine("6. Quit");
        Console.Write("Select a choice from the menu: ");

        choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                CreateGoal();
                break;

            case "2":
                ListGoals();
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
                Console.WriteLine(
                    "Goodbye! Keep progressing on your Eternal Quest!");
                break;

            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }
}

static void CreateGoal()
{
    Console.WriteLine();
    Console.WriteLine("Create Goal");
    Console.WriteLine("1. Simple Goal");
    Console.WriteLine("2. Eternal Goal");
    Console.WriteLine("3. Checklist Goal");
    Console.Write("Which type of goal would you like to create? ");

    string type = Console.ReadLine();

    Console.Write("What is the name of your goal? ");
    string name = Console.ReadLine();

    Console.Write("What is a short description of it? ");
    string description = Console.ReadLine();

    Console.Write("What is the amount of points for this goal? ");

    if (!int.TryParse(Console.ReadLine(), out int points) || points < 0)
    {
        Console.WriteLine("Please enter a valid non-negative number.");
        return;
    }

    Goal goal;

    if (type == "1")
    {
        goal = new SimpleGoal(name, description, points);
    }
    else if (type == "2")
    {
        goal = new EternalGoal(name, description, points);
    }
    else if (type == "3")
    {
        Console.Write("How many times does this goal need to be completed? ");

        if (!int.TryParse(Console.ReadLine(), out int target) || target <= 0)
        {
            Console.WriteLine("The target must be greater than zero.");
            return;
        }

        Console.Write("What is the bonus for completing the target? ");

        if (!int.TryParse(Console.ReadLine(), out int bonus) || bonus < 0)
        {
            Console.WriteLine("Please enter a valid non-negative bonus.");
            return;
        }

        goal = new ChecklistGoal(
            name,
            description,
            points,
            target,
            bonus);
    }
    else
    {
        Console.WriteLine("Invalid goal type.");
        return;
    }

    _goals.Add(goal);
    Console.WriteLine("Goal created successfully!");
}

static void ListGoals()
{
    Console.WriteLine();
    Console.WriteLine("The goals are:");

    if (_goals.Count == 0)
    {
        Console.WriteLine("No goals have been created yet.");
        return;
    }

    for (int i = 0; i < _goals.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
    }
}

static void RecordEvent()
{
    Console.WriteLine();

    if (_goals.Count == 0)
    {
        Console.WriteLine("There are no goals to record.");
        return;
    }

    Console.WriteLine("Record Event");
    Console.WriteLine("Which goal did you accomplish?");

    for (int i = 0; i < _goals.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
    }

    Console.Write("Select a goal number: ");

    if (!int.TryParse(Console.ReadLine(), out int goalNumber) ||
        goalNumber < 1 ||
        goalNumber > _goals.Count)
    {
        Console.WriteLine("Invalid goal number.");
        return;
    }

    Goal selectedGoal = _goals[goalNumber - 1];

    if (selectedGoal.IsComplete())
    {
        Console.WriteLine("This goal has already been completed.");
        return;
    }

    int pointsEarned = selectedGoal.RecordEvent();

    _score += pointsEarned;

    Console.WriteLine($"Congratulations! You earned {pointsEarned} points.");
    Console.WriteLine($"Your total score is {_score}.");
}

static void SaveGoals()
{
    Console.WriteLine();
    Console.Write("Enter the filename to save your goals: ");

    string filename = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(filename))
    {
        Console.WriteLine("Filename cannot be empty.");
        return;
    }

    try
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Could not save goals: {ex.Message}");
    }
}

static void LoadGoals()
{
    Console.WriteLine();
    Console.Write("Enter the filename to load your goals: ");

    string filename = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(filename))
    {
        Console.WriteLine("Filename cannot be empty.");
        return;
    }

    if (!File.Exists(filename))
    {
        Console.WriteLine("The file does not exist.");
        return;
    }

    try
    {
        string[] lines = File.ReadAllLines(filename);

        if (lines.Length == 0 ||
            !int.TryParse(lines[0], out int loadedScore))
        {
            Console.WriteLine("The save file is invalid.");
            return;
        }

        List<Goal> loadedGoals = new List<Goal>();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');

            if (parts.Length < 4 ||
                !int.TryParse(parts[3], out int points))
            {
                Console.WriteLine(
                    $"Skipping invalid goal on line {i + 1}.");
                continue;
            }

            string type = parts[0];
            string name = parts[1];
            string description = parts[2];

            if (type == "SimpleGoal")
            {
                if (parts.Length < 5 ||
                    !bool.TryParse(parts[4], out bool isComplete))
                {
                    Console.WriteLine(
                        $"Skipping invalid goal on line {i + 1}.");
                    continue;
                }

                SimpleGoal goal = new SimpleGoal(
                    name,
                    description,
                    points,
                    isComplete);

                loadedGoals.Add(goal);
            }
            else if (type == "EternalGoal")
            {
                EternalGoal goal = new EternalGoal(
                    name,
                    description,
                    points);

                loadedGoals.Add(goal);
            }
            else if (type == "ChecklistGoal" && parts.Length >= 7)
            {
                if (!int.TryParse(parts[4], out int amountCompleted) ||
                    !int.TryParse(parts[5], out int target) ||
                    !int.TryParse(parts[6], out int bonus))
                {
                    Console.WriteLine(
                        $"Skipping invalid checklist on line {i + 1}.");
                    continue;
                }

                ChecklistGoal goal = new ChecklistGoal(
                    name,
                    description,
                    points,
                    amountCompleted,
                    target,
                    bonus);

                loadedGoals.Add(goal);
            }
            else
            {
                Console.WriteLine(
                    $"Skipping unrecognized goal on line {i + 1}.");
            }
        }

        _goals.Clear();
        _goals.AddRange(loadedGoals);
        _score = loadedScore;

        Console.WriteLine("Goals loaded successfully!");
        Console.WriteLine($"Your score is {_score}.");
        Console.WriteLine($"Number of goals loaded: {_goals.Count}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Could not load goals: {ex.Message}");
    }
}

}

