using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaP.Repositories;

namespace TiendaP.Models
{
    public class IProductRepository
    {
        public static int Agregar (Product product)
        {
            int retorno = 0;
            using (SqlConnection Conn = ProductRepository.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand(string.Format("INSERT INTO Products VALUES ('{0}','{1}', '{2}', '{3}', '{4}');", product.Nombre, product.Tipo, product.Talla, product.ImagenURl, product.Precio), Conn);

                retorno = Comando.ExecuteNonQuery();
            }
            return retorno;
        }

        public static List<Product> ObtenerProductos()
        {
            List<Product> Lista = new List<Product>();

            using (SqlConnection conexion = ProductRepository.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand("SELECT Nombre, Tipo, Talla, ImagenUrl, Precio FROM Products", conexion);
                SqlDataReader reader = null;

                try
                {
                    conexion.Open();
                    reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.Nombre = reader.GetString(0);
                        product.Tipo = reader.GetString(1);
                        product.Talla = reader.GetString(2);
                        product.ImagenURl = reader.GetString(3);
                        product.Precio = reader.GetFloat(4);

                        Lista.Add(product);
                    }
                }
                catch (Exception ex)
                {
                    // Manejar la excepción adecuadamente
                    Console.WriteLine("Error al obtener los productos: " + ex.Message);
                }
                finally
                {
                    if (reader != null)
                        reader.Close();

                    conexion.Close();
                }

                return Lista;
            }

        }
    }
}
