using System;
using tabuleiro;

namespace xadrez
{
    class King : Piece
    {
        public King(Chessboard board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
