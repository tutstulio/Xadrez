using System;
using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    class ChessMatch
    {
        public Chessboard board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool end { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> capturedPieces;

        public ChessMatch()
        {
            board = new Chessboard(8, 8);
            turn = 1;
            currentPlayer = Color.Branca;
            end = false;
            pieces = new HashSet<Piece>();
            capturedPieces = new HashSet<Piece>();
            putPieces();
        }

        public void move(Position origin, Position destiny)
        {
            Piece p = board.removePiece(origin);
            p.incrementMovement();
            Piece capturedPiece = board.removePiece(destiny);
            board.putPiece(p, destiny);
            if (capturedPiece != null)
                capturedPieces.Add(capturedPiece);
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

        public HashSet<Piece> getCapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece p in capturedPieces)
                if (p.color == color)
                    aux.Add(p);
            return aux;
        }

        public HashSet<Piece> getPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece p in pieces)
                if (p.color == color)
                    aux.Add(p);
            aux.ExceptWith(getCapturedPieces(color));
            return aux;
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
            if (!board.piece(origin).canMoveTo(destiny))
                throw new ChessboardException("Posição de destino inválida!");
        }

        public void putNewPiece(char column, int line, Piece piece)
        {
            board.putPiece(piece, new ChessPosition(column, line).toPosition());
            pieces.Add(piece);
        }

        private void putPieces()
        {
            putNewPiece('c', 1, new Tower(board, Color.Branca));
            putNewPiece('c', 2, new Tower(board, Color.Branca));
            putNewPiece('d', 1, new King(board, Color.Branca));
            putNewPiece('d', 2, new Tower(board, Color.Branca));
            putNewPiece('e', 1, new Tower(board, Color.Branca));
            putNewPiece('e', 2, new Tower(board, Color.Branca));

            putNewPiece('c', 8, new Tower(board, Color.Preta));
            putNewPiece('c', 7, new Tower(board, Color.Preta));
            putNewPiece('d', 8, new King(board, Color.Preta));
            putNewPiece('d', 7, new Tower(board, Color.Preta));
            putNewPiece('e', 8, new Tower(board, Color.Preta));
            putNewPiece('e', 7, new Tower(board, Color.Preta));
        }
    }
}
