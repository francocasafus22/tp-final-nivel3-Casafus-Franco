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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (Seguridad.SesionIniciada(Session["usuario"]))
                {
                    txtID.Text = ((User)Session["usuario"]).id.ToString();
                    txtEmail.Text = ((User)Session["usuario"]).mail;
                   

                    if (((User)Session["usuario"]).nombre == null)
                        txtNombre.Attributes.Add("placeholder", "Ingresa tu nombre");
                    else
                        txtNombre.Text = ((User)Session["usuario"]).nombre;

                    if (((User)Session["usuario"]).apellido == null)
                        txtApellido.Attributes.Add("placeholder", "Ingresa tu apellido");
                    else
                        txtApellido.Text = ((User)Session["usuario"]).apellido;

                    if (string.IsNullOrEmpty(((User)Session["usuario"]).Imagen))
                        txtImagen.Attributes.Add("placeholder", "Ingresa la URL de tu imagen de perfil");
                    else
                    {
                        txtImagen.Text = ((User)Session["usuario"]).Imagen;
                        ImagenPerfil.ImageUrl = txtImagen.Text;
                    }
                                            
                }
                else
                {
                    Response.Redirect("Default.aspx", false);
                }
            }
            
        }

        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {
            if (txtImagen.Text != "")
                ImagenPerfil.ImageUrl = txtImagen.Text;
            else
                ImagenPerfil.ImageUrl = "https://static.vecteezy.com/system/resources/previews/004/511/281/original/default-avatar-photo-placeholder-profile-picture-vector.jpg";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;

            UsuarioNegocio negocio = new UsuarioNegocio();
            User usuario = ((User)Session["usuario"]);            
            usuario.mail = txtEmail.Text;
            usuario.nombre = txtNombre.Text;
            usuario.apellido = txtApellido.Text;
            usuario.Imagen = txtImagen.Text;                       
            negocio.Actualizar(usuario);            
            Session.Add("usuario", usuario);
            Response.Redirect("Default.aspx", false);
        }
    }
}