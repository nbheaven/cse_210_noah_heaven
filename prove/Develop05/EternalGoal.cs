using System.Security.Cryptography;

class EternalGoal : Goal{

    private double _totalPoints;

    public EternalGoal(string name = "", string description = "", double points = 0, double totalPoints = 0) : 
    base(name, description, points) {

        _goalType = "Eternal Goal";
    }

    public override string ToJson()
    {
        return $@"{{
    ""GoalType"": ""{_goalType}"",
    ""Name"": ""{_name}"",
    ""Description"": ""{_description}"",
    ""Complete"": {_complete.ToString().ToLower()},
    ""Points"": {_points},
    ""TotalPoints"": {_totalPoints}
}}";
    }


    public override void UpdateStatus()
    {
        _totalPoints += _points;
    }

    public override void PopulateGoalAttributes(){

        Console.WriteLine("\nWhat is the name of your goal?");
        string name = Console.ReadLine();

        Console.WriteLine("\nWhat is a short description of it?");
        string description = Console.ReadLine();

        Console.WriteLine("\nWhat is the amount of points associated with this goal?");

        _points = CheckPointsInputDouble();

        _name = name;

        _description = description;
   
     }


    public override string DisplayForList(){

        return $"[ ] {_name} ({_description})";

     }

    public override double GetPoints(){

        return _totalPoints;
    }

    public override double GetTotalPoints()
    {
        return _totalPoints;
    }

    

}