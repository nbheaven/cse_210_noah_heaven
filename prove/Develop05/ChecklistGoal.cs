namespace Develop05;

class ChecklistGoal : Goal{

    private int _progress;
    private double _bonus;
    private int _progressTotal;
    private double _totalPoints;

    public ChecklistGoal(string name = "", string description = "", double points = 0, bool complete = false, int progress = 0, double bonus = 0, double totalPoints = 0, int progressTotal = 0) : 
        base(name, description, points, complete)
    {
        _goalType = "Checklist Goal";
        _progress = progress;
        _bonus = bonus;
        _progressTotal = progressTotal;
        _totalPoints = totalPoints;
    }

    public void SetProgress(int progress)
    {
        _progress = progress;
    }

    public void SetBonus(double bonus)
    {
        _bonus = bonus;
    }

    public override void PopulateGoalAttributes()
    {
        Console.WriteLine("\nWhat is the name of your goal?");
        string name = Console.ReadLine();

        Console.WriteLine("\nWhat is a short description of it?");
        string description = Console.ReadLine();

        Console.WriteLine("\nHow many points will be awarded per completion of this goal?");
        _points = CheckPointsInputDouble();

        Console.WriteLine("\nHow many bonus points would you like to be awarded once the goal is fully completed?");
        _bonus = CheckPointsInputDouble();

        Console.WriteLine("\nHow many times will the goal need to be checked off before it is completed?");
        _progressTotal = CheckPointsInputInt();

        _name = name;

        _description = description;
    }

    public override void UpdateStatus()
    {
        if (_progress < _progressTotal)
        {
            _totalPoints += _points;
            _progress++;
            if (_progress >= _progressTotal)
            {
                _totalPoints += _bonus;
                _complete = true;
            }
        }

    }

    public override double GetTotalPoints()
    {
        return _totalPoints;
    }

    public override double GetPoints()
    {
        if(_complete)
        {
            return _points + _bonus;
        }

        else
        {
            return _points;
        }
    }

    public override string DisplayForList()
    {
        if (_complete)
        {
            return($"[X] {_name} ({_description}) -- Currently completed {_progress}/{_progressTotal}");
        }
        else
        {
            return($"[ ] {_name} ({_description}) -- Currently completed {_progress}/{_progressTotal}");
        }
    }

    public override string ToJson()
    {
        return $@"{{
    ""GoalType"": ""{_goalType}"",
    ""Name"": ""{_name}"",
    ""Description"": ""{_description}"",
    ""Complete"": {_complete.ToString().ToLower()},
    ""Points"": {_points},
    ""Progress"": {_progress},
    ""Bonus"": {_bonus},
    ""ProgressTotal"": {_progressTotal},
    ""TotalPoints"": {_totalPoints}
}}";
    }
}