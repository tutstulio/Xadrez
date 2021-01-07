using System;
using tabuleiro;

namespace xadrez
{
    class ChessMatch
    {
        public Chessboard board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool end { get; private set; }

        public ChessMatch()
        {
            board = new Chessboard(8, 8);
            turn = 1;
            currentPlayer = Color.Branca;
            end = false;
            putPieces();
        }

        public void move(Position origin, Position destiny)
        {
            Piece p = board.removePiece(origin);
            p.incrementMovement();
            Piece capturePiece = board.removePiece(destiny);
            board.putPiece(p, destiny);
        }

        private void putPieces()
        {
            board.putPiece(new Tower(board, Color.Branca), new ChessPosition('c', 1).toPosition());
            board.putPiece(new Tower(board, Color.Branca), new ChessPosition('c', 2).toPosition());
            board.putPiece(new King(board, Color.Branca), new ChessPosition('d', 1).toPosition());
            board.putPiece(new Tower(board, Color.Branca), new ChessPosition('d', 2).toPosition());
            board.putPiece(new Tower(board, Color.Branca), new ChessPosition('e', 1).toPosition());
            board.putPiece(new Tower(board, Color.Branca), new ChessPosition('e', 2).toPosition());

            board.putPiece(new Tower(board, Color.Preta), new ChessPosition('c', 8).toPosition());
            board.putPiece(new Tower(board, Color.Preta), new ChessPosition('c', 7).toPosition());
            board.putPiece(new King(board, Color.Preta), new ChessPosition('d', 8).toPosition());
            board.putPiece(new Tower(board, Color.Preta), new ChessPosition('d', 7).toPosition());
            board.putPiece(new Tower(board, Color.Preta), new ChessPosition('e', 8).toPosition());
            board.putPiece(new Tower(board, Color.Preta), new ChessPosition('e', 7).toPosition());
        }

        public void releaseTurn(Position origin, Position destiny)
        {
            move(origin, destiny);
            turn++;
            changePlayer();
        }

        private void changePlayer()
        {
            if (currentPlayer == Color.Branca)
                currentPlayer = Color.Preta;
            else
                currentPlayer = Color.Branca;
        }

        public void checkOriginPosition(Position pos)
        {
            if (board.piece(pos) == null)
                throw new ChessboardException("Não existe peça na posição de origem escolhida!");

            if (currentPlayer != board.piece(pos).color)
                throw new ChessboardException("A peça de origem escolhida não é sua!");

            if (!board.piece(pos).existPossibleMovements())
                throw new ChessboardException("Não há movimentos possíveis para a peça de origem escolhida!");
        }

        public void checkDestinyPosition(Position origin, Position destiny)
        {
            if (board.piece(origin).canMoveTo(destiny))
                throw new ChessboardException("Posição de destino inválida!");
        }
    }
}
