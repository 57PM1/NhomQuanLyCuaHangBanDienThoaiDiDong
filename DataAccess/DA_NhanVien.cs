using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using EntityClass;
using System.Data;

namespace DataAccess
{
    public class DA_NhanVien
    {
        GetData data = new GetData();
        private string _error;

        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }

        public DataTable getAll()
        {
            string select = "SELECT MANV[Mã Nhân Viên], TENNV[Tên Nhân Viên], NGAYSINH[Ngày Sinh], GIOITINH[Giới Tính], DIENTHOAI[Điện Thoại], DIACHI[Địa Chỉ], EMAIL[Email], CHUCVU[Chức Vụ] FROM NhanVien";
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
        //    string select = "SELECT * FROM NhanVien";
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
        public bool insertNV(EC_NhanVien nv)
        {
            string strInsert = "INSERT INTO NhanVien VALUES (";
            strInsert += "N'" + nv.MaNV + "', ";
            strInsert += "N'" + nv.TenNV + "', ";
            strInsert += "N'" + nv.NgaySinh + "', ";
            strInsert += "N'" + nv.GioiTinh + "', ";
            strInsert += "N'" + nv.DienThoai + "', ";
            strInsert += "N'" + nv.DiaChi + "', ";
            strInsert += "N'" + nv.Email + "', ";
            strInsert += "N'" + nv.ChucVu + "')";
            if (!data.UpdateData(strInsert))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }

        public bool updateNV(EC_NhanVien nv)
        {
            string strUpdate = "UPDATE NhanVien SET ";
            strUpdate += "TENNV=N'" + nv.TenNV + "',";
            strUpdate += "NGAYSINH=N'" + nv.NgaySinh + "',";
            strUpdate += "GIOITINH=N'" + nv.GioiTinh + "',";
            strUpdate += "DIENTHOAI=N'" + nv.DienThoai + "',";
            strUpdate += "DIACHI=N'" + nv.DiaChi + "',";
            strUpdate += "EMAIL=N'" + nv.Email + "',";
            strUpdate += "CHUCVU=N'" + nv.ChucVu + "'";
            strUpdate += "WHERE MANV=N'" + nv.MaNV + "'";

            if (!data.UpdateData(strUpdate))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }

        public bool deleteNV(string ma)
        {
            string delete = "DELETE  FROM NhanVien WHERE MANV=N'" + ma + "'";
            if (!data.UpdateData(delete))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }

        public DataTable tkMa(string key)
        {
            string select = "SELECT MANV[Mã Nhân Viên], TENNV[Tên Nhân Viên], NGAYSINH[Ngày Sinh], GIOITINH[Giới Tính], DIENTHOAI[Điện Thoại], DIACHI[Địa Chỉ],EMAIL[Email], CHUCVU[Chức Vụ] FROM NhanVien WHERE MANV LIKE N'%" + key + "%'";
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
            string select = "SELECT MANV[Mã Nhân Viên], TENNV[Tên Nhân Viên], NGAYSINH[Ngày Sinh], GIOITINH[Giới Tính], DIENTHOAI[Điện Thoại], DIACHI[Địa Chỉ],EMAIL[Email], CHUCVU[Chức Vụ] FROM NhanVien WHERE TENNV LIKE N'%" + key + "%'";
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
