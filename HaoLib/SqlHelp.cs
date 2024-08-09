using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HaoLib;
using System.Windows.Forms;

namespace HaoLib
{
    /// <summary>
    ///主要包括sqlHelp数据库访问助手类 和常用的一些函数定义
    ///</summary>
    ///SqlHelp数据库访问助手
    ///1.public static void OpenConn()                                  //打开数据库连接
    ///2.public static void CloseConn()                                 //关闭数据库连接
    ///3.public static SqlDataReader getDataReaderValue(string sql)     //读取数据
    ///4.public DataSet GetDataSetValue(string sql, string tableName)   //返回DataSet
    ///5.public DataView GetDataViewValue(string sql)                   //返回DataView
    ///6.public DataTable GetDataTableValue(string sql)                 //返回DataTable
    ///7.public void ExecuteNonQuery(string sql)                        //执行一个SQL操作:添加、删除、更新操作
    ///8.public int ExecuteNonQueryCount(string sql)                    //执行一个SQL操作:添加、删除、更新操作，返回受影响的行
    ///9.public static object ExecuteScalar(string sql)                 //执行一条返回第一条记录第一列的SqlCommand命令
    ///10.public int SqlServerRecordCount(string sql)                   //返回记录数


    ///常用函数
    ///1.public static bool IsNumber(string a)                          //判断是否为数字
    ///2.public static string GetSafeValue(string value)                //过滤非法字符
    public class SqlHelp
    {
        ///私有属性:数据库连接字符串
        ///Data Source=(Local)          服务器地址
        ///Initial Catalog=SimpleMESDB  数据库名称
        ///User ID=sa                   数据库用户名
        ///Password=admin123456         数据库密码
        //private const string connectionString = "Data Source=(Local);Pooling=False;Max Pool Size = 1024;Initial Catalog=house;Persist Security Info=True;User ID=sa;Password=123";


        /// <summary>
        /// sqlHelp 的摘要说明:数据库访问助手类
        /// sqlHelper是从DAAB中提出的一个类，在这里进行了简化，DAAB是微软Enterprise Library的一部分，该库包含了大量大型应用程序
        /// 开发需要使用的库类。
        /// </summary>
        private static string connectionString;

        public SqlHelp()
        {
            //无参构造函数

            string dateIp;//数据库IP地址
            string dateName;//数据库名字
            string dateUser;//数据库用户名
            string datePwd;//数据库密码
            string dateBase = "dateBase";//数据库信息保存文件的文件名
            bool ipReturn = HaoBase.DatabaseFileRead(dateBase, out dateIp, out dateName, out dateUser, out datePwd);


            if (ipReturn)
            {
                connectionString = string.Format("Data Source={0};Pooling=False;Max Pool Size = 1024;Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",
                                dateIp, dateName, dateUser, datePwd);
            }
            else
            {
                // 处理错误情况，例如设置一个默认连接字符串或者抛出异常
                MessageBox.Show("HaoLib:This worry 0x00000001");
            }

        }

        public static SqlConnection conn;

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public static void OpenConn()
        {
            string SqlCon = connectionString;//数据库连接字符串
            conn = new SqlConnection(SqlCon);
            if (conn.State.ToString().ToLower() == "open")
            {

            }
            else
            {
                conn.Open();
            }
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public static void CloseConn()
        {
            if (conn.State.ToString().ToLower() == "open")
            {
                //连接打开时
                conn.Close();
                conn.Dispose();
            }
        }


        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader GetDataReaderValue(string sql)
        {
            OpenConn();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            CloseConn();
            return dr;
        }


        /// <summary>
        /// 返回DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataSet GetDataSetValue(string sql, string tableName)
        {
            OpenConn();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, tableName);
            CloseConn();
            return ds;
        }

        /// <summary>
        ///  返回DataView
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataView GetDataViewValue(string sql)
        {
            OpenConn();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "temp");
            CloseConn();
            return ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable GetDataTableValue(string sql)
        {
            OpenConn();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            CloseConn();
            return dt;
        }

        /// <summary>
        /// 执行一个SQL操作:添加、删除、更新操作
        /// </summary>
        /// <param name="sql"></param>
        public void ExecuteNonQuery(string sql)
        {
            OpenConn();
            SqlCommand cmd;
            cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            CloseConn();
        }

        /// <summary>
        /// 执行一个SQL操作:添加、删除、更新操作，返回受影响的行
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteNonQueryCount(string sql)
        {
            OpenConn();
            SqlCommand cmd;
            cmd = new SqlCommand(sql, conn);
            int value = cmd.ExecuteNonQuery();
            return value;
        }

        /// <summary>
        /// 执行一条返回第一条记录第一列的SqlCommand命令
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object ExecuteScalar(string sql)
        {
            OpenConn();
            SqlCommand cmd;
            cmd = new SqlCommand(sql, conn);
            object value = cmd.ExecuteScalar();
            return value;
        }

        /// <summary>
        /// 返回记录数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int SqlServerRecordCount(string sql)
        {
            OpenConn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = conn;
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            int RecordCount = 0;
            while (dr.Read())
            {
                RecordCount = RecordCount + 1;
            }
            CloseConn();
            return RecordCount;
        }
        /// <summary>
        /// 获取服务器数据库时间
        /// </summary>
        /// <returns>DateTime类型的时间</returns>
        public DateTime GetSqlServerTime()
        {
            string sql = "SELECT CONVERT(date, GETDATE())";
            //string sql = "SELECT CONVERT(VARCHAR(10), GETDATE(), 120)";
            DataTable dt = GetDataTableValue(sql);
            string s = dt.Rows[0][0].ToString();
            DateTime dateTime = DateTime.Parse(s);
            return dateTime;
        }
    }
}
