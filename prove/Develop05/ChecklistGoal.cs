class ChecklistGoal : Goal
{
    public int targetCount;
    public int completedCount;
    public int bonusValue;

    public ChecklistGoal(string name, int value, int targetCount, int bonusValue) : base(name, value)
    {
        this.targetCount = targetCount;
        this.bonusValue = bonusValue;
    }

    public override void MarkComplete()
    {
        base.MarkComplete();
        completedCount++;

        Console.WriteLine($"You gained {value} points for attending the temple ({completedCount}/{targetCount} times).");

        if (completedCount == targetCount)
        {
            Console.WriteLine($"Bonus! You gained an extra {bonusValue} points for completing the goal.");
        }
    }

    public override void DisplayStatus()
    {
        Console.WriteLine($"{name} Completed {completedCount}/{targetCount} times");
    }
}