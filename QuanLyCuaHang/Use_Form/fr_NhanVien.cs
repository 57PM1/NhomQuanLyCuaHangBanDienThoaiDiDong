using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DataAccess;
using EntityClass;
using Business;

namespace QuanLyCuaHang.Use_Form
{
    public partial class fr_NhanVien : Form
    {
        public fr_NhanVien()
        {
            InitializeComponent();
        }

        BU_NhanVien thucthi = new BU_NhanVien();
        GetData data = new GetData();
        EC_NhanVien nv = new EC_NhanVien();
        bool themmoi;
        int dong = 0;


        public void setnull()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            cbxGioiTinh.Text = "Nam";
            dateTimeNgaySinh.Text = DateTime.Now.ToShortTimeString();
            txtDT.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtChucVu.Text = "";
        }
        public void locktext()
        {
            txtMaNV.Enabled = false;
            txtTenNV.Enabled = false;
            cbxGioiTinh.Enabled = false;
            dateTimeNgaySinh.Enabled = false;
            txtDiaChi.Enabled = false;
            txtDT.Enabled = false;
            txtEmail.Enabled = false;
            txtChucVu.Enabled = false;

            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
        public void un_locktext()
        {
            txtMaNV.Enabled = true;
            txtTenNV.Enabled = true;
            cbxGioiTinh.Enabled = true;
            dateTimeNgaySinh.Enabled = true;
            txtDiaChi.Enabled = true;
            txtDT.Enabled = true;
            txtEmail.Enabled = true;
            txtChucVu.Enabled = true;

            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        public void khoitaoluoi()
        {
            DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridView.Columns[0].HeaderText = "Mã Nhân Viên";
            DataGridView.Columns[0].Frozen = true;
            DataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridView.Columns[0].Width = 100;

            DataGridView.Columns[1].HeaderText = "Tên Nhân Viên";
            DataGridView.Columns[1].Width = 200;

            DataGridView.Columns[2].HeaderText = "Ngày Sinh";
            DataGridView.Columns[2].Width = 200;

            DataGridView.Columns[3].HeaderText = "Giới Tính";
            DataGridView.Columns[3].Width = 200;

            DataGridView.Columns[4].HeaderText = "Điện Thoại";
            DataGridView.Columns[4].Width = 200;

            DataGridView.Columns[5].HeaderText = "Địa Chỉ";
            DataGridView.Columns[5].Width = 200;

            DataGridView.Columns[6].HeaderText = "Email";
            DataGridView.Columns[6].Width = 200;

            DataGridView.Columns[7].HeaderText = "Chức Vụ";
            DataGridView.Columns[7].Width = 200;

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

        private void fr_NhanVien_Load(object sender, EventArgs e)
        {
            locktext();
            hienthi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            themmoi = true;
            un_locktext();
            setnull();
            txtMaNV.Enabled = true;
            txtMaNV.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text != "")
            {
                {
                    if (themmoi == true)
                    {
                        try
                        {
                            nv.MaNV = txtMaNV.Text;
                            nv.TenNV = txtTenNV.Text;
                            nv.NgaySinh = dateTimeNgaySinh.Text;
                            nv.GioiTinh = cbxGioiTinh.Text;
                            nv.DienThoai = txtDT.Text;
                            nv.DiaChi = txtDiaChi.Text;
                            nv.Email = txtEmail.Text;
                            nv.ChucVu = txtChucVu.Text;

                            thucthi.insertNV(nv);
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
                            nv.MaNV = txtMaNV.Text;
                            nv.TenNV = txtTenNV.Text;
                            nv.NgaySinh = dateTimeNgaySinh.Text;
                            nv.GioiTinh = cbxGioiTinh.Text;
                            nv.DienThoai = txtDT.Text;
                            nv.DiaChi = txtDiaChi.Text;
                            nv.Email = txtEmail.Text;
                            nv.ChucVu = txtChucVu.Text;

                            thucthi.updateNV(nv);
                            MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    txtMaNV.Enabled = true;
                    locktext();
                    hienthi();
                }
            }
            else
            {
                MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                txtMaNV.Focus();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            un_locktext();
            txtMaNV.Enabled = false;
            txtTenNV.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    nv.MaNV = txtMaNV.Text;

                    thucthi.deleteNV(nv.MaNV);
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

        private void radiobtnMaNV_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobtnMaNV.Checked)
                radiobtnTenNV.Checked = false;
            if (radiobtnMaNV.Checked == false)
                radiobtnTenNV.Checked = true;
        }

        private void radiobtnTenNV_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobtnTenNV.Checked)
                radiobtnMaNV.Checked = false;
            if (radiobtnTenNV.Checked == false)
                radiobtnMaNV.Checked = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (radiobtnMaNV.Checked)
            {
                if (txtTimMaNV.Text != "")
                {
                    //DataGridView.DataSource = thucthi.tkMa(txtTimMaNV.Text);
                    DataTable dt = thucthi.tkMa(txtTimMaNV.Text);
                    if (dt != null)
                        DataGridView.DataSource = dt;
                    else
                    {
                        MessageBox.Show(thucthi.Error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
            }
            if (radiobtnTenNV.Checked)
            {
                if (txtTimTenNV.Text != "")
                {
                    //DataGridView.DataSource = thucthi.tkTen(txtTimTenNV.Text);
                    DataTable dt = thucthi.tkTen(txtTimTenNV.Text);
                    if (dt != null)
                        DataGridView.DataSource = dt;
                    else
                    {
                        MessageBox.Show(thucthi.Error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Tên Không được để trống", "Chú Ý", MessageBoxButtons.OK);
            }
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            txtMaNV.Text = DataGridView.Rows[dong].Cells[0].Value.ToString();
            txtTenNV.Text = DataGridView.Rows[dong].Cells[1].Value.ToString();
            dateTimeNgaySinh.Text = DataGridView.Rows[dong].Cells[2].Value.ToString();
            cbxGioiTinh.Text = DataGridView.Rows[dong].Cells[3].Value.ToString();
            txtDT.Text = DataGridView.Rows[dong].Cells[4].Value.ToString();
            txtDiaChi.Text = DataGridView.Rows[dong].Cells[5].Value.ToString();
            txtEmail.Text = DataGridView.Rows[dong].Cells[6].Value.ToString();
            txtChucVu.Text = DataGridView.Rows[dong].Cells[7].Value.ToString();
            locktext();
        }
    }
}
