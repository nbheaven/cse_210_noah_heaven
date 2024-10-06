public class Job
{
   public string _jobTitle;
   public int _startYear;
   public int _endYear;
   public string _company;

   public void Display()
   {
      Console.WriteLine($"{_jobTitle}, {_startYear}, {_endYear}, {_company}");
   }
}