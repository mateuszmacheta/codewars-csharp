using System;
using System.Collections.Generic;

public class ConnectFour
{
    private static char[,] board { get; set; }

    static ConnectFour()
    {
        board = new char[6, 7];
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                board[j, i] = '0';
            }
        }
    }

    static void drawBoard()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                Console.Write($"{board[i, j]},");
            }
            System.Console.WriteLine();
        }
    }

    private static void makeMove(string move)
    {
        int column = move[0] - 65;
        char player = move[2];
        for (int i = 5; i >= 0; i--)
        {
            if (board[i, column] == '0')
                board[i, column] = player;
        }
    }
    public static string WhoIsWinner(List<string> piecesPositionList)
    {
        ConnectFour.drawBoard();
        foreach (var position in piecesPositionList)
        {
            makeMove(position);
        }
        ConnectFour.drawBoard();
        return "Draw";
    }
}
class Program
{
    static void Main(string[] args)
    {
        List<string> myList = new List<string>()
            {
                "A_Yellow",
                "B_Red",
                "B_Yellow",
                "C_Red",
                "G_Yellow",
                "C_Red",
                "C_Yellow",
                "D_Red",
                "G_Yellow",
                "D_Red",
                "G_Yellow",
                "D_Red",
                "F_Yellow",
                "E_Red",
                "D_Yellow"
            };
        Console.WriteLine(ConnectFour.WhoIsWinner(myList));
    }
}
