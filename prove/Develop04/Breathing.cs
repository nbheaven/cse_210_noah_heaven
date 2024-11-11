using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;

class Breathing : Activity{

    public Breathing()
    {
        _welcomeDescription = "This activity will help you relax by walking you through breathing in and out slowly.\nClear your mind and focus on your breathing. ";
        _promptList = [["breathe in"], ["breathe out"]];
    }

public void BreathingActivity()
    {   
        Console.Clear();
        ConsoleSpinner spinner = new();
        PromptForDuration();
        Console.WriteLine($"{_openingMessage}\n");
        Console.Write($"{_welcomeDescription}");
        spinner.Turn(5000);

            int counter = 0;
            double x = 0;
            Console.CursorVisible = false;

            Console.Clear();

            while (x < _duration) 
            {
            
                Console.Write($"{_promptList[0][0]}");

                for(int i = 0; i<16; i++)
                {
                
                    if(i%4 == 0 || i == 0)
                    {

                        switch (counter % 4)
                        {
                        
                            case 0: Console.Write("  *---"); break;
                            case 1: Console.Write("  -*--"); break;
                            case 2: Console.Write("  --*-"); break;
                            case 3: Console.Write("  ---*"); break;
                
                        }

                        counter++;
                        Console.SetCursorPosition(Console.CursorLeft - 6, Console.CursorTop);

                    }
                    
                    if(x < _duration)
                    {
                        Thread.Sleep(250);
                        x += 0.25;
                    }

                    else
                    {
                        break;
                    }
                }

                Console.Clear();

                if(x<_duration){

                    Console.Write($"{_promptList[1][0]}");

                    for(int i = 0; i<16; i++){

                        if(i%4 == 0 || i == 0)
                        {

                            switch (counter % 4)

                            {
                                case 0: Console.Write("  ---*"); break;
                                case 1: Console.Write("  --*-"); break;
                                case 2: Console.Write("  -*--"); break;
                                case 3: Console.Write("  *---"); break;
                            }

                            counter++;
                            Console.SetCursorPosition(Console.CursorLeft - 6, Console.CursorTop);

                        }

                        if(x < _duration){
                            Thread.Sleep(250);
                            x += 0.25;
                        }

                        else
                        {
                            break;
                        }
                        
                    }

                }

                Console.Clear();
            }

        Console.CursorVisible = true;
    }
}