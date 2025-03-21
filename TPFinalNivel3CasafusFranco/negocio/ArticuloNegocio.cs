using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {

        public List<Articulo> Listar(string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (filtro == "")
                {
                    datos.setConsulta("select A.Id as Id, A.Codigo, Nombre, A.Descripcion as Descripcion, ImagenUrl,C.Id as Id_Descripcion ,C.Descripcion as Categoria, M.Id as Id_Marca,M.Descripcion as Marca,Precio from Articulos A inner join CATEGORIAS C ON A.IdCategoria = C.Id inner join MARCAS M on A.IdMarca = M.Id; ");
                }
                else
                {
                    datos.setConsulta("select A.Id as Id, A.Codigo, Nombre, A.Descripcion as Descripcion, ImagenUrl,C.Id as Id_Descripcion ,C.Descripcion as Categoria, M.Id as Id_Marca,M.Descripcion as Marca,Precio from Articulos A inner join CATEGORIAS C ON A.IdCategoria = C.Id inner join MARCAS M on A.IdMarca = M.Id where A.Nombre like @filtro; ");
                    datos.setParametro("@filtro", "%" + filtro + "%");
                }
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Imagen = (string)datos.Lector["ImagenUrl"];
                    aux.Categoria_Articulo = new Categoria();
                    aux.Categoria_Articulo.Id = (int)datos.Lector["Id_Descripcion"];
                    aux.Categoria_Articulo.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Marca_Articulo = new Marca();
                    aux.Marca_Articulo.Descripcion = (string)datos.Lector["Marca"];
                    aux.Marca_Articulo.Id = (int)datos.Lector["Id_Marca"];
                    decimal precio = (decimal)datos.Lector["Precio"];
                    aux.Precio = Math.Round(precio, 2);

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

    }
}
