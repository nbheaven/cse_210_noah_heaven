using System.Text;
using System.Text.Json;

namespace Develop05;

class Management {
    private double _totalPoints;
    private List<Goal> _goals = new List<Goal>();

    public Management(double totalPoints = 0) {

        _totalPoints = totalPoints;
    }

    public void RunProgram(){

        bool done = true;

        Console.Clear();
        Console.WriteLine("Welcome to the Goal Tracker System");
    
    

        while (done)
        {

            DisplayTotalPoints();
    
            Console.WriteLine("What would you like to do? \n 1. Create New Goal \n 2. List goals \n 3. Save Goals \n 4. Load Goals \n 5. Record Event \n 6. Quit");

    
            bool check = true;
            int selection = 6;
    
            while (check) {

                string input = Console.ReadLine();

                if (int.TryParse(input, out selection) && selection >= 1 && selection <= 6) {check = false;}

                else {Console.WriteLine("Invalid selection, please try again");
                }
            }
        
            switch (selection) {

                case 1:
                    Console.Clear();
                    NewGoalPrompt();
                    break;

                case 2:
                    Console.Clear();
                    ListGoals();
                    break;

                case 3:
                    Console.Clear();
                    SaveGoalsToJson("goals.json");
                    break;

                case 4:
                    Console.Clear();
                    LoadGoalsFromJson("goals.json");
                    break;

                case 5:
                    Console.Clear();
                    RecordEvent();
                    break;

                case 6:
                    done = false;
                    break;
            }
        }

    }
    public void DisplayTotalPoints()
    {
        Console.WriteLine($"You have {_totalPoints} points");
    }

    public void ListGoals(bool includeDescription = true)
    {   
        Console.WriteLine("\nThe goals are:");

        if (includeDescription) {

            for (int i = 0; i < _goals.Count; i++) {

                Console.WriteLine($"{i+1}. {_goals[i].DisplayForList()}");

            }

            Console.WriteLine();

        }

        else {

            for (int i = 0; i < _goals.Count; i++) {

                Console.WriteLine($"{i+1}. {_goals[i].GetName()}");

            }

        }

    

    }

    public void RecordEvent()
    {
        ListGoals(false);

        Console.Write("Which goal did you accomplish? ");

    
        bool check = true;
        int index = 0;

        while (check) {

            string input = Console.ReadLine();

            if (int.TryParse(input, out index) && index >= 0 && index <= _goals.Count) {check = false; index--;}

            else {Console.WriteLine("Invalid entry, please try again");
            }
        }

        if (index < 0) {}

        else {

            if (_goals[index].GetStatus()) {
                Console.WriteLine("This goal has already been completed");
            }

            else {

                _goals[index].UpdateStatus();


                if (_goals[index].GetStatus()) {

                    Console.WriteLine("Congratulations! You have completed the goal!");
                }

                Console.WriteLine($"You have been awarded {_goals[index].GetPoints()} points");

                AddPoints(_goals[index].GetPoints());

            }

        }
    }

    public void AddPoints(double points){

        _totalPoints = _totalPoints + points;

    }

    public void AddToList(Goal goal)
    { 
        _goals.Add(goal);
    }

    public void NewGoalPrompt()
    {

        Console.WriteLine("The types of goals you can create are: \n 1. Simple Goal \n 2. Eternal Goal \n 3. Checklist Goal \n 4. Exit");
        Console.WriteLine("Please enter the number of the goal you would like to create");

    
        bool check = true;
        int selection = 4;
        while (check) {

            string input = Console.ReadLine();

            if (int.TryParse(input, out selection) && selection >= 1 && selection <= 4) {check = false;}

            else {Console.WriteLine("Invalid selection, please try again");
            }
        }

        switch (selection) {

            case 1:
                Goal simpleGoal = new SimpleGoal();
                simpleGoal.PopulateGoalAttributes();
                AddToList(simpleGoal);
                break;
            

            case 2:
                Goal eternalGoal = new EternalGoal();
                eternalGoal.PopulateGoalAttributes();
                AddToList(eternalGoal);
                break;

            case 3:
                Goal checklistGoal = new ChecklistGoal();
                checklistGoal.PopulateGoalAttributes();
                AddToList(checklistGoal);
                break;

            case 4:
                break;
        }
    

    }
    public void LoadTotalPoints()
    {
        for (int i = 0; i < _goals.Count; i++)
        {

            _totalPoints += _totalPoints + _goals[i].GetTotalPoints();
        
        }
    }

    public void LoadGoalsFromJson(string filename) {

        try
        {
            string jsonString = File.ReadAllText($"/Users/noahheaven/Documents/cse_210/cse_210_noah_heaven/prove/Develop05/bin/Debug/net8.0/{filename}");
            JsonDocument doc = JsonDocument.Parse(jsonString);
            JsonElement root = doc.RootElement;

            foreach (JsonElement element in root.EnumerateArray())
            {
                string goalType = element.GetProperty("GoalType").GetString();
                string name = element.GetProperty("Name").GetString();
                string description = element.GetProperty("Description").GetString();
                bool complete = element.GetProperty("Complete").GetBoolean();
                double points = element.GetProperty("Points").GetDouble();

                switch (goalType)
                {
                    case "Simple Goal":
                        Goal simpleGoal = new SimpleGoal(name, description, points, complete);
                        AddToList(simpleGoal);
                        break;

                    case "Eternal Goal":
                        double totalPoints = element.GetProperty("TotalPoints").GetDouble();
                        Goal eternalGoal = new EternalGoal(name, description, points, totalPoints);
                        AddToList(eternalGoal);
                        break;

                    case "Checklist Goal":
                        int progress = element.GetProperty("Progress").GetInt32();
                        double bonus = element.GetProperty("Bonus").GetDouble();
                        int progressTotal = element.GetProperty("ProgressTotal").GetInt32();

                        Console.WriteLine(progressTotal);
                        double total_Points = element.GetProperty("TotalPoints").GetDouble();
                        ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, complete, progress, bonus, total_Points, progressTotal);
                        AddToList(checklistGoal);
                        break;
                }
            }

            LoadTotalPoints();
            Console.WriteLine($"Goals have been successfully loaded from {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading goals: {ex.Message}");
        }
    }

    public void SaveGoalsToJson(string filename)
    {
        try
        {
            var jsonBuilder = new StringBuilder();
            jsonBuilder.AppendLine("[");
        
            for (int i = 0; i < _goals.Count; i++)
            {

                // Console.WriteLine(_goals[i].ToJson());

                jsonBuilder.Append(_goals[i].ToJson());
                if (i < _goals.Count - 1)
                {
                    jsonBuilder.AppendLine(",");
                }
            }
        
            jsonBuilder.AppendLine("]");

            using (StreamWriter outputFile = new StreamWriter(filename))
            {
        
                outputFile.WriteLine(jsonBuilder.ToString());
            }   

            Console.WriteLine($"Goals have been successfully saved to {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving goals: {ex.Message}");
        }
    }


}