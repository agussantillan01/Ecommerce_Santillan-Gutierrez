<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="detalleProducto.aspx.cs" Inherits="Administracion_web.detalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding: 10px;">
        <img style="display: inline-block; width: 421px; margin-left: 50px;" src="<%=  prod.Imagen %>" class="img-fluid rounded-start" alt="...">
        
        <div style="display: inline-block; padding-left: 74px;">
            <h5 style="padding-top:30px;" class="card-title"><%= prod.Nombre %></h5>
            <p class="card-text" style="font-weight: bold;"><%= prod.Marca.Nombre %></p>
            <p class="card-text"><%= prod.Descripcion %></p>
            <p class="card-text"><small class="text-muted">$ <%= prod.Precio%></small></p>
            <asp:DropDownList ID="ddlColores" CssClass="form-select" runat="server"></asp:DropDownList>
            <hr />
            <a href="Carrito.aspx?id=<% = prod.Id %>">
                <button class="btn btn-outline-secondary" type="button" style="text-align: center">
                    <img style="width:20px;" src="../img/iconCarrito.png" alt="Alternate Text" />
                    <p class="card-text"><small class="text-muted"><% = prod.Precio.ToString()%></small></p>
                </button>
            </a>
        </div>
    </div>



</asp:Content>
