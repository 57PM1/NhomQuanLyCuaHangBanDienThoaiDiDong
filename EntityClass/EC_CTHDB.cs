using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityClass
{
   public class EC_CTHDB
    {


        private string _maHDB;

        public string MaHDB
        {
            get { return _maHDB; }
            set { _maHDB = value; }
        }
        private string _maHang;

        public string MaHang
        {
            get { return _maHang; }
            set { _maHang = value; }
        }
        private int _soLuong;

        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }
        private float _donGia;

        public float DonGia
        {
            get { return _donGia; }
            set { _donGia = value; }
        }


        private float _thanhTien;
       
    
public float thanhTien
{
  get { return _thanhTien; }
  set { _thanhTien = value; }
}
   }
}
