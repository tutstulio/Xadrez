using System;
using tabuleiro;

namespace xadrez
{
    class Queen : Piece
    {
        public Queen(Chessboard board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "D";
        }

        private bool canMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] m = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);

            //Up and Left
            pos.defineValues(position.line - 1, position.column - 1);
            while (board.isValid(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                    break;
                pos.defineValues(pos.line - 1, pos.column - 1);
            }

            //Up and Right
            pos.defineValues(position.line - 1, position.column + 1);
            while (board.isValid(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                    break;
                pos.defineValues(pos.line - 1, pos.column + 1);
            }

            //Down and Left
            pos.defineValues(position.line + 1, position.column - 1);
            while (board.isValid(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                    break;
                pos.defineValues(pos.line + 1, pos.column - 1);
            }

            //Down and Right
            pos.defineValues(position.line + 1, position.column + 1);
            while (board.isValid(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                    break;
                pos.defineValues(pos.line + 1, pos.column + 1);
            }

            //Up
            pos.defineValues(position.line - 1, position.column);
            while (board.isValid(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color)
                    break;
                pos.line -= 1;
            }

            //Down
            pos.defineValues(position.line + 1, position.column);
            while (board.isValid(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color)
                    break;
                pos.line += 1;
            }

            //Left
            pos.defineValues(position.line, position.column - 1);
            while (board.isValid(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color)
                    break;
                pos.column -= 1;
            }

            //Right
            pos.defineValues(position.line, position.column + 1);
            while (board.isValid(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color)
                    break;
                pos.column += 1;
            }

            return m;
        }
    }
}
