public class Randomprompt
{
  
    public List<string> _Questions = new List<string>()
    {
        "How is is your day? ",
        "How did you see the Lord's hand in your life? ",
        "What is one thing you are greatful for?  "

    };

    public string RandomQuestion()
    {
        Random rand = new Random();
        int randomIndex = rand.Next(0, _Questions.Count);
        return _Questions[randomIndex];
    }



    public Randomprompt()
    {
    }

  
  

}


