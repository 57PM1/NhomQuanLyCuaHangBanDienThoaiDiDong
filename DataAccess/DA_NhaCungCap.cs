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
    public class DA_NhaCungCap
    {
        private string _error;
        GetData data = new GetData();
        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }

        public DataTable getAll()
        {
            string select = "SELECT MANCC[Mã Nhà Cung Cấp], TENNCC[Tên Nhà Cung Cấp], DIENTHOAI[Điện Thoại],DIACHI[Địa Chỉ],  EMAIL[Email] FROM NhaCungCap";
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

        //public DataTable getAllforReport()
        //{
        //    string select = "SELECT * FROM NhaCungCap";
        //    try
        //    {
        //        return data.getdata(select);
        //    }
        //    catch
        //    {
        //        Error = data.Error;
        //        return null;
        //    }
        //}
        public DataTable getAllWith(string select)
        {
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

        public DataTable searchMaNCC(string key)
        {
            string select = "SELECT MANCC[Mã Nhà Cung Cấp], TENNCC[Tên Nhà Cung Cấp], DIENTHOAI[Điện Thoại],DIACHI[Địa Chỉ],  EMAIL[Email] from NhaCungCap where MANCC like N'%" + key + "%'";
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
        public DataTable searchTenNCC(string key)
        {
            string select = "SELECT MANCC[Mã Nhà Cung Cấp], TENNCC[Tên Nhà Cung Cấp], DIENTHOAI[Điện Thoại],DIACHI[Địa Chỉ],  EMAIL[Email] from NhaCungCap WHERE TENNCC like N'%" + key + "%'";
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

        public bool insertNCC(EC_NhaCungCap ncc)
        {
            string insert = "INSERT INTO NhaCungCap VALUES(";
            insert += "N'" + ncc.MaNCC + "',";
            insert += "N'" + ncc.TenNCC + "',";
            insert += "N'" + ncc.DienThoai + "',";
            insert += "N'" + ncc.DiaChi + "',";
            insert += "N'" + ncc.Email + "')";
            if (!data.UpdateData(insert))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }

        public bool updateNCC(EC_NhaCungCap ncc)
        {
            string update = "UPDATE NhaCungCap SET ";
            update += "TENNCC=N'" + ncc.TenNCC + "',";
            update += "DIENTHOAI=N'" + ncc.DienThoai + "',";
            update += "DIACHI=N'" + ncc.DiaChi + "',";
            update += "EMAIL=N'" + ncc.Email + "'";
            update += "WHERE MANCC=N'" + ncc.MaNCC + "'";
            if (!data.UpdateData(update))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }

        public bool deleteNCC(EC_NhaCungCap ncc)
        {
            string delete = "DELETE FROM NhaCungCap WHERE MANCC=N'" + ncc.MaNCC + "'";
            if (!data.UpdateData(delete))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }
    }
}
