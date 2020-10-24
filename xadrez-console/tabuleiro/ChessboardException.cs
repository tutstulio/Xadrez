using System;

namespace tabuleiro
{
    class ChessboardException : Exception
    {
        public ChessboardException(string msg) : base(msg)
        {
        }
    }
}
