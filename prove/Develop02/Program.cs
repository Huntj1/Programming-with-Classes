using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

public class Program
{
    static void Main(string[] args)
    {
        // Variables
        DateTime today = DateTime.Today;

        List<Entry> entries = new List<Entry>();

        Randomprompt _Questions = new Randomprompt();


        // User interface menu
        string response = "";
        do {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            response = Console.ReadLine();

            // Handle user response
            switch (response) {
                // Write
                case "1":
                    // example
                    // Get today's date
                    string date = today.ToShortDateString();
                    // Give a prompt
                    string prompt = _Questions.RandomQuestion();
                    Console.WriteLine(prompt);
                    Console.WriteLine();
                    // Ask for a response
                    string entry = Console.ReadLine();
                    // Save into a new entry
                    Entry newEntry = new Entry(date, prompt, entry);
                    entries.Add(newEntry);
                    break;
                    
                // Display
                case "2":
                    // Display all of the entries using a for loop
                    foreach (Entry item in entries) {
                        Console.WriteLine($"{item._date} {item._prompt} {item._entry}");
                        Console.WriteLine("___________________________");
                    }
                    break;

                // Load
                case "3":

                    Console.WriteLine("Which file would you like so load? ");
                    string loadFileName = Console.ReadLine();

                    string[] lines = System.IO.File.ReadAllLines(loadFileName);

                    foreach (string line in lines)
                    {
                        Console.WriteLine(line);
                        string [] parts = line.Split(",");
                        Entry oldEntry = new Entry(parts[0],parts[1],parts[2]);

                        entries.Add(oldEntry);
                    }

                    // Use code you wrote below to pull entries from a file
                    break;
                // Save
                case "4":
                    // Use code you wrote before to save entries to a file
                    // Get filename from the user
                    Console.Write("Name of file to save to --> ");
                    string filename = Console.ReadLine();

                    using (StreamWriter outputFile = new StreamWriter(filename))
                    {
                        foreach (Entry i in entries)
                        {
                            outputFile.WriteLine($"{i._date},{i._prompt},{i._entry}");
                        }
                    }

                    entries.Clear();

                    break;


                // Quit
                default:
                    break;
                }
            
        } while(response != "5");
    }
}











        //  Person p1 = new Person();
        //  p1._firstName = "Mary";
        //  p1._lastName = "Smith";
        //  p1._age = 25;

        //  Person p2 = new Person();
        //  p2._firstName = "John";
        //  p2._lastName = "watkins";
        //  p2._age = 30;

        //  List<Person> people = new List<Person>();
        //  people.Add(p1);
        //  people.Add(p2);

        //  foreach (Person p in people)
        //  {
        //     Console.WriteLine(p._firstName);
        //  }

        //  SaveToFile(people);

        // List<Person> newPeople = ReadFromFile();
        // foreach(Person p in newPeople)
        // {

        //     Console.WriteLine(p._firstName);
        // }

    // }

    // public static void SaveToFile(List<Person> people)
    // {
    //     Console.WriteLine("Saving to file...");
    //     string filename = "";
    //     // Get filename from the user
    //     Console.Write("Name of file to save to --> ");
    //     filename = Console.ReadLine();

    //     using (StreamWriter outputFile = new StreamWriter(filename))
    //     {
    //         foreach (Person p in people)
    //         {
    //             outputFile.WriteLine($"{p._firstName},{p._lastName},{p._age}");
    //         }
    //     }
    // }

    // public static List<Person> ReadFromFile()
    // {
    //     Console.WriteLine("Reading list from file...");
    //     List<Person> people = new List<Person>();
    //     string filename = "people.txt";

    //     string[] lines = System.IO.File.ReadAllLines(filename);

    //     foreach (string line in lines)
    //     {
    //         // Console.WriteLine(line);
    //         string [] parts = line.Split(",");

    //         // parts[0] - Mary
    //         // parts[1] - Smith
    //         // parts[2] - 25

    //         Person newPerson = new Person();
    //         newPerson._firstName = parts[0];
    //         newPerson._lastName = parts[1];
    //         newPerson._age = int.Parse(parts[2]);

    //         people.Add(newPerson);
    //     }

    //     return people;


    // }
// }