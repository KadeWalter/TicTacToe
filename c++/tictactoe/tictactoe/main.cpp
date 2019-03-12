#include <stdio.h>
#include <iostream>
#include <string>

using namespace std;

const int boardRows = 3;
const int boardCols = 3;

const string space = " ";

void PlayMove(string(&board)[boardRows][boardCols], int rowToPlay, int colToPlay, string token)
{
	board[rowToPlay][colToPlay] = token;
}

void PrintBoard(string board[boardRows][boardCols])
{
	for (int i = 0; i < boardRows; i++)
	{
		for (int j = 0; j < boardCols; j++)
		{
			if (j == boardCols - 1)
				cout << board[i][j] << "\n";
			else
				cout << board[i][j] << " | ";
		}
	}
	cout << endl;
}


void PrintWinningMessage(string player)
{
	cout << endl;
	cout << "Congratulations Player " << player << " own the game!" << endl;
}

bool CheckDiagonals(string board[boardRows][boardCols], string player)
{
	bool winner = true;
	// check diagonal top left to bottom right
	for (int row = 0, col = 0; row < boardRows && col < boardCols; row++, col++)
	{
		if (board[row][col] != player || board[row][col] == space)
		{
			winner = false;
			break;
		}
	}
	if (winner)
		return true;

	winner = true;
	// check diagonal top left to bottom right
	for (int row = 0, col = boardCols - 1; row < boardRows && col >= 0; row++, col--)
	{
		if (board[row][col] != player || board[row][col] == space)
		{
			winner = false;
			break;
		}
	}
	if (winner)
		return true;

	return false;
}

bool CheckVerticals(string board[boardRows][boardCols], string player)
{
	for (int col = 0; col < boardRows; col++)
	{
		bool winner = true;
		for (int row = 0; row < boardCols; row++)
		{
			if (board[row][col] != player || board[row][col] == space)
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

bool CheckHorizontal(string board[boardRows][boardCols], string player)
{
	for (int row = 0; row < boardRows; row++)
	{
		bool winner = true;
		for (int col = 0; col < boardCols; col++)
		{
			if (board[row][col] != player || board[row][col] == space)
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

bool WinnerFound(string board[boardRows][boardCols], string player)
{
	if (CheckDiagonals(board, player) || CheckVerticals(board, player) || CheckHorizontal(board, player))
		return true;
	return false;
}

int main()
{
	string board[boardRows][boardCols];

	// initialize the game board
	for (int i = 0; i < boardRows; i++)
	{
		for (int j = 0; j < boardCols; j++)
		{
			board[i][j] = space;
		}
	}

	bool winner = false;
	string player = "X"; // starting player

	cout << "Welcome to Tic Tac Toe. X starts first. \nIf you would like to quit, type -1 when asked for row or column number.\n" << endl;

	while (!winner)
	{
		// get move
		cout << "Enter the row where you want to play: " << endl;
		int rowToPlay;
		cin >> rowToPlay;
		cout << "Enter the column where you want to play: " << endl;
		int colToPlay;
		cin >> colToPlay;
		if (rowToPlay == -1 || colToPlay == -1)
		{
			winner = true;
			break;
		}
		if (rowToPlay < 0 || rowToPlay >= boardRows || colToPlay < 0 || colToPlay >= boardCols)
			cout << "Invalid position. Please try again." << endl;
		else if (board[rowToPlay][colToPlay] != space)
			cout << "Someone has already played there. Please try again." << endl;
		else
		{
			// play the move
			PlayMove(board, rowToPlay, colToPlay, player);
			// print the board
			PrintBoard(board);
			// check for a winner
			winner = WinnerFound(board, player);
			// change turn
			if (winner)
				PrintWinningMessage(player);

			player = (player == "X") ? "O" : "X";
		}
	}
	cout << endl << "Thanks for playing. Type -1 to exit." << endl;
	void* m;
	cin >> m;
}

