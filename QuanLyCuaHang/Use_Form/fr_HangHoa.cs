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
using System.IO;

namespace QuanLyCuaHang.Use_Form
{
    public partial class fr_HangHoa : Form
    {
        public fr_HangHoa()
        {
            InitializeComponent();
        }


        BU_HangHoa thucthi = new BU_HangHoa();
        GetData data = new GetData();
        EC_HangHoa hh = new EC_HangHoa();
        bool themmoi;
        int dong = 0;


        public void setnull()
        {
            txtMaHang.Text = "";
            txtTenHang.Text = "";
            txtDonGiaNhap.Text = "0";
            txtDonGiaBan.Text = "0";
            txtSoLuong.Text = "0";
            txtCPU.Text = "";
            txtRam.Text = "";
            txtPin.Text = "";
            txtKetNoi.Text = "";
            txtHeDieuHanh.Text = "";
            txtBoNho.Text = "";
            txtCamera.Text = "";
            txtDVT.Text = "";
            cbxMaNSX.Text = "";
        }
        public void locktext()
        {
            txtMaHang.Enabled = false;
            txtTenHang.Enabled = false;
            txtDVT.Enabled = false;
            txtCPU.Enabled = false;
            txtRam.Enabled = false;
            txtPin.Enabled = false;
            txtKetNoi.Enabled = false;
            txtHeDieuHanh.Enabled = false;
            txtBoNho.Enabled = false;
            txtCamera.Enabled = false;
            cbxMaNSX.Enabled = false;

            btnThemNSX.Enabled = false;
            //btnThemDVT.Enabled = false;
            btnThemMoi.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
        public void un_locktext()
        {
            txtMaHang.Enabled = true;
            txtTenHang.Enabled = true;
            txtCPU.Enabled = true;
            txtRam.Enabled = true;
            txtPin.Enabled = true;
            txtKetNoi.Enabled = true;
            txtHeDieuHanh.Enabled = true;
            txtBoNho.Enabled = true;
            txtCamera.Enabled = true;
            txtDVT.Enabled = true;
            cbxMaNSX.Enabled = true;

            //btnThemDVT.Enabled = true;
            btnThemNSX.Enabled = true;
            btnThemMoi.Enabled = false;
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

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            themmoi = true;
            un_locktext();
            setnull();
            txtMaHang.Enabled = true;
            txtMaHang.Focus();
        }

        private void fr_HangHoa_Load(object sender, EventArgs e)
        {
            locktext();
            DataTable dt = thucthi.GetMaNSX();
            if (dt != null)
            {
                cbxMaNSX.DataSource = dt;
                cbxMaNSX.ValueMember = "MANSX";
                cbxMaNSX.DisplayMember = "TENNSX";
            }
            else
            {
                MessageBox.Show(thucthi.Error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            hienthi();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaHang.Text != "")
            {
                if (cbxMaNSX.Text != "")
                {
                    if (txtDVT.Text != "")
                    {
                        if (themmoi == true)
                        {
                            try
                            {
                                hh.MaHang = txtMaHang.Text;
                                hh.TenHang = txtTenHang.Text;
                                hh.MaNSX = cbxMaNSX.SelectedValue.ToString();
                                hh.DonViTinh = txtDVT.Text;
                                hh.SoLuong = Int32.Parse(txtSoLuong.Text);
                                //hh.DONGIANHAP = txtDonGiaNhap.Text;
                                hh.DonGiaBan = Int32.Parse(txtDonGiaBan.Text);
                                hh.HinhAnh = null;
                                hh.HeDieuHanh = txtHeDieuHanh.Text;
                                hh.KetNoi = txtKetNoi.Text;
                                hh.Pin = txtPin.Text;
                                hh.Ram = txtRam.Text;
                                hh.BoNho = txtBoNho.Text;
                                hh.Camera = txtCamera.Text;
                                hh.Cpu = txtCPU.Text;


                                thucthi.insertHang(hh);
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
                                hh.MaHang = txtMaHang.Text;
                                hh.TenHang = txtTenHang.Text;
                                hh.MaNSX = cbxMaNSX.SelectedValue.ToString();
                                hh.DonViTinh = txtDVT.Text;
                                hh.SoLuong = Int32.Parse(txtSoLuong.Text);
                                //hh.DONGIANHAP = txtDonGiaNhap.Text;
                                hh.DonGiaBan = Int32.Parse(txtDonGiaBan.Text);
                                hh.HinhAnh = null;
                                hh.HeDieuHanh = txtHeDieuHanh.Text;
                                hh.KetNoi = txtKetNoi.Text;
                                hh.Pin = txtPin.Text;
                                hh.Ram = txtRam.Text;
                                hh.BoNho = txtBoNho.Text;
                                hh.Camera = txtCamera.Text;
                                hh.Cpu = txtCPU.Text;


                                thucthi.updateHang(hh);
                                MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        txtMaHang.Enabled = true;
                        locktext();
                        hienthi();
                    }
                    else
                    {
                        MessageBox.Show("Đơn vị tính Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txtDVT.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Mã nhà sản xuất Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    cbxMaNSX.Focus();
                }
            }
            else
            {
                MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                txtMaHang.Focus();
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            un_locktext();
            txtMaHang.Enabled = false;
            txtTenHang.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    hh.MaHang = txtMaHang.Text;

                    thucthi.deleteHang(hh.MaHang);
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

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            txtMaHang.Text = DataGridView.Rows[dong].Cells[0].Value.ToString();
            txtTenHang.Text = DataGridView.Rows[dong].Cells[1].Value.ToString();
            txtSoLuong.Text = DataGridView.Rows[dong].Cells[2].Value.ToString();
            //txtDonGiaNhap.Text = DataGridView.Rows[dong].Cells[4].Value.ToString();
            txtDonGiaBan.Text = DataGridView.Rows[dong].Cells[3].Value.ToString();
            txtDVT.Text = DataGridView.Rows[dong].Cells[4].Value.ToString();
            //hinh ảnh
            cbxMaNSX.SelectedValue = DataGridView.Rows[dong].Cells[6].Value.ToString();
            txtHeDieuHanh.Text = DataGridView.Rows[dong].Cells[7].Value.ToString();
            txtCPU.Text = DataGridView.Rows[dong].Cells[8].Value.ToString();
            txtRam.Text = DataGridView.Rows[dong].Cells[9].Value.ToString();
            txtPin.Text = DataGridView.Rows[dong].Cells[10].Value.ToString();
            txtKetNoi.Text = DataGridView.Rows[dong].Cells[11].Value.ToString();
            txtBoNho.Text = DataGridView.Rows[dong].Cells[12].Value.ToString();
            txtCamera.Text = DataGridView.Rows[dong].Cells[13].Value.ToString();

            locktext();
        }

        private void btnThemNSX_Click(object sender, EventArgs e)
        {
            fr_ThemNSX fr = new fr_ThemNSX();
            //fr.MdiParent = this;
            fr.Show();
        }

        private void radiobtnMaHH_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobtnMaHH.Checked)
                radiobtnTenHH.Checked = false;
            if (radiobtnMaHH.Checked == false)
                radiobtnTenHH.Checked = true;
        }

        private void radiobtnTenHH_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobtnTenHH.Checked)
                radiobtnMaHH.Checked = false;
            if (radiobtnTenHH.Checked == false)
                radiobtnMaHH.Checked = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (radiobtnMaHH.Checked)
            {
                if (txtTimMaHang.Text != "")
                {
                    //DataGridView.DataSource = thucthi.tkMa(txtTimMaLoaiHang.Text);
                    DataTable dt = thucthi.tkMa(txtTimMaHang.Text);
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
            if (radiobtnTenHH.Checked)
            {
                if (txtTimTenHang.Text != "")
                {
                    //DataGridView.DataSource = thucthi.tkTen(txtTimTenLoaiHang.Text);
                    DataTable dt = thucthi.tkTen(txtTimTenHang.Text);
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
    }
    
}
