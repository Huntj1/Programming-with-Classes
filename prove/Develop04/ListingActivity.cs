class ListingActivity : Activity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public void DoListingActivity()
    {
        StartActivity();
        while (duration > 0)
        {
            string randomPrompt = prompts[new Random().Next(prompts.Length)];
            Console.WriteLine($"{randomPrompt}\nGet ready to list...");

            PauseWithSpinner(2);

            Console.Write("Start listing: ");
            string[] items = Console.ReadLine()?.Split(',');

            if (items != null)
            {
                Console.WriteLine($"\nYou listed {items.Length} items.");
                PauseWithSpinner(3);
                duration -= 6;
            }
        }
        EndActivity();
    }
}