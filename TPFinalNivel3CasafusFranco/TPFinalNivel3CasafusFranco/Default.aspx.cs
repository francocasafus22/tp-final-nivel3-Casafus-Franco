using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPFinalNivel3CasafusFranco
{
	public partial class Default : System.Web.UI.Page
	{
        public List<Articulo> listaArticulos { get; set; }      
        protected void Page_Load(object sender, EventArgs e)
		{         
                ArticuloNegocio negocio = new ArticuloNegocio();
                listaArticulos = negocio.Listar("");
                Session.Add("listaArticulos", listaArticulos);
                
                txtBuscar.Attributes.Add("placeholder", "Buscar por nombre, marca o categoria...");

        }
        protected void txtBuscar_TextChanged1(object sender, EventArgs e)
        {
            listaArticulos = ((List<Articulo>)Session["listaArticulos"]).FindAll(x => x.Nombre.ToLower().Contains(txtBuscar.Text.ToLower()) || 
            x.Categoria_Articulo.Descripcion.ToLower().Contains(txtBuscar.Text.ToLower()) ||
            x.Marca_Articulo.Descripcion.ToLower().Contains(txtBuscar.Text.ToLower()));
        }

        protected void btnFavorito_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}