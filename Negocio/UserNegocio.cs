using AccesoDatos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UserNegocio
    {
        public bool Login (User user)
        {
            Conexion datos = new Conexion();
            try
            {
                datos.setearConsulta("select Id, email, pass, nombre, apellido, urlImagenPerfil, admin FROM USERS where email = @email AND pass = @pass");
                datos.setearParametro("@email", user.Email);
                datos.setearParametro("@pass", user.Contraseña);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    user.Id = (int)datos.Lector["Id"];
                    user.Admin = (bool)datos.Lector["admin"];
                    if (!(datos.Lector["urlImagenPerfil"]is DBNull))
                    {
                        user.UrlImgPerfil = (string)datos.Lector["urlImagenPerfil"];
                    }
                    if (!(datos.Lector["nombre"]is DBNull))
                    {
                        user.Nombre = (string)datos.Lector["nombre"];
                    }
                    if (!(datos.Lector["apellido"]is DBNull))
                    {
                        user.Apellido = (string)datos.Lector["apellido"];
                    }
                    return true;
                }
                return false;
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

        public int nuevoUser(User nuevo)
        {
            Conexion datos = new Conexion();
            try
            {
                datos.setearSP("nuevoUser");
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@apellido", nuevo.Apellido);
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@pass", nuevo.Contraseña);
                return datos.ejecutarAccionScalar();
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

        public void actualizarUser(User user)
        {
            Conexion datos = new Conexion();
            try
            {
                datos.setearConsulta("Update USERS set urlImagenPerfil = @imgPerfil, nombre = @nombre, apellido = @apellido, email = @email, pass = @pass WHERE Id = @id");
                datos.setearParametro("@imgPerfil", (object)user.UrlImgPerfil ?? DBNull.Value);
                datos.setearParametro("@nombre", user.Nombre);
                datos.setearParametro("@apellido", user.Apellido);
                datos.setearParametro("@email", user.Email);
                datos.setearParametro("@pass", user.Contraseña);
                datos.setearParametro("@id", user.Id);
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
