using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace Administracion_web
{
    public partial class listaCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tipoNegocio negocio = new tipoNegocio();
            dgvlistaCategoria.DataSource = negocio.listar();
            dgvlistaCategoria.DataBind();
        }

        protected void dgvlistaCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}