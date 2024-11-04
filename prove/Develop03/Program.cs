using System;   
using System.IO;
using System.Text.Json;
using Develop03;

class Program
{
    static void Main(string[] args)
    {
        JsonQuery test1 = new JsonQuery();
        Scripture scripture = new Scripture();
        scripture.ToWordList(test1.QueryJson());
        scripture.DisplayQuiz();
        
    }
}