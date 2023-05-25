using System;
using System.Collections.Generic;
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

namespace TiendaP.View
{
    /// <summary>
    /// Lógica de interacción para CuentaView.xaml
    /// </summary>
    public partial class CuentaView : System.Windows.Controls.UserControl
    {
        public CuentaView()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            product.Nombre = txtNombre.Text;
            product.Tipo = txtTipo.Text;
            product.Talla = txtTalla.Text;
            product.ImagenURl = txtImagenUrl.Text;
            product.Precio = float.Parse(txtPrecio.Text);  

            int resultado = IProductRepository.Agregar(product);

            if (resultado > 0) {
                DatosGuardados.Text = "Se han guardado correctamente";
            } else
            {
                DatosGuardados.Text = "No se pudieron guardar los datos";
            }
        }
    }
}
