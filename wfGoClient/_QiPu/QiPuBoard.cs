using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfGoClient
{
    class QiPuBoard:Board
    {
        //base: matrixlist 存有所有棋盘状态，number表示总手数
        private int m; //要显示的棋盘是matrixlist[m]
        

        public QiPuBoard()
        { }
        public QiPuBoard(Board b)
        {
            this.matrixlist = b.GetMatrixList();
            this.m = matrixlist.Count - 1;
        }

        public override void Draw(Graphics gr)
        {
            DrawToBmp();

            base.Draw(gr);
        }

        public new void DrawToBmp()
        {
            Graphics grbmp = Graphics.FromImage(bmp);
            DrawBoard(grbmp);
            DrawPieces(grbmp);

            if (showsituation == true)
            {
                Matrix matrix = matrixlist[m];

                Matrix powerpoint = GetPowerPointMatrix(matrix);

                Matrix Area = powerpoint.GetSituationMatrix();

                DrawPowerAreaToBmp(Area);
            }
        }

        protected new void  DrawPieces(Graphics gr)
        {
            int n = linenum + 1;
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (matrixlist[m][i, j] != 0)
                    {
                        bool isblack = true;
                        if (matrixlist[m][i, j] < 0)
                        {
                            isblack = false;
                        }
                        DrawPiece(gr, isblack, i, j);
                        if (Math.Abs(matrixlist[m][i, j]) == m)
                        {
                            DrawNewFlag(gr, i, j);
                        }
                    }
                }
            }
        }

        protected new void DrawPiece(Graphics gr, bool isblack, int x, int y)
        {
            int r = ConstNumber.r;
            Color color = isblack == true ? Color.Black : Color.White;
            Brush mybrush = new SolidBrush(color);

            int rectX = x * 2 * r - r;
            int rectY = y * 2 * r - r;

            gr.FillEllipse(mybrush, rectX, rectY, 2 * r, 2 * r);
            gr.DrawEllipse(Pens.Black, rectX, rectY, 2 * r, 2 * r);

            if (shownumber)
            {
                int n = Math.Abs(matrixlist[m][x, y]);
                Font font;
                Point p;

                Color c = color == Color.Black ? Color.White : Color.Black;
                Brush b = new SolidBrush(c);
                if (n < 10)
                {
                    font = new Font("宋体", 15, FontStyle.Bold);
                    p = new Point(rectX + r / 2, rectY + r / 2);
                }
                else if (n < 100)
                {
                    font = new Font("宋体", 12, FontStyle.Bold);
                    p = new Point(rectX + r / 4, rectY + r / 4);
                }
                else
                {
                    font = new Font("宋体", 10, FontStyle.Bold);
                    p = new Point(rectX, rectY + r / 3);
                }

                gr.DrawString(n.ToString(), font, b, p);

            }
        }

        public new void ReadInSGF(string path)
        {
            base.ReadInSGF(path);
            m = matrixlist.Count - 1;
            
        }

        public void BoardReturn()
        {
            m = 0;
        }

        public void BoardBack()
        {
            if (m - 1 >= 0)
                m -= 1;
        }

        public void BoardForward()
        {
            if (m + 1 < matrixlist.Count)
                m += 1;
        }

        public void BoardEnd()
        {
            m = matrixlist.Count - 1;
        }

        public new int BlackKillWhite
        {
            //白棋总手数-棋盘上存在的白棋数
            get
            {
                int n = ConstNumber.linenum + 1;
                Matrix matrix = matrixlist[m];
                int white = 0;
                for (int i = 1; i < n; i++)
                {
                    for (int j = 1; j < n; j++)
                    {
                        if (matrix[i, j] < 0)
                            white++;
                    }
                }
                return m / 2 - white;

            }
        }

        public new int WhiteKillBlack
        {
            get
            {
                int n = ConstNumber.linenum + 1;
                Matrix matrix = matrixlist[m];
                int black = 0;
                for (int i = 1; i < n; i++)
                {
                    for (int j = 1; j < n; j++)
                    {
                        if (matrix[i, j] > 0)
                            black++;
                    }
                }
                if (m % 2 == 1)
                {
                    return m / 2 + 1 - black;
                }
                else

                {
                    return m / 2 - black;
                }
            }
        }

    }
}
