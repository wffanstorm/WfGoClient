using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using System.IO;

namespace wfGoClient
{
    public  class Board
    {
        protected int linenum;
        protected int size;
        protected List<Matrix> matrixlist;
        protected int number;//目前是第几手（第0手表示双方均未落子）
        protected int cellSize;

        protected Bitmap bmp;
        protected SoundPlayer soundplayer;
        //###############
        protected bool shownumber;
        protected bool showsituation;

        //#####

        //2017_4_18  提子数
        public int BlackKillWhite
        {
            //白棋总手数-棋盘上存在的白棋数
            get
            {
                int n = ConstNumber.linenum + 1;
                Matrix m = matrixlist[matrixlist.Count - 1];
                int white = 0;
                for (int i = 1; i < n; i++)
                {
                    for (int j = 1; j < n; j++)
                    {
                        if (m[i, j] < 0)
                            white++;
                    }
                }
                return number / 2 - white;

            }
        }

        public int WhiteKillBlack
        {
            get
            {
                int n = ConstNumber.linenum + 1;
                Matrix m = matrixlist[matrixlist.Count - 1];
                int black = 0;
                for (int i = 1; i < n; i++)
                {
                    for (int j = 1; j < n; j++)
                    {
                        if (m[i, j] > 0)
                            black++;
                    }
                }
                if (number % 2 == 1)
                {
                    return number / 2 + 1 - black;
                }
                else

                {
                    return number / 2 - black;
                }
            }
        }

        //

        protected void DrawBoard(Graphics gr)
        {
            //背景
            Image img = Image.FromFile("Image/背景.jpg");
            gr.DrawImage(img, 0, 0);

            //横线
            for (int i = 1; i <= linenum; i++)
            {
                Point start = new Point(cellSize, i * cellSize);
                Point end = new Point(linenum * cellSize, i * cellSize);
                gr.DrawLine(Pens.Black, start, end);
            }
            //竖线
            for (int i = 1; i <= linenum; i++)
            {
                Point start = new Point(i * cellSize, cellSize);
                Point end = new Point(i * cellSize, linenum * cellSize);
                gr.DrawLine(Pens.Black, start, end);
            }
            //横坐标
            for (int i = 1; i <= linenum; i++)
            {
                string drawstr = i.ToString();
                Font drawfont = new Font("宋体", 12);
                SolidBrush drawbrush = new SolidBrush(Color.Black);
                PointF drawpointf = new PointF((float)(i * cellSize) - 10, 0);
                gr.DrawString(drawstr, drawfont, drawbrush, drawpointf);
            }
            //纵坐标
            for (int i = 1; i <= linenum; i++)
            {
                string drawstr = i.ToString();
                Font drawfont = new Font("宋体", 12);
                SolidBrush drawbrush = new SolidBrush(Color.Black);
                PointF drawpointf = new PointF(0, (float)(i * cellSize) - 10);
                gr.DrawString(drawstr, drawfont, drawbrush, drawpointf);
            }
            //9个小圆点
            for (int i = 4; i <= 16; i += 6)
            {
                for (int j = 4; j <= 16; j += 6)
                {
                    int X = i * cellSize;
                    int Y = j * cellSize;

                    int width = cellSize / 4;
                    int height = width;

                    int circleX = X - width / 2;
                    int circleY = Y - height / 2;

                    gr.FillEllipse(Brushes.Black, circleX, circleY, width, height);


                }
            }
        }

