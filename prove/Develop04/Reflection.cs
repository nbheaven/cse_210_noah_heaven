class Reflection : Activity
{

    public Reflection()
    {
        _welcomeDescription = "This activity will help you reflect on times in your life when you have shown strength and resilience.\nThis will help you recognize the power you have and how you can use it in other aspects of your life. \nEvery 5 seconds a new prompt to ponder will appear ";

        _promptList = [["Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless.",
            "Think of a time when you made a positive impact on someone's life.",
            "Think of a time when you overcame a personal challenge.",
            "Think of a time when you worked hard for something you believed in.",
            "Think of a time when you forgave someone who hurt you.",
            "Think of a time when you inspired others by your actions."], ["Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"]];
    }

    public void ReflectionActivity()
    {
        Console.Clear();
        double x = 0;
        ConsoleSpinner spinner = new();
        PromptForDuration();
        Console.Clear();
        Console.WriteLine(_openingMessage);
        Console.WriteLine();
        Console.Write(_welcomeDescription);
        spinner.Turn(5000);
        Console.Clear();
        

        while (x < _duration)
        {
            Console.Clear();
            Console.WriteLine();
            Console.Write(RandomListSelector(_promptList[0]));

            for(int i = 0; i < 12; i++)
            {
               spinner.Turn(400);
               x += 0.4;

               if(x >= _duration)
               {
                    break;
               }

            }

            if(x <= _duration){
                Console.WriteLine();
                Console.Write(RandomListSelector(_promptList[1]));

                for(int i = 0; i<12; i++)
                {
                    spinner.Turn(400);
                    x += 0.4;
                
                    if(x >= _duration)
                    {
                        break;
                    }

                }
            
            }
        }
        
        Console.Clear();
        Console.WriteLine(_closingMessage);
        Thread.Sleep(3000);
        Console.Clear();
    }
}