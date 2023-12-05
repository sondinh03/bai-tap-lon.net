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

        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            frmTheLoai f = new frmTheLoai();
            f.ShowDialog();
            this.Show();
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
    }
}
