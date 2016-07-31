using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BereSystem.Model.Class
{
    public class DiaHora
    {

        public DateTime dia { get; set; }
        public int hora { get; set; }
        public int estado { get; set; }

        public DiaHora() { }

        public DiaHora(DateTime dia,int hora, int estado)
         {
             this.dia = dia;
             this.hora = hora;
             this.estado = estado;
        }
    }
}