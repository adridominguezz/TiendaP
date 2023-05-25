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
    }
}
