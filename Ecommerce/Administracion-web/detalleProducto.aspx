﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="detalleProducto.aspx.cs" Inherits="Administracion_web.detalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div class="row">
        <div class="col-6">
            <div id="carouselExample" class="carousel slide">
                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <img style="display: inline-block; width: 421px; margin-left: 50px;" src="<%=  prod.Imagen1 %>" class="img-fluid rounded-start" onerror="this.src='https://assets.cdn-shop.com/mi-arte3-es/assets/img/backgrounds/placeholder-8b83e412a5.svg';" alt="...">
                    </div>
                    <div class="carousel-item">
                        <img style="display: inline-block; width: 421px; margin-left: 50px;" src="<%=  prod.Imagen2 %>" onerror="this.src='https://assets.cdn-shop.com/mi-arte3-es/assets/img/backgrounds/placeholder-8b83e412a5.svg';" class="img-fluid rounded-start" alt="...">
                    </div>
                    <div class="carousel-item">
                        <img style="display: inline-block; width: 421px; margin-left: 50px;" src="<%=  prod.Imagen3 %>" onerror="this.src='https://assets.cdn-shop.com/mi-arte3-es/assets/img/backgrounds/placeholder-8b83e412a5.svg';" class="img-fluid rounded-start" alt="...">
                    </div>
                    <div class="carousel-item">
                        <img style="display: inline-block; width: 421px; margin-left: 50px;" src="<%=  prod.Imagen4 %>" onerror="this.src='https://assets.cdn-shop.com/mi-arte3-es/assets/img/backgrounds/placeholder-8b83e412a5.svg';" class="img-fluid rounded-start" alt="...">
                    </div>
                </div>
                <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Previous</span>
                </button>
                <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Next</span>
                </button>
            </div>
        </div>
        <div class="col-2"></div>
        <div class="col-4">
            <div style="display: inline-block; padding-left: 74px;">
                <h4 style="padding-top: 30px;" class="card-title"><%= prod.Nombre %></h4>
                <h6 class="card-text" style="font-weight: bold;"><%= prod.Marca.Nombre%></h6>
                <p class="card-text" style="font-weight: bold;"><%= prod.Tipo.Nombre%></p>
                <%if (prod.Tipo.Nombre == "Notebook" || prod.Tipo.Nombre == "PC")
                    {%>

                <p style="color: black;" class="card-text">DISCO:          <%= prod.TipoDisco %></p>
                <p style="color: black;" class="card-text">PROCESADOR:     <%= prod.Procesador %></p>
                <p style="color: black;" class="card-text">SIST. OPERATIVO:<%= prod.SistemaOperativo%></p>
                <p style="color: black;" class="card-text">PLACA VIDEO:    <%= prod.PlacaVideo%></p>
                <% } %>
                <p style="color: black;" class="card-text">MEMORIA INTERNA:<%= prod.MemoriaInterna%> GB</p>
                <p style="color: black;" class="card-text">MEMORIA RAM:   <%= prod.MemoriaRam%> GB</p>
                <p class="card-text"><small class="text-muted">$ <%= prod.Precio%></small></p>
                <%if (prod.Descripcion != "")
                    {%>
                <p style="color: black; background: #EAECEE;" class="card-text">DESCRIPCION:   <%= prod.Descripcion%></p>
                <%} %>
                <asp:DropDownList ID="ddlColores" OnDataBound="ddlColores_DataBound" OnSelectedIndexChanged="ddlColores_SelectedIndexChanged" AutoPostBack="true" CssClass="form-select" runat="server"></asp:DropDownList>
                <hr />
                <br />
                <asp:Label Style="color: green;" Text="" ID="lblStockDisponible" runat="server" />
                <br />

                <%if (idColor != 0)
                    {%>
                <a href="Carrito.aspx?id=<% = prod.Id %>&IdColor=<% = colorSeleccionado.Id%>">
                    <button class="btn btn-outline-secondary" type="button" style="text-align: center">
                        <img style="width: 20px;" src="../img/iconCarrito.png" alt="Alternate Text" />
                        <p class="card-text"><small class="text-muted"><% = prod.Precio.ToString()%></small></p>
                    </button>
                </a>
                <% }
                    else
                    { %>

                <button class="btn btn-outline-secondary" type="button" style="text-align: center">
                    <img style="width: 20px;" src="../img/iconCarrito.png" alt="Alternate Text" />
                    <p class="card-text"><small class="text-muted"><% = prod.Precio.ToString()%></small></p>
                </button>

                <% }%>
            </div>




        </div>
    </div>

    </div>






















</asp:Content>
