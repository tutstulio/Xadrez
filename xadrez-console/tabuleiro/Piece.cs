namespace tabuleiro
{
    class Piece
    {
        public Position pos { get; set; }
        public Color color { get; protected set; }
        public int moveNum { get; protected set; }
        public Chessboard board { get; protected set; }

        public Piece(Chessboard board, Color color)
        {
            pos = null;
            this.color = color;
            this.board = board;
            moveNum = 0;
        }
    }
}
