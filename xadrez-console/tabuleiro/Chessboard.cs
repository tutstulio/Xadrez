﻿namespace tabuleiro
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
    }
}