using HaoLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace House
{
    public partial class Form1 : Form
    {
        SqlHelp sqlHelper = new SqlHelp();
        //private Dictionary<string, Form> openedForms; // 存储已打开的窗体
        private readonly Dictionary<string, Form> openedForms = new Dictionary<string, Form>();//使用泛型集合来存储窗体
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //底部信息栏写入登录名
            toolStripStatusLabel_user.Text = Program.userName;

            // 根据用户身份过滤列表视图项            
            FilterListViewItems(Program.userNameDepartment);//缺少窗体字典，后期添加！！！
        }
        /// <summary>
        /// 通过科室来过滤功能
        /// </summary>
        /// <param name="userDepartment"></param>
        private void FilterListViewItems(string userDepartment)
        {
            //listView.Items.Clear();

            // 根据用户身份添加相应的列表视图项
            switch (userDepartment)
            {
                case "管理员":
                    // 管理员可以访问所有功能
                    break;
                case "福卡中心":
                    // 福卡中心用户可以访问的功能
                    break;
                // 其他部门...
                default:
                    // 默认情况下，用户可以访问的功能
                    break;
            }
        }

        private async void ListViewEx_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem selectedItem = listViewEx.GetItemAt(e.X, e.Y);

            if (selectedItem != null)
            {
                string itemName = selectedItem.Text;

                switch (itemName)
                {
                    case "病人管理":
                        // 打开窗体
                        await OpenFormAsync<Patient>("Patient", "病人管理");
                        break;
                    case "ReportPacs":
                        // 打开窗体
                        await OpenFormAsync<ReportPacs>("ReportPacs", "ReportPacs");
                        break;
                    default:
                        break;
                }

                
            }
        }
        /// <summary>
        /// 异步打开窗体
        /// </summary>
        /// <param name="formName"></param>
        private async Task OpenFormAsync<T>(string formName, string buttonName) where T : Form, new()
        {
            // 检查窗体是否已打开
            if (openedForms.ContainsKey(formName))
            {
                Form form = openedForms[formName];
                form.BringToFront();
                return;
            }

            // 创建窗体实例
            T newForm = new T();
            newForm.Text = buttonName;
            openedForms.Add(formName, newForm);

            // 注册窗体关闭事件，从字典中移除已关闭的窗体
            newForm.FormClosed += (sender, e) =>
            {
                openedForms.Remove(formName);
            };

            // 显示窗体
            newForm.Show();
        }

        /// <summary>
        /// 底部信息栏实时更新本地电脑时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void time_nowtime_Tick(object sender, EventArgs e)
        {
            Label_nowtime.Text = DateTime.Now.ToString();
        }
        /// <summary>
        /// 打开更新日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 更新日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDialog updateDialog = new UpdateDialog();
            updateDialog.ShowDialog();
        }
    }
}
