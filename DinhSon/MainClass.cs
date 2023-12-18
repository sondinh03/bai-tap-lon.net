using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace DoiBanThan
{
    internal class MainClass
    {
        public static readonly string strCon = @"Data Source=SONDINH\SQLEXPRESS;Initial Catalog=Quanlynhahang;Integrated Security=True";

        public static SqlConnection sqlCon = null;

        public static string user;

        private static void MoKetNoi()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            if (sqlCon.State == System.Data.ConnectionState.Closed)
            {
                sqlCon.Open();
            }
        }

        public static bool KiemTraTaiKhoan(string tenDangNhap, string matKhau)
        {
            bool kt = false;

            MoKetNoi();
            string qry = @"select * from tblUsers where TenDangNhap = '" + tenDangNhap + "' and MatKhau = '" + matKhau + "'";
            SqlCommand cmd = new SqlCommand(qry, sqlCon);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                kt = true;
                USER = dt.Rows[0]["TenNguoiDung"].ToString();
            }
            return kt;
        }

        public static string USER
        {
            get { return user; }
            private set { user = value; }
        }

        public static int Sql(string qry, Hashtable ht)
        {
            int res = 0;

            try
            {
                SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                sqlCmd.CommandType = CommandType.Text;

                foreach(DictionaryEntry item in ht)
                {
                    sqlCmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                }
                MoKetNoi();
                res = sqlCmd.ExecuteNonQuery();
                if(sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqlCon.Close();
            }
            return res;
        }

        public static void LoadData(string qry, DataGridView gv, ListBox lb)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand (qry, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                for(int i = 0; i < lb.Items.Count; i++)
                {
                    string cot1 = ((DataGridViewColumn)lb.Items[i]).Name;
                    gv.Columns[cot1].DataPropertyName = dt.Columns[i].ToString();
                }

                gv.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqlCon.Close();
            }
        }

    }
}
