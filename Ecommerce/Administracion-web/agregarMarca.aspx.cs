﻿using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administracion_web
{
    
    public partial class modificaMarca : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.QueryString["Id"] != null && !IsPostBack)
            {
                marcaNegocio negocioMarca = new marcaNegocio();
                int idSeleccionado = int.Parse(Request.QueryString["Id"]);
                Marca marca = (negocioMarca.listar()).Find(x => x.Id == idSeleccionado);
                txtNombre.Text = marca.Nombre;
            }
            

            

        }


        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            
            Marca nuevo = new Marca();
            nuevo.Nombre = txtNombre.Text;
            marcaNegocio negocioMarca = new marcaNegocio();
            if (Request.QueryString["Id"]== null)
            {
                negocioMarca.agregar(nuevo);
                Response.Redirect("listaMarcas.aspx", false);
            }else
            {
                int id = int.Parse(Request.QueryString["Id"]);
                negocioMarca.ModificarSP(id, nuevo);
                Response.Redirect("listaMarcas.aspx", false);
            }




        }
    }
}