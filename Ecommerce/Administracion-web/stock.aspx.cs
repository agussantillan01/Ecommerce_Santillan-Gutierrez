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
    public partial class stock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {



            }
            catch (Exception)
            {

                Session.Add("Error", "recuerde seleccionar un producto/color");
            }

        }

        protected void btnAplicar_Click(object sender, EventArgs e)
        {
            int idProducto = int.Parse(Session["IdProductoAgregado"].ToString());
            productoNegocio prNegocio = new productoNegocio();
            List<Producto> listaProducto = prNegocio.listar();
            Producto pr = listaProducto.Find(x => x.Id == idProducto);
            int idColorParametro = int.Parse(Request.QueryString["Id"].ToString());
            colorNegocio colorNegocio = new colorNegocio();
            List<Color> listColor = colorNegocio.listarTodos();
            Color color = listColor.Find(x => x.Id == idColorParametro);

            int cantStock = int.Parse(txtStock.Text);
            
            colorNegocio negColor = new colorNegocio();
            negColor.agregarSP(pr, color, cantStock);
            Response.Redirect("agregarColores.aspx", false);
        }

        protected void btnSumarStock_Click(object sender, EventArgs e)
        {
            int cantStock = int.Parse(txtStock.Text);
            if (cantStock >= 0)
            {
                cantStock++;
                txtStock.Text = cantStock.ToString();

            }

        }

        protected void btnRestarStock_Click(object sender, EventArgs e)
        {
            int cantStock = int.Parse(txtStock.Text);
            if (cantStock > 0)
            {
                cantStock--;
                txtStock.Text = cantStock.ToString();

            }
        }
    }
}