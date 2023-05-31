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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TiendaP.Models;
using TiendaP.ViewModels;

namespace TiendaP.View
{
    /// <summary>
    /// Lógica de interacción para CestaView.xaml
    /// </summary>
    public partial class CestaView : UserControl
    {

        private static List<Product> _carrito = new List<Product>();
        float precioCompra = 0;
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

            foreach (Product producto in Carrito)
            {
                precioCompra += producto.Precio;
            }

            precioPedido.Text = (precioCompra).ToString("0.00") + "€";
            
            if (precioCompra > 100)
            {
                gastoPedido.Text = ("0€");
                totalPedido.Text = (precioCompra).ToString("0.00") + "€"; ;
            }
            else
            {
                totalPedido.Text = (precioCompra + 4.95f).ToString("0.00") + "€";
            }

        }

        public Product Product { get; set; }
        public string ImagenUrl { get; set; }
        public string Nombre { set; get; }
        public string Talla { set; get; }
        public float Precio { set; get; }

        
        
        private void btnDltProduct_Click(object sender, RoutedEventArgs e)
        {
            // Obtén el botón que se hizo clic
            Button button = (Button)sender;

            // Obtén el elemento asociado al botón
            Product producto = button.DataContext as Product;

            if (producto != null)
            {
                // Eliminar el elemento de la lista "Carrito"
                Carrito.Remove(producto);

                // Recalcular el precio de compra
                precioCompra = (float)Math.Round(precioCompra, 2);
                precioCompra = 0;
                foreach (Product p in Carrito)
                {
                    precioCompra += p.Precio;
                }

                // Actualizar los textos con los nuevos precios
                precioPedido.Text = (precioCompra).ToString("0.00") + "€";
                if (precioCompra > 100)
                {
                    gastoPedido.Text = ("0€");
                    totalPedido.Text = (precioCompra).ToString("0.00") + "€";
                } else
                {
                    totalPedido.Text = (precioCompra + 4.95f).ToString("0.00") + "€";
                }

                // Refrescar el origen de datos del control
                ProductosCesta.ItemsSource = null;  // Limpia el origen de datos actual
                ProductosCesta.ItemsSource = Carrito; // Asigna la lista actualizada como nuevo origen de datos


            }


        }

        private void btnConfirmarCompra_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
