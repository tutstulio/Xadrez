using System;
using tabuleiro;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Chessboard board = new Chessboard(8, 8);

            Screen.printBoard(board);

            Console.ReadKey();
        }
    }
}
