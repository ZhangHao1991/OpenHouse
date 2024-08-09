using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileUpdater
{
    // 定义类
    public class UpdateLocalFiles
    {
        // 定义共享文件夹路径
        private string sharedFolderPath = @"\\\\192.168.0.20\\Share\\";

        // 定义本地文件夹路径
        private string localFolderPath = Path.GetDirectoryName(Application.ExecutablePath);

        // 定义日志文件路径
        private string logFilePath = Application.StartupPath + @"\\log.txt";

        // 定义日志文件流写入器
        private StreamWriter logFileWriter;

        // 定义进度条
        private ProgressBar progressBar;

        // 定义richTextBox1用于日志输出
        private RichTextBox logBox;

        // 定义构造函数
        public UpdateLocalFiles(ProgressBar progressBar, RichTextBox logBox)
        {
            // 初始化进度条和日志框
            this.progressBar = progressBar;
            this.logBox = logBox;

            // 初始化日志文件流写入器
            logFileWriter = new StreamWriter(logFilePath, true);

            // 将起始消息写入日志
            logBox.AppendText("[" + DateTime.Now.ToString() + "] 开始更新本地文件...\\n");
            logFileWriter.WriteLine("[" + DateTime.Now.ToString() + "] 开始更新本地文件...");
        }

        // 定义更新本地文件的方法
        public void UpdateFiles()
        {
            // 获取本地文件列表
            string[] localFiles = Directory.GetFiles(localFolderPath);

            // 遍历每个文件并检查是否需要更新
            foreach (string localFilePath in localFiles)
            {
                string localFileName = Path.GetFileName(localFilePath);

                // 检查共享文件夹中是否存在该文件
                if (File.Exists(sharedFolderPath + localFileName))
                {
                    // 比较本地文件和共享文件的修改时间
                    DateTime localFileModificationTime = File.GetLastWriteTime(localFilePath);
                    DateTime sharedFileModificationTime = File.GetLastWriteTime(sharedFolderPath + localFileName);

                    // 如果共享文件较新，则下载并替换本地文件
                    if (sharedFileModificationTime > localFileModificationTime)
                    {
                        // 将更新消息写入日志
                        logBox.AppendText("[" + DateTime.Now.ToString() + "] 正在更新 " + localFileName + "...\\n");
                        logFileWriter.WriteLine("[" + DateTime.Now.ToString() + "] 正在更新 " + localFileName + "...");

                        // 下载共享文件
                        WebClient client = new WebClient();
                        client.DownloadFile(sharedFolderPath + localFileName, localFilePath);

                        // 更新进度条
                        progressBar.Value += 1;
                    }
                }
                // 如果本地文件不存在，则从共享文件夹中下载文件
                else
                {
                    // 将下载消息写入日志
                    logBox.AppendText("[" + DateTime.Now.ToString() + "] 正在下载 " + localFileName + "...\\n");
                    logFileWriter.WriteLine("[" + DateTime.Now.ToString() + "] 正在下载 " + localFileName + "...");

                    // 下载共享文件
                    WebClient client = new WebClient();
                    client.DownloadFile(sharedFolderPath + localFileName, localFolderPath + localFileName);

                    // 更新进度条
                    progressBar.Value += 1;
                }
            }
            // 释放日志文件流写入器
            logFileWriter.Dispose();

            // 将完成消息写入日志
            logBox.AppendText("[" + DateTime.Now.ToString() + "] 更新本地文件完成。\\n");
            logFileWriter.WriteLine("[" + DateTime.Now.ToString() + "] 更新本地文件完成。");
        }
    }
}
