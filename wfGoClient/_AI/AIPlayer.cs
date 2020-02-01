using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace wfGoClient
{
    public class AIPlayer : Player
    {
        private AIBoard board;
        private bool isblack;
        private HumanPlayer humanplayer;
        private PictureBox pic;
        private int level;
        private ANN ann;

        public bool CanSetPiece;


        public AIPlayer(AIBoard b, bool isblack, HumanPlayer h, PictureBox pic, int lv)
        {
            this.board = b;
            this.isblack = isblack;
            humanplayer = h;
            this.pic = pic;
            level = lv;


            ann = new ANN(361, 13, 50, 361);
            if (File.Exists("weight.txt"))
            {
                ann.ReadInWeight();
            }
        }

        public void ThinkAndGo()//AI走棋函数
        {
            Thread AIGoThread;
            switch (level)
            {
                case 1:
                    AIGoThread = new Thread(AIGoMethod_1);
                    break;
                case 2:
                    AIGoThread = new Thread(AIGoMethod_2);
                    break;
                case 3:
                    AIGoThread = new Thread(AIGoMethod_3);
                    break;
                case 4:
                    AIGoThread = new Thread(AIGoMethod_4);
                    break;
                case 5:
                    AIGoThread = new Thread(AIGoMethod_5);
                    break;
                default:
                    AIGoThread = new Thread(AIGoMethod_1);
                    break;

            }

           
            AIGoThread.Start();

        }


        //###################################

        private bool AIJudgeWin(Matrix m) //给定棋盘矩阵，判定自己是否优势
        {
            return board.AIJudgeWin(m, isblack);
        }

        private bool SetPiece(int x, int y)
        {
            if (isblack == true)
            {
                return board.SetBlackPiece(x, y);
            }
            else
            {
                return board.SetWhitePiece(x, y);
            }
        }

        private int CountLiberty(Matrix m, int x, int y)
        {
            return board.CountLiberty(m, x, y);
        }


        /*  AIGoMethod  -> 使用一定的算法，求出落子点(i,j),并落子
         * 
         *  选取最佳落子点(i,j)后，加入以下代码
         * 
         
            SetPiece(i, j);
            CanSetPiece = false;
            humanplayer.CanSetPiece = true;
            pic.BeginInvoke(new Action(() =>
            {
                pic.Invalidate();
            }));

        */

        private void TurnEnd()
        {
            CanSetPiece = false;
            humanplayer.CanSetPiece = true;
            pic.BeginInvoke(new Action(() =>
            {
                pic.Invalidate();
            }));
        }

        private void AIGoMethod_1()//AI算法1,演示算法
        {
            if (CanSetPiece == false) return;
            int n = ConstNumber.linenum + 1;
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (SetPiece(i, j) == true)
                    {
                        CanSetPiece = false;
                        humanplayer.CanSetPiece = true;
                        pic.BeginInvoke(new Action(() =>
                        {
                            pic.Invalidate();
                        }));
                        return;
                    }
                }
            }

        }

        private void AIGoMethod_2()//MTCL完全随机 
        {

            Matrix m = board.GetLastMatrix();
            Point point = MTCLChoose(m, 15, 3);

            SetPiece(point.X, point.Y);

            TurnEnd();

            return;
        }

        //############# Function used in AIGoMethod_2 ##############################
        private Point MTCLChoose(Matrix m, int width, int deepth)//m is a numbered matrix
        {
            Point result = new Point(0, 0);//最优点
            double p_max = 0;//最高获胜概率
            string str = "";
            for (int i = 0; i < width; i++)
            {
                //复制,落子，搜索，更新
                Matrix mm = m.Copy();
                Point point = AISimulationSetPiece1(ref mm);
                double p = MTCLSearch(mm, width, deepth - 1);

                if (p >= p_max)
                {
                    p_max = p;
                    result = point;
                }
                str += "尝试次数=" + i.ToString() + "  落子点为：(" + point.X + "," + point.Y + ")  取胜概率p=" + p.ToString() + "\r\n";
            }
            //MessageBox.Show(str+"\r\n" +"MTCLChoose x=" + result.X + "  y=" + result.Y);
            return result;
        }

        private double MTCLSearch(Matrix m, int width, int deepth)
        {
            if (deepth == 0)
            {
                if (AIJudgeWin(m))
                {
                    //MessageBox.Show("AIJudge Win");
                    return 1;
                }
                else return 0;
            }

            double p_ave = 0;

            for (int i = 0; i < width; i++)
            {
                Matrix mm = m.Copy();
                AISimulationSetPiece1(ref mm);
                double p = MTCLSearch(mm, width, deepth - 1);
                p_ave += p;
            }
            p_ave = p_ave / width;
            return p_ave;
        }

        private Point AISimulationSetPiece1(ref Matrix m)
        {
            //AI脑海中模拟2步棋（按照围棋规则），自己1步，对方1步
            //策略：完全随机
            Point point = new Point(0, 0);
            Random rand = new Random(DateTime.Now.Millisecond);
            int n = ConstNumber.linenum + 1;
            while (true)//AI自己走棋1步
            {
                int x = rand.Next(1, n);
                int y = rand.Next(1, n);
                if (m[x, y] != 0) continue; //此处有棋，重新随机

                Matrix mm = m.Copy();
                int flag = 1;
                if (isblack == false)
                {
                    flag = -1;
                }
                mm[x, y] = flag * (mm.GetLastNumber() + 1);

                //提子判断
                bool killed = board.KillProcess(mm, x, y);

                //未提子
                if (killed == false)
                {
                    //落子气判断

                    int liberty = CountLiberty(mm, x, y);
                    if (liberty == 0)//落子无气，该落子无效
                    {
                        continue;
                    }
                }
                //成功走棋
                m = mm.Copy(); //矩阵更新

                //记录该点，并在方法末尾返回该点
                point.X = x;
                point.Y = y;

                break;
            }
            while (true)//AI在脑海中给对手走棋1步
            {
                int x = rand.Next(1, n);
                int y = rand.Next(1, n);
                if (m[x, y] != 0) continue; //此处有棋，重新随机

                Matrix mm = m.Copy();
                int flag = 1;
                if (isblack == true)//对手的棋色与自己的相反
                {
                    flag = -1;
                }
                mm[x, y] = flag * (mm.GetLastNumber() + 1);

                //提子判断
                bool killed = board.KillProcess(mm, x, y);

                //未提子
                if (killed == false)
                {
                    //落子气判断

                    int liberty = CountLiberty(mm, x, y);
                    if (liberty == 0)//落子无气，该落子无效
                    {
                        continue;
                    }
                }
                //成功走棋
                m = mm.Copy(); //矩阵更新

                break;
            }
            //MessageBox.Show("in AI simulation  m= \r\n" + m.ToString());
            return point;
        }

        //###########################################

        private void AIGoMethod_3()//开局+附近搜索+MTCL完全随机
        {

            Matrix m = board.GetLastMatrix();

            //开局前6步，如果还有角未落子，则占角
            if (m.GetLastNumber() < 6)
            {
                if (StartUpSetPiece(m))
                {
                    TurnEnd();
                    return;
                }
            }
            //上次对手落子位置为lastpoint，该点周围4距离内，搜索己方所有棋串，若气<=2,则长

            if(CloseAreaSetPiece())
            {
                TurnEnd();
                return;
            }

            AIGoMethod_2();
        }
        //############# Function used in AIGoMethod_3 ##############################
        private bool StartUpSetPiece(Matrix m)
        {
            if (StartUpSetPiece_Sub1(m, 4, 4)) return true;
            else if (StartUpSetPiece_Sub1(m, 16, 4)) return true;
            else if (StartUpSetPiece_Sub1(m, 4, 16)) return true;
            else if (StartUpSetPiece_Sub1(m, 16, 16)) return true;

            else return false;
        }
        private bool StartUpSetPiece_Sub1(Matrix m, int midX, int midY)//used in StartUpSetPiece
        {
            //search  1/4  board, if no piece here, set piece
            int i1 = 0;
            int i2 = 0;
            int j1 = 0;
            int j2 = 0;

            if (midX == 4 && midY == 4)
            {
                i1 = 1;
                i2 = 10;
                j1 = 1;
                j2 = 10;
            }
            else if (midX == 16 && midY == 4)
            {
                i1 = 11;
                i2 = 20;
                j1 = 1;
                j2 = 10;
            }
            else if (midX == 4 && midY == 16)
            {
                i1 = 1;
                i2 = 10;
                j1 = 11;
                j2 = 20;
            }
            else if (midX == 16 && midY == 16)
            {
                i1 = 11;
                i2 = 20;
                j1 = 11;
                j2 = 20;
            }

            bool hasPiece = false;

            //四分之一棋盘搜索
            for (int i = i1; i < i2; i++)
            {
                for (int j = j1; j < j2; j++)
                {
                    if (m[i, j] != 0)
                    {
                        hasPiece = true;
                        break;
                    }
                }
                if (hasPiece == true)
                {
                    break;
                }
            }
            if (hasPiece == false)
            {
                Random rand = new Random();
                int deltaX = 0;
                int deltaY = 0;
                while (true)
                {
                    deltaX = rand.Next(-1, 2);
                    deltaY = rand.Next(-1, 2);
                    if (Math.Abs(deltaX) + Math.Abs(deltaY) <= 1)
                    {
                        break;
                    }
                }
                int x = midX + deltaX;
                int y = midY + deltaY;

                SetPiece(x, y);
                return true;
            }
            return false;
        }

        private bool CloseAreaSetPiece()
        {
            Matrix m = board.GetLastMatrix();
            Point lastpoint = m.GetLastPoint();
            int lastnum = m.GetLastNumber();

            int n = ConstNumber.linenum + 1;
            int i = lastpoint.X;
            int j = lastpoint.Y;

            //该上一步棋子的4距离领域内搜索
            for (int u = 0; u <= 4; u++)
            {
                for (int v = 0; v <= 4; v++)
                {
                    if (u + v > 4) continue;
                    //if (u == 0 && v == 0) continue;

                    // + +
                    if (i + u < n && j + v < n)
                    {
                        if (NeedChang(m, i + u, j + v))
                        {
                            return true;
                        }
                    }
                    // + -
                    if (i + u < n && j - v > 0 && v != 0)
                    {
                        if (NeedChang(m, i + u, j - v))
                        {
                            return true;
                        }
                    }
                    // - +
                    if (i - u > 0 && j + v < n && u != 0)
                    {
                        if (NeedChang(m, i - u, j + v))
                        {
                            return true;
                        }

                    }
                    // - -
                    if (i - u > 0 && j - v > 0 && u != 0 && v != 0)
                    {
                        if (NeedChang(m, i - u, j - v))
                        {
                            return true;
                        }
                    }

                }
            }

            return false;
        }

        private bool IsMyPiece(Matrix m, int x, int y)
        {
            if (isblack)
            {
                if (m[x, y] > 0) return true;
                else return false;
            }
            else
            {
                if (m[x, y] < 0) return true;
                else return false;
            }
        }

        private bool NeedChang(Matrix m, int x, int y)
        {
            if (m[x, y] != 0)
            {
                if (IsMyPiece(m, x, y))
                {
                    if (CountLiberty(m, x, y) <= 2)
                    {
                        return Chang(m,x, y);
                    }
                }
            }
            return false;
        }
        private bool Chang(Matrix m,int x, int y)
        {
            bool[,] visited = new bool[20, 20];
            List<Point> pointlist = new List<Point>();
            visited[x, y] = true;
            //找出所有可以长的点，记录到pointlist
            Chang_DeepSearch(m, x, y, visited, pointlist);

            if (pointlist.Count == 0) return false;

            //选出长后 气最多的点 p
            Point p=ChooseMaxLibertyChang(m, pointlist);

            SetPiece(p.X, p.Y);
            //MessageBox.Show("Chang");
            return true;
        }
        private void Chang_DeepSearch(Matrix m,int x,int y,bool[,] visited,List<Point> pointlist)
        {
            //找到所有可以长的位置点，保存到pointlist

            //left
            if (x - 1 >= 1) //左边非边界
            {
                if (visited[x - 1, y] == false)//左边位置未被搜索过
                {
                    visited[x - 1, y] = true;

                    if(m[x-1,y]==0)
                    {
                        pointlist.Add(new Point(x - 1, y));
                    }
                    else if(IsMyPiece(m,x-1,y))
                    {
                        Chang_DeepSearch(m, x-1, y, visited, pointlist);
                    }
                    
                }
            }
            //up
            if (y - 1 >= 1) //上边非边界
            {
                if (visited[x, y - 1] == false)//上边位置未被搜索过
                {
                    visited[x, y - 1] = true;

                    if (m[x , y-1] == 0)
                    {
                        pointlist.Add(new Point(x, y-1));
                    }
                    else if (IsMyPiece(m, x , y-1))
                    {
                        Chang_DeepSearch(m, x, y-1, visited, pointlist);
                    }

                }
            }
            //right
            if (x + 1 <= ConstNumber.linenum) //右边非边界
            {
                if (visited[x + 1, y] == false)//右边位置未被搜索过
                {
                    visited[x + 1, y] = true;

                    if (m[x + 1, y] == 0)
                    {
                        pointlist.Add(new Point(x + 1, y));
                    }
                    else if (IsMyPiece(m, x + 1, y))
                    {
                        Chang_DeepSearch(m, x + 1, y, visited, pointlist);
                    }

                }
            }
            //down
            if (y + 1 <= ConstNumber.linenum) //下边非边界
            {
                if (visited[x, y + 1] == false)//下边位置未被搜索过
                {
                    visited[x, y + 1] = true;

                    if (m[x, y + 1] == 0)
                    {
                        pointlist.Add(new Point(x, y + 1));
                    }
                    else if (IsMyPiece(m, x, y + 1))
                    {
                        Chang_DeepSearch(m, x, y + 1, visited, pointlist);
                    }
                }
            }

        }
        private Point ChooseMaxLibertyChang(Matrix m,List<Point> pointlist)
        {
            Point p = new Point();
            int liberty = 0;
            int pieceflag = -1;
            if (isblack) pieceflag = 1;
            foreach(Point pt in pointlist)
            {
                Matrix mm = m.Copy();

                mm[pt.X, pt.Y] = pieceflag;
                int l = CountLiberty(mm, pt.X, pt.Y);

                if(l>liberty)
                {
                    p = pt;
                    liberty = l;
                }

            }
            return p;
        }

        //##########################################

        private void AIGoMethod_4() // 开局+ANN
        {
            Matrix m = board.GetLastMatrix();

            //开局前6步，如果还有角未落子，则占角
            if (m.GetLastNumber() < 6)
            {
                if (StartUpSetPiece(m))
                {
                    TurnEnd();
                    return;
                }
            }

            //ANN
            Matrix mm = m.Copy();
            if (isblack == false) mm.Passive();
            DataNode node = new DataNode(mm);
            Point point = ann.ANNGO(node);

            //MessageBox.Show(point.X.ToString() + " " + point.Y.ToString());

            //落子
            if(!SetPiece(point.X, point.Y))
            {
                //MessageBox.Show("failed");
                AIGoMethod_3();
            }
            TurnEnd();
            return;

        }

        private void AIGoMethod_5() // 开局+ANN+MTCL
        {
            Matrix m = board.GetLastMatrix();

            //开局前6步，如果还有角未落子，则占角
            if (m.GetLastNumber() < 6)
            {
                if (StartUpSetPiece(m))
                {
                    TurnEnd();
                    return;
                }
            }

            //ANN
            Point point = ann.ANNGO(new DataNode(m));
            SetPiece(point.X, point.Y);
            TurnEnd();
            return;

        }

        //############# Function used in AIGoMethod_5 ##############################

        //##########################################
    }
}
