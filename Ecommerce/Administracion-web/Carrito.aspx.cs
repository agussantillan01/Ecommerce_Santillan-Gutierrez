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
    public partial class Carrito : System.Web.UI.Page
    {
        public carritoCompra carrito = new carritoCompra();
        public List<itemCarrito> ListaEnCarrito;

        decimal totalAux;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int.Parse(Request.QueryString["Id"])) > 0 && (int.Parse(Request.QueryString["IdColor"])) > 0)
            {
                ListaEnCarrito = (List<itemCarrito>)Session["listaEnCarro"];
                carrito = (carritoCompra)Session["total"];

                if (ListaEnCarrito == null)
                    ListaEnCarrito = new List<itemCarrito>();
                if (carrito == null)
                    carrito = new carritoCompra();

                if (!IsPostBack)
                {
                    if (Request.QueryString["Id"] != null && Request.QueryString["IdColor"] != null)
                    {
                        if (ListaEnCarrito.Find(x => x.item.Id.ToString() == Request.QueryString["Id"] && x.color.Id.ToString() == Request.QueryString["IdColor"]) == null)
                        {
                            List<Producto> listadoOriginal = (List<Producto>)Session["listadoProductos"];

                            colorNegocio colorNegocio = new colorNegocio();
                            List<Color> colorListaTotal = colorNegocio.listarTodos();

                            itemCarrito aux = new itemCarrito();

                            if (aux.cantidad == 0)
                            {
                                aux.cantidad = 1;
                            }
                            aux.item = listadoOriginal.Find(x => x.Id.ToString() == Request.QueryString["Id"]);
                            aux.color = colorListaTotal.Find(x => x.Id.ToString() == Request.QueryString["IdColor"]);
                            aux.subtotal = aux.cantidad * aux.item.Precio;
                            aux.id = aux.item.Id;

                            carrito.total += aux.item.Precio;

                            lblPrecioTotal.Text = "Total: " + carrito.total.ToString();

                            ListaEnCarrito.Add(aux);


                        }

                        carrito.listado = ListaEnCarrito;


                    }
                    repetidor.DataSource = ListaEnCarrito;
                    repetidor.DataBind();

                }

                lblPrecioTotal.Text = "$ Total: " + carrito.total.ToString();
                Session.Add("listaEnCarro", ListaEnCarrito);
                Session.Add("total", carrito);

            }
            else
            {
                Response.Redirect("quienesSomos.aspx", false);
            }
            
        }

        protected void btnInc_Click(object sender, EventArgs e)
        {

        }

        protected void btnDec_Click(object sender, EventArgs e)
        {

        }
    }
}