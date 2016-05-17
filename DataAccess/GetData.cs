using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class GetData
    {
        string _error;

        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }
        SqlConnection conn = new SqlConnection(@"Data Source=TENT\SQLEXPRESS;Initial Catalog=Mobile;Integrated Security=True");

        //SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Demo;User Id=sa;Password=sqlexpress;");

        public bool Connect()
        {
            //conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Demo;Integrated Security=True;");
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                Error = e.Message;
                return false;
            }
            return true;
        }
        void DisConnect()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }


        public DataTable getdata(string sqlcommand)
        {
            if (conn.State == ConnectionState.Closed)
                if (Connect() == false) return null;
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(sqlcommand, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                //DisConnect();
                return dt;
            }
            catch (Exception e)
            {
                Error = e.Message;
                conn.Close();
                //DisConnect();
                return null;
            }
        }

        public SqlDataReader getdataReader(string sqlcommand)
        {
            if (conn.State == ConnectionState.Closed)
                if (Connect() == false) return null;
            try
            {
                SqlCommand sda = new SqlCommand(sqlcommand, conn);
                SqlDataReader dt = sda.ExecuteReader();
                return dt;
            }
            catch (Exception e)
            {
                Error = e.Message;
                conn.Close();
                //DisConnect();
                return null;
            }
        }

        public bool UpdateData(string sqlcommand)
        {
            if (conn.State == ConnectionState.Closed)
                if (Connect() == false) return false;
            SqlCommand sqlUpdate = new SqlCommand(sqlcommand, conn);
            int kq = 0;
            try
            {
                kq = sqlUpdate.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Error = e.Message;
                return false;
            }
            DisConnect();
            //conn.Close();
            if (kq <= 0) return false;
            return true;
        }

        public void ExecuteNonQuery(string sqlcommand)
        {
            if (conn.State == ConnectionState.Closed)
                if (Connect() == false) return;
            SqlCommand sqlUpdate = new SqlCommand(sqlcommand, conn);
            sqlUpdate.ExecuteNonQuery();
        }

    }
}

