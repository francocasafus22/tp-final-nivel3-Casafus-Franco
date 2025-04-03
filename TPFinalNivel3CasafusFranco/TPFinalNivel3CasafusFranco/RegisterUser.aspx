<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="TPFinalNivel3CasafusFranco.RegisterUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #mynavbar {
            position: fixed !important;
            width: 100%;
            z-index: 10;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row justify-content-center align-items-center vh-100">
        <div class="col-md-5">
            <div class="card p-4">
                <div class="text-center">
                    <h1 class="display-6">Registrarse</h1>
                </div>
                <div class="mb-1">
                    <label for="txtUser" class="form-label">Email</label>
                    <div class="input-group">
                        <span class="input-group-text"><i class="bi bi-person"></i></span>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtMail" TextMode="Email" />
                    </div>
                    <asp:RequiredFieldValidator ErrorMessage="Email Requerido" ControlToValidate="txtMail" runat="server" CssClass="validacion" />
                </div>
                <div class="mb-3">
                    <label for="txtPass" class="form-label">Contraseña</label>
                    <div class="input-group">
                        <span class="input-group-text"><i class="bi bi-lock"></i></span>
                        <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="txtPass" />
                    </div>
                    <asp:RequiredFieldValidator ErrorMessage="Contraseña requerida" ControlToValidate="txtPass" runat="server" CssClass="validacion" />
                </div>
                <div class="d-grid">
                    <asp:Button Text="Crear Cuenta" runat="server" CssClass="btn btn-primary" ID="btnRegistrarse" OnClick="btnRegistrarse_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
