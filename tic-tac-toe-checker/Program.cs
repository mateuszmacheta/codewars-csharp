using System;
using System.Linq;

namespace tic_tac_toe_checker
{
	public class TicTacToe
	{
		public int IsSolved(int[,] board)
		{
			int winResult;
			for (int i = 0; i < 9; i++)
				if (board[i / 3, i % 3] == 2)
					board[i / 3, i % 3] = -1;

			if ((winResult = checkRows(board)) != -1)
				return winResult;

			if ((winResult = checkCols(board)) != -1)
				return winResult;

			if ((winResult = checkDiagonals(board)) != -1)
				return winResult;

			return board.Cast<int>().Any(x => x == 0) ? -1 : 0;
		}

		private int checkRows(int[,] board)
		{
			int sum = 0;
			for (int y = 0; y < 3; y++)
			{
				sum = 0;
				for (int x = 0; x < 3; x++)
				{
					sum += board[y, x];
				}
				if (Math.Abs(sum) == 3)
					return (sum == 3 ? 1 : 2);
			}
			return -1;
		}

		private int checkCols(int[,] board)
		{
			int sum = 0;
			for (int x = 0; x < 3; x++)
			{
				sum = 0;
				for (int y = 0; y < 3; y++)
				{
					sum += board[y, x];
				}
				if (Math.Abs(sum) == 3)
					return (sum == 3 ? 1 : 2);
			}
			return -1;
		}

		private int checkDiagonals(int[,] board)
		{
			int sum = 0;
			for (int i = 0; i < 3; i++) // NW - SE diagonal
				sum += board[i, i];

			if (Math.Abs(sum) == 3)
				return (sum == 3 ? 1 : 2);

			sum = 0;
			for (int i = 0; i < 3; i++) // NE - SW diagonal
				sum += board[i, 2 - i];

			if (Math.Abs(sum) == 3)
				return (sum == 3 ? 1 : 2);

			return -1;
		}


	}
	class Program
	{
		static void Main(string[] args)
		{
			int[,] board = new int[,] { { 2, 1, 1 }, { 0, 1, 1 }, { 2, 2, 2 } };
			TicTacToe checker = new TicTacToe();
			System.Console.WriteLine(checker.IsSolved(board));
		}
	}
}
