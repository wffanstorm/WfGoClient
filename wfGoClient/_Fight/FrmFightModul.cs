using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfGoClient
{
    public partial class FrmFightModul : Form
    {
        public FrmFightModul()
        {
            InitializeComponent();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FrmFightModul_Load(object sender, EventArgs e)
        {
            FrmStart.client.frmfightmodul = this;
            FrmStart.main.Hide();
        }

        private void PicShow_Paint(object sender, PaintEventArgs e)
        {
            if (FrmStart.client.board != null)
                FrmStart.client.board.Draw(e.Graphics);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FrmStart.client.SendApplyFightMSG(20);
        }

        private void FrmFightModul_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("退出房间？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                FrmStart.client.SendQuitRoomMSG();
                FrmStart.main.Show();
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FrmStart.client.SendRegretMSG();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FrmStart.client.SendFinishMSG();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            FrmStart.client.SendSurrenderMSG();
        }

        private int GetUpperNum(double a)//上取整
        {
            int b = (int)a;
            if (b < a) b = b + 1; //如果取整后比原来数字小，则取整后+1
            return b;

        }

        private void PicShow_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            if (FrmStart.client.right == false) return;
            //计算横纵坐标
            int cellSize = ConstNumber.r * 2;
            int boardsize = ConstNumber.BoardSize;

            //根据鼠标点击位置，计算出棋子的横纵坐标
            double dbX = e.X * 1.0 / cellSize - 0.5;
            int intX = GetUpperNum(dbX);
            double dbY = e.Y * 1.0 / cellSize - 0.5;
            int intY = GetUpperNum(dbY);//上取整
                                        //如果点击位置不在棋盘范围则返回
            if (intX > boardsize || intY > boardsize) return;
            if (intX == 0 || intY == 0) return;

            if (FrmStart.client.player.isblack)
            {
                FrmStart.client.board.SetBlackPiece(intX, intY);
            }
            else
            {
                FrmStart.client.board.SetWhitePiece(intX, intY);
            }
            PicShow.Invalidate();
            FrmStart.client.right = false;
            FrmStart.client.SendBoardMSG();



        }
    }
}
