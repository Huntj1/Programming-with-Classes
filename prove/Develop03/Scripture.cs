class Scripture
{
    private string reference;
    private string text;
    private List<string> hiddenWords;
    private string[] allWords;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.text = text;
        this.hiddenWords = new List<string>();
        this.allWords = text.Split(' ');
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine($"{reference}\n");

        foreach (var word in allWords)
        {
            if (hiddenWords.Contains(word))
                Console.Write("____ ");
            else
                Console.Write($"{word} ");
        }

        Console.WriteLine("\n");
    }

    public void HideRandomWords()
    {
        // Randomly hide a few words
        Random random = new Random();
        int wordsToHide = random.Next(1, 4);

        for (int i = 0; i < wordsToHide; i++)
        {
            int randomIndex = random.Next(allWords.Length);
            string wordToHide = allWords[randomIndex];

            // Check if the word is not already hidden
            if (!hiddenWords.Contains(wordToHide))
                hiddenWords.Add(wordToHide);
        }
    }

    public bool AllWordsHidden
    {
        get { return hiddenWords.Count == allWords.Length; }
    }
}