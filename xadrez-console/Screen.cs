using System;
using tabuleiro;

namespace xadrez_console
{
    class Screen
    {
        public static void printBoard(Chessboard board)
        {
            for (int i = 0; i < board.lines; i++)
            {
                for (int j = 0; j < board.columns; j++)
                {
                    if (board.piece(i, j) == null)
                        Console.Write("- ");
                    else
                        Console.Write(board.piece(i, j) + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
