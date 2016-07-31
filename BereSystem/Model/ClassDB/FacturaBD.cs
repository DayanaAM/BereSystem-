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
    public class FacturaBD
    {

        public int agregarFactura(Factura factura)
        {
            SqlCommand oCommand = new SqlCommand();
            int registrosActualizados = 0;

            oCommand.CommandText = "sp_inserta_factura";//Nombre del procedimiento en sql-server
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.AddWithValue("@pFecha", factura.fecha);
            oCommand.Parameters[0].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pUsuario", factura.cliente);
            oCommand.Parameters[1].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pDescuento", factura.descuento);
            oCommand.Parameters[2].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pMontoTotal", factura.montoTotal);
            oCommand.Parameters[3].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pEstado", factura.estado);
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

        public int modificaFactura(Factura factura)
        {
            SqlCommand oCommand = new SqlCommand();
            int registrosActualizados = 0;

            oCommand.CommandText = "sp_modifica_factura";//Nombre del procedimiento en sql-server
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.AddWithValue("@pNumFactura", factura.numFactura);
            oCommand.Parameters[0].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pFecha", factura.fecha);
            oCommand.Parameters[1].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pUsuario", factura.cliente);
            oCommand.Parameters[2].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pDescuento", factura.descuento);
            oCommand.Parameters[3].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pMontoTotal", factura.montoTotal);
            oCommand.Parameters[4].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pEstado", factura.estado);
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

        public int eliminaFactura(Factura factura)
        {
            SqlCommand oCommand = new SqlCommand();
            int registrosActualizados = 0;

            oCommand.CommandText = "sp_eliminar_factura";//Nombre del procedimiento en sql-server
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.AddWithValue("@pNumFactura", factura.numFactura);
            oCommand.Parameters[0].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pFecha", factura.fecha);
            oCommand.Parameters[1].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pUsuario", factura.cliente);
            oCommand.Parameters[2].Direction = ParameterDirection.Input;

            oCommand.Parameters.AddWithValue("@pEstado", factura.estado);
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


        public Factura factura(int numFactura)
        {
            string sql = "Select numFactura,fecha,cliente,descuento,montoTotal,estado from Factura where numFactura=" + numFactura;
            try
            {
                Factura factura = new Factura();
                SqlConnection oConex = new SqlConnection(@"Data Source=localhost;Initial Catalog=bereSystem;User ID=sa;Password=123456");
                oConex.Open();
                SqlCommand ocmd = new SqlCommand(sql, oConex);
                SqlDataReader dr = ocmd.ExecuteReader();
                dr.Read();
                factura.numFactura = int.Parse(dr[0].ToString());
                factura.fecha = DateTime.Parse(dr[1].ToString());
                factura.cliente = Guid.Parse(dr[2].ToString());
                factura.descuento = int.Parse(dr[3].ToString());
                factura.montoTotal = int.Parse(dr[4].ToString());
                factura.estado= int.Parse(dr[5].ToString());
                oConex.Close();

                return factura;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable listaFacturas()
        {
            SqlCommand oCommand = new SqlCommand();
            oCommand.CommandText = "sp_lista_facturas";//Nombre del procedimiento en sql-server
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