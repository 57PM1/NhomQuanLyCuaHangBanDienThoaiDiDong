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

namespace QuanLyCuaHang.Use_Form
{
    public partial class fr_NhaSanXuat : Form
    {
        public fr_NhaSanXuat()
        {
            InitializeComponent();
        }

        BU_NhaSanXuat thucthi = new BU_NhaSanXuat();
        GetData data = new GetData();
        EC_NhaSanXuat nsx = new EC_NhaSanXuat();
        bool themmoi;
        int dong = 0;

        public void setnull()
        {
            txtMaNSX.Text = "";
            txtTenNSX.Text = "";
        }
        public void locktext()
        {
            txtMaNSX.Enabled = false;
            txtTenNSX.Enabled = false;

            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
        public void un_locktext()
        {
            txtMaNSX.Enabled = true;
            txtTenNSX.Enabled = true;

            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        //public void khoitaoluoi()
        //{
        //    DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    DataGridView.Columns[0].HeaderText = "Mã NSX";
        //    DataGridView.Columns[0].Frozen = true;
        //    DataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    DataGridView.Columns[0].Width = 100;

        //    DataGridView.Columns[1].HeaderText = "Tên NSX";
        //    DataGridView.Columns[1].Width = 200;

        //}
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

        private void fr_NhaSanXuat_Load(object sender, EventArgs e)
        {
            locktext();
            hienthi();
           //khoitaoluoi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            themmoi = true;
            un_locktext();
            setnull();
            txtMaNSX.Enabled = true;
            txtTenNSX.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaNSX.Text != "")
            {
                if (themmoi == true)
                {
                    try
                    {
                        nsx.MANSX = txtMaNSX.Text;
                        nsx.TENNSX = txtTenNSX.Text;

                        thucthi.insertNSX(nsx);
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
                        nsx.MANSX = txtMaNSX.Text;
                        nsx.TENNSX = txtTenNSX.Text;

                        thucthi.updateNSX(nsx);
                        MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                txtMaNSX.Enabled = true;
                locktext();
                hienthi();
            }
            else
            {
                MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                txtMaNSX.Focus();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            un_locktext();
            txtMaNSX.Enabled = false;
            txtTenNSX.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {

                    thucthi.deleteNSX(nsx.MANSX);
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
            txtMaNSX.Text = DataGridView.Rows[dong].Cells[0].Value.ToString();
            txtTenNSX.Text = DataGridView.Rows[dong].Cells[1].Value.ToString();
            locktext();
        }

        private void radiobtnMaNSX_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobtnMaNSX.Checked)
                radiobtnTenNSX.Checked = false;
            if (radiobtnMaNSX.Checked == false)
                radiobtnTenNSX.Checked = true;
        }

        private void radiobtnTenNSX_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobtnTenNSX.Checked)
                radiobtnMaNSX.Checked = false;
            if (radiobtnTenNSX.Checked == false)
                radiobtnMaNSX.Checked = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (radiobtnMaNSX.Checked)
            {
                if (txtTimMaNSX.Text != "")
                {
                    //DataGridView.DataSource = thucthi.tkMa(txtTimMaLoaiHang.Text);
                    DataTable dt = thucthi.tkMa(txtTimMaNSX.Text);
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
            if (radiobtnTenNSX.Checked)
            {
                if (txtTimTenNSX.Text != "")
                {
                    //DataGridView.DataSource = thucthi.tkTen(txtTimTenLoaiHang.Text);
                    DataTable dt = thucthi.tkTen(txtTimTenNSX.Text);
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
