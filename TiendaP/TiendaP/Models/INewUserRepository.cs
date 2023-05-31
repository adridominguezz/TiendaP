using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaP.Models
{
    public class INewUserRepository
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection Conn = new SqlConnection("Server=(local); Database=TiendaP; Integrated Security=true");
            Conn.Open();
            return Conn;
        }

        public static int CrearUsuario(User usuario)
        {
            int retorno = 0;
            try
            {
                using (SqlConnection Conn = ObtenerConexion())
                {
                    string insertQuery = "INSERT INTO [User] VALUES (NEWID(), @Usuario, @Password, @Nombre, @Apellido, @Email, @Tipo)";

                    SqlCommand Comando = new SqlCommand(insertQuery, Conn);
                    Comando.Parameters.AddWithValue("@Nombre", usuario.Name);
                    Comando.Parameters.AddWithValue("@Apellido", usuario.LastName);
                    Comando.Parameters.AddWithValue("@Email", usuario.Email);
                    Comando.Parameters.AddWithValue("@Usuario", usuario.Username);
                    Comando.Parameters.AddWithValue("@Password", usuario.Password);
                    Comando.Parameters.AddWithValue("@Tipo", usuario.Tipo);

                    retorno = Comando.ExecuteNonQuery();
                    Conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar usuario: " + ex.Message);
            }

            return retorno;
        }
    }
}
