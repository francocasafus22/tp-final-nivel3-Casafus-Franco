using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3CasafusFranco
{
	public partial class MasterPage : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Seguridad.SesionIniciada(Session["usuario"]))
            {
                btnSesion.Visible = true;
                hyperLinkRegistrar.Visible = false;
                hlFavoritos.Visible = true;
                hlPerfil.Visible = true;
            }
            else
            {
                btnSesion.Visible = false;
                hyperLinkRegistrar.Visible = true;
                hlFavoritos.Visible = false;
                hlPerfil.Visible = false;
            }

            if (Seguridad.isAdmin(Session["usuario"]))            
                hlGestion.Visible = true;            
            else            
                hlGestion.Visible = false;
            

        }

        protected void btnSesion_Click(object sender, EventArgs e)
        {
			Session.Remove("usuario");
            Response.Redirect("Default.aspx", false);
        }
    }
}