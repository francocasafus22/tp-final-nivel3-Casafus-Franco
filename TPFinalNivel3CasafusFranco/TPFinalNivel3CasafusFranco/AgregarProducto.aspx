<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="TPFinalNivel3CasafusFranco.AgregarProducto" %>

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

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="content-wrapper">

        <div class="row justify-content-center align-items-center min-vh-100">
            <div class="col-md-4 text-center d-flex justify-content-center align-items-center mb-3">
                <div style="width: 400px; height: 400px; overflow: hidden;">
                    <asp:Image
                        ID="Img_Articulo"
                        runat="server"
                        CssClass="object-fit-contain w-100 h-100"
                        ImageUrl="https://placehold.co/800?text=IMAGEN+NO+DISPONIBLE&font=roboto"
                        onerror="this.onerror=null;this.src='https://placehold.co/600?text=IMAGEN+NO+DISPONIBLE&font=roboto';" />
                </div>
            </div>
            <div class="col-md-8">
                <div>



                    <div class="row g-3">
                        <div class="col-md-2">
                            <label for="txtId" class="form-label">ID</label>
                            <asp:TextBox ID="txtId" runat="server" CssClass="form-control" ReadOnly="true" TextMode="Number"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <label for="txtCodigo" class="form-label">Codigo</label>
                            <asp:TextBox ID="txtCodigo" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Codigo requerido" ControlToValidate="txtCodigo" runat="server" CssClass="validacion" Display="Dynamic" />
                        </div>

                        <div class="col-md-3">
                            <label for="ddlMarca" class="form-label">Marca</label>
                            <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select"></asp:DropDownList>
                        </div>
                        <div class="col-md-3">
                            <label for="ddlCategoria" class="form-label">Categoria</label>
                            <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select"></asp:DropDownList>
                        </div>

                        <div class="col-md-2">
                            <label for="txtPrecio" class="form-label">Precio</label>
                            <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Precio requerido" ControlToValidate="txtPrecio" runat="server" CssClass="validacion" Display="Dynamic" />
                            <asp:RangeValidator ErrorMessage="Fuera de rango (1 - 1M)" ControlToValidate="txtPrecio" runat="server" Type="Currency" MinimumValue="1" MaximumValue="1000000" CssClass="validacion" Display="Dynamic" />
                        </div>
                        <div class="col-md-12">
                            <label for="txtNombre" class="form-label">Nombre</label>
                            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Nombre requerido" ControlToValidate="txtNombre" runat="server" CssClass="validacion" Display="Dynamic" />

                        </div>
                        <div class="col-md-12">
                            <label for="txtDescripcion" class="form-label">Descripcion</label>
                            <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server" MaxLength="150"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Descripcion requerida" ControlToValidate="txtDescripcion" runat="server" CssClass="validacion" Display="Dynamic" />
                        </div>

                        <div class="col-md-12 mb-3">
                            <label for="txtImagen" class="form-label">Url Imagen:</label>
                            <asp:TextBox ID="txtImagen" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtImagen_TextChanged" MaxLength="1000"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Imagen requerida" ControlToValidate="txtImagen" CssClass="validacion" Display="Dynamic" runat="server" />
                        </div>
                    </div>

                </div>
                <div class="text-center mt-3">
                    <asp:Button Text="Guardar" runat="server" CssClass="btn btn-primary " ID="btnGuardar" OnClick="btnGuardar_Click" />
                    <asp:Button Text="Volver" runat="server" CssClass="btn btn-outline-primary" ID="btnVolver" OnClick="btnVolver_Click" />
                </div>
            </div>


        </div>
    </div>

</asp:Content>
