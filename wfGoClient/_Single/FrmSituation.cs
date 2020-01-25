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
    public partial class FrmSituation : Form
    {
        public FrmSituation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TxtShow.Text = true.ToString();
        }

        private void FrmTest_Load(object sender, EventArgs e)
        {

        }

        public void SetStr(string str1,string str2)
        {
            label1.Text = str1;
            label2.Text = str2;
        }
    }
}
