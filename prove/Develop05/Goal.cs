using System.Runtime.CompilerServices;

public abstract class Goal {

    protected string _goalType;

    protected string _name;

    protected string _description;

    protected bool _complete;

    protected double _points;

    protected Goal(string name = "", string description = "", double points = 0, bool complete = false){

        _name = name;

        _description = description;

        _complete = complete;

        _points = points;

    }


    public abstract void UpdateStatus();

    public abstract void PopulateGoalAttributes();

    public abstract string DisplayForList();

    public abstract double GetTotalPoints();
    public abstract double GetPoints();

    public bool GetStatus(){

        return _complete;

    }


    public void SetName(string name){

        _name = name;

    }

    public string GetName(){

        return _name;

    }

    public void SetDescription(string description){

        _description = description;

    }

    public string GetGoalType(){

        return _goalType;
    }

    public int CheckPointsInputInt() {

          bool check = true;
            int value = 0;

        while (check) {

            string input = Console.ReadLine();

            if (int.TryParse(input, out value)){

                check = false;
            }

            else {

                Console.WriteLine("Invalid points, please try again");
                continue;
            }

        }
            
             return value;

    }

    public double CheckPointsInputDouble()
    {

        bool check = true;
        double points = 0;

        while (check) {

            string input = Console.ReadLine();

            if (double.TryParse(input, out points)){

                check = false;
            }

            else {

                Console.WriteLine("Invalid points, please try again");
                continue;
            }

        }

         return points;
        
    }

    public abstract string ToJson();




}