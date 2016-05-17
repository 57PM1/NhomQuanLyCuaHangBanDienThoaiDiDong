using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityClass
{
   public class EC_HoaDonNhap
    {
        private string _maHDN;

        public string MaHDN
        {
            get { return _maHDN; }
            set { _maHDN = value; }
        }
        private string _ngayNhap;

        public string NgayNhap
        {
            get { return _ngayNhap; }
            set { _ngayNhap = value; }
        }
        private string _maNV;

        public string MaNV
        {
            get { return _maNV; }
            set { _maNV = value; }
        }
        private string _maNCC;

        public string MaNCC
        {
            get { return _maNCC; }
            set { _maNCC = value; }
        }
        private int _tongTien;

        public int TongTien
        {
            get { return _tongTien; }
            set { _tongTien = value; }
        }
    }
}
