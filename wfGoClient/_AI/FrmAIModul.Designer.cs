namespace wfGoClient
{
    partial class FrmAIModul
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAIModul));
            this.PicShow = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnRegret = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.LblShowNumber = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.LblSituation = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnJudge = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnView = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.LblIsBlack = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.LblAIDifficult = new System.Windows.Forms.ToolStripLabel();
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
            this.PicShow.Paint += new System.Windows.Forms.PaintEventHandler(this.PicShow_Paint);
            this.PicShow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicShow_MouseUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.BtnRegret,
            this.toolStripButton3,
            this.toolStripSeparator2,
            this.LblShowNumber,
            this.toolStripSeparator3,
            this.LblSituation,
            this.toolStripSeparator4,
            this.BtnJudge,
            this.toolStripSeparator5,
            this.BtnView,
            this.toolStripSeparator6,
            this.toolStripSeparator7,
            this.toolStripSeparator8,
            this.toolStripSeparator9,
            this.LblIsBlack,
            this.toolStripSeparator10,
            this.LblAIDifficult});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(624, 32);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton1.Text = "开始";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // BtnRegret
            // 
            this.BtnRegret.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnRegret.Image = ((System.Drawing.Image)(resources.GetObject("BtnRegret.Image")));
            this.BtnRegret.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnRegret.Name = "BtnRegret";
            this.BtnRegret.Size = new System.Drawing.Size(29, 29);
            this.BtnRegret.Text = "悔棋";
            this.BtnRegret.Click += new System.EventHandler(this.BtnRegret_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton3.Text = "投降";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // LblShowNumber
            // 
            this.LblShowNumber.Name = "LblShowNumber";
            this.LblShowNumber.Size = new System.Drawing.Size(80, 29);
            this.LblShowNumber.Text = "显示手数：关";
            this.LblShowNumber.Click += new System.EventHandler(this.LblShowNumber_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
            // 
            // LblSituation
            // 
            this.LblSituation.Name = "LblSituation";
            this.LblSituation.Size = new System.Drawing.Size(80, 29);
            this.LblSituation.Text = "形势判断：关";
            this.LblSituation.Click += new System.EventHandler(this.LblSituation_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 32);
            // 
            // BtnJudge
            // 
            this.BtnJudge.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnJudge.Image = ((System.Drawing.Image)(resources.GetObject("BtnJudge.Image")));
            this.BtnJudge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnJudge.Name = "BtnJudge";
            this.BtnJudge.Size = new System.Drawing.Size(29, 29);
            this.BtnJudge.Text = "形势判断";
            this.BtnJudge.Click += new System.EventHandler(this.BtnJudge_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 32);
            // 
            // BtnView
            // 
            this.BtnView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnView.Image = ((System.Drawing.Image)(resources.GetObject("BtnView.Image")));
            this.BtnView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnView.Name = "BtnView";
            this.BtnView.Size = new System.Drawing.Size(29, 29);
            this.BtnView.Text = "棋局研究";
            this.BtnView.Click += new System.EventHandler(this.BtnView_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 32);
            // 
            // LblIsBlack
            // 
            this.LblIsBlack.Name = "LblIsBlack";
            this.LblIsBlack.Size = new System.Drawing.Size(44, 29);
            this.LblIsBlack.Text = "未开始";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 32);
            // 
            // LblAIDifficult
            // 
            this.LblAIDifficult.Name = "LblAIDifficult";
            this.LblAIDifficult.Size = new System.Drawing.Size(44, 29);
            this.LblAIDifficult.Text = "未开始";
            // 
            // FrmAIModul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 651);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.PicShow);
            this.Name = "FrmAIModul";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "wfGoClient-AI对弈模式";
            this.Load += new System.EventHandler(this.FrmAIModul_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicShow)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicShow;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BtnRegret;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel LblShowNumber;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel LblSituation;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton BtnJudge;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton BtnView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripLabel LblIsBlack;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripLabel LblAIDifficult;
    }
}