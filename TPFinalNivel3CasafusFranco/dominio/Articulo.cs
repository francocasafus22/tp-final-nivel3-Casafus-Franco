using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Marca Marca_Articulo { get; set; }
        public Categoria Categoria_Articulo { get; set; }
        public string Imagen { get; set; }
        public decimal Precio { get; set; }

    }
}
