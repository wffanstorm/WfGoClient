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


    public partial class FrmQiPuModul : Form
    {
        QiPuModul game;

        public FrmQiPuModul()
        {
            InitializeComponent();
        }
        public FrmQiPuModul(Board b)
        {
            InitializeComponent();
            game = new QiPuModul(b);
        }

        private void FrmSingleModul_Load(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (game != null)
            {
                game.board.Draw(e.Graphics);
            }
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

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            game = new QiPuModul();

            openFileDialog1.Filter = "SGF文件|*.sgf";
            DialogResult res = openFileDialog1.ShowDialog();

            if (res == DialogResult.OK)
            {
                game.board.ReadInSGF(openFileDialog1.FileName);
            }
            PicShow.Invalidate();
            UpdateLbl();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (game == null) return;

            game.board.SituationJudge();

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


        //######

        private void toolStripBtnForward_Click(object sender, EventArgs e)
        {
            if (game == null) return;
            game.board.BoardForward();
            PicShow.Invalidate();
            UpdateLbl();
        }

        private void toolStripBtnStart_Click(object sender, EventArgs e)
        {
            if (game == null) return;
            game.board.BoardReturn();
            PicShow.Invalidate();
            UpdateLbl();
        }

        private void toolStripBtnBack_Click(object sender, EventArgs e)
        {
            if (game == null) return;
            game.board.BoardBack();
            PicShow.Invalidate();
            UpdateLbl();
        }

        private void toolStripBtnEnd_Click(object sender, EventArgs e)
        {
            if (game == null) return;
            game.board.BoardEnd();
            PicShow.Invalidate();
            UpdateLbl();
        }

        private void FrmQiPuModul_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Q:
                    toolStripBtnStart_Click(this, null);
                    break;
                case Keys.W:
                    toolStripBtnBack_Click(this, null);
                    break;
                case Keys.E:
                    toolStripBtnForward_Click(this, null);
                    break;
                case Keys.R:
                    toolStripBtnEnd_Click(this, null);
                    break;
            }
        }

        public void UpdateLbl()
        {
            LblBlackKill.Text = game.board.BlackKillWhite.ToString();
            LblWhiteKill.Text = game.board.WhiteKillBlack.ToString();
        }


    }
}
