public class WongHalves : Strategy {
    public WongHalves(int deckCount) : base(deckCount) {
        _name = "Wong Halves";
        _runningCount = 0;
        _trueCount = 0;
        _cardCount = 0;

    }

    public override void UpdateCount(string card) {

        if (card == "3" || card == "4" || card == "6") {
            _runningCount++;

        } else if (card == "2" || card == "7") {
            _runningCount += 0.5;

        } else if (card == "9") {
            _runningCount -= 0.5;

        } else if (card == "T" || card == "J" || card == "Q" || card == "K" || card == "A") {
            _runningCount--;
        }

        _trueCount = Math.Round(_runningCount / _deckCount);

        _cardCount++;
    
    }
}