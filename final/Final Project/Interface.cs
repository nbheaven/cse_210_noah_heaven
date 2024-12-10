public class Interface {

    static List<Strategy> strategies = [new HiLo(1), new Knockout(1), new WongHalves(1), new ZenCount(1), new OmegaII(1), new ReKo(1), new RPAC(1), new SilverFox(1)];
    static string[,] menuOptions = {
        { "Decks", "Strategy", "Exit" },
        { "Card Input", "", "" }
    };
    static string[] option1Settings = { "1", "2", "3", "4", "5", "6", "7", "8" };
    static string[] option2Settings = {strategies[0].GetStrategyName(), strategies[1].GetStrategyName(), strategies[2].GetStrategyName(), strategies[3].GetStrategyName(), strategies[4].GetStrategyName(), strategies[5].GetStrategyName(), strategies[6].GetStrategyName(), strategies[7].GetStrategyName()};
    static int option1Index = 0;
    static int option2Index = 0;
    static int check1 = 0;
    static int check2 = 0;
    static BasicAction basicAction = new BasicAction();
    static Analyzer analyzer = new Analyzer(basicAction);
    public Strategy GetStrategy() {
        return strategies[option2Index];
    }

    public void Show() {

        bool exit = false;
        Console.CursorVisible = false;

        while (!exit)
        {
            Console.Clear();
            (int row, int col) mainMenuChoice = DisplayMainMenu();
            if (mainMenuChoice == (0, 2))
            {
                exit = true;
                Console.Clear();
            }
        }
    }

    static (int, int) DisplayMainMenu()
    {
        int selectedRow = 0;
        int selectedCol = 0;
        bool inSettingMode = false;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Settings:");
            for (int row = 0; row < menuOptions.GetLength(0); row++)
            {
                for (int col = 0; col < menuOptions.GetLength(1); col++)
                {
                    if (menuOptions[row, col] == "") continue;

                    if (col % 3 != 0) Console.Write("  ");

                    if (row == selectedRow && col == selectedCol && !inSettingMode)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write(menuOptions[row, col]);
                    Console.ResetColor();

                    if (row == 0 && col == 0)
                    {
                        if (row == selectedRow && col == selectedCol && inSettingMode)
                        {
                            Console.Write(": ");
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(option1Settings[option1Index]);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write($": {option1Settings[option1Index]}");
                        }
                    }
                    else if (row == 0 && col == 1)
                    {
                        if (row == selectedRow && col == selectedCol && inSettingMode)
                        {
                            Console.Write(": ");
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(option2Settings[option2Index]);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write($": {option2Settings[option2Index]}");
                        }
                    }
                    else if (row == 1 && col == 0)
                    {
                        if (row == selectedRow && col == selectedCol && inSettingMode)
                        {
                            UserInput user = new UserInput(analyzer);
                            analyzer.DisplayAnalyzer(Console.CursorLeft, Console.CursorTop);

                            user.Interact(strategies[option2Index]);
                            Console.Write(" - Hand Complete - Press Enter to continue to next hand.");
                            analyzer.SetPlayerHand("");
                            analyzer.SetPlayerTotal(0);
                            analyzer.ResetAction();
                            analyzer.SetDealerUpcard(" ");
                            analyzer.DisplayAnalyzer(Console.CursorLeft, Console.CursorTop);
                            inSettingMode = false;
                            Console.CursorVisible = false;
                        }
                        else
                        {
                            Console.Write($":");
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
                Console.WriteLine();
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (inSettingMode)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (selectedRow == 0 && selectedCol == 0)
                           { int check1 = option1Index;
                             option1Index = (option1Index == 0) ? option1Settings.Length - 1 : option1Index - 1;
                           }

                        else if (selectedRow == 0 && selectedCol == 1)
                            { int check2 = option2Index;
                              option2Index = (option2Index == 0) ? option2Settings.Length - 1 : option2Index - 1;
                            }
                        break;
                    case ConsoleKey.RightArrow:
                        if (selectedRow == 0 && selectedCol == 0)
                            option1Index = (option1Index == option1Settings.Length - 1) ? 0 : option1Index + 1;
                        else if (selectedRow == 0 && selectedCol == 1)
                            option2Index = (option2Index == option2Settings.Length - 1) ? 0 : option2Index + 1;
                        break;
                    case ConsoleKey.Enter:
                        if (selectedRow == 0 && selectedCol == 0) {
                            if (check1 != option1Index) {
                                
                                strategies[0] = new HiLo(option1Index + 1);
                                strategies[1] = new Knockout(option1Index + 1);
                                strategies[2] = new WongHalves(option1Index + 1);
                                strategies[3] = new ZenCount(option1Index + 1);
                                strategies[4] = new OmegaII(option1Index + 1);
                                strategies[5] = new ReKo(option1Index + 1);
                                strategies[6] = new RPAC(option1Index + 1);
                                strategies[7] = new SilverFox(option1Index + 1);
                                check1 = option1Index;
                            }

                            else if (check2 != option2Index) {
                                strategies[0] = new HiLo(option1Index + 1);
                                strategies[1] = new Knockout(option1Index + 1);
                                strategies[2] = new WongHalves(option1Index + 1);
                                strategies[3] = new ZenCount(option1Index + 1);
                                strategies[4] = new OmegaII(option1Index + 1);
                                strategies[5] = new ReKo(option1Index + 1);
                                strategies[6] = new RPAC(option1Index + 1);
                                strategies[7] = new SilverFox(option1Index + 1);
                                check2 = option2Index;
                            }
                            
                        }
                        inSettingMode = false;
                        break;
                }
            }
            else
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedRow = (selectedRow == 0) ? menuOptions.GetLength(0) - 1 : selectedRow - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        if (selectedRow == 0 && (selectedCol == 2 || selectedCol == 1)) {selectedCol = 0;}

                        selectedRow = (selectedRow == menuOptions.GetLength(0) - 1) ? 0 : selectedRow + 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (selectedRow == 1) {selectedCol = 0;}

                        else {
                        selectedCol = (selectedCol == 0) ? menuOptions.GetLength(1) - 1 : selectedCol - 1;
                        }
                        break;
                    case ConsoleKey.RightArrow:

                        if (selectedRow == 1) {selectedCol = 0;}

                        else {
                        selectedCol = (selectedCol == menuOptions.GetLength(1) - 1) ? 0 : selectedCol + 1;
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (selectedRow == 0 && selectedCol == 2)
                            return (selectedRow, selectedCol);
                        else
                            inSettingMode = true;
                        break;
                }
            }

        }

        }


    }