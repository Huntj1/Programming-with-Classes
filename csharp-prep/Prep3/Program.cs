using System;
using System.Globalization;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        string response = "yes";

        do
        {
            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1, 11);
            bool user = false;
            Console.WriteLine($"The magic number is {number}");
            Console.WriteLine("Only input whole numbers");
            int count = 0;
            while (user == false)
            {
                Console.Write("\nWhat is your Guess? ");
                string valueFromUser = Console.ReadLine();

                int x = int.Parse(valueFromUser);

                if (x > number)
                {
                    Console.WriteLine("Lower");
                }
                else if (x < number)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("You got it! Nice Job");
                    user = true;
                }
                count = count + 1;

            }

        Console.WriteLine($"It took you {count} try(s)");   
        Console.Write("Do you want to continue? ");
        response = Console.ReadLine();
        } while (response == "yes");
        
    }
}

