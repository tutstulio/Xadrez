using System;
using tabuleiro;

namespace xadrez
{
    class Tower : Piece
    {
        public Tower(Chessboard board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "T";
        }

        private bool canMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.color != this.color;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] m = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);

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