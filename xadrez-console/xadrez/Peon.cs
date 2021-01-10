using System;
using tabuleiro;

namespace xadrez
{
    class Peon : Piece
    {
        private ChessMatch match;

        public Peon(Chessboard board, Color color, ChessMatch match) : base(board, color)
        {
            this.match = match;
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

                // #En Passant
                if (position.line == 3)
                {
                    Position left = new Position(position.line, position.column - 1);
                    if (board.isValid(left) && hasEnemy(left) && board.piece(left) == match.enPassantVulnerable)
                        m[left.line - 1, left.column] = true;

                    Position right = new Position(position.line, position.column + 1);
                    if (board.isValid(right) && hasEnemy(right) && board.piece(right) == match.enPassantVulnerable)
                        m[right.line - 1, right.column] = true;
                }
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

                // #En Passant
                if (position.line == 4)
                {
                    Position left = new Position(position.line, position.column - 1);
                    if (board.isValid(left) && hasEnemy(left) && board.piece(left) == match.enPassantVulnerable)
                        m[left.line + 1, left.column] = true;

                    Position right = new Position(position.line, position.column + 1);
                    if (board.isValid(right) && hasEnemy(right) && board.piece(right) == match.enPassantVulnerable)
                        m[right.line + 1, right.column] = true;
                }
            }

            return m;
        }
    }
}
