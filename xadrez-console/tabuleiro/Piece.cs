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

        public abstract bool[,] possibleMovements();
    }
}
