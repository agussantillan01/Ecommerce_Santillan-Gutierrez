<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="misComprasDetalle.aspx.cs" Inherits="Administracion_web.misComprasDetalle_" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%if(tu == dominio.TipoUsuario.NORMAL)
      {%>
            <asp:GridView ID="dgvDetalleCompra" runat="server" Style="width: 100%;" AutoGenerateColumns="false" CssClass="table table-ligth table-striped"
        OnClass="table">
        <Columns>
            <asp:BoundField HeaderText="#Producto" DataField="item.Nombre" />
            <asp:BoundField HeaderText="Color" DataField="Color.Nombre" />
            <asp:BoundField HeaderText="Cantidad" DataField="cantidad" />
            <asp:BoundField HeaderText="Precio" DataField="subtotal" />
        </Columns>
    </asp:GridView>

      <%} %>
</asp:Content>
