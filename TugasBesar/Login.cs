using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasBesar
{
    class Login : Connection
    {
        MySqlConnection conn = Connection.conString();
        public Boolean login(string un, string pw)
        {
            string SQL = "SELECT username, password FROM user";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(SQL, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if ((un == rdr.GetString(0)) && pw == rdr.GetString(1))
                {
                    return true;
                }
            }
            conn.Close();
            return false;
        }
    }
}
