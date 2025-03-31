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
			if (Request.QueryString["id"] != null)
			{
				int id = int.Parse(Request.QueryString["id"]);
				Articulo = ((List<Articulo>)Session["listaArticulos"]).Find(x => x.Id == id);
            }

        }

        protected void btnFavorito_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
			try
			{
				negocio.AgregarArticuloFavorito(Articulo.Id, ((User)Session["usuario"]).id);
            }
			catch (Exception ex)
			{

				Session.Add("error", ex.Message);
				Response.Redirect("Error.aspx", false);
            }
        }
    }
}