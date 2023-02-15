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
    public partial class MisCompras : System.Web.UI.Page
    {
        public  TipoUsuario tu;
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = Session["usuario"] != null ? (Usuario)Session["usuario"] : null;
            if (usuario == null)
            {
                Session.Add("Error", "Debes loguearte!");
                Response.Redirect("ErrorLogin.aspx", false);
            }
            else
            {
                tu = usuario.TipoUsuario;
                if (tu == TipoUsuario.ADMIN)
                {
                    CompraNegocio negocio = new CompraNegocio();
                    dgvComprasTotal.DataSource = negocio.listar();
                    dgvComprasTotal.DataBind();
                } else
                {
                    CompraNegocio negocio = new CompraNegocio();
                    dgvComprasXusuario.DataSource = negocio.listar(usuario.Id.ToString());
                    dgvComprasXusuario.DataBind();

                }

            }

            //asca


        }


    }
}

