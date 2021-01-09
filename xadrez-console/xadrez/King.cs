using System;
using tabuleiro;

namespace xadrez
{
    class King : Piece
    {
        private ChessMatch match;

        public King(Chessboard board, Color color, ChessMatch match) : base(board, color)
        {
            this.match = match;
        }

        public override string ToString()
        {
            return "R";
        }

        private bool canMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.color != this.color;
        }

        private bool towerCastlingTest(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p is Tower && p.color == color && p.moveNum == 0;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] m = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);

            //Up
            pos.defineValues(position.line - 1, position.column);
            if (board.isValid(pos) && canMove(pos))
                m[pos.line, pos.column] = true;

            //Down
            pos.defineValues(position.line + 1, position.column);
            if (board.isValid(pos) && canMove(pos))
                m[pos.line, pos.column] = true;

            //Left
            pos.defineValues(position.line, position.column - 1);
            if (board.isValid(pos) && canMove(pos))
                m[pos.line, pos.column] = true;

            //Right
            pos.defineValues(position.line, position.column + 1);
            if (board.isValid(pos) && canMove(pos))
                m[pos.line, pos.column] = true;

            //Up and Left
            pos.defineValues(position.line - 1, position.column - 1);
            if (board.isValid(pos) && canMove(pos))
                m[pos.line, pos.column] = true;

            //Up and Right
            pos.defineValues(position.line - 1, position.column + 1);
            if (board.isValid(pos) && canMove(pos))
                m[pos.line, pos.column] = true;

            //Down and Left
            pos.defineValues(position.line + 1, position.column - 1);
            if (board.isValid(pos) && canMove(pos))
                m[pos.line, pos.column] = true;

            //Down and Right
            pos.defineValues(position.line + 1, position.column + 1);
            if (board.isValid(pos) && canMove(pos))
                m[pos.line, pos.column] = true;

            // #Jogada Especial - Roque
            if (moveNum == 0 && !match.check)
            {
                // Roque Pequeno
                Position towerPos1 = new Position(position.line, position.column + 3);
                if (towerCastlingTest(towerPos1))
                {
                    Position pos1 = new Position(position.line, position.column + 1);
                    Position pos2 = new Position(position.line, position.column + 2);
                    if (board.piece(pos1) == null && board.piece(pos2) == null)
                        m[position.line, position.column + 2] = true;
                }

                // Roque Grande
                Position towerPos2 = new Position(position.line, position.column - 4);
                if (towerCastlingTest(towerPos2))
                {
                    Position pos1 = new Position(position.line, position.column - 1);
                    Position pos2 = new Position(position.line, position.column - 2);
                    Position pos3 = new Position(position.line, position.column - 3);
                    if (board.piece(pos1) == null && board.piece(pos2) == null && board.piece(pos3) == null)
                        m[position.line, position.column - 2] = true;
                }
            }

            return m;
        }
    }
}
