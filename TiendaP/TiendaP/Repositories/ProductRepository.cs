using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaP.Repositories
{
    public class ProductRepository
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection Conn = new SqlConnection("Server=(local); Database=TiendaP; Integrated Security=true");
            Conn.Open();
            return Conn;
        }
    }
}
