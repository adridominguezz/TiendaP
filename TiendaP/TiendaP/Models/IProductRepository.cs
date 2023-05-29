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
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection Conn = new SqlConnection("Server=(local); Database=TiendaP; Integrated Security=true");
            Conn.Open();
            return Conn;
        }
        public static int Agregar (Product product)
        {
            int retorno = 0;
            using (SqlConnection Conn = ObtenerConexion())
            {
                
                SqlCommand Comando = new SqlCommand(string.Format("INSERT INTO Products VALUES ('{0}','{1}', '{2}', '{3}', '{4}');", product.Nombre, product.Tipo, product.Talla, product.ImagenURl, product.Precio), Conn);

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
                SqlCommand comando = new SqlCommand("Use TiendaP; SELECT Nombre, Tipo, Talla, ImagenUrl, Precio FROM Products", conexion);
               

                SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.Nombre = reader.GetString(0);
                        product.Tipo = reader.GetString(1);
                        product.Talla = reader.GetString(2);
                        product.ImagenURl = reader.GetString(3);
                        //product.Precio = reader.GetFloat(4);

                        Lista.Add(product);
                    }
                conexion.Close();
               

                return Lista;
            }

        }
    }
}
