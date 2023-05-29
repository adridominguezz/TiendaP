﻿using System;
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

        public List<Product> lista = new List<Product>();
        public HomeView()
        {
            InitializeComponent();

            Binding Producto = new Binding();
            Binding Img = new Binding();
            Binding Nombre = new Binding();
            Binding Talla = new Binding();
            Binding Precio = new Binding();


            ////Obtengo los productos de la tabla
            //List<Product> Lista = new List<Product>();

            lista = IProductRepository.ObtenerProductos();


            DataContext = this;


            Producto.Source = lista[0];
            Img.Source = lista[0].ImagenURl;
            Nombre.Source = lista[0].Nombre;
            Talla.Source = lista[0].Talla;
            Precio.Source = lista[0].Precio;

            //TallaValue.SetBinding(TextBlock.TextProperty, Talla);
            //imagenValue.SetBinding(Image.SourceProperty, Img);


            //foreach (Product p in Lista)
            //{
            //    Producto.Source = p;
            //    Img.Source = p.ImagenURl;
            //    Nombre.Source = p.Nombre;
            //    Talla.Source = p.Talla;
            //    Precio.Source = p.Precio;
            //}


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