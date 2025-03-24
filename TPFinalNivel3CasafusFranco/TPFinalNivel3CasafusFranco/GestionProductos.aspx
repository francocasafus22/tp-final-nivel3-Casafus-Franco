<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GestionProductos.aspx.cs" Inherits="TPFinalNivel3CasafusFranco.GestionProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .search-bar {
            max-width: 500px;
            margin: auto auto;
        }

        .search-bar .input-group {
            border-radius: 30px;
            overflow: hidden;
            box-shadow: 0 2px 6px rgba(0, 0, 0, 0.1);
        }

        .search-bar .form-control {
            border: none;
            padding-left: 20px;
        }

        .search-bar .btn {
            border: none;
            padding: 10px 20px;
        }

        table {
            width: 100%;
            border-collapse: collapse;
        }

        .table-wrapper {
            overflow-x: auto;
        }
    </style>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="search-bar mb-3">
        <div class="input-group">
            <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" OnTextChanged="txtBuscar_TextChanged" AutoPostBack="true"></asp:TextBox>
            <button class="btn btn-primary" type="button" id="search-addon">
                <i class="fas fa-search"></i>
            </button>
        </div>
    </div>

    <div class="table-wrapper">
        <asp:GridView ID="dgvArticulos" runat="server" CssClass="table" AutoGenerateColumns="false" DataKeyNames="Id" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
            AllowPaging="true" PageSize="10" OnPageIndexChanging="dgvArticulos_PageIndexChanging" OnRowDeleting="dgvArticulos_RowDeleting">

            <Columns>
                <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Categoria_Articulo.Descripcion" HeaderText="Categoria" />
                <asp:BoundField DataField="Marca_Articulo.Descripcion" HeaderText="Marca" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEditar" runat="server" Text="✏️ Editar" CommandName="Select" CssClass="btn btn-primary btn-sm" />
                        <asp:LinkButton ID="lnkEliminar" runat="server" Text="🗑️ Eliminar" CommandName="Delete" CssClass="btn btn-danger btn-sm" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
    </div>

    <a href="AgregarProducto.aspx" class="btn btn-primary">Agregar</a>

</asp:Content>
