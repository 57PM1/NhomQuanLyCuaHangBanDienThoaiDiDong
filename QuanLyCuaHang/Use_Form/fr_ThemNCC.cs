using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityClass;
using Business;
using DataAccess;

namespace QuanLyCuaHang.Use_Form
{
    public partial class fr_ThemNCC : Form
    {
        public fr_ThemNCC()
        {
            InitializeComponent();
        }

        BU_NhaCungCap thucthi = new BU_NhaCungCap();
        GetData data = new GetData();
        EC_NhaCungCap ncc = new EC_NhaCungCap();

        private void setnull()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDiaChi.Text = "";
            txtDT.Text = "";
            txtEmail.Text = "";
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMaNCC.Text != "")
            {
                try
                {
                    ncc.MaNCC = txtMaNCC.Text;
                    ncc.TenNCC = txtTenNCC.Text;
                    ncc.DiaChi = txtDiaChi.Text;
                    ncc.DienThoai = txtDT.Text;
                    ncc.Email = txtEmail.Text;

                    setnull();
                    thucthi.insertNCC(ncc);
                    MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                txtMaNCC.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            setnull();
            txtMaNCC.Focus();
        }
    }
}
