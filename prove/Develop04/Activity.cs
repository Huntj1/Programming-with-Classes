class Activity
{
    private string name;
    private string description;
    protected int duration;

    public Activity(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public void StartActivity()
    {
        Console.WriteLine($"Starting {name} activity. {description}");
        SetDuration();
        Console.WriteLine($"Get ready...{Environment.NewLine}");
        PauseWithSpinner(3);
    }

    public void EndActivity()
    {
        Console.WriteLine($"\nGood job! You have completed the {name} activity for {duration} seconds.");
        PauseWithSpinner(3);
    }

    private void SetDuration()
    {
        Console.Write($"Enter the duration for {name} activity in seconds: ");
        while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
        {
            Console.Write("Invalid input. Please enter a positive integer: ");
        }
    }

    protected void PauseWithSpinner(int seconds)
    {
        Console.WriteLine("Starting in...");
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}
