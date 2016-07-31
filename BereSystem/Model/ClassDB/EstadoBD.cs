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
    public class EstadoBD
    {

        public int agregarEstado(Estado estado)
        {
            SqlCommand oCommand = new SqlCommand();
            int registrosActualizados = 0;

            oCommand.CommandText = "sp_inserta_estado";//Nombre del procedimiento en sql-server
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.AddWithValue("@pCodigo", estado.codigo);
            oCommand.Parameters[0].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pEstado", estado.estado);
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

        public int modificaEstado(Estado estado)
        {
            SqlCommand oCommand = new SqlCommand();
            int registrosActualizados = 0;

            oCommand.CommandText = "sp_modifica_estado";//Nombre del procedimiento en sql-server
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.AddWithValue("@pCodigo", estado.codigo);
            oCommand.Parameters[0].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pEstado", estado.estado);
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

        public int eliminaEstado(Estado estado)
        {
            SqlCommand oCommand = new SqlCommand();
            int registrosActualizados = 0;

            oCommand.CommandText = "sp_eliminar_estado";//Nombre del procedimiento en sql-server
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.AddWithValue("@pCodigo", estado.codigo);
            oCommand.Parameters[0].Direction = ParameterDirection.Input;

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


        public Estado estado(int codigo)
        {
            string sql = "Select codigo,estado from Estado where codigo="+codigo;
            try
            {
                Estado estado1 = new Estado();
                SqlConnection oConex = new SqlConnection(@"Data Source=localhost;Initial Catalog=bereSystem;User ID=sa;Password=123456");
                oConex.Open();
                SqlCommand ocmd = new SqlCommand(sql, oConex);

                SqlDataReader dr = ocmd.ExecuteReader();

                dr.Read();
                estado1.codigo = int.Parse(dr[0].ToString());
                estado1.estado = dr[1].ToString();
                oConex.Close();

                return estado1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable listaEstados()
        {
            SqlCommand oCommand = new SqlCommand();


            oCommand.CommandText = "sp_lista_estados";//Nombre del procedimiento en sql-server
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