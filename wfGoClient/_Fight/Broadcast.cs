using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace wfGoClient
{
    class Broadcast
    {
        public List<Room> roomlist;
        public int onlinenum;
        public string info;

        public Broadcast(List<Room> l,int o,string i)
        {
            roomlist = l;
            onlinenum = o;
            info = i;
        }

        public string ToJson()
        {
            string str = JsonConvert.SerializeObject(this);
            return str;
        }

        public Broadcast Parse(string jsonstr)
        {
            Broadcast b = JsonConvert.DeserializeObject<Broadcast>(jsonstr);
            return b;
        }

    }
}
