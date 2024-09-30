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
    public partial class Marcas : System.Web.UI.Page
    {
        public List<Articulo> listaArticulos {  get; set; }
		protected void Page_Load(object sender, EventArgs e)
        {
			ArticuloNegocio negocio = new ArticuloNegocio();
			try
			{
				listaArticulos = negocio.listarSP();
                if (!IsPostBack)
                {
                    repRepetidor.DataSource = listaArticulos;
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
                if (Seguridad.sesionIniciada(Session["sesionIniciada"]) || Seguridad.soyAdmin(Session["sesionIniciada"]))
                {
                    FavoritoNegocio negocio = new FavoritoNegocio();
                    Favorito nuevo = new Favorito();

                    ImageButton btn = (ImageButton)sender;
                    string id = btn.CommandArgument;

                    nuevo.IdArticulo = int.Parse(id);
                    User user = (User)Session["sesionIniciada"];
                    nuevo.IdUser = user.Id;

                    List<Articulo> favoritos = negocio.listarFavoritoSP(nuevo.IdUser);
                    bool articuloEnFavoritos = favoritos.Any(fav => fav.Id == nuevo.IdArticulo);

                    if (articuloEnFavoritos)
                    {
                        negocio.eliminarFavoritoSP(nuevo);
                        btn.CssClass = "btn btn-light";
                        btn.Width = 50;
                    }
                    else
                    {
                        negocio.agregarFavoritoSP(nuevo);
                        btn.CssClass = "btn btn-warning";
                        btn.Width = 50;
                    }

                }
                else
                {
                    Response.Redirect("~/Login.aspx?returnUrl=Login", false);
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