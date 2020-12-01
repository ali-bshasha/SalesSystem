using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace SalesSystem.Modle
{
    class DAL
    {
        SqlConnection SqlConnection;
        public DAL()
        {
           //SqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ALI-BSHASHA\source\repos\SalesSystem\SalesSystem\SalemSystem.mdf;Integrated Security=True");
            SqlConnection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=SalemSystem;Integrated Security=True");
        }
        //دالة فتح الإتصال
        public void open()
        {
            if (SqlConnection.State != ConnectionState.Open)
            {
                SqlConnection.Open();
            }

        }
        //دالة إغلاق الاتصال
        public void close()
        {
            if (SqlConnection.State == ConnectionState.Open)
            {
                SqlConnection.Close();
            }
        }
        //البحث وجلب البيانات في شكل جدول
        public DataTable SelectData(string cmd)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = cmd;
            sqlcmd.Connection = SqlConnection;
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        //دالة ارسال الاوامرالحدف التعديل الإضافة
        public int ExecuteCommand(string cmd)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = cmd;
            sqlcmd.Connection = SqlConnection;
            open();
            int t = sqlcmd.ExecuteNonQuery();
            close();
            return t;
        }
        public int Ex(string cmd, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandText = cmd;
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = SqlConnection;
            if (param != null)
            {
                sqlcmd.Parameters.AddRange(param);
            }
            open();
            int t = sqlcmd.ExecuteNonQuery();
            close();
            return t;
        }
        public DataTable Read(string cmd, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandText = cmd;
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = SqlConnection;
            if (param != null)
            {
                sqlcmd.Parameters.AddRange(param);
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
