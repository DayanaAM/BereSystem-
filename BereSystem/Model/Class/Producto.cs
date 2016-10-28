using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BereSystem.Model.Class
{
    public class Producto
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public int cantidad { get; set; }
        public int categoria { get; set; }
        public int precio { get; set; }
        public int estado { get; set; }

        public Categoria Categoria
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Producto() { }

        public Producto(int codigo,string nombre,int cantidad,int categoria, int precio,int estado)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.cantidad = cantidad;
            this.categoria=categoria;
            this.precio=precio;
            this.estado=estado;
            
        }

       
    }
}