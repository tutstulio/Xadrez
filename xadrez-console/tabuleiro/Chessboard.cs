namespace tabuleiro
{
    class Chessboard
    {
        public int lines { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

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

        public Piece piece(Position pos)
        {
            return pieces[pos.line, pos.column];
        }

        public void putPiece(Piece p, Position pos)
        {
            if (hasPiece(pos))
                throw new ChessboardException("Já existe uma peça nessa posição");
            pieces[pos.line, pos.column] = p;
            p.position = pos;
        }

        public Piece removePiece(Position pos)
        {
            if (piece(pos) == null)
                return null;
            Piece aux = piece(pos);
            aux.position = null;
            pieces[pos.line, pos.column] = null;
            return aux;
        }

        public bool hasPiece(Position pos)
        {
            validPosition(pos);
            return piece(pos) != null;
        }

        public void validPosition(Position pos)
        {
            if (!isValid(pos))
                throw new ChessboardException("Posição inválida!");
        }

        public bool isValid(Position pos)
        {
            if (pos.line < 0 || pos.line >= lines || pos.column < 0 || pos.column >= columns)
                return false;
            return true;
        }
    }
}
