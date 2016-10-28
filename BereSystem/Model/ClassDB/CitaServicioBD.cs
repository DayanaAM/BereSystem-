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
    public class CitaServicioBD
    {

        public int agregarCitaServicio(CitaServicio citaServ)
        {
            SqlCommand oCommand = new SqlCommand();
            int registrosActualizados = 0;

            oCommand.CommandText = "sp_inserta_cita_servicio";//Nombre del procedimiento en sql-server
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.AddWithValue("@pNumCita", citaServ.numCita);
            oCommand.Parameters[0].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pDia", citaServ.dia);
            oCommand.Parameters[1].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pUsuario", citaServ.usuario);
            oCommand.Parameters[2].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pServicio", citaServ.servicio);
            oCommand.Parameters[3].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pHora", citaServ.hora);
            oCommand.Parameters[4].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pDuracionMinutos", citaServ.duracionMinutos);
            oCommand.Parameters[5].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pEstado", citaServ.estado);
            oCommand.Parameters[6].Direction = ParameterDirection.Input;

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

        public int modificaCitaServicio(CitaServicio citaServ)
        {
            SqlCommand oCommand = new SqlCommand();
            int registrosActualizados = 0;

            oCommand.CommandText = "sp_modifica_cita_servicio";//Nombre del procedimiento en sql-server
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.AddWithValue("@pNumCita", citaServ.numCita);
            oCommand.Parameters[0].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pDia", citaServ.dia);
            oCommand.Parameters[1].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pUsuario", citaServ.usuario);
            oCommand.Parameters[2].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pServicio", citaServ.servicio);
            oCommand.Parameters[3].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pHora", citaServ.hora);
            oCommand.Parameters[4].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pDuracionMinutos", citaServ.duracionMinutos);
            oCommand.Parameters[5].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pEstado", citaServ.estado);
            oCommand.Parameters[6].Direction = ParameterDirection.Input;
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

        public int eliminaCitaServicio(CitaServicio citaServ)
        {
            SqlCommand oCommand = new SqlCommand();
            int registrosActualizados = 0;

            oCommand.CommandText = "sp_eliminar_cita_servicio";//Nombre del procedimiento en sql-server
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.AddWithValue("@pNumCita", citaServ.numCita);
            oCommand.Parameters[0].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pDia", citaServ.dia);
            oCommand.Parameters[1].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pUsuario", citaServ.usuario);
            oCommand.Parameters[2].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pServicio", citaServ.servicio);
            oCommand.Parameters[3].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pEstado", citaServ.estado);
            oCommand.Parameters[4].Direction = ParameterDirection.Input;

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


        public CitaServicio citaServicio(int numCita, Guid cliente, int servicio)
        {
            string sql = "Select numCita,dia,usuario,servicio,hora,duracionMinutos, estado from Cita_Servicio where numCita=" + numCita +
                " and usuario=  CONVERT(UNIQUEIDENTIFIER,'" + cliente + "') and servicio=" + servicio;
            try
            {
                CitaServicio citaServ = new CitaServicio();
                SqlConnection oConex = new SqlConnection(@"Data Source=localhost;Initial Catalog=bereSystem;User ID=sa;Password=123456");
                oConex.Open();
                SqlCommand ocmd = new SqlCommand(sql, oConex);

                SqlDataReader dr = ocmd.ExecuteReader();

                dr.Read();
                citaServ.numCita = int.Parse(dr[0].ToString());
                citaServ.dia = DateTime.Parse(dr[1].ToString());
                citaServ.usuario = Guid.Parse(dr[2].ToString());
                Servicio servicio1 = new Servicio();
                servicio1.codigo = int.Parse(dr[3].ToString());
                citaServ.servicio = servicio1;
                citaServ.hora = int.Parse(dr[4].ToString());
                citaServ.duracionMinutos = int.Parse(dr[5].ToString());
                citaServ.estado = int.Parse(dr[6].ToString());
                oConex.Close();

                return citaServ;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable listaCitaServicios()
        {
            SqlCommand oCommand = new SqlCommand();


            oCommand.CommandText = "sp_lista_cita_servicios";//Nombre del procedimiento en sql-server
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