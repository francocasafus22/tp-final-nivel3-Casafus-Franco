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
                datos.setConsulta("update USERS set nombre=@nombre, apellido=@apellido, email=@email ,urlImagenPerfil=@urlImagenPerfil where Id=@id");
                datos.setParametro("@nombre", usuario.nombre);
                datos.setParametro("@apellido", usuario.apellido);
                datos.setParametro("@urlImagenPerfil", usuario.Imagen);
                datos.setParametro("@id", usuario.id);
                datos.setParametro("@email", usuario.mail);
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
        
        public void AgregarArticuloFavorito(int IdArticulo, int IdUser)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("INSERT INTO FAVORITOS(IdArticulo, IdUser) VALUES (@IdArticulo, @IdUser)");
                datos.setParametro("@IdArticulo", IdArticulo);
                datos.setParametro("@IdUser", IdUser);
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
        public List<Articulo> GetListaFavoritos(int IdUser)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulo> lista = new List<Articulo>();
            try
            {
                datos.setConsulta("SELECT A.Id, A.ImagenUrl, A.Nombre, A.Precio " +
                    "FROM FAVORITOS F " +
                    "INNER JOIN ARTICULOS A ON F.IdArticulo = A.Id " +
                    "INNER JOIN USERS U ON F.IdUser = U.Id " +
                    "WHERE F.IdUser = @UserId");
                datos.setParametro("@UserId", IdUser);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Imagen = (string)datos.Lector["ImagenUrl"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    lista.Add(aux);
                }
                return lista;
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

        public void EliminarFavorito(int IdArticulo, int IdUser)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("DELETE FROM FAVORITOS WHERE IdArticulo=@Articulo and IdUser=@User");
                datos.setParametro("@Articulo", IdArticulo);
                datos.setParametro("@User", IdUser);
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
