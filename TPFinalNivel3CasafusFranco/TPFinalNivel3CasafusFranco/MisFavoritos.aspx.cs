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
	public partial class MisFavoritos : System.Web.UI.Page
	{
        public List<Articulo> listaFavoritos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
		{
			if(!IsPostBack)
            {
                if (Seguridad.SesionIniciada(Session["usuario"]))
                {
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    try
                    {
                        listaFavoritos = negocio.GetListaFavoritos(((User)Session["usuario"]).id);
                        Session.Add("listaFavoritos", listaFavoritos);
                    }
                    catch (Exception ex)
                    {
                        Session.Add("error", ex.Message);
                        Response.Redirect("Error.aspx", false);
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx", false);
                }
            }
        }

        protected void txtBuscar_TextChanged1(object sender, EventArgs e)
        {
            listaFavoritos = ((List<Articulo>)Session["listaFavoritos"]).FindAll(x => x.Nombre.ToLower().Contains(txtBuscar.Text.ToLower()));
        }
    }
}