public abstract class Strategy {

    protected string _name;
    protected int _deckCount;
    protected double _runningCount;
    protected double _trueCount;
    protected int _cardCount;

    public Strategy(int deckCount){
        _deckCount = deckCount;
    }

    public string GetStrategyName() {
        return _name;
    }

    public void ResetCount(){
        _runningCount = 0;
        _trueCount = 0;
        _cardCount = 0;
    }
    public abstract void UpdateCount(string card);

    public double GetTrueCount() {
        return _trueCount;
    }

    public double GetRunningCount() {
        return _runningCount;
    }

    public double GetRemainingDecks() {
        return (_deckCount*52.0 - _cardCount) / 52.0;
    }


}