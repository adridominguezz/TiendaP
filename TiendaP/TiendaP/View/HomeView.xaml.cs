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
using TiendaP.Repositories;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using TiendaP.ViewModels;

namespace TiendaP.View
{
  
    public partial class HomeView : UserControl
    {

        public List<Product> lista = new List<Product>();
        public HomeView()
        { 
            InitializeComponent();



            Binding Producto = new Binding();
            Binding Img = new Binding();
            Binding Nombre = new Binding();
            Binding Talla = new Binding();
            Binding Precio = new Binding();



            lista = IProductRepository.ObtenerProductos();
            ProductosLista.ItemsSource = lista;

            DataContext = this;

        }

        public Product Product { get; set; }
        public string ImagenUrl { get; set; } 
        public string Nombre { set; get; }
        public string Talla { set; get; } 
        public float Precio { set; get; }

        private void ItemsControl_Loaded(object sender, RoutedEventArgs e)
        {
            


        }
    }
}