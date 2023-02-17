<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ShopTodos.aspx.cs" Inherits="Administracion_web.ShopTodos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="row">
        <div class="col-4">
            <asp:Panel runat="server" CssClass="input-group">
                <asp:TextBox ID="txtSearch" MaxLength="20" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="Buscar" />
            </asp:Panel>
        </div>
        <div class="col-6"></div>
        <div class="col-2">
            <div class="input-group input-group-sm mb-1" style="padding-bottom: 10px;">
                <asp:DropDownList ID="ddlFiltros" CssClass="form-control" runat="server">
                    <asp:ListItem Text="filtrar" Value="" Enabled="false"></asp:ListItem>
                    <asp:ListItem Text="Precio de Menor a Mayor" />
                    <asp:ListItem Text="Precio de Mayor a Menor" />
                    <asp:ListItem Text="A-Z" />
                    <asp:ListItem Text="Z-A" />
                </asp:DropDownList>
            </div>
        </div>
        <br />
        <br />
    </div>



    <div class="row row-cols-1 row-cols-md-3 g-4">

        <% foreach (dominio.Producto item in ListaProductos)
            {%>
        <div class="col">
            <div class="card h-100" style="width: 18rem;">
                <img src="<% = item.Imagen1 %>" class="card-img-top img-fluid" alt="..." onerror="this.src='https://assets.cdn-shop.com/mi-arte3-es/assets/img/backgrounds/placeholder-8b83e412a5.svg';">
                <div class="card-body card-heigth-xs">
                    <h5 class="card-title"><% = item.Marca.Nombre %></h5>
                    <h5 class="card-title"><% = item.Nombre %></h5>
                    <p style="color: grey;" class="card-text"><%= item.Precio %></p>
                    <a href="detalleProducto.aspx?id=<% = item.Id %>" class="btn btn-primary">
                        <span>Ver detalle
                                <img style="width: 20px;" src="../img/visibility.png" alt="Alternate Text" /></span>
                    </a>


                </div>
            </div>
        </div>


        <%} %>
        <br />
        <br />
    </div>
    </div>


    <div class="row" style="padding-top: 100px;">
        <div class="col-1"></div>
        <div class="col-2" style="text-align: center;">
            <span>
                <img style="width: 80px;" src="../img/iconEnvio.png" alt="Alternate Text" />
            </span>
            <div>
                <h5 style="color: grey;">ENVIAMOS TU COMPRA</h5>
                <p style="color: grey;">Entregas a todo el país</p>
            </div>
        </div>
        <div class="col-2"></div>
        <div class="col-2" style="text-align: center;">
            <span>
                <img style="width: 80px;" src="../img/iconCreditCard.png" alt="Alternate Text" />
            </span>
            <div>
                <h5 style="color: grey;">PAGO SENCILLO</h5>
                <p style="color: grey;">Pagás y lo llevás</p>
            </div>
        </div>
        <div class="col-2"></div>
        <div class="col-2" style="text-align: center;">
            <span>
                <img style="width: 80px;" src="../img/iconSecurity.png" alt="Alternate Text" />
            </span>
            <div>
                <h5 style="color: grey;">COMPRÁ CON SEGURIDAD</h5>
                <p style="color: grey;">Tus datos siempre protegidos</p>
            </div>
        </div>
        <div class="col-4"></div>
    </div>



</asp:Content>
