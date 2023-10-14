class SimpleGoal : Goal
{
    public SimpleGoal(string name, int value) : base(name, value) { }
}

class EternalGoal : Goal
{
    public EternalGoal(string name, int value) : base(name, value) { }

    public override void MarkComplete()
    {
        base.MarkComplete();
        Console.WriteLine($"You gained {value} points");
    }
}