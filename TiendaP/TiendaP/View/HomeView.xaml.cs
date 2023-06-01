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
        public List<Product> carrito;
        public HomeView()
        { 
            InitializeComponent();

            contCart.Text = CestaView.Carrito.Count.ToString(); //Cuento cuantos productos tiene en el carrito.

            
            lista = IProductRepository.ObtenerProductos(); //Asigno los productos de la base de datos a la lista para luego mostrarla

            // Ordenar la lista de forma aleatoria
            Random rnd = new Random();
            lista = lista.OrderBy(x => rnd.Next()).ToList();

            //Asigno la lista al itemsource para que pueda mostrar los elementos de la lista.
            ProductosLista.ItemsSource = lista;

            DataContext = this;

        }

        private void ItemsControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        
        private void btnAddCart_Click(object sender, RoutedEventArgs e)
        {
            // Obtén el botón que se hizo clic
            Button button = (Button)sender;

            // Obtén el elemento asociado al botón
            Product producto = button.DataContext as Product;

            carrito = CestaView.Carrito;

            // Añade el producto al carrito
            carrito.Add(producto);

            contCart.Text = CestaView.Carrito.Count.ToString(); //Cuento cuantos productos tiene en el carrito.
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            string filtro = txtFilter.Text.Trim();

            // Crear una nueva lista para almacenar los elementos filtrados
            List<Product> listaFiltrada = new List<Product>();

            // Iterar sobre la lista y agregar los elementos que coincidan con el filtro a la lista filtrada
            foreach (Product producto in lista)
            {
                if (producto.Nombre.ToLower().Contains(filtro.ToLower()) ||
                    producto.Tipo.ToLower().Contains(filtro.ToLower()) ||
                    producto.Talla.ToLower().Contains(filtro.ToLower()))
                {
                    listaFiltrada.Add(producto);
                }
            }

            // Asignar la lista filtrada al ItemsControl
            ProductosLista.ItemsSource = listaFiltrada;
        }
        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Realizar el filtrado cuando se presione la tecla Enter
                btnFilter_Click(sender, e);
            }
        }

    }
}