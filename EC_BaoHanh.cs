using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClass
{
   public class EC_BaoHanh
    {
        private string _maBH;
        private string _maKH;
        private string _maHang;
        private string _iMEI;
        private string _ngayBD;
        private string _ngayKT;
        private string _loi;
        private string _ghiChu;

        public string MaBH
        {
            get
            {
                return _maBH;
            }

            set
            {
                _maBH = value;
            }
        }

        public string MaKH
        {
            get
            {
                return _maKH;
            }

            set
            {
                _maKH = value;
            }
        }

        public string MaHang
        {
            get
            {
                return _maHang;
            }

            set
            {
                _maHang = value;
            }
        }

        public string IMEI
        {
            get
            {
                return _iMEI;
            }

            set
            {
                _iMEI = value;
            }
        }

        public string NgayBD
        {
            get
            {
                return _ngayBD;
            }

            set
            {
                _ngayBD = value;
            }
        }

        public string NgayKT
        {
            get
            {
                return _ngayKT;
            }

            set
            {
                _ngayKT = value;
            }
        }

        public string Loi
        {
            get
            {
                return _loi;
            }

            set
            {
                _loi = value;
            }
        }



        public string GhiChu
        {
            get
            {
                return _ghiChu;
            }

            set
            {
                _ghiChu = value;
            }
        }
    }
}
