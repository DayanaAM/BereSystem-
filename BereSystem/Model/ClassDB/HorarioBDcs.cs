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
    public class HorarioBDcs
    {


        public int agregarHorario(Horario horario)
        {
            SqlCommand oCommand = new SqlCommand();
            int registrosActualizados = 0;

            oCommand.CommandText = "sp_inserta_horario";//Nombre del procedimiento en sql-server
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.AddWithValue("@pCodigo", horario.codigo);
            oCommand.Parameters[0].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pNombre", horario.nombre);
            oCommand.Parameters[1].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pEstado", horario.estado);
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

        public int modificaHorario(Horario horario)
        {
            SqlCommand oCommand = new SqlCommand();
            int registrosActualizados = 0;

            oCommand.CommandText = "sp_modifica_horario";//Nombre del procedimiento en sql-server
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores

            oCommand.Parameters.AddWithValue("@pCodigo", horario.codigo);
            oCommand.Parameters[0].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pNombre", horario.nombre);
            oCommand.Parameters[1].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pEstado", horario.estado);
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

        public int eliminaHorario(Horario horario)
        {
            SqlCommand oCommand = new SqlCommand();
            int registrosActualizados = 0;

            oCommand.CommandText = "sp_eliminar_horario";//Nombre del procedimiento en sql-server
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.AddWithValue("@pCodigo", horario.codigo);
            oCommand.Parameters[0].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pEstado", horario.estado);
            oCommand.Parameters[1].Direction = ParameterDirection.Input;

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


        public Horario horario(int codigo)
        {
            string sql = "Select codigo,nombre,estado from Horario where codigo=" + codigo;
            try
            {
                Horario horario = new Horario();
                SqlConnection oConex = new SqlConnection(@"Data Source=localhost;Initial Catalog=bereSystem;User ID=sa;Password=123456");
                oConex.Open();
                SqlCommand ocmd = new SqlCommand(sql, oConex);

                SqlDataReader dr = ocmd.ExecuteReader();

                dr.Read();
                horario.codigo = int.Parse(dr[0].ToString());
                horario.nombre = dr[1].ToString();
                horario.estado = int.Parse(dr[2].ToString());
                oConex.Close();

                return horario;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable listaCitas()
        {
            SqlCommand oCommand = new SqlCommand();

            oCommand.CommandText = "sp_lista_horarios";//Nombre del procedimiento en sql-server
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