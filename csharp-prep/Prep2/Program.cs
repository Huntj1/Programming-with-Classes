using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is the grade percentage? (dont include % sign): ");
        string valueFromUser = Console.ReadLine();

        int x = int.Parse(valueFromUser);

        string letter = "";

        if (x >= 97)
        {
            letter = "A";
        }
        else if (x >= 90)
        {
            letter = "A-";
        }
        else if (x >= 87)
        {
            letter = "B+";
        }
        else if (x >= 85)
        {
            letter = "B";
        }
        else if (x >= 80)
        {
            letter = "B-";
        }
        else if (x >= 77)
        {
            letter = "C+";
        }
        else if (x >= 75)
        {
            letter = "C";
        }
        else if (x >= 70)
        {
            letter = "C-";
        }
        else if (x >= 67)
        {
            letter = "D+";
        }
        else if (x >= 65)
        {
            letter = "D";
        }
        else if (x >= 60)
        {
            letter = "D-";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your Letter Grade is {letter}");

        if (x >= 70)
        {
            Console.WriteLine("You Passed!");
        }
        else
        {
            Console.WriteLine("Try again! yoy Failed");
        }
        
    }
}