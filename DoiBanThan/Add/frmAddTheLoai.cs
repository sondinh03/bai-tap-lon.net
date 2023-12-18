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

namespace DoiBanThan
{
    public partial class frmAddTheLoai : Form
    {
        public frmAddTheLoai()
        {
            InitializeComponent();
        }

        public string maTL = "";

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuuTheLoai_Click(object sender, EventArgs e)
        {
            string qry = "";

            if(maTL == "") //Insert
            {
                qry = "insert into tblTheLoai(TenTheLoai) values(@tenTheLoai)";
            }
            else
            {
                qry = "update tblTheLoai set tenTheLoai = @tenTheLoai where maTheLoai = @maTheLoai";
            }

            Hashtable ht = new Hashtable();
            ht.Add("@maTheLoai", maTL);
            ht.Add("@tenTheLoai", txtTenTheLoai.Text.Trim());

            if(MainClass.Sql(qry, ht) > 0)
            {
                MessageBox.Show("Thêm thể loại thành công.");
                maTL = "";
                txtTenTheLoai.Focus();
                txtTenTheLoai.Text = "";
                this.Close();
            }
        }
    }
}
