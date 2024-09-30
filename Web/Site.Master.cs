using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Auxiliar;
using Dominio;

namespace Web
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!(Page is Default || Page is Categorias || Page is Marcas || Page is Error1 ||
                    Page is PagSamsung || Page is PagApple || Page is PagSony || Page is PagHuawei ||
                    Page is PagMotorola || Page is PagCelulares || Page is PagTelevisores || Page is PagMedia ||
                    Page is PagAudio || Page is Producto || Page is Registrar || Page is Busqueda))
                {
                    if (!Seguridad.sesionIniciada(Session["sesionIniciada"]))
                    {
                        Response.Redirect("~/Login.aspx?returnUrl=Perfil", true);
                    }
                }
                if (!Seguridad.sesionIniciada(Session["sesionIniciada"]))
                {
                    hyperArticulos.Visible = false;
                    panelMenuPerfil.Visible = false;
                    panelLogin.Visible = true;
                }
                if (Seguridad.soyAdmin(Session["sesionIniciada"]))
                {
                    User admin = (User)Session["sesionIniciada"];
                    hyperArticulos.Visible = true;
                    panelMenuPerfil.Visible = true;
                    panelLogin.Visible = false;
                    lblNombreUser.Text = admin.Nombre;

                    if (!string.IsNullOrEmpty(admin.UrlImgPerfil))
                    {
                        imgUser.ImageUrl = "~/Images/Perfil/Admin/" + admin.UrlImgPerfil + "?v=" + DateTime.Now.Ticks;
                    }
                    else
                    {
                        imgUser.ImageUrl = "~/Images/admin.jpg";
                    }
                }
                else if (Seguridad.sesionIniciada(Session["sesionIniciada"]))
                {
                    User user = (User)Session["sesionIniciada"];
                    hyperArticulos.Visible = false;
                    panelLogin.Visible = false;
                    panelMenuPerfil.Visible = true;
                    lblNombreUser.Text = user.Nombre;

                    if (!string.IsNullOrEmpty(user.UrlImgPerfil))
                    {
                        imgUser.ImageUrl = "~/Images/Perfil/" + user.UrlImgPerfil + "?v=" + DateTime.Now.Ticks;
                    }
                    else
                    {
                        imgUser.ImageUrl = "~/Images/foto-perfil-sin-img.png";
                    }
                }
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
    }
}
