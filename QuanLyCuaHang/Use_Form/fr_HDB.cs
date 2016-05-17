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
using DataAccess;
using EntityClass;
using QuanLyCuaHang.Use_Form;

namespace QuanLyCuaHang.Use_Form
{
    public partial class fr_HDB : Form
    {
        public fr_HDB()
        {
            InitializeComponent();
        }
        BU_HoaDonBan thucthi = new BU_HoaDonBan();
        GetData data = new GetData();
        EC_HoaDonBan hdb = new EC_HoaDonBan();
        bool themmoi;
        int dong = 0;

        public void setnull()
        {
            txtMaHDB.Text = "";
            dateNgayBan.Text = DateTime.Now.ToShortTimeString();
            cbxKH.Text = "";
            cbxNV.Text = "";
            txtThanhTien.Text = "0";
        }
        public void locktext()
        {
            txtMaHDB.Enabled = false;
            dateNgayBan.Enabled = false;
            cbxKH.Enabled = false;
            cbxNV.Enabled = false;

            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThemCTHDB.Enabled = true;
        }
        public void un_locktext()
        {
            txtMaHDB.Enabled = true;
            dateNgayBan.Enabled = true;
            cbxKH.Enabled = true;
            cbxNV.Enabled = true;

            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThemCTHDB.Enabled = true;
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
        private void fr_HDB_Load(object sender, EventArgs e)
        {
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
            //Load combobox khach hàng
            dt = thucthi.GetKhachHang();
            if (dt != null)
            {
                cbxKH.DataSource = dt;
                cbxKH.ValueMember = "MAKH";
                cbxKH.DisplayMember = "TENKH";
            }
            else
            {
                MessageBox.Show(thucthi.Error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            hienthi();
            locktext();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            themmoi = true;
            un_locktext();
            setnull();
            txtMaHDB.Enabled = true;
            txtMaHDB.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaHDB.Text != "")
            {
                if (cbxNV.Text != "")
                {
                    if (cbxKH.Text != "")
                    {
                        if (themmoi == true)
                        {
                            try
                            {
                                //dong = int.Parse(txtma.Text);
                                hdb.MaHDB = txtMaHDB.Text;
                                hdb.MaNV = cbxNV.SelectedValue.ToString();
                                hdb.NgayBan = dateNgayBan.Text;
                                hdb.MaKH = cbxKH.SelectedValue.ToString();
                                hdb.TongTien = Int32.Parse(txtThanhTien.Text);

                                thucthi.insertHDB(hdb);
                                locktext();
                                hienthi();
                                MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                fr_CTHDB fr = new fr_CTHDB();
                                fr.SOHDB = txtMaHDB.Text;
                                //this.Close();
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
                                hdb.MaHDB = txtMaHDB.Text;
                                hdb.MaNV = cbxNV.SelectedValue.ToString();
                                hdb.NgayBan = dateNgayBan.Text;
                                hdb.MaKH = cbxKH.SelectedValue.ToString();
                                hdb.TongTien = Int32.Parse(txtThanhTien.Text);

                                thucthi.updateHDB(hdb);
                                MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                fr_CTHDB fr = new fr_CTHDB();
                                fr.SOHDB = txtMaHDB.Text;
                                //this.Close();
                                fr.Show();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        //txtma.Enabled = false;
                        locktext();
                        btnThemCTHDB.Enabled = true;
                        hienthi();
                    }
                    else
                    {
                        MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        cbxKH.Focus();
                    }
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
                txtMaHDB.Focus();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            themmoi = false;
            un_locktext();
            txtMaHDB.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    hdb.MaHDB = txtMaHDB.Text;

                    thucthi.deleteHDB(hdb);
                    MessageBox.Show("Đã Xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienthi();
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
            txtMaHDB.Text = DataGridView.Rows[dong].Cells[0].Value.ToString();
            dateNgayBan.Text = DataGridView.Rows[dong].Cells[1].Value.ToString();
            cbxNV.SelectedValue = DataGridView.Rows[dong].Cells[2].Value.ToString();
            cbxKH.SelectedValue = DataGridView.Rows[dong].Cells[3].Value.ToString();
            txtThanhTien.Text = DataGridView.Rows[dong].Cells[4].Value.ToString();
            locktext();
        }

        private void btnThemCTHDB_Click(object sender, EventArgs e)
        {
            //dong = int.Parse(txtma.Text);
            fr_CTHDB fr = new fr_CTHDB();
            fr.SOHDB = txtMaHDB.Text;
            //this.Close();
            fr.Show();
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            fr_ThemKH fr = new fr_ThemKH();
            fr.Show();
        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            fr_CTHDB fr = new fr_CTHDB();
            fr.SOHDB = DataGridView.Rows[dong].Cells[0].Value.ToString();
            //this.Close();
            fr.Show();
        }
    }
}
