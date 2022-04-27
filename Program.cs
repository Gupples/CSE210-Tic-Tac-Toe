using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> board = new List<char> 
                {'1', '2', '3', '4', '5', '6', '7', '8', '9'};
            bool isGameOver = false;
            char player = '-';
            while (!isGameOver)
            {

                for (int turn = 0; turn > 9; turn++)
                {
                    // Display Board
                    displayBoard(board);

                    // Determine player
                    if ((turn % 2) == 0)                    
                    {
                        player = 'x';
                    }
                    else
                    {
                        player = 'o';
                    }

                    // Prompt for move
                    bool isTurnOver = false;
                    while (!isTurnOver)
                    {
                        Console.Write($"{player}'s turn to chose a square");
                        Console.Write(" (1-9): "); // 80 char limit.
                        string choice = Console.ReadLine();
                        bool isValid = validSquareChecker(choice, board);
                        while (!isValid)
                        {
                            if (isValid)
                            {
                                int square = int.Parse(choice);
                                board[square] = player; // Place mark on board
                                isTurnOver = true;
                            }
                            else
                            {
                                Console.Write($"Sorry; '{choice}' isn't a");
                                Console.WriteLine(" valid square.");
                            }
                        }
                    }// exit isTurnOver loop
                    // isGameOver = endgameChecker(board);

                } // exit "turn" for loop
            } // exit while (!isGameOver) loop
            // Write your code here
        } // exit main()

        static void displayBoard(List<char> board)
        {
            for (int i = 0; i < 3; i++)
            {
                int j = i * 3;
                string line;
                line = $"{board[(j + 0)]}|{board[(j + 1)]}|{board[(j + 2)]}";
                // Would combine lines 84 & 85, if not for 80 char limit.
                Console.WriteLine(line);
                if (i != 2)
                {
                    Console.WriteLine("-+-+-");
                } // exit if statement
            } // exit for loop

        } // exit displayBoard() 

        static bool endgameChecker(List<char> board)
        {
            bool isOver;
            // VVV Placeholder until I fill in the code.
            isOver = true;


            return isOver;
        } // exit endgameChecker()

        static bool validSquareChecker(string choice, List<char> board)
        {

            int subject = 0;
            // Assume choice is not valid input, and change validation
            // under specific conditions.
            bool isValidSquare = false;
            
            // IS VALID FOR CONVERSION?
            // Check to see if input can be converted to a single-digit int
            if (choice.Length == 1) // single digit
            {
                // Check to see if it's numeric. Thanks docs.microsoft for
                //  the method
                bool isNumberic = int.TryParse(choice, out subject);
                // if invalid, .TryParse() will set subject to 0 (redundant)
                
            } // exit length clause (and conversion check).

            // IS VALID SPACE?
            // 1) Is it a number 1-9?
            if (subject > 0 && subject < 10)
            {
                // 2) Is it a number hasn't been chosen yet
                char i = board[subject];
                if (i != 'x' && i != 'o')
                {
                    isValidSquare = true; // Is valid.
                } //exit chosen number

            } //exit 1-9 condition
            
            return isValidSquare;
        } // exit validSquareChecker()

    } // exit class Program
} // exit namespace
