using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace wfGoClient
{
    class DataNode
    {
        //361输入，361输出

        Matrix matrix; //输入节点输入 400个
        Point point;   //类别判断

        public DataNode(Matrix m,Point p)
        {
            matrix = m;
            point = p;
        }
        public DataNode(Matrix m)
        {
            matrix = m;
            point = new Point();
        }

        public List<double> GetAttribList()
        {
            //将361个输入数据提取到列表并返回
            List<double> l = new List<double>();
            int n = ConstNumber.linenum + 1;
            for(int i=1;i<n;i++)
            {
                for(int j=1;j<n;j++)
                {
                    l.Add((double)matrix[i, j]);
                }
            }
            return l;
        }

        public int GetNodeType()
        {
            int type = (point.X - 1) * 19 + point.Y - 1;
            return type;
        }

        public new string ToString()
        {
            string str = "";

            return str;
        }
    }
}
