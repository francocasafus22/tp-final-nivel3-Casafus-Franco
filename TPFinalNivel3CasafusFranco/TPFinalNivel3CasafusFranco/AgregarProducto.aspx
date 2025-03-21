<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="TPFinalNivel3CasafusFranco.AgregarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <h1 class="text-center mb-4 display-5">Agregar Articulo</h1>

    <div class="row g-3">
        <div class="col-md-2">
            <label for="txtId" class="form-label">ID</label>
            <input type="number" class="form-control" id="txtId" readonly="readonly">
        </div>
        <div class="col-md-2">
            <label for="txtCodigo" class="form-label">Codigo</label>
            <input type="text" class="form-control" id="txtCodigo">
        </div>
        <div class="col-md-6">
            <label for="txtNombre" class="form-label">Nombre</label>
            <input type="text" class="form-control" id="txtNombre">
        </div>
        <div class="col-md-2">
            <label for="txtPrecio" class="form-label">Precio</label>
            <input type="number" class="form-control" id="txtPrecio">
        </div>
        <div class="col-md-6">
            <label for="txtDescripcion" class="form-label">Descripcion</label>
            <input type="text" class="form-control" id="txtDescripcion">
        </div>
        <div class="col-md-3">
            <label for="ddlMarca" class="form-label">Marca</label>
            <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select"></asp:DropDownList>

        </div>
        <div class="col-md-3">
            <label for="ddlCategoria" class="form-label">Categoria</label>
            <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select"></asp:DropDownList>
        </div>


        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="col-md-12 mb-3">
                    <label for="txtImagen" class="form-label">Url Imagen:</label>
                    <asp:TextBox ID="txtImagen" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtImagen_TextChanged"></asp:TextBox>
                </div>

                <div class="col-md-12 d-flex justify-content-center mb-3">
                    <div style="max-width: 400px; width: 100%; overflow: hidden; border-radius: 12px; box-shadow: 0 0 5px rgba(0,0,0,0.1);">
                        <asp:Image
                            ID="Img_Articulo"
                            runat="server"
                            CssClass="img-fluid w-100"
                            ImageUrl="https://placehold.co/800?text=IMAGEN+NO+DISPONIBLE&font=roboto" />
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>

    <asp:Button Text="Guardar" runat="server" CssClass="btn btn-primary " />
    <asp:Button Text="Volver" runat="server" CssClass="btn btn-outline-primary" />

</asp:Content>
