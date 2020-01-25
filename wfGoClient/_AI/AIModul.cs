using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfGoClient
{
    public class AIModul
    {
        private bool humanIsBlack;
        private bool AIisBlack;
        private int level;
        private PictureBox pic;

        public AIBoard board;
        public AIPlayer AIplayer;
        public HumanPlayer humanplayer;

        public AIModul(PictureBox pic)
        {
            board = new AIBoard();
            this.pic = pic;
        }

        public void InitSet(string strColor, string strLevel)
        {
            if (strColor == "执黑")
            {
                humanIsBlack = true;
                AIisBlack = false;
            }
            else
            {
                humanIsBlack = false;
                AIisBlack = true;
            }

            level = Convert.ToInt32(strLevel);


            humanplayer = new HumanPlayer(board, humanIsBlack);
            AIplayer = new AIPlayer(board, AIisBlack,humanplayer,pic,level);
            if (humanIsBlack == true)
            {
                humanplayer.CanSetPiece = true;
                AIplayer.CanSetPiece = false;
            }
            else
            {
                humanplayer.CanSetPiece = false;
                AIplayer.CanSetPiece = true;
                AIplayer.ThinkAndGo();
            }

        }


    }
}
