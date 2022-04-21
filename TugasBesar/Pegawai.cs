using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasBesar
{
    class Pegawai : Connection
    {
        public int id_pegawai { set; get; }
        public String nama_pegawai { set; get; }
        public String tempat_lahir { set; get; }
        public String tanggal_lahir { set; get; }
        public String agama { set; get; }
        public String alamat { set; get; }

        MySqlConnection conn = Connection.conString();
        MySqlCommand cmd;

        public Pegawai()
        {
            MySqlConnection conn = Connection.conString();
            cmd = new MySqlCommand();
        }

        public String Insert()
        {
            String error = null;
            conn.Open();
            cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO data_pegawai (nama_pegawai, tempat_lahir, tanggal_lahir, " +
                "agama, alamat) VALUES (@nama_pegawai, @tempat_lahir, @tanggal_lahir, @agama, @alamat)";
            cmd.Parameters.AddWithValue("@nama_pegawai", this.nama_pegawai);
            cmd.Parameters.AddWithValue("@tempat_lahir", this.tempat_lahir);
            cmd.Parameters.AddWithValue("@tanggal_lahir", this.tanggal_lahir);
            cmd.Parameters.AddWithValue("@agama", this.agama);
            cmd.Parameters.AddWithValue("@alamat", this.alamat);

            try
            {
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception e)
            {
                error = e.Message;
            }
            return error;
        }

        public DataTable Read()
        {
            DataTable dt = new DataTable();
            conn.Open();
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM data_pegawai";
            {
                try
                {
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    dt.Load(rdr);
                }
                catch(Exception e) { }
            }
            return dt;
        }

        public String Delete()
        {
            String result = null;
            conn.Open();
            using (MySqlCommand cmd = new MySqlCommand("DELETE FROM data_pegawai WHERE id_pegawai = @id_pegawai", conn))
            {
                cmd.Parameters.AddWithValue("@id_pegawai", this.id_pegawai);
                try
                {
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            return result;
        }

        public String Update()
        {
            string result = null;
            conn.Open();
            cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE data_pegawai set nama_pegawai = @nama_pegawai, tempat_lahir = @tempat_lahir, tanggal_lahir = @tanggal_lahir, " +
                "agama = @agama, alamat = @alamat WHERE id_pegawai = @id_pegawai";
            cmd.Parameters.AddWithValue("@nama_pegawai", this.nama_pegawai);
            cmd.Parameters.AddWithValue("@tempat_lahir", this.tempat_lahir);
            cmd.Parameters.AddWithValue("@tanggal_lahir", this.tanggal_lahir);
            cmd.Parameters.AddWithValue("@agama", this.agama);
            cmd.Parameters.AddWithValue("@alamat", this.alamat);
            cmd.Parameters.AddWithValue("@id_pegawai", this.id_pegawai);
            try
            {
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return result;
        }
    }
}
