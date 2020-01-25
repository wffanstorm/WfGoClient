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
    public partial class FrmAISet : Form
    {
        FrmAIModul mother;

        public FrmAISet(FrmAIModul f)
        {
            mother = f;
            InitializeComponent();
        }
        

        private void FrmAISet_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("执黑");
            comboBox1.Items.Add("执白");
            comboBox1.Text = "执黑";

            comboBox2.Items.Clear();
            comboBox2.Items.Add("1");
            comboBox2.Items.Add("2");
            comboBox2.Items.Add("3");
            comboBox2.Items.Add("4");
            comboBox2.Items.Add("5");
            comboBox2.Text = "1";
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            mother.InitSet(comboBox1.Text, comboBox2.Text);
            this.Close();
        }
    }
}
