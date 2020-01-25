namespace wfGoClient
{
    partial class FrmANNTrain
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
            this.BtnSearchSGF = new System.Windows.Forms.Button();
            this.TxtPath = new System.Windows.Forms.TextBox();
            this.BtnStartTrain = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LblFileNumNow = new System.Windows.Forms.Label();
            this.LblFileNumAll = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // BtnSearchSGF
            // 
            this.BtnSearchSGF.Location = new System.Drawing.Point(461, 10);
            this.BtnSearchSGF.Name = "BtnSearchSGF";
            this.BtnSearchSGF.Size = new System.Drawing.Size(95, 23);
            this.BtnSearchSGF.TabIndex = 0;
            this.BtnSearchSGF.Text = "查找sgf文件";
            this.BtnSearchSGF.UseVisualStyleBackColor = true;
            this.BtnSearchSGF.Click += new System.EventHandler(this.BtnSearchSGF_Click);
            // 
            // TxtPath
            // 
            this.TxtPath.Location = new System.Drawing.Point(12, 12);
            this.TxtPath.Name = "TxtPath";
            this.TxtPath.Size = new System.Drawing.Size(443, 21);
            this.TxtPath.TabIndex = 1;
            // 
            // BtnStartTrain
            // 
            this.BtnStartTrain.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnStartTrain.Location = new System.Drawing.Point(124, 387);
            this.BtnStartTrain.Name = "BtnStartTrain";
            this.BtnStartTrain.Size = new System.Drawing.Size(373, 49);
            this.BtnStartTrain.TabIndex = 3;
            this.BtnStartTrain.Text = "开始训练";
            this.BtnStartTrain.UseVisualStyleBackColor = true;
            this.BtnStartTrain.Click += new System.EventHandler(this.BtnStartTrain_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(138, 456);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "正在分析文件：";
            // 
            // LblFileNumNow
            // 
            this.LblFileNumNow.AutoSize = true;
            this.LblFileNumNow.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblFileNumNow.Location = new System.Drawing.Point(326, 456);
            this.LblFileNumNow.Name = "LblFileNumNow";
            this.LblFileNumNow.Size = new System.Drawing.Size(79, 20);
            this.LblFileNumNow.TabIndex = 6;
            this.LblFileNumNow.Text = "filenow";
            // 
            // LblFileNumAll
            // 
            this.LblFileNumAll.AutoSize = true;
            this.LblFileNumAll.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblFileNumAll.Location = new System.Drawing.Point(418, 456);
            this.LblFileNumAll.Name = "LblFileNumAll";
            this.LblFileNumAll.Size = new System.Drawing.Size(79, 20);
            this.LblFileNumAll.TabIndex = 8;
            this.LblFileNumAll.Text = "fileall";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(401, 456);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "/";
            // 
            // ListBox1
            // 
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.ItemHeight = 12;
            this.ListBox1.Location = new System.Drawing.Point(12, 39);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(694, 340);
            this.ListBox1.TabIndex = 12;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmANNTrain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 538);
            this.Controls.Add(this.ListBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LblFileNumAll);
            this.Controls.Add(this.LblFileNumNow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnStartTrain);
            this.Controls.Add(this.TxtPath);
            this.Controls.Add(this.BtnSearchSGF);
            this.Name = "FrmANNTrain";
            this.Text = "FrmANNTrain";
            this.Load += new System.EventHandler(this.FrmANNTrain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSearchSGF;
        private System.Windows.Forms.TextBox TxtPath;
        private System.Windows.Forms.Button BtnStartTrain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblFileNumNow;
        private System.Windows.Forms.Label LblFileNumAll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox ListBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}