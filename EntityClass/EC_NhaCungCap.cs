using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityClass
{
    public class EC_NhaCungCap
    {
        private string _maNCC;

        public string MaNCC
        {
            get { return _maNCC; }
            set { _maNCC = value; }
        }
        private string _tenNCC;

        public string TenNCC
        {
            get { return _tenNCC; }
            set { _tenNCC = value; }
        }
        private string _dienThoai;

        public string DienThoai
        {
            get { return _dienThoai; }
            set { _dienThoai = value; }
        }
        private string _diaChi;

        public string DiaChi
        {
            get { return _diaChi; }
            set { _diaChi = value; }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
    }
}
