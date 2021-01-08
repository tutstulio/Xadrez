using tabuleiro;

namespace xadrez
{
    class Horse : Piece
    {
        public Horse(Chessboard board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "C";
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
            pos.defineValues(position.line - 1, position.column - 2);
            if (board.isValid(pos) && canMove(pos))
                m[pos.line, pos.column] = true;

            pos.defineValues(position.line - 2, position.column - 1);
            if (board.isValid(pos) && canMove(pos))
                m[pos.line, pos.column] = true;

            //Up and Right
            pos.defineValues(position.line - 1, position.column + 2);
            if (board.isValid(pos) && canMove(pos))
                m[pos.line, pos.column] = true;

            pos.defineValues(position.line - 2, position.column + 1);
            if (board.isValid(pos) && canMove(pos))
                m[pos.line, pos.column] = true;

            //Down and Left
            pos.defineValues(position.line + 1, position.column - 2);
            if (board.isValid(pos) && canMove(pos))
                m[pos.line, pos.column] = true;

            pos.defineValues(position.line + 2, position.column - 1);
            if (board.isValid(pos) && canMove(pos))
                m[pos.line, pos.column] = true;

            //Down and Right
            pos.defineValues(position.line + 1, position.column + 2);
            if (board.isValid(pos) && canMove(pos))
                m[pos.line, pos.column] = true;

            pos.defineValues(position.line + 2, position.column + 1);
            if (board.isValid(pos) && canMove(pos))
                m[pos.line, pos.column] = true;

            return m;
        }
    }
}
