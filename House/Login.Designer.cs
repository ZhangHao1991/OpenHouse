namespace House
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.button_update = new System.Windows.Forms.Button();
            this.textBox_NewPw = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox_checkPW = new System.Windows.Forms.CheckBox();
            this.checkBox_remember = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_exit = new System.Windows.Forms.Button();
            this.button_login = new System.Windows.Forms.Button();
            this.textBox_pw = new System.Windows.Forms.TextBox();
            this.textBox_user = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_update
            // 
            this.button_update.Location = new System.Drawing.Point(128, 270);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(113, 42);
            this.button_update.TabIndex = 35;
            this.button_update.Text = "修改";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Visible = false;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // textBox_NewPw
            // 
            this.textBox_NewPw.Location = new System.Drawing.Point(198, 226);
            this.textBox_NewPw.Name = "textBox_NewPw";
            this.textBox_NewPw.Size = new System.Drawing.Size(170, 26);
            this.textBox_NewPw.TabIndex = 34;
            this.textBox_NewPw.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_NewPw.Visible = false;
            this.textBox_NewPw.WordWrap = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(96, 217);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 35);
            this.label5.TabIndex = 33;
            this.label5.Text = "新密码";
            this.label5.Visible = false;
            // 
            // checkBox_checkPW
            // 
            this.checkBox_checkPW.AutoSize = true;
            this.checkBox_checkPW.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_checkPW.Location = new System.Drawing.Point(230, 337);
            this.checkBox_checkPW.Name = "checkBox_checkPW";
            this.checkBox_checkPW.Size = new System.Drawing.Size(90, 20);
            this.checkBox_checkPW.TabIndex = 32;
            this.checkBox_checkPW.Text = "修改密码";
            this.checkBox_checkPW.UseVisualStyleBackColor = false;
            this.checkBox_checkPW.CheckedChanged += new System.EventHandler(this.checkBox_checkPW_CheckedChanged);
            // 
            // checkBox_remember
            // 
            this.checkBox_remember.AutoSize = true;
            this.checkBox_remember.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_remember.Location = new System.Drawing.Point(198, 223);
            this.checkBox_remember.Name = "checkBox_remember";
            this.checkBox_remember.Size = new System.Drawing.Size(122, 20);
            this.checkBox_remember.TabIndex = 27;
            this.checkBox_remember.Text = "记住账户密码";
            this.checkBox_remember.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(345, 338);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 16);
            this.label4.TabIndex = 29;
            this.label4.Text = "版权所有：张  浩";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(50, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(401, 62);
            this.label3.TabIndex = 28;
            this.label3.Text = "Work For House";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(304, 270);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(113, 42);
            this.button_exit.TabIndex = 31;
            this.button_exit.Text = "退出";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(127, 270);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(113, 42);
            this.button_login.TabIndex = 30;
            this.button_login.Text = "登录";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // textBox_pw
            // 
            this.textBox_pw.Location = new System.Drawing.Point(198, 173);
            this.textBox_pw.Name = "textBox_pw";
            this.textBox_pw.Size = new System.Drawing.Size(170, 26);
            this.textBox_pw.TabIndex = 26;
            this.textBox_pw.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_pw.UseSystemPasswordChar = true;
            this.textBox_pw.WordWrap = false;
            this.textBox_pw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_pw_KeyDown);
            // 
            // textBox_user
            // 
            this.textBox_user.Location = new System.Drawing.Point(198, 116);
            this.textBox_user.Name = "textBox_user";
            this.textBox_user.Size = new System.Drawing.Size(170, 26);
            this.textBox_user.TabIndex = 25;
            this.textBox_user.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_user.WordWrap = false;
            this.textBox_user.TextChanged += new System.EventHandler(this.textBox_user_TextChanged);
            this.textBox_user.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_user_KeyDown);
            this.textBox_user.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_user_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(123, 165);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 35);
            this.label2.TabIndex = 23;
            this.label2.Text = "密码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(123, 111);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 35);
            this.label1.TabIndex = 24;
            this.label1.Text = "账户";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::House.Properties.Resources.login_bj;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(500, 374);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.textBox_NewPw);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBox_checkPW);
            this.Controls.Add(this.checkBox_remember);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.textBox_pw);
            this.Controls.Add(this.textBox_user);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "House登陆系统";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.TextBox textBox_NewPw;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox_checkPW;
        private System.Windows.Forms.CheckBox checkBox_remember;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.TextBox textBox_pw;
        private System.Windows.Forms.TextBox textBox_user;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}