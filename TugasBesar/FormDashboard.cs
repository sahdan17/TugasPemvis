using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TugasBesar
{
    public partial class FormDashboard : Form
    {
        public FormDashboard()
        {
            InitializeComponent();
        }

        private void labelProduk_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBoxLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void labelPegawai_Click(object sender, EventArgs e)
        {
            FormPegawai form3 = new FormPegawai();
            form3.TopLevel = false;
            form3.AutoScroll = true;
            this.panelContent.Controls.Clear();
            this.panelContent.Controls.Add(form3);
            form3.Show();
            labelTitle.Text = "PEGAWAI";
        }
    }
}
