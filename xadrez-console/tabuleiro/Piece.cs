namespace tabuleiro
{
    class Piece
    {
        public Position pos { get; set; }
        public Color color { get; protected set; }
        public int moveNum { get; protected set; }
        public Chessboard board { get; protected set; }

        public Piece(Position pos, Color color, Chessboard board)
        {
            this.pos = pos;
            this.color = color;
            this.board = board;
            moveNum = 0;
        }
    }
}
