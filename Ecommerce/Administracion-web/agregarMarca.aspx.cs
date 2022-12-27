using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administracion_web
{
    
    public partial class modificaMarca : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
            //    tipoNegocio negocioTipo = new tipoNegocio();
            //    ddlTipo.DataSource = negocioTipo.listar();
            //    ddlTipo.DataTextField = "NOMBRE";
            //    ddlTipo.DataValueField = "ID";
            //    ddlTipo.DataBind();

            //    marcaNegocio negocioMarca = new marcaNegocio();
            //    ddlMarca.DataSource = negocioMarca.listar();
            //    ddlMarca.DataTextField = "NOMBRE";
            //    ddlMarca.DataValueField = "ID";
            //    ddlMarca.DataBind();
            }
            

            

        }


        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            
            Marca nuevo = new Marca();
            nuevo.Nombre = txtNombre.Text;
            marcaNegocio negocioMarca = new marcaNegocio();
            negocioMarca.agregar(nuevo);
            Response.Redirect("Default.aspx", false);



        }
    }
}