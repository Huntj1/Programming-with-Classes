using System;
using System.Collections.Generic;

class User
{
    public List<Goal> goals;
    public int score;

    public User()
    {
        goals = new List<Goal>();
        score = 0;
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        Goal goal = goals[goalIndex];
        goal.MarkComplete();
        score += goal.value;

        if (goal is ChecklistGoal && ((ChecklistGoal)goal).completedCount == ((ChecklistGoal)goal).targetCount)
        {
            score += ((ChecklistGoal)goal).bonusValue;
        }
    }

    public void DisplayGoals()
    {
        for (int i = 0; i < goals.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            goals[i].DisplayStatus();
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Total Score: {score}");
    }

    public void ResetScore()
    {
        score = 0;
        Console.WriteLine("Score reset to zero.");
    }

    public void ResetGoals()
    {
        goals.Clear();
        Console.WriteLine("Goals list cleared.");
    }

    public void SaveGoals(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (Goal goal in goals)
            {
                string line = $"{goal.GetType().Name},{goal.name},{goal.value},{goal.completed}";
                writer.WriteLine(line);
            }
        }
        Console.WriteLine($"Goals saved to {fileName}.");
    }

    public void LoadGoals(string fileName)
    {
        try
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        string type = parts[0];
                        string name = parts[1];
                        int value = int.Parse(parts[2]);
                        bool completed = bool.Parse(parts[3]);

                        Goal goal;
                        switch (type)
                        {
                            case nameof(SimpleGoal):
                                goal = new SimpleGoal(name, value);
                                break;

                            case nameof(EternalGoal):
                                goal = new EternalGoal(name, value);
                                break;

                            case nameof(ChecklistGoal):
                                goal = new ChecklistGoal(name, value, 0, 0); // You might need to handle these parameters differently
                                break;

                            default:
                                Console.WriteLine($"Unknown goal type: {type}");
                                continue;
                        }

                        goal.completed = completed;
                        goals.Add(goal);
                    }
                }
            }

            Console.WriteLine($"Goals loaded from {fileName}.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: File {fileName} not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }
}

class Program
{
    static void Main()
    {
        User user = new User();

        while (true)
        {
            Console.WriteLine("\n1. Add Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("\n5. Reset Score");
            Console.WriteLine("6. Reset Goals");
            Console.WriteLine("\n7. Save Goals");
            Console.WriteLine("8. Load Goals");
            Console.WriteLine("0. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter goal type (Simple/Eternal/Checklist): ");
                    string goalType = Console.ReadLine().ToLower();

                    Console.Write("Enter goal name: ");
                    string goalName = Console.ReadLine();

                    Console.Write("Enter goal value: ");
                    int goalValue = int.Parse(Console.ReadLine());

                    if (goalType == "simple")
                    {
                        user.AddGoal(new SimpleGoal(goalName, goalValue));
                    }
                    else if (goalType == "eternal")
                    {
                        user.AddGoal(new EternalGoal(goalName, goalValue));
                    }
                    else if (goalType == "checklist")
                    {
                        Console.Write("Enter target count: ");
                        int targetCount = int.Parse(Console.ReadLine());

                        Console.Write("Enter bonus value: ");
                        int bonusValue = int.Parse(Console.ReadLine());

                        user.AddGoal(new ChecklistGoal(goalName, goalValue, targetCount, bonusValue));
                    }
                    break;

                case "2":
                    user.DisplayGoals();
                    Console.Write("Enter the goal number to mark as complete: ");
                    int goalIndex = int.Parse(Console.ReadLine()) - 1;
                    user.RecordEvent(goalIndex);
                    break;

                case "3":
                    user.DisplayGoals();
                    break;

                case "4":
                    user.DisplayScore();
                    break;

                case "5":
                    user.ResetScore();
                    break;
                
                case "6":
                    user.ResetGoals();
                    break;

                case "7":
                    Console.Write("Enter the file name to save goals: ");
                    string saveFileName = Console.ReadLine();
                    user.SaveGoals(saveFileName);
                    break;

                case "8":
                    Console.Write("Enter the file name to load goals from: ");
                    string loadFileName = Console.ReadLine();
                    user.LoadGoals(loadFileName);
                    break;

                case "0":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}