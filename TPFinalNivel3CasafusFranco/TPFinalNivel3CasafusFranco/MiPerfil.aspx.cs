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
                    esAdmin.Checked = ((User)Session["usuario"]).TipoUsuario;

                    if (((User)Session["usuario"]).nombre == null)
                        txtNombre.Attributes.Add("placeholder", "Ingresa tu nombre");
                    else
                        txtNombre.Text = ((User)Session["usuario"]).nombre;

                    if (((User)Session["usuario"]).apellido == null)
                        txtApellido.Attributes.Add("placeholder", "Ingresa tu apellido");
                    else
                        txtApellido.Text = ((User)Session["usuario"]).apellido;

                    if (((User)Session["usuario"]).Imagen == null)
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
            ImagenPerfil.ImageUrl = txtImagen.Text;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            User usuario = new User();            
            usuario.mail = txtEmail.Text;
            usuario.nombre = txtNombre.Text;
            usuario.apellido = txtApellido.Text;
            usuario.Imagen = txtImagen.Text;
            usuario.id = int.Parse(txtID.Text);
            negocio.Actualizar(usuario);
            Session.Add("usuario", usuario);
        }
    }
}