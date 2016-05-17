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
    public class DA_HangHoa
    {
        GetData data = new GetData();

        private string _error;

        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }

        public int soluong(string mahang)
        {
            int i = 0;
            string select = "select SOLUONG from MatHang Where MAHANG=N'" + mahang + "'";
            try
            {
                DataTable dt = data.getdata(select);
                i = Convert.ToInt16(dt.Rows[0][0]);
            }
            catch
            {
                Error = data.Error;
            }
            return i;
        }
        public long layGiaBan(string ma)
        {
            long a = 0;
            string select = "select DONGIABAN from MatHang where MAHANG=N'" + ma + "'";
            DataTable dt = new DataTable();
            dt = data.getdata(select);
            try
            {
                a = Convert.ToInt64(dt.Rows[0][0]);
            }
            catch (Exception e)
            {
                Error = e.Message;
            }
            return a;
        }
        public DataTable getAll()
        {
            string select = "select MAHANG[Mã Hàng], TENHANG[Tên Hàng], SOLUONG[Số Lượng], DONGIABAN[Đơn Giá Bán], DONVITINH[Đơn Vị Tính], HINHANH[Hình Ảnh], MANSX[Mã NSX], HEDIEUHANH[Hệ Điều Hành], CPU[CPU], RAM[RAM], PIN[PIN],KETNOI[Kết Nối],BONHO[Bộ Nhớ],CAMERA[Camera] from HangHoa";
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
        //    string select = "select * from HangHoa";
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
        public bool insertHang(EC_HangHoa hang)
        {
            string strInsert = "insert into HangHoa values( ";
            strInsert += "N'" + hang.MaHang + "', ";
            strInsert += "N'" + hang.TenHang + "', ";
            strInsert += "N'" + hang.SoLuong + "', ";
            strInsert += "N'" + hang.DonGiaBan + "', ";
            strInsert += "N'" + hang.DonViTinh + "', ";
            strInsert += "N'" + hang.HinhAnh + "', ";
            strInsert += "N'" + hang.MaNSX + "',";
            strInsert += "N'" + hang.HeDieuHanh + "',";
            strInsert += "N'" + hang.Cpu + "',";
            strInsert += "N'" + hang.Ram + "',";
            strInsert += "N'" + hang.Pin + "',";
            strInsert += "N'" + hang.KetNoi + "',";
            strInsert += "N'" + hang.BoNho + "', ";
            strInsert += "N'" + hang.Camera + "')";
            if (!data.UpdateData(strInsert))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }
        public bool updateHang(EC_HangHoa hang)
        {
            string strUpdate = "update HangHoa set ";
            strUpdate += "TENHANG=N'" + hang.TenHang + "', ";
            strUpdate += "SOLUONG=N'" + hang.SoLuong + "', ";
            strUpdate += "DONGIABAN=N'" + hang.DonGiaBan + "', ";
            strUpdate += "DONVITINH=N'" + hang.DonViTinh + "', ";
            strUpdate += "HINHANH=N'" + hang.HinhAnh + "', ";
            strUpdate += "MANSX=N'" + hang.MaNSX + "', ";
            strUpdate += "HEDIEUHANH=N'" + hang.HeDieuHanh + "', ";
            strUpdate += "CPU=N'" + hang.Cpu + "', ";
            strUpdate += "RAM=N'" + hang.Ram + "', ";
            strUpdate += "PIN=N'" + hang.Pin + "', ";
            strUpdate += "KETNOI=N'" + hang.KetNoi + "', ";
            strUpdate += "BONHO=N'" + hang.BoNho + "', ";
            strUpdate += "CAMERA=N'" + hang.Camera + "' ";
            strUpdate += " where MAHANG=N'" + hang.MaHang + "'";

            if (!data.UpdateData(strUpdate))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }
        public bool deleteHang(string ma)
        {
            string delete = "delete  from HangHoa where MAHANG=N'" + ma + "'";
            if (!data.UpdateData(delete))
            {
                Error = data.Error;
                return false;
            }
            return true;
        }
        public DataTable tkMa(string key)
        {
            string select = "select MAHANG[Mã Hàng], TENHANG[Tên Hàng], SOLUONG[Số Lượng], DONGIABAN[Đơn Giá Bán], DONVITINH[Đơn Vị Tính], HINHANH[Hình Ảnh], MANSX[Mã NSX], HEDIEUHANH[Hệ Điều Hành], CPU[CPU], RAM[RAM], PIN[PIN],KETNOI[Kết Nối],BONHO[Bộ Nhớ],CAMERA[Camera]  from HangHoa where MAHANG like N'%" + key + "%'";
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
            string select = "select MAHANG[Mã Hàng], TENHANG[Tên Hàng], SOLUONG[Số Lượng], DONGIABAN[Đơn Giá Bán], DONVITINH[Đơn Vị Tính], HINHANH[Hình Ảnh], MANSX[Mã NSX], HEDIEUHANH[Hệ Điều Hành], CPU[CPU], RAM[RAM], PIN[PIN],KETNOI[Kết Nối],BONHO[Bộ Nhớ],CAMERA[Camera]  from HangHoa where TENHANG like N'%" + key + "%'";
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
        public string getImage(string key)
        {
            string select = "select HINHANH from HangHoa WHERE MAHANG=N'" + key + "'";
            try
            {
                return data.getdata(select).Rows[0][0].ToString();
            }
            catch
            {
                Error = data.Error;
                return null;
            }
        }
        //load nha san xuat
        public DataTable GetMaNSX()
        {
            string select = "SELECT * FROM NhaSanXuat";
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
