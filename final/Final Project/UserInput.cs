public class UserInput {
    private string _dealerUpcard;
    private int _dealerTotal;
    private string _playerHand; //convert the list of cards to a string
    private int _playerTotal;
    private Analyzer _analyzer;

    public UserInput(Analyzer analyzer) {
        _dealerUpcard = "";
        _dealerTotal = 0;
        _playerHand = "";
        _playerTotal = 0;
        _analyzer = analyzer;

    }
    
    public void UpdateDealerTotal(Strategy strategy, List<string> cards) {
        bool dealerFinished = false;
            
            while (dealerFinished == false)
            {
                    
                Console.Write("Enter Dealer card ");

                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                
                string card = keyInfo.KeyChar.ToString().ToUpper();

                if (cards.Contains(card))
                {
                    strategy.UpdateCount(card);

                    if (card == "T" || card == "J" || card == "Q" || card == "K")
                    {
                        _dealerTotal += 10;
                    }

                    else if (card == "A")
                    {
                        if (_dealerTotal + 11 <= 21)
                        {
                            _dealerTotal += 11;
                        }

                        else
                        {
                            _dealerTotal += 1;
                        }
                    }
                        
                    else if (card == "2" || card == "3" || card == "4" || card == "5" || card == "6" || card == "7" || card == "8" || card == "9")
                    {
    
                        _dealerTotal += Convert.ToInt32(card);
                    }

                    if (_dealerTotal >= 17)
                    {
                        
                    UpdateAnalyzer(strategy, card);
                    Console.SetCursorPosition(Console.CursorLeft - 18, Console.CursorTop);
                    dealerFinished = true;
                    
                    }
                    
                    else
                    {
                        UpdateAnalyzer(strategy, card);
                        Console.SetCursorPosition(Console.CursorLeft - 18, Console.CursorTop);
                    }
                }

                else
                    {
                        _analyzer.SetLastInput("Invalid");
                        _analyzer.DisplayAnalyzer(Console.CursorLeft, Console.CursorTop);
                        Console.SetCursorPosition(Console.CursorLeft - 18, Console.CursorTop);
                    }
            }
    }

    public void UpdateAnalyzer(Strategy strategy, string card) {

        
        _analyzer.SetPlayerHand(_playerHand);
        _analyzer.SetPlayerTotal(_playerTotal);
        _analyzer.SetRemainingDecks(strategy.GetRemainingDecks());
        _analyzer.SetTrueCount(strategy.GetTrueCount());
        _analyzer.SetRunningCount(strategy.GetRunningCount());
        _analyzer.SetLastInput(card);
        _analyzer.ResetAction();
        _analyzer.DisplayAnalyzer(Console.CursorLeft, Console.CursorTop);
        _analyzer.SetRecommendedAction();
        _analyzer.DisplayAnalyzer(Console.CursorLeft, Console.CursorTop);
    }

    public void Interact(Strategy strategy) {
        List <string> cards = new List<string>(["2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K", "A"]);
        string card;
        _analyzer.SetRemainingDecks(strategy.GetRemainingDecks());
        _analyzer.ResetAction();

        Console.SetCursorPosition(Console.CursorLeft - 10, Console.CursorTop);

        for (int i = 0; i < 3; i++)
{

        if (i == 0)
        {   
            Console.Write("Dealer Upcard: ");
            Console.CursorVisible = true;
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
            card = keyInfo.KeyChar.ToString().ToUpper();

            if (cards.Contains(card)) {

                strategy.UpdateCount(card);

                if (card == "T" || card == "J" || card == "Q" || card == "K" || card == "A")
                {
                    _dealerUpcard = card;
                    _dealerTotal += 10;
                }
                else if (card == "2" || card == "3" || card == "4" || card == "5" || card == "6" || card == "7" || card == "8" || card == "9")
                {
                    _dealerUpcard = card;
                    _dealerTotal += Convert.ToInt32(card);
                }

                _analyzer.SetDealerUpcard(_dealerUpcard);
                _analyzer.SetTrueCount(strategy.GetTrueCount());
                _analyzer.SetRunningCount(strategy.GetRunningCount());
                _analyzer.SetLastInput(card);
                _analyzer.SetRemainingDecks(strategy.GetRemainingDecks());
                _analyzer.DisplayAnalyzer(Console.CursorLeft, Console.CursorTop);
                Console.SetCursorPosition(Console.CursorLeft - 15, Console.CursorTop);
                Console.Write("               ");
                Console.SetCursorPosition(Console.CursorLeft - 15, Console.CursorTop);
            }
            else
            {   
                _analyzer.SetLastInput("Invalid");
                _analyzer.DisplayAnalyzer(Console.CursorLeft, Console.CursorTop);
                Console.SetCursorPosition(Console.CursorLeft - 15, Console.CursorTop);
                i--;
            }

        }
        else if (i >= 1)
        {   
            Console.CursorVisible = false;
            Console.Write("Player card: ");
            Console.CursorVisible = true;
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
            card = keyInfo.KeyChar.ToString().ToUpper();

            if (cards.Contains(card))
            {
                strategy.UpdateCount(card);

                if (card == "T" || card == "J" || card == "Q" || card == "K")
                {
                    _playerHand += card;
                    _playerTotal += 10;
                }

                else if (card == "A")
                {
                    

                    if (_playerTotal + 11 <= 21)
                    {
                        _playerHand += card;
                        _playerTotal += 11;
                    }

                    else
                    {
                        _playerHand += card.ToLower();
                        _playerTotal += 1;
                    }
                    
                }
            
                else if (card == "2" || card == "3" || card == "4" || card == "5" || card == "6" || card == "7" || card == "8" || card == "9")
                {
                    _playerHand += card;
                    _playerTotal += Convert.ToInt32(card);
                }

                _analyzer.SetPlayerHand(_playerHand);
                _analyzer.SetPlayerTotal(_playerTotal);
                _analyzer.SetTrueCount(strategy.GetTrueCount());
                _analyzer.SetRunningCount(strategy.GetRunningCount());
                _analyzer.SetLastInput(card);
                _analyzer.SetRemainingDecks(strategy.GetRemainingDecks());
                _analyzer.DisplayAnalyzer(Console.CursorLeft, Console.CursorTop); 

                Console.SetCursorPosition(Console.CursorLeft - 13, Console.CursorTop);
                Console.Write("             ");
                Console.SetCursorPosition(Console.CursorLeft - 13, Console.CursorTop);
        
            }
            else
                {
                    _analyzer.SetLastInput("Invalid");
                    _analyzer.DisplayAnalyzer(Console.CursorLeft, Console.CursorTop);
                    Console.SetCursorPosition(Console.CursorLeft - 13, Console.CursorTop);

                    i--;
                }  
    }
}

_analyzer.SetRecommendedAction();
_analyzer.DisplayAnalyzer(Console.CursorLeft, Console.CursorTop);

if (_analyzer.GetRecommendedAction() == "Blackjack!") {
    
    _dealerTotal = 16;
    UpdateDealerTotal(strategy, cards);
    return;

}

_analyzer.DisplayAnalyzer(Console.CursorLeft, Console.CursorTop);

bool finishedHand = false;  
    Console.CursorVisible = false;
    Console.CursorVisible = true;

    while (finishedHand == false)
    {
        Console.Write("Enter Player Action (H, P, D, S): ");
        ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
        card = keyInfo.KeyChar.ToString().ToUpper();
        Console.SetCursorPosition(Console.CursorLeft - 34, Console.CursorTop);
        Console.Write("                                  ");
        Console.SetCursorPosition(Console.CursorLeft - 34, Console.CursorTop);

        if (card == "S")
        {
            finishedHand = true;
        }

        else if (card == "H")
        {
            Console.Write("Enter user card ");

            keyInfo = Console.ReadKey(intercept: true);
            
            card = keyInfo.KeyChar.ToString().ToUpper();

            if (cards.Contains(card))
            {

                if (card == "T" || card == "J" || card == "Q" || card == "K")
                {
                    _playerHand += card;
                    _playerTotal += 10;
                }

                else if (card == "A")
                {

                    

                    if (_playerTotal + 11 <= 21)
                    {
                        _playerHand += card;
                        _playerTotal += 11;
                    }

                    else
                    {
                        _playerHand += card.ToLower();
                        _playerTotal += 1;
                    }
                    
                }
                    
                else if (card == "2" || card == "3" || card == "4" || card == "5" || card == "6" || card == "7" || card == "8" || card == "9")
                {
                    _playerHand += card;
                    _playerTotal += Convert.ToInt32(card);
                }

                if (_playerTotal >= 21) {
                    
                    if (_playerHand.Contains("A")) {
                        _playerTotal -= 10;

                        int index = _playerHand.IndexOf("A");


                        if (index != -1) {

                            char[] charArray = _playerHand.ToCharArray();

                            charArray[index] = Char.ToLower(charArray[index]);

                            _playerHand = new string(charArray);
                        }

                    }

                    
                    if (_playerTotal >= 21) {

                    UpdateAnalyzer(strategy, card);
                    Console.SetCursorPosition(Console.CursorLeft - 16, Console.CursorTop);
                    finishedHand = true;
                    _dealerTotal = 16;

                    }
                
                }
                
                else
                {
                    
                    UpdateAnalyzer(strategy, card);
                    Console.SetCursorPosition(Console.CursorLeft - 16, Console.CursorTop);
                }
            }
        }

        else if (card == "P")
        {
            if (_analyzer.CanSplit() == true)
            {   
                int splitBase = 0;

                if (_playerHand.ToUpper() == "AA") {splitBase = 11;}
                
                else {splitBase = _playerTotal / 2;}

                
                for (int i = 0; i < 2; i++)
                {
                    int count = 0;

                        _playerTotal = splitBase;

                    string splitPlayerHand = _playerHand[i].ToString().ToUpper(); 

                    _playerTotal = Convert.ToInt32(splitBase);
                    bool finishedSplit = false;

                    _analyzer.SetPlayerHand("       ");
                    _analyzer.DisplayAnalyzer(Console.CursorLeft, Console.CursorTop);

                    while (finishedSplit == false)
                    {

                    _analyzer.SetPlayerHand(splitPlayerHand);
                    _analyzer.SetPlayerTotal(_playerTotal);
                    _analyzer.SetTrueCount(strategy.GetTrueCount());
                    _analyzer.SetRunningCount(strategy.GetRunningCount());
                    _analyzer.SetLastInput(card);
                    _analyzer.SetRemainingDecks(strategy.GetRemainingDecks());
                    _analyzer.DisplayAnalyzer(Console.CursorLeft, Console.CursorTop);
                    Console.Write("Enter user card ");

                    keyInfo = Console.ReadKey(intercept: true);
                
                    card = keyInfo.KeyChar.ToString().ToUpper();

                    if (cards.Contains(card))
                    {
                        strategy.UpdateCount(card);
                    }

                    if (cards.Contains(card) || card == "S")
                    {
                        
                        if (card == "S") {
                            finishedSplit = true;
                        }

                        else if (card == "T" || card == "J" || card == "Q" || card == "K")
                        {
                            splitPlayerHand += card;
                            _playerTotal += 10;
                        }

                        else if (card == "A")
                        {

                            if (_playerTotal + 11 <= 21)
                            {
                                _playerTotal += 11;
                                splitPlayerHand += card;
                            }

                            else
                            {
                                splitPlayerHand += card.ToLower();
                                _playerTotal += 1;
                            }
    
                        }

                        else if (card == "2" || card == "3" || card == "4" || card == "5" || card == "6" ||
                                 card == "7" ||
                                 card == "8" || card == "9")
                        {
                            splitPlayerHand += card;
                            _playerTotal += Convert.ToInt32(card);
                        }

                        if (_playerTotal >= 21)
                        {
                            if (_playerTotal == 21) {finishedSplit = true; continue;}

                            if (_playerHand.Contains("A")) {
                            _playerTotal -= 10;

                            int index = _playerHand.IndexOf("A");


                            if (index != -1) {

                                char[] charArray = _playerHand.ToCharArray();

                                charArray[index] = Char.ToLower(charArray[index]);

                                _playerHand = new string(charArray);
                            }



                        }

                            if (_playerTotal >= 21)
                            {

                            finishedSplit = true;
                            UpdateAnalyzer(strategy, card);
                            count ++;

                            if (count == 2) {_dealerTotal = 16;}
                            }

                            Console.SetCursorPosition(Console.CursorLeft - 16, Console.CursorTop);

                            

                        }

                        else
                        {   
                            _analyzer.SetPlayerHand(splitPlayerHand);
                            _analyzer.SetPlayerTotal(_playerTotal);
                            _analyzer.SetTrueCount(strategy.GetTrueCount());
                            _analyzer.SetRunningCount(strategy.GetRunningCount());
                            _analyzer.SetLastInput(card);
                            _analyzer.SetRemainingDecks(strategy.GetRemainingDecks());
                            _analyzer.ResetAction();
                            _analyzer.DisplayAnalyzer(Console.CursorLeft, Console.CursorTop);
                            _analyzer.SetRecommendedAction();
                            _analyzer.DisplayAnalyzer(Console.CursorLeft, Console.CursorTop);

                            Console.SetCursorPosition(Console.CursorLeft - 16, Console.CursorTop);
                            
                        }
                        

                    }

                    else
                    {
                        _analyzer.SetLastInput("Invalid");
                        _analyzer.DisplayAnalyzer(Console.CursorLeft, Console.CursorTop);
                        Console.SetCursorPosition(Console.CursorLeft - 16, Console.CursorTop);
                        i--;
                    }

                }
                
                finishedHand = true;
            }
        }
 
    }

    else if (card == "D")
        {

            while (true) {

            Console.Write("Enter user card ");

            keyInfo = Console.ReadKey(intercept: true);
            
            card = keyInfo.KeyChar.ToString().ToUpper();

            if (cards.Contains(card))
            {

                if (card == "T" || card == "J" || card == "Q" || card == "K")
                {
                    _playerHand += card;
                    _playerTotal += 10;
                }

                else if (card == "A")
                {
                    

                    if (_playerTotal + 11 <= 21)
                    {
                        _playerTotal += 11;
                        _playerHand += card;
                    }

                    else
                    {
                        _playerHand += card.ToLower();
                        _playerTotal += 1;
                    }
    
                }
                    
                else if (card == "2" || card == "3" || card == "4" || card == "5" || card == "6" || card == "7" || card == "8" || card == "9")
                {
                    _playerHand += card;
                    _playerTotal += Convert.ToInt32(card);
                }

                if (_playerTotal >= 21) {
                    
                    if (_playerHand.Contains("A")) {
                        _playerTotal -= 10;

                        int index = _playerHand.IndexOf("A");


                        if (index != -1) {

                            char[] charArray = _playerHand.ToCharArray();

                            charArray[index] = Char.ToLower(charArray[index]);

                            _playerHand = new string(charArray);
                        }

                    }

                    
                    if (_playerTotal >= 21) {

                    _dealerTotal = 16;
                    finishedHand = true;
                    UpdateAnalyzer(strategy, card);
                    break;
                    }
                }
        }
        
        else
        {
            _analyzer.SetLastInput("Invalid");
            _analyzer.DisplayAnalyzer(Console.CursorLeft, Console.CursorTop);
            Console.SetCursorPosition(Console.CursorLeft - 16, Console.CursorTop);
            
            continue;
        }

        UpdateAnalyzer(strategy, card);
        finishedHand = true;
        Console.SetCursorPosition(Console.CursorLeft - 16, Console.CursorTop);
        break;
            } 
        }

        else
        {
            _analyzer.SetLastInput("Invalid");
            _analyzer.DisplayAnalyzer(Console.CursorLeft, Console.CursorTop);
        }

}

UpdateDealerTotal(strategy, cards);

}
}