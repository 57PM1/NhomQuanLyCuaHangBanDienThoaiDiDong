using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClass;
using Business;
using DataAccess;

namespace QuanLyCuaHang.Use_Form
{
    public partial class fr_NhaCungCap : Form
    {
        public fr_NhaCungCap()
        {
            InitializeComponent();
        }


        BU_NhaCungCap thucthi = new BU_NhaCungCap();
        GetData data = new GetData();
        EC_NhaCungCap ncc = new EC_NhaCungCap();
        bool themmoi;
        int dong = 0;

        public void setnull()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDiaChi.Text = "";
            txtDT.Text = "";
        }
        public void locktext()
        {
            txtMaNCC.Enabled = false;
            txtTenNCC.Enabled = false;
            txtDiaChi.Enabled = false;
            txtDT.Enabled = false;
            txtEmail.Enabled = false;

            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
        public void un_locktext()
        {
            txtMaNCC.Enabled = true;
            txtTenNCC.Enabled = true;
            txtDiaChi.Enabled = true;
            txtDT.Enabled = true;
            txtEmail.Enabled = true;

            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        public void hienthi()
        {
            DataTable dt = thucthi.getAll();
            if (dt != null)
                DataGridView.DataSource = dt;
            else
            {
                MessageBox.Show(thucthi.Error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void fr_NhaCungCap_Load(object sender, EventArgs e)
        {
            locktext();
            hienthi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            themmoi = true;
            un_locktext();
            setnull();
            txtMaNCC.Enabled = true;
            txtMaNCC.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaNCC.Text != "")
            {
                if (themmoi == true)
                {
                    try
                    {
                        ncc.MaNCC = txtMaNCC.Text;
                        ncc.TenNCC = txtTenNCC.Text;
                        ncc.DiaChi = txtDiaChi.Text;
                        ncc.DienThoai = txtDT.Text;
                        ncc.Email = txtEmail.Text;

                        thucthi.insertNCC(ncc);
                        locktext();
                        hienthi();
                        MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    try
                    {
                        ncc.MaNCC = txtMaNCC.Text;
                        ncc.TenNCC = txtTenNCC.Text;
                        ncc.DiaChi = txtDiaChi.Text;
                        ncc.DienThoai = txtDT.Text;
                        ncc.Email = txtEmail.Text;

                        thucthi.updateNCC(ncc);
                        MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                txtMaNCC.Enabled = true;
                locktext();
                hienthi();
            }
            else
            {
                MessageBox.Show("Mã NCCông được để trống", "Chú Ý", MessageBoxButtons.OK);
                txtMaNCC.Focus();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            un_locktext();
            txtMaNCC.Enabled = false;
            txtTenNCC.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ncc.MaNCC = txtMaNCC.Text;

                    thucthi.deleteNCC(ncc);
                    MessageBox.Show("Đã Xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienthi();
                    setnull();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi");
                }
            }
        }

        private void radiobtnMaNCC_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobtnMaNCC.Checked)
                radiobtnTenNCC.Checked = false;
            if (radiobtnMaNCC.Checked == false)
                radiobtnTenNCC.Checked = true;
        }

        private void radiobtnTenNCC_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobtnTenNCC.Checked)
                radiobtnMaNCC.Checked = false;
            if (radiobtnTenNCC.Checked == false)
                radiobtnMaNCC.Checked = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (radiobtnMaNCC.Checked)
            {
                if (txtTimMaNCC.Text != "")
                {
                    //DataGridView.DataSource = thucthi.searchMaNCC(txtTimMaNCC.Text);
                    DataTable dt = thucthi.searchMaNCC(txtTimMaNCC.Text);
                    if (dt != null)
                        DataGridView.DataSource = dt;
                    else
                    {
                        MessageBox.Show(thucthi.Error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Mã NCC không được để trống", "Chú Ý", MessageBoxButtons.OK);
            }
            if (radiobtnTenNCC.Checked)
            {
                if (txtTimTenNCC.Text != "")
                {
                    //DataGridView.DataSource = thucthi.searchTenNCC(txtTimTenNCC.Text);
                    DataTable dt = thucthi.searchTenNCC(txtTimTenNCC.Text);
                    if (dt != null)
                        DataGridView.DataSource = dt;
                    else
                    {
                        MessageBox.Show(thucthi.Error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Tên NCC không được để trống", "Chú Ý", MessageBoxButtons.OK);
            }
        }
    

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            txtMaNCC.Text = DataGridView.Rows[dong].Cells[0].Value.ToString();
            txtTenNCC.Text = DataGridView.Rows[dong].Cells[1].Value.ToString();
            txtDT.Text = DataGridView.Rows[dong].Cells[2].Value.ToString();
            txtDiaChi.Text = DataGridView.Rows[dong].Cells[3].Value.ToString();
            txtEmail.Text = DataGridView.Rows[dong].Cells[4].Value.ToString();
            locktext();
        }
    }
}
