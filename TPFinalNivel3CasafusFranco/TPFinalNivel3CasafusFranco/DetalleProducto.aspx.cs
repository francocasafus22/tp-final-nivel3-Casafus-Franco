using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3CasafusFranco
{
    public partial class DetalleProducto : System.Web.UI.Page
    {
        public Articulo Articulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    Articulo = ((List<Articulo>)Session["listaArticulos"]).Find(x => x.Id == id);
                    Session.Add("articulo", Articulo);
                }

                if (Session["usuario"] != null)
                {
                    btnFavorito.Visible = true;
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    List<Articulo> listFavoritos = negocio.GetListaFavoritos(((User)Session["usuario"]).id);

                    if (listFavoritos.Exists(x => x.Id == ((Articulo)Session["articulo"]).Id))
                        btnFavorito.Text = "Quitar de Favoritos";
                    else
                        btnFavorito.Text = "Agregar a Favoritos";

                }
                else
                {
                    btnFavorito.Visible = false;
                }
            }

            Articulo = ((Articulo)Session["articulo"]);

        }

        protected void btnFavorito_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                if (btnFavorito.Text == "Agregar a Favoritos")
                {
                    negocio.AgregarArticuloFavorito(((Articulo)Session["articulo"]).Id, ((User)Session["usuario"]).id);
                    btnFavorito.Text = "Quitar de Favoritos";
                }
                else
                {
                    negocio.EliminarFavorito(((Articulo)Session["articulo"]).Id, ((User)Session["usuario"]).id);
                    btnFavorito.Text = "Agregar a Favoritos";
                }
                    

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }
    }
}