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
   public class DA_HoaDonBan
    {
        GetData data = new GetData();
        public string _error;

        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }

        public DataTable getAll()
        {
            string select = "SELECT MAHDB[Mã HĐ Bán], NGAYBAN[Ngày Bán], MANV[Mã Nhân Viên], MAKH[Mã Khách Hàng], TONGTIEN[Tổng Tiền] FROM HoaDonBan";
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

        public bool insertHDB(EC_HoaDonBan hd)
        {
            string insert = "INSERT INTO HoaDonBan VALUES(";
            insert += "N'" + hd.MaHDB + "',";
            insert += "N'" + hd.NgayBan + "',";
            insert += "N'" + hd.MaNV + "',";
            insert += "N'" + hd.MaKH + "',";
            insert += "N'" + hd.TongTien + "')";
            if (!data.UpdateData(insert))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }

        public bool updateHDB(EC_HoaDonBan hd)
        {
            string update = "UPDATE HoaDonBan SET ";
            update += "NGAYBAN=N'" + hd.NgayBan + "',";
            update += "MANV=N'" + hd.MaNV + "', ";
            update += "MAKH= N'" + hd.MaKH + "' ";
            update += "WHERE MAHDB=N'" + hd.MaHDB + "'";
            if (!data.UpdateData(update))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }

        public bool deleteHDB(EC_HoaDonBan hd)
        {
            string delete = "DELETE FROM HoaDonBan WHERE MAHDB=N'" + hd.MaHDB + "'";
            if (!data.UpdateData(delete))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }

        public DataTable tkMa(string key)
        {
            string select = "SELECT MAHDB[Mã HĐ Bán], NGAYBAN[Ngày Bán], TENNV[TENNV], TENKH[Khách Hàng], THANHTIEN[Thành Tiền] FROM ((NhanVien INNER JOIN HoaDonBan ON HoaDonBan.MANV=NhanVien.MANV)INNER JOIN KhachHang ON KhachHang.MAKH=HoaDonBan.MAKH) WHERE MAHDB LIKE N'%" + key + "%'";
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

        //load khách hàng
        public DataTable GetKhachHang()
        {
            string select = "SELECT * FROM KhachHang";
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
        public DataTable GetTTHoaDon(string mahd)
        {
            string select = "SELECT dbo.HoaDonBan.MAHDB, dbo.HoaDonBan.NGAYBAN, dbo.CTHDB.SOLUONG, dbo.CTHDB.DONGIA,dbo.KhachHang.DIENTHOAI,dbo.KhachHang.EMAIL,dbo.KhachHang.DIACHI, dbo.CTHDB.THANHTIEN, dbo.HoaDonBan.TONGTIEN, dbo.HangHoa.TENHANG, dbo.KhachHang.TENKH, dbo.NhanVien.TENNV, dbo.HangHoa.DONVITINH FROM  dbo.CTHDB INNER JOIN dbo.HoaDonBan ON dbo.CTHDB.MAHDB = dbo.HoaDonBan.MAHDB INNER JOIN dbo.HangHoa ON dbo.CTHDB.MAHANG = dbo.HangHoa.MAHANG INNER JOIN dbo.KhachHang ON dbo.HoaDonBan.MAKH = dbo.KhachHang.MAKH INNER JOIN dbo.NhanVien ON dbo.HoaDonBan.MANV = dbo.NhanVien.MANV";
            select += " where dbo.HoaDonBan.MaHDB='" + mahd + "'";
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
