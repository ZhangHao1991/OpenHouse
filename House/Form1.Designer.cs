namespace House
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("病人管理", 9);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("跟进提醒", 7);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("订房卡", 14);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("订房类型管理", 15);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("地址管理", 17);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("项目管理", 10);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("报表管理", 6);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("医技工作站", 16);
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("科室员工管理", 4);
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("打印机设置", 18);
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem("套餐管理", 8);
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem("分娩登记台", 12);
            System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem("孕期计算器", 0);
            System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem("ReportPacs", 13);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.业务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.同步科室人员信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.同步地址信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入数据表格临时使用ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.扩展ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.报表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更新日志ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largeImageList = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_user = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_nowtime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_dataGridView_list = new System.Windows.Forms.ToolStripStatusLabel();
            this.time_nowtime = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.listViewEx = new System.Windows.Forms.ListView();
            this.menuStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.业务ToolStripMenuItem,
            this.扩展ToolStripMenuItem,
            this.报表ToolStripMenuItem,
            this.查看ToolStripMenuItem,
            this.窗口ToolStripMenuItem,
            this.帮助ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(924, 25);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 业务ToolStripMenuItem
            // 
            this.业务ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.同步科室人员信息ToolStripMenuItem,
            this.同步地址信息ToolStripMenuItem,
            this.导入数据表格临时使用ToolStripMenuItem});
            this.业务ToolStripMenuItem.Enabled = false;
            this.业务ToolStripMenuItem.Name = "业务ToolStripMenuItem";
            this.业务ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.业务ToolStripMenuItem.Text = "业务";
            // 
            // 同步科室人员信息ToolStripMenuItem
            // 
            this.同步科室人员信息ToolStripMenuItem.Name = "同步科室人员信息ToolStripMenuItem";
            this.同步科室人员信息ToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.同步科室人员信息ToolStripMenuItem.Text = "同步科室人员信息";
            // 
            // 同步地址信息ToolStripMenuItem
            // 
            this.同步地址信息ToolStripMenuItem.Name = "同步地址信息ToolStripMenuItem";
            this.同步地址信息ToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.同步地址信息ToolStripMenuItem.Text = "同步地址信息";
            // 
            // 导入数据表格临时使用ToolStripMenuItem
            // 
            this.导入数据表格临时使用ToolStripMenuItem.Name = "导入数据表格临时使用ToolStripMenuItem";
            this.导入数据表格临时使用ToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.导入数据表格临时使用ToolStripMenuItem.Text = "导入数据表格（临时使用）";
            // 
            // 扩展ToolStripMenuItem
            // 
            this.扩展ToolStripMenuItem.Name = "扩展ToolStripMenuItem";
            this.扩展ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.扩展ToolStripMenuItem.Text = "扩展";
            // 
            // 报表ToolStripMenuItem
            // 
            this.报表ToolStripMenuItem.Name = "报表ToolStripMenuItem";
            this.报表ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.报表ToolStripMenuItem.Text = "报表";
            // 
            // 查看ToolStripMenuItem
            // 
            this.查看ToolStripMenuItem.Name = "查看ToolStripMenuItem";
            this.查看ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.查看ToolStripMenuItem.Text = "查看";
            // 
            // 窗口ToolStripMenuItem
            // 
            this.窗口ToolStripMenuItem.Name = "窗口ToolStripMenuItem";
            this.窗口ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.窗口ToolStripMenuItem.Text = "窗口";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.更新日志ToolStripMenuItem});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // 更新日志ToolStripMenuItem
            // 
            this.更新日志ToolStripMenuItem.Name = "更新日志ToolStripMenuItem";
            this.更新日志ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.更新日志ToolStripMenuItem.Text = "更新日志";
            this.更新日志ToolStripMenuItem.Click += new System.EventHandler(this.更新日志ToolStripMenuItem_Click);
            // 
            // largeImageList
            // 
            this.largeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("largeImageList.ImageStream")));
            this.largeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.largeImageList.Images.SetKeyName(0, "分娩登记.png");
            this.largeImageList.Images.SetKeyName(1, "记录特况.png");
            this.largeImageList.Images.SetKeyName(2, "建档.png");
            this.largeImageList.Images.SetKeyName(3, "报修管理备份2x.png");
            this.largeImageList.Images.SetKeyName(4, "产业链.png");
            this.largeImageList.Images.SetKeyName(5, "访客预约备份.png");
            this.largeImageList.Images.SetKeyName(6, "工单报表备份.png");
            this.largeImageList.Images.SetKeyName(7, "活动报名备份 2.png");
            this.largeImageList.Images.SetKeyName(8, "科技产业服务备份 2.png");
            this.largeImageList.Images.SetKeyName(9, "客户管理.png");
            this.largeImageList.Images.SetKeyName(10, "通道管理.png");
            this.largeImageList.Images.SetKeyName(11, "新建不合格单备份.png");
            this.largeImageList.Images.SetKeyName(12, "账单管理.png");
            this.largeImageList.Images.SetKeyName(13, "综合能耗备份.png");
            this.largeImageList.Images.SetKeyName(14, "银行卡.png");
            this.largeImageList.Images.SetKeyName(15, "52_卡片管理.png");
            this.largeImageList.Images.SetKeyName(16, "医技工作站.png");
            this.largeImageList.Images.SetKeyName(17, "地址管理2.png");
            this.largeImageList.Images.SetKeyName(18, "打印机.png");
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel_user,
            this.toolStripStatusLabel5,
            this.Label_nowtime,
            this.toolStripStatusLabel7,
            this.toolStripStatusLabel_dataGridView_list});
            this.statusStrip.Location = new System.Drawing.Point(0, 477);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(924, 22);
            this.statusStrip.TabIndex = 19;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(30, 3, 0, 2);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel1.Text = "所属单位：";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(104, 17);
            this.toolStripStatusLabel2.Text = "聊城水城妇产医院";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Margin = new System.Windows.Forms.Padding(30, 3, 0, 2);
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(80, 17);
            this.toolStripStatusLabel3.Text = "当前操作人：";
            // 
            // toolStripStatusLabel_user
            // 
            this.toolStripStatusLabel_user.Name = "toolStripStatusLabel_user";
            this.toolStripStatusLabel_user.Size = new System.Drawing.Size(29, 17);
            this.toolStripStatusLabel_user.Text = "007";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Margin = new System.Windows.Forms.Padding(30, 3, 0, 2);
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel5.Text = "系统时间：";
            // 
            // Label_nowtime
            // 
            this.Label_nowtime.Name = "Label_nowtime";
            this.Label_nowtime.Size = new System.Drawing.Size(56, 17);
            this.Label_nowtime.Text = "未初始化";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Margin = new System.Windows.Forms.Padding(30, 3, 0, 2);
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(100, 17);
            this.toolStripStatusLabel7.Text = "版权所有：张  浩";
            this.toolStripStatusLabel7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripStatusLabel_dataGridView_list
            // 
            this.toolStripStatusLabel_dataGridView_list.Name = "toolStripStatusLabel_dataGridView_list";
            this.toolStripStatusLabel_dataGridView_list.Size = new System.Drawing.Size(0, 17);
            // 
            // time_nowtime
            // 
            this.time_nowtime.Enabled = true;
            this.time_nowtime.Interval = 1000;
            this.time_nowtime.Tick += new System.EventHandler(this.time_nowtime_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Bisque;
            this.panel1.Controls.Add(this.listViewEx);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(924, 452);
            this.panel1.TabIndex = 20;
            // 
            // listViewEx
            // 
            this.listViewEx.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listViewEx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewEx.BackColor = System.Drawing.Color.Bisque;
            this.listViewEx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewEx.ForeColor = System.Drawing.Color.Black;
            this.listViewEx.HideSelection = false;
            listViewItem14.ToolTipText = "ReportPacs";
            this.listViewEx.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10,
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14});
            this.listViewEx.LargeImageList = this.largeImageList;
            this.listViewEx.Location = new System.Drawing.Point(3, 15);
            this.listViewEx.Name = "listViewEx";
            this.listViewEx.Size = new System.Drawing.Size(918, 423);
            this.listViewEx.TabIndex = 19;
            this.listViewEx.UseCompatibleStateImageBehavior = false;
            this.listViewEx.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListViewEx_MouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 499);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "House";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 业务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 同步科室人员信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 同步地址信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入数据表格临时使用ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 扩展ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 报表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 窗口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更新日志ToolStripMenuItem;
        private System.Windows.Forms.ImageList largeImageList;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_user;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel Label_nowtime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_dataGridView_list;
        private System.Windows.Forms.Timer time_nowtime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listViewEx;
    }
}

