namespace wfGoClient
{
    partial class FrmSingleModul
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSingleModul));
            this.PicShow = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonBlackAndWhite = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBalck = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonWhite = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCross = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRegret = new System.Windows.Forms.ToolStripButton();
            this.LblChoose = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.LblShowNumber = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.LblSituation = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnView = new System.Windows.Forms.ToolStripButton();
            this.LblLiberty = new System.Windows.Forms.ToolStripLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.PicShow)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PicShow
            // 
            this.PicShow.Location = new System.Drawing.Point(12, 35);
            this.PicShow.Name = "PicShow";
            this.PicShow.Size = new System.Drawing.Size(600, 600);
            this.PicShow.TabIndex = 0;
            this.PicShow.TabStop = false;
            this.PicShow.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.PicShow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicShow_MouseUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNew,
            this.toolStripButtonOpen,
            this.toolStripButtonSave,
            this.toolStripSeparator1,
            this.toolStripButtonBlackAndWhite,
            this.toolStripButtonBalck,
            this.toolStripButtonWhite,
            this.toolStripButtonCross,
            this.toolStripButtonRegret,
            this.LblChoose,
            this.toolStripSeparator3,
            this.LblShowNumber,
            this.toolStripSeparator9,
            this.LblSituation,
            this.toolStripSeparator4,
            this.toolStripButton1,
            this.toolStripSeparator6,
            this.toolStripBtnView,
            this.toolStripSeparator2,
            this.LblLiberty});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(624, 32);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonNew
            // 
            this.toolStripButtonNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNew.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNew.Image")));
            this.toolStripButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNew.Name = "toolStripButtonNew";
            this.toolStripButtonNew.Size = new System.Drawing.Size(29, 29);
            this.toolStripButtonNew.Text = "新建";
            this.toolStripButtonNew.Click += new System.EventHandler(this.toolStripButton8_Click);
            // 
            // toolStripButtonOpen
            // 
            this.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOpen.Image")));
            this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Size = new System.Drawing.Size(29, 29);
            this.toolStripButtonOpen.Text = "打开";
            this.toolStripButtonOpen.Click += new System.EventHandler(this.toolStripButtonOpen_Click);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(29, 29);
            this.toolStripButtonSave.Text = "保存";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripButtonBlackAndWhite
            // 
            this.toolStripButtonBlackAndWhite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBlackAndWhite.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonBlackAndWhite.Image")));
            this.toolStripButtonBlackAndWhite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBlackAndWhite.Name = "toolStripButtonBlackAndWhite";
            this.toolStripButtonBlackAndWhite.Size = new System.Drawing.Size(29, 29);
            this.toolStripButtonBlackAndWhite.Text = "黑白交替";
            this.toolStripButtonBlackAndWhite.Click += new System.EventHandler(this.toolStripButtonBlackAndWhite_Click);
            // 
            // toolStripButtonBalck
            // 
            this.toolStripButtonBalck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBalck.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonBalck.Image")));
            this.toolStripButtonBalck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBalck.Name = "toolStripButtonBalck";
            this.toolStripButtonBalck.Size = new System.Drawing.Size(29, 29);
            this.toolStripButtonBalck.Text = "黑子";
            this.toolStripButtonBalck.Click += new System.EventHandler(this.toolStripButtonBalck_Click);
            // 
            // toolStripButtonWhite
            // 
            this.toolStripButtonWhite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonWhite.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonWhite.Image")));
            this.toolStripButtonWhite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonWhite.Name = "toolStripButtonWhite";
            this.toolStripButtonWhite.Size = new System.Drawing.Size(29, 29);
            this.toolStripButtonWhite.Text = "白子";
            this.toolStripButtonWhite.Click += new System.EventHandler(this.toolStripButtonWhite_Click);
            // 
            // toolStripButtonCross
            // 
            this.toolStripButtonCross.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCross.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCross.Image")));
            this.toolStripButtonCross.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCross.Name = "toolStripButtonCross";
            this.toolStripButtonCross.Size = new System.Drawing.Size(29, 29);
            this.toolStripButtonCross.Text = "标记";
            this.toolStripButtonCross.Click += new System.EventHandler(this.toolStripButtonCross_Click);
            // 
            // toolStripButtonRegret
            // 
            this.toolStripButtonRegret.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRegret.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRegret.Image")));
            this.toolStripButtonRegret.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRegret.Name = "toolStripButtonRegret";
            this.toolStripButtonRegret.Size = new System.Drawing.Size(29, 29);
            this.toolStripButtonRegret.Text = "悔棋";
            this.toolStripButtonRegret.Click += new System.EventHandler(this.toolStripButtonRegret_Click);
            // 
            // LblChoose
            // 
            this.LblChoose.Name = "LblChoose";
            this.LblChoose.Size = new System.Drawing.Size(32, 29);
            this.LblChoose.Text = "当前";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
            // 
            // LblShowNumber
            // 
            this.LblShowNumber.Name = "LblShowNumber";
            this.LblShowNumber.Size = new System.Drawing.Size(80, 29);
            this.LblShowNumber.Text = "显示手数：关";
            this.LblShowNumber.Click += new System.EventHandler(this.LblShowNumber_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 32);
            // 
            // LblSituation
            // 
            this.LblSituation.Name = "LblSituation";
            this.LblSituation.Size = new System.Drawing.Size(80, 29);
            this.LblSituation.Text = "形式判断：关";
            this.LblSituation.Click += new System.EventHandler(this.LblSituation_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton1.Text = "形势判断";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripBtnView
            // 
            this.toolStripBtnView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnView.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnView.Image")));
            this.toolStripBtnView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnView.Name = "toolStripBtnView";
            this.toolStripBtnView.Size = new System.Drawing.Size(29, 29);
            this.toolStripBtnView.Text = "棋局研究";
            this.toolStripBtnView.Click += new System.EventHandler(this.toolStripBtnView_Click);
            // 
            // LblLiberty
            // 
            this.LblLiberty.Name = "LblLiberty";
            this.LblLiberty.Size = new System.Drawing.Size(32, 29);
            this.LblLiberty.Text = "气：";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // FrmSingleModul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(624, 651);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.PicShow);
            this.Name = "FrmSingleModul";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "wfGoClient-单人打谱模式";
            this.Load += new System.EventHandler(this.FrmSingleModul_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicShow)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicShow;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonBlackAndWhite;
        private System.Windows.Forms.ToolStripButton toolStripButtonBalck;
        private System.Windows.Forms.ToolStripButton toolStripButtonWhite;
        private System.Windows.Forms.ToolStripButton toolStripButtonCross;
        private System.Windows.Forms.ToolStripButton toolStripButtonRegret;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonNew;
        private System.Windows.Forms.ToolStripLabel LblChoose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel LblLiberty;
        private System.Windows.Forms.ToolStripLabel LblShowNumber;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripLabel LblSituation;
        private System.Windows.Forms.ToolStripButton toolStripBtnView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}