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
    public partial class FrmAIModul : Form
    {
        public AIModul game;
        public FrmAIModul()
        {
            InitializeComponent();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form frm = new FrmAISet(this);
            frm.Show();
        }

        private void FrmAIModul_Load(object sender, EventArgs e)
        {

        }

        private void LblShowNumber_Click(object sender, EventArgs e)
        {
            if (game == null) return;

            if (LblShowNumber.Text == "显示手数：关")
            {
                LblShowNumber.Text = "显示手数：开";
                game.board.TurnOnShowNumber();
                PicShow.Invalidate();
            }
            else
            {
                LblShowNumber.Text = "显示手数：关";
                game.board.TurnOffShowNumber();
                PicShow.Invalidate();
            }
        }

        private void LblSituation_Click(object sender, EventArgs e)
        {
            if (game == null) return;

            if (game.board.GetShowSituation())
            {
                game.board.TurnOffShowSituation();
                LblSituation.Text = "形式判断：关";
            }
            else
            {
                game.board.TurnOnShowSituation();
                LblSituation.Text = "形式判断：开";
            }
            PicShow.Invalidate();
        }

        private void BtnJudge_Click(object sender, EventArgs e)
        {
            if (game == null) return;

            game.board.SituationJudge();
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            if (game == null) return;
            FrmQiPuModul frm = new FrmQiPuModul(game.board);
            frm.Show();
        }

        private void BtnRegret_Click(object sender, EventArgs e)
        {
            if (game == null) return;
            if (game.humanplayer.CanSetPiece == false) return;

            game.board.Regret();
            game.board.Regret();
            PicShow.Invalidate();
        }

        private void PicShow_Paint(object sender, PaintEventArgs e)
        {
            if (game == null) return;

            game.board.Draw(e.Graphics);

        }

        public void InitSet(string strColor, string strLevel)
        {
            game = new AIModul(PicShow);
            game.InitSet(strColor, strLevel);
            LblIsBlack.Text = "您 " + strColor;
            LblAIDifficult.Text = "难度：" + strLevel;

            PicShow.Invalidate();

        }

        private int GetUpperNum(double a)//上取整
        {
            int b = (int)a;
            if (b < a) b = b + 1; //如果取整后比原来数字小，则取整后+1
            return b;

        }

        private void PicShow_MouseUp(object sender, MouseEventArgs e)
        {
            if (game == null) return;
            if (e.Button != MouseButtons.Left) return;
            if (game.humanplayer.CanSetPiece == false) return;
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

            bool setok=game.humanplayer.SetPiece(intX, intY);
            if(setok==true)
            {
                game.humanplayer.CanSetPiece = false;
                game.AIplayer.CanSetPiece = true;
                game.AIplayer.ThinkAndGo();
            }

            PicShow.Invalidate();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
