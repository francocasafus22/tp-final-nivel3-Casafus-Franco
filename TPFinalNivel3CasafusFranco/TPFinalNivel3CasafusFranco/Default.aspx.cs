﻿using System;
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
			
        }

    }
}