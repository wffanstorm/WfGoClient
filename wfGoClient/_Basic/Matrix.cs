using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace wfGoClient
{
    public class Matrix
    {
        public int[,] matrix;

        public int this[int i, int j]
        {
            get { return matrix[i, j]; }
            set { matrix[i, j] = value; }
        }

        public Matrix()
        {
            int n = ConstNumber.linenum + 1;
            matrix = new int[n, n];//用1，1到19，19

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = 0;
                }
            }
        }

        public Matrix Copy()
        {
            Matrix m = new Matrix();
            int n = ConstNumber.linenum;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    m[i, j] = this[i, j];
                }
            }
            return m;
        }

        public bool EqualSituationWith(Matrix m)
        {
            int n = ConstNumber.linenum + 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int a = this[i, j];
                    int b = m[i, j];
                    if (a != 0)
                    {
                        a = a / Math.Abs(a);
                    }

                    if (b != 0)
                    {
                        b = b / Math.Abs(b);
                    }

                    if (a != b)
                    {
                        return false;
                    }
                }
            }
            return true;


        }

        public Point GetPointByNumber(int number)
        {
            int n = ConstNumber.linenum + 1;
            Point p = new Point(0, 0);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Math.Abs(this[i, j]) == number)
                    {
                        int flag = 1;
                        if (this[i, j] < 0) flag = -1;
                        p.X = i * flag;
                        p.Y = j;
                        return p;
                    }
                }
            }
            return p;

        }

        public Matrix GetSituationMatrix()
        {
            int n = ConstNumber.linenum + 1;
            Matrix m = new Matrix();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (this[i, j] == 0) continue;
                    m[i, j] = this[i,j]/ Math.Abs(this[i, j]);
                }
            }
            return m;
        }

        public override string ToString()
        {
            int n = ConstNumber.linenum + 1;
            string str = "";
            for(int i=1;i<n;i++)
            {
                for(int j=1;j<n;j++)
                {
                    str += this[j, i].ToString();
                    str += "  ";
                }
                str += "\r\n";
            }
            return str;
        }

        public int GetLastNumber()
        {
            int result = 1;
            int n = ConstNumber.linenum + 1;
            for(int i=1;i<n;i++)
            {
                for(int j=1;j<n;j++)
                {
                    if(Math.Abs(this[i,j])>result)
                    {
                        result = Math.Abs(this[i, j]);
                    }
                }
            }
            return result;
        }

        public Point GetLastPoint()
        {
            Point p = new Point(0, 0);

            int lastnum = 0;
            int n = ConstNumber.linenum + 1;
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (Math.Abs(this[i, j]) > lastnum)
                    {
                        lastnum = Math.Abs(this[i, j]);
                        p.X = i;
                        p.Y = j;
                    }
                }
            }

            return p;
        }

        public void Passive()
        {
            int n = ConstNumber.linenum + 1;
            for(int i=0;i<n;i++)
            {
                for(int j=0;j<n;j++)
                {
                    this[i, j] *= -1;
                }
            }
        }


    }
}
