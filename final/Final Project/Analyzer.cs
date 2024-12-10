using System;

public class Analyzer
{
    private BasicAction _basicAction;

    public Analyzer(BasicAction basicAction)
    {
        _basicAction = basicAction;
    }
    static string[,] parameters = {
        {"Last input", "", ""},
        {"Running Count", "Remaining Decks", "True Count"},
        {"Dealer Upcard", "Player Hand", "Player Total"},
        {"Recommended Action", "", ""}
    };

    private string _lastInput = "";
    private double _runningCount = 0;
    private double _remainingDecks = 0;
    private double _trueCount = 0;
    private string _dealerUpcard = " ";
    private string _playerHand = "";
    private int _playerTotal = 0;
    private string _recommendedAction = "";

    public void SetLastInput(string lastInput)
    {   
        if (_lastInput == "Invalid") {
            _lastInput = lastInput + "      ";
        }
        _lastInput = lastInput;
    }

    public void SetRunningCount(double runningCount)
    {
        _runningCount = runningCount;
    }

    public void SetRemainingDecks(double remainingDecks)
    {
        _remainingDecks = remainingDecks;
    }

    public void SetTrueCount(double trueCount)
    {
        _trueCount = trueCount;
    }

    public void SetDealerUpcard(string dealerUpcard)
    {
        _dealerUpcard = dealerUpcard;
    }

    public void SetPlayerHand(string playerHand)
    {
        _playerHand = playerHand;
    }

    public void SetPlayerTotal(int playerTotal)
    {
        _playerTotal = playerTotal;
    }

    public void SetRecommendedAction()
    {
        _recommendedAction = _basicAction.GetRecommendedAction(_playerHand, _playerTotal, _dealerUpcard, _trueCount);
    }

    public string GetRecommendedAction()
    {
        return _recommendedAction;
    }

    public void ResetAction() {
        _recommendedAction = "                ";
    }

    public bool CanSplit()
    {
        if (_playerHand[0].ToString().ToUpper() == _playerHand[1].ToString().ToUpper())
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public void DisplayAnalyzer(int cursorLeft, int cursorTop)
    {


        Console.SetCursorPosition(0, 5);
        Console.WriteLine("                           Analyzer");
        Console.SetCursorPosition(0, 6);
        Console.WriteLine("-------------------------------------------------------");
        Console.SetCursorPosition(0, 7);
        Console.Write("                   ");
        Console.SetCursorPosition(0, 7);
        Console.WriteLine($"{parameters[0, 0]}: {_lastInput}");
        Console.SetCursorPosition(0, 8);
        Console.WriteLine($"{parameters[1, 0]}: {_runningCount}    {parameters[1, 1]}: {Math.Round(_remainingDecks, 2)}    {parameters[1, 2]}: {_trueCount}   ");
        Console.SetCursorPosition(0, 9);
        Console.Write("                                                            ");
        Console.SetCursorPosition(0, 9);
        Console.WriteLine($"{parameters[2, 0]}: {_dealerUpcard}    {parameters[2, 1]}: {_playerHand}    {parameters[2, 2]}: {_playerTotal}");
        Console.SetCursorPosition(0, 10);
        Console.WriteLine($"{parameters[3, 0]}: {_recommendedAction}              ");

        Console.SetCursorPosition(cursorLeft, cursorTop);
    }
}