using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = 3;
            int cols = 3;
            string[,] board = new string[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    board[i, j] = " ";
                }
            }

            bool winner = false;
            string player = "X";

            Console.WriteLine("\nWelcome to Tic Tac Toe. X starts first. \nIf you would like to quit, type QUIT when asked for a row or column number.\n");
            while (!winner)
            {
                // get row to play from user
                Console.WriteLine("Enter the row where you want to play: ");
                string rowInput = Console.ReadLine();
                if (rowInput == "QUIT")
                {
                    winner = true;
                    break;
                }
                int rowToPlay = Convert.ToInt32(rowInput);

                // get col to play from user
                Console.WriteLine("Enter the column where you want to play: ");
                string colInput = Console.ReadLine();
                if (rowInput == "QUIT")
                {
                    winner = true;
                    break;
                }
                int colToPlay = Convert.ToInt32(colInput);

                // check if valid position
                if (rowToPlay >= board.GetLength(0) || rowToPlay < 0 || colToPlay > board.GetLength(1) || colToPlay < 0)
                    Console.WriteLine("Invalid position. Please try again.");
                else if (board[rowToPlay, colToPlay] != " ")
                {
                    Console.WriteLine("Someone has already played there. Please try again.");
                    PrintBoard(board);
                }
                else
                {
                    PlayMove(board, rowToPlay, colToPlay, player);
                    winner = FindWinner(board, player); // check if the player won 

                    PrintBoard(board);

                    if (winner)
                        PrintWinningMessage(player);

                    player = (player == "X") ? "O" : "X"; // Change player
                }
            }
        }

        private static string[,] PlayMove(string[,] board, int row, int col, string player)
        {
            board[row, col] = player;
            return board;
        }

        private static bool FindWinner(string[,] board, string player)
        {
            if (CheckDiagonals(board, player) || CheckVerticals(board, player) || CheckHorizontals(board, player))
                return true;
            return false;
        }

        private static bool CheckDiagonals(string[,] board, string player)
        {
            bool winner = true;
            // check diagonal from top left to bottom right
            for (int row = 0, col = 0; row < board.GetLength(0) && col < board.GetLength(1); row++, col++)
            {
                if (board[row, col] != player || board[row, col] == " ")
                {
                    winner = false;
                    break;
                }
            }
            if (winner)
                return true;

            // check diagonal from top right to bottom left
            winner = true;
            for (int row = 0, col = board.GetLength(1) - 1; row < board.GetLength(0) && col >= 0; row++, col--)
            {
                if (board[row, col] != player || board[row, col] == " ")
                {
                    winner = false;
                    break;
                }
            }
            if (winner)
                return true;

            return false;
        }

        private static bool CheckVerticals(string[,] board, string player)
        {
            for (int col = 0; col < board.GetLength(1); col++)
            {
                bool winner = true;
                for (int row = 0; row < board.GetLength(0); row++)
                {
                    if (board[row, col] != player || board[row, col] == " ")
                    {
                        winner = false;
                        break;
                    }
                }
                if (winner)
                    return true;
            }
            return false;
        }

        private static bool CheckHorizontals(string[,] board, string player)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                bool winner = true;
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] != player || board[row, col] == " ")
                    {
                        winner = false;
                        break;
                    }
                }
                if (winner)
                    return true;
            }
            return false;
        }

        private static void PrintWinningMessage(string player)
        {
            Console.WriteLine("\nCongratulations! Player " + player + " won the game!");
        }
        private static void PrintBoard(string[,] board)
        {
            Console.WriteLine("   0 | 1 | 2 ");
            for (int row = 0; row < board.GetLength(0); row++)
            {
                Console.Write(row + ": ");
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (col == board.GetLength(1) - 1)
                        Console.Write(board[row, col] + "\n");
                    else
                        Console.Write(board[row, col] + " | ");
                }
            }
        }
    }
}
