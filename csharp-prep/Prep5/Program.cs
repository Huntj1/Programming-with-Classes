using System;
using System.ComponentModel;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();

        string userName = PromptName();
        int userNumber = PromptNumber();

        int square = Square(userNumber);

        DisplayResult(userName, square);
    
    }

    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome User!");
    }

    static string PromptName()
    {
        Console.Write("What is your full name?: ");
        string name = Console.ReadLine();

        return name;
    }

    static int PromptNumber()
    {
        Console.Write("What is your favorite number?: ");
        int x = int.Parse(Console.ReadLine());

        return x;
    }

    static int Square(int number)
    {
        int square = number * number;
        return square;
    }

    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }

}