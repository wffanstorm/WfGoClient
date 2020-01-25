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
    public partial class FrmStart : Form
    {
        public static wfGoClient client;
        public static FrmFightMain main;

        public FrmStart()
        {
            InitializeComponent();
        }

        private void BtnSingleModul_Click(object sender, EventArgs e)
        {
            Form frmsingle = new FrmSingleModul();
            frmsingle.Show();
        }

        private void BtnFightModul_Click(object sender, EventArgs e)
        {

            Form frmfightlogin = new FrmFightLogin();
            frmfightlogin.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new FrmFightModul();
            frm.Show();
        }

        private void FrmStart_Load(object sender, EventArgs e)
        {

        }

        private void FrmStart_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
            e.Cancel = false;
        }

        private void BtnQiPu_Click(object sender, EventArgs e)
        {
            FrmQiPuModul frm = new FrmQiPuModul();
            frm.Show();
        }

        private void BtnAIModul_Click(object sender, EventArgs e)
        {
            FrmAIModul frm = new FrmAIModul();
            frm.Show();
        }

        private void BtnANNTrain_Click(object sender, EventArgs e)
        {
            FrmANNTrain frm = new FrmANNTrain();
            frm.Show();
        }
    }
}
