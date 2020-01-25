using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace wfGoClient
{
    public class wfGoClient
    {
        public FightBoard board;
        public FightPlayer player;

        public bool right; //落子权

        private TcpClient tcp;
        private NetworkStream netstream;
        private StreamReader streamreader;
        private Thread ListenThread;
        private Thread SendHeartbeatThread;


        public FrmFightModul frmfightmodul;
        public FrmFightMain frmfightmain;


        public wfGoClient(string name)
        {
            board = new FightBoard();
            player = new FightPlayer(name);
            tcp = new TcpClient();

            right = false;


        }

        public void Connect()
        {
            string ip = ConstNumber.serverIP;
            int port = ConstNumber.serverport;
            tcp.Connect(ip, port);
        }
        public void SendNameMSG(string name)
        {
            netstream = tcp.GetStream();
            MSG msg = new MSG(MSG_Type.Name, name);
            byte[] data = Encoding.Unicode.GetBytes(msg.ToJson() + "\r\n");
            netstream.Write(data, 0, data.Length);
        }
        public void SendCreatRoomMSG(string roomname)
        {
            netstream = tcp.GetStream();
            MSG msg = new MSG(MSG_Type.CreatRoom, roomname);
            byte[] data = Encoding.Unicode.GetBytes(msg.ToJson() + "\r\n");
            netstream.Write(data, 0, data.Length);
        }
        public void SendComeInRoomMSG(int roomnumber)
        {
            netstream = tcp.GetStream();
            MSG msg = new MSG(MSG_Type.ComeInRoom, roomnumber.ToString());
            byte[] data = Encoding.Unicode.GetBytes(msg.ToJson() + "\r\n");
            netstream.Write(data, 0, data.Length);
        }
        public void SendIfAgreeMSG(bool ifagree, string target)
        {
            netstream = tcp.GetStream();
            string param = ifagree.ToString() + "_" + target;
            MSG msg = new MSG(MSG_Type.IfAgree, param);
            byte[] data = Encoding.Unicode.GetBytes(msg.ToJson() + "\r\n");
            netstream.Write(data, 0, data.Length);
        }
        public void SendQuitRoomMSG()
        {
            netstream = tcp.GetStream();
            MSG msg = new MSG(MSG_Type.QuitRoom, null);
            byte[] data = Encoding.Unicode.GetBytes(msg.ToJson() + "\r\n");
            netstream.Write(data, 0, data.Length);
        }

        public void SendApplyFightMSG(int minute)
        {
            //MessageBox.Show("sendapplyfight", player.name);
            netstream = tcp.GetStream();
            MSG msg = new MSG(MSG_Type.ApplyFight, minute);
            byte[] data = Encoding.Unicode.GetBytes(msg.ToJson() + "\r\n");
            netstream.Write(data, 0, data.Length);
        }
        public void SendBoardMSG()
        {
            netstream = tcp.GetStream();
            MSG msg = new MSG(MSG_Type.Board, board);
            byte[] data = Encoding.Unicode.GetBytes(msg.ToJson() + "\r\n");
            netstream.Write(data, 0, data.Length);
        }
        public void SendRegretMSG()
        {
            netstream = tcp.GetStream();
            MSG msg = new MSG(MSG_Type.Regret, board);
            byte[] data = Encoding.Unicode.GetBytes(msg.ToJson() + "\r\n");
            netstream.Write(data, 0, data.Length);
        }
        public void SendSurrenderMSG()
        {
            netstream = tcp.GetStream();
            MSG msg = new MSG(MSG_Type.Surrender, null);
            byte[] data = Encoding.Unicode.GetBytes(msg.ToJson() + "\r\n");
            netstream.Write(data, 0, data.Length);
        }
        public void SendFinishMSG()
        {
            netstream = tcp.GetStream();
            MSG msg = new MSG(MSG_Type.Finish, null);
            byte[] data = Encoding.Unicode.GetBytes(msg.ToJson() + "\r\n");
            netstream.Write(data, 0, data.Length);
        }

        public void SendHearbeatMSG()
        {
            netstream = tcp.GetStream();
            MSG msg = new MSG(MSG_Type.Heartbeat, null);
            byte[] data = Encoding.Unicode.GetBytes(msg.ToJson() + "\r\n");
            netstream.Write(data, 0, data.Length);
        }
        private void Listen()
        {
            streamreader = new StreamReader(tcp.GetStream(), Encoding.Unicode);
            while (tcp.Connected)
            {
                string jsonstr;
                jsonstr = streamreader.ReadLine();
                MSG msg = MSG.Parse(jsonstr);
                //消息处理
                DealMSG(msg);
            }
        }

        private void DealMSG(MSG msg)
        {
            switch (msg.type)
            {
                case MSG_Type.Broadcast:
                    DealBroadcastMSG(msg);
                    break;
                case MSG_Type.IfAgree:
                    DealIfAgreeMSG(msg);
                    break;
                case MSG_Type.Room:
                    DealRoomMSG(msg);
                    break;
                case MSG_Type.ApplyFight:
                    DealApplyFightMSG(msg);
                    break;
                case MSG_Type.Board:
                    DealBoardMSG(msg);
                    break;
                case MSG_Type.Regret:
                    DealRegretMSG(msg);
                    break;
                case MSG_Type.Finish:
                    DealFinishMSG(msg);
                    break;
                case MSG_Type.Surrender:
                    DealSurrenderMSG(msg);
                    break;
            }
        }

        private void DealBroadcastMSG(MSG msg)
        {
            //MessageBox.Show("rcv broadcast");
            if (frmfightmain == null) return;
            Broadcast b = JsonConvert.DeserializeObject<Broadcast>(msg.parameter.ToString());
            frmfightmain.LblInfo.BeginInvoke(new Action(() => frmfightmain.LblInfo.Text = b.info));
            frmfightmain.LblOnLineNum.BeginInvoke(new Action(() => frmfightmain.LblOnLineNum.Text = b.onlinenum.ToString()));

            frmfightmain.ListView1.BeginInvoke(new Action(() =>
            {

                frmfightmain.ListView1.Items.Clear();
                foreach (Room r in b.roomlist)
                {
                    ListViewItem item = new ListViewItem(new string[] { r.number.ToString(), r.name, r.state.ToString(), r.playernum.ToString() });
                    frmfightmain.ListView1.Items.Add(item);
                }

            }));

        }
        private void DealIfAgreeMSG(MSG msg)
        {
            string param = (string)msg.parameter;
            string[] strs = param.Split('_');
            bool b = strs[0] == "True" ? true : false;
            string target = strs[1];


            if (b)
            {
                //MessageBox.Show(target + " 成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                if (target == "CreatRoom")
                {
                    int roomnumber = Convert.ToInt32(strs[2]);
                    //进入房间
                    frmfightmain.LblOnLineNum.BeginInvoke(new Action(() =>
                    {
                        Form frm = new FrmFightModul();
                        frm.Show();
                    }));

                }
                if (target == "ComeInRoom")
                {
                    //进入房间
                    frmfightmain.LblOnLineNum.BeginInvoke(new Action(() =>
                    {
                        Form frm = new FrmFightModul();
                        frm.Show();
                    }));
                }
                if (target == "ApplyFight")
                {
                    board = new FightBoard();
                    player.isblack = true;
                    frmfightmodul.BeginInvoke(new Action(() =>
                    {
                        frmfightmodul.PicShow.Invalidate();
                    }));
                    MessageBox.Show("游戏开始，您执黑先行");
                    right = true;
                }
                if(target=="Regret")
                {
                    //悔棋
                    frmfightmodul.BeginInvoke(new Action(() =>
                    {
                        frmfightmodul.PicShow.Invalidate();
                    }));
                }
                if(target=="Finish")
                {
                    //终局
                }
                
            }
            else
            {
                MessageBox.Show(target + " 不同意！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void DealRoomMSG(MSG msg)
        {
            //MessageBox.Show("roommsg");
            Room r = Room.Parse(msg.parameter.ToString());
            int roomnumber = r.number;
            string roomname = r.name;
            frmfightmodul.LVPlayer.BeginInvoke(new Action(() =>
            {
                frmfightmodul.Text = "wfGoClient-- " + roomnumber.ToString() + "号房间:" + roomname;
                frmfightmodul.LVPlayer.Items.Clear();
                foreach (FightPlayer p in r.playerlist)
                {
                    frmfightmodul.LVPlayer.Items.Add(p.name);
                }
                if (r.playerlist.Count >= 1)
                {
                    frmfightmodul.LblName1.Text = r.playerlist[0].name;
                    frmfightmodul.LblName2.Text = "null";
                }
                if (r.playerlist.Count >= 2)
                {
                    frmfightmodul.LblName2.Text = r.playerlist[1].name;
                }
            }));



        }

        private void DealApplyFightMSG(MSG msg)
        {
            //MessageBox.Show("rcv applyfight", player.name );

            int min = Convert.ToInt32( msg.parameter.ToString());

            DialogResult res = MessageBox.Show("对方申请开局：对方执黑，" + min.ToString() + "分钟", "申请开局", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                SendIfAgreeMSG(true, "ApplyFight");
                board = new FightBoard();
                player.isblack = false;
                frmfightmodul.PicShow.Invalidate();
                MessageBox.Show("对局开始，您执白后行","游戏开始");
            }
            else
            {
                SendIfAgreeMSG(false, "ApplyFight");
            }
        }
        private void DealRegretMSG(MSG msg)
        {
            DialogResult res = MessageBox.Show("对方申请悔棋，是否同意？", "申请悔棋", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                SendIfAgreeMSG(true, "Regret");
                //悔棋
            }
            else
            {
                SendIfAgreeMSG(false, "Regret");
            }
        }
        private void DealFinishMSG(MSG msg)
        {
            DialogResult res = MessageBox.Show("对方申请终局，是否同意？", "申请悔棋", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                SendIfAgreeMSG(true, "Finish");
                //终局
                right = false;
            }
            else
            {
                SendIfAgreeMSG(false, "Finish");
            }
        }
        private void DealSurrenderMSG(MSG msg)
        {
            //显示胜利；
            MessageBox.Show("对方投子认输！", "胜利");
            right = false;
        }
        private void DealBoardMSG(MSG msg)
        {
            //帮对方落子，与自己的棋色相反
            FightBoard fb =JsonConvert.DeserializeObject<FightBoard>( msg.parameter.ToString());
            if (player.isblack == true)
            {
                board.SetWhitePiece(fb.x, fb.y);
            }
            else
            {
                board.SetBlackPiece(fb.x, fb.y);
            }
            frmfightmodul.BeginInvoke(new Action(() =>
           {
               frmfightmodul.PicShow.Invalidate();
           }
            ));
            right = true;

        }




        public void StartListenThread()
        {
            ListenThread = new Thread(Listen);
            ListenThread.Start();
        }

        private void SendHeart()
        {
            netstream = tcp.GetStream();
            while (tcp.Connected)
            {
                Thread.Sleep(3000);
                SendHearbeatMSG();
            }
        }

        public void StartSendHeartbeatThread()
        {
            SendHeartbeatThread = new Thread(SendHeart);
            SendHeartbeatThread.Start();
        }




    }
}
