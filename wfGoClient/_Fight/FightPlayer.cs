using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfGoClient
{
    public class FightPlayer:Player
    {
        public string name;
        public bool isblack;
        public int roomnumber;


        public FightPlayer(string Name)
        {
            name = Name;
            roomnumber = 0;
        }

        public void Regret(Board board)
        {
            board.Regret();
            board.Regret();
        }

    }
}
