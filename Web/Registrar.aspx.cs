using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Auxiliar;
using Dominio;
using Negocio;

namespace Web
{
    public partial class Registrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Session.Add("ERROR", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            User user = new User();
            UserNegocio negocio = new UserNegocio();
            ServicioEmail emailConfirm = new ServicioEmail();
            try
            {
                if (Validacion.textoVacio(txtEmail) && Validacion.textoVacio(txtContraseña))
                {
                    txtEmail.CssClass = "form-control input-invalid";
                    lblEmail.Text = "Ingrese su email.";
                    lblEmail.Visible = true;

                    txtContraseña.CssClass = "form-control input-invalid";
                    lblContraseña.Text = "Ingrese una contraseña con mínimo 3 caracteres.";
                    lblContraseña.Visible = true;
                }
                else
                {
                    user.Nombre = txtNombre.Text;
                    user.Apellido = txtApellido.Text;
                    user.Email = txtEmail.Text;
                    user.Contraseña = txtContraseña.Text;
                    user.Id = negocio.nuevoUser(user);
                    Session.Add("sesionIniciada", user);

                    emailConfirm.armarCorreo(user.Email, "Bienvenido a comercio!", "Ya puedes ser usuario de nuestra web");
                    emailConfirm.enviarEmail();
                    Response.Redirect("Perfil.aspx", false);
                }

            }
            catch (Exception ex)
            {
                Session.Add("ERROR", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Validacion.emailValido(txtEmail.Text))
                {
                    txtEmail.CssClass = "form-control input-valid";
                    lblEmail.Visible = false;
                }
                else
                {
                    txtEmail.CssClass = "form-control input-invalid";
                    lblEmail.Text = "Ingrese correctamente su email.";
                    lblEmail.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Session.Add("ERROR", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtContraseña.Text.Length >= 3)
                {
                    txtContraseña.CssClass = "form-control input-valid";
                    lblContraseña.Visible = false;
                }
                else
                {
                    txtContraseña.CssClass = "form-control input-invalid";
                    lblContraseña.Text = "Ingrese una contraseña con mínimo 3 caracteres.";
                    lblContraseña.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Session.Add("ERROR", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}