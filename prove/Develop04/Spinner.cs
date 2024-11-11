using System.Security.Cryptography.X509Certificates;

public class ConsoleSpinner
{


    int _counter;
    bool _check;

    public ConsoleSpinner()
    {
        _counter = 0;
        _check = true;
    }


    public void Turn(int miliseconds = 5000)
    {
        Console.CursorVisible = false;
        _counter = 0;
        _check = true;

        while(_check==true)
        {   
        
            if(_counter*50 < miliseconds)
            {
                Thread.Sleep(50);

                switch (_counter % 8)
                {
            
                    case 0: Console.Write("-"); break;
                    case 1: Console.Write("\\"); break;
                    case 2: Console.Write("|"); break;
                    case 3: Console.Write("/"); break;
                    case 4: Console.Write("-"); break;
                    case 5: Console.Write("\\"); break;
                    case 6: Console.Write("|"); break;
                    case 7: Console.Write("/"); break;
            
                }

                _counter++;
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            }
            
            else
            {
                _check=false;

            } 

        }

    Console.CursorVisible = true;

    }
}

