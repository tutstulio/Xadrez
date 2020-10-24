using tabuleiro;

namespace xadrez
{
    class ChessPosition
    {
        public int line { get; set; }
        public char column { get; set; }

        public ChessPosition(char column, int line)
        {
            this.line = line;
            this.column = column;
        }

        public Position toPosition()
        {
            return new Position(8 - line, column - 'a');
        }

        public override string ToString()
        {
            return "" + column + line;
        }
    }
}
