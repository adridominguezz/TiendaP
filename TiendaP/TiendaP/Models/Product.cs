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
        public string Tipo { get; set; }
        public string Talla { get; set; }
        public string ImagenURl { get; set; }
        public float Precio { get; set; }

        public Product() { }
        public Product( int id, string nombre,string tipo, string talla, string imagenURl, float precio)
        {
            Id = id;
            Nombre = nombre;
            Tipo = tipo;
            Talla = talla;
            ImagenURl = imagenURl;
            Precio = precio;
        }


        

    }
}
