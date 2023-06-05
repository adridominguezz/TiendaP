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

    public partial class ComprasView : UserControl
    {
        public List<Compras> compras = new List<Compras>();
        public ComprasView()
        {
            InitializeComponent();

            compras = IComprasRepository.ObtenerCompras();


            ListaCompras.ItemsSource = compras;

            DataContext = this;
        }
        private void ItemsControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
