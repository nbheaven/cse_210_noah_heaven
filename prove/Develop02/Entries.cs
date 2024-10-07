class Entry
{
    public List<string> _prompts = new List<string>();

    string _date;
    string _entry; 

    public string generate_prompt() 
    {
        Random rnd = new Random();
        int n = _prompts.Count;
        int rando = rnd.Next(1, n+1);

        return _prompts[rando];
        
    }

    public string new_entry()
    {
        Console.WriteLine($"{generate_prompt()}");
        string input = Console.ReadLine();
        _entry = ($"{_date}, {generate_prompt()}, {input}");

        return _entry;
    }

        

