using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfGoClient
{
    public class HumanPlayer : Player
    {
        private AIBoard board;
        private bool isblack;

        public bool CanSetPiece;

        public HumanPlayer(AIBoard b,bool isblack)
        {
            this.board = b;
            this.isblack = isblack;

        }

        public bool SetPiece(int x,int y)
        {
            if(isblack==true)
            {
                return board.SetBlackPiece(x, y);
            }
            else
            {
                return board.SetWhitePiece(x, y);
            }
        }


    }
}
