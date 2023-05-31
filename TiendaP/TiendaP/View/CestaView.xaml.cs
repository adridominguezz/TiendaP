using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TiendaP.Models;

namespace TiendaP.View
{
    /// <summary>
    /// Lógica de interacción para CestaView.xaml
    /// </summary>
    public partial class CestaView : UserControl
    {

        public List<Product> Carrito { get; set; }

        public CestaView(/*List<Product> carrito*/)
        {
            InitializeComponent();

            //Binding Producto = new Binding();
            //Binding Img = new Binding();
            //Binding Nombre = new Binding();
            //Binding Talla = new Binding();
            //Binding Precio = new Binding();

            //Carrito = carrito;

            //Console.WriteLine(Carrito[0].Nombre);

            //DataContext = this;
        }

        //public Product Product { get; set; }
        //public string ImagenUrl { get; set; }
        //public string Nombre { set; get; }
        //public string Talla { set; get; }
        //public float Precio { set; get; }
    }
}
