<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="TPFinalNivel3CasafusFranco.DetalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%if (Articulo != null)
        { %>

    <div class="row">

        <div class="col-md-6 mb-4" style="display: flex; justify-content: center; align-items: center; height: 100%;">
            <img src="<%: Articulo.Imagen %>" alt="Product" class="img-fluid rounded mb-3 product-image" id="mainImage" onerror="this.onerror=null;this.src='https://placehold.co/500?text=IMAGEN+NO+DISPONIBLE&font=roboto';">
        </div>


        <div class="col-md-6">
            <h2 class="mb-3"><%: Articulo.Nombre %></h2>
            <p class="text-muted mb-4">Código: <%: Articulo.Codigo %></p>
            <div class="mb-3">
                <span class="h4 me-2">$<%: Articulo.Precio %></span>
                <span class="text-muted"><s>$<%: Articulo.Precio + Articulo.Precio/10%></s></span>
            </div>
            <div class="mb-3">
                <i class="bi bi-star-fill text-warning"></i>
                <i class="bi bi-star-fill text-warning"></i>
                <i class="bi bi-star-fill text-warning"></i>
                <i class="bi bi-star-fill text-warning"></i>
                <i class="bi bi-star-half text-warning"></i>
                <span class="ms-2">4.5 (120 reviews)</span>
            </div>
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
            <button class="btn btn-primary btn-lg mb-3 me-2">
                <i class="bi bi-cart-plus"></i>Agregar a Favoritos
            </button>
            <button class="btn btn-outline-secondary btn-lg mb-3">
                <i class="bi bi-heart"></i>Cancelar
            </button>
        </div>
    </div>

    <%}
        else
        { %>
    <h1>No hay un articulo seleccionado.</h1>
    <a href="Default.aspx" class="btn btn-primary">Volver</a>
    <%} %>
</asp:Content>
