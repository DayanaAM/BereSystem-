using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BereSystem.Model.Class
{
    public class CitaServicio
    {
        public int numCita { get; set; }
        public DateTime dia { get; set; }
        public Guid usuario { get; set; }
        public int servicio { get; set; }
        public int hora { get; set; }
        public int duracionMinutos { get; set; }
        public int estado { get; set; }

        public CitaServicio() { }

        public CitaServicio(  int numCita,DateTime dia , Guid usuario ,int servicio , int hora, int duracionMinutos, int estado )
        {
            this.numCita = numCita;
            this.dia = dia;
            this.usuario = usuario;
            this.servicio = servicio;
            this.hora = hora;
            this.duracionMinutos = duracionMinutos;
            this.estado = estado;
        }
    }
}