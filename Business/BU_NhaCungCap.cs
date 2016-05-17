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
    public class BU_NhaCungCap
    {
        private static DA_NhaCungCap da = new DA_NhaCungCap();

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
        public DataTable searchMaNCC(string key)
        {
            return da.searchMaNCC(key);
        }
        public DataTable searchTenNCC(string key)
        {
            return da.searchTenNCC(key);
        }
        public bool insertNCC(EC_NhaCungCap ncc)
        {
            return da.insertNCC(ncc);
        }
        public bool updateNCC(EC_NhaCungCap ncc)
        {
            return da.updateNCC(ncc);
        }
        public bool deleteNCC(EC_NhaCungCap ncc)
        {
            return da.deleteNCC(ncc);
        }
    }
}
