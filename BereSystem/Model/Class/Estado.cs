using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BereSystem.Model.Class
{
    public class Estado
    {
        public int codigo { get; set; }
        public string estado { get; set; }

        public Estado() { }

        public Estado(int codigo, string estado) 
        {
            this.codigo = codigo;
            this.estado = estado;
        }
    }
}