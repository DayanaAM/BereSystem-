using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BereSystem.Model.Class
{
    public class DetalleFactura
    {
        public int numFactura { get; set; }
        public int producto { get; set; }
        public int servicio { get; set; }
        public int precio { get; set; }
        public int cantidad { get; set; }
        public int total { get; set; }
        public int estado { get; set; }

        public DetalleFactura() { }

        public DetalleFactura(int numFactura,int producto, int servicio, int precio, int cantidad, int total, int estado) 
        {
            this.numFactura = numFactura;
            this.producto = producto;
            this.servicio = servicio;
            this.precio = precio;
            this.cantidad = cantidad;
            this.total = total;
            this.estado = estado;
        }
    }
}