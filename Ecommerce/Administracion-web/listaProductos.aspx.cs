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
    public partial class listaProductos : System.Web.UI.Page
    {
        public List<Producto> ListaProductos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            // productoNegocio negocioProducto = new productoNegocio();
            // dgvListadoProductos.DataSource = negocioProducto.listar();
            // dgvListadoProductos.DataBind();

            productoNegocio productoNegocio = new productoNegocio();
            ListaProductos = productoNegocio.listar();
        }

  

        protected void dgvListadoProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }
    }
}