using System;
using System.Collections;
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

        private static List<Product> _carrito = new List<Product>();
        public static List<Product> Carrito
        {
            get { return _carrito; }
            set { _carrito = value; }
        }

        public CestaView()
        {
            InitializeComponent();

            ProductosCesta.ItemsSource = Carrito;


            DataContext = this;
        }

        public Product Product { get; set; }
        public string ImagenUrl { get; set; }
        public string Nombre { set; get; }
        public string Talla { set; get; }
        public float Precio { set; get; }
    }
}
