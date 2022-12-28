<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="listaMarcas.aspx.cs" Inherits="Administracion_web.listaMarcas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row">
        <hr />
        <div style="text-align: center;">
            <a type="submit" class="btn btn-light" href="listaProductos.aspx">Productos</a>
            <a type="submit" class="btn btn-light" href="listaMarcas.aspx">Marcas</a>
            <a type="submit" class="btn btn-light" href="listaCategorias.aspx">Categorias</a>
        </div>
        <hr />
        <div>
            <asp:GridView runat="server" ID="dgvListaMarcas" Style="width: 50%;" OnClass="table" DataKeyNames="Id" AutoGenerateColumns="false" CssClass="table table-ligth table-striped" OnSelectedIndexChanged="dgvListaMarcas_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="Marca" DataField="Nombre"/>
                </Columns>
            </asp:GridView>
            <a type="submit" class="btn btn-primary" href="agregarMarca.aspx">Agregar</a>
        </div>


    </div>
</asp:Content>
