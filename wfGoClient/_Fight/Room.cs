using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace wfGoClient
{
    class Room
    {
        public int number;
        public string name;
        public bool state;
        public int playernum;

        public  List<FightPlayer> playerlist;

        private FightBoard board;



        public Room(int number,string name )
        {
            this.number = number;
            this.name = name;
            state = false;  

        }


        public string ToJson()
        {
            string str = JsonConvert.SerializeObject(this);
            return str;
        }

        public static Room Parse(string jsonstr)
        {
            Room room = JsonConvert.DeserializeObject<Room>(jsonstr);
            return room;
        }

        public void AddPlayer(FightPlayer p)
        {
            playerlist.Add(p);
        }

        public void StartFight()
        {
            state = true;
        }

    }
}
