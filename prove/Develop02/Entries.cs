class Entry
{
    public List<string> _prompts = new List<string>();

    public string _date;
    public string _entry;
    public string _prompt;

    public string Generate_Prompt() 
    {
        _prompts = ["What happened today?", "What was the best thing that happened today?",
        "What was the worst thing that happened today?",
        "What was the most interesting thing I saw or heard today?",
        "What was the most challenging thing I faced today?",
        "What am I grateful for today?",
        "What did I learn today?",
        "What was the most fun thing I did today?",
        "What was the most surprising thing that happened today?",
        "What did I do today that I am proud of?", "How am I feeling today?",
        "How does my body feel today?",
        "What am I nervous or anxious about today?",
        "What actions can I take on each of the things that make me nervous or anxious?",
        "What are my top priorities for the day?",
        "What’s something I can do to make today amazing?",
        "What did I learn today? How can I apply this knowledge in the future?",
        "What challenges did I face today? How did I overcome them? What can I learn from these experiences?",
        "What did I do today that brought me joy or fulfillment? How can I incorporate more of these activities into my daily routine?",
        "What was a moment of joy, delight, or contentment today?",
        "What was a small detail I noticed today?",
        "What was the weather like today?",
        "What am I thankful for today?",
        "What could I have done differently today?",
        "How can I make tomorrow even better?"];

        Random rnd = new Random();
        int n = _prompts.Count;
        int rando = rnd.Next(1, n+1);

        return _prompts[rando];
        
    }

    public string New_Entry()
    {
        _prompt = Generate_Prompt();
        Console.WriteLine($"{_prompt}");
        string input = Console.ReadLine();
        _date = DateTime.Now.ToString("dd/MM/yyyy");
        _entry = ($"Date: {_date}, Prompt: {_prompt}, {input}");

        return _entry;
    }
}
        

