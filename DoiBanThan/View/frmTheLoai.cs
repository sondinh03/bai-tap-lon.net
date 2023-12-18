using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoiBanThan.View
{
    public partial class frmTheLoai : Form
    {
        public frmTheLoai()
        {
            InitializeComponent();
        }

        public void GetData()
        {
            string qry = "select * from tblTheLoai where tenTheLoai like '%" + txtTimKiemTheLoai.Text + "%'";
            //string qry = "select * from tblTheLoai";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvMaTheLoai);
            lb.Items.Add(dgvTenTheLoai);

            MainClass.LoadData(qry, grvTheLoai, lb);
        }

        private void grvTheLoai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmTheLoai_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnThemTheLoai_Click(object sender, EventArgs e)
        {
            frmAddTheLoai frm = new frmAddTheLoai();
            frm.ShowDialog();
            GetData();
        }

        private void txtTimKiemTheLoai_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void grvTheLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(grvTheLoai.CurrentCell.OwningColumn.Name == "dgvEdit")
            {
                frmAddTheLoai frm = new frmAddTheLoai();
                frm.maTL = Convert.ToString(grvTheLoai.CurrentRow.Cells["dgvMaTheLoai"].Value);
                frm.txtTenTheLoai.Text = Convert.ToString(grvTheLoai.CurrentRow.Cells["dgvTenTheLoai"].Value);
                frm.ShowDialog();
                GetData();
            } 
            if(grvTheLoai.CurrentCell.OwningColumn.Name == "dgvDelete")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xóa?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string maTL = Convert.ToString(grvTheLoai.CurrentRow.Cells["dgvMaTheLoai"].Value);
                    string qry = "delete from tblTheLoai where maTheLoai = '" + maTL + "'";
                    Hashtable ht = new Hashtable();
                    MainClass.Sql(qry, ht);
                    MessageBox.Show("Xóa thành công!");
                    GetData();
                }
                
            } 
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
