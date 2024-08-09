using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AES
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 设置加密密码
            string password = textBox_password.Text;

            // 加密字符串
            string plainText = textBox1.Text;
            byte[] encryptedBytes = AesEncryption.Encrypt(plainText, password);

            // 输出加密结果

            textBox2.Text = Convert.ToBase64String(encryptedBytes);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 设置加密密码
            string password = textBox_password.Text;

            byte[] encryptedBytes = Convert.FromBase64String(textBox1.Text);

            // 调用解密函数
            string decryptedText = AesEncryption.Decrypt(encryptedBytes, password);
            textBox2.Text = decryptedText;
        }
    }
}
