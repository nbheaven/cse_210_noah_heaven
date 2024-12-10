public class RPAC : Strategy {
    public RPAC(int deckCount) : base(deckCount) {
        _name = "RPAC";
        _runningCount = 0;
        _trueCount = 0;
        _cardCount = 0;
    }

    public override void UpdateCount(string card) {

        if (card == "2" || card == "7")
        {
            _runningCount += 2;
            
        }
        
        else if (card == "3" || card == "6")
        {
            _runningCount += 3;
        }

        else if (card == "5")
        {
            _runningCount += 4;
        }

        else if (card == "9")
        {
            _runningCount--;
        }

        else if (card == "T" || card == "J" || card == "Q" || card == "K")
        {
            _runningCount -= 3;
        }

        else if (card == "A")
        {
            _runningCount -= 4;
        }

        _trueCount = Math.Round(_runningCount / _deckCount);

        _cardCount++;


    
    }
}