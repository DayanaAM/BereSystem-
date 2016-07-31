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
    public class DetalleFacturaBD
    {

        public int agregarDetalleFactura(DetalleFactura df)
        {
            SqlCommand oCommand = new SqlCommand();
            int registrosActualizados = 0;

            oCommand.CommandText = "sp_inserta_detalle_factura";//Nombre del procedimiento en sql-server
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.AddWithValue("@pNumFactura", df.numFactura);
            oCommand.Parameters[0].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pProducto", df.producto);
            oCommand.Parameters[1].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pServicio", df.servicio);
            oCommand.Parameters[2].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pPrecio", df.precio);
            oCommand.Parameters[3].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pCantidad", df.cantidad);
            oCommand.Parameters[4].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pTotal", df.total);
            oCommand.Parameters[5].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pEstado", df.estado);
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

        public int modificaDetalleFactura(DetalleFactura df)
        {
            SqlCommand oCommand = new SqlCommand();
            int registrosActualizados = 0;

            oCommand.CommandText = "sp_modifica_detalle_factura";//Nombre del procedimiento en sql-server
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.AddWithValue("@pNumFactura", df.numFactura);
            oCommand.Parameters[0].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pProducto", df.producto);
            oCommand.Parameters[1].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pServicio", df.servicio);
            oCommand.Parameters[2].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pPrecio", df.precio);
            oCommand.Parameters[3].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pCantidad", df.cantidad);
            oCommand.Parameters[4].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pTotal", df.total);
            oCommand.Parameters[5].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pEstado", df.estado);
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

        public int eliminaDetalleFactura(DetalleFactura df)
        {
            SqlCommand oCommand = new SqlCommand();
            int registrosActualizados = 0;

            oCommand.CommandText = "sp_eliminar_detalle_factura";//Nombre del procedimiento en sql-server
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.AddWithValue("@pNumFactura", df.numFactura);
            oCommand.Parameters[0].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pProducto", df.producto);
            oCommand.Parameters[1].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pServicio", df.servicio);
            oCommand.Parameters[2].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pEstado", df.estado);
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

        public DetalleFactura detalleFactura(int numFactura, int producto, int servicio, int estado)
        {
            string sql ="Select numFactura, producto,servicio, estado from Detalle_Factura where numFactura=" + numFactura +
                         " and producto= " + producto + " and servicio= " + servicio + " and estado= " + estado; 
            try
            {
                DetalleFactura defact = new DetalleFactura();
                SqlConnection oConex = new SqlConnection(@"Data Source=localhost;Initial Catalog=bereSystem;User ID=sa;Password=123456");
                oConex.Open();
                SqlCommand ocmd = new SqlCommand(sql, oConex);


                SqlDataReader dr = ocmd.ExecuteReader();

                dr.Read();
                defact.numFactura = int.Parse(dr[0].ToString());
                defact.producto = int.Parse(dr[1].ToString());
                defact.servicio = int.Parse(dr[2].ToString());
                defact.estado = int.Parse(dr[3].ToString());
                oConex.Close();

                return defact;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataTable detalleFactura()
        {
            SqlCommand oCommand = new SqlCommand();


            oCommand.CommandText = "sp_lista_detalles_factura";//Nombre del procedimiento en sql-server
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