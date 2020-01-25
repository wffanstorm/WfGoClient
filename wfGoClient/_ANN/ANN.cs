using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace wfGoClient
{
    class ANN
    {
        private int mInputCount;
        private int mHiddenLayerCount;
        private int mHiddenCount;
        private int mOutputCount;

        private List<NetworkNode> mInputNodes;
        private List<List<NetworkNode>> mHiddenNodes;
        private List<NetworkNode> mOutputNodes;

        //private double[,] mInputHiddenWeight;
        //private double[,] mHiddenOutputWeight;

        private double[][][] weight;


        private List<DataNode> trainNodes;

        public void setTrainNodes(List<DataNode> trainNodes)
        {
            this.trainNodes = trainNodes;
        }


        public ANN(int inputCount,int hiddenLayerCount, int hiddenCount, int outputCount)
        {

            mInputCount = inputCount;
            mHiddenLayerCount = hiddenLayerCount;
            mHiddenCount = hiddenCount;
            mOutputCount = outputCount;


            //构建 输入节点
            mInputNodes = new List<NetworkNode>();
            for (int i = 0; i < inputCount; i++)
            {
                mInputNodes.Add(new NetworkNode(NetworkNode.TYPE_INPUT));
            }

            //构建 隐藏层框架、节点
            mHiddenNodes = new List<List<NetworkNode>>();
            for (int i = 0; i < mHiddenLayerCount; i++)
            {
                List<NetworkNode> l = new List<NetworkNode>();
                for(int j=0;j<mHiddenCount;j++)
                {
                    l.Add(new NetworkNode(NetworkNode.TYPE_HIDDEN));
                }
                mHiddenNodes.Add(l);
            }

            //构建 输出层节点
            mOutputNodes = new List<NetworkNode>();
            for (int i = 0; i < mOutputCount; i++)
            {
                mOutputNodes.Add(new NetworkNode(NetworkNode.TYPE_OUTPUT));
            }



            //###### weight  数组构建
            weight = new double[mHiddenLayerCount + 1][][];
            //weight  输入层--第一隐层  构建
            weight[0] = new double[inputCount][];
            for (int i = 0; i < inputCount; i++)
            {
                weight[0][i] = new double[hiddenCount];
            }
            //weight  隐层--隐层   构建
            for(int ll=1;ll<mHiddenLayerCount;ll++)
            {
                weight[ll] = new double[mHiddenCount][];
                for (int i = 0; i < mHiddenCount; i++)
                {
                    weight[ll][i] = new double[hiddenCount];
                }
            }
            //weight  最后隐层--输出层   构建
            weight[mHiddenLayerCount] = new double[mHiddenCount][];
            for (int i = 0; i < mHiddenCount; i++)
            {
                weight[mHiddenLayerCount][i] = new double[mOutputCount];
            }

            //#######   weight初始化
            Random rand = new Random();
            //weight  输入层--第一隐层  初始化
            for (int i = 0; i < mInputCount; i++)
                for (int j = 0; j < mHiddenCount; j++)
                    weight[0][i][j] = (double)(rand.NextDouble() * 0.1);
            //weight  隐层--隐层   初始化
            for (int ll = 1; ll < mHiddenLayerCount; ll++)
            {
                for (int i = 0; i < mHiddenCount; i++)
                    for (int j = 0; j < mHiddenCount; j++)
                        weight[ll][i][j] = (double)(rand.NextDouble() * 0.1);
            }
            //weight  最后一隐层--输出层   初始化
            for (int i = 0; i < mHiddenCount; i++)
                for (int j = 0; j < mOutputCount; j++)
                    weight[mHiddenLayerCount][i][j] = (double)(rand.NextDouble() * 0.1);

        }

        /**
         * 更新权重，每个权重的梯度都等于与其相连的前一层节点的输出乘以与其相连的后一层的反向传播的输出
         */
        private void updateWeights(double eta)
        {
            //更新输入层到隐层的权重矩阵
            for (int i = 0; i < mInputCount; i++)
                for (int j = 0; j < mHiddenCount; j++)
                    weight[0][i][j] -= eta
                            * mInputNodes[i].getForwardOutputValue()
                            * mHiddenNodes[0][j].getBackwardOutputValue();

            //更新隐层到下一隐层的权重矩阵
            for (int ll = 1; ll < mHiddenLayerCount; ll++)
            {
                for (int i = 0; i < mHiddenCount; i++)
                {
                    for (int j = 0; j < mHiddenCount; j++)
                    {
                        weight[ll][i][j] -= eta
                            * mHiddenNodes[ll-1][i].getForwardOutputValue()
                            * mHiddenNodes[ll][j].getBackwardOutputValue();
                    }
                }
            }

            //更新隐层到输出层的权重矩阵
            for (int i = 0; i < mHiddenCount; i++)
                for (int j = 0; j < mOutputCount; j++)
                    weight[mHiddenLayerCount][i][j] -= eta
                            * mHiddenNodes[mHiddenLayerCount - 1][i].getForwardOutputValue()
                            * mOutputNodes[j].getBackwardOutputValue();

        }

        /**
         * 前向传播
         */
        private void forward(List<double> list)
        {
            // 输入层
            for (int k = 0; k < list.Count; k++)
                mInputNodes[k].setForwardInputValue(list[k]);
            // 第一隐层
            for (int j = 0; j < mHiddenCount; j++)
            {
                double temp = 0;
                for (int k = 0; k < mInputCount; k++)
                    temp += weight[0][k][j]
                            * mInputNodes[k].getForwardOutputValue();
                mHiddenNodes[0][j].setForwardInputValue(temp);
            }
            //后续隐层
            for (int ll = 1; ll < mHiddenLayerCount; ll++)
            {
                for (int j = 0; j < mHiddenCount; j++)
                {
                    double temp = 0;
                    for (int k = 0; k < mHiddenCount; k++)
                        temp += weight[ll][k][j]
                                * mHiddenNodes[ll-1][k].getForwardOutputValue();
                    mHiddenNodes[ll][j].setForwardInputValue(temp);
                }
            }

            // 输出层
            for (int j = 0; j < mOutputCount; j++)
            {
                double temp = 0;
                for (int k = 0; k < mHiddenCount; k++)
                    temp += weight[mHiddenLayerCount][k][j]
                            * mHiddenNodes[mHiddenLayerCount-1][k].getForwardOutputValue();
                mOutputNodes[j].setForwardInputValue(temp);
            }
        }

        /**
         * 反向传播
         */
        private void backward(int type)
        {
            // 输出层
            for (int j = 0; j < mOutputCount; j++)
            {
                //输出层计算误差把误差反向传播，这里-1代表不属于，1代表属于
                double result = -1;
                if (j == type)
                    result = 1;
                mOutputNodes[j].setBackwardInputValue(
                        mOutputNodes[j].getForwardOutputValue() - result);
            }
            // 最后一个隐层
            for (int j = 0; j < mHiddenCount; j++)
            {
                double temp = 0;
                for (int k = 0; k < mOutputCount; k++)
                    temp += weight[mHiddenLayerCount][j][k]
                            * mOutputNodes[k].getBackwardOutputValue();
            }
            //前面的隐层
            for (int ll = mHiddenLayerCount - 1; ll >= 1; ll--)
            {
                for (int j = 0; j < mHiddenCount; j++)
                {
                    double temp = 0;
                    for (int k = 0; k < mHiddenCount; k++)
                        temp += weight[ll][j][k]
                                * mHiddenNodes[ll][k].getBackwardOutputValue();
                }
            }

        }


        public void train(double eta, int n)
        {
            //reset();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < trainNodes.Count; j++)
                {
                    forward(trainNodes[j].GetAttribList());
                    backward(trainNodes[j].GetNodeType());
                    updateWeights(eta);
                }

            }
        }


        /**
         * 初始化
         */
         /*
        private void reset()
        {
            mInputNodes.Clear();
            mHiddenNodes.Clear();
            mOutputNodes.Clear();
            Random rand = new Random();
            for (int i = 0; i < mInputCount; i++)
                mInputNodes.Add(new NetworkNode(NetworkNode.TYPE_INPUT));
            for (int i = 0; i < mHiddenCount; i++)
                mHiddenNodes[0].Add(new NetworkNode(NetworkNode.TYPE_HIDDEN));
            for (int i = 0; i < mOutputCount; i++)
                mOutputNodes.Add(new NetworkNode(NetworkNode.TYPE_OUTPUT));
            for (int i = 0; i < mInputCount; i++)
                for (int j = 0; j < mHiddenCount; j++)
                    weight[0][i][j] = (double)(rand.NextDouble() * 0.1);
            for (int i = 0; i < mHiddenCount; i++)
                for (int j = 0; j < mOutputCount; j++)
                    weight[1][i][j] = (double)(rand.NextDouble() * 0.1);
        }
        */

        public int test(DataNode dn)
        {
            forward(dn.GetAttribList());
            double result = 2;
            int type = 0;
            //取最接近1的
            for (int i = 0; i < mOutputCount; i++)
            {
                //MessageBox.Show("output " + i.ToString() + " : " + mOutputNodes[i].getForwardOutputValue().ToString());
                if ((1 - mOutputNodes[i].getForwardOutputValue()) < result)
                {
                    result = 1 - mOutputNodes[i].getForwardOutputValue();
                    type = i;
                }
            }
            return type;
        }



        public void SaveWeight()
        {
            StreamWriter writer = new StreamWriter("weight.txt");
            StringBuilder str = new StringBuilder();

            //将所有参数添加到 str， 用空格隔开
            for(int i=0;i<mHiddenLayerCount+1;i++)
            {
                if(i==0)
                {
                    for(int j=0;j<mInputCount;j++)
                    {
                        for(int k=0;k<mHiddenCount;k++)
                        {
                            str.Append(weight[i][j][k].ToString()+" ");
                        }
                    }
                }
                else if(i==mHiddenLayerCount)
                {
                    for (int j = 0; j < mHiddenCount; j++)
                    {
                        for (int k = 0; k < mOutputCount; k++)
                        {
                            str.Append(weight[i][j][k].ToString() + " ");
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < mHiddenCount; j++)
                    {
                        for (int k = 0; k < mHiddenCount; k++)
                        {
                            str.Append(weight[i][j][k].ToString() + " ");
                        }
                    }
                }
            }
            str.Remove(str.Length - 1, 1);
            writer.Write(str);
            writer.Close();
            MessageBox.Show("save weight ok");
            
        }

        public void ReadInWeight()
        {
            StreamReader reader = new StreamReader("weight.txt");
            string str = reader.ReadToEnd();
            reader.Close();
            string[] strs = str.Split(' ');

            //从strs中读入所有参数
            int i = 0;
            int j = 0;
            int k = 0;
            foreach(string s in strs)
            {
                //weight[0][][]
                if(i==0)
                {
                    if(k==mHiddenCount)
                    {
                        j++;
                        k = 0;
                    }
                    if(j==mInputCount)
                    {
                        i = 1;
                        j = 0;
                        k = 0;
                    }

                }

                //weight[mhiddenlayercount][][]
                else if(i==mHiddenLayerCount)
                {
                    if (k == mOutputCount)
                    {
                        j++;
                        k = 0;
                    }
                    if (j == mHiddenCount)
                    {
                        break;
                        //全部读入完成
                    }
                }
                //weight[1~mhiddenlayercount-1][][]
                else
                {
                    if (k == mHiddenCount)
                    {
                        j++;
                        k = 0;
                    }
                    if (j == mHiddenCount)
                    {
                        i++;
                        j = 0;
                        k = 0;
                    }
                }

                weight[i][j][k] = Convert.ToDouble(s);
                k++;

            }

            MessageBox.Show("read in weight ok");

 
        }

        public Point ANNGO(DataNode dn)
        {
            Point p = new Point();

            int type = test(dn);

            p.X = type / 19 + 1;
            p.Y = type % 19 + 1;

            return p;
        }

    }
}
