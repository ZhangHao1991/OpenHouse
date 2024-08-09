using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using HaoLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace House
{
    public partial class ReportPacs : Form
    {
        public ReportPacs()
        {
            InitializeComponent();
        }

        private void ReportPacs_Load(object sender, EventArgs e)
        {

        }

        string paceFile;
        /// <summary>
        /// 保存并且打印出来
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_print_Click(object sender, EventArgs e)
        {
            HaoLib.HaoBase.PrintWord(paceFile);
        }
        private void button_save_Click(object sender, EventArgs e)
        {
            button_save.Enabled = false;

            string riqi = DateTime.Now.ToString("yyyyMMdd");

            string tempathName = "USreport4.doc";//USreport.doc
            int kg = 150;//图片的宽度和高度
            if (textBox_picture4.Text == "")
            {
                tempathName = "USreport3.doc";
                kg = 200;
            }
            if (textBox_picture3.Text == "")
            {
                tempathName = "USreport2.doc";
                kg = 300;
            }

            //1.首先需要载入模板
            Report report = new Report();
            report.CreateNewDocument(HaoLib.HaoBase.GetFilePath("temPath", tempathName)); //模板路径

            report.InsertValue("name", textBox_name.Text);//在书签“姓名”处插入值
            string ganner;
            if (checkBox_men.Checked)
            {
                ganner = "男";
            }
            else { ganner = "女"; }
            report.InsertValue("ganner", ganner);//在书签“性别”处插入值
            report.InsertValue("age", textBox_age.Text);//在书签“姓名”处插入值
            report.InsertValue("nationality", textBox_nationality.Text);//在书签“姓名”处插入值
            report.InsertValue("askDocker", comboBox_askDocker.Text);//在书签“姓名”处插入值
            report.InsertValue("department", comboBox_department.Text);//在书签“姓名”处插入值
            report.InsertValue("bed", textBox_bed.Text);//在书签“姓名”处插入值
            report.InsertValue("ID", textBox_ID.Text);//在书签“姓名”处插入值


            report.InsertValue("bingqingzhaiyao", textBox_bingqingzhaiyao.Text);//在书签“姓名”处插入值
            report.InsertValue("linchuangzhenduan", textBox_linchuangzhenduan.Text);//在书签“姓名”处插入值
            report.InsertValue("jianchabuwei", comboBox_jianchabuwei.Text);//在书签“姓名”处插入值



            //pic

            //13.插入图片
            //string picturePath = @"C:\Documents and Settings\Administrator\桌面\1.jpg";
            //report.InsertPicture("Bookmark_picture",picturePath, 150, 150); //书签位置，图片路径，图片宽度，图片高度
            if (textBox_picture1.Text != "")
                report.InsertPicture("pic1", textBox_picture1.Text, kg, kg); //书签位置，图片路径，图片宽度，图片高度
            if (textBox_picture2.Text != "")
                report.InsertPicture("pic2", textBox_picture2.Text, kg, kg); //书签位置，图片路径，图片宽度，图片高度
            if (textBox_picture3.Text != "")
                report.InsertPicture("pic3", textBox_picture3.Text, kg, kg); //书签位置，图片路径，图片宽度，图片高度
            if (textBox_picture4.Text != "")
                report.InsertPicture("pic4", textBox_picture4.Text, kg, kg); //书签位置，图片路径，图片宽度，图片高度



            report.InsertValue("reprot", textBox_reprot.Text);//在书签“姓名”处插入值

            report.InsertValue("datereprot", dateTimePicker_datereprot.Text);//在书签“报告日期”处插入值
            report.InsertValue("dateexamine", dateTimePicker_dateexamine.Text);//在书签“审核日期”处插入值

            paceFile = HaoLib.HaoBase.GetFilePath("PaceSave") + "\\" + riqi + textBox_name.Text + Guid.NewGuid().ToString() + ".doc";
            //15.最后保存文档
            report.SaveDocument(paceFile); //文档路径
            report.killWinWordProcess();



            button_print.Enabled = true;
        }

        private void button_picture1_Click(object sender, EventArgs e)
        {
            // 创建一个OpenFileDialog实例
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // 设置OpenFileDialog的过滤器，以便只显示图片文件
            openFileDialog.Filter = "图片文件 (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

            // 显示OpenFileDialog
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 如果用户选择了文件，获取文件的路径
                string filePath = openFileDialog.FileName;
                textBox_picture1.Text = filePath;
            }
        }

        private void button_picture2_Click(object sender, EventArgs e)
        {
            // 创建一个OpenFileDialog实例
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // 设置OpenFileDialog的过滤器，以便只显示图片文件
            openFileDialog.Filter = "图片文件 (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

            // 显示OpenFileDialog
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 如果用户选择了文件，获取文件的路径
                string filePath = openFileDialog.FileName;
                textBox_picture2.Text = filePath;
            }
        }

        private void button_picture3_Click(object sender, EventArgs e)
        {
            // 创建一个OpenFileDialog实例
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // 设置OpenFileDialog的过滤器，以便只显示图片文件
            openFileDialog.Filter = "图片文件 (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

            // 显示OpenFileDialog
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 如果用户选择了文件，获取文件的路径
                string filePath = openFileDialog.FileName;
                textBox_picture3.Text = filePath;
            }
        }

        private void button_picture4_Click(object sender, EventArgs e)
        {
            // 创建一个OpenFileDialog实例
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // 设置OpenFileDialog的过滤器，以便只显示图片文件
            openFileDialog.Filter = "图片文件 (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

            // 显示OpenFileDialog
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 如果用户选择了文件，获取文件的路径
                string filePath = openFileDialog.FileName;
                textBox_picture4.Text = filePath;
            }
        }

        private void button_clean_Click(object sender, EventArgs e)
        {
            textBox_name.Text = "";
            textBox_age.Text = "";
            textBox_nationality.Text = "";
            comboBox_askDocker.Text = "";
            comboBox_department.Text = "";
            textBox_bed.Text = "";
            textBox_ID.Text = "";
            textBox_bingqingzhaiyao.Text = "";
            textBox_linchuangzhenduan.Text = "";
            comboBox_jianchabuwei.Text = "";
            textBox_picture1.Text = "";
            textBox_picture2.Text = "";
            textBox_picture3.Text = "";
            textBox_picture4.Text = "";
            textBox_reprot.Text = "";
            checkBox_men.Checked = true;

            button_save.Enabled = true;
            button_print.Enabled = false;
        }

        private void checkBox_men_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_women.Checked = false;
        }

        private void checkBox_women_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_men.Checked = false;
        }
    }
}
