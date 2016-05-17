using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;
using DevComponents.DotNetBar;
using QuanLyCuaHang.Use_Form;
using EntityClass;

namespace QuanLyCuaHang
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        EC_TaiKhoan tk = new EC_TaiKhoan();
        private void frmMain_Load(object sender, EventArgs e)
        {
            QuyenKhach();
        }
        private void QuyenAdmin()
        {
            đăngNhậpToolStripMenuItem.Enabled = false;
            đăngXuấtToolStripMenuItem.Enabled = true;
            đổiMậtKhẩuToolStripMenuItem.Enabled = true;
            sảnPhẩmToolStripMenuItem.Enabled = true;
            kháchHàngToolStripMenuItem.Enabled = true;
            nhàCungCấpToolStripMenuItem.Enabled = true;
            nhânViênToolStripMenuItem.Enabled = true;
            tàiKhoảnToolStripMenuItem.Enabled = true;
            nhậpHàngToolStripMenuItem.Enabled = true;
            xuấtHàngToolStripMenuItem.Enabled = true;
        }
        private void QuyenQL()
        {
            đăngNhậpToolStripMenuItem.Enabled = false;
            đăngXuấtToolStripMenuItem.Enabled = true;
            đổiMậtKhẩuToolStripMenuItem.Enabled = true;
            sảnPhẩmToolStripMenuItem.Enabled = true;
            kháchHàngToolStripMenuItem.Enabled = true;
            nhàCungCấpToolStripMenuItem.Enabled = true;
            nhânViênToolStripMenuItem.Enabled = true;
            tàiKhoảnToolStripMenuItem.Enabled = false;
            nhậpHàngToolStripMenuItem.Enabled = true;
            xuấtHàngToolStripMenuItem.Enabled = true;
        }

        private void QuyenNV()
        {
            đăngNhậpToolStripMenuItem.Enabled = false;
            đăngXuấtToolStripMenuItem.Enabled = true;
            đổiMậtKhẩuToolStripMenuItem.Enabled = true;
            sảnPhẩmToolStripMenuItem.Enabled = true;
            kháchHàngToolStripMenuItem.Enabled = true;
            nhàCungCấpToolStripMenuItem.Enabled = true;
            nhânViênToolStripMenuItem.Enabled = false;
            tàiKhoảnToolStripMenuItem.Enabled = false;
            nhậpHàngToolStripMenuItem.Enabled = true;
            xuấtHàngToolStripMenuItem.Enabled = true;
        }
        private void QuyenKhach()
        {
            đăngNhậpToolStripMenuItem.Enabled = true;
            đăngXuấtToolStripMenuItem.Enabled = false;
            đổiMậtKhẩuToolStripMenuItem.Enabled = false;
            sảnPhẩmToolStripMenuItem.Enabled = false;
            kháchHàngToolStripMenuItem.Enabled = false;
            nhàCungCấpToolStripMenuItem.Enabled = false;
            nhânViênToolStripMenuItem.Enabled = false;
            tàiKhoảnToolStripMenuItem.Enabled = false;
            nhậpHàngToolStripMenuItem.Enabled = false;
            xuấtHàngToolStripMenuItem.Enabled = false;
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fr_DangNhap f = new fr_DangNhap();
            f.ShowDialog();
            //f.MdiParent = this;
            //f.Show();
            tk = f.tk;
            toolStripStatusLabel1.Text = "Tài Khoản: " + tk.TaiKhoan;
            switch (tk.Quyen)
            {
                case "admin": QuyenAdmin(); break;
                case "quanly": QuyenQL(); break;
                case "nhanvien": QuyenNV(); break;
                default: QuyenKhach(); break;
            }
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fr_DoiMatKhau f = new fr_DoiMatKhau();
            //f.setUser(TenTaiKhoan);
            //f.MdiParent = this;
            f.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult h = new DialogResult();
            h = MessageBox.Show("Đăng Xuất", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (h.ToString() == "OK")
            {
                QuyenKhach();
                toolStripStatusLabel1.Text = "Chế Độ Khách";
                // Thoát các Form hết
                foreach (Form f in this.MdiChildren)
                {
                    f.Close();
                }
                tk = null;
                fr_DangNhap fr = new fr_DangNhap();
                fr.ShowDialog();
            }
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fr_KhachHang f = new fr_KhachHang();
            //f.MdiParent = this;
            f.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fr_NhanVien f = new fr_NhanVien();
            //f.MdiParent = this;
            f.Show();
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fr_TaiKhoan f = new fr_TaiKhoan();
            //f.MdiParent = this;
            f.Show();
        }
    }
}
