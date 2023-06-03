using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using TextBox = System.Windows.Controls.TextBox;

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

            
            ActualizarOrigenDatos();

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


                if (resultado > 0)
                {
                    DatosGuardados.Text = "Se han guardado correctamente";
                    // Refrescar el origen de datos del control
                    ActualizarOrigenDatos();
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

                // Refrescar el origen de datos del control

                ProductosTienda.ItemsSource = null;  // Limpia el origen de datos actual
                ProductosTienda.ItemsSource = productosTienda; // Asigna la lista actualizada como nuevo origen de datos
            }
            else
            {
                // Error al eliminar el producto
                DatosGuardados.Text = "No se pudo eliminar el producto";
            }
        }

        private void btnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            // Obtén el botón que se hizo clic
            Button btn = (Button)sender;

            // Obtener el producto asociado al botón
            Product product = (Product)btn.DataContext;

            // Eliminar el producto de la base de datos
            int resultado = IProductRepository.Eliminar(product);

            TextBox cambioNombre = FindVisualChild<TextBox>(btn, "CambioNombre");
            TextBox cambioMarca = FindVisualChild<TextBox>(btn, "CambioMarca");
            TextBox cambioTalla = FindVisualChild<TextBox>(btn, "CambioTalla");
            TextBox cambioImagen = FindVisualChild<TextBox>(btn, "CambioImagen");
            TextBox cambioPrecio = FindVisualChild<TextBox>(btn, "CambioPrecio");

            if (cambioNombre != null && cambioMarca != null && cambioTalla != null && cambioImagen != null && cambioPrecio != null)
            {
                product.Nombre = cambioNombre.Text;
                product.Tipo = cambioMarca.Text;
                product.Talla = cambioTalla.Text;
                product.ImagenURl = cambioImagen.Text;
                product.Precio = float.Parse(cambioPrecio.Text, CultureInfo.GetCultureInfo("en-US"));
            }

            resultado = IProductRepository.Agregar(product);


            // Refrescar el origen de datos del control
            ActualizarOrigenDatos();
        }

        private static T FindVisualChild<T>(DependencyObject parent, string childName) where T : DependencyObject
        {
            if (parent == null)
                return null;

            T foundChild = null;
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                T childType = child as T;
                if (childType == null)
                {
                    foundChild = FindVisualChild<T>(child, childName);
                    if (foundChild != null)
                        break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    foundChild = (T)child;
                    break;
                }
            }

            return foundChild;
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            ActualizarOrigenDatos();
        }

        private void ActualizarOrigenDatos()
        {
            productosTienda = IProductRepository.ObtenerProductos();
            ObservableCollection<Product> productosObservable = new ObservableCollection<Product>(productosTienda);
            ProductosTienda.ItemsSource = productosObservable;
        }
    }
}
