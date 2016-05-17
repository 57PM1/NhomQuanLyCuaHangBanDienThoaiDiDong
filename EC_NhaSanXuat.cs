using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClass
{
    public class EC_NhaSanXuat
    {
        private string _mANSX;

        private string _tENNSX;

        public string MANSX
        {
            get
            {
                return _mANSX;
            }

            set
            {
                _mANSX = value;
            }
        }

        public string TENNSX
        {
            get
            {
                return _tENNSX;
            }

            set
            {
                _tENNSX = value;
            }
        }
    }
}
