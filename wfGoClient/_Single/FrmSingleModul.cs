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


    public partial class FrmSingleModul : Form
    {
        SingleModul game;

        public FrmSingleModul()
        {
            InitializeComponent();
        }

        private void FrmSingleModul_Load(object sender, EventArgs e)
        {
            LblChoose.Text = "当前：黑白";

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (game != null)
            {
                game.board.Draw(e.Graphics);
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (game != null)
            {
                DialogResult res = MessageBox.Show("是否保存该棋谱？", "提示", MessageBoxButtons.YesNo);
                if(res==DialogResult.Yes)
                {
                    saveFileDialog1.Filter = "SGF文件|*.sgf";
                    saveFileDialog1.FileName = "NewSave.sgf";
                    DialogResult res1 = saveFileDialog1.ShowDialog();

                    if (res1 == DialogResult.OK)
                    {
                        game.board.WriteToSGF(saveFileDialog1.FileName);
                        MessageBox.Show("该棋谱保存成功！", "提示");
                    }
                    else
                    {
                        return;
                    }
                }

            }

            game = new SingleModul();
            PicShow.Invalidate();
        }

        private void toolStripButtonBlackAndWhite_Click(object sender, EventArgs e)
        {
            if (game == null) return;

            game.choose = Choose.BlackAndWhite;
            LblChoose.Text = "当前：黑白";
        }

        private void toolStripButtonBalck_Click(object sender, EventArgs e)
        {
            if (game == null) return;

            game.choose = Choose.Black;
            LblChoose.Text = "当前：黑子";
        }

        private void toolStripButtonWhite_Click(object sender, EventArgs e)
        {
            if (game == null) return;

            game.choose = Choose.White;
            LblChoose.Text = "当前：白子";
        }

        private void toolStripButtonCross_Click(object sender, EventArgs e)
        {
            if (game == null) return;

            game.choose = Choose.Cross;
            LblChoose.Text = "当前：标记";
        }

        private void PicShow_MouseUp(object sender, MouseEventArgs e)
        {
            if (game == null) return;

            //计算横纵坐标
            int cellSize = ConstNumber.r * 2;
            int boardsize = ConstNumber.linenum;

            //根据鼠标点击位置，计算出棋子的横纵坐标
            double dbX = e.X * 1.0 / cellSize - 0.5;
            int intX = GetUpperNum(dbX);
            double dbY = e.Y * 1.0 / cellSize - 0.5;
            int intY = GetUpperNum(dbY);//上取整
                                        //如果点击位置不在棋盘范围则返回
            if (intX > boardsize || intY > boardsize) return;
            if (intX == 0 || intY == 0) return;

            //右键
            if (e.Button == MouseButtons.Right)
            {
                //移除棋子和标记
                game.board.RemoveCross(intX, intY);
                game.board.RemovePiece(intX, intY);
            }

            //左键
            if (e.Button == MouseButtons.Left)
            {
                //放置棋子
                switch (game.choose)
                {
                    case Choose.BlackAndWhite:
                        bool setok = false;
                        if (game.board.flag % 2 == 0)
                        {
                            setok = game.board.SetWhitePiece(intX, intY);
                        }
                        else
                        {
                            setok = game.board.SetBlackPiece(intX, intY);
                        }
                        if (setok)
                        {
                            game.board.flag++;
                        }

                        break;
                    case Choose.Black:
                        game.board.SetBlackPiece(intX, intY);
                        break;
                    case Choose.White:
                        game.board.SetWhitePiece(intX, intY);
                        break;
                    case Choose.Cross:
                        game.board.SetCross(intX, intY);
                        break;
                }
            }
            LblLiberty.Text = "气：" + game.board.GetLiberty(intX, intY).ToString();

            PicShow.Invalidate();
            //game.board.Draw(PicShow.CreateGraphics());
        }

        private int GetUpperNum(double a)//上取整
        {
            int b = (int)a;
            if (b < a) b = b + 1; //如果取整后比原来数字小，则取整后+1
            return b;

        }

        private void toolStripButtonRegret_Click(object sender, EventArgs e)
        {
            if (game == null)
            {
                return;
            }
            game.board.Regret();
            game.board.Draw(PicShow.CreateGraphics());
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
            game = new SingleModul();

            openFileDialog1.Filter = "SGF文件|*.sgf";
            DialogResult res = openFileDialog1.ShowDialog();

            if (res == DialogResult.OK)
            {
                game.board.ReadInSGF(openFileDialog1.FileName);
            }
            PicShow.Invalidate();

        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (game == null) return;

            saveFileDialog1.Filter = "SGF文件|*.sgf";
            saveFileDialog1.FileName = "NewSave.sgf";
            DialogResult res = saveFileDialog1.ShowDialog();

            if (res == DialogResult.OK)
            {
                game.board.WriteToSGF(saveFileDialog1.FileName);
                MessageBox.Show("该棋谱保存成功！", "提示");
            }

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

        private void toolStripBtnView_Click(object sender, EventArgs e)
        {
            if (game == null) return;
            FrmQiPuModul frm = new FrmQiPuModul(game.board);
            frm.Show();
            
        }
    }
}
