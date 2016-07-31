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
    public class CategoriaBD
    {

        public int agregarCategoria(Categoria c)
        {
            SqlCommand oCommand = new SqlCommand();
            int registrosActualizados = 0;

            oCommand.CommandText = "sp_inserta_categoria";//Nombre del procedimiento en sql-server
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.AddWithValue("@pNombre", c.nombre);
            oCommand.Parameters[0].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pEstado", c.estado);
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

        public int modificaCategoria(Categoria c)
        {
            SqlCommand oCommand = new SqlCommand();
            int registrosActualizados = 0;

            oCommand.CommandText = "sp_modifica_categoria";//Nombre del procedimiento en sql-server
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.AddWithValue("@pCodigo", c.codigo);
            oCommand.Parameters[0].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pNombre", c.nombre);
            oCommand.Parameters[1].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pEstado", c.estado);
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

        public int eliminaCategoria(Categoria c)
        {
            SqlCommand oCommand = new SqlCommand();
            int registrosActualizados = 0;

            oCommand.CommandText = "sp_eliminar_categoria";//Nombre del procedimiento en sql-server
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.AddWithValue("@pCodigo", c.codigo);
            oCommand.Parameters[0].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pEstado", c.estado);
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

        public Categoria categoria(int cod)
        {
            string sql = "Select codigo,nombre,estado from Categoria where codigo=" + cod;
            try
            {
                Categoria cat = new Categoria();
                SqlConnection oConex = new SqlConnection(@"Data Source=localhost;Initial Catalog=bereSystem;User ID=sa;Password=123456");
                oConex.Open();
                SqlCommand ocmd = new SqlCommand(sql, oConex);

                SqlDataReader dr = ocmd.ExecuteReader();

                dr.Read();
                cat.codigo = int.Parse(dr[0].ToString());
                cat.nombre = dr[1].ToString();
                cat.estado = int.Parse(dr[2].ToString());
                oConex.Close();

                return cat;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataTable listaCategorias()
        {
            SqlCommand oCommand = new SqlCommand();


            oCommand.CommandText = "sp_lista_categorias";//Nombre del procedimiento en sql-server
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