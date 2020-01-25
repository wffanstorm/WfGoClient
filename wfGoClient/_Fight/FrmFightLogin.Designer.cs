namespace wfGoClient
{
    partial class FrmFightLogin
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtUserID = new System.Windows.Forms.TextBox();
            this.TxtPwd = new System.Windows.Forms.TextBox();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.linkLabelRegister = new System.Windows.Forms.LinkLabel();
            this.linkLabelForgetPwd = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码：";
            // 
            // TxtUserID
            // 
            this.TxtUserID.Location = new System.Drawing.Point(131, 61);
            this.TxtUserID.Name = "TxtUserID";
            this.TxtUserID.Size = new System.Drawing.Size(117, 21);
            this.TxtUserID.TabIndex = 2;
            // 
            // TxtPwd
            // 
            this.TxtPwd.Location = new System.Drawing.Point(131, 105);
            this.TxtPwd.Name = "TxtPwd";
            this.TxtPwd.PasswordChar = '*';
            this.TxtPwd.Size = new System.Drawing.Size(117, 21);
            this.TxtPwd.TabIndex = 3;
            // 
            // BtnLogin
            // 
            this.BtnLogin.Location = new System.Drawing.Point(168, 163);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(94, 47);
            this.BtnLogin.TabIndex = 4;
            this.BtnLogin.Text = "登录";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // linkLabelRegister
            // 
            this.linkLabelRegister.AutoSize = true;
            this.linkLabelRegister.Location = new System.Drawing.Point(144, 234);
            this.linkLabelRegister.Name = "linkLabelRegister";
            this.linkLabelRegister.Size = new System.Drawing.Size(29, 12);
            this.linkLabelRegister.TabIndex = 5;
            this.linkLabelRegister.TabStop = true;
            this.linkLabelRegister.Text = "注册";
            // 
            // linkLabelForgetPwd
            // 
            this.linkLabelForgetPwd.AutoSize = true;
            this.linkLabelForgetPwd.Location = new System.Drawing.Point(209, 234);
            this.linkLabelForgetPwd.Name = "linkLabelForgetPwd";
            this.linkLabelForgetPwd.Size = new System.Drawing.Size(53, 12);
            this.linkLabelForgetPwd.TabIndex = 6;
            this.linkLabelForgetPwd.TabStop = true;
            this.linkLabelForgetPwd.Text = "忘记密码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(254, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 60);
            this.label3.TabIndex = 7;
            this.label3.Text = "Debug:\r\n伪登录，\r\n用户名3个字符以上即可，\r\n密码为123，\r\n人为控制用户名不重复\r\n";
            // 
            // FrmFightLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 357);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.linkLabelForgetPwd);
            this.Controls.Add(this.linkLabelRegister);
            this.Controls.Add(this.BtnLogin);
            this.Controls.Add(this.TxtPwd);
            this.Controls.Add(this.TxtUserID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmFightLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "wfGoClient-联机模式登录";
            this.Load += new System.EventHandler(this.FrmFightLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtUserID;
        private System.Windows.Forms.TextBox TxtPwd;
        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.LinkLabel linkLabelRegister;
        private System.Windows.Forms.LinkLabel linkLabelForgetPwd;
        private System.Windows.Forms.Label label3;
    }
}