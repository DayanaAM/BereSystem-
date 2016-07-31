
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
    public class DiaHoraBD
    {

        public int agregarDiaHora(DiaHora diaHora)
        {
            SqlCommand oCommand = new SqlCommand();
            int registrosActualizados = 0;

            oCommand.CommandText = "sp_inserta_horaDia";//Nombre del procedimiento en sql-server
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.AddWithValue("@pDia", diaHora.dia);
            oCommand.Parameters[0].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pHora", diaHora.hora);
            oCommand.Parameters[1].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pEstado", diaHora.estado);
            oCommand.Parameters[2].Direction = ParameterDirection.Input;


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

        public int modificaDiaHora(DiaHora diaHora)
        {
            SqlCommand oCommand = new SqlCommand();
            int registrosActualizados = 0;

            oCommand.CommandText = "sp_modifica_dia_hora";//Nombre del procedimiento en sql-server
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.AddWithValue("@pDia", diaHora.dia);
            oCommand.Parameters[0].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pHora", diaHora.hora);
            oCommand.Parameters[1].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pEstado", diaHora.estado);
            oCommand.Parameters[2].Direction = ParameterDirection.Input;

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

        public int eliminaDiaHora(DiaHora diaHora)
        {
            SqlCommand oCommand = new SqlCommand();
            int registrosActualizados = 0;

            oCommand.CommandText = "sp_eliminar_dia_hora";//Nombre del procedimiento en sql-server
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.AddWithValue("@pDia", diaHora.dia);
            oCommand.Parameters[0].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pHora", diaHora.hora);
            oCommand.Parameters[1].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pEstado", diaHora.estado);
            oCommand.Parameters[2].Direction = ParameterDirection.Input;


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


        //public DiaHora diaHora( DateTime dia, int hora, int estado )
        //{
        //    string sql = "";
        //    try
        //    {
        //        DiaHora diaHora = new DiaHora();
        //        SqlConnection oConex = new SqlConnection(@"Data Source=localhost;Initial Catalog=bereSystem;User ID=sa;Password=123456");
        //        oConex.Open();
        //        SqlCommand ocmd = new SqlCommand(sql, oConex);

        //        SqlDataReader dr = ocmd.ExecuteReader();

        //        dr.Read();
        //        diaHora.dia = DateTime.Parse(dr[0].ToString());
        //        diaHora.hora = int.Parse(dr[1].ToString());
        //        diaHora.estado = int.Parse(dr[2].ToString());
        //        oConex.Close();

        //        return diaHora;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        public DataTable listaDiaHora()
        {
            SqlCommand oCommand = new SqlCommand();


            oCommand.CommandText = "sp_lista_dia_horas";//Nombre del procedimiento en sql-server
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