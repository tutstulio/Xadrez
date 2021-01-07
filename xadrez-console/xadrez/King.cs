using System;
using tabuleiro;

namespace xadrez
{
    class King : Piece
    {
        public King(Chessboard board, Color color) : base(board, color)
        {
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

            return m;
        }
    }
}
