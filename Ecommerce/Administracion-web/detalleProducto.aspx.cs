using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;
namespace Administracion_web
{
    public partial class detalleProducto : System.Web.UI.Page
    {
        public Producto prod = new Producto();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    productoNegocio productoNegocio = new productoNegocio();
                    List<Producto> list = new List<Producto>();
                    list = productoNegocio.listar();
                    int idSeleccionado = int.Parse(Request.QueryString["Id"]);

                    prod = list.Find(x => x.Id == idSeleccionado);

                    colorNegocio negocioColor = new colorNegocio();
                    List<Color> listColor = negocioColor.listarSP(idSeleccionado);

                    ddlColores.DataSource = listColor;
                    ddlColores.DataValueField = "Id";
                    ddlColores.DataTextField = "Nombre";
                    ddlColores.DataBind();

                }
            }

            catch (Exception)
            {

                Response.Redirect("quienesSomos.aspx", false);
            }
            
        }
    }
}