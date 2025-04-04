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
                hyperLinkLogin.Visible = false;                
                if (string.IsNullOrEmpty(((User)Session["usuario"]).Imagen))
                    ProfileImage.Visible = false;   
                else
                    ProfileImage.ImageUrl = ((User)Session["usuario"]).Imagen;
            }
            else
            {
                btnSesion.Visible = false;
                hyperLinkRegistrar.Visible = true;
                hlFavoritos.Visible = false;
                hlPerfil.Visible = false;
                hyperLinkLogin.Visible = true;
                ProfileImage.Visible = false;
            }

            if (Seguridad.isAdmin(Session["usuario"]))            
                hlGestion.Visible = true;            
            else            
                hlGestion.Visible = false;

            if(!(Page is Default || Page is Error || Page is Login || Page is RegisterUser || Page is DetalleProducto || Page is MisFavoritos || Page is MiPerfil))
            {
                if (!(Seguridad.isAdmin(Session["usuario"]))){

                    Response.Redirect("Default.aspx", false);
                }
            }
            

        }

        protected void btnSesion_Click(object sender, EventArgs e)
        {
			Session.Remove("usuario");
            Response.Redirect("Default.aspx", false);
        }
    }
}