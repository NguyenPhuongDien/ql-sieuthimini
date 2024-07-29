using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Nhom1_QuanLySieuThiMini
{
    public class DBConnect
    {
        SqlConnection connect;

        public SqlConnection Connect
        {
            get { return connect; }
            set { connect = value; }
        }
        const string strConnect = "Data Source= admin-pc;Initial Catalog = SieuThiMini;Integrated Security=True";

        //string strConnect = "data source=ADMIN-PC;initial catalog=SieuThiMini;integrated security=True";
        public DBConnect()
        {
            connect = new SqlConnection(strConnect);
        }

        public void open()
        {
            if (connect.State == ConnectionState.Closed)
                connect.Open();
        }
        public void close()
        {
            if (connect.State == ConnectionState.Open)
                connect.Close();
        }
        public int getNonQuery(string sql)
        {
            open();
            SqlCommand cmd = new SqlCommand(sql, connect);
            int kq = cmd.ExecuteNonQuery();
            close();
            return kq;
        }
        public SqlDataReader getDataReader(string sql)
        {
            open();
            SqlCommand cmd = new SqlCommand(sql, connect);
            SqlDataReader rd = cmd.ExecuteReader();
            //close();
            return rd;
        }
        public DataTable ExecuteReader(string sql)
        {
            open();
            SqlCommand cmd = new SqlCommand(sql, connect);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            reader.Close();
            close();
            return dt;
        }
        public int ExecuteNonQuery(string sql)
        {
            open();
            SqlCommand cmd = new SqlCommand(sql, connect);
            int result = cmd.ExecuteNonQuery();
            close();
            return result;
        }
        public object getScalar(string sql)
        {
            open();
            SqlCommand cmd = new SqlCommand(sql, connect);
            object kq = cmd.ExecuteScalar();
            close();
            return kq;
        }

        public DataTable getDatatable(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, connect);
            da.Fill(dt);
            return dt;
        }

        public int updateDatabase(string sql, DataTable dt)
        {
            SqlDataAdapter da_lop = new SqlDataAdapter(sql, Connect);
            SqlCommandBuilder cb = new SqlCommandBuilder(da_lop);
            int kq = da_lop.Update(dt);
            return kq;
        }
        public bool isDuplicate(string id, string table, string keyField)
        {
            DataTable tbl = getDatatable("SELECT * FROM " + table + " WHERE " + keyField + " = N'" + id + "'");
            if (tbl.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
