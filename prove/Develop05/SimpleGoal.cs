namespace Develop05;

class SimpleGoal : Goal{

    public SimpleGoal(string name = "", string description = "", double points = 0, bool complete = false) : 
        base(name, description, points, complete)
    {
        _goalType = "Simple Goal";
    }

    public override void PopulateGoalAttributes()
    {
        Console.WriteLine("\nWhat is the name of your goal?");
        string name = Console.ReadLine();

        Console.WriteLine("\nWhat is a short description of it?");
        string description = Console.ReadLine();

        Console.WriteLine("\nWhat is the amount of points associated with this goal?");

        _points = CheckPointsInputDouble();

        _name = name;

        _description = description;

    }

    public override void UpdateStatus()
    {
        _complete = true;
    }

    public override double GetTotalPoints()
    {
        if (_complete)
        {
            return _points;
        }

        else
        {
            return 0;
        }
    }

    public override double GetPoints()
    {
        if (_complete)
        {
            return _points;
        }

        else
        {
            return 0;
        }
    }

    public override string DisplayForList()
    {
        if (_complete){

            return $"[X] {_name} ({_description})";
        }

        else {

            return $"[ ] {_name} ({_description})";
        }

    }

    public override string ToJson()
    {
        return $@"{{
    ""GoalType"": ""{_goalType}"",
    ""Name"": ""{_name}"",
    ""Description"": ""{_description}"",
    ""Complete"": {_complete.ToString().ToLower()},
    ""Points"": {_points}
}}";
    }
    
}