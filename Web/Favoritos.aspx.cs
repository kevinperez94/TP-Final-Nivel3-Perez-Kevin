using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Auxiliar;
using Negocio;

namespace Web
{
    public partial class Favoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Seguridad.sesionIniciada(Session["sesionIniciada"]))
                {
                    Response.Redirect("~/Login.aspx?returnUrl=Favoritos", false);
                }
                if (!IsPostBack)
                {
                    FavoritoNegocio negocio = new FavoritoNegocio();
                    User user = (User)Session["sesionIniciada"];
                    int idUser = user.Id;

                    List<Articulo> favoritosUser = negocio.listarFavoritoSP(idUser);
                    Session.Add("favoritosUser", favoritosUser);

                    repRepetidor.DataSource = favoritosUser;
                    repRepetidor.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("ERROR", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnFavoritos_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                FavoritoNegocio negocio = new FavoritoNegocio();
                Favorito favorito = new Favorito();

                ImageButton btn = (ImageButton)sender;
                string id = btn.CommandArgument;

                favorito.IdArticulo = int.Parse(id);
                User user = (User)Session["sesionIniciada"];
                favorito.IdUser = user.Id;

                // Obtener la lista actual de favoritos del usuario desde la sesión
                List<Articulo> favoritosUser = (List<Articulo>)Session["favoritosUser"];

                // Verificar si el artículo está en favoritos
                bool articuloEnFavoritos = favoritosUser.Any(fav => fav.Id == favorito.IdArticulo);

                if (articuloEnFavoritos)
                {
                    // Si el artículo está en favoritos, lo eliminamos
                    negocio.eliminarFavoritoSP(favorito);

                    // Actualizamos la lista de favoritos eliminando el artículo
                    favoritosUser.RemoveAll(fav => fav.Id == favorito.IdArticulo);

                    Response.Redirect(Request.RawUrl, false);
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