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

        }
    }
}