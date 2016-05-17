using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EntityClass;
using DataAccess;

namespace Business
{
    public class BU_TaiKhoan
    {
        private static DA_TaiKhoan da = new DA_TaiKhoan();

        public string Error = da.Error;

        public DataTable getAll()
        {
            return da.getAll();
        }
        public DataTable getUser(EC_TaiKhoan tk)
        {
            return da.getUser(tk);
        }
        public bool insertTK(EC_TaiKhoan tk)
        {
            return da.insertTK(tk);
        }
        public bool updateTK(EC_TaiKhoan tk)
        {
            return da.updateTK(tk);
        }
        public bool deleteTK(EC_TaiKhoan tk)
        {
            return da.deleteTK(tk);
        }
        public bool updateMK(EC_TaiKhoan tk)
        {
            return da.updateMK(tk);
        }

        public bool ktTK(EC_TaiKhoan tk)
        {
            return da.ktTK(tk);
        }

        public DataTable tkTenTK(string key)
        {
            return da.tkTenTK(key);
        }
        public DataTable tkQuyen(string key)
        {
            return da.tkQuyen(key);
        }
    }
}
