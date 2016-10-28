
using BereSystem.Model.Class;
using BereSystem.Model.ClassDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BereSystem.View.ZonaAdministrador
{
    public partial class RegistroProcedimientos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            asignaCodigo();
            cargarCategorias();
             cargarZonasTratamiento();
        }

        private void asignaCodigo()
        {
            try
            {
                ServicioBD servicio = new ServicioBD();
                txtCodigo.Text = servicio.consecutivo();
            }
            catch (Exception e)
            {
                Response.Write("Error en asignacion de codigo consecutivo: " + e.Message);
            }
        }


        private void cargarCategorias()
        {
            try
            {
                CategoriaBD categoriaBD = new  CategoriaBD();
                DataTable data = new DataTable();
                data = categoriaBD.listaCategorias();
                ddlCategorias.DataSource = data;
                ddlCategorias.DataValueField = "codigo";
                ddlCategorias.DataTextField = "nombre";
                ddlCategorias.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("Error en llenar las categorias: " + ex.Message);
            }
        }

        private void cargarZonasTratamiento()
        {
            try
            {
                ZonaTratamientoBD zonaTratamientoBD = new ZonaTratamientoBD();
                DataTable data = new DataTable();
                data = zonaTratamientoBD.listaZonaTratamientos();
                ddlZonas.DataSource = data;
                ddlZonas.DataValueField = "codigo";
                ddlZonas.DataTextField = "nombre";
                ddlZonas.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("Error en llenar las Zonas de Tratamiento: " + ex.Message);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
             // aqui  llama webservice update 

             Services.WebServiceBereSystemSoapClient servicio = new Services.WebServiceBereSystemSoapClient();
           
             try
             {
                
                 string nombre = txtNombre.Text;
                 int codCategoria = Convert.ToInt32(ddlCategorias.SelectedValue);
                 Categoria categoria1= new Categoria();
                 categoria1.codigo=codCategoria;
                 int codZona = Convert.ToInt32(ddlZonas.Text);
                 ZonaTratamiento zona= new ZonaTratamiento();
                 zona.codigo=codZona;
                 int precio = Convert.ToInt32(txtPrecio.Text);
                 int tipoServ=0;
                 int duracionMinutos =Convert.ToInt32(txtDuracion.Text);
                 int estado=Convert.ToInt32(cboEstado.Text);


               //servicio.insertaServicio(nombre, categoria1, zona, precio, tipoServ, duracionMinutos, estado);
                 lblMensaje.Text = "Producto Actualizado Correctamente";
                 //llenaDatos();
                 //limpiar();
                 asignaCodigo();
                 this.btnAgregar.Visible = true;
                 this.btnActualiza.Visible = false;
             }
              catch (Exception ex)
            {
                Response.Write("Error en llenar las Zonas de Tratamiento: " + ex.Message);
            }
         }
    }

}
         
