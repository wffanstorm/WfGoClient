using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfGoClient
{
    public class FightBoard : Board
    {
        public Matrix nowmatrix;
        public int x;
        public int y;


        public FightBoard()
        {
            nowmatrix = new Matrix();
        }

        public new bool SetBlackPiece(int x, int y)
        {
            bool rst = base.SetBlackPiece(x, y);
            if (rst == true)
            {
                nowmatrix = matrixlist[matrixlist.Count - 1].Copy();
                this.x = x;
                this.y = y;
            }
            return rst;
        }

        public new bool SetWhitePiece(int x, int y)
        {
            bool rst = base.SetWhitePiece(x, y);
            if (rst == true)
            {
                nowmatrix = matrixlist[matrixlist.Count - 1].Copy();
                this.x = x;
                this.y = y;
            }
            return rst;
        }

        public override void Draw(Graphics gr)
        {
            DrawToBmp();
            base.Draw(gr);
        }

        //base.RemovePiece();

    }
}
