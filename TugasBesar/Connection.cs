using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasBesar
{
    class Connection
    {
        public static MySqlConnection conString()
        {
            MySqlConnection Conn = null;
            try
            {
                string ConnString = "server=localhost; database=inventaris; uid=root; password=1234;";
                Conn = new MySqlConnection(ConnString);
            }
            catch (MySqlException sqlex)
            {
                throw new Exception(sqlex.Message.ToString());
            }
            return Conn;
        }
    }
}
