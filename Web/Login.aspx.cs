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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["returnUrl"] == "Perfil")
                    {
                        lblMensaje.Text = "Debes iniciar sesión para poder hacer esto...";
                        lblMensaje.Visible = true;
                    }
                    if (Request.QueryString["returnUrl"] == "Login")
                    {
                        lblMensaje.Text = "Debes iniciar sesión para poder hacer esto...";
                        lblMensaje.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("ERROR", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            User user = new User();
            UserNegocio negocio = new UserNegocio();
            try
            {
                if (Validacion.textoVacio(txtEmail) && Validacion.textoVacio(txtContraseña))
                {
                    txtEmail.CssClass = "form-control input-invalid";
                    lblErrorCorreo.Text = "Ingrese su correo";
                    lblErrorCorreo.Visible = true;

                    txtContraseña.CssClass = "form-control input-invalid";
                    lblErrorContraseña.Text = "Ingrese su contraseña";
                    lblErrorContraseña.Visible = true;

                    lblMensaje.Text = "Ingrese su correo y contraseña para ingresar por favor..";
                    lblMensaje.Visible = true;
                }
                else
                {
                    lblMensaje.Visible = false;

                    user.Email = txtEmail.Text;
                    user.Contraseña = txtContraseña.Text;
                    if (negocio.Login(user))
                    {
                        Session.Add("sesionIniciada", user);
                        Response.Redirect("Default.aspx", false);
                    }
                    else
                    {
                        txtEmail.CssClass = "form-control input-invalid";
                        lblErrorCorreo.Text = "Ingrese su correo";
                        lblErrorCorreo.Visible = true;

                        txtContraseña.CssClass = "form-control input-invalid";
                        lblErrorContraseña.Text = "Ingrese su contraseña";
                        lblErrorContraseña.Visible = true;

                        lblMensaje.Text = "Correo o contraseña incorrectos, por favor ingrese sus datos correctamente..";
                        lblMensaje.Visible = true;
                    }
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