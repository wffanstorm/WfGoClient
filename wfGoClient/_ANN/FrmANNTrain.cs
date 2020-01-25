using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace wfGoClient
{
    public partial class FrmANNTrain : Form
    {
        ANN ann;
        public FrmANNTrain()
        {
            InitializeComponent();
        }


        private void FrmANNTrain_Load(object sender, EventArgs e)
        {
            ann = new ANN(361, 13, 50, 361);
            if (File.Exists("weight.txt"))
            {
                ann.ReadInWeight();
            }
           
        }

        private void BtnSearchSGF_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            string str = openFileDialog1.FileName;
            int pos=str.LastIndexOf(@"\");
            string path = str.Substring(0, pos);
            string[] files = Directory.GetFiles(path);
            ListBox1.Items.Clear();
            foreach (string s in files)
            {
                ListBox1.Items.Add(s);
            }

        }

        private void BtnStartTrain_Click(object sender, EventArgs e)
        {
            if (ListBox1.Items.Count == 0)
            {
                MessageBox.Show("请添加训练文件", "提示");
                return;
            }
            LblFileNumAll.Text = ListBox1.Items.Count.ToString();

            Thread TrainThread = new Thread(Train);
            TrainThread.Start();

        }

        private void Train()
        {
            DateTime t1 = DateTime.Now;
            int now = 0;
            foreach (string s in ListBox1.Items)
            {
                now++;

                this.BeginInvoke(new Action(() =>
                {
                    LblFileNumNow.Text = now.ToString();
                }));

                StreamReader reader = new StreamReader(s);
                string sgfstr = reader.ReadToEnd();
                reader.Close();

                List<DataNode> list = SGF.GetDataNodes(sgfstr);
                ann.setTrainNodes(list);
                ann.train(0.01, 10);
            }
            DateTime t2 = DateTime.Now;
            TimeSpan ts = t2.Subtract(t1);
            ann.SaveWeight();
            MessageBox.Show("train end,save weight ok   ts:" +ts.ToString() );
        }



    }
}
