using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TiendaP.Models;
using Button = System.Windows.Controls.Button;

namespace TiendaP.View
{
    /// <summary>
    /// Lógica de interacción para CuentaView.xaml
    /// </summary>
    public partial class CuentaView : System.Windows.Controls.UserControl
    {
        public List<Product> productosTienda = new List<Product>();
        public CuentaView()
        {
            InitializeComponent();

            productosTienda = IProductRepository.ObtenerProductos();

            ProductosTienda.ItemsSource = productosTienda;

            DataContext = this;

        }
        private void ItemsControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            product.Nombre = txtNombre.Text;
            product.Tipo = txtTipo.Text;
            product.Talla = txtTalla.Text;
            product.ImagenURl = txtImagenUrl.Text;

            bool error = false;

            try
            {
                product.Precio = float.Parse(txtPrecio.Text, CultureInfo.GetCultureInfo("en-US"));

                int resultado = IProductRepository.Agregar(product);

                // Refrescar el origen de datos del control
                ProductosTienda.ItemsSource = null;  // Limpia el origen de datos actual
                ProductosTienda.ItemsSource = productosTienda; // Asigna la lista actualizada como nuevo origen de datos

                if (resultado > 0)
                {
                    DatosGuardados.Text = "Se han guardado correctamente";
                    

                }
                else
                {
                    error = true;
                }
            }
            catch
            {
                error = true;
            }

            if (error)
            {
                DatosGuardados.Text = "No se pudieron guardar los datos";
            }
        }

        private void btnSuprProduct_Click(object sender, RoutedEventArgs e)
        {
            // Obtén el botón que se hizo clic
            Button btn = (Button)sender;

            // Obtener el producto asociado al botón
            Product product = (Product)btn.DataContext;

            // Eliminar el producto de la base de datos
            int resultado = IProductRepository.Eliminar(product);

            if (resultado > 0)
            {
                // Eliminación exitosa, actualizar la lista de productos
                productosTienda.Remove(product);
                ProductosTienda.Items.Refresh();
            }
            else
            {
                // Error al eliminar el producto
                DatosGuardados.Text = "No se pudo eliminar el producto";
            }
        }
    }
}
