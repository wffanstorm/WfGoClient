using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace wfGoClient
{
    static class SGF
    {

        public static void Parse(string sgfstr, Board b)
        {
            string body = GetBody(sgfstr);
            BodyToBoard(body, b);
        }

        public static string Serialize(Board b)
        {
            string str = "(";
            int i = 1;
            foreach (Matrix m in b.GetMatrixList())
            {
                string word = GetSGFWord(m, ref i);
                if (word != "")
                {
                    str += ";";
                    str += word;
                }

            }
            str += ")";
            return str;
        }

        public static List<DataNode> GetDataNodes(string sgfstr)
        {
            List<DataNode> list = new List<DataNode>();

            string body = GetBody(sgfstr);
            string[] strs = body.Split(';');

            Matrix m = new Matrix();
            Board b = new Board();

            foreach (string str in strs)
            {
                Point p = new Point();

                char[] c = str.ToCharArray();
                int x = c[2] - 'a' + 1;
                int y = c[3] - 'a' + 1;

                p.X = x;
                p.Y = y;
                Matrix mm = m.Copy();
                int flag = 1;
                if(c[0]=='W')
                {
                    mm.Passive();
                    flag = -1;
                }
                DataNode node = new DataNode(mm, p);
                list.Add(node);

                m[x, y] = flag;
                b.KillProcess(m, x, y);


            }
                return list;
        }

        //###############

        private static string GetBody(string sgfstr)
        {
            string s_start = ";B[";
            int n_start = sgfstr.IndexOf(s_start);
            n_start += 1;
            string body = sgfstr.Substring(n_start);
            body = body.Substring(0, body.Length - 1);
            return body;
        }

        private static void BodyToBoard(string body, Board b)
        {
            string[] strs = body.Split(';');
            foreach (string str in strs)
            {
                char[] c = str.ToCharArray();
                int x = c[2] - 'a' + 1;
                int y = c[3] - 'a' + 1;
                if (c[0] == 'B')
                {
                    b.SetBlackPiece(x, y);
                }
                else
                {
                    b.SetWhitePiece(x, y);
                }
            }
        }

        private static string GetSGFWord(Matrix m, ref int i)
        {
            string word = "";

            Point p = m.GetPointByNumber(i);
            if (p.X == 0 && p.Y == 0)
            {
            }
            else
            {
                if (p.X < 0)
                {
                    word += "W[";
                }
                else
                {
                    word += "B[";
                }
                char cx = (char)(Math.Abs(p.X) + 'a' - 1);
                char cy = (char)(p.Y + 'a' - 1);
                word += cx.ToString();
                word += cy.ToString();
                word += "]";
                i++;
            }
            return word;
        }



    }
}
