using System;

class Program
{
    static void Main()
    {
        bool userquit = false;
        int useroption = 0;
        Journal journal = new Journal();
        Entry entry = new Entry();
        Console.WriteLine("Welcome to the journal program!\nPlease select one of the following options!");
        
        while (userquit == false)
        {
        Console.WriteLine("1. Write\n2. Display\n3. Load\n4. Save\n5. Quit");
        useroption = int.Parse(Console.ReadLine());
        
            if (useroption == 1)
            {
                string _entry = entry.New_Entry();
                
                journal._entries.Add(_entry);
            }
        

            else if (useroption == 2)
            {
                journal.Display();
            }

            else if (useroption == 3)
            {
                journal._entries = journal.Load();
            }

            else if (useroption == 4)
            {
                journal.save(journal._entries);
            }

            else if (useroption == 5)
            {
                userquit = true;
            }
        }
    }
}