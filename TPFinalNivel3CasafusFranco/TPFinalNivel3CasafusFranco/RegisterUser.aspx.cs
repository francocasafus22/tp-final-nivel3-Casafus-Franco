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
    public partial class RegisterUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;

            UsuarioNegocio negocio = new UsuarioNegocio();
            User usuario = new User();

            try
            {
                if (Validacion.textoVacio(txtPass) || Validacion.textoVacio(txtMail))
                {
                    throw new Exception("Debe completar todos los campos");
                }
                usuario.mail = txtMail.Text;
                usuario.password = txtPass.Text;
                negocio.Registrarse(usuario);

                if (negocio.Login(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    throw new Exception("Error al iniciar sesión. Vuelva a intentarlo.");
                }

                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("Error.aspx", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}