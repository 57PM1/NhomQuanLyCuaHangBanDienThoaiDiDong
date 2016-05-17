using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityClass;
using System.Data;

namespace DataAccess
{
    public class DA_TaiKhoan
    {
        public string Error;
        GetData data = new GetData();

        public DataTable getAll()
        {
            string select = "SELECT TAIKHOAN[Tên Tài Khoản],MATKHAU[Mật Khẩu], QUYEN[Quyền] FROM TaiKhoan";
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
        public DataTable getUser(EC_TaiKhoan tk)
        {
            string select = "SELECT * FROM TaiKhoan WHERE TAIKHOAN=N'" + tk.TaiKhoan + "' " + "AND MATKHAU=N'" + tk.MatKhau + "'";
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
        public bool insertTK(EC_TaiKhoan tk)
        {
            string insert = "INSERT INTO TaiKhoan VALUES(";
            insert += "N'" + tk.TaiKhoan + "',";
            insert += "N'" + tk.MatKhau + "',";
            insert += "N'" + tk.Quyen + "')";
            if (!data.UpdateData(insert))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }
        public bool updateTK(EC_TaiKhoan tk)
        {
            string update = "UPDATE TaiKhoan SET ";
            update += "TAIKHOAN=N'" + tk.TaiKhoan + "', ";
            update += "MATKHAU=N'" + tk.MatKhau + "',";
            update += "QUYEN=N'" + tk.Quyen + "'";
            update += "WHERE TAIKHOAN=N'" + tk.TaiKhoan + "'";
            update += "AND MATKHAU=N'" + tk.MatKhau + "'";
            if (!data.UpdateData(update))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }
        public bool deleteTK(EC_TaiKhoan tk)
        {
            string delete = "DELETE FROM TaiKhoan WHERE TAIKHOAN=N'" + tk.TaiKhoan + "'";
            if (!data.UpdateData(delete))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }
        public bool updateMK(EC_TaiKhoan tk)
        {
            string update = "UPDATE TaiKhoan SET  MATKHAU = N'" + tk.MatKhau + "'";
            //string update = "UPDATE TaiKhoan SET MATKHAU=N'" + tk.MatKhau + "' WHERE TAIKHOAN=N'" + tk.TaiKhoan + "'";
            if (!data.UpdateData(update))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }
        public bool ktTK(EC_TaiKhoan tk)
        {
            string select = "SELECT * FROM TaiKhoan WHERE ";
            select += " TAIKHOAN=N'" + tk.TaiKhoan + "' ";
            select += "AND MATKHAU=N'" + tk.MatKhau + "' ";
            if (data.getdata(select) == null)
            {
                Error = data.Error;
                return false;
            }
            return true;
        }
        public DataTable tkTenTK(string key)
        {
            string select = "SELECT TAIKHOAN[Tên Tài Khoản], MATKHAU[Mật Khẩu], QUYEN[Quyền] FROM TaiKhoan WHERE TAIKHOAN LIKE N'%" + key + "%'";
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
        public DataTable tkQuyen(string key)
        {
            string select = "SELECT TAIKHOAN[Tên Tài Khoản], MATKHAU[Mật Khẩu], QUYEN[Quyền] FROM TaiKhoan WHERE QUYEN LIKE N'%" + key + "%'";
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
