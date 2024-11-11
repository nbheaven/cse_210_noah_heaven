using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System;
using System.Timers;

class Activity{
    protected string _openingMessage;
    protected string _closingMessage;
    protected List <List<string>> _promptList;
    protected string _welcomeDescription;
    protected int _duration;

    public Activity(){
        _openingMessage = "Welcome to this activity";

        _closingMessage = "Thank you for participating in the activity. I hope you feel nice and relaxed!";
    }



public void DogAnimation(double durationInSeconds){
    
        int consoleWidth = Console.WindowWidth;
        int dogWidth = 14;
        int position = 0;

        int totalSteps = consoleWidth - dogWidth;
        if (totalSteps <= 0) totalSteps = 1;

        int delay = (int)((durationInSeconds * 1000) / totalSteps);

        string[] dogFrames = new string[]
        {
            @"
    Run, Spot, Run!
           __       
    |____{(''o      
    (      ``      
     \-/-/-\
    ",
            @"
    Run, Spot, Run!!
           __       
    \____{(''o      
    (      ``     
     /-\-\-/
    ",
            @"
    Run, Spot, Run!!!
           __       
    |____{(''o      
    (      ``      
     \-/-/-\
    ",
            @"
    Run, Spot, Run!!
           __       
    /____{(''o      
    (      ``      
     /-\-\-/
    "
        };

        bool T = true;

        while (T)
        {
            for (int frame = 0; frame < dogFrames.Length; frame++)
            {
                Console.Clear();
                
                string spaces = new string(' ', position);

                string[] lines = dogFrames[frame].Split('\n');
                Console.WriteLine(lines[1]);

                for (int i = 2; i < lines.Length; i++)
                {   
                    Console.WriteLine(spaces + lines[i]);
                }

                Thread.Sleep(delay);

                position++;
                if (position > consoleWidth - 2*dogWidth)
                {
                    T=false;
                }
            }
        }

        Console.Clear();

}

public void PromptForDuration()
{
    Console.WriteLine("How many seconds would you like the activity to last?");
    while (true)
    {
        string input = Console.ReadLine();
        if (int.TryParse(input, out int duration) && duration >= 0)
        {
            _duration = duration;
            break;
        }
        else
        {
            Console.WriteLine("Please enter a valid number of seconds.");
        }
    }
}

public string RandomListSelector(List<string> prompt)
{
    Random random = new Random();
    int randomIndex = random.Next(prompt.Count);
    string randomPrompt = prompt[randomIndex];
    
    return(randomPrompt);
}

public void printDelayClear(int delay, string statement)
{
    Console.WriteLine(statement);
    Thread.Sleep(delay);
    Console.Clear();
}
}