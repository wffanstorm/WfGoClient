using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfGoClient
{
    public class AIBoard:Board
    {


        public override void Draw(Graphics gr)
        {
            DrawToBmp();
            base.Draw(gr);
        }

        public override void Regret()
        {
            if (number == 0)
            {
                return;
            }
            if (matrixlist.Count > 1)
            {
                matrixlist.RemoveAt(matrixlist.Count - 1);
            }

            number--;
        }


    }
}
