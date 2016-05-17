using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EntityClass;
using System.Data;

namespace DataAccess
{
   public class DA_CTHDN
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
            string select = "SELECT MAHDN[Mã HĐ Nhập], MAHANG[Mã Hàng], SOLUONG[Số Lượng], DONGIA[Đơn Giá], THANHTIEN[Thành Tiền] FROM CTHDN";
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

        public bool insertCTHDN(EC_CTHDN cthdn)
        {
            string insert = "INSERT INTO CTHDN VALUES(";
            insert += "N'" + cthdn.MaHDN + "',";
            insert += "N'" + cthdn.MaHang + "',";
            insert += "N'" + cthdn.SoLuong + "',";
            insert += "N'" + cthdn.DonGia + "',";
            insert += "N'" + cthdn.ThanhTien + "')";
            if (!data.UpdateData(insert))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }

        public bool updateCTHDN(EC_CTHDN cthdn)
        {
            string update = "UPDATE CTHDN SET ";
            update += "SOLUONG=N'" + cthdn.SoLuong + "',";
            update += "DONGIA=N'" + cthdn.DonGia + "', ";
            update += "THANHTIEN=N'" + cthdn.ThanhTien + "'";
            update += "WHERE MAHDN=N'" + cthdn.MaHDN + "'";
            update += "AND MAHANG=N'" + cthdn.MaHang + "'"; 
            if (!data.UpdateData(update))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }
        public bool deleteCTHDN1(EC_CTHDN cthdn)
        {
            string delete = "DELETE FROM CTHDN WHERE MAHDN=N'" + cthdn.MaHDN + "' AND MAHANG=N'" + cthdn.MaHang + "'";
            if (!data.UpdateData(delete))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }

        public bool deleteCTHDN2(string maHDN, string maHang)
        {
            string delete = "DELETE FROM CTHDN WHERE MAHDN=N'" + maHDN + "' AND MAHANG=N'" + maHang + "'";
            if (!data.UpdateData(delete))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }
        public DataTable tkMaHDN(string key)
        {
            string select = "SELECT MAHDN[Mã HĐ Nhập], MAHANG[Mã Hàng], SOLUONG[Số Lượng], DONGIA[Đơn Giá], THANHTIEN[Thành Tiền] FROM CTHDN WHERE MAHDN LIKE N'%" + key + "%'";
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

        //load mã hàng
        public DataTable GetMaHang()
        {
            string select = "SELECT * FROM HangHoa";
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
        //load mã hóa đơn nhập
        public DataTable GetMaHoaDonNhap()
        {
            string select = "SELECT * FROM HoaDonNhap";
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
