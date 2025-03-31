using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class UsuarioNegocio
    {
        public bool Login(User usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("select id, email, pass, nombre, apellido, urlImagenPerfil, admin from USERS where email=@mail and pass=@pass");
                datos.setParametro("@mail", usuario.mail);
                datos.setParametro("@pass", usuario.password);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                   usuario.id = (int)datos.Lector["Id"];
                   usuario.mail = (string)datos.Lector["email"];
                   usuario.TipoUsuario = (bool)datos.Lector["admin"];
                    if (!(datos.Lector["nombre"] is DBNull))
                        usuario.nombre = (string)datos.Lector["nombre"];
                    if (!(datos.Lector["apellido"] is DBNull))
                        usuario.apellido = (string)datos.Lector["apellido"];
                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        usuario.Imagen = (string)datos.Lector["urlImagenPerfil"];

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Registrarse(User usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("insert into USERS (email, pass, admin) values (@mail, @pass, 0)");
                datos.setParametro("@mail", usuario.mail);
                datos.setParametro("@pass", usuario.password);               
                datos.ejecutarAccion();               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void Actualizar(User usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("update USERS set nombre=@nombre, apellido=@apellido, urlImagenPerfil=@urlImagenPerfil where Id=@id");
                datos.setParametro("@nombre", usuario.nombre);
                datos.setParametro("@apellido", usuario.apellido);
                datos.setParametro("@urlImagenPerfil", usuario.Imagen);
                datos.setParametro("@id", usuario.id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
