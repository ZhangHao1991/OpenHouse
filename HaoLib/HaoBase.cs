using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HaoLib
{
    public class HaoBase
    {
        /// <summary>
        /// 导出Dategridview到表格
        /// </summary>
        /// <param name="dataGridView"></param>
        public static void OutTable(DataGridView dataGridView)
        {
            string fileName = "当前表格" + DateTime.Now.ToString("yyyyMMddHHmmss");
            string saveFileName = "";//文件保存名
            SaveFileDialog saveDialog = new SaveFileDialog();//实例化文件对象
            saveDialog.DefaultExt = "xlsx";//文件默认扩展名
            saveDialog.Filter = "Excel文件|*.xlsx";//获取或设置当前文件名筛选器字符串，该字符串决定对话框的“另存为文件类型”或“文件类型”框中出现的选择内容。
            saveDialog.FileName = fileName;
            saveDialog.ShowDialog();//打开保存窗口给你选择路径和设置文件名
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，您的电脑可能未安装Excel");
                return;
            }

            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;//Workbooks代表一个 Microsoft Excel 工作簿
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);//新建一个工作表。 新工作表将成为活动工作表。
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1 
                                                                                                                                  //写入标题             
            for (int i = 0; i < dataGridView.ColumnCount; i++)//遍历循环获取DataGridView标题
            { worksheet.Cells[1, i + 1] = dataGridView.Columns[i].HeaderText; }// worksheet.Cells[1, i + 1]表示工作簿第一行第i+1列，Columns[i].HeaderText表示第i列的表头


            //写入数值
            for (int r = 0; r < dataGridView.Rows.Count; r++)//这里表示数据的行标,dataGridView.Rows.Count表示行数
            {
                for (int i = 0; i < dataGridView.ColumnCount; i++)//遍历r行的列数
                {
                    worksheet.Cells[r + 2, i + 1] = dataGridView.Rows[r].Cells[i].Value;//Cells[r + 2, i + 1]表示工作簿从第二行开始第一行保存为表头了，dataGridView.Rows[r].Cells[i].Value获取列的r行i值
                }
                System.Windows.Forms.Application.DoEvents();//实时更新表格
            }

            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
            MessageBox.Show(fileName + "资料保存成功", "提示", MessageBoxButtons.OK);//提示保存成功
            if (saveFileName != "")//saveFileName保存文件名不为空
            {
                try
                {
                    workbook.Saved = true;//获取或设置一个值，该值指示工作簿自上次保存以来是否进行了更改
                    workbook.SaveCopyAs(saveFileName);  //fileSaved = true;将工作簿副本保存到文件中，但不修改内存中打开的工作簿                 
                }
                catch (Exception ex)
                {//fileSaved = false;                      
                    MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                }
            }
            xlApp.Quit();
            GC.Collect();//强行销毁    
        }


        /// <summary>
        /// 判断是否为数字
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool IsNumber(string a)
        {
            if (string.IsNullOrEmpty(a))
                return false;
            foreach (char c in a)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 过滤非法字符
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetSafeValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;
            value = Regex.Replace(value, @";", string.Empty);
            value = Regex.Replace(value, @"'", string.Empty);
            value = Regex.Replace(value, @"&", string.Empty);
            value = Regex.Replace(value, @"%20", string.Empty);
            value = Regex.Replace(value, @"--", string.Empty);
            value = Regex.Replace(value, @"==", string.Empty);
            value = Regex.Replace(value, @"<", string.Empty);
            value = Regex.Replace(value, @">", string.Empty);
            value = Regex.Replace(value, @"%", string.Empty);
            return value;
        }



        
        /// <summary>
        /// 写入数据库信息文件的方法
        /// </summary>
        /// <param name="s">数据库信息文件名</param>
        /// <returns></returns>
        public static bool DatabaseFileWrite(string datebaseFile)
        {
            // 获取程序运行目录
            string runningDirectory = AppDomain.CurrentDomain.BaseDirectory;
            // 设置文件路径为程序运行目录下的s文件
            string filePath = Path.Combine(runningDirectory, datebaseFile);

            // 检查文件是否存在
            if (!File.Exists(filePath))
            {
                // 文件不存在，创建文件并写入内容
                try
                {
                    // 创建文件
                    using (StreamWriter sw = File.CreateText(filePath))
                    {
                        // 写入内容
                        sw.WriteLine("IP=192.168.0.3");
                        sw.WriteLine("dateName=House");
                        sw.WriteLine("user=sa");
                        sw.WriteLine("pwd=123");
                    }

                    Console.WriteLine("文件已创建并写入内容。");
                    return true;
                }
                catch (Exception ex)
                {
                    // 如果有错误，打印错误信息
                    Console.WriteLine("创建文件时发生错误: " + ex.Message);
                    return false;
                }
            }
            else
            {
                // 文件已存在
                Console.WriteLine("文件已存在。");
                return false;
            }
        }

        /// <summary>
        /// 读取数据库信息文件的方法
        /// </summary>
        /// <param name="ip">返回ip结果，用out接收</param>
        /// <param name="dateName">返回dateName结果，用out接收</param>
        /// <param name="user">返回user结果，用out接收</param>
        /// <param name="pwd">返回pwd结果，用out接收</param>
        public static bool DatabaseFileRead(string datebaseFile,out string ip, out string dateName, out string user, out string pwd)
        {
            // 初始化输出参数
            ip = null;
            dateName = null;
            user = null;
            pwd = null;

            // 获取程序运行目录
            string runningDirectory = AppDomain.CurrentDomain.BaseDirectory;
            // 设置文件路径为程序运行目录下的数据库信息文件
            string filePath = Path.Combine(runningDirectory, datebaseFile);

            // 检查文件是否存在
            if (File.Exists(filePath))
            {
                try
                {
                    // 读取文件中的每一行
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        // 拆分键和值
                        string[] parts = line.Split('=');
                        if (parts.Length == 2)
                        {
                            string key = parts[0].Trim();
                            string value = parts[1].Trim();

                            // 根据键设置对应的值
                            switch (key)
                            {
                                case "IP":
                                    ip = value;
                                    break;
                                case "dateName":
                                    dateName = value;
                                    break;
                                case "user":
                                    user = value;
                                    break;
                                case "pwd":
                                    pwd = value;
                                    break;
                            }
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    // 如果有错误，打印错误信息
                    Console.WriteLine("读取文件时发生错误: " + ex.Message);
                    return false;
                }
            }
            else
            {
                // 文件不存在
                Console.WriteLine("数据库信息文件不存在。");
                return false;
            }
        }


        /// <summary>
        /// 更新数据库信息文件中的值  公共静态方法
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="dateName"></param>
        /// <param name="user"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static bool DatabaseFileUpdate(string ip, string dateName, string user, string pwd)
        {
            // 获取程序运行目录
            string runningDirectory = AppDomain.CurrentDomain.BaseDirectory;
            // 设置文件路径为程序运行目录下的数据库信息文件
            string filePath = Path.Combine(runningDirectory, "databaseInfo.txt");

            // 检查文件是否存在
            if (File.Exists(filePath))
            {
                try
                {
                    // 读取现有文件内容到内存
                    string[] lines = File.ReadAllLines(filePath);
                    // 创建一个列表来存储更新后的内容
                    List<string> updatedLines = new List<string>();

                    // 遍历每一行，寻找需要更新的键
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split('=');
                        if (parts.Length == 2)
                        {
                            string key = parts[0].Trim();
                            string value = parts[1].Trim();

                            // 根据键更新对应的值
                            switch (key)
                            {
                                case "IP":
                                    updatedLines.Add($"IP={ip}");
                                    break;
                                case "dateName":
                                    updatedLines.Add($"dateName={dateName}");
                                    break;
                                case "user":
                                    updatedLines.Add($"user={user}");
                                    break;
                                case "pwd":
                                    updatedLines.Add($"pwd={pwd}");
                                    break;
                                default:
                                    // 如果不是我们要更新的键，保留原行
                                    updatedLines.Add(line);
                                    break;
                            }
                        }
                        else
                        {
                            // 如果行格式不正确，保留原行
                            updatedLines.Add(line);
                        }
                    }

                    // 将更新后的内容写回文件
                    File.WriteAllLines(filePath, updatedLines);

                    // 更新成功
                    return true;
                }
                catch (Exception ex)
                {
                    // 如果有错误，这里可以记录日志或打印错误信息
                     Console.WriteLine("更新文件时发生错误: " + ex.Message);
                    // 更新失败
                    return false;
                }
            }
            else
            {
                // 文件不存在，无法更新
                Console.WriteLine("文件不存在。");
                return false;
            }
        }




        /// <summary>
        /// 弹出一个输入框，一般用来读取就诊码或者是健康码，目前用健康码
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        public static string ShowInputDialog(string prompt)
        {
            Form inputForm = new Form();
            Label lblPrompt = new Label();
            TextBox txtInput = new TextBox();
            Button btnOk = new Button();

            inputForm.Text = "输入对话框";
            lblPrompt.Text = prompt;
            btnOk.Text = "确认";
            btnOk.DialogResult = DialogResult.OK;

            lblPrompt.SetBounds(9, 20, 372, 13);
            txtInput.SetBounds(12, 36, 372, 20);
            btnOk.SetBounds(309, 72, 75, 23);

            lblPrompt.AutoSize = true;
            txtInput.Anchor = txtInput.Anchor | AnchorStyles.Right;
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            inputForm.ClientSize = new System.Drawing.Size(396, 107);
            inputForm.Controls.AddRange(new Control[] { lblPrompt, txtInput, btnOk });
            inputForm.ClientSize = new System.Drawing.Size(Math.Max(300, lblPrompt.Right + 10), inputForm.ClientSize.Height);
            inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            inputForm.StartPosition = FormStartPosition.CenterScreen;
            inputForm.MinimizeBox = false;
            inputForm.MaximizeBox = false;
            inputForm.AcceptButton = btnOk;

            // 显示对话框并等待确认按钮被点击
            DialogResult result = inputForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                // 返回用户输入的文字
                return txtInput.Text;
            }
            else
            {
                // 用户取消输入，返回空字符串
                return string.Empty;
            }
        }
        /// <summary>
        /// 弹出一个输入框，用来接收健康码，最大支持到64位
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        public static string ShowInputDialog64(string prompt)
        {
            Form inputForm = new Form();
            Label lblPrompt = new Label();
            TextBox txtInput = new TextBox();
            Button btnOk = new Button();

            inputForm.Text = "输入对话框";
            lblPrompt.Text = prompt;
            btnOk.Text = "确认";
            btnOk.DialogResult = DialogResult.OK;

            lblPrompt.SetBounds(9, 20, 372, 13);
            txtInput.SetBounds(12, 36, 372, 20);
            btnOk.SetBounds(309, 72, 75, 23);

            lblPrompt.AutoSize = true;
            txtInput.Anchor = txtInput.Anchor | AnchorStyles.Right;
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            inputForm.ClientSize = new System.Drawing.Size(396, 107);
            inputForm.Controls.AddRange(new Control[] { lblPrompt, txtInput, btnOk });
            inputForm.ClientSize = new System.Drawing.Size(Math.Max(300, lblPrompt.Right + 10), inputForm.ClientSize.Height);
            inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            inputForm.StartPosition = FormStartPosition.CenterScreen;
            inputForm.MinimizeBox = false;
            inputForm.MaximizeBox = false;
            inputForm.AcceptButton = btnOk;

            // 确认按钮被点击时的事件处理程序
            btnOk.Click += (sender, e) =>
            {
                // 检查文本框内容长度是否超过64位
                if (txtInput.Text.Length > 64)
                {
                    txtInput.Text = txtInput.Text.Substring(0, 64); // 截断文本到64位
                }
            };

            // 在文本框的 KeyPress 事件中检查字符长度
            txtInput.KeyPress += (sender, e) =>
            {
                if (txtInput.Text.Length >= 64 && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true; // 阻止输入超过64位的字符
                }
            };

            // 显示对话框并等待确认按钮被点击
            DialogResult result = inputForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                // 返回用户输入的文字
                return txtInput.Text;
            }
            else
            {
                // 用户取消输入，返回空字符串
                return string.Empty;
            }
        }


        /// <summary>
        /// 用来验证combobox录入的内容是不是它的选项，如果不是就清空
        /// </summary>
        /// <param name="comboBox"></param>
        public static void ClearComboBoxIfNotInItems(ComboBox comboBox)
        {
            string input = comboBox.Text.Trim();

            if (!comboBox.Items.Contains(input))
            {
                comboBox.Text = string.Empty;
            }
        }

        /// <summary>
        /// 计算预产期的日期，直接用现行日期加280天
        /// </summary>
        /// <param name="givenDate"></param>
        /// <returns></returns>
        public static DateTime CalculateDueDate(DateTime givenDate)
        {
            DateTime dueDate = givenDate.AddDays(280);
            return dueDate;
        }

        /// <summary>
        /// 获取运行文件路径指定文件夹下的文件方法
        /// </summary>
        /// <param name="folderName">根目录下的文件夹名</param>
        /// <param name="fileName"></param>
        /// <returns>返回文件地址，如果为null，就是文件不存在</returns>
        public static string GetFilePath(string folderName, string fileName)
        {
            // 获取程序运行目录
            string runningDirectory = AppDomain.CurrentDomain.BaseDirectory;
            // 设置文件路径为程序运行目录下的指定文件夹和文件名
            string filePath = Path.Combine(runningDirectory, folderName, fileName);

            // 检查文件是否存在
            if (File.Exists(filePath))
            {
                return filePath;
            }
            else
            {
                // 文件不存在
                Console.WriteLine("文件不存在。");
                return null;
            }
        }

        /// <summary>
        /// 获取程序运行目录下的某个文件夹地址，若不存在就新建
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetFilePath(string fileName)
        {
            // 获取程序运行目录
            string runningDirectory = AppDomain.CurrentDomain.BaseDirectory;
            // 设置文件路径为程序运行目录下的PaceSave文件夹
            string folderPath = Path.Combine(runningDirectory, fileName);

            // 检查文件夹是否存在
            if (!Directory.Exists(folderPath))
            {
                // 文件夹不存在，创建文件夹
                Directory.CreateDirectory(folderPath);
            }

            return folderPath;
        }




        /// <summary>
        /// 打印word文档
        /// </summary>
        /// <param name="path">文档地址</param>
        public static void PrintWord(string path)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            //不现实调用程序窗口,但是对于某些应用无效
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

            //采用操作系统自动识别的模式
            p.StartInfo.UseShellExecute = true;

            //要打印的文件路径，可以是WORD,EXCEL,PDF,TXT等等
            //p.StartInfo.FileName = @"d:\a.doc";
            p.StartInfo.FileName = path;

            //指定执行的动作，是打印，即print，打开是 open
            p.StartInfo.Verb = "print";

            //开始
            p.Start();
        }
    }

    
}
