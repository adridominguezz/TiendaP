using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaP.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Talla { get; set; }
        public string ImagenURl { get; set; }
        public float Precio { get; set; }
    }
}
