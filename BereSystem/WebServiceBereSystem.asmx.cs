using BereSystem.Model.Class;
using BereSystem.Model.ClassDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace BereSystem
{
    /// <summary>
    /// Descripción breve de WebServiceBereSystem
    /// </summary>
    [WebService(Namespace = "http://localhost/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceBereSystem : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        //*****************************************************Productos***************************************************
        [WebMethod]
        public int insertaProducto(string nombre, int cantidad, int categoria, int precio, int estado)
        {
            Producto producto= new Producto();
            producto.nombre = nombre;
            producto.cantidad = cantidad;
            producto.categoria = categoria;
            producto.precio = precio;
            producto.estado = estado;
            ProductoBD productoBD = new ProductoBD();
            int result = 0;
            try
            {
                result = productoBD.agregarProducto(producto);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public int modificaProveedor(int codigo, string nombre, int cantidad, int categoria, int precio, int estado)
        {
            Producto producto = new Producto(codigo,nombre, cantidad, categoria, precio, estado);
            ProductoBD productoBD = new ProductoBD();
            int result = 0;
            try
            {
                result = productoBD.modificaProducto(producto);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public int eliminaProducto(int codigo, int estado)
        {
            Producto producto = new Producto();
            
            producto.codigo = codigo;
            producto.estado = estado;
            ProductoBD productoBD = new ProductoBD();
            int result = 0;
            try
            {
                result = productoBD.eliminaProducto(producto);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //*****************************************************Citas***************************************************
        [WebMethod]
        public int insertaCita(DateTime dia,int horario, int horaInicio, int horaFin,int  minutosDisponibles, int cantidadTotalMin, int estado )
        {
            int numCita = 0;
            Cita cita = new Cita(numCita,dia,horario,horaInicio,horaFin,minutosDisponibles,cantidadTotalMin,estado);
            CitaBD citaBD = new CitaBD();

            int result = 0;
            try
            {
                result = citaBD.agregarCita(cita);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public int modificaCita(int numCita, DateTime dia, int horario, int horaInicio, int horaFin, int minutosDisponibles, int cantidadTotalMin, int estado)
        {
            Cita cita = new Cita(numCita, dia, horario, horaInicio, horaFin, minutosDisponibles, cantidadTotalMin, estado);
            CitaBD citaBD = new CitaBD();
            int result = 0;
            try
            {
                result = citaBD.modificaCita(cita);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public int eliminaCita(int numCita, int estado)
        {
            Cita cita = new Cita();
            cita.numCita= numCita;
            cita.estado = estado;
            CitaBD citaBD = new CitaBD();
            int result = 0;
            try
            {
                result = citaBD.eliminaCita(cita);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //*****************************************************Servicio ***********************************************************************
        [WebMethod]
        public int insertaServicio(string nombre,Categoria categoria,ZonaTratamiento zona, int precio,int tipoServicio, int duracionMinutos, int estado)
        {
            int codigo = 0;
            Servicio servicio = new Servicio(codigo, nombre, categoria, zona, precio, tipoServicio, duracionMinutos, estado);
            ServicioBD servBD = new ServicioBD();
            int result = 0;
            try
            {
                result = servBD.agregarServicio(servicio);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public int modificaServicio(int codigo, string nombre,Categoria categoria,ZonaTratamiento zona, int precio,int tipoServicio, int duracionMinutos, int estado)
        {
            Servicio servicio = new Servicio(codigo, nombre, categoria, zona, precio, tipoServicio, duracionMinutos, estado);
            ServicioBD servBD = new ServicioBD();
            int result = 0;
            try
            {
                result = servBD.modificaServicio(servicio);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public int eliminaServicio(int codigo, int estado)
        {
            Servicio servicio = new Servicio();
            servicio.codigo = codigo;
            servicio.estado = estado;
            ServicioBD servBD = new ServicioBD();
            int result = 0;
            try
            {
                result = servBD.eliminaServicio(servicio);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //*****************************************************Estado***************************************************
        [WebMethod]
        public int insertaEstado(int codigo, string estado)
        {
            Estado estado1 = new Estado(codigo,estado);
            EstadoBD estadoBD = new EstadoBD();
         
            int result = 0;
            try
            {
                result = estadoBD.agregarEstado(estado1);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public int modificaEstado(int codigo, string estado)
        {
            Estado estado1 = new Estado(codigo, estado);
            EstadoBD estadoBD = new EstadoBD();
            int result = 0;
            try
            {
                result = estadoBD.modificaEstado(estado1);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public int eliminaEstado(int codigo)
        {
            Estado estado1 = new Estado();
            estado1.codigo = codigo;
            EstadoBD estadoBD = new EstadoBD();
            int result = 0;
            try
            {
                result = estadoBD.eliminaEstado(estado1);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //*****************************************************Horario***************************************************
        [WebMethod]
        public int insertaHorario( string nombre, int estado)
        {
            int codigo = 0;
            Horario horario = new Horario(codigo, nombre, estado);
            HorarioBD horarioBD = new HorarioBD();

            int result = 0;
            try
            {
                result = horarioBD.agregarHorario(horario);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public int modificaHorario(int codigo, string nombre, int estado)
        {   Horario horario = new Horario(codigo, nombre, estado);
            HorarioBD horarioBD = new HorarioBD();

            int result = 0;
            try
            {
                result = horarioBD.modificaHorario(horario);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public int eliminaHorario(int codigo)
        {
            Horario horario = new Horario();
            horario.codigo = codigo;
            HorarioBD horarioBD = new HorarioBD();
            int result = 0;
            try
            {
                result = horarioBD.eliminaHorario(horario);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //*****************************************************Categoria***************************************************
        [WebMethod]
        public int insertaCategoria(string nombre, int estado)
        {
            int codigo = 0;
            Categoria categoria = new Categoria(codigo, nombre, estado);
            CategoriaBD catBD = new CategoriaBD();

            int result = 0;
            try
            {
                result = catBD.agregarCategoria(categoria);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public int modificaCategoria(int codigo, string nombre, int estado)
        {
            Categoria categoria = new Categoria(codigo, nombre, estado);
            CategoriaBD catBD = new CategoriaBD();

            int result = 0;
            try
            {
                result = catBD.modificaCategoria(categoria);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public int eliminaCategoria(int codigo)
        {
            Categoria categoria = new Categoria();
            categoria.codigo = codigo;
            CategoriaBD catBD = new CategoriaBD();
            int result = 0;
            try
            {
                result = catBD.eliminaCategoria(categoria);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //*****************************************************Zona Tratamiento***************************************************
        [WebMethod]
        public int insertaZonaTratamiento(string nombre, int estado)
        {
            int codigo = 0;
            ZonaTratamiento zonaTratamiento = new ZonaTratamiento(codigo, nombre, estado);
            ZonaTratamientoBD zonaTratBD = new ZonaTratamientoBD();

            int result = 0;
            try
            {
                result = zonaTratBD.agregarZonaTratamiento(zonaTratamiento);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public int modificaZonaTratamiento(int codigo, string nombre, int estado)
        {
            ZonaTratamiento zonaTratamiento = new ZonaTratamiento(codigo, nombre, estado);
            ZonaTratamientoBD zonaTratBD = new ZonaTratamientoBD();

            int result = 0;
            try
            {
                result = zonaTratBD.modificaZonaTratamiento(zonaTratamiento);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public int eliminaZonaTratamiento(int codigo)
        {
            ZonaTratamiento zonaTratamiento = new ZonaTratamiento();
            zonaTratamiento.codigo = codigo;
            ZonaTratamientoBD zonaTratBD = new ZonaTratamientoBD();
            int result = 0;
            try
            {
                result = zonaTratBD.eliminaZonaTratamiento(zonaTratamiento);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        //*****************************************************Tipo_Servicio***************************************************
        [WebMethod]
        public int insertaTipoServicio(string nombre, int estado)
        {
            int codigo = 0;
            TipoServicio tipServicio = new TipoServicio(codigo, nombre, estado);
            TipoServicioBD tipServicioBD = new TipoServicioBD();

            int result = 0;
            try
            {
                result = tipServicioBD.agregarTipoServicio(tipServicio);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public int modificaTipoServicio(int codigo, string nombre, int estado)
        {
            TipoServicio tipServicio = new TipoServicio(codigo, nombre, estado);
            TipoServicioBD tipServicioBD = new TipoServicioBD();

            int result = 0;
            try
            {
                result = tipServicioBD.modificaTipoServicio(tipServicio);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public int eliminaTipoServicio(int codigo)
        {
            TipoServicio tipServicio = new TipoServicio();
            tipServicio.codigo = codigo;
            TipoServicioBD tipServicioBD = new TipoServicioBD();
            int result = 0;
            try
            {
                result = tipServicioBD.eliminaTipoServicio(tipServicio);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //*****************************************************Dia_Hora***************************************************
        [WebMethod]
        public int insertaDiaHora(DateTime dia, int hora, int estado)
        {
            DiaHora diaHora = new DiaHora(dia, hora, estado);
            DiaHoraBD diaHoraBD = new DiaHoraBD();

            int result = 0;
            try
            {
                result = diaHoraBD.agregarDiaHora(diaHora);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public int modificaDiaHora(DateTime dia, int hora, int estado)
        {
            DiaHora diaHora = new DiaHora(dia, hora, estado);
            DiaHoraBD diaHoraBD = new DiaHoraBD();

            int result = 0;
            try
            {
                result = diaHoraBD.modificaDiaHora(diaHora);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public int eliminaDiaHora(DateTime dia,int hora)
        {
            DiaHora diaHora = new DiaHora();
            diaHora.dia = dia;
            diaHora.hora = hora;
            DiaHoraBD diaHoraBD = new DiaHoraBD();
            int result = 0;
            try
            {
                result = diaHoraBD.eliminaDiaHora(diaHora);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //*****************************************************Cita_Servicio***************************************************
        [WebMethod]
        public int insertaCitaServicio(int numCita, DateTime dia, Guid usuario, Servicio servicio,int hora, int duracionMinutos, int estado)
        {
            CitaServicio citaServicio = new CitaServicio(numCita,dia,usuario,servicio,hora,duracionMinutos,estado);
            CitaServicioBD citaServicioBD = new CitaServicioBD();
            int result = 0;
            try
            {
                result = citaServicioBD.agregarCitaServicio(citaServicio);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [WebMethod]
        public int modificaCitaServicio(int numCita, DateTime dia, Guid usuario, Servicio servicio, int hora, int duracionMinutos, int estado)
        {
            CitaServicio citaServicio = new CitaServicio(numCita, dia, usuario, servicio, hora, duracionMinutos, estado);
            CitaServicioBD citaServicioBD = new CitaServicioBD();

            int result = 0;
            try
            {
                result = citaServicioBD.modificaCitaServicio(citaServicio);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public int eliminaCitaServicio(int numCita,DateTime dia,Guid usuario,Servicio servicio,int estado)
        {
            CitaServicio citaServicio = new CitaServicio();
            citaServicio.numCita = numCita;
            citaServicio.dia = dia;
            citaServicio.usuario = usuario;

            citaServicio.servicio = servicio;
            citaServicio.estado = estado;
            CitaServicioBD citaServicioBD = new CitaServicioBD();
            int result = 0;
            try
            {
                result = citaServicioBD.eliminaCitaServicio(citaServicio);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //*****************************************************Factura***************************************************
        [WebMethod]
        public int insertaFactura(DateTime fecha, Guid cliente,int descuento, int montoTotal, int estado)
        {
            int numFactura = 0;
            Factura factura = new Factura(numFactura, fecha, cliente, descuento, montoTotal, estado);
            FacturaBD facturaBD = new FacturaBD();
            int result = 0;
            try
            {
                result = facturaBD.agregarFactura(factura);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [WebMethod]
        public int modificaFactura(int numFactura, DateTime fecha, Guid cliente, int descuento, int montoTotal, int estado)
        {
            Factura factura = new Factura(numFactura, fecha, cliente, descuento, montoTotal, estado);
            FacturaBD facturaBD = new FacturaBD();

            int result = 0;
            try
            {
                result = facturaBD.modificaFactura(factura);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public int eliminaFactura(int numFactura, DateTime fecha, Guid cliente, int estado)
        {
            Factura factura = new Factura();
            factura.numFactura = numFactura;
            factura.fecha = fecha;
            factura.cliente = cliente;
            factura.estado = estado;
            FacturaBD facturaBD = new FacturaBD();
            int result = 0;
            try
            {
                result = facturaBD.eliminaFactura(factura);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //*****************************************************Detalle_Factura***************************************************
        [WebMethod]
        public int insertaDetalleFactura(int numFactura,int producto, int servicio, int precio, int cantidad, int total, int estado )
        {
           
            DetalleFactura detalleFactura = new DetalleFactura(numFactura,producto, servicio,precio,cantidad, total,estado);
            DetalleFacturaBD facturaBD = new DetalleFacturaBD();
            int result = 0;
            try
            {
                result = facturaBD.agregarDetalleFactura(detalleFactura);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [WebMethod]
        public int modificaDetalleFactura(int numFactura, int producto, int servicio, int precio, int cantidad, int total, int estado)
        {
            DetalleFactura detalleFactura = new DetalleFactura(numFactura, producto, servicio, precio, cantidad, total, estado);
            DetalleFacturaBD facturaBD = new DetalleFacturaBD();

            int result = 0;
            try
            {
                result = facturaBD.modificaDetalleFactura(detalleFactura);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public int eliminaDetalleFactura(int numFactura, int producto, int servicio,  int estado)
        {
            DetalleFactura detalleFactura = new DetalleFactura();
            detalleFactura.numFactura = numFactura;
            detalleFactura.producto = producto;
            detalleFactura.servicio = servicio;
            detalleFactura.estado = estado;
            DetalleFacturaBD facturaBD = new DetalleFacturaBD();
            int result = 0;
            try
            {
                result = facturaBD.eliminaDetalleFactura(detalleFactura);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
