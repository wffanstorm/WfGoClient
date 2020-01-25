namespace wfGoClient
{
    public partial class FrmFightModul
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFightModul));
            this.PicShow = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.TxtWord = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblName2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblName1 = new System.Windows.Forms.Label();
            this.LVPlayer = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.PicShow)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.toolStripLabel1,
            this.toolStripButton1,
            this.toolStripSeparator3,
            this.toolStripSeparator6,
            this.toolStripLabel2,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripSeparator4,
            this.toolStripLabel3,
            this.toolStripButton3,
            this.toolStripSeparator5,
            this.toolStripSeparator2,
            this.toolStripLabel4,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(846, 32);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(56, 29);
            this.toolStripLabel1.Text = "申请开局";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton1.Text = "申请开局";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(56, 29);
            this.toolStripLabel2.Text = "请求悔棋";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton2.Text = "请求悔棋";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(56, 29);
            this.toolStripLabel3.Text = "终局确认";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton3.Text = "终局确认";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(56, 29);
            this.toolStripLabel4.Text = "发起投降";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton4.Text = "发起投降";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // TxtWord
            // 
            this.TxtWord.Location = new System.Drawing.Point(618, 400);
            this.TxtWord.Multiline = true;
            this.TxtWord.Name = "TxtWord";
            this.TxtWord.ReadOnly = true;
            this.TxtWord.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtWord.Size = new System.Drawing.Size(216, 235);
            this.TxtWord.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LblName2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.LblName1);
            this.groupBox1.Location = new System.Drawing.Point(618, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 117);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "对弈";
            // 
            // LblName2
            // 
            this.LblName2.AutoSize = true;
            this.LblName2.Font = new System.Drawing.Font("华文新魏", 15F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblName2.ForeColor = System.Drawing.Color.Blue;
            this.LblName2.Location = new System.Drawing.Point(113, 79);
            this.LblName2.Name = "LblName2";
            this.LblName2.Size = new System.Drawing.Size(74, 21);
            this.LblName2.TabIndex = 2;
            this.LblName2.Text = "name2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("华文行楷", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(87, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "VS";
            // 
            // LblName1
            // 
            this.LblName1.AutoSize = true;
            this.LblName1.Font = new System.Drawing.Font("华文新魏", 15F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblName1.ForeColor = System.Drawing.Color.Red;
            this.LblName1.Location = new System.Drawing.Point(21, 17);
            this.LblName1.Name = "LblName1";
            this.LblName1.Size = new System.Drawing.Size(71, 21);
            this.LblName1.TabIndex = 0;
            this.LblName1.Text = "name1";
            // 
            // LVPlayer
            // 
            this.LVPlayer.Location = new System.Drawing.Point(618, 158);
            this.LVPlayer.Name = "LVPlayer";
            this.LVPlayer.Size = new System.Drawing.Size(216, 236);
            this.LVPlayer.TabIndex = 4;
            this.LVPlayer.UseCompatibleStateImageBehavior = false;
            this.LVPlayer.View = System.Windows.Forms.View.List;
            // 
            // FrmFightModul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 651);
            this.Controls.Add(this.LVPlayer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TxtWord);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.PicShow);
            this.Name = "FrmFightModul";
            this.Text = "wfGoClient-";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmFightModul_FormClosing);
            this.Load += new System.EventHandler(this.FrmFightModul_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicShow)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.ToolStrip toolStrip1;

        private System.Windows.Forms.GroupBox groupBox1;

        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripButton toolStripButton4;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;

        public System.Windows.Forms.PictureBox PicShow;
        public System.Windows.Forms.TextBox TxtWord;
        public System.Windows.Forms.ListView LVPlayer;
        public System.Windows.Forms.Label LblName1;
        public System.Windows.Forms.Label LblName2;


    }
}