class Goal
{
    public string name;
    public int value;
    public bool completed;

    public Goal(string name, int value)
    {
        this.name = name;
        this.value = value;
        this.completed = false;
    }

    public virtual void MarkComplete()
    {
        completed = true;
    }

    public virtual void DisplayStatus()
    {
        string status = completed ? "[X]" : "[ ]";
        Console.WriteLine($"{name} {status}");
    }
}