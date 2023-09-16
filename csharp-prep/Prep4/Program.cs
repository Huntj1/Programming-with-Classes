using System;
using System.ComponentModel;
using System.ComponentModel.Design;

class Program
{
    static void Main(string[] args)
    {
        string start = "yes";
        do
        {
        string response = "yes";
        List<int> numbers = new List<int>();
            do
            {
                
                Console.WriteLine("Hello User! Please start by entering a number");
                bool user = false;
                int count = 0;

                while (user == false)
                {
                        Console.Write("Please enter a value: ");
                        string number = Console.ReadLine();
                        int x = int.Parse(number);
                        if (x != 0)
                        {
                            numbers.Add(x); 
                        }
                        else if (x == 0)
                        {
                            user = true;
                        }
                        count = count + 1;

                }

            int sum = 0;
            int min = 10000;
            int max = -1; 

            foreach (int number in numbers)
                {
                    sum += number; 
                    if (number > max)
                        {
                            max = number;
                        }
                    else if (number < min)
                        {
                            min = number;
                        }
                }

            float avg = sum /(count-1);
 
            Console.WriteLine("\nYou have entered 0. Here are some stats for your list.");
            Console.WriteLine($"\nThe sum is: {sum}");
            Console.WriteLine($"\nThe avg is: {avg}");
            Console.WriteLine($"\nThe max is: {max}");
            Console.WriteLine($"\nThe min is: {min}");
        
            Console.Write("Do you want to continue adding numbers to your list? ");
            response = Console.ReadLine();

            } while (response == "yes");
        

        Console.Write("Do you want to start over? ");
            start = Console.ReadLine();


        } while (start == "Yes");

    Console.WriteLine("Thanks for playing! see you next time!");
    }
}