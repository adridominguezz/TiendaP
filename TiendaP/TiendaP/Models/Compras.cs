﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaP.Models
{
    public class Compras
    {

        public int IdCompra { get; set; }
        public string IdCliente { get; set; }
        public int ProductosCompra { get; set; }
        public float PrecioCompra { get; set; }

        public Compras() { }
        public Compras(int idCompra, string idCliente, int productosCompra, float precioCompra)
        {
            IdCompra = idCompra;
            IdCliente = idCliente;
            ProductosCompra = productosCompra;
            PrecioCompra = precioCompra;
        }
        public override string ToString()
        {
            return $"IdCompra: {IdCompra}, IdCliente: {IdCliente}, ProductosCompra: {ProductosCompra}, PrecioCompra: {PrecioCompra}";
        }
    }
}

