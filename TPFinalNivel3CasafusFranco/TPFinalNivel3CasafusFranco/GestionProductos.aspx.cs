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
	public partial class GestionProductos : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Session.Add("listaArticulos", negocio.Listar(""));
                dgvArticulos.DataSource = Session["listaArticulos"];
                dgvArticulos.DataBind();
                txtBuscar.Attributes.Add("placeholder", "Buscar por nombre, marca o categoria...");
            }
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)dgvArticulos.SelectedDataKey.Value;
            Response.Redirect("AgregarProducto.aspx?id=" + id, false);
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataSource = Session["listaArticulos"];
            dgvArticulos.DataBind();
        }

        protected void dgvArticulos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            int id = (int)dgvArticulos.DataKeys[e.RowIndex].Value;
            negocio.Eliminar(id);
            Session["listaArticulos"] = negocio.Listar("");
            dgvArticulos.DataSource = Session["listaArticulos"];
            dgvArticulos.DataBind();
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada = ((List<Articulo>)Session["listaArticulos"]).FindAll(x => x.Nombre.ToLower().Contains(txtBuscar.Text.ToLower()) ||
                  x.Categoria_Articulo.Descripcion.ToLower().Contains(txtBuscar.Text.ToLower()) ||
                  x.Marca_Articulo.Descripcion.ToLower().Contains(txtBuscar.Text.ToLower()));            
            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.DataBind();
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCampo.SelectedIndex == 0)
            {
                ddlCriterio.Items.Clear();
                ddlCriterio.Items.Add("Menor a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Igual a");
            }
            else
            {
                ddlCriterio.Items.Clear();
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
                ddlCriterio.Items.Add("Contiene");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                dgvArticulos.DataSource = negocio.busquedaFiltrada(txtFiltro.Text, ddlCampo.SelectedItem.ToString(), ddlCriterio.SelectedItem.ToString());
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void cbAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbAvanzado.Checked)
            {
                dgvArticulos.DataSource = Session["listaArticulos"];
                dgvArticulos.DataBind();
            }

        }
    }
}