﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="TPFinalNivel3CasafusFranco.DetalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #mynavbar {
            position: fixed !important;
            width: 100%;
        }

        @media (max-width: 768px) {
            .content-wrapper {
                padding-top: 90px; /* Mayor espacio en móviles si el navbar es más alto */
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <%if (Articulo != null)
            { %>

        <div class="row justify-content-center align-items-center min-vh-100">

            <div class="col-md-6 mb-4 d-flex justify-content-center align-items-center">
                <div class="justify-content-center align-items-center d-flex " style="width: 400px; height: 400px; overflow: hidden">
                    <img src="<%: Articulo.Imagen %>" alt="Product"
                        class="object-fit-contain w-100 h-100"
                        id="mainImage"
                        onerror="this.onerror=null;this.src='https://placehold.co/400?text=IMAGEN+NO+DISPONIBLE&font=roboto';">
                </div>
            </div>


            <div class="col-md-6">
                <h2 class="mb-3"><%: Articulo.Nombre %></h2>
                <p class="text-muted mb-4">Código: <%: Articulo.Codigo %></p>
                <div class="mb-3">
                    <span class="h4 me-2">$<%: Articulo.Precio %></span>
                    <span class="text-muted"><s>$<%: Articulo.Precio + Articulo.Precio/10%></s></span>
                </div>
                <p class="text-muted">155 vendidos</p>
                <p class="mb-4"><%: Articulo.Descripcion %></p>
                <div class="mb-4">
                    <h5>Categoria: <%: Articulo.Categoria_Articulo %></h5>
                </div>
                <div class="mb-4">
                    <h5>Marca: <%: Articulo.Marca_Articulo %></h5>
                </div>
                <div class="mb-4">
                    <label for="cantidad" class="form-label">Cantidad:</label>
                    <input type="number" class="form-control" id="cantidad" value="1" min="1" style="width: 80px;">
                </div>
                <asp:Button Text="Agregar a Favoritos" runat="server" CssClass="btn btn-primary btn-lg mb-3 me-2" ID="btnFavorito" OnClick="btnFavorito_Click" />
                <asp:Button Text="Volver" runat="server" CssClass="btn btn-outline-secondary btn-lg mb-3" ID="btnVolver" OnClick="btnVolver_Click" />
            </div>
        </div>

        <%}
            else
            { %>
        <h1>No hay un articulo seleccionado.</h1>
        <a href="Default.aspx" class="btn btn-primary">Volver</a>
        <%} %>
    </div>
</asp:Content>
