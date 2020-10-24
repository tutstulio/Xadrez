using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Chessboard board = new Chessboard(8, 8);

            board.putPiece(new Tower(board, Color.Black), new Position(0, 0));
            board.putPiece(new Tower(board, Color.Black), new Position(6, 7));
            board.putPiece(new King(board, Color.Black), new Position(2, 4));

            Screen.printBoard(board);

            Console.ReadKey();
        }
    }
}
