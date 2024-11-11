using System;
using System.Timers;
using Timer = System.Timers.Timer;
using System.Diagnostics;

class Listing : Activity{
    
    private static Timer _timer;

    public Listing()
    { _welcomeDescription =
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _promptList = [["Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?",
            "What is something you accomplished recently that you feel proud of?",
            "When have you felt peace or comfort in a difficult time?",
            "Who has made a positive impact in your life?",
            "What are things you are grateful for today?",
            "When have you shown kindness to others recently?",
            "What are things you love about yourself?",
            "When did you see someone else serve with love?",
            "What is something you have learned recently?",
            "What goals have you set to become a better person?",
            "Who has inspired you to become a better person?",
            "When did you feel close to God this week?",
            "What are things you enjoy about life right now?",
            "How have you helped someone without expecting anything in return?",
            "Who has shown you love or friendship recently?",
            "What qualities do you admire in others?"]];
    }

public void ListingActivity()
{
    int x = 0;
    
    Console.Clear();
    printDelayClear(3000, _openingMessage);
    printDelayClear(7000, _welcomeDescription);
    PromptForDuration();
    Console.WriteLine(RandomListSelector(_promptList[0]));
    printDelayClear(5000, ($"Get ready, you will have {_duration} seconds to list as many items as possible"));
    
    Stopwatch stopwatch = Stopwatch.StartNew();
    Task.Run(() =>
        {
            while (stopwatch.Elapsed < TimeSpan.FromSeconds(_duration))
            {
                if (Console.ReadLine()?.ToLower() == "exit")
                    Environment.Exit(0);
                x += 1;
                Console.WriteLine($"Awesome, thats {x} things listed!");
            }
        }
    );

    Thread.Sleep(_duration * 1000);
    Console.Clear();
    Console.WriteLine($"Congratulations, you listed {x} items!");
    Thread.Sleep(5000);
}
}