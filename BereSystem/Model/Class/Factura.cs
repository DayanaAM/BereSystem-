using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BereSystem.Model.Class
{
    public class Factura
    {
        public int numFactura { get; set; }
        public DateTime fecha { get; set; }
        public Guid cliente { get; set; }
        public int descuento { get; set; }
        public int montoTotal { get; set; }
        public int estado { get; set; }

        public Estado Estado
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Factura() { }

        public Factura(int numFactura, DateTime fecha,Guid cliente, int descuento, int montoTotal, int estado)
        {
            this.numFactura = numFactura;
            this.fecha = fecha;
            this.cliente = cliente;
            this.descuento = descuento;
            this.montoTotal = montoTotal;
            this.estado = estado;
        }
    }
}