using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BereSystem.Model.Class
{
    public class Servicio
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public Categoria categoria { get; set; }
        public ZonaTratamiento zona { get; set; }
        public int precio { get; set; }
        public int tipoServicio { get; set; }
        public int duracionMinutos { get; set; }
        public int estado { get; set; }

       
        public ZonaTratamiento ZonaTratamiento
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Servicio() { }

        public Servicio(int codigo, string nombre, Categoria categoria,ZonaTratamiento zona, int precio,int tipoServicio, int duracionMinutos, int estado)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.categoria = categoria;
            this.zona = zona;
            this.precio = precio;
            this.tipoServicio = tipoServicio;
            this.duracionMinutos = duracionMinutos;
            this.estado = estado;
        }
    }
}