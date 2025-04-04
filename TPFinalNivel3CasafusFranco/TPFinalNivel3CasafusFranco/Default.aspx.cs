using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPFinalNivel3CasafusFranco
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> listaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                listaArticulos = negocio.Listar("");
                Session["listaArticulos"] = listaArticulos;

                txtBuscar.Attributes.Add("placeholder", "Buscar por nombre, marca o categoría...");

                ResetearClasesBotones();
            }
            else
            {
                AplicarFiltros();
            }

        }
        protected void txtBuscar_TextChanged1(object sender, EventArgs e)
        {
            AplicarFiltros();

        }
        private string CategoriaSeleccionada
        {
            get => ViewState["CategoriaSeleccionada"]?.ToString();
            set => ViewState["CategoriaSeleccionada"] = value;
        }

        protected void btnCateogoria_Command(object sender, CommandEventArgs e)
        {
            string categoriaClickeada = e.CommandName;

            if (CategoriaSeleccionada == categoriaClickeada)
            {   //Si se selecciona la misma categoria que antes
                CategoriaSeleccionada = null;
                ResetearClasesBotones();
            }
            else
            {   //Si se selecciona una categoria diferente que antes
                CategoriaSeleccionada = categoriaClickeada;
                ResetearClasesBotones();
                ((Button)sender).CssClass = "btn btn-primary";
            }

            AplicarFiltros();
        }
        private void ResetearClasesBotones()
        {
            btnCelulares.CssClass = "btn btn-outline-primary";
            btnMedia.CssClass = "btn btn-outline-primary";
            btnTelevisores.CssClass = "btn btn-outline-primary";
            btnAudio.CssClass = "btn btn-outline-primary";
        }
        private void AplicarFiltros()
        {
            List<Articulo> todos = (List<Articulo>)Session["listaArticulos"];
            string filtroTexto = txtBuscar.Text.ToLower();
            string categoria = CategoriaSeleccionada;

            List<Articulo> filtrados = todos.FindAll(x =>
            (string.IsNullOrEmpty(categoria) || x.Categoria_Articulo.Descripcion == categoria) &&
            (string.IsNullOrEmpty(filtroTexto) ||
             x.Nombre.ToLower().Contains(filtroTexto) ||
             x.Categoria_Articulo.Descripcion.ToLower().Contains(filtroTexto) ||
             x.Marca_Articulo.Descripcion.ToLower().Contains(filtroTexto))
             );

            listaArticulos = filtrados;
        }


    }
}