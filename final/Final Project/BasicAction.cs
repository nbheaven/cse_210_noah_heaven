public class BasicAction
{
    static string[,] basicChart = {
        // Dealer's upcard: 2, 3, 4, 5, 6, 7, 8, 9, 10, A
        // Player's hand: 5-8, 9, 10, 11, 12, 13-16, 17, A2-A3, A4-A5, A6, A7, A8-A9, AA, 22-77, 88, 99, TT
        { "H", "H", "H", "H", "H", "H", "H", "H", "H", "H" }, // 5-8
        { "H", "D", "D", "D", "D", "H", "H", "H", "H", "H" }, // 9
        { "D", "D", "D", "D", "D", "D", "D", "D", "H", "H" }, // 10
        { "D", "D", "D", "D", "D", "D", "D", "D", "D", "D" }, // 11
        { "H", "H", "S", "S", "S", "H", "H", "H", "H", "H" }, // 12
        { "S", "S", "S", "S", "S", "H", "H", "H", "H", "H" }, // 13-16
        { "S", "S", "S", "S", "S", "S", "S", "S", "S", "S" }, // 17
        { "H", "H", "H", "D", "D", "H", "H", "H", "H", "H" }, // A2-A3
        { "H", "H", "D", "D", "D", "H", "H", "H", "H", "H" }, // A4-A5
        { "H", "D", "D", "D", "D", "H", "H", "H", "H", "H" }, // A6
        { "S", "D", "D", "D", "D", "S", "S", "H", "H", "H" }, // A7
        { "S", "S", "S", "S", "S", "S", "S", "S", "S", "S" }, // A8-A9
        { "P", "P", "P", "P", "P", "P", "P", "P", "P", "P" }, // AA
        { "P", "P", "P", "P", "P", "H", "H", "H", "H", "H" }, // 22-77
        { "P", "P", "P", "P", "P", "P", "P", "P", "P", "P" }, // 88
        { "P", "P", "P", "P", "P", "S", "P", "P", "S", "S" }, // 99
        { "S", "S", "S", "S", "S", "S", "S", "S", "S", "S" }  // TT
    };

    
    // H = Hit, S = Stand, D = Double, P = Split

    private int GetRow(string playerHand, int playerTotal)
    {   
        
        playerHand = playerHand.Replace("J", "T");
        playerHand = playerHand.Replace("Q", "T");
        playerHand = playerHand.Replace("K", "T");
        playerHand = playerHand.ToUpper();
        if (playerHand == "AT" || playerHand == "TA") return 999;
        else if (playerHand == "A2" || playerHand == "A3" || playerHand == "2A" || playerHand == "3A") return 7;
        else if (playerHand == "A4" || playerHand == "A5" || playerHand == "4A" || playerHand == "5A") return 8;
        else if (playerHand == "A6" || playerHand == "6A") return 9;
        else if (playerHand == "A7" || playerHand == "7A") return 10;
        else if (playerHand == "A8" || playerHand == "A9" || playerHand == "8A" || playerHand == "9A") return 11;
        else if (playerHand == "AA") return 12;
        else if (playerHand == "22" || playerHand == "33" || playerHand == "44" || playerHand == "55" || playerHand == "66" || playerHand == "77") return 13;
        else if (playerHand == "88") return 14;
        else if (playerHand == "99") return 15;
        else if (playerHand == "TT") return 16;
        else if (playerTotal < 5) return 0;
        else if (playerTotal >= 5 && playerTotal <= 8) return 0;
        else if (playerTotal == 9) return 1;
        else if (playerTotal == 10) return 2;
        else if (playerTotal == 11) return 3;
        else if (playerTotal == 12) return 4;
        else if (playerTotal >= 13 && playerTotal <= 16) return 5;
        else if (playerTotal >= 17) return 6;
        else throw new ArgumentException("Invalid player hand");
    }

    private int GetColumn(int dealerUpcard)
    {
        if (dealerUpcard >= 2 && dealerUpcard <= 10) return dealerUpcard - 2;
        else if (dealerUpcard == 1) return 9; 
        else throw new ArgumentException("Invalid dealer upcard");
    }

    private string GetDeviation(int dealerUpcard, int playerTotal, double trueCount, string playerHand) {

        int intTrueCount = Convert.ToInt32(trueCount);
        playerHand = playerHand.ToUpper();

        if (dealerUpcard == 1 && intTrueCount >= 3) {return "Take Insurance";}
        else if (playerTotal == 9 && dealerUpcard == 2 && intTrueCount >= 1) {return "Double Down";}
        else if (playerTotal == 9 && dealerUpcard == 7 && intTrueCount >= 3) {return "Double Down";}
        else if (playerTotal == 10 && dealerUpcard == 10 && intTrueCount >= 4) {return "Double Down";}
        else if (playerTotal == 11 && dealerUpcard == 1 && intTrueCount >= 1) {return "Double Down";}
        else if (playerTotal == 12 && dealerUpcard == 2 && intTrueCount >= 3 && playerHand != "AA") {return "Stand";}
        else if (playerTotal == 12 && dealerUpcard == 3 && intTrueCount >= 2 && playerHand != "AA") {return "Stand";}
        else if (playerTotal == 12 && dealerUpcard == 4 && intTrueCount <= 0 && playerHand != "AA") {return "Hit";}
        else if (playerTotal == 12 && dealerUpcard == 5 && intTrueCount <= -2 && playerHand != "AA") {return "Hit";}
        else if (playerTotal == 12 && dealerUpcard == 6 && intTrueCount <= -1 && playerHand != "AA") {return "Hit";}
        else if (playerTotal == 13 && dealerUpcard == 2 && intTrueCount <= -1) {return "Hit";}
        else if (playerTotal == 13 && dealerUpcard == 3 && intTrueCount <= -2) {return "Hit";}
        else if (playerTotal == 15 && (dealerUpcard == 10 || dealerUpcard == 1) && intTrueCount >= 4) {return "Stand";}
        else if (playerTotal == 16 && dealerUpcard == 9 && intTrueCount >= 5) {return "Stand";}
        else if (playerTotal == 16 && (dealerUpcard == 10 || dealerUpcard == 1) && intTrueCount >= 0) {return "Stand";}
        else if (playerTotal == 16 && dealerUpcard == 1 && intTrueCount < 3) {return "Surrender";}
        else if (playerTotal == 17 && dealerUpcard == 1 && intTrueCount < 3) {return "Surrender";}
        else return "No Deviation";

    }
    public string GetRecommendedAction(string playerHand, int playerTotal, string dealerUpcard, double trueCount)
    {   
         int intDealerUpcard = 0;

        if (dealerUpcard == "T" || dealerUpcard == "J" || dealerUpcard == "Q" || dealerUpcard == "K") {intDealerUpcard = 10;}
        else if (dealerUpcard == "A") {intDealerUpcard = 1;}
        else {intDealerUpcard = int.Parse(dealerUpcard);}

        if (playerTotal > 21) {return "Bust";}

        if (GetRow(playerHand, playerTotal) == 999) {
            return "Blackjack!";
        }

        string action = basicChart[GetRow(playerHand, playerTotal), GetColumn(intDealerUpcard)];

         if (trueCount < 0) {
            if (action == "D") {
                return "Hit";
            }
        }

        string deviation = GetDeviation(intDealerUpcard, playerTotal, trueCount, playerHand);
        
        if (deviation != "No Deviation") {
            return deviation;
        }

        else {
            if (action == "H") {return "Hit";}
            else if (action == "S") {return "Stand";}
            else if (action == "D") {return "Double Down";}
            else if (action == "P") {return "Split";}
            else {return "Error";}
        }
    }
}

