using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace wfGoClient
{
    class SingleBoard : Board
    {
        private bool[,] crossmatrix;
        public int flag;

        public SingleBoard()
        {
            int n = ConstNumber.linenum + 1;
            crossmatrix = new bool[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    crossmatrix[i, j] = false;
                }
            }
            flag = 1;
        }


        public override void Draw(Graphics gr)
        {
            DrawToBmp();
            DrawCrossToBmp();
            gr.DrawImage(bmp, 0, 0);
        }

        private void DrawCrossToBmp()
        {
            Graphics gr = Graphics.FromImage(bmp);
            int n = ConstNumber.linenum + 1;
            int cellSize = ConstNumber.r * 2;
            Pen mypen = new Pen(Color.Red, 3);
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (crossmatrix[i, j] == true)
                    {
                        int r = ConstNumber.r / 2;
                        int rectX = i * cellSize - r;
                        int rectY = j * cellSize - r;

                        gr.DrawRectangle(mypen, rectX, rectY, 2 * r, 2 * r);
                    }
                }
            }
        }

        public bool SetCross(int x, int y)
        {
            //该位置已经有cross
            if (crossmatrix[x, y] == true)
            {
                return false;
            }
            //
            crossmatrix[x, y] = true;
            return true;
        }

        public bool RemoveCross(int x, int y)
        {
            //该位置没有cross
            if (crossmatrix[x, y] == false)
            {
                return false;
            }
            //
            crossmatrix[x, y] = false;
            return true;
        }

        public override void Regret()
        {
            if (number == 0)
            {
                return;
            }
            if (matrixlist.Count > 1)
            {
                matrixlist.RemoveAt(matrixlist.Count - 1);
            }

            number--;
            flag--;
        }

    }
}
