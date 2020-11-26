using System;
using System.Linq;

namespace tic_tac_toe
{
    public class TTTSolver
    {
        public TTTSolver()
        {
            Move[0] = -1; Move[1] = -1;
        }
        private int[][] Board = new int[3][];
        private int Player { get; set; }
        private int Opponent { get; set; }
        private int[] Move = new int[2];
        public int[] TurnMethod(int[][] board, int player)
        {
            Board = board.Clone() as int[][];
            Player = player;
            Opponent = player == 1 ? 2 : 1;

            checkWin();

            if (Move[0] != -1)
                return Move;

            return Move;
        }

        private void checkWin()
        {
            int count;

            // check rows
            for (int i = 0; i < 3; i++)
            {
                count = Board[i].Count(e => e == Player);
                if (count == 2)
                {
                    Move[1] = i;
                    Move[0] = Array.IndexOf(Board[i], 0);
                    return;
                }
            }
            // check columns
            for (int i = 0; i < 3; i++)
            {
                count = Board.
            }
        }

    }

    public static class Print2D
    {
        public static void PrintArr(int[][] arr)
        {
            foreach (var row in arr)
            {
                foreach (var item in row)
                {
                    Console.Write(item + ' ');
                }
                System.Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solver = new TTTSolver();
            var state = new int[][]
            {
                new int[] { 1, 0, 1 },
                new int[] { 0, 0, 0 },
                new int[] { 1, 0, 1 }
            };
            Print2D.PrintArr(state);
            Console.WriteLine(string.Join(',', solver.TurnMethod(state, 1)));
        }
    }
}
