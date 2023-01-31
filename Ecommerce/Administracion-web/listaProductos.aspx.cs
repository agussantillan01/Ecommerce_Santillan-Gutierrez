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

        public bool confirmaEliminacion { get; set; }
        public List<Producto> ListaProductos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            // productoNegocio negocioProducto = new productoNegocio();
            // dgvListadoProductos.DataSource = negocioProducto.listar();
            // dgvListadoProductos.DataBind();
            confirmaEliminacion = false;
            productoNegocio productoNegocio = new productoNegocio();
            ListaProductos = productoNegocio.listar();
        }

  

        protected void dgvListadoProductos_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idSeleccionado = int.Parse(Request.QueryString["Id"].ToString());
            Session.Add("idProductoEliminar", idSeleccionado);///ACA TENGO EL ERROR
            confirmaEliminacion = true;

        }

     


        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmarEliminacion.Checked)
                {
                    productoNegocio negocioProducto = new productoNegocio();
         
                 
                   
                      int idSeleccionado = int.Parse(Session["idProductoEliminar"].ToString());


                        ColoresXproductoNegocio negocio = new ColoresXproductoNegocio();
                    List<ColoresXproducto> lista = negocio.listarL();

                    foreach (var item in lista)
                    {


                        if (item.Producto.Id == idSeleccionado)
                        {
                            if (item.Stock == 0)
                            {
                                negocioProducto.eliminarConSP(idSeleccionado);
                                Response.Redirect("listaProductos.aspx");

                                break;
                            }
                            else
                            {
                                Session.Add("Error", "No se ha podido eliminar el producto, ya que aún cuenta con stock");
                                Response.Redirect("Error.aspx", false);

                                break;
                            }

                        }

                    }

                }
            }
            catch (Exception)
            {

                //Session.Add("Error", "No se ha podido actualizar los prodcuto");
                //Response.Redirect("Error.aspx", false);
            }
        }



    }
}