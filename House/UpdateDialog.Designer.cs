namespace House
{
    partial class UpdateDialog
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.textBoxUpdateLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(695, 397);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(67, 29);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Visible = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // textBoxUpdateLog
            // 
            this.textBoxUpdateLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUpdateLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxUpdateLog.Font = new System.Drawing.Font("宋体", 11F);
            this.textBoxUpdateLog.Location = new System.Drawing.Point(12, 12);
            this.textBoxUpdateLog.Multiline = true;
            this.textBoxUpdateLog.Name = "textBoxUpdateLog";
            this.textBoxUpdateLog.ReadOnly = true;
            this.textBoxUpdateLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxUpdateLog.Size = new System.Drawing.Size(776, 426);
            this.textBoxUpdateLog.TabIndex = 4;
            this.textBoxUpdateLog.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UpdateDialog_MouseDown);
            // 
            // UpdateDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxUpdateLog);
            this.Name = "UpdateDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "更新日志";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.UpdateDialog_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UpdateDialog_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TextBox textBoxUpdateLog;
    }
}