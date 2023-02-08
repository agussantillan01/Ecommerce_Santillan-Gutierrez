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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public int cant;

        public string Logeado;
        protected void Page_Load(object sender, EventArgs e)
        {
        

            if (Session["cantidadProductosCarrito"] == null)
            {
                cant = 0;
            }
             else
            {
                cant = (int)Session["cantidadProductosCarrito"];
            }

    



        Usuario usuario = Session["usuario"] != null ? (Usuario)Session["usuario"] : null;

            if (usuario == null)
            {
                Logeado = "Login";
            }
            else
            {
               Logeado = "Logeado"; // CAMBIAR AL NOMBRE DEL CLIENTE DSP
  //             Logeado = (string)Session["NombreUsuario"];

            }
         }
    }
}