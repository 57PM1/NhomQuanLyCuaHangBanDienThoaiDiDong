using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Business;
using EntityClass;
using DataAccess;


namespace QuanLyCuaHang.Use_Form
{
    public partial class fr_HDN : Form
    {
        public fr_HDN()
        {
            InitializeComponent();
        }
        BU_HoaDonNhap thucthi = new BU_HoaDonNhap();
        GetData data = new GetData();
        EC_HoaDonNhap hdn = new EC_HoaDonNhap();
        bool themmoi;
        int dong = 0;

        public void setnull()
        {
            txtMaHDN.Text = "";
            dateNgayNhap.Text = DateTime.Now.ToShortTimeString();
            cbxNV.Text = "";
            cbxNCC.Text = "";
            txtThanhTien.Text = "0";
        }
        public void locktext()
        {
            txtMaHDN.Enabled = false;
            dateNgayNhap.Enabled = false;
            cbxNV.Enabled = false;
            cbxNCC.Enabled = false;
            txtThanhTien.Enabled = false;

            btnThem.Enabled = true;
            btLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
        public void un_locktext()
        {
            txtMaHDN.Enabled = true;
            dateNgayNhap.Enabled = true;
            cbxNV.Enabled = true;
            cbxNCC.Enabled = true;
            //txtThanhTien.Enabled = true;

            btnThem.Enabled = false;
            btLuu.Enabled = true;
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

        private void fr_HDN_Load(object sender, EventArgs e)
        {
            locktext();
            //Load combobox nhân viên
            DataTable dt = thucthi.GetNhanVien();
            if (dt != null)
            {
                cbxNV.DataSource = dt;
                cbxNV.ValueMember = "MANV";
                cbxNV.DisplayMember = "TENNV";
            }
            else
            {
                MessageBox.Show(thucthi.Error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Load combobox nhà cung cấp
            dt = thucthi.GetNhaCungCap();
            if (dt != null)
            {
                cbxNCC.DataSource = dt;
                cbxNCC.ValueMember = "MANCC";
                cbxNCC.DisplayMember = "TENNCC";
            }
            else
            {
                MessageBox.Show(thucthi.Error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            hienthi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            themmoi = true;
            un_locktext();
            setnull();
            txtMaHDN.Enabled = true;
            txtMaHDN.Focus();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (txtMaHDN.Text != "")
            {
                if (cbxNV.Text != "")
                {
                    if (themmoi == true)
                    {
                        try
                        {
                            hdn.MaHDN = txtMaHDN.Text;
                            hdn.MaNV = cbxNV.SelectedValue.ToString();
                            hdn.MaNCC = cbxNCC.SelectedValue.ToString();
                            hdn.NgayNhap = dateNgayNhap.Text;
                            hdn.TongTien = int.Parse(txtThanhTien.Text);

                            thucthi.insertHDN(hdn);
                            locktext();
                            hienthi();
                            MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            fr_CTHDN fr = new fr_CTHDN();
                            fr.SOHDN = txtMaHDN.Text;
                            this.Close();
                            fr.Show();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                        try
                        {
                            hdn.MaHDN = txtMaHDN.Text;
                            hdn.MaNV = cbxNV.SelectedValue.ToString();
                            hdn.MaNCC = cbxNCC.SelectedValue.ToString();
                            hdn.NgayNhap = dateNgayNhap.Text;
                            hdn.TongTien = int.Parse(txtThanhTien.Text);

                            thucthi.updateHDN(hdn);
                            MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            fr_CTHDN fr = new fr_CTHDN();
                            fr.SOHDN = txtMaHDN.Text;
                            this.Hide();
                            fr.ShowDialog();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    txtMaHDN.Enabled = true;
                    locktext();
                    hienthi();
                }
                else
                {
                    MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    cbxNV.Focus();
                }
            }
            else
            {
                MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                txtMaHDN.Focus();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            un_locktext();
            txtMaHDN.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    hdn.MaHDN = txtMaHDN.Text;

                    thucthi.deleteHDN(hdn);
                    MessageBox.Show("Đã Xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienthi();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi");
                }
            }
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            fr_ThemNCC fr = new fr_ThemNCC();
            fr.Show();
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            txtMaHDN.Text = DataGridView.Rows[dong].Cells[0].Value.ToString();
            dateNgayNhap.Text = DataGridView.Rows[dong].Cells[1].Value.ToString();
            cbxNV.SelectedText = DataGridView.Rows[dong].Cells[2].Value.ToString();
            cbxNCC.SelectedText = DataGridView.Rows[dong].Cells[3].Value.ToString();
            txtThanhTien.Text = DataGridView.Rows[dong].Cells[4].Value.ToString();
            locktext();
        }

        private void btnThemCT_Click(object sender, EventArgs e)
        {
            fr_CTHDN fr = new fr_CTHDN();
            fr.Show();
        }
    }
}
