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
        public bool check { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> capturedPieces;

        public ChessMatch()
        {
            board = new Chessboard(8, 8);
            turn = 1;
            currentPlayer = Color.Branca;
            end = false;
            check = false;
            pieces = new HashSet<Piece>();
            capturedPieces = new HashSet<Piece>();
            putPieces();
        }

        public Piece move(Position origin, Position destiny)
        {
            Piece p = board.removePiece(origin);
            p.incrementMovement();
            Piece capturedPiece = board.removePiece(destiny);
            board.putPiece(p, destiny);
            if (capturedPiece != null)
                capturedPieces.Add(capturedPiece);

            return capturedPiece;
        }

        public void undoMovement(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece p = board.removePiece(destiny);
            p.decrementMovement();
            if (capturedPiece != null)
            {
                board.putPiece(capturedPiece, destiny);
                capturedPieces.Remove(capturedPiece);
            }
            board.putPiece(p, origin);
        }

        public void releaseTurn(Position origin, Position destiny)
        {
            Piece capturedPiece = move(origin, destiny);

            if (isCheck(currentPlayer))
            {
                undoMovement(origin, destiny, capturedPiece);
                throw new ChessboardException("Não é possível se colocar em xeque!");
            }

            if (isCheck(adversary(currentPlayer)))
                check = true;
            else
                check = false;

            if (isCheckMate(adversary(currentPlayer)))
                end = true;
            else
            {
                changePlayer();
                turn++;
            }
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

        private Color adversary(Color color)
        {
            if (color == Color.Branca)
                return Color.Preta;
            else
                return Color.Branca;
        }

        private Piece getKing(Color color)
        {
            foreach (Piece p in getPieces(color))
                if (p is King)
                    return p;
            return null;
        }

        public bool isCheck(Color color)
        {
            Piece r = getKing(color);
            if (r == null)
                throw new ChessboardException("Não tem rei da cor" + color + " no tabuleiro!");

            foreach (Piece p in getPieces(adversary(color)))
            {
                bool[,] m = p.possibleMovements();
                if (m[r.position.line, r.position.column])
                    return true;
            }
            return false;
        }

        public bool isCheckMate(Color color)
        {
            if (!isCheck(color))
                return false;

            foreach (Piece p in getPieces(color))
            {
                bool[,] m = p.possibleMovements();
                for (int i = 0; i < board.lines; i++)
                    for (int j = 0; j < board.columns; j++)
                        if (m[i, j])
                        {
                            Position origin = p.position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = move(origin, destiny);
                            bool testCheck = isCheck(color);
                            undoMovement(origin, destiny, capturedPiece);
                            if (!testCheck)
                                return false;
                        }
            }
            return true;
        }

        public void putNewPiece(char column, int line, Piece piece)
        {
            board.putPiece(piece, new ChessPosition(column, line).toPosition());
            pieces.Add(piece);
        }

        private void putPieces()
        {
            putNewPiece('c', 1, new Tower(board, Color.Branca));
            putNewPiece('d', 1, new King(board, Color.Branca));
            putNewPiece('h', 7, new Tower(board, Color.Branca));

            putNewPiece('a', 8, new King(board, Color.Preta));
            putNewPiece('b', 8, new Tower(board, Color.Preta));
        }
    }
}
