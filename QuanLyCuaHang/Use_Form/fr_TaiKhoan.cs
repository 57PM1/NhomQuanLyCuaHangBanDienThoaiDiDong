using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccess;
using EntityClass;
using Business;

namespace QuanLyCuaHang.Use_Form
{
    public partial class fr_TaiKhoan : Form
    {
        public fr_TaiKhoan()
        {
            InitializeComponent();
        }
        BU_TaiKhoan thucthi = new BU_TaiKhoan();
        GetData data = new GetData();
        EC_TaiKhoan tk = new EC_TaiKhoan();
        bool themmoi;
        int dong = 0;

        public void setnull()
        {
            txtTênTK.Text = "";
            txtMatKhau.Text = "";
            txtQuyen.Text = "";
        }
        public void locktext()
        {
            txtTênTK.Enabled = false;
            txtMatKhau.Enabled = false;
            txtQuyen.Enabled = false;

            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
        public void un_locktext()
        {
            txtTênTK.Enabled = true;
            txtMatKhau.Enabled = true;
            txtQuyen.Enabled = true;

            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        public void hienthi()
        {
            DataTable dt = thucthi.getAll();
            if (dt != null)
                dataGridView.DataSource = dt;
            else
            {
                MessageBox.Show(thucthi.Error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void fr_TaiKhoan_Load(object sender, EventArgs e)
        {
            locktext();
            hienthi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            themmoi = true;
            un_locktext();
            setnull();
            txtTênTK.Enabled = true;
            txtTênTK.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTênTK.Text != "")
            {
                if (themmoi == true)
                {
                    try
                    {
                        tk.TaiKhoan = txtTênTK.Text;
                        tk.MatKhau = txtMatKhau.Text;
                        tk.Quyen = txtQuyen.Text;

                        thucthi.insertTK(tk);
                        locktext();
                        //hienthi();
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
                        tk.TaiKhoan = txtTênTK.Text;
                        tk.MatKhau = txtMatKhau.Text;
                        tk.Quyen = txtQuyen.Text;

                        thucthi.updateTK(tk);
                        MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                txtTênTK.Enabled = true;
                locktext();
                hienthi();
            }
            else
            {
                MessageBox.Show("Tên Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                txtTênTK.Focus();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            un_locktext();
            txtTênTK.Enabled = false;
            txtTênTK.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    tk.TaiKhoan = txtTênTK.Text;

                    thucthi.deleteTK(tk);
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

        private void radiobtnTenTK_CheckedChanged(object sender, EventArgs e)
        {

            if (radiobtnTenTK.Checked)
                radiobtnQuyen.Checked = false;
            if (radiobtnTenTK.Checked == false)
                radiobtnQuyen.Checked = true;
        }

        private void radiobtnQuyen_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobtnQuyen.Checked)
                radiobtnTenTK.Checked = false;
            if (radiobtnQuyen.Checked == false)
                radiobtnTenTK.Checked = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (radiobtnTenTK.Checked)
            {
                if (txtTimTenTK.Text != "")
                {
                    //dataGridView.DataSource = thucthi.tkTenTK(txtTimTenTK.Text);
                    DataTable dt = thucthi.tkTenTK(txtTimTenTK.Text);
                    if (dt != null)
                        dataGridView.DataSource = dt;
                    else
                    {
                        MessageBox.Show(thucthi.Error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Tên Không được để trống", "Chú Ý", MessageBoxButtons.OK);
            }
            if (radiobtnQuyen.Checked)
            {
                if (txtTimTenTK.Text != "")
                {
                    //dataGridView.DataSource = thucthi.tkQuyen(txtTimQuyen.Text);
                    DataTable dt = thucthi.tkQuyen(txtTimQuyen.Text);
                    if (dt != null)
                        dataGridView.DataSource = dt;
                    else
                    {
                        MessageBox.Show(thucthi.Error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Quyền Không được để trống", "Chú Ý", MessageBoxButtons.OK);
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            txtTênTK.Text = dataGridView.Rows[dong].Cells[0].Value.ToString();
            txtMatKhau.Text = dataGridView.Rows[dong].Cells[1].Value.ToString();
            txtQuyen.Text = dataGridView.Rows[dong].Cells[2].Value.ToString();
            locktext();
        }
    }
}
