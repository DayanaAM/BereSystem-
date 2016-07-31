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
    public class ProductoBD
    {


        public int agregarProducto(Producto  producto)
        {
            SqlCommand oCommand = new SqlCommand();
            int registrosActualizados = 0;

            oCommand.CommandText = "sp_inserta_producto";//Nombre del procedimiento en sql-server
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.AddWithValue("@pCodigo", producto.codigo);
            oCommand.Parameters[0].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pNombre", producto.nombre);
            oCommand.Parameters[1].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pCantidad", producto.cantidad);
            oCommand.Parameters[2].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pCategoria", producto.categoria);
            oCommand.Parameters[3].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pPrecio", producto.precio);
            oCommand.Parameters[4].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pEstado", producto.estado);
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

        public int modificaProducto(Producto producto)
        {
            SqlCommand oCommand = new SqlCommand();
            int registrosActualizados = 0;

            oCommand.CommandText = "sp_modifica_producto";//Nombre del procedimiento en sql-server
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores

            oCommand.Parameters.AddWithValue("@pCodigo", producto.codigo);
            oCommand.Parameters[0].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pNombre", producto.nombre);
            oCommand.Parameters[1].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pCantidad", producto.cantidad);
            oCommand.Parameters[2].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pCategoria", producto.categoria);
            oCommand.Parameters[3].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pPrecio", producto.precio);
            oCommand.Parameters[4].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pEstado", producto.estado);
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

        public int eliminaProducto(Producto producto)
        {
            SqlCommand oCommand = new SqlCommand();
            int registrosActualizados = 0;

            oCommand.CommandText = "sp_eliminar_producto";//Nombre del procedimiento en sql-server
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.AddWithValue("@pCodigo", producto.codigo);
            oCommand.Parameters[0].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pEstado", producto.estado);
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


        public Producto producto (int codigo)
        {
            string sql = "Select codigo,nombre,stock,categoria,precio,estado from Producto where codigo=" + codigo;
            try
            {
                Producto producto = new Producto();
                SqlConnection oConex = new SqlConnection(@"Data Source=localhost;Initial Catalog=bereSystem;User ID=sa;Password=123456");
                oConex.Open();
                SqlCommand ocmd = new SqlCommand(sql, oConex);

                SqlDataReader dr = ocmd.ExecuteReader();

                dr.Read();
                producto.codigo = int.Parse(dr[0].ToString());
                producto.nombre = dr[1].ToString();
                producto.cantidad= int.Parse(dr[2].ToString());
                producto.categoria =int.Parse(dr[3].ToString());
                producto.precio = int.Parse(dr[4].ToString());
                producto.estado = int.Parse(dr[5].ToString());
                oConex.Close();

                return producto;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable listaProductos()
        {
            SqlCommand oCommand = new SqlCommand();


            oCommand.CommandText = "sp_lista_productos";//Nombre del procedimiento en sql-server
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