<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TPFinalNivel3CasafusFranco.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #mynavbar {
            position: fixed !important;
            width: 100%;
        }

        @media (max-width: 768px) {
            .content-wrapper {
                padding-top: 60px; /* Mayor espacio en móviles si el navbar es más alto */
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


    <div class="content-wrapper">

        <div class="row justify-content-center align-items-center min-vh-100">

            <div class="col-md-4 text-center">
                <asp:UpdatePanel runat="server" ID="updImagen" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Image ImageUrl="https://static.vecteezy.com/system/resources/previews/004/511/281/original/default-avatar-photo-placeholder-profile-picture-vector.jpg"
                            runat="server" CssClass="rounded-circle"
                            AlternateText="Foto de Perfil" Width="250"
                            ID="ImagenPerfil" onerror="this.onerror=null;this.src='https://placehold.co/600?text=IMAGEN+NO+DISPONIBLE&font=roboto';" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtImagen" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>

            <div class="col-md-8">
                <div>

                    <div class="row g-3">
                        <div class="col-md-6">
                            <label for="id" class="form-label">ID</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtID" ReadOnly="true" />
                        </div>
                        <div class="col-md-6">
                            <label for="nombre" class="form-label">Nombre</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" />
                        </div>
                        <div class="col-md-6">
                            <label for="apellido" class="form-label">Apellido</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido" />
                        </div>
                        <div class="col-md-6">
                            <label for="email" class="form-label">Correo Electrónico</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" TextMode="Email" />
                            <asp:RequiredFieldValidator ErrorMessage="Mail requerido" ControlToValidate="txtEmail" runat="server" CssClass="validacion" Display="Dynamic" />
                        </div>
                        <div class="col-md-12">
                            <label for="urlImagenPerfil" class="form-label">URL de Imagen de Perfil</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtImagen" OnTextChanged="txtImagen_TextChanged" AutoPostBack="true" />
                        </div>
                    </div>
                </div>

                <div class="text-center ">
                    <asp:Button Text="Guardar Cambios" runat="server" CssClass="btn btn-primary mt-3" ID="btnGuardar" OnClick="btnGuardar_Click" />
                </div>

            </div>

        </div>
    </div>

</asp:Content>
