namespace tabuleiro
{
    abstract class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int moveNum { get; protected set; }
        public Chessboard board { get; protected set; }

        public Piece(Chessboard board, Color color)
        {
            position = null;
            this.color = color;
            this.board = board;
            moveNum = 0;
        }

        public void incrementMovement()
        {
            moveNum++;
        }

        public void decrementMovement()
        {
            moveNum--;
        }

        public bool existPossibleMovements()
        {
            bool[,] m = possibleMovements();
            for (int i = 0; i < board.lines; i++)
                for (int j = 0; j < board.columns; j++)
                    if (m[i, j])
                        return true;
            return false;
        }

        public bool canMoveTo(Position pos)
        {
            return possibleMovements()[pos.line, pos.column];
        }

        public abstract bool[,] possibleMovements();
    }
}
