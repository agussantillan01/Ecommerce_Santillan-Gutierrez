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

        }
    }
}