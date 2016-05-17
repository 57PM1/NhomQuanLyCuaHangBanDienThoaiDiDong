using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EntityClass;
using DataAccess;

namespace Business
{
    public class BU_NhanVien
    {
        private static DA_NhanVien da = new DA_NhanVien();

        public string Error = da.Error;

        public DataTable getAll()
        {
            return da.getAll();
        }
        //public DataTable getAllforReport()
        //{
        //    return da.getAllforReport();
        //}
        public DataTable getAllWith(string select)
        {
            return da.getAllWith(select);
        }
        public bool insertNV(EC_NhanVien nv)
        {
            return da.insertNV(nv);
        }
        public bool updateNV(EC_NhanVien nv)
        {
            return da.updateNV(nv);
        }
        public bool deleteNV(string ma)
        {
            return da.deleteNV(ma);
        }
        public DataTable tkMa(string key)
        {
            return da.tkMa(key);
        }
        public DataTable tkTen(string key)
        {
            return da.tkTen(key);
        }
    }
}
