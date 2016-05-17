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
   public class BU_HoaDonBan
    {
       private static DA_HoaDonBan da = new DA_HoaDonBan();

       public string Error = da.Error;

       public DataTable getAll()
        {
            return da.getAll();
        }

        public bool insertHDB(EC_HoaDonBan hd)
        {
            return da.insertHDB(hd);
        }

        public bool updateHDB(EC_HoaDonBan hd)
        {
            return da.updateHDB(hd);
        }

        public bool deleteHDB(EC_HoaDonBan hd)
        {
            return da.deleteHDB(hd);
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

        //load khach hang
        public DataTable GetKhachHang()
        {
            return da.GetKhachHang();
        }
        public DataTable GetTTHoaDon(string mahd)
   {
       return da.GetTTHoaDon(mahd);
   }
    }
}
