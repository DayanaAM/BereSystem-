using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BereSystem.Model.Class
{
    public class Cita
    {

        public int numCita { get; set; }
        public DateTime dia { get; set; }
        public int horario { get; set; }
        public int horaInicio { get; set; }
        public int horaFin { get; set; }
        public int minutosDisponibles { get; set; }
        public int cantidadTotalMin { get; set; }
        public int estado { get; set; }

        public Horario Horario
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

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

        
        public Cita() { }

        public Cita(int numCita, DateTime dia, int horario, int horaIncio, int horaFin, int minutosDisponibles, int cantidadTotalMin, int estado)
        {
            this.numCita = numCita;
            this.dia = dia;
            this.horario = horario;
            this.horaInicio = horaInicio;
            this.horaFin = horaFin;
            this.minutosDisponibles = minutosDisponibles;
            this.cantidadTotalMin = cantidadTotalMin;
            this.estado = estado;
        }
    }
}