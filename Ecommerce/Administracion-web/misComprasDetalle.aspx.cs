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
    public partial class misComprasDetalle_ : System.Web.UI.Page
    {
        public TipoUsuario tu;
        protected void Page_Load(object sender, EventArgs e)
        {

            Usuario usuario = Session["usuario"] != null ? (Usuario)Session["usuario"] : null;
            if (usuario == null)
            {
                Session.Add("Error", "Debes loguearte");
                Response.Redirect("ErrorLogin.aspx", false);
            }
            else if (Request.QueryString["IdCompraDetalle"] == null)
            {
                Session.Add("Error", "Recuerde seleccionar un producto");
                Response.Redirect("ErrorLogin.aspx", false);
            }
            else
            {
                tu = usuario.TipoUsuario;
                if (tu == TipoUsuario.NORMAL)
                {
                    string idVenta = Request.QueryString["IdCompraDetalle"].ToString();
                    CompraNegocio negocio = new CompraNegocio();
                    dgvDetalleCompra.DataSource = negocio.listarXVenta(idVenta);
                    dgvDetalleCompra.DataBind();
                }

            }

        }
    }
}