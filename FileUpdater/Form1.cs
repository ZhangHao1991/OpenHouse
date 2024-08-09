using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileUpdater
{
    public partial class Form1 : Form
    {
        private string ProgramName = "House.exe";
        private BackgroundWorker bgWorker;
        private WebClient wc;
        private string localFolder;
        private string[] serverFiles;
        private string[] serverVersions;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //先判断程序是否启动了，启动了就退出
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                MessageBox.Show("程序已经在运行中！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }


            //判断程序中是否有house程序，如果有就关闭掉
            foreach (Process p in Process.GetProcesses())
            {
                if (p.MainWindowTitle.Equals(ProgramName, StringComparison.OrdinalIgnoreCase))
                {
                    p.Kill();
                }
            }

            // 初始化BackgroundWorker
            bgWorker = new BackgroundWorker();
            bgWorker.WorkerReportsProgress = true;
            bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            bgWorker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_ProgressChanged);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);

            // 初始化WebClient
            wc = new WebClient();

            // 初始化本地文件夹
            localFolder = Application.StartupPath;

            // 获取服务器文件夹中所有文件的路径和版本号
            string serverFolder = Properties.Resources.ResourceManager.GetString("Shared Folder");
            serverFiles = Directory.GetFiles(serverFolder);
            serverVersions = new string[serverFiles.Length];
            for (int i = 0; i < serverFiles.Length; i++)
            {
                FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(serverFiles[i]);
                serverVersions[i] = versionInfo.FileVersion;
            }

            // 启动BackgroundWorker
            bgWorker.RunWorkerAsync();

        }
        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // 更新进度条
            progressBar1.Value = e.ProgressPercentage;

            // 输出日志信息
            //Debug.WriteLine($"ProgressChanged: {e.ProgressPercentage}, {e.UserState}");

            // 更新 RichTextBox 显示内容
            if (e.UserState != null)
            {
                richTextBox1.AppendText(DateTime.Now + "   " + e.UserState.ToString() + "\n");
            }
            else
            {
                richTextBox1.AppendText(DateTime.Now + "   [Empty UserState]\n");
            }

        }
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // 保存 richTextBox1 对象到局部变量
            RichTextBox localRichTextBox1 = richTextBox1;



            // 计算服务器文件夹中所有文件的总大小
            long totalSize = 0;
            foreach (string file in serverFiles)
            {
                if (Path.GetFileName(file) != "FileUpdater.exe")
                {
                    totalSize += new FileInfo(file).Length;
                }
            }

            // 动态调整进度条的Maximum属性
            bgWorker.ReportProgress(0, "开始下载更新...");
            int progress = 0;
            foreach (string file in serverFiles)
            {
                if (Path.GetFileName(file) != "start.exe")
                {
                    string localFile = Path.Combine(localFolder, Path.GetFileName(file));
                    string serverVersion = serverVersions[Array.IndexOf(serverFiles, file)];

                    if (!File.Exists(localFile) || FileVersionInfo.GetVersionInfo(localFile).FileVersion != serverVersion)
                    {
                        // 下载文件
                        wc.DownloadFile(file, localFile);

                        // 更新进度条的Maximum属性
                        progress += (int)(new FileInfo(file).Length * 100 / totalSize);
                        bgWorker.ReportProgress(progress, null);

                        // 更新RichTextBox和写入日志文件
                        string log = string.Format("{0}: {1} -> {2}", Path.GetFileName(file), FileVersionInfo.GetVersionInfo(localFile).FileVersion, serverVersion);
                        bgWorker.ReportProgress(progress, log);
                    }
                }
            }




            // 更新 richTextBox1
            if (localRichTextBox1 != null)
            {
                localRichTextBox1.Invoke(new Action(() =>
                {
                    localRichTextBox1.AppendText(DateTime.Now + "   更新任务已完成。\n");
                }));


            }

        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // 更新进度条
            progressBar1.Value = 100;

            // 显示消息框
            //MessageBox.Show("更新完成！");



            // 获取Updatelog文件夹路径和文件名
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Updatelog");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string fileName = "log" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            string filePath = Path.Combine(folderPath, fileName);

            // 将richTextBox1的内容写入文件
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.Write(richTextBox1.Text);
            }

            //MessageBox.Show("已保存到文件：" + filePath);





            try
            {
                Process.Start(Path.Combine(Application.StartupPath, ProgramName));  // 启动程序

                this.Close();   // 关闭更新窗口

                //// 关闭程序
                //Application.Exit();
                button1.Text = "打开程序";
                button1.Enabled = true;
                button2.Enabled = true;
            }
            catch
            {
                MessageBox.Show("未找到启动程序");
                this.Close();   // 关闭更新窗口
            }






            //if (MessageBox.Show("更新完成！是否立即启动程序？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            //{
            //    Process.Start(Path.Combine(Application.StartupPath, "house.exe"));  // 启动程序
            //    this.Close();   // 关闭更新窗口
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("更新完成！是否立即启动程序？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            //{
            //    Process.Start(Path.Combine(Application.StartupPath, "house.exe"));  // 启动程序
            //    this.Close();   // 关闭更新窗口
            //}

            Process.Start(Path.Combine(Application.StartupPath, "HouseHis.exe"));  // 启动程序
            Thread.Sleep(1000);
            this.Close();   // 关闭更新窗口
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 关闭程序
            Application.Exit();
        }
    }
}
