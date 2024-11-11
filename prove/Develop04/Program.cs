using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

class Program
{
    
    static void Main(string[] args)
    {
        bool q = true;

        while(q){

            string menu = @"
Menu Options:
    1. Start breathing activity
    2. Start reflecting activity
    3. Start listing activity
    4. Run, Spot, Run!
    5. Quit
    ";
            Console.Clear();
            Console.WriteLine(menu);
            
            Console.Write("Select a choice from the menu: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 5)
        {
                if(choice == 1){
                    
                  Breathing breath = new Breathing();
                  breath.BreathingActivity();

                }

                else if(choice == 2){
                    
                    Reflection reflect = new Reflection();
                    reflect.ReflectionActivity();

                }

                else if(choice == 3){
                    Listing list = new Listing();
                    list.ListingActivity();
                }

                else if(choice == 4){

                    Activity act = new Activity();
                    act.DogAnimation(7);
                }

                else if(choice == 5){

                    q = false;
                }

                
        }

            else
            {
                Console.WriteLine("Please enter a valid selection");
            }
        }


        
    }
}
