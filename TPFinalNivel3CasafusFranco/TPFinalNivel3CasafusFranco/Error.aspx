<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TPFinalNivel3CasafusFranco.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Error</h1>
    <asp:Label Text="text" runat="server" ID="lblError"/>
    <div>
        <a href="Default.aspx" class="btn btn-primary">Volver</a>
    </div>
</asp:Content>
