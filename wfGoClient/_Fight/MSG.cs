using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace wfGoClient
{
    enum MSG_Type { QuitRoom,Room,Broadcast,Name,CreatRoom, ComeInRoom, ApplyFight, IfAgree, Board, Surrender, Finish, Regret, RoomList, Heartbeat }
    //param state:   null,    Room,broadcast, name,roomname , roomnumber, minutes, bool_target, ftboard,   null,    null ,  null, list<room>,  null
    class MSG
    {
        public MSG_Type type;
        public object parameter;

        public MSG(MSG_Type t, object param)
        {
            type = t;
            parameter = param;
        }

        public string ToJson()
        {
            string str = JsonConvert.SerializeObject(this);
            return str;
        }

        public static MSG Parse(string jsonstr)
        {
            MSG msg = JsonConvert.DeserializeObject<MSG>(jsonstr);
            return msg;
        }

    }
}
