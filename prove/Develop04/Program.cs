using System;
using System.Threading;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.Write("Invalid choice. Please enter a number between 1 and 4: ");
            }

            switch (choice)
            {
                case 1:
                    new BreathingActivity().DoBreathingActivity();
                    break;
                case 2:
                    new ReflectionActivity().DoReflectionActivity();
                    break;
                case 3:
                    new ListingActivity().DoListingActivity();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
