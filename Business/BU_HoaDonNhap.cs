using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EntityClass;
using DataAccess;

namespace Business
{
   public class BU_HoaDonNhap
    {
        private static DA_HoaDonNhap da = new DA_HoaDonNhap();

        public string Error = da.Error;

        public DataTable getAll()
        {
            return da.GetAll();
        }

        public bool insertHDN(EC_HoaDonNhap hd)
        {
            return da.insertHDN(hd);
        }

        public bool updateHDN(EC_HoaDonNhap hd)
        {
            return da.updateHDN(hd);
        }

        public bool deleteHDN(EC_HoaDonNhap hd)
        {
            return da.deleteHDN(hd);
        }

        public DataTable tkMa(string key)
        {
            return da.tkMa(key);
        }

        //load Nhân Viên
        public DataTable GetNhanVien()
        {
            return da.GetNhanVien();
        }

        //load Nhà cung cấp
        public DataTable GetNhaCungCap()
        {
            return da.GetNhaCungCap();
        }
        public DataTable GetTTHoaDonNhapHang(string mahd)
        {
            return da.GetTTHoaDonNhapHang(mahd);
        }
    }
}
