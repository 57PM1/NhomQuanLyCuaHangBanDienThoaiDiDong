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
   public class BU_CTHDN
    {
        private static DA_CTHDN da = new DA_CTHDN();

        public string Error = da.Error;

        public DataTable getAll()
        {
            return da.getAll();
        }

        public bool insertCTHDN(EC_CTHDN CTHDN)
        {
            return da.insertCTHDN(CTHDN);
        }

        public bool updateCTHDN(EC_CTHDN CTHDN)
        {
            return da.updateCTHDN(CTHDN);
        }
        public bool deleteCTHDN1(EC_CTHDN cthdn)
        {
            return da.deleteCTHDN1(cthdn);
        }
        public bool deleteCTHDN2(string maHDN, string maHH)
        {
            return da.deleteCTHDN2(maHDN, maHH);
        }
        public DataTable tkMaHDN(string key)
        {
            return da.tkMaHDN(key);
        }
        public DataTable GetMaHang()
        {
            return da.GetMaHang();
        }

        //load mã hóa đơn nhập
        public DataTable GetMaHoaDonNhap()
        {
            return da.GetMaHoaDonNhap();
        }
    }
}
