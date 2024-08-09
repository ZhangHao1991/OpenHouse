using HaoLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace House
{
    public partial class UpdateDialog : Form
    {
        SqlHelp sqlHelper = new SqlHelp();
        public UpdateDialog()
        {
            InitializeComponent();
        }
        private Timer timer;
        private int countDown = 4;
        private void buttonOK_Click(object sender, EventArgs e)
        {

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            countDown--;
            UpdateTitle();

            if (countDown == 0)
            {
                ((Timer)sender).Stop();
                this.Close();
            }
        }
        private void UpdateDialog_Load(object sender, EventArgs e)
        {
            textBoxUpdateLog.Text = "";
            string query = "SELECT Version, LogText FROM HH_UpdateLog ORDER BY ID DESC";
            DataTable result = sqlHelper.GetDataTableValue(query);

            StringBuilder sb = new StringBuilder();

            foreach (DataRow row in result.Rows)
            {
                string version = row["Version"].ToString();
                string logText = row["LogText"].ToString();

                sb.AppendLine($"[{version}]");
                sb.AppendLine(logText);
                sb.AppendLine();
            }

            string updateLog = sb.ToString();
            textBoxUpdateLog.Text = updateLog;




            timer = new Timer();
            timer.Interval = 1000; // 1秒
            timer.Tick += Timer_Tick;
            timer.Start();

            UpdateTitle();
        }
        private void UpdateTitle()
        {
            this.Text = $"更新日志对话框 ({countDown} 秒后关闭)";
        }

        private void UpdateDialog_MouseDown(object sender, MouseEventArgs e)
        {
            timer.Stop();
            this.Text = $"更新日志对话框";
        }
    }
}
