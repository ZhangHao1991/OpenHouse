using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using System.Text.RegularExpressions;
using System.Diagnostics;
using HaoLib;
using AES;

namespace House
{
    public partial class Login : Form
    {
        SqlHelp sqlHelper = new SqlHelp();

        // 定义INI文件操作相关函数
        // 保存用户名和密码到INI文件
        string section = "Login";
        string rememberKey = "Remember";
        string usernameKey = "Username";
        string passwordKey = "Password";
        string filename = "config.ini";

        public Login()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 判断程序是不是第一次运行,并且获取版本号
        /// </summary>
        private void IsFristRun()
        {
            string version = Application.ProductVersion;
            string folderPath = Path.Combine(Application.StartupPath, "Updatelog");

            // 如果Updatelog文件夹不存在，则创建该文件夹
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath = Path.Combine(folderPath, version + ".txt");

            // 如果版本号.txt文件不存在，则创建该文件，并显示提示框
            if (!File.Exists(filePath))
            {
                string sql = string.Format("Select * From HH_UpdateLog Where Version = '{0}'", version);
                DataTable dt = sqlHelper.GetDataTableValue(sql);

                if (dt.Rows.Count > 0)
                {
                    File.WriteAllText(filePath, "[" + version + "]" + "\n" + dt.Rows[0]["LogText"].ToString() + "\n");
                }

                UpdateDialog ud = new UpdateDialog();
                ud.ShowDialog();
            }
        }
        private void CheckForUpdates()
        {
            string sql = string.Format("Select * From HH_version");
            DataTable dt_version = sqlHelper.GetDataTableValue(sql);

            try
            {
                string newVersion = dt_version.Rows[0]["version"].ToString();//从服务器获取的最新版本号


                FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(Path.Combine(Application.StartupPath, "House.exe"));
                string currentVersion = versionInfo.FileVersion; //当前应用程序的版本号
                if (newVersion != currentVersion)
                {
                    // 获取当前程序所在目录
                    string directory = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

                    // 构造 start.exe 的完整路径
                    string startPath = Path.Combine(directory, "FileUpdater.exe");

                    // 检查 start.exe 是否存在
                    if (File.Exists(startPath))
                    {
                        MessageBox.Show("程序需要更新，点击确定后自动更新\r\n更新完毕将自动运行程序");
                        // 执行 start.exe
                        Process.Start(startPath);

                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("FileUpdater 不存在");
                        Application.Exit();
                    }

                }

            }
            catch
            {
                MessageBox.Show("网络出现问题，请联系管理员");
                Application.Exit();
            }



            //授权情况
            string s = dt_version.Rows[0]["expire"].ToString();
            s = AES.AesEncryption.AESjian(s);//AES解密

            DateTime expire = DateTime.Parse(s);

            if (expire < sqlHelper.GetSqlServerTime())
            {
                MessageBox.Show("程序需要维护，请联系管理员");
                Application.Exit();
            }
        }
        private void Login_Load(object sender, EventArgs e)
        {
            HaoLib.HaoBase.DatabaseFileWrite("dateBase");

            IsFristRun();

            //先判断是不是有ini文件，如果没有，则写入一个新的文件
            if (!File.Exists(filename))
            {
                // 如果INI文件不存在，则创建一个新的INI文件
                StreamWriter writer = new StreamWriter(filename);
                writer.WriteLine("[" + section + "]");
                writer.WriteLine(rememberKey + "=");
                writer.WriteLine(usernameKey + "=");
                writer.WriteLine(passwordKey + "=");
                writer.Close();
            }

            //读取ini里面的配制
            string remember = "";
            string username = "";
            string pw = "";

            if (File.Exists(filename))
            {
                // 如果INI文件存在，则读取用户名和密码
                StreamReader reader = new StreamReader(filename);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith(rememberKey + "="))
                    {
                        remember = line.Substring(rememberKey.Length + 1);
                    }
                    if (line.StartsWith(usernameKey + "="))
                    {
                        username = line.Substring(usernameKey.Length + 1);
                    }
                    else if (line.StartsWith(passwordKey + "="))
                    {
                        pw = line.Substring(passwordKey.Length + 1);

                    }
                    if (remember == "1")
                    {
                        checkBox_remember.Checked = true;
                        textBox_user.Text = username;
                        textBox_pw.Text = pw;

                    }

                }
                reader.Close();
            }

