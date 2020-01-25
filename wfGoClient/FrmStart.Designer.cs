namespace wfGoClient
{
    public partial class FrmStart
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnSingleModul = new System.Windows.Forms.Button();
            this.BtnFightModul = new System.Windows.Forms.Button();
            this.BtnAIModul = new System.Windows.Forms.Button();
            this.BtnQiPu = new System.Windows.Forms.Button();
            this.BtnANNTrain = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnSingleModul
            // 
            this.BtnSingleModul.Location = new System.Drawing.Point(51, 55);
            this.BtnSingleModul.Name = "BtnSingleModul";
            this.BtnSingleModul.Size = new System.Drawing.Size(168, 58);
            this.BtnSingleModul.TabIndex = 0;
            this.BtnSingleModul.Text = "单人打谱模式";
            this.BtnSingleModul.UseVisualStyleBackColor = true;
            this.BtnSingleModul.Click += new System.EventHandler(this.BtnSingleModul_Click);
            // 
            // BtnFightModul
            // 
            this.BtnFightModul.Location = new System.Drawing.Point(51, 147);
            this.BtnFightModul.Name = "BtnFightModul";
            this.BtnFightModul.Size = new System.Drawing.Size(168, 58);
            this.BtnFightModul.TabIndex = 1;
            this.BtnFightModul.Text = "联机对弈模式";
            this.BtnFightModul.UseVisualStyleBackColor = true;
            this.BtnFightModul.Click += new System.EventHandler(this.BtnFightModul_Click);
            // 
            // BtnAIModul
            // 
            this.BtnAIModul.Location = new System.Drawing.Point(51, 239);
            this.BtnAIModul.Name = "BtnAIModul";
            this.BtnAIModul.Size = new System.Drawing.Size(168, 58);
            this.BtnAIModul.TabIndex = 2;
            this.BtnAIModul.Text = "AI对弈模式";
            this.BtnAIModul.UseVisualStyleBackColor = true;
            this.BtnAIModul.Click += new System.EventHandler(this.BtnAIModul_Click);
            // 
            // BtnQiPu
            // 
            this.BtnQiPu.Location = new System.Drawing.Point(271, 55);
            this.BtnQiPu.Name = "BtnQiPu";
            this.BtnQiPu.Size = new System.Drawing.Size(168, 58);
            this.BtnQiPu.TabIndex = 3;
            this.BtnQiPu.Text = "棋谱研究";
            this.BtnQiPu.UseVisualStyleBackColor = true;
            this.BtnQiPu.Click += new System.EventHandler(this.BtnQiPu_Click);
            // 
            // BtnANNTrain
            // 
            this.BtnANNTrain.Location = new System.Drawing.Point(271, 239);
            this.BtnANNTrain.Name = "BtnANNTrain";
            this.BtnANNTrain.Size = new System.Drawing.Size(168, 58);
            this.BtnANNTrain.TabIndex = 4;
            this.BtnANNTrain.Text = "ANN训练";
            this.BtnANNTrain.UseVisualStyleBackColor = true;
            this.BtnANNTrain.Click += new System.EventHandler(this.BtnANNTrain_Click);
            // 
            // FrmStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 401);
            this.Controls.Add(this.BtnANNTrain);
            this.Controls.Add(this.BtnQiPu);
            this.Controls.Add(this.BtnAIModul);
            this.Controls.Add(this.BtnFightModul);
            this.Controls.Add(this.BtnSingleModul);
            this.Name = "FrmStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "wfGoClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmStart_FormClosing);
            this.Load += new System.EventHandler(this.FrmStart_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnSingleModul;
        private System.Windows.Forms.Button BtnFightModul;
        private System.Windows.Forms.Button BtnAIModul;
        private System.Windows.Forms.Button BtnQiPu;
        private System.Windows.Forms.Button BtnANNTrain;
    }
}

