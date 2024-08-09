using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace House
{
    internal static class Program
    {
        public static string userName = "";
        public static string userNameDepartment = "";

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new ReportPacs());//测试代码



            // 创建登录窗体
            Login loginForm = new Login();

            // 检查登录状态
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // 登录成功，创建并显示主窗体
                Application.Run(new Form1());
            }
        }
    }
}
