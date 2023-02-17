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
    public partial class ShopTodos : System.Web.UI.Page
    {
        public List<Producto> ListaProductos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            productoNegocio productoNegocio = new productoNegocio();
            ListaProductos = productoNegocio.listar();
            Session.Add("listadoProductos", ListaProductos);

            if (!IsPostBack)
            {
                ddlFiltros.AppendDataBoundItems = true;
                ddlFiltros.Items.Insert(0, new ListItem("Filtrar", ""));
            }
        }
    }
}