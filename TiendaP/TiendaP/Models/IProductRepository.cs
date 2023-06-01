using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaP.Repositories;

namespace TiendaP.Models
{
    public class IProductRepository
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection Conn = new SqlConnection("Server=(local); Database=TiendaP; Integrated Security=true");
            Conn.Open();
            return Conn;
        }
        public static int Agregar(Product product)
        {
            int retorno = 0;
            using (SqlConnection Conn = ObtenerConexion())
            {
                string insertQuery = "INSERT INTO Products (Nombre, Tipo, Talla, ImagenURL, Precio) " +
                                     "VALUES (@Nombre, @Tipo, @Talla, @ImagenURL, @Precio)";

                SqlCommand Comando = new SqlCommand(insertQuery, Conn);
                Comando.Parameters.AddWithValue("@Nombre", product.Nombre);
                Comando.Parameters.AddWithValue("@Tipo", product.Tipo);
                Comando.Parameters.AddWithValue("@Talla", product.Talla);
                Comando.Parameters.AddWithValue("@ImagenURL", product.ImagenURl);
                Comando.Parameters.AddWithValue("@Precio", product.Precio);

                retorno = Comando.ExecuteNonQuery();
                Conn.Close();
            }
            return retorno;
        }

        public static List<Product> ObtenerProductos()
        {
            List<Product> Lista = new List<Product>();

            using (SqlConnection conexion = ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand("Use TiendaP; SELECT idProducto, Nombre, Tipo, Talla, ImagenUrl, Precio FROM Products", conexion);
               

                SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.Id = reader.GetInt32(0);
                        product.Nombre = (reader.GetString(1)).ToUpper(); 
                        product.Tipo = reader.GetString(2);
                        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                        product.Tipo = textInfo.ToTitleCase(product.Tipo.ToLower());
                        product.Talla = reader.GetString(3);
                        product.ImagenURl = reader.GetString(4);
                        product.Precio = Convert.ToSingle(reader.GetDouble(5)); 

                        Lista.Add(product);
                    }
                conexion.Close();
               
                return Lista;
            }

        }

        public static int Eliminar(Product product)
        {
            int retorno = 0;
            using (SqlConnection Conn = ObtenerConexion())
            {
                string deleteQuery = "DELETE FROM Products WHERE idProducto = @Id";

                SqlCommand Comando = new SqlCommand(deleteQuery, Conn);
                Comando.Parameters.AddWithValue("@Id", product.Id);

                retorno = Comando.ExecuteNonQuery();
                Conn.Close();
            }
            return retorno;
        }
    }
}
