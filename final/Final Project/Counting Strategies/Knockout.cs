public class Knockout : Strategy {
    public Knockout(int deckCount) : base(deckCount) {
        _name = "Knockout";
        _runningCount = 0;
        _trueCount = 0;
        _cardCount = 0;
    }

    public override void UpdateCount(string card) {

        if (card == "2" || card == "3" || card == "4" || card == "5" || card == "6" || card == "7") {
            _runningCount++;
            
        } else if (card == "T" || card == "J" || card == "Q" || card == "K" || card == "A") {
            _runningCount--;
        }

        _trueCount = Math.Round(_runningCount / _deckCount);

        _cardCount++;


    
    }
}