using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Auxiliar;
using Negocio;
using System.IO;

namespace Web
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    if (Seguridad.soyAdmin(Session["sesionIniciada"]))
                    {
                        User admin = (User)Session["sesionIniciada"];

                        lblNombreApellido.Text = admin.Nombre + " " + admin.Apellido;
                        lblCorreo.Text = admin.Email;
                        lblContraseña.Text = "*******";
                        if (!string.IsNullOrEmpty(admin.UrlImgPerfil))
                        {
                            imgPerfil.ImageUrl = "~/Images/Perfil/Admin/" + admin.UrlImgPerfil + "?v=" + DateTime.Now.Ticks;
                        }
                        else
                        {
                            imgPerfil.ImageUrl = "~/Images/admin.jpg";
                        }
                    }
                    else if (Seguridad.sesionIniciada(Session["sesionIniciada"]))
                    {
                        User user = (User)Session["sesionIniciada"];

                        lblNombreApellido.Text = user.Nombre + " " + user.Apellido;
                        lblCorreo.Text = user.Email;
                        lblContraseña.Text = "*******";
                        if (!string.IsNullOrEmpty(user.UrlImgPerfil))
                        {
                            imgPerfil.ImageUrl = "~/Images/Perfil/" + user.UrlImgPerfil + "?v=" + DateTime.Now.Ticks;
                        }
                        else
                        {
                            imgPerfil.ImageUrl = "~/Images/foto-perfil-sin-img.png";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("ERROR", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Seguridad.soyAdmin(Session["sesionIniciada"]))
                {
                    UserNegocio negocio = new UserNegocio();
                    User admin = (User)Session["sesionIniciada"];

                    if (Validacion.textoVacio(txtEmail) && Validacion.textoVacio(txtContraseña))
                    {
                        txtEmail.CssClass = "form-control input-invalid";
                        lblEmail.Text = "Ingrese su email.";
                        lblEmail.Visible = true;

                        txtContraseña.CssClass = "form-control input-invalid";
                        lblPass.Text = "Ingrese una contraseña con mínimo 3 caracteres.";
                        lblPass.Visible = true;
                    }
                    else
                    {
                        try
                        {
                            if (fileImgPerfil.PostedFile.FileName != "")
                            {
                                string ruta = Server.MapPath("./Images/Perfil/Admin/");
                                if (!Directory.Exists(ruta))
                                {
                                    Directory.CreateDirectory(ruta);
                                }
                                fileImgPerfil.PostedFile.SaveAs(ruta + "admin-" + admin.Nombre + "-" + admin.Id + ".jpg");
                                admin.UrlImgPerfil = "admin-" + admin.Nombre + "-" + admin.Id + ".jpg";
                            }
                        }
                        catch (Exception ex)
                        {
                            Session.Add("ERROR", ex.ToString());
                            Response.Redirect("Error.aspx", false);
                        }

                        admin.Nombre = txtNombre.Text;
                        admin.Apellido = txtApellido.Text;
                        admin.Email = txtEmail.Text;
                        admin.Contraseña = txtContraseña.Text;
                        negocio.actualizarUser(admin);

                        Image img = (Image)Master.FindControl("imgUser");
                        img.ImageUrl = "~/Images/Perfil/Admin/" + admin.UrlImgPerfil;

                        imgPerfil.ImageUrl = "~/Images/Perfil/Admin/" + admin.UrlImgPerfil;

                        panelPerfil.Visible = true;
                        panelEditar.Visible = false;
                    }
                }

                else if (Seguridad.sesionIniciada(Session["sesionIniciada"]))
                {
                    UserNegocio negocio = new UserNegocio();
                    User user = (User)Session["sesionIniciada"];

                    if (Validacion.textoVacio(txtEmail.Text) && Validacion.textoVacio(txtContraseña.Text))
                    {
                        txtEmail.CssClass = "form-control input-invalid";
                        lblEmail.Text = "Ingrese su email.";
                        lblEmail.Visible = true;

                        txtContraseña.CssClass = "form-control input-invalid";
                        lblPass.Text = "Ingrese una contraseña con mínimo 3 caracteres.";
                        lblPass.Visible = true;
                    }
                    else
                    {
                        try
                        {
                            if (fileImgPerfil.PostedFile.FileName != "")
                            {
                                string ruta = Server.MapPath("./Images/Perfil/");
                                if (!Directory.Exists(ruta))
                                {
                                    Directory.CreateDirectory(ruta);
                                }
                                fileImgPerfil.PostedFile.SaveAs(ruta + "perfil-" + user.Nombre + "-" + user.Id + ".jpg");
                                user.UrlImgPerfil = "perfil-" + user.Nombre + "-" + user.Id + ".jpg";
                            }
                        }
                        catch (Exception ex)
                        {
                            Session.Add("ERROR", ex.ToString());
                            Response.Redirect("Error.aspx", false);
                        }

                        user.Nombre = txtNombre.Text;
                        user.Apellido = txtApellido.Text;
                        user.Email = txtEmail.Text;
                        user.Contraseña = txtContraseña.Text;
                        negocio.actualizarUser(user);

                        Image img = (Image)Master.FindControl("imgUser");
                        img.ImageUrl = "~/Images/Perfil/" + user.UrlImgPerfil;

                        imgPerfil.ImageUrl = "~/Images/Perfil/" + user.UrlImgPerfil;

                        panelPerfil.Visible = true;
                        panelEditar.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("ERROR", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                panelPerfil.Visible = false;
                panelEditar.Visible = true;

                if (Seguridad.soyAdmin(Session["sesionIniciada"]))
                {
                    User admin = (User)Session["sesionIniciada"];

                    txtEmail.Text = admin.Email;
                    txtContraseña.Text = admin.Contraseña;
                    txtNombre.Text = admin.Nombre;
                    txtApellido.Text = admin.Apellido;
                    if (!string.IsNullOrEmpty(admin.UrlImgPerfil))
                    {
                        imgPerfilEditar.ImageUrl = "~/Images/Perfil/Admin/" + admin.UrlImgPerfil + "?v=" + DateTime.Now.Ticks;
                    }
                }
                else if (Seguridad.sesionIniciada(Session["sesionIniciada"]))
                {
                    User user = (User)Session["sesionIniciada"];

                    txtEmail.Text = user.Email;
                    txtContraseña.Text = user.Contraseña;
                    txtNombre.Text = user.Nombre;
                    txtApellido.Text = user.Apellido;
                    if (!string.IsNullOrEmpty(user.UrlImgPerfil))
                    {
                        imgPerfilEditar.ImageUrl = "~/Images/Perfil/" + user.UrlImgPerfil + "?v=" + DateTime.Now.Ticks;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("ERROR", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                panelEditar.Visible = false;
                panelPerfil.Visible = true;
            }
            catch (Exception ex)
            {
                Session.Add("ERROR", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Clear();
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("ERROR", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void txtNombre_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtNombre.Text.Length > 50)
                {
                    txtNombre.CssClass = "form-control input-invalid";
                    lblNombre.Text = "Ingrese un nombre con menos de 50 caracteres.";
                    lblNombre.Visible = true;
                }
                else
                {
                    txtNombre.CssClass = "form-control input-valid";
                    lblNombre.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Session.Add("ERROR", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void txtApellido_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtApellido.Text.Length > 20)
                {
                    txtApellido.CssClass = "form-control input-invalid";
                    lblApellido.Text = "Ingrese un apellido con menos de 20 caracteres.";
                    lblApellido.Visible = true;
                }
                else
                {
                    txtApellido.CssClass = "form-control input-valid";
                    lblApellido.Visible = false;
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
                    lblPass.Visible = false;
                }
                else
                {
                    txtContraseña.CssClass = "form-control input-invalid";
                    lblPass.Text = "Ingrese una contraseña con mínimo 3 caracteres.";
                    lblPass.Visible = true;
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

