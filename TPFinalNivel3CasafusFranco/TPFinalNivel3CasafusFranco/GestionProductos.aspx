<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GestionProductos.aspx.cs" Inherits="TPFinalNivel3CasafusFranco.GestionProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="dgvArticulos" runat="server" CssClass="table" AutoGenerateColumns="false" DataKeyNames="Id" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
         AllowPaging="true" PageSize="10"  OnPageIndexChanging="dgvArticulos_PageIndexChanging" OnRowDeleting="dgvArticulos_RowDeleting" >

        <Columns>     
            <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />            
            <asp:BoundField DataField="Categoria_Articulo.Descripcion" HeaderText="Categoria" />
            <asp:BoundField DataField="Marca_Articulo.Descripcion" HeaderText="Marca" />
            <asp:BoundField DataField="Precio" HeaderText="Precio" />
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEditar" runat="server" Text="✏️ Editar" CommandName="Select" CssClass="btn btn-primary btn-sm"/>
                    <asp:LinkButton ID="lnkEliminar" runat="server" Text="🗑️ Eliminar" CommandName="Delete" CssClass="btn btn-danger btn-sm"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>

     <a href="AgregarProducto.aspx" class="btn btn-primary">Agregar</a>

</asp:Content>
