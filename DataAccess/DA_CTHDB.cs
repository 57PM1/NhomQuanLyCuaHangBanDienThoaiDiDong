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
    public class DA_CTHDB
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
            string select = "SELECT  MAHDB[Mã HĐ Bán], MAHANG[Mã Hàng], SOLUONG[Số Lượng], DONGIA[Đơn Giá], THANHTIEN[Thành Tiền] FROM CTHDB";
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

        public bool insertCTHDB(EC_CTHDB cthdb)
        {
            string insert = "INSERT INTO CTHDB VALUES(";
            insert += "N'" + cthdb.MaHDB + "',";
            insert += "N'" + cthdb.MaHang + "',";
            insert += "N'" + cthdb.SoLuong + "',";
            insert += "N'" + cthdb.DonGia + "',";
            insert += "N'" + cthdb.thanhTien + "')";
            if (!data.UpdateData(insert))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }

        public bool updateCTHDB(EC_CTHDB cthdb)
        {
            string update = "UPDATE CTHDB SET ";
            update += "SOLUONG=N'" + cthdb.SoLuong + "',";
            update += "DONGIA=N'" + cthdb.DonGia + "', ";
            update += "THANHTIEN=N'" + cthdb.thanhTien + "'";
            update += "WHERE MAHDB=N'" + cthdb.MaHDB + "'";
            update += "AND MAHANG=N'" + cthdb.MaHang + "'";
            if (!data.UpdateData(update))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }
        public bool deleteCTHDB1(EC_CTHDB cthdb)
        {
            string delete = "DELETE FROM CTHDB WHERE MAHDB=N'" + cthdb.MaHDB + "' AND MAHANG=N'"+cthdb.MaHang+"'";
            if (!data.UpdateData(delete))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }

        public bool deleteCTHDB2(string maHDB,string maHang)
        {
            string delete = "DELETE FROM CTHDB WHERE MAHDB=N'" + maHDB + "' AND MAHANG=N'"+maHang+"'";
            if (!data.UpdateData(delete))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }

        public DataTable tkMaHDB(string key)
        {
            string select = "SELECT MAHDB[Mã HĐ Bán], MAHANG[Mã Hàng], SOLUONG[Số Lượng], DONGIA[Đơn Giá], THANHTIEN[Thành Tiền] FROM CTHDB WHERE MAHDB LIKE N'%" + key + "%'";
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

        //Load don gia
        public DataTable GetDonGia(string mahang)
        {
            string select = "SELECT DONGIABAN From HangHoa where MAHANG= N'" + mahang + "'";
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

        //load mã hóa đơn bán
        public DataTable GetMaHoaDonBan()
        {
            string select = "SELECT * FROM HoaDonBan";
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
