public class OmegaII : Strategy {
    public OmegaII(int deckCount) : base(deckCount) {
        _name = "Omega II";
        _runningCount = 0;
        _trueCount = 0;
        _cardCount = 0;
    }

    public override void UpdateCount(string card) {

        if (card == "2" || card == "3" || card == "7")
        {
            _runningCount++;
            
        }
        
        else if (card == "9")
        {
            _runningCount--;
        }

        else if (card == "4" || card == "5" || card == "6")
        {
            _runningCount += 2;
        }

        else if (card == "T" || card == "J" || card == "Q" || card == "K" || card == "A")
        {
            _runningCount -= 2;
        }

        _trueCount = Math.Round(_runningCount / _deckCount);

        _cardCount++;
    }
}