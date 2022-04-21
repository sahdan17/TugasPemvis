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

namespace TugasBesar
{    
    public partial class FormPegawai : Form
    {
        int _id_pegawai;
        public FormPegawai()
        {
            InitializeComponent();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            Pegawai dataPegawai = new Pegawai();
            dataPegawai.nama_pegawai = textBoxNama.Text;
            dataPegawai.tempat_lahir = textBoxTmptLahir.Text;
            dataPegawai.tanggal_lahir = dateTimePickerTglLahir.Value.ToString("yyyyMMdd");
            dataPegawai.agama = comboBoxAgama.SelectedItem.ToString();
            dataPegawai.alamat = textBoxAlamat.Text;

            String response;
            response = dataPegawai.Insert();
            if (response == null) MessageBox.Show("Input data sukses");
            else MessageBox.Show("Input data gagal" + response);

            readData();
        }

        private void readData()
        {
            Pegawai tabelPegawai = new Pegawai();
            DataTable dt = new DataTable();
            dt = tabelPegawai.Read();
            dataGridViewPegawai.DataSource = dt;
            dataGridViewPegawai.Show();

            textBoxNama.Text = null;
            textBoxTmptLahir.Text = null;
            textBoxAlamat.Text = null;
        }

        private void FormPegawai_Load(object sender, EventArgs e)
        {
            readData();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string response;
            Pegawai deletePegawai = new Pegawai();
            deletePegawai.id_pegawai = _id_pegawai;
            response = deletePegawai.Delete();
            if (response == null) MessageBox.Show("Hapus data sukses");
            else MessageBox.Show(response);
            readData();
        }

        private void dataGridViewPegawai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridViewPegawai.SelectedCells[0].RowIndex;
            DataGridViewRow selected = dataGridViewPegawai.Rows[index];

            textBoxNama.Text = Convert.ToString(selected.Cells["nama_pegawai"].Value);
            textBoxTmptLahir.Text = Convert.ToString(selected.Cells["tempat_lahir"].Value);
            dateTimePickerTglLahir.Value = Convert.ToDateTime(selected.Cells["tanggal_lahir"].Value);
            comboBoxAgama.Text = Convert.ToString(selected.Cells["agama"].Value);
            textBoxAlamat.Text = Convert.ToString(selected.Cells["alamat"].Value);
            _id_pegawai = Convert.ToInt32(selected.Cells["id_pegawai"].Value);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string response;
            Pegawai editPegawai = new Pegawai();
            editPegawai.nama_pegawai = textBoxNama.Text;
            editPegawai.tempat_lahir = textBoxTmptLahir.Text;
            editPegawai.tanggal_lahir = dateTimePickerTglLahir.Value.ToString("yyyyMMdd");
            editPegawai.agama = comboBoxAgama.SelectedItem.ToString();
            editPegawai.alamat = textBoxAlamat.Text;
            editPegawai.id_pegawai = _id_pegawai;
            response = editPegawai.Update();
            if (response == null) MessageBox.Show("Update data sukses");
            else MessageBox.Show(response);
            readData();
        }
    }
}
