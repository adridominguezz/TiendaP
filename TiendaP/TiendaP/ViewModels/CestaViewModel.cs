using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaP.Models;
using TiendaP.View;

namespace TiendaP.ViewModels
{

    public class CestaViewModel : ViewModelBase
    {
        private static List<Product> _carrito = new List<Product>();
        public Product Product { get; set; }
        public string ImagenUrl { get; set; }
        public string Tipo { get; set; }
        public string Nombre { set; get; }
        public string Talla { set; get; }
        public float Precio { set; get; }

        public CestaViewModel() {
            _carrito = CestaView.Carrito;
        }
    }
}
