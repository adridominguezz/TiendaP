using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TiendaP.Models;

namespace TiendaP.ViewModels
{

    public class HomeViewModel : ViewModelBase
    {
        
        public List<Product> lista = new List<Product>();
        public Product Product { get; set; }
        public string ImagenUrl { get; set; }
        public string Nombre { set; get; }
        public string Talla { set; get; }
        public float Precio { set; get; }
        public HomeViewModel()
        {
            lista = IProductRepository.ObtenerProductos();
            Console.WriteLine(lista[1].Nombre);

            Binding Producto = new Binding();
            Binding Img = new Binding();
            Binding Nombre = new Binding();
            Binding Talla = new Binding();
            Binding Precio = new Binding();

        }
    }
}