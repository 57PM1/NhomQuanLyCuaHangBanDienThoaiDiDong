using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EntityClass;
using DataAccess;

namespace Business
{
    public class BU_HangHoa
    {
        private static DA_HangHoa da = new DA_HangHoa();

        public string Error = da.Error;

        public int soluong(string mahang)
        {
            return da.soluong(mahang);
        }
        public long layGiaBan(string ma)
        {
            return da.layGiaBan(ma);
        }
        public DataTable getAll()
        {
            return da.getAll();
        }
        //public DataTable getAllforReport()
        //{
        //    return da.getAllforReport();
        //}
        public bool insertHang(EC_HangHoa hang)
        {
            return da.insertHang(hang);
        }
        public bool updateHang(EC_HangHoa hang)
        {
            return da.updateHang(hang);
        }
        public bool deleteHang(string ma)
        {
            return da.deleteHang(ma);
        }
        public DataTable tkMa(string key)
        {
            return da.tkMa(key);
        }
        public DataTable tkTen(string key)
        {
            return da.tkTen(key);
        }
        public DataTable getAllWith(string key)
        {
            return da.getAllWith(key);
        }
        public string getImage(string key)
        {
            return da.getImage(key);
        }
        //load loại
        public DataTable GetMaNSX()
        {
            return da.GetMaNSX();
        }
    }
}
