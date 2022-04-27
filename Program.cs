// HYPERLINK TO VIDEO OF WORKING PROGRAM:
// https://drive.google.com/file/d/1leRKqtrbFZDroseAMogcL2LT5pKROfEp/view?usp=sharing

using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            string playAgain = "yes";
            while (playAgain.ToLower() == "yes")
            {                
                List<char> board = new List<char> 
                    {'1', '2', '3', '4', '5', '6', '7', '8', '9'};
                bool isGameOver = false;
                bool isWinner = false;
                char player = '-';
                while (!isGameOver)
                {

                    for (int turn = 0; turn < 9; turn++)
                    {
                        if (isGameOver)
                        {
                            break;

                        }
                        bool isTurnOver = false;
                        // Display Board
                        if (turn != 0) 
                        {
                            Console.WriteLine();
                        }
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
                        while (!isTurnOver)
                        {
                            bool isValid = false;
                            while (!isValid)
                            {
                                Console.Write($"\n{player}'s turn to chose a square");
                                    Console.Write(" (1-9): "); // 80 char limit.
                                string choice = Console.ReadLine();
                                isValid = validSquareChecker(choice, board);
                                if (isValid)
                                {
                                    int square = int.Parse(choice) - 1;
                                    board[square] = player; // Place mark on board
                                    isTurnOver = true;
                                }
                                else
                                {
                                    Console.Write($"Sorry; '{choice}' isn't a");
                                    Console.WriteLine(" valid square.");
                                }
                            } // exit while(!isValid) loop
                        } // exit isTurnOver loop

                        isWinner = winnerCheck(board);
                        if (isWinner)
                        {
                            isGameOver = true;
                            Console.WriteLine($"Congratulations! {player}'s wins!");
                        }

                    } // exit "turn" for loop
                    if (!isWinner)
                    {
                        isGameOver = true;
                        Console.WriteLine("There was no winner.");
                    }

                } // exit while (!isGameOver) loop

                Console.Write("\nWould you like to play again? (yes/no) ");
                playAgain = Console.ReadLine();
                if (playAgain.ToLower() == "yes")
                {
                    Console.WriteLine();
                }
            } // exit while (playAgain)

            // Thank the user for playing
            Console.WriteLine("Thank you for playing!\n");

        } // exit main()

        static void displayBoard(List<char> board)
        {
            // draw row by row
            for (int i = 0; i < 3; i++)
            {
                int j = i * 3;
                string line;
                line = $"{board[(j + 0)]}|{board[(j + 1)]}|{board[(j + 2)]}";
                // ^^^Would combine those two lines, if not for 80 char limit.
                Console.WriteLine(line);
                // This next part isn't needed on the bottom line
                if (i != 2)
                {
                    Console.WriteLine("-+-+-");
                } // exit if statement
            } // exit for loop

        } // exit displayBoard() 

        static bool winnerCheck(List<char> board)
        {
            // Assume game is not over.
            bool isWinner = false;
            
            // Are any of the rows the same?
            for (int i = 0; i < 3; i++)
            {
                int j = i * 3;
                int col1 = j;
                int col2 = j + 1;
                int col3 = j + 2; 
                if (board[col1] == board[col2] &&
                 board[col2] == board[col3])
                {
                    isWinner = true;
                    break;
                }
            } // exit row loop

            // If there wasn't a winner yet...
            if (!isWinner)
            {
                // ...are any of the columns the same?
                for (int i = 0; i < 3; i++)
                {
                    int row1 = i;
                    int row2 = i + 3;
                    int row3 = i + 6;
                    if (board[row1] == board[row2] &&
                    board[row2] == board[row3])
                    {
                        isWinner = true;
                        break;
                    }
                } // exit column loop

                if (!isWinner)
                {
                    // Check for \ pattern
                    if (board[0] == board[4] && board[4] == board[8])
                    {
                        isWinner = true;
                    }

                    if (!isWinner)
                    {
                        // check for / pattern (Last condition for winners)
                        if (board[2] == board[4] && board[4] == board[6])
                        {
                            isWinner = true;
                        }//exit / win condition
                    } // exit \ win condition 
                } // exit column win condition
            } // exit row win condition

            // Is it a tie?
            // TAKEN CARE OF WITH TURNS LOOP
            return isWinner;
        } // exit winnerCheck()

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
                char i = board[subject - 1];
                if (i != 'x' && i != 'o')
                {
                    isValidSquare = true; // Is valid.
                } //exit chosen number

            } //exit 1-9 condition
            
            return isValidSquare;
        } // exit validSquareChecker()

    } // exit class Program
} // exit namespace
