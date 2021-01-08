using System;
using tabuleiro;

namespace xadrez
{
    class Peon : Piece
    {
        public Peon(Chessboard board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool hasEnemy(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p.color != color;
        }

        private bool isFree(Position pos)
        {
            return board.piece(pos) == null;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] m = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);

            if (color == Color.Branca)
            {
                pos.defineValues(position.line - 1, position.column);
                if (board.isValid(pos) && isFree(pos))
                    m[pos.line, pos.column] = true;

                pos.defineValues(position.line - 2, position.column);
                Position pos2 = new Position(position.line - 1, position.column);
                if (board.isValid(pos2) && isFree(pos2) && board.isValid(pos) && isFree(pos) && moveNum == 0)
                    m[pos.line, pos.column] = true;

                pos.defineValues(position.line - 1, position.column - 1);
                if (board.isValid(pos) && hasEnemy(pos))
                    m[pos.line, pos.column] = true;

                pos.defineValues(position.line - 1, position.column + 1);
                if (board.isValid(pos) && hasEnemy(pos))
                    m[pos.line, pos.column] = true;
            }
            else
            {
                pos.defineValues(position.line + 1, position.column);
                if (board.isValid(pos) && isFree(pos))
                    m[pos.line, pos.column] = true;

                pos.defineValues(position.line + 2, position.column);
                Position pos2 = new Position(position.line + 1, position.column);
                if (board.isValid(pos2) && isFree(pos2) && board.isValid(pos) && isFree(pos) && moveNum == 0)
                    m[pos.line, pos.column] = true;

                pos.defineValues(position.line + 1, position.column - 1);
                if (board.isValid(pos) && hasEnemy(pos))
                    m[pos.line, pos.column] = true;

                pos.defineValues(position.line + 1, position.column + 1);
                if (board.isValid(pos) && hasEnemy(pos))
                    m[pos.line, pos.column] = true;
            }

            return m;
        }
    }
}
