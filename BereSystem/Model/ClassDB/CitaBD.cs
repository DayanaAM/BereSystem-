using BereSystem.DAO;
using BereSystem.Model.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BereSystem.Model.ClassDB
{
    public class CitaBD
    {

        public int agregarCita(Cita c)
        {
            SqlCommand oCommand = new SqlCommand();
            int registrosActualizados = 0;

            oCommand.CommandText = "sp_inserta_cita";//Nombre del procedimiento en sql-server
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.AddWithValue("@pHorario", c.horario);
            oCommand.Parameters[0].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pHoraInicio", c.horaInicio);
            oCommand.Parameters[1].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pHoraFin", c.horaFin);
            oCommand.Parameters[2].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pMinutosDisponibles", c.minutosDisponibles);
            oCommand.Parameters[3].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pCantidadTotalMin", c.cantidadTotalMin);
            oCommand.Parameters[4].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pEstado", c.estado);
            oCommand.Parameters[5].Direction = ParameterDirection.Input;

            try
            {
                registrosActualizados = AccesoDatos.getInstance().EjecutarSqlActualizacion(oCommand);
                return registrosActualizados;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int modificaCita(Cita c)
        {
            SqlCommand oCommand = new SqlCommand();
            int registrosActualizados = 0;

            oCommand.CommandText = "sp_modifica_cita";//Nombre del procedimiento en sql-server
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores

            oCommand.Parameters.AddWithValue("@pNumCita", c.numCita);
            oCommand.Parameters[0].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pDia", c.dia);
            oCommand.Parameters[1].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pHorario", c.horario);
            oCommand.Parameters[2].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pHoraInicio", c.horaInicio);
            oCommand.Parameters[3].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pHoraFin", c.horaFin);
            oCommand.Parameters[4].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pMinutosDisponibles", c.minutosDisponibles);
            oCommand.Parameters[5].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pCantidadTotalMin", c.cantidadTotalMin);
            oCommand.Parameters[6].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pEstado", c.estado);
            oCommand.Parameters[7].Direction = ParameterDirection.Input;

            try
            {
                registrosActualizados = AccesoDatos.getInstance().EjecutarSqlActualizacion(oCommand);
                return registrosActualizados;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int eliminaCita(Cita c)
        {
            SqlCommand oCommand = new SqlCommand();
            int registrosActualizados = 0;

            oCommand.CommandText = "sp_eliminar_cita";//Nombre del procedimiento en sql-server
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.AddWithValue("@pNumCita", c.numCita);
            oCommand.Parameters[0].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pDia", c.dia);
            oCommand.Parameters[1].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pHorario", c.horario);
            oCommand.Parameters[2].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pEstado", c.estado);
            oCommand.Parameters[3].Direction = ParameterDirection.Input;

            try
            {
                registrosActualizados = AccesoDatos.getInstance().EjecutarSqlActualizacion(oCommand);
                return registrosActualizados;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public Cita cita(int numCita)
        {
            string sql = "Select numCita,dia,horario,horaInicio,horaFin,minutosDisponibles,cantidadTotalMin, estado from Cita where numCita=" + numCita;
            try
            {
                Cita cita = new Cita();
                SqlConnection oConex = new SqlConnection(@"Data Source=localhost;Initial Catalog=bereSystem;User ID=sa;Password=123456");
                oConex.Open();
                SqlCommand ocmd = new SqlCommand(sql, oConex);

                SqlDataReader dr = ocmd.ExecuteReader();

                dr.Read();
                cita.numCita= int.Parse(dr[0].ToString());
                cita.dia = DateTime.Parse(dr[1].ToString());
                cita.horario = int.Parse(dr[2].ToString());
                cita.horaInicio = int.Parse(dr[3].ToString());
                cita.horaFin = int.Parse(dr[4].ToString());
                cita.minutosDisponibles= int.Parse(dr[5].ToString());
                cita.cantidadTotalMin = int.Parse(dr[6].ToString());
                cita.estado = int.Parse(dr[7].ToString());
                oConex.Close();

                return cita;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable listaCitas()
        {
            SqlCommand oCommand = new SqlCommand();


            oCommand.CommandText = "sp_lista_citas";//Nombre del procedimiento en sql-server
            oCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                return AccesoDatos.getInstance().EjecutarConsultaDataTable(oCommand);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}