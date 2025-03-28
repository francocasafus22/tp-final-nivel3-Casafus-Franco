using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace TPFinalNivel3CasafusFranco
{
	public partial class Login : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
							
            

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            User user;
            UsuarioNegocio negocio = new UsuarioNegocio();

            try
            {
                user = new User();

                if (Validacion.textoVacio(txtPass) || Validacion.textoVacio(txtMail))
                {
                    throw new Exception("Debe completar todos los campos");
                }

                user.mail = txtMail.Text;
                user.password = txtPass.Text;

                if (negocio.Login(user))
                {
                    Session.Add("usuario", user);
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    throw new Exception("Usuario o contraseña incorrectos");

                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }

        }
    }
}