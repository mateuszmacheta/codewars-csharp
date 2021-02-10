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

        private static int[][] Board = new int[3][];
        private static int Player { get; set; }
        private static int Opponent { get; set; }
        private static int[] Move = new int[2];
        public static int[] TurnMethod(int[][] board, int player)
        {
            Board = board.Clone() as int[][];
            Player = player;
            Opponent = player == 1 ? 2 : 1;

            // make winning move
            checkWin(Player);

            if (Move[0] != -1)
                return Move;

            // block opponent's winning move
            checkWin(Opponent);

            if (Move[0] != -1)
                return Move;

            // check if center empty
            if (Board[1][1] == 0)
            {
                Move[0] = 1;
                Move[1] = 1;
                return Move;
            }


            // play corner
            playCorner();
            if (Move[0] != -1)
                return Move;

            return Move;
        }

        private static void checkWin(int player)
        {
            int opponent = player == 1 ? 2 : 1;
            int count;
            int oCount; // opponent's symbols count

            // -- check rows
            for (int i = 0; i < 3; i++)
            {
                count = Board[i].Count(e => e == player);
                oCount = Board[i].Count(e => e == opponent);

                if (count == 2 && oCount == 0)
                {
                    Move[0] = Array.IndexOf(Board[i], 0);
                    Move[1] = i;
                    return;
                }
            }
            // -- check columns
            for (int i = 0; i < 3; i++)
            {
                count = 0; oCount = 0;
                for (int j = 0; j < 3; j++)
                {
                    count += (Board[j][i] == player ? 1 : 0);
                    oCount += (Board[j][i] == opponent ? 1 : 0);
                }

                if (count == 2 && oCount == 0)
                {
                    Move[0] = i;
                    Move[1] = Array.IndexOf(new int[] { Board[0][i], Board[1][i], Board[2][i] }, 0);
                    return;
                }
            }
            // -- check diagonals

            // first diagonal NW-SE
            count = 0; oCount = 0;
            count += Board[0][0] == player ? 1 : 0;
            count += Board[1][1] == player ? 1 : 0;
            count += Board[2][2] == player ? 1 : 0;

            oCount += Board[0][0] == opponent ? 1 : 0;
            oCount += Board[1][1] == opponent ? 1 : 0;
            oCount += Board[2][2] == opponent ? 1 : 0;

            if (count == 2 && oCount == 0)
            {
                Move[0] = Array.IndexOf(new int[] { Board[0][0], Board[1][1], Board[2][2] }, 0);
                Move[1] = Move[0];
            }

            // second diagonal NE-SW

            count = 0; oCount = 0;
            count += Board[0][2] == player ? 1 : 0;
            count += Board[1][1] == player ? 1 : 0;
            count += Board[2][0] == player ? 1 : 0;

            oCount += Board[0][2] == opponent ? 1 : 0;
            oCount += Board[1][1] == opponent ? 1 : 0;
            oCount += Board[2][0] == opponent ? 1 : 0;

            if (count == 2 && oCount == 0)
            {
                Move[1] = Array.IndexOf(new int[] { Board[0][2], Board[1][1], Board[2][0] }, 0);
                Move[0] = 2 - Move[1];
            }
        }

        private static void playCorner()
        {
            // opposite to opponent

            if (Board[0][0] == Opponent) // NE
            {
                Move[0] = 2;
                Move[1] = 2;
                return;
            }

            if (Board[0][2] == Opponent) // NW
            {
                Move[0] = 0;
                Move[1] = 2;
                return;
            }

            if (Board[2][0] == Opponent) // SW
            {
                Move[0] = 2;
                Move[1] = 0;
                return;
            }

            if (Board[2][2] == Opponent) // SE
            {
                Move[0] = 0;
                Move[1] = 0;
                return;
            }

            // first empty

            if (Board[0][0] == 0) // NE
            {
                Move[0] = 0;
                Move[1] = 0;
                return;
            }

            if (Board[0][2] == 0) // NW
            {
                Move[0] = 2;
                Move[1] = 0;
                return;
            }

            if (Board[2][0] == 0) // SW
            {
                Move[0] = 0;
                Move[1] = 2;
                return;
            }

            if (Board[2][2] == 0) // SE
            {
                Move[0] = 2;
                Move[1] = 2;
                return;
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
                    Console.Write(item.ToString() + ' ');
                }
                System.Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //var solver = new TTTSolver();
            var state = new int[][]
            {
        new int[] { 0, 2, 1 },
        new int[] { 1, 2, 2 },
        new int[] { 2, 1, 1 }
            };
            Print2D.PrintArr(state);
            Console.WriteLine(string.Join(',', TTTSolver.TurnMethod(state, 1)));
        }
    }
}
