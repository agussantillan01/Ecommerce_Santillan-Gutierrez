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
    
    public partial class modificaProducto : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                tipoNegocio negocioTipo = new tipoNegocio();
                ddlTipo.DataSource = negocioTipo.listar();
                ddlTipo.DataTextField = "NOMBRE";
                ddlTipo.DataValueField = "ID";
                ddlTipo.DataBind();

                marcaNegocio negocioMarca = new marcaNegocio();
                ddlMarca.DataSource = negocioMarca.listar();
                ddlMarca.DataTextField = "NOMBRE";
                ddlMarca.DataValueField = "ID";
                ddlMarca.DataBind();
            }
            

            

        }



        protected void dgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgvColores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            
            Producto nuevo = new Producto();
            nuevo.Nombre = txtNombre.Text; 
            nuevo.Descripcion = txtDescripcion.Text;
            nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
            nuevo.Tipo = new Tipo();
                nuevo.Tipo.Id = int.Parse(ddlTipo.SelectedValue);
            nuevo.Imagen = txtImagenURL.Text;
            nuevo.Precio = decimal.Parse(txtPrecio.Text);
            productoNegocio negocioProducto = new productoNegocio();
            negocioProducto.agregar(nuevo);



        }
    }
}