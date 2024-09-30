using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Dominio;

namespace Negocio
{
    public class FavoritoNegocio
    {
        public List<Articulo> listarFavoritoSP(int IdUser)
        {
            List<Articulo> lista = new List<Articulo>();
            Conexion datos = new Conexion();
            try
            {
                //datos.setearConsulta("select Codigo, Nombre, A.Descripcion, ImagenUrl, M.Descripcion as Marca, C.Descripcion as Categoria, A.Id, Precio from ARTICULOS A, CATEGORIAS C, MARCAS M, FAVORITOS F where C.Id = A.IdCategoria and M.Id = A.IdMarca And F.IdArticulo = A.Id and F.IdUser = @idUser");
                datos.setearSP("listaFavoritoSP");
                datos.setearParametro("@idUser", IdUser);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.CodigoArticulo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    {
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    }
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Id = (int)datos.Lector["Id"];
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

        public void agregarFavoritoSP(Favorito nuevo)
        {
            Conexion datos = new Conexion();
            try
            {
                datos.setearSP("agregarFavoritoSP");
                datos.setearParametro("idUser", nuevo.IdUser);
                datos.setearParametro("idArticulo", nuevo.IdArticulo);
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

        public void eliminarFavoritoSP(Favorito fav)
        {
            Conexion datos = new Conexion();
            try
            {
                datos.setearSP("eliminarFavoritoSP");
                datos.setearParametro("@idUser", fav.IdUser);
                datos.setearParametro("@idArticulo", fav.IdArticulo);
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
