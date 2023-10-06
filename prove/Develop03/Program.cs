using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Create a Scripture object
        Scripture myScripture = new Scripture("Helamen 5:12", "And now, my sons, remember, remember that it is upon the arock of our Redeemer, who is Christ, the Son of God, that ye must build your bfoundation; that when the devil shall send forth his mighty winds, yea, his shafts in the whirlwind, yea, when all his hail and his mighty cstorm shall beat upon you, it shall have no power over you to drag you down to the gulf of misery and endless wo, because of the rock upon which ye are built, which is a sure foundation, a foundation whereon if men build they cannot fall.");

        // Display the complete scripture
        myScripture.Display();

        // Continue hiding words until all are hidden
        while (!myScripture.AllWordsHidden)
        {
            // Prompt the user to press Enter or type quit
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
            string userInput = Console.ReadLine();

            // Check if the user wants to quit
            if (userInput.ToLower() == "quit")
                break;

            // Hide a few random words and display the scripture
            myScripture.HideRandomWords();
            myScripture.Display();
        }

        Console.WriteLine("Program ended.");
    }
}


