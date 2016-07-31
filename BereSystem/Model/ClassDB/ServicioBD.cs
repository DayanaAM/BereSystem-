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
    public class ServicioBD
    {


        public int agregarServicio(Servicio servicio)
        {
            SqlCommand oCommand = new SqlCommand();
            int registrosActualizados = 0;

            oCommand.CommandText = "sp_inserta_servicio";//Nombre del procedimiento en sql-server
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores


            oCommand.Parameters.AddWithValue("@pNombre", servicio.nombre);
            oCommand.Parameters[0].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pCategoria", servicio.categoria);
            oCommand.Parameters[1].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pZona", servicio.zona);
            oCommand.Parameters[2].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pPrecio", servicio.precio);
            oCommand.Parameters[3].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pTipoServicio", servicio.tipoServicio);
            oCommand.Parameters[4].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pDuracionMinutos", servicio.duracionMinutos);
            oCommand.Parameters[5].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pEstado", servicio.estado);
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

        public int modificaServicio(Servicio servicio)
        {
            SqlCommand oCommand = new SqlCommand();
            int registrosActualizados = 0;

            oCommand.CommandText = "sp_modifica_servicio";//Nombre del procedimiento en sql-server
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores

            oCommand.Parameters.AddWithValue("@pCodigo", servicio.codigo);
            oCommand.Parameters[0].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pNombre", servicio.nombre);
            oCommand.Parameters[1].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pCategoria", servicio.categoria);
            oCommand.Parameters[2].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pZona", servicio.zona);
            oCommand.Parameters[3].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pPrecio", servicio.precio);
            oCommand.Parameters[4].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pTipoServicio", servicio.tipoServicio);
            oCommand.Parameters[5].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pDuracionMinutos", servicio.duracionMinutos);
            oCommand.Parameters[6].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pEstado", servicio.estado);
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

        public int eliminaServicio(Servicio servicio)
        {
            SqlCommand oCommand = new SqlCommand();
            int registrosActualizados = 0;

            oCommand.CommandText = "sp_eliminar_servicio";//Nombre del procedimiento en sql-server
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.AddWithValue("@pCodigo", servicio.codigo);
            oCommand.Parameters[0].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pEstado", servicio.estado);
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


        public Servicio servicio(int codigo)
        {
            string sql = "Select codigo,nombre,categoria,zona,precio,tipoServicio,duracionMinutos,estado from Servicio where codigo=" + codigo;
            try
            {
                 Servicio servicio = new Servicio();
                SqlConnection oConex = new SqlConnection(@"Data Source=localhost;Initial Catalog=bereSystem;User ID=sa;Password=123456");
                oConex.Open();
                SqlCommand ocmd = new SqlCommand(sql, oConex);

                SqlDataReader dr = ocmd.ExecuteReader();

                dr.Read();
                servicio.codigo = int.Parse(dr[0].ToString());
                servicio.nombre= dr[1].ToString();
                servicio.categoria = int.Parse(dr[2].ToString());
                servicio.zona = int.Parse(dr[3].ToString());
                servicio.precio = int.Parse(dr[4].ToString());
                servicio.tipoServicio = int.Parse(dr[5].ToString());
                servicio.duracionMinutos = int.Parse(dr[6].ToString());
                servicio.estado = int.Parse(dr[7].ToString());
                oConex.Close();

                return servicio;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable listaServicios()
        {
            SqlCommand oCommand = new SqlCommand();


            oCommand.CommandText = "sp_lista_servicios";//Nombre del procedimiento en sql-server
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