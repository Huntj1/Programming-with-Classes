// Breathing activity class
class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void DoBreathingActivity()
    {
        StartActivity();
        while (duration > 0)
        {
            Console.WriteLine("Breathe in...");
            PauseWithSpinner(6);
            Console.WriteLine("Breathe out...");
            PauseWithSpinner(6);
            duration -= 12;
        }
        EndActivity();
    }
}
