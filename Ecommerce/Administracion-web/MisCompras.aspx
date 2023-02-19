<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MisCompras.aspx.cs" Inherits="Administracion_web.MisCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%if ((dominio.Usuario)Session["Usuario"] == null)
        {
            Session.Add("Error", "Recuerde loguearte!");
            Response.Redirect("ErrorLogin.aspx", false);
        }
        else
        {%>
    <h2 style="font-family: Arial;">Registro de compras</h2>


    <%if (tu == dominio.TipoUsuario.ADMIN)
        {%>
    <asp:GridView ID="dgvComprasTotal" runat="server" Style="width: 100%;" DataKeyNames="Id" AutoGenerateColumns="false" CssClass="table table-ligth table-striped"
        OnClass="table" OnSelectedIndexChanged="dgvComprasTotal_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="#Numero de Compra" DataField="Id" />
            <asp:BoundField HeaderText="Nombre" DataField="usuario.Nombre" />
            <asp:BoundField HeaderText="Apellido" DataField="usuario.Apellido" />
            <asp:BoundField HeaderText="Email" DataField="usuario.Email" />
            <asp:BoundField HeaderText="Fecha" DataField="FechaCompra" />
            <asp:BoundField HeaderText="$" DataField="total" />
            <asp:CommandField HeaderText="Detalle" ShowSelectButton="true" SelectText="Ver más" />
        </Columns>
    </asp:GridView>
    <%}
        else
        { %>
    <h3 style="color: grey; text-align: center;">Ultimos productos Comprados</h3>
    <p style="color: grey; text-align: center;">Recuerde que si su producto se encuentra en esta lista, aún puede realizar la devolución</p>
    <asp:GridView ID="dgvComprasXusuario" runat="server" Style="width: 100%;" DataKeyNames="Id" AutoGenerateColumns="false" CssClass="table table-ligth table-striped"
        OnClass="table" OnSelectedIndexChanged="dgvComprasXusuario_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="#Numero de Compra" DataField="Id" />
            <asp:BoundField HeaderText="Fecha" DataField="FechaCompra" />
            <asp:BoundField HeaderText="$" DataField="total" />
            <asp:CommandField HeaderText="Detalle" ShowSelectButton="true" SelectText="Ver más" />
        </Columns>
    </asp:GridView>
    <% } %>

    <% }%>
</asp:Content>
