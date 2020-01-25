using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfGoClient
{
    enum Choose { BlackAndWhite, Black, White, Cross }

    class SingleModul
    {
        public SingleBoard board;
        public Choose choose;

        public SingleModul()
        {
            board = new SingleBoard();
            choose = Choose.BlackAndWhite;
            
        }


    }
}
