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
    /// <summary>
    /// Lógica de interacción para HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {

        public HomeView()
        {
            InitializeComponent();

            // Set the DataContext to an instance of HomeViewModel
            DataContext = new HomeViewModel();
        }
    }
}