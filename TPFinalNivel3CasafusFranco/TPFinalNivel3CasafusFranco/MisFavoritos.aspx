<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MisFavoritos.aspx.cs" Inherits="TPFinalNivel3CasafusFranco.MisFavoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        
        body {
            background-color: #f0f0f5;
        }

        .card {
            border: none;
            border-radius: 12px;
            transition: transform 0.3s, box-shadow 0.3s;
        }

            .card:hover {
                transform: translateY(-5px);
                box-shadow: 0 4px 15px rgba(0, 0, 0, 0.1);
            }

        .btn-primary {
            background-color: #4f46e5;
            border: none;
            transition: background-color 0.3s;
        }

            .btn-primary:hover {
                background-color: #4338ca;
            }

        .card-img-top {
            height: 200px;
            width: 600px;
            object-fit: contain;
            background-color: white;
        }

        @media (max-width: 764px) {
            .row-cols-1 > .col {
                flex: 0 0 50%;
                max-width: 50%;
            }

            .buscar {
                width: 100% !important;
            }
        }

        .buscar {
            width: 50%;
        }
    
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager runat="server" />

    <h1 class="text-center mb-3 display-6 text-primary fw-bold">Mis Favoritos</h1>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="col-12 d-flex justify-content-center">
                <div class="input-group mb-3 buscar">
                    <asp:TextBox runat="server" AutoPostBack="true" CssClass="form-control" ID="txtBuscar" OnTextChanged="txtBuscar_TextChanged1"/>
                    <button class="btn btn-primary" type="submit">Buscar</button>
                </div>
            </div>

            <div class="row row-cols-1 row-cols-md-4 row-cols-sm-2 g-4">
                <% if (listaFavoritos != null)
                    {
                        foreach (dominio.Articulo item in listaFavoritos)
                        {%>
                <div class="col">
                    <div class="card h-100 text-center">
                        <%--<img src="<%: item.Imagen %>" class="card-img-top img-fluid" alt="https://as1.ftcdn.net/v2/jpg/06/86/19/34/1000_F_686193407_DHZwjeydBOR1tEDkLAzwM3w5kYstRzzB.jpg">--%>
                        <img src="<%: item.Imagen %>" class="card-img-top img-fluid" alt="..." onerror="this.onerror=null;this.src='https://placehold.co/600?text=IMAGEN+NO+DISPONIBLE&font=roboto';">

                        <div class="card-body">
                            <h5 class="card-title"><%: item.Nombre %></h5>
                            <h5 class="card-text  fw-bold">$<%: item.Precio %></h5>
                            <a href="DetalleProducto.aspx?id=<%: item.Id %>" class="btn btn-primary mt-3">Ver Detalles</a>

                        </div>
                    </div>
                </div>
                <%}
                    }
                    else
                    {  %> 
            </div>
            <h1 class="text-center mt-4 display-6 ">No hay articulos favoritos</h1> <%} %>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