        protected void DrawPieces(Graphics gr)
        {
            int n = linenum + 1;
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (matrixlist[number][i, j] != 0)
                    {
                        bool isblack = true;
                        if (matrixlist[number][i, j] < 0)
                        {
                            isblack = false;
                        }
                        DrawPiece(gr, isblack, i, j);
                        if (Math.Abs(matrixlist[number][i, j]) == number)
                        {
                            DrawNewFlag(gr, i, j);
                        }
                    }
                }
            }
        }

        protected void DrawPiece(Graphics gr, bool isblack, int x, int y)
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
                int n = Math.Abs(matrixlist[number][x, y]);
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

        protected void DrawNewFlag(Graphics gr, int x, int y)
        {
            int r = ConstNumber.r;
            int rectX = x * 2 * r - r / 2;
            int rectY = y * 2 * r;
            gr.FillEllipse(Brushes.Orange, rectX, rectY, r - 2, r - 2);

        }

        protected bool SetPiece(bool isblack, int x, int y)
        {
            //合法判断
            if (matrixlist[number][x, y] != 0)
            {
                return false;
            }

            //尝试落子
            Matrix m = matrixlist[number].Copy();
            int flag = 1;
            if (isblack == false)
            {
                flag = -1;
            }
            m[x, y] = flag * (number + 1);

            //提子判断
            bool killed = KillProcess(m, x, y);

            //未提子
            if (killed == false)
            {
                //落子气判断

                int liberty = CountLiberty(m, x, y);
                if (liberty == 0)//落子无气，该落子无效
                {
                    return false;
                }
            }
            //劫判断
            if (number - 1 >= 0)
            {
                if (m.EqualSituationWith(matrixlist[number - 1]))
                {
                    return false;
                }
            }


            //落子有效
            number = number + 1;
            matrixlist.Add(m);
            soundplayer.SoundLocation = "Sound/落子.wav";
            soundplayer.Play();

            return true;

        }

        public Board()
        {
            size = ConstNumber.BoardSize;
            linenum = ConstNumber.linenum;
            cellSize = 2 * ConstNumber.r;

            number = 0;
            matrixlist = new List<Matrix>();


            Matrix m = new Matrix();
            matrixlist.Add(m);

            bmp = new Bitmap(size, size);
            soundplayer = new SoundPlayer();
        }

        public virtual void Draw(Graphics gr)
        {
            gr.DrawImage(bmp, 0, 0);
        }

        public void DrawToBmp()
        {
            Graphics grbmp = Graphics.FromImage(bmp);
            DrawBoard(grbmp);
            DrawPieces(grbmp);

            if (showsituation == true)
            {
                Matrix m = matrixlist[matrixlist.Count - 1];

                Matrix powerpoint = GetPowerPointMatrix(m);

                Matrix Area = powerpoint.GetSituationMatrix();

                DrawPowerAreaToBmp(Area);
            }
        }

        public bool SetBlackPiece(int x, int y)
        {
            return SetPiece(true, x, y);
        }

        public bool SetWhitePiece(int x, int y)
        {
            return SetPiece(false, x, y);
        }

        public bool RemovePiece(int x, int y)
        {
            //该位置没有棋子
            if (matrixlist[number][x, y] == 0)
            {
                return false;
            }
            //有棋子，移除它
            int num = matrixlist[number][x, y];
            matrixlist[number][x, y] = 0;

            return false;

        }

        public virtual void Regret()
        {

        }


        //############################################
        //Update1  2017_4_13 数气，落子判断，杀棋判断   集成到 SetPiece 函数
        //############################################

        public  int CountLiberty(Matrix m, int x, int y)
        {
            int liberty = 0;
            bool[,] visited = new bool[20, 20];

            //isblack?
            bool isblack = false;
            if (m[x, y] > 0)
                isblack = true;

            //count liberty
            visited[x, y] = true;
            if (isblack)
            {
                CountBlackLiberty(m, x, y, visited, ref liberty);
            }
            else
            {
                CountWhiteLiberty(m, x, y, visited, ref liberty);
            }

            //MessageBox.Show("liberty:" + liberty.ToString());
            return liberty;
        }

        protected void CountBlackLiberty(Matrix m, int x, int y, bool[,] visited, ref int liberty)
        {

            //left
            if (x - 1 >= 1) //左边非边界
            {
                if (visited[x - 1, y] == false)//左边位置未被搜索过
                {
                    visited[x - 1, y] = true;

                    int left = m[x - 1, y];
                    if (left == 0)//左边位置为空
                    {
                        liberty = liberty + 1;
                    }
                    else if (left < 0)//左边位置为白
                    {
                    }
                    else if (left > 0)//左边位置为黑
                    {
                        CountBlackLiberty(m, x - 1, y, visited, ref liberty);//对左边黑旗进行深搜
                    }
                }
            }

            //up
            if (y - 1 >= 1) //上边非边界
            {
                if (visited[x, y - 1] == false)//上边位置未被搜索过
                {
                    visited[x, y - 1] = true;

                    int up = m[x, y - 1];
                    if (up == 0)//上边位置为空
                    {
                        liberty = liberty + 1;

                    }
                    else if (up < 0)//上边位置为白
                    {
                    }
                    else if (up > 0)//上边位置为黑
                    {
                        CountBlackLiberty(m, x, y - 1, visited, ref liberty);//对上边黑旗进行深搜

                    }
                }
            }

            //right
            if (x + 1 <= linenum) //右边非边界
            {
                if (visited[x + 1, y] == false)//右边位置未被搜索过
                {
                    visited[x + 1, y] = true;

                    int right = m[x + 1, y];
                    if (right == 0)//右边位置为空
                    {
                        liberty = liberty + 1;

                    }
                    else if (right < 0)//右边位置为白
                    {
                    }
                    else if (right > 0)//右边位置为黑
                    {
                        CountBlackLiberty(m, x + 1, y, visited, ref liberty);//对右边黑旗进行深搜

                    }
                }
            }


            //down
            if (y + 1 <= linenum) //下边非边界
            {
                if (visited[x, y + 1] == false)//下边位置未被搜索过
                {
                    visited[x, y + 1] = true;

                    int down = m[x, y + 1];
                    if (down == 0)//下边位置为空
                    {
                        liberty = liberty + 1;

                    }
                    else if (down < 0)//下边位置为白
                    {
                    }
                    else if (down > 0)//下边位置为黑
                    {
                        CountBlackLiberty(m, x, y + 1, visited, ref liberty);//对下边黑旗进行深搜

                    }
                }
            }
        }

        protected void CountWhiteLiberty(Matrix m, int x, int y, bool[,] visited, ref int liberty)
        {

            //left
            if (x - 1 >= 1) //左边非边界
            {
                if (visited[x - 1, y] == false)//左边位置未被搜索过
                {
                    visited[x - 1, y] = true;

                    int left = m[x - 1, y];
                    if (left == 0)//左边位置为空
                    {
                        liberty = liberty + 1;
                    }
                    else if (left > 0)//左边位置为黑
                    {
                    }
                    else if (left < 0)//左边位置为白
                    {
                        CountWhiteLiberty(m, x - 1, y, visited, ref liberty);//对左边白旗进行深搜
                    }
                }
            }

            //up
            if (y - 1 >= 1) //上边非边界
            {
                if (visited[x, y - 1] == false)//上边位置未被搜索过
                {
                    visited[x, y - 1] = true;

                    int up = m[x, y - 1];
                    if (up == 0)//上边位置为空
                    {
                        liberty = liberty + 1;
                    }
                    else if (up > 0)//上边位置为黑
                    {
                    }
                    else if (up < 0)//上边位置为白
                    {
                        CountWhiteLiberty(m, x, y - 1, visited, ref liberty);//对上边白旗进行深搜
                    }
                }
            }

            //right
            if (x + 1 <= linenum) //右边非边界
            {
                if (visited[x + 1, y] == false)//右边位置未被搜索过
                {
                    visited[x + 1, y] = true;

                    int right = m[x + 1, y];
                    if (right == 0)//右边位置为空
                    {
                        liberty = liberty + 1;
                    }
                    else if (right > 0)//右边位置为黑
                    {
                    }
                    else if (right < 0)//右边位置为白
                    {
                        CountWhiteLiberty(m, x + 1, y, visited, ref liberty);//对右边白旗进行深搜
                    }
                }
            }


            //down
            if (y + 1 <= linenum) //下边非边界
            {
                if (visited[x, y + 1] == false)//下边位置未被搜索过
                {
                    visited[x, y + 1] = true;

                    int down = m[x, y + 1];
                    if (down == 0)//下边位置为空
                    {
                        liberty = liberty + 1;
                    }
                    else if (down > 0)//下边位置为黑
                    {
                    }
                    else if (down < 0)//下边位置为白
                    {
                        CountWhiteLiberty(m, x, y + 1, visited, ref liberty);//对下边白旗进行深搜
                    }
                }
            }

        }


        public  bool KillProcess(Matrix m, int x, int y)
        {
            //MessageBox.Show("killprocess");
            bool haskilled = false;

            //isblack?
            bool isblack = false;
            if (m[x, y] > 0)
            {
                isblack = true;
            }

            if (isblack)
            {
                haskilled = KillWhiteSearch(m, x, y);
            }
            else
            {
                haskilled = KillBlackSearch(m, x, y);
            }

            return haskilled;
        }

        protected bool KillBlackSearch(Matrix m, int x, int y)//x,y为白子，杀黑棋
        {
            // MessageBox.Show("killBlackSearch");

            bool haskilled = false;

            //left
            if (x - 1 >= 1)
            {
                if (m[x - 1, y] > 0)//左边是黑棋
                {
                    int liberty = CountLiberty(m, x - 1, y);
                    if (liberty == 0)
                    {
                        Kill(m, x - 1, y);
                        haskilled = true;
                    }

                }
            }

            //up
            if (y - 1 >= 1)
            {
                if (m[x, y - 1] > 0)//上边是黑棋
                {
                    int liberty = CountLiberty(m, x, y - 1);
                    if (liberty == 0)
                    {
                        Kill(m, x, y - 1);
                        haskilled = true;
                    }

                }
            }

            //right
            if (x + 1 <= linenum)
            {
                if (m[x + 1, y] > 0)
                {
                    int liberty = CountLiberty(m, x + 1, y);
                    if (liberty == 0)
                    {
                        Kill(m, x + 1, y);
                        haskilled = true;
                    }
                }
            }

            //down
            if (y + 1 <= linenum)
            {
                if (m[x, y + 1] > 0)
                {
                    int liberty = CountLiberty(m, x, y + 1);
                    if (liberty == 0)
                    {
                        Kill(m, x, y + 1);
                        haskilled = true;
                    }
                }
            }


            return haskilled;
        }

        protected bool KillWhiteSearch(Matrix m, int x, int y)//x,y为黑子，杀白棋
        {
            // MessageBox.Show("killWhiteSearch");
            bool haskilled = false;

            //left
            if (x - 1 >= 1)
            {
                if (m[x - 1, y] < 0)//左边是白棋
                {
                    int liberty = CountLiberty(m, x - 1, y);
                    if (liberty == 0)
                    {
                        Kill(m, x - 1, y);
                        haskilled = true;
                    }
                }
            }

            //up
            if (y - 1 >= 1)
            {
                if (m[x, y - 1] < 0)//上边是bai棋
                {
                    int liberty = CountLiberty(m, x, y - 1);
                    if (liberty == 0)
                    {
                        Kill(m, x, y - 1);
                        haskilled = true;
                    }

                }
            }

            //right
            if (x + 1 <= linenum)
            {
                if (m[x + 1, y] < 0)
                {
                    int liberty = CountLiberty(m, x + 1, y);
                    if (liberty == 0)
                    {
                        Kill(m, x + 1, y);
                        haskilled = true;
                    }
                }
            }

            //down
            if (y + 1 <= linenum)
            {
                if (m[x, y + 1] < 0)
                {
                    int liberty = CountLiberty(m, x, y + 1);
                    if (liberty == 0)
                    {
                        Kill(m, x, y + 1);
                        haskilled = true;
                    }
                }
            }
            return haskilled;
        }

        protected void Kill(Matrix m, int x, int y)
        {
            //MessageBox.Show("kill");
            bool isblack = false;
            if (m[x, y] > 0)
            {
                isblack = true;
            }
            bool[,] visited = new bool[20, 20];
            visited[x, y] = true;

            if (isblack)
            {
                KillBlackPieces(m, x, y, visited);
            }
            else
            {
                KillWhitePieces(m, x, y, visited);
            }
        }

        protected void KillBlackPieces(Matrix m, int x, int y, bool[,] visited)
        {
            //MessageBox.Show("killblackpieces");


            visited[x, y] = true;
            //left
            if (x - 1 >= 1)
            {
                if (visited[x - 1, y] == false)
                {

                    if (m[x - 1, y] > 0)
                    {
                        KillBlackPieces(m, x - 1, y, visited);
                    }
                }

            }

            //up
            if (y - 1 >= 1)
            {
                if (visited[x, y - 1] == false)
                {
                    if (m[x, y - 1] > 0)
                    {
                        KillBlackPieces(m, x, y - 1, visited);
                    }
                }

            }

            //right
            if (x + 1 <= linenum)
            {
                if (visited[x + 1, y] == false)
                {
                    if (m[x + 1, y] > 0)
                    {
                        KillBlackPieces(m, x + 1, y, visited);
                    }
                }

            }

            //down
            if (y + 1 <= linenum)
            {
                if (visited[x, y + 1] == false)
                {
                    if (m[x, y + 1] > 0)
                    {
                        KillBlackPieces(m, x, y + 1, visited);
                    }
                }

            }
            //self
            m[x, y] = 0;
        }

        protected void KillWhitePieces(Matrix m, int x, int y, bool[,] visited)
        {
            //MessageBox.Show("killwhitepieces");

            visited[x, y] = true;
            //left
            if (x - 1 >= 1)
            {
                if (visited[x - 1, y] == false)
                {

                    if (m[x - 1, y] < 0)
                    {
                        KillWhitePieces(m, x - 1, y, visited);
                    }
                }

            }

            //up
            if (y - 1 >= 1)
            {
                if (visited[x, y - 1] == false)
                {
                    if (m[x, y - 1] < 0)
                    {
                        KillWhitePieces(m, x, y - 1, visited);
                    }
                }

            }

            //right
            if (x + 1 <= linenum)
            {
                if (visited[x + 1, y] == false)
                {
                    if (m[x + 1, y] < 0)
                    {
                        KillWhitePieces(m, x + 1, y, visited);
                    }
                }

            }

            //down
            if (y + 1 <= linenum)
            {
                if (visited[x, y + 1] == false)
                {
                    if (m[x, y + 1] < 0)
                    {
                        KillWhitePieces(m, x, y + 1, visited);
                    }
                }

            }
            //self
            m[x, y] = 0;


        }

        public int GetLiberty(int x, int y)//前端调用显示
        {
            if (matrixlist[matrixlist.Count - 1][x, y] == 0) return 0;
            return CountLiberty(matrixlist[matrixlist.Count - 1], x, y);
        }

        //############################################
        //################



        //############################################
        //Update2  2017_4_14 手数显示，SGF文件解析，棋谱读入、保存
        //############################################

        public void TurnOnShowNumber()
        {
            shownumber = true;
        }

        public void TurnOffShowNumber()
        {
            shownumber = false;
        }

        public void ReadInSGF(string path)
        {
            StreamReader reader = new StreamReader(path);
            string str = reader.ReadToEnd();
            reader.Close();
            SGF.Parse(str, this);

        }

        public void WriteToSGF(string path)
        {
            string str = SGF.Serialize(this);
            StreamWriter writer = new StreamWriter(path);
            writer.Write(str);
            writer.Close();
        }

        public List<Matrix> GetMatrixList()
        {
            return matrixlist;
        }

        //############################################
        //################


        //############################################
        //Update2  2017_4_15  简单形式判断
        //############################################

        public void SituationJudge()
        {
            Matrix m = matrixlist[matrixlist.Count - 1];
            Matrix powerpoint = GetPowerPointMatrix(m);
            Matrix Area = powerpoint.GetSituationMatrix();
            int blackcount = 0;
            int whitecount = 0;
            int n = ConstNumber.linenum + 1;
            string str = "";
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (Area[j, i] > 0)
                        blackcount++;
                    if (Area[j, i] < 0)
                        whitecount++;
                    //删除黑白棋本身所占的目数
                    if (m[j, i] > 0)
                        blackcount--;
                    if (m[j, i] < 0)
                        whitecount--;
                    string unit = powerpoint[j, i].ToString();
                    str += String.Format("{0,4} ", unit);
                }
                str += "\r\n\r\n";
            }
            //目数加入死子
            blackcount += BlackKillWhite;
            whitecount += WhiteKillBlack;

            string str2 = "黑：" + blackcount.ToString() + "目 ， 白：" + whitecount.ToString() + "目";

            str2 += "\r\n" + "黑提子：" + BlackKillWhite.ToString() + "  白提子：" + WhiteKillBlack.ToString();
            FrmSituation frm = new FrmSituation();
            frm.Show();
            frm.SetStr(str, str2);

        }

        public bool AIJudgeWin(Matrix m,bool AIisblack)
        {
            Matrix powerpoint = GetPowerPointMatrix(m);
            Matrix Area = powerpoint.GetSituationMatrix();
            int blackcount = 0;
            int whitecount = 0;
            int n = ConstNumber.linenum + 1;
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (Area[j, i] > 0)
                        blackcount++;
                    if (Area[j, i] < 0)
                        whitecount++;
                    //删除黑白棋本身所占的目数
                    if (m[j, i] > 0)
                        blackcount--;
                    if (m[j, i] < 0)
                        whitecount--;
                }
            
            }
            //目数加入死子
            blackcount += BlackKillWhite;
            whitecount += WhiteKillBlack;

            if(AIisblack)
            {
                if (blackcount > whitecount) return true;
                else return false;
            }
            else
            {
                if (blackcount < whitecount) return true;
                else return false;
            }
        }

        public void TurnOnShowSituation()
        {
            showsituation = true;
        }

        public void TurnOffShowSituation()
        {
            showsituation = false;
        }

        public bool GetShowSituation()
        {
            return showsituation;
        }

        protected void DrawPowerAreaToBmp(Matrix Area)
        {
            Graphics gr = Graphics.FromImage(bmp);

            int n = ConstNumber.linenum + 1;

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {

                    int a = Area[i, j];
                    if (a == 0) continue;

                    bool isblack = true;
                    int r = ConstNumber.r;
                    if (a < 0)
                    {
                        isblack = false;
                    }

                    Color color = isblack == true ? Color.Black : Color.White;
                    Brush mybrush = new SolidBrush(color);

                    int rectX = i * 2 * r - r / 4;
                    int rectY = j * 2 * r - r / 4;

                    gr.FillRectangle(mybrush, rectX, rectY, r / 2, r / 2);
                    gr.DrawRectangle(Pens.Black, rectX, rectY, r / 2, r / 2);

                }
            }


        }

        protected Matrix GetPowerPointMatrix(Matrix matrix)
        {
            Matrix m = matrix.GetSituationMatrix();

            Matrix situation = new Matrix();

            int n = ConstNumber.linenum + 1;

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    //m棋盘搜索，若是棋子则处理
                    if (m[i, j] == 0) continue;
                    PiecePowerCalculation(m, i, j, situation);
                }
            }
            /*
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (Math.Abs(situation[i, j]) < 2)
                        situation[i, j] = 0;
                }
            }
            */

            return situation;
        }

        protected void PiecePowerCalculation(Matrix m, int i, int j, Matrix situation)
        {
            int n = ConstNumber.linenum + 1;

            bool isblack = true;
            if (m[i, j] < 0)
                isblack = false;
            //该棋子的势力领域内
            for (int u = 0; u <= 4; u++)
            {
                for (int v = 0; v <= 4; v++)
                {
                    if (u + v > 4) continue;
                    //if (u == 0 && v == 0) continue;

                    // + +
                    if (i + u < n && j + v < n)
                    {
                        //if (m[i + u, j + v] == 0)//此处是空，分配势力点
                        {
                            situation[i + u, j + v] += GetPowerPoint(isblack, u, v);
                        }

                    }
                    // + -
                    if (i + u < n && j - v > 0 && v != 0)
                    {
                        //if (m[i + u, j - v] == 0)//此处是空，分配势力点
                        {
                            situation[i + u, j - v] += GetPowerPoint(isblack, u, v);
                        }

                    }
                    // - +
                    if (i - u > 0 && j + v < n && u != 0)
                    {
                        //if (m[i - u, j + v] == 0)//此处是空，分配势力点
                        {
                            situation[i - u, j + v] += GetPowerPoint(isblack, u, v);
                        }

                    }
                    // - -
                    if (i - u > 0 && j - v > 0 && u != 0 && v != 0)
                    {
                        //if (m[i - u, j - v] == 0)//此处是空，分配势力点
                        {
                            situation[i - u, j - v] += GetPowerPoint(isblack, u, v);
                        }
                        /*
                        else
                        {
                            situation[i - u, j - v] = 0;
                        }
                        */
                    }

                }
            }
        }

        protected int GetPowerPoint(bool isblack, int u, int v)
        {
            int sum = u + v;
            int rt = 0;

            int flag = 1;
            if (isblack == false)
                flag = -1;

            switch (sum)
            {
                case 0:
                    rt = 62;
                    break;
                case 1:
                    rt = 10;
                    break;
                case 2:
                    rt = 6;
                    break;
                case 3:
                    rt = 2;
                    break;
                case 4:
                    rt = 1;
                    break;
            }
            return rt * flag;
        }

        //############################################
        //################

        //#### update in 2017_5_6
        public Matrix GetLastMatrix()
        {
            return matrixlist[matrixlist.Count - 1];
        }

        //####

    }

}
