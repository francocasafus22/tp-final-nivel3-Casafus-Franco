<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="TPFinalNivel3CasafusFranco.AgregarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <h1 class="text-center mb-4 display-5">Agregar Articulo</h1>

    <div class="row g-3">
        <div class="col-md-2">
            <label for="txtId" class="form-label">ID</label>
            <asp:TextBox ID="txtId" runat="server" CssClass="form-control" ReadOnly="true" TextMode="Number"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <label for="txtCodigo" class="form-label">Codigo</label>            
            <asp:TextBox ID="txtCodigo" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ErrorMessage="Codigo requerido" ControlToValidate="txtCodigo" runat="server" CssClass="validacion" />
        </div>
        <div class="col-md-6">
            <label for="txtNombre" class="form-label">Nombre</label>
            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ErrorMessage="Nombre requerido" ControlToValidate="txtNombre" runat="server" CssClass="validacion"/>
           
        </div>
        <div class="col-md-2">
            <label for="txtPrecio" class="form-label">Precio</label>
            <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator ErrorMessage="Precio requerido" ControlToValidate="txtPrecio" runat="server" CssClass="validacion"/>
            <asp:RangeValidator ErrorMessage="Precio fuera de rango (1 - 1 Millón)" ControlToValidate="txtPrecio" runat="server" Type="Currency" MinimumValue="1" MaximumValue="1000000" CssClass="validacion    "/>            
        </div>
        <div class="col-md-6 mt-0">
            <label for="txtDescripcion" class="form-label">Descripcion</label>
            <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server" MaxLength="150"></asp:TextBox>
            <asp:RequiredFieldValidator ErrorMessage="Descripcion requerida" ControlToValidate="txtDescripcion" runat="server" CssClass="validacion" />
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
                    <asp:TextBox ID="txtImagen" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtImagen_TextChanged" MaxLength="1000"></asp:TextBox>
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

    <asp:Button Text="Guardar" runat="server" CssClass="btn btn-primary " ID="btnGuardar" OnClick="btnGuardar_Click"/>
    <asp:Button Text="Volver" runat="server" CssClass="btn btn-outline-primary" ID="btnVolver" OnClick="btnVolver_Click"/>

</asp:Content>
