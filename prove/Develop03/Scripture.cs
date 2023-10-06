class Scripture
{
    private string _reference;
    private string text;
    // private List<string> hiddenWords;
    private List<Word> allWords;

    public Scripture(string reference, string text)
    {
        _reference = reference;
        this.text = text;
        // this.hiddenWords = new List<string>();
        allWords = new List<Word>();
        string[] allStrings = text.Split(' ');
        foreach (string item in allStrings) {
            Word word = new Word();
            word._text = item;
            allWords.Add(word);
        }
    }

    public void Display()
    {
        Console.Clear();
        // Console.WriteLine($"hiddenWords.Count: {hiddenWords.Count}"); // debug
        Console.WriteLine($"{_reference}\n");

        foreach (Word word in allWords)
        {
            if (word._hidden)
                Console.Write("____ ");
            else
                Console.Write($"{word._text} ");
        }

        Console.WriteLine("\n");
    }

    public void HideRandomWords()
    {
        // Randomly hide a few words
        Random random = new Random();
        int wordsToHide = random.Next(1, 4);
        // int wordsToHide = 2;

        for (int i = 0; i < wordsToHide; i++)
        {
            int randomIndex = random.Next(allWords.Count);
            

            // Check if the word is not already hidden
            if (!allWords[randomIndex]._hidden){
                // Console.WriteLine($"word hidden: {wordToHide}, hiddenWords.Count: {hiddenWords.Count}");
                allWords[randomIndex]._hidden = true;
            }
            else {
                // As long as the random word is already hidden, and there are
                // still words which have not been hidden, keep searching for
                // a word which has not been hidden yet.
                do {
                    randomIndex = random.Next(allWords.Count);
                } while(!allWords[randomIndex]._hidden && !this.AllWordsHidden());
                    // hiddenWords.Contains(wordToHide);
                
                allWords[randomIndex]._hidden = true;
                // Console.WriteLine($"word hidden: {wordToHide} hiddenWords.Count: {hiddenWords.Count}");
            }
        }
    }

    public bool AllWordsHidden()
    {
        foreach (Word word in allWords)
        {
            if (word._hidden == false){
                return false;
            }
        }
        return true;
    }
}