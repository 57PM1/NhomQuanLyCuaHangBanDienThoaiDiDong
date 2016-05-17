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
   public class BU_CTHDB
    {
       private static DA_CTHDB da = new DA_CTHDB();

       public string Error = da.Error;

       public DataTable getAll()
       {
           return da.getAll();
       }

       public bool insertCTHDB(EC_CTHDB cthdb)
       {
           return da.insertCTHDB(cthdb);
       }

       public bool updateCTHDB(EC_CTHDB cthdb)
       {
           return da.updateCTHDB(cthdb);
       }
       public bool deleteCTHDB1(EC_CTHDB cthdb)
       {
           return da.deleteCTHDB1(cthdb);
       }

       public bool deleteCTHDB2(string maHDB,string maHH)
       {
           return da.deleteCTHDB2(maHDB,maHH);
       }

       public DataTable tkMaHDB(string key)
       {
           return da.tkMaHDB(key);
       }

       //load mã hàng
       public DataTable GetMaHang()
       {
           return da.GetMaHang();
       }

       //Load don gia
       public DataTable GetDonGia(string mahang)
       {
           return da.GetDonGia(mahang);
       }

       //load mã hóa đơn bán
       public DataTable GetMaHoaDonBan()
       {
           return da.GetMaHoaDonBan();
       }
    }
}
