<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="agregarProducto.aspx.cs" Inherits="Administracion_web.modificaProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <h2 style="font-family: Arial; color: grey;">Agregue un producto</h2>
        <hr />
        <div class="col-4">
            <div class="mb-3">
                <asp:Label Text="Nombre" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Descripcion" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Tipo" CssClass="form-label" runat="server" />
                <asp:DropDownList ID="ddlTipo" CssClass="form-select" runat="server"></asp:DropDownList>

            </div>
            <div class="mb-3">
                <asp:Label Text="Marca" CssClass="form-label" runat="server" />
                <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Label Text="Precio" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Button CssClass="btn btn-primary" ID="btnSiguiente" OnClick="btnSiguiente_Click" Text="Siguiente" runat="server" />
               <%--CUANDO APRETO EL BOTON, TENGO QUE DAR DE ALTA LA TABLA PRODUCTO PARA PODER CREAR UN ID PRODUCTO--%>
            </div>
        </div>
        <div class="col-2"></div>
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Imagen URL" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtImagenURL" CssClass="form-control" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
