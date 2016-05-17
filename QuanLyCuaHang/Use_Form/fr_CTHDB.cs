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
using DataAccess;
using EntityClass;
using Business;

namespace QuanLyCuaHang.Use_Form
{
    public partial class fr_CTHDB : Form
    {
        public fr_CTHDB()
        {
            InitializeComponent();
        }

        BU_CTHDB thucthi = new BU_CTHDB();
        GetData data = new GetData();
        EC_CTHDB cthdb = new EC_CTHDB();
        bool themmoi;
        int dong = 0;

        private string sohdb;
        public string SOHDB
        {
            get
            {
                return sohdb;
            }
            set
            {
                sohdb = value;
            }
        }

        public void setnull()
        {

            txtSoLuong.Text = "0";
            txtDonGia.Text = "0";
            txtTongTien.Text = "0";
            cbxMaHang.Text = "";
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
        public void locktext()
        {

            txtSoLuong.Enabled = false;
            cbxMaHang.Enabled = false;
            cbxMaHDB.Enabled = false;

            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
        public void un_locktext()
        {
            txtSoLuong.Enabled = true;
            txtDonGia.Enabled = true;
            cbxMaHang.Enabled = true;
            cbxMaHDB.Enabled = true;

            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void fr_CTHDB_Load(object sender, EventArgs e)
        {
            //txtMaHDB.Text = sohdb;
            //txtMaHDB.Enabled = false;
            //Load combobox mã hàng
            DataTable dt = thucthi.GetMaHang();
            if (dt != null)
            {
                cbxMaHang.DataSource = dt;
                cbxMaHang.ValueMember = "MAHANG";
                cbxMaHang.DisplayMember = "TENHANG";
            }
            else
            {
                MessageBox.Show(thucthi.Error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dt = thucthi.GetMaHoaDonBan();
            if (dt != null)
            {
                cbxMaHDB.DataSource = dt;
                cbxMaHDB.ValueMember = "MAHDB";
                cbxMaHDB.DisplayMember = "MAHDB";
            }
            else
            {
                MessageBox.Show(thucthi.Error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            hienthi();
            //khoitaoluoi();
            locktext();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            themmoi = true;
            un_locktext();
            setnull();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cbxMaHang.Text != "")
            {
                if (themmoi == true)
                {
                    try
                    {
                        float tt = (float.Parse(txtSoLuong.Text) * float.Parse(txtDonGia.Text));
                        cthdb.MaHDB = cbxMaHDB.SelectedValue.ToString();
                        cthdb.MaHang = cbxMaHang.SelectedValue.ToString();
                        cthdb.thanhTien = Int32.Parse(tt.ToString());
                        cthdb.SoLuong = Int32.Parse(txtSoLuong.Text);
                        cthdb.DonGia = Int32.Parse(txtDonGia.Text);

                        thucthi.insertCTHDB(cthdb);
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
                        float tt = (float.Parse(txtSoLuong.Text) * float.Parse(txtDonGia.Text));

                        cthdb.MaHDB = cbxMaHDB.SelectedValue.ToString();
                        cthdb.MaHang = cbxMaHang.SelectedValue.ToString();
                        cthdb.thanhTien = Int32.Parse(tt.ToString());
                        cthdb.SoLuong = Int32.Parse(txtSoLuong.Text);
                        cthdb.DonGia = Int32.Parse(txtDonGia.Text);

                        thucthi.updateCTHDB(cthdb);
                        MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                float gn = float.Parse(txtDonGia.Text);
                float gb = (gn * 110) / 100;

                string updateSL = "UPDATE Hanghoa SET SOLUONG =SOLUONG - '" + txtSoLuong.Text + "' where mahang='" + cbxMaHang.Text + "'";
                string updateTT = "update HoaDonBan set TONGTIEN=(SELECT sum(THANHTIEN) FROM CTHDB where MAHDB='" + cbxMaHDB.Text + "')" + " where MaHDB='" + cbxMaHDB.Text + "'";
                data.UpdateData(updateSL);
                data.UpdateData(updateTT);
                locktext();
                hienthi();
                float t1 = (float.Parse(txtSoLuong.Text) * float.Parse(txtDonGia.Text));
                txtTongTien.Text = t1.ToString();
            }
            else
            {
                MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                cbxMaHang.Focus();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            un_locktext();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    cthdb.MaHDB = cbxMaHDB.Text;
                    cthdb.MaHang = cbxMaHang.SelectedValue.ToString();

                    thucthi.deleteCTHDB1(cthdb);
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
            cbxMaHDB.SelectedValue = DataGridView.Rows[dong].Cells[0].Value.ToString();
            cbxMaHang.SelectedValue = DataGridView.Rows[dong].Cells[1].Value.ToString();
            txtSoLuong.Text = DataGridView.Rows[dong].Cells[2].Value.ToString();
            txtDonGia.Text = DataGridView.Rows[dong].Cells[3].Value.ToString();
            txtTongTien.Text = DataGridView.Rows[dong].Cells[4].Value.ToString();
            locktext();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable dt = thucthi.tkMaHDB(txtTimMaHDB.Text);
            if (dt != null)
                DataGridView.DataSource = dt;
            else
            {
                MessageBox.Show(thucthi.Error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = thucthi.GetDonGia(cbxMaHang.SelectedValue.ToString());
            if (dt != null)
            {
                var temp = dt.Rows;
                if (temp.Count > 0)
                {
                    txtDonGia.Text = temp[0][0].ToString();
                }
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
        }
    }
}
