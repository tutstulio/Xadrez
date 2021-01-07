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
                    try
                    {
                        Console.Clear();
                        Screen.printBoard(match.board);

                        Console.WriteLine("\nTurno: " + match.turn);
                        Console.WriteLine("Aguardando a jogada: " + match.currentPlayer);

                        Console.Write("\nOrigem: ");
                        Position origin = Screen.readChessPosition().toPosition();
                        match.checkOriginPosition(origin);

                        bool[,] possiblePositions = match.board.piece(origin).possibleMovements();

                        Console.Clear();
                        Screen.printBoard(match.board, possiblePositions);

                        Console.Write("\nDestino: ");
                        Position destiny = Screen.readChessPosition().toPosition();
                        match.checkDestinyPosition(origin, destiny);

                        match.releaseTurn(origin, destiny);
                    }
                    catch (ChessboardException ce)
                    {
                        Console.WriteLine(ce.Message);
                        Console.ReadLine();
                    }
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
