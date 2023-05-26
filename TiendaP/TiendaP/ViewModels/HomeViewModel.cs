using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaP.Models;

namespace TiendaP.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private List<Product> products;

        public List<Product> Products
        {
            get { return products; }
            set
            {
                if (products != value)
                {
                    products = value;
                    OnPropertyChanged(nameof(Products));
                }
            }
        }

        public HomeViewModel()
        {
            // Get products from the repository and assign them to the Products property
            Products = IProductRepository.ObtenerProductos();
        }
    }
}