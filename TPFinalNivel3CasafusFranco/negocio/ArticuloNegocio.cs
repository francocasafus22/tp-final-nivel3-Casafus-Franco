﻿using System;
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

        public void Agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("insert into Articulos (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio);");
                datos.setParametro("@Codigo", nuevo.Codigo);
                datos.setParametro("@Nombre", nuevo.Nombre);
                datos.setParametro("@Descripcion", nuevo.Descripcion);
                datos.setParametro("@IdMarca", nuevo.Marca_Articulo.Id);
                datos.setParametro("@IdCategoria", nuevo.Categoria_Articulo.Id);
                datos.setParametro("@ImagenUrl", nuevo.Imagen);
                datos.setParametro("@Precio", nuevo.Precio);
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

        public void Modificar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("update Articulos set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @ImagenUrl, Precio = @Precio where Id = @Id;");
                datos.setParametro("@Codigo", nuevo.Codigo);
                datos.setParametro("@Nombre", nuevo.Nombre);
                datos.setParametro("@Descripcion", nuevo.Descripcion);
                datos.setParametro("@IdMarca", nuevo.Marca_Articulo.Id);
                datos.setParametro("@IdCategoria", nuevo.Categoria_Articulo.Id);
                datos.setParametro("@ImagenUrl", nuevo.Imagen);
                datos.setParametro("@Precio", nuevo.Precio);
                datos.setParametro("@Id", nuevo.Id);
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

        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("delete from Articulos where Id = @Id;");
                datos.setParametro("@Id", id);
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

       

        public List<Articulo> busquedaFiltrada(string filtro, string v1, string v2)
        {
            List<Articulo> list = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select A.Id as Id, A.Codigo, Nombre, A.Descripcion as Descripcion, ImagenUrl,C.Id as Id_Descripcion ,C.Descripcion as Categoria, M.Id as Id_Marca,M.Descripcion as Marca,Precio from Articulos A inner join CATEGORIAS C ON A.IdCategoria = C.Id inner join MARCAS M on A.IdMarca = M.Id ";

                switch (v1)
                {
                    case "Codigo":
                        switch (v2)
                        {
                            case "Comienza con":
                                consulta += "where A.Codigo like @filtro";
                                datos.setParametro("@filtro", filtro + "%");
                                break;
                            case "Termina con":
                                consulta += "where A.Codigo like @filtro";
                                datos.setParametro("@filtro", "%" + filtro);
                                break;
                            case "Contiene":
                                consulta += "where A.Codigo like @filtro";
                                datos.setParametro("@filtro", "%" + filtro + "%");
                                break;
                            default: break;
                        }
                        break;
                    case "Nombre":
                        switch (v2)
                        {
                            case "Comienza con":
                                consulta += "where A.Nombre like @filtro";
                                datos.setParametro("@filtro", filtro + "%");
                                break;
                            case "Termina con":
                                consulta += "where A.Nombre like @filtro";
                                datos.setParametro("@filtro", "%" + filtro);
                                break;
                            case "Contiene":
                                consulta += "where A.Nombre like @filtro";
                                datos.setParametro("@filtro", "%" + filtro + "%");
                                break;
                            default: break;
                        }
                        break;
                    case "Precio":
                        switch (v2)
                        {
                            case "Mayor a":
                                consulta += "where A.Precio > @filtro";
                                datos.setParametro("@filtro", filtro);
                                break;
                            case "Menor a":
                                consulta += "where A.Precio < @filtro";
                                datos.setParametro("@filtro", filtro);
                                break;
                            case "Igual a":
                                consulta += "where A.Precio = @filtro";
                                datos.setParametro("@filtro", filtro);
                                break;
                            default: break;
                        }
                        break;

                    case "Categoria":
                        consulta += "where C.Descripcion = @filtro";
                        datos.setParametro("@filtro", v2);
                        break;

                    case "Marca":
                        consulta += "where M.Descripcion = @filtro";
                        datos.setParametro("@filtro", v2);
                        break;

                    default:
                        break;
                }

                datos.setConsulta(consulta);
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

                    list.Add(aux);
                }
                return list;

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
