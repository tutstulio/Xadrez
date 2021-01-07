using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();

                while(!match.end)
                {
                    Console.Clear();
                    Screen.printBoard(match.board);

                    Console.Write("\nOrigem: ");
                    Position origin = Screen.readChessPosition().toPosition();

                    bool[,] possiblePositions = match.board.piece(origin).possibleMovements();

                    Console.Clear();
                    Screen.printBoard(match.board, possiblePositions);

                    Console.Write("\nDestino: ");
                    Position destiny = Screen.readChessPosition().toPosition();

                    match.move(origin, destiny);
                }
            }
            catch (ChessboardException ce)
            {
                Console.WriteLine(ce.Message);
            }

            Console.ReadKey();
        }
    }
}
