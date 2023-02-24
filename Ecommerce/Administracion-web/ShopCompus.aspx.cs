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
    public partial class ShopCompus : System.Web.UI.Page
    {
        public List<Producto> ListaProductos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (txtSearch1.Text == "")

            {
                productoNegocio productoNegocio = new productoNegocio();
            ListaProductos = productoNegocio.listarCompus();
            Session.Add("listadoProductos", ListaProductos);
            }
            else
            {

                productoNegocio productoNegocio = new productoNegocio();
                ListaProductos = productoNegocio.listarConFiltroCompus(txtSearch1.Text.ToString());
                Session.Add("listadoProductos", ListaProductos);
            }
       
         }

        protected void btnMenorAMayor_Click1(object sender, EventArgs e)
        {
            //1 
            productoNegocio productoNegocio = new productoNegocio();
            ListaProductos = productoNegocio.listarXFiltroCompus(1);

        }

        protected void btnMayorAMenor_Click1(object sender, EventArgs e)
        {
            //2
            productoNegocio productoNegocio = new productoNegocio();
            ListaProductos = productoNegocio.listarXFiltroCompus(2);
        }

        protected void btnAZ_Click1(object sender, EventArgs e)
        {
            //3
            productoNegocio productoNegocio = new productoNegocio();
            ListaProductos = productoNegocio.listarXFiltroCompus(3);
        }

        protected void btnZA_Click1(object sender, EventArgs e)
        {
            //4
            productoNegocio productoNegocio = new productoNegocio();
            ListaProductos = productoNegocio.listarXFiltroCompus(4);

        }
        protected void btnSSD_Click(object sender, EventArgs e)
        {
            //4
            productoNegocio productoNegocio = new productoNegocio();
            ListaProductos = productoNegocio.listarXFiltroCompus(5);

        }
        protected void btnHDD_Click(object sender, EventArgs e)
        {
            //4
            productoNegocio productoNegocio = new productoNegocio();
            ListaProductos = productoNegocio.listarXFiltroCompus(6);

        }
    }
}