<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="agregarProducto.aspx.cs" Inherits="Administracion_web.modificaProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">

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
                <asp:DropDownList ID="ddlTipo" runat="server"></asp:DropDownList>

            </div>
            <div class="mb-3">
                <asp:Label Text="Marca" CssClass="form-label" runat="server" />
                <asp:DropDownList ID="ddlMarca" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Label Text="Precio" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:GridView ID="dgvColores" runat="server"  DataKeyNames="Id" AutoGenerateColumns="false" CssClass="table table-ligth table-striped"
                    OnClass="table" OnSelectedIndexChanged="dgvColores_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="Color" DataField="Nombre" />
                        

                    </Columns>

                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
