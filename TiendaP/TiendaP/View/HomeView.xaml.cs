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

namespace TiendaP.View
{
    /// <summary>
    /// Lógica de interacción para HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        private ObservableCollection<Product> products = new ObservableCollection<Product>();
        
        public HomeView()
        {
            InitializeComponent();
            lvProducts = new ListView();

            // Conexion con la base de datos
            var connectionString = @"Data Source=localhost;Initial Catalog=TiendaP;Integrated Security=True";
            using (var connection = new SqlConnection(connectionString))
            {
                // Abrir la conexion
                connection.Open();

                // Crear la consulta y ejecutarla
                var command = new SqlCommand("SELECT * FROM Products", connection);

                var reader = command.ExecuteReader();

                // Iterate through the results
                while (reader.Read())
                {
                    // Crear un objeto de producto
                    var product = new Product
                    {
                        // Sacar los datos del producto
                        Nombre = reader["Nombre"].ToString(),
                        Talla = reader["Talla"].ToString(),
                        ImagenURl = reader["ImagenUrl"].ToString(),
                        Precio = (float)Convert.ToDecimal(reader["Precio"]),
                    };

                    // Agregar los productos a la lista
                    products.Add(product);
                }
            }

            // Bind the collection to the ListView
            lvProducts.ItemsSource = products;



        }
        private void ListView_Loaded(object sender, RoutedEventArgs e)
        {
            // Get the collection of products.
            ObservableCollection<Product> products = new ObservableCollection<Product>();

            // Bind the ListView control to the collection of products.
            listView.ItemsSource = products;
        }

        public ListView lvProducts { get; private set; }

        private void AddToCart(object sender, RoutedEventArgs e)
        {
            var products = (Product)sender;
            // Add the product to the cart
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e) { }


    }
}
