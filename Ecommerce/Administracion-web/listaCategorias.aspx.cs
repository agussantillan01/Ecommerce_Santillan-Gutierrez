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
            string id = dgvlistaCategoria.SelectedDataKey.Value.ToString();
            Response.Redirect("agregarTipo.aspx?Id="+id, false);

        }

        protected void dgvlistaCategoria_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            string value = dgvlistaCategoria.DataKeys[index]["Id"].ToString(); // Esto captura el ID de la categoria seleccionada en ELIMINAR
        }
    }
}