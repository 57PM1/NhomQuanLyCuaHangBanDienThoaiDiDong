using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EntityClass;

namespace DataAccess
{
    public class DA_NhaSanXuat
    {

        private string _error;
        GetData data = new GetData();
        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }

        public DataTable getAllWith(string key)
        {
            try
            {
                return data.getdata(key);
            }
            catch
            {
                Error = data.Error;
                return null;
            }
        }

        public DataTable getAll()
        {
            string select = "select MANSX[Mã NSX], TENNSX[Tên NSX]  from NhaSanXuat";
            //string select = "select * from NhaSanXuat";
            try
            {
                return data.getdata(select);
            }
            catch
            {
                Error = data.Error;
                return null;
            }
        }

        public bool insertNSX(EC_NhaSanXuat nsx)
        {
            string insert = "insert into NhaSanXuat values(";
            insert += "N'" + nsx.MANSX + "',";
            insert += "N'" + nsx.TENNSX + "')";
            if (!data.UpdateData(insert))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }

        public bool updateNSX(EC_NhaSanXuat nsx)
        {
            string update = "update NhaSanXuat set ";
            update += "TENNSX = N'" + nsx.TENNSX + "'";
            update += "where MANSX =N'" + nsx.MANSX + "'";
            if (!data.UpdateData(update))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }

        public bool deleteNSX(string ma)
        {
            string delete = "delete from NhaSanXuat where MANSX=N'" + ma + "'";
            if (!data.UpdateData(delete))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }

        public DataTable tkMa(string key)
        {
            string select = "select MANSX[Mã NSX], TENNSX[Tên NSX]  from NhaSanXuat WHERE MANSX LIKE N'%" + key + "%'";
            try
            {
                return data.getdata(select);
            }
            catch
            {
                Error = data.Error;
                return null;
            }
        }

        public DataTable tkTen(string key)
        {
            string select = "select MANSX[Mã NSX], TENNSX[Tên NSX]  from NhaSanXuat WHERE TENNSX LIKE N'%" + key + "%'";
            try
            {
                return data.getdata(select);
            }
            catch
            {
                Error = data.Error;
                return null;
            }
        }
    }
}
