<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="listaProductos.aspx.cs" Inherits="Administracion_web.listaProductos" %>

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
        <%--        <div>
            <asp:GridView runat="server" ID="dgvListadoProductos" Style="width: 80%;" OnClass="table" DataKeyNames="Id" AutoGenerateColumns="false" CssClass="table table-ligth table-striped" OnSelectedIndexChanged="dgvListadoProductos_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="Producto" DataField="Nombre"/>
                    <asp:BoundField HeaderText="Marca" DataField="Marca.Nombre"/>
                    <asp:BoundField HeaderText="Categoria" DataField="Tipo.Nombre"/>
                    <asp:BoundField HeaderText="Precio" DataField="Precio"/>
                </Columns>
            </asp:GridView>
            <a type="submit" class="btn btn-primary" href="agregarProducto.aspx">Agregar</a>
        </div>--%>

        <div>
            <a type="submit" class="btn btn-primary" href="agregarProducto.aspx">Agregar</a>
            <% foreach (dominio.Producto item in ListaProductos)
                {%>
            <div class="card mb-3" style="max-width: 540px;">
                <div class="row g-0">
                    <div class="col-md-4">
                        <img src="<% = item.Imagen %>" class="img-fluid rounded-start" onerror="this.src='https://assets.cdn-shop.com/mi-arte3-es/assets/img/backgrounds/placeholder-8b83e412a5.svg';" alt="...">
                    </div>
                    <div class="col-md-8">
                        <div class="card-body">
                            <h5 class="card-title"><% = item.Nombre %></h5>
                            <p style="color: grey;" class="card-text"><%= item.Descripcion %></p>
                            <a href="agregarProducto.aspx?id=<% = item.Id %>" class="btn btn-primary">Modificar</a>
                            <asp:Button CssClass="btn btn-danger" Text="eliminar" runat="server" />
                        </div>
                    </div>
                </div>
            </div>


            <%} %>s
        </div>
    </div>
</asp:Content>
