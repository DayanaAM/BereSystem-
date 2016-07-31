using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BereSystem.Model.Class
{
    public class Categoria
    {

        public int codigo{ get; set; }
        public string nombre { get; set; }
        public int estado { get; set; }
    

        public Categoria() { }

        public Categoria(int codigo, string nombre, int estado)
        {
            this.codigo= codigo;
            this.nombre = nombre;
            this.estado = estado;
        }

    }
}