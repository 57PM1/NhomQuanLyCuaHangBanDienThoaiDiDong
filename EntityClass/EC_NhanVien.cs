using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClass
{
    public class EC_NhanVien
    {
        private string _maNV;

        public string MaNV
        {
            get { return _maNV; }
            set { _maNV = value; }
        }
        private string _tenNV;

        public string TenNV
        {
            get { return _tenNV; }
            set { _tenNV = value; }
        }
        private string _ngaySinh;

        public string NgaySinh
        {
            get { return _ngaySinh; }
            set { _ngaySinh = value; }
        }
        private string _gioiTinh;

        public string GioiTinh
        {
            get { return _gioiTinh; }
            set { _gioiTinh = value; }
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
        private string _chucVu;

        public string ChucVu
        {
            get { return _chucVu; }
            set { _chucVu = value; }
        }
    }
}
