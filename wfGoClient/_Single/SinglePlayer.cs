using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace wfGoClient
{
    class SinglePlayer:Player
    {
        

        public SinglePlayer()
        {

        }

        public bool SetCross(SingleBoard b,int x,int y)
        {
            return b.SetCross(x, y);
        }

        public bool RemoveCross(SingleBoard b, int x, int y)
        {
            return b.RemoveCross(x, y);
        }

        public void Regret()
        {

        }
    }
}
