using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityClass;
using System.Data;

namespace DataAccess
{
    public class DA_BaoHanh
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
            string select = "SELECT MABH[Mã BH], MAKH[Mã KH], MAHANG[Mã Hàng], IMEI[IMEI], NGAYBD[Ngày BĐ], NGAYKT[Ngày KT], LOI[Lỗi], GHICHU[Ghi Chú] FROM BaoHanh";
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

        public bool insertBaoHanh(EC_BaoHanh bh)
        {
            string strInsert = "insert into BaoHanh values( ";
            strInsert += "N'" + bh.MaBH + "', ";
            strInsert += "N'" + bh.MaKH + "', ";
            strInsert += "N'" + bh.MaHang + "', ";
            strInsert += "N'" + bh.IMEI + "', ";
            strInsert += "N'" + bh.NgayBD + "', ";
            strInsert += "N'" + bh.NgayKT + "', ";
            strInsert += "N'" + bh.Loi + "',";
            strInsert += "N'" + bh.GhiChu + "')";
            if (!data.UpdateData(strInsert))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }

        public bool updateBaoHanh(EC_BaoHanh bh)
        {
            string strUpdate = "update BaoHanh set ";
            strUpdate += "MABH=N'" + bh.MaBH + "', ";
            strUpdate += "MAKH=N'" + bh.MaBH + "', ";
            strUpdate += "MAHANG=N'" + bh.MaHang + "', ";
            strUpdate += "IMEI=N'" + bh.IMEI + "', ";
            strUpdate += "NGAYBD=N'" + bh.NgayBD + "', ";
            strUpdate += "NGAYKT=N'" + bh.NgayKT + "', ";
            strUpdate += "LOI=N'" + bh.Loi + "', ";
            strUpdate += "GHICHU=N'" + bh.GhiChu + "'";

            if (!data.UpdateData(strUpdate))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }

        public bool deleteBaohanh(string ma)
        {
            string delete = "delete  from BaoHanh where MABH=N'" + ma + "'";
            if (!data.UpdateData(delete))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }
        public DataTable tkMa(string key)
        {
            string select = "select SELECT MABH[Mã BH], MAKH[Mã KH], MAHANG[Mã Hàng], IMEI[IMEI], NGAYBD[Ngày BĐ], NGAYKT[Ngày KT], LOI[Lỗi], GHICHU[Ghi Chú] FROM BaoHanh where MaBH like N'%" + key + "%'";
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

        public DataTable tkIMEI(string key)
        {
            string select = "select SELECT MABH[Mã BH], MAKH[Mã KH], MAHANG[Mã Hàng], IMEI[IMEI], NGAYBD[Ngày BĐ], NGAYKT[Ngày KT], LOI[Lỗi], GHICHU[Ghi Chú] FROM BaoHanh where IMEI like N'%" + key + "%'";
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

        public DataTable GetMaKH()
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
    }
}
