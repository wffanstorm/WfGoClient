using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfGoClient
{
    class QiPuModul
    {
        public QiPuBoard board;

        public QiPuModul()
        {
            board = new QiPuBoard();
        }
        public QiPuModul(Board b)
        {
            board = new QiPuBoard(b);
            
        }
    }
}
