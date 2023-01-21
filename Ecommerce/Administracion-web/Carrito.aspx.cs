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
    public partial class Carrito : System.Web.UI.Page
    {
        public carritoCompra carrito = new carritoCompra();
        public List<itemCarrito> ListaEnCarrito;

        decimal totalAux;
        protected void Page_Load(object sender, EventArgs e)
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


        protected void btnInc_Click(object sender, EventArgs e)
        {
            carrito = (carritoCompra)Session["Total"];
            totalAux = 0;
            string[] argument = ((Button)sender).CommandArgument.Split(',');
            List<itemCarrito> ListaEnCarrito = (List<itemCarrito>)Session["listaEnCarro"];
            itemCarrito sobrecarga = ListaEnCarrito.Find(x => x.id.ToString() == argument[0].ToString() && x.color.Id.ToString() == argument[1].ToString());


            sobrecarga.cantidad++;
            sobrecarga.subtotal = sobrecarga.item.Precio * sobrecarga.cantidad;

            foreach (itemCarrito item in ListaEnCarrito)
            {

                if (item.id.ToString() == argument[0] && item.color.Id.ToString() == argument[1])
                {
                    item.id = sobrecarga.id;
                    item.item = sobrecarga.item;
                    item.color = sobrecarga.color;
                    item.cantidad = sobrecarga.cantidad;
                    item.subtotal = sobrecarga.subtotal;
                    

                }

                totalAux += item.subtotal;

            }

            carrito.total = totalAux;

            lblPrecioTotal.Text = "Total: " + carrito.total.ToString();

            Session.Add("listaEnCarro", ListaEnCarrito);
            Session.Add("Total", carrito);
            repetidor.DataSource = null;
            repetidor.DataSource = ListaEnCarrito;
            repetidor.DataBind();

            Response.Redirect("Carrito.aspx");
        }

        protected void btnDec_Click(object sender, EventArgs e)
        {
            carrito = (carritoCompra)Session["Total"];

            totalAux = 0;


            string[] argument = ((Button)sender).CommandArgument.Split(',');
            List<itemCarrito> ListaEnCarrito = (List<itemCarrito>)Session["listaEnCarro"];
            itemCarrito sobrecarga = ListaEnCarrito.Find(x => x.id.ToString() == argument[0] && x.color.Id.ToString() == argument[1]);
            if (sobrecarga.cantidad > 1)
            {
                sobrecarga.cantidad--;
                sobrecarga.subtotal = sobrecarga.item.Precio * sobrecarga.cantidad;
                foreach (itemCarrito item in ListaEnCarrito)
                {
                    if (item.id.ToString() == argument[0] && item.color.Id.ToString() == argument[1])
                    {
                        item.id = sobrecarga.id;
                        item.item = sobrecarga.item;
                        item.color = sobrecarga.color;
                        item.cantidad = sobrecarga.cantidad;
                        item.subtotal = sobrecarga.subtotal;
                        


                    }

                    totalAux += item.subtotal;
                }
               


                carrito.total = totalAux;

                lblPrecioTotal.Text = "Total: " + carrito.total.ToString();


                Session.Add("listaEnCarro", ListaEnCarrito);
                Session.Add("Total", carrito);
                repetidor.DataSource = null;
                repetidor.DataSource = ListaEnCarrito;
                repetidor.DataBind();

                Response.Redirect("Carrito.aspx");

            }
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            CompraNegocio negocioCompra = new CompraNegocio(); 
            negocioCompra.registroCompra (carrito);

            List<carritoCompra> listaTotal = negocioCompra.listar();
            int ultimoIndice= listaTotal.Count();
            carritoCompra ultimo = listaTotal[ultimoIndice - 1];

            foreach (var item in carrito.listado)
            {
                negocioCompra.agregarDetalleXventa(item, ultimo.Id);

            }

            Response.Redirect("Default.aspx", false);


            limpraLista();

        }
        private void limpraLista() {
            carrito = null; 
            ListaEnCarrito = null;

            Session.Add("listaEnCarrito", ListaEnCarrito);
            Session.Add("carrito", carrito);
            Session.Add("listaEnCarro", null);
            Session.Add("total", null);



        }

        
    }
}