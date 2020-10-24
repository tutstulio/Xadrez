namespace tabuleiro
{
    class Chessboard
    {
        public int lines { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces { get; set; }

        public Chessboard(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            pieces = new Piece[lines, columns];
        }

        public Piece piece(int i, int j)
        {
            return pieces[i, j];
        }

        public void putPiece(Piece p, Position pos)
        {
            pieces[pos.line, pos.column] = p;
            p.pos = pos;
        }
    }
}
