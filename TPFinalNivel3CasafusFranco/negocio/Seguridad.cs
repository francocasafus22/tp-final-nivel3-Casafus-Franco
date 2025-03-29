using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using dominio;

namespace negocio
{
    static public class Seguridad
    {
        public static bool SesionIniciada(object User)
        {
            User usuario = User != null ? (User)User : null;

            if (usuario != null && usuario.id != 0)
                return true;
            else
                return false;           
        }

        public static bool isAdmin(object User)
        {
            User usuario = User != null ? (User)User : null;
            if (usuario != null && usuario.TipoUsuario && usuario.id != 0)
                return true;
            else
                return false;
        }
    }
}
