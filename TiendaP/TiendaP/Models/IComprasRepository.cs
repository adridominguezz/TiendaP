using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaP.Repositories;

namespace TiendaP.Models
{
    public class IComprasRepository
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection Conn = new SqlConnection("Server=(local); Database=TiendaP; Integrated Security=true");
            Conn.Open();
            return Conn;
        }


        public static int Agregar(Compras compra)
        {
            int retorno = 0;
            using (SqlConnection Conn = ObtenerConexion())
            {
                string insertQuery = "INSERT INTO Compras (idCliente, CantidadProductos, PrecioCompra) " +
                                     "VALUES (@idCliente, @CantidadProductos, @PrecioCompra)";

                SqlCommand Comando = new SqlCommand(insertQuery, Conn);
                Comando.Parameters.AddWithValue("@idCliente", compra.IdCliente);
                Comando.Parameters.AddWithValue("@CantidadProductos", compra.ProductosCompra);
                Comando.Parameters.AddWithValue("@PrecioCompra", compra.PrecioCompra);

                retorno = Comando.ExecuteNonQuery();
                Conn.Close();
            }
            return retorno;
        }


        public static List<Compras> ObtenerCompras()
        {
            List<Compras> Lista = new List<Compras>();
            UserRepository userRepository = new UserRepository();

            using (SqlConnection conexion = ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand("Use TiendaP; SELECT idCompra, idCliente, CantidadProductos, PrecioCompra FROM Compras", conexion);


                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Compras compra = new Compras();
                    compra.IdCompra = reader.GetInt32(0);
                    compra.Nombre = userRepository.GetNameAndLastNameById(reader.GetGuid(1).ToString());
                    compra.ProductosCompra = reader.GetInt32(2);
                    compra.PrecioCompra = Convert.ToSingle(reader.GetDouble(3));
                    
                    Lista.Add(compra);
                }
                conexion.Close();

                return Lista;
            }

        }
    }

}
