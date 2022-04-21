using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TugasBesar
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Login lgn = new Login();
            if (lgn.login(textBoxUsername.Text, textBoxPassword.Text))
            {
                FormDashboard form1 = new FormDashboard();
                /*form1.TopLevel = false;
                form1.AutoScroll = true;
                this.panel4.Controls.Clear();
                this.panel4.Controls.Add(form1);*/
                form1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username atau Password salah");
            }           
        }

        private void pictureBoxLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
