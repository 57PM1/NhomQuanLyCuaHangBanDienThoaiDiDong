using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;


namespace EntityClass
{
    public class EC_HangHoa
    {
        private string _maHang;

        public string MaHang
        {
            get { return _maHang; }
            set { _maHang = value; }
        }
        private string _tenHang;

        public string TenHang
        {
            get { return _tenHang; }
            set { _tenHang = value; }
        }
        private int _soLuong;

        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }
        private float _donGiaBan;

        public float DonGiaBan
        {
            get { return _donGiaBan; }
            set { _donGiaBan = value; }
        }
        private string _donViTinh;

        public string DonViTinh
        {
            get { return _donViTinh; }
            set { _donViTinh = value; }
        }
        private string _hinhAnh;

        public string HinhAnh
        {
            get { return _hinhAnh; }
            set { _hinhAnh = value; }
        }
        private string _maNSX;
        public string MaNSX
        {
            get { return _maNSX; }
            set { _maNSX = value; }
        }

        public string HeDieuHanh
        {
            get
            {
                return heDieuHanh;
            }

            set
            {
                heDieuHanh = value;
            }
        }

        public string Cpu
        {
            get
            {
                return cpu;
            }

            set
            {
                cpu = value;
            }
        }

        public string Ram
        {
            get
            {
                return ram;
            }

            set
            {
                ram = value;
            }
        }

        public string Pin
        {
            get
            {
                return pin;
            }

            set
            {
                pin = value;
            }
        }

        public string KetNoi
        {
            get
            {
                return ketNoi;
            }

            set
            {
                ketNoi = value;
            }
        }

        public string BoNho
        {
            get
            {
                return boNho;
            }

            set
            {
                boNho = value;
            }
        }

        public string Camera
        {
            get
            {
                return camera;
            }

            set
            {
                camera = value;
            }
        }

        private string heDieuHanh;
        private string cpu;
        private string ram;
        private string pin;
        private string ketNoi;
        private string boNho;
        private string camera;
    }
}
