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
    public partial class fr_CTHDN : Form
    {
        public fr_CTHDN()
        {
            InitializeComponent();
        }

        BU_CTHDN thucthi = new BU_CTHDN();
        GetData data = new GetData();
        EC_CTHDN ck = new EC_CTHDN();
        bool themmoi;
        int dong = 0;

        private string sohdn;
        public string SOHDN
        {
            get
            {
                return sohdn;
            }
            set
            {
                sohdn = value;
            }
        }

        public void setnull()
        {

            txtsl.Text = "0";
            txtdg.Text = "0";
            txttt.Text = "0";
            cbhang.Text = "";
        }
        public void locktext()
        {
            txtsl.Enabled = false;
            txtdg.Enabled = false;
            cbhang.Enabled = false;
            cbxHDN.Enabled = false;

            btmoi.Enabled = true;
            btluu.Enabled = false;
            btsua.Enabled = true;
            btxoa.Enabled = true;
        }
        public void un_locktext()
        {
            txtsl.Enabled = true;
            txtdg.Enabled = true;
            cbhang.Enabled = true;
            cbxHDN.Enabled = true;

            btmoi.Enabled = false;
            btluu.Enabled = true;
            btsua.Enabled = false;
            btxoa.Enabled = false;
        }

        public void hienthi()
        {
            DataTable dt = thucthi.getAll();
            if (dt != null)
                dataGridView1.DataSource = dt;
            else
            {
                MessageBox.Show(thucthi.Error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fr_CTHDN_Load(object sender, EventArgs e)
        {
            cbxHDN.Text = sohdn;
            hienthi();
            locktext();
            DataTable dt = thucthi.GetMaHang();
            if (dt != null)
            {
                cbhang.DataSource = dt;
                cbhang.ValueMember = "MAHANG";
                cbhang.DisplayMember = "TENHANG";
            }
            else
            {
                MessageBox.Show(thucthi.Error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dt = thucthi.GetMaHoaDonNhap();
            if (dt != null)
            {
                cbxHDN.DataSource = dt;
                cbxHDN.ValueMember = "MAHDN";
                cbxHDN.DisplayMember = "MAHDN";
            }
            else
            {
                MessageBox.Show(thucthi.Error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btmoi_Click(object sender, EventArgs e)
        {
            themmoi = true;
            un_locktext();
            setnull();
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            if (cbhang.Text != "")
            {
                if (themmoi == true)
                {
                    try
                    {
                        float tt = (float.Parse(txtsl.Text) * float.Parse(txtdg.Text));

                        ck.MaHDN = cbxHDN.SelectedValue.ToString();
                        ck.MaHang = cbhang.SelectedValue.ToString();
                        ck.SoLuong = Int32.Parse(txtsl.Text);
                        ck.DonGia = Int32.Parse(txtdg.Text);
                        ck.ThanhTien = Int32.Parse(tt.ToString());

                        thucthi.insertCTHDN(ck);
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
                        float tt = (float.Parse(txtsl.Text) * float.Parse(txtdg.Text));

                        ck.MaHDN = cbxHDN.SelectedValue.ToString();
                        ck.MaHang = cbhang.SelectedValue.ToString();
                        ck.SoLuong = Int32.Parse(txtsl.Text);
                        ck.DonGia = Int32.Parse(txtdg.Text);
                        ck.ThanhTien = Int32.Parse(tt.ToString());
                        thucthi.updateCTHDN(ck);

                        MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                float gn = float.Parse(txtdg.Text);
                float gb = (gn * 110) / 100;

                string upsl = "UPDATE Hanghoa SET SOLUONG =SOLUONG + '" + txtsl.Text + "' where MAHANG='" + cbhang.SelectedValue + "'";
                //string upsl1 = "UPDATE Hanghoa SET dongianhap ='" + txtdg.Text + "' where mahang ='" + cbhang.Text + "'";
                string upsl2 = "UPDATE Hanghoa SET DONGIABAN ='" + gb + "'where MAHANG='" + cbhang.SelectedValue + "'";
                string uptt = "update HoaDonNhap set TONGTIEN=(SELECT sum(THANHTIEN) FROM CTHDN where MAHDN='" + cbxHDN.SelectedValue + "')" + " where MaHDN='" + cbxHDN.SelectedValue + "'";
                data.ExecuteNonQuery(upsl);
                data.ExecuteNonQuery(upsl2);
                data.ExecuteNonQuery(uptt);
                //data.ExcuteNonQuery(upsl2);
                locktext();
                hienthi();
                float t1 = (float.Parse(txtsl.Text) * float.Parse(txtdg.Text));
                txttt.Text = t1.ToString();
            }
            else
            {
                MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                cbhang.Focus();
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            un_locktext();
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ck.MaHDN = cbxHDN.Text;
                    ck.MaHang = cbhang.SelectedValue.ToString();

                    thucthi.deleteCTHDN1(ck);
                    MessageBox.Show("Đã Xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienthi();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi");
                }
            }
        }

        private void btquaylai_Click(object sender, EventArgs e)
        {
            fr_HDN fr = new fr_HDN();
            this.Close();
            fr.Show();
        }



        private void txtsl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtdg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            cbxHDN.SelectedValue = dataGridView1.Rows[dong].Cells[0].Value.ToString();
            cbhang.SelectedValue = dataGridView1.Rows[dong].Cells[1].Value.ToString();
            txtsl.Text = dataGridView1.Rows[dong].Cells[2].Value.ToString();
            txtdg.Text = dataGridView1.Rows[dong].Cells[3].Value.ToString();
            txttt.Text = dataGridView1.Rows[dong].Cells[4].Value.ToString();
            locktext();
        }
    }
}
