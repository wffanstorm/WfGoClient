using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfGoClient
{
    public abstract class Player
    {
        public bool SetBlackPiece(Board board,int x,int y)
        {
            return board.SetBlackPiece(x, y);
        }
        public bool SetWhitePiece(Board board, int x, int y)
        {
            return board.SetWhitePiece(x, y);
        }
        public bool RemovePiece(Board board,int x,int y)
        {
            return board.RemovePiece(x, y);
        }

    }
}