            System.Diagnostics.Process[] myProcesses = System.Diagnostics.Process.GetProcessesByName("HouseHis");//获取指定的进程名

            if (myProcesses.Length > 1) //如果可以获取到知道的进程名则说明已经启动
            {
                MessageBox.Show("程序已启动！");
                Application.Exit();//关闭系统
            }
        }


        private bool ValidateLogin(string username, string password)
        {

            // 在这里使用 sqlHelper 对象进行数据库交互
            // 进行用户名和密码验证的逻辑

            // 示例：从数据库中查询用户信息，并验证用户名和密码是否匹配
            string sql = $"SELECT name, department FROM HH_admin WHERE userName = '{username}' and passWord = '{password}'";
            DataTable dataTable = sqlHelper.GetDataTableValue(sql);
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                Program.userName = row["name"].ToString().Trim();
                Program.userNameDepartment = row["department"].ToString().Trim();
                return true;
            }

            return false;

        }
        private void button_login_Click(object sender, EventArgs e)
        {
            CheckForUpdates();

            string username = textBox_user.Text;
            string password = textBox_pw.Text;

            // 进行登录验证逻辑
            if (ValidateLogin(username, password))
            {
                // 登录成功，设置登录结果为 OK 并关闭登录窗体
                DialogResult = DialogResult.OK;


                // 窗口加载以前，保存账户密码
                // 写入用户名和密码到INI文件
                StreamWriter writer = new StreamWriter(filename);
                writer.WriteLine("[" + section + "]");
                if (checkBox_remember.Checked == true)
                {
                    writer.WriteLine(rememberKey + "=1");
                    writer.WriteLine(usernameKey + "=" + textBox_user.Text);
                    writer.WriteLine(passwordKey + "=" + textBox_pw.Text);
                }
                else
                {
                    writer.WriteLine(rememberKey + "=0");
                    writer.WriteLine(usernameKey + "=");
                    writer.WriteLine(passwordKey + "=");
                }
                writer.Close();


                Close();
            }
            else
            {
                // 登录失败，显示错误消息或执行其他操作
                MessageBox.Show("用户名或密码错误，请重新输入。", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_pw.Text = "";//清空密码
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            string username = this.textBox_user.Text.Trim();
            string oldPwd = this.textBox_pw.Text.Trim();
            string newPwd = this.textBox_NewPw.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(oldPwd) || string.IsNullOrEmpty(newPwd))
            {
                MessageBox.Show("请填写完整信息！");
                return;
            }

            string sql = string.Format("SELECT * FROM HH_admin WHERE userName = '{0}' AND passWord = '{1}'", username, oldPwd);
            DataTable dt = sqlHelper.GetDataTableValue(sql);

            if (dt.Rows.Count > 0)
            {
                string updateSql = string.Format("UPDATE HH_admin SET passWord = '{0}' WHERE userName = '{1}'", newPwd, username);
                sqlHelper.ExecuteNonQuery(updateSql);

                MessageBox.Show("密码修改成功！");
                checkBox_checkPW.Checked = false;
                textBox_pw.Text = newPwd;
            }
            else
            {
                MessageBox.Show("用户名或原密码错误，请重新输入！");
                return;
            }
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void checkBox_checkPW_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_checkPW.Checked)
            {
                label5.Visible = true;
                textBox_NewPw.Visible = true;
                button_update.Visible = true;
                button_login.Visible = false;

                checkBox_remember.Visible = false;
            }
            else
            {
                label5.Visible = false;
                textBox_NewPw.Visible = false;

                checkBox_remember.Visible = true;
                button_update.Visible = false;
                button_login.Visible = true;
            }
        }

        private void textBox_user_TextChanged(object sender, EventArgs e)
        {
            string pattern = @"^[a-zA-Z0-9]*$"; // 正则表达式，只允许输入英文和数字
            Regex regex = new Regex(pattern);

            if (!regex.IsMatch(textBox_user.Text)) // 验证文本是否符合规则
            {
                textBox_user.Text = ""; // 清空文本框内容
            }
        }

        private void textBox_user_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                textBox_pw.Focus();
            }
        }

        private void textBox_user_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_pw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                button_login.PerformClick();
            }
        }
    }
}
