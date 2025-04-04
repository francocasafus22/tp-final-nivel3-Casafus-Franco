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
	public partial class AgregarProducto : System.Web.UI.Page
	{
		Articulo Articulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                ddlCategoria.DataSource = categoriaNegocio.Listar();
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataBind();


                MarcaNegocio marcaNegocio = new MarcaNegocio();
                ddlMarca.DataSource = marcaNegocio.Listar();
                ddlMarca.DataTextField = "Descripcion";
                ddlMarca.DataValueField = "Id";
                ddlMarca.DataBind();

                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Articulo = negocio.Listar("").Find(x => x.Id == id);
                    txtId.Text = Articulo.Id.ToString();
                    txtCodigo.Text = Articulo.Codigo;
                    txtNombre.Text = Articulo.Nombre;
                    txtDescripcion.Text = Articulo.Descripcion;
                    txtImagen.Text = Articulo.Imagen;
                    txtPrecio.Text = Articulo.Precio.ToString();
                    ddlCategoria.SelectedValue = Articulo.Categoria_Articulo.Id.ToString();
                    ddlMarca.SelectedValue = Articulo.Marca_Articulo.Id.ToString();
                    Img_Articulo.ImageUrl = Articulo.Imagen;

                }
            }

            
        }

        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {
            if (txtImagen.Text != "")
                Img_Articulo.ImageUrl = txtImagen.Text;        
            else
                Img_Articulo.ImageUrl = "https://placehold.co/800?text=IMAGEN+NO+DISPONIBLE&font=roboto";
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionProductos.aspx", false);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return; 

            try
            {
                
                if (Validacion.textoVacio(txtCodigo) || Validacion.textoVacio(txtNombre) || Validacion.textoVacio(txtDescripcion) || Validacion.textoVacio(txtImagen) || Validacion.textoVacio(txtPrecio))
                {
                    throw new Exception("Debes completar todos los campos.");
                }

                ArticuloNegocio negocio = new ArticuloNegocio();
                Articulo newArticulo = new Articulo();

                newArticulo.Codigo = txtCodigo.Text;
                newArticulo.Nombre = txtNombre.Text;
                newArticulo.Descripcion = txtDescripcion.Text;
                newArticulo.Imagen = txtImagen.Text;
                newArticulo.Precio = decimal.Parse(txtPrecio.Text);
                newArticulo.Categoria_Articulo = new Categoria();
                newArticulo.Categoria_Articulo.Id = int.Parse(ddlCategoria.SelectedValue);
                newArticulo.Marca_Articulo = new Marca();
                newArticulo.Marca_Articulo.Id = int.Parse(ddlMarca.SelectedValue);

                if (txtId.Text != "")
                {
                    newArticulo.Id = int.Parse(txtId.Text);
                    negocio.Modificar(newArticulo);
                }
                else
                {
                    negocio.Agregar(newArticulo);
                }

                Response.Redirect("GestionProductos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}