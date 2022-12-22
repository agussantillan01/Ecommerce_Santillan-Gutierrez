<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ShopTodos.aspx.cs" Inherits="Administracion_web.ShopTodos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <% foreach (dominio.Producto item in ListaProductos)
            {%>
        <div class="col">
            <div class="card">
                <img src="<% = item.Imagen %>" class="card-img-top" alt="..." onerror="this.src='https://assets.cdn-shop.com/mi-arte3-es/assets/img/backgrounds/placeholder-8b83e412a5.svg';">
                <div class="card-body">
                    <h5 class="card-title"><% = item.Nombre %></h5>
                    <p style="color: grey;" class="card-text"><%= item.Descripcion %></p>
                    <a href="detalleProducto.aspx?id=<% = item.Id %>" class="btn btn-primary">Ver Detalle</a>
                    
                </div>
            </div>
        </div>


        <%} %>
    </div>

</asp:Content>
