<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="detalleProducto.aspx.cs" Inherits="Administracion_web.detalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <style>
        .custom-card {
            width: 500px;
            height: 500px;
        }
    </style>--%>


    <div style="padding: 100px;">
        <img style="display: inline-block; width: 421px; margin-left: 50px;" src="<%=  prod.Imagen %>" class="img-fluid rounded-start" alt="...">

        <div style="display: inline-block; padding-left: 74px;">
            <h5 class="card-title"><%= prod.Nombre %></h5>
            <p class="card-text" style="font-weight: bold;"><%= prod.Marca.Nombre %></p>
            <p class="card-text"><%= prod.Descripcion %></p>
            <p class="card-text"><small class="text-muted">$ <%= prod.Precio%></small></p>
            <asp:DropDownList ID="ddlColores" CssClass="form-select" runat="server"></asp:DropDownList>
        </div>
    </div>



</asp:Content>
