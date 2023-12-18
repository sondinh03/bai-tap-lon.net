using DoiBanThan.Add;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoiBanThan
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblNguoiDung.Text = MainClass.USER;
            GetDataTheLoai();
        }

        public void GetDataTheLoai()
        {
            string qry = "select * from tblTheLoai where tenTheLoai like '%"+ txtTimKiemTheLoai.Text +"%'";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvIdTheLoai);
            lb.Items.Add(dgvTenTheLoai);

            MainClass.LoadData(qry, grvTheLoai, lb);
        }

        private void btnTimKiemTheLoai_Click(object sender, EventArgs e)
        {
            GetDataTheLoai();
        }

        private void btnThemTheLoai_Click(object sender, EventArgs e)
        {
            frmTheLoai frm = new frmTheLoai();
            frm.ShowDialog();
            GetDataTheLoai();
        }




        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi hệ thống không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }



        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnThemBan_Click(object sender, EventArgs e)
        {
            frmBanAn f = new frmBanAn();
            f.ShowDialog();
            this.Show();
        }

        private void tabChucNang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click_1(object sender, EventArgs e)
        {
            frmSanPham f = new frmSanPham();
            f.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmShip f = new frmShip();
            f.ShowDialog();
            this.Show();
        }

        private void tabTheLoai_Click(object sender, EventArgs e)
        {

        }

        private void btnSuaTheLoai_Click(object sender, EventArgs e)
        {

        }
    }
}
