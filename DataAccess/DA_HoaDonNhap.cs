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
   public class DA_HoaDonNhap
    {
        GetData data = new GetData();
        string _error;

        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }

        public DataTable GetAll()
        {
            string select = "SELECT MAHDN[Mã HĐ Nhập], NGAYNHAP[Ngày Nhập], TENNV[TENNV], TENNCC[Tên NCC], TONGTIEN[Tổng Tiền] FROM ((NhanVien INNER JOIN HoaDonNhap ON HoaDonNhap.MANV=NhanVien.MANV)INNER JOIN NhaCungCap ON NhaCungCap.MANCC=HoaDonNhap.MANCC)";
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

        public bool insertHDN(EC_HoaDonNhap hd)
        {
            string insert = "INSERT INTO HoaDonNhap VALUES(";
            insert += "N'" + hd.MaHDN + "',";
            insert += "N'" + hd.NgayNhap + "',";
            insert += "N'" + hd.MaNV + "',";
            insert += "N'" + hd.MaNCC + "',";
            insert += "N'" + hd.TongTien + "')";
            if (!data.UpdateData(insert))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }

        public bool updateHDN(EC_HoaDonNhap hd)
        {
            string update = "UPDATE HoaDonNhap SET ";
            update += "NGAYNHAP=N'" + hd.NgayNhap + "',";
            update += "MANV=N'" + hd.MaNV + "', ";
            update += "MANCC= N'" + hd.MaNCC + "' ";
            update += "WHERE MAHDN=N'" + hd.MaHDN + "'";
            if (!data.UpdateData(update))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }

        public bool deleteHDN(EC_HoaDonNhap hd)
        {
            string delete = "DELETE FROM HoaDonNhap WHERE MAHDN=N'" + hd.MaHDN + "'";
            if (!data.UpdateData(delete))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }

        public DataTable tkMa(string key)
        {
            string select = "SELECT MAHDN[Mã HĐ Nhap], NGAYNHAP[Ngày Nhập], TENNV[TENNV], TENNCC[Nhà Cung Cấp], TONGTIEN[Tổng Tiền] FROM HoaDonNhap WHERE MAHDN LIKE N'%" + key + "%'";
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

        //load Nhân Viên
        public DataTable GetNhanVien()
        {
            string select = "SELECT * FROM NhanVien";
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

        //load Nhà cung cấp
        public DataTable GetNhaCungCap()
        {
            string select = "SELECT * FROM NhaCungCap";
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
        public DataTable GetTTHoaDonNhapHang(string mahoadon)
        {
            string select = "SELECT        HoaDonNhap.MAHDN, HoaDonNhap.NGAYNHAP, CTHDN.MAHANG, CTHDN.SOLUONG, CTHDN.DONGIA, CTHDN.THANHTIEN, HangHoa.TENHANG, NhanVien.TENNV, NhaCungCap.TENNCC FROM CTHDN INNER JOIN HangHoa ON CTHDN.MAHANG = HangHoa.MAHANG INNER JOIN HoaDonNhap ON CTHDN.MAHDN = HoaDonNhap.MAHDN INNER JOIN NhaCungCap ON HoaDonNhap.MANCC = NhaCungCap.MANCC INNER JOIN NhanVien ON HoaDonNhap.MANV = NhanVien.MANV";
            select += " where HoaDonNhap.MaHDN='" + mahoadon + "'";
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
