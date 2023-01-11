using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administracion_web
{
    public partial class listaMarcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            marcaNegocio negocio = new marcaNegocio();
            dgvListaMarcas.DataSource = negocio.listar();
            dgvListaMarcas.DataBind();
        }

        protected void dgvListaMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idSeleccionado = dgvListaMarcas.SelectedDataKey.Value.ToString();
            Response.Redirect("agregarMarca.aspx?Id=" + idSeleccionado, false);
        }

        protected void dgvListaMarcas_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int index = Convert.ToInt32(e.CommandArgument);
            string value = dgvListaMarcas.DataKeys[index]["Id"].ToString(); // Esto captura el ID de la marca seleccionada en ELIMINAR
            


        }
    }
}