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
    public partial class Busqueda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    string referencia = Request.UrlReferrer?.AbsolutePath;
                    if (referencia != null && referencia.Contains("Default.aspx"))
                    {
                        string busqueda = Request.QueryString["query"];
                        if (!string.IsNullOrEmpty(busqueda))
                        {
                            ArticuloNegocio negocio = new ArticuloNegocio();
                            Session.Add("listaBusqueda", negocio.listarSP());

                            lblBusqueda.Text = $"Resultados de búsqueda para: {busqueda}";

                            List<Articulo> busquedaArticulos = (List<Articulo>)Session["listaBusqueda"];
                            List<Articulo> filtrada = busquedaArticulos.FindAll(x => x.Nombre.ToUpper().Contains(busqueda.ToUpper()));

                            if (filtrada.Count == 0)
                            {
                                panelListado.Visible = false;
                                panelSinResultado.Visible = true;
                                lblSinResultado.Text = "No se encontraron resultados de " + busqueda;
                            }
                            else
                            {
                                panelListado.Visible = true;
                                panelSinResultado.Visible = false;
                                repListado.DataSource = filtrada;
                                repListado.DataBind();
                            }
                        }
                        else
                        {
                            panelListado.Visible = true;
                            panelSinResultado.Visible = false;

                            ArticuloNegocio negocio = new ArticuloNegocio();
                            Session.Add("listaBusqueda", negocio.listarSP());

                            repListado.DataSource = Session["listaBusqueda"];
                            repListado.DataBind();
                        }
                    }
                    else
                    {
                        panelListado.Visible = true;
                        ArticuloNegocio negocio = new ArticuloNegocio();
                        Session.Add("listaBusqueda", negocio.listarSP());

                        repListado.DataSource = Session["listaBusqueda"];
                        repListado.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("ERROR", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Articulo> listaArticulos = (List<Articulo>)Session["listaBusqueda"];
                List<Articulo> busqueda = listaArticulos;

                if (!string.IsNullOrEmpty(txtBuscar.Text))
                {
                    panelListado.Visible = true;
                    panelSinResultado.Visible = false;

                    busqueda = busqueda.Where(x => x.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper())).ToList();
                    repListado.DataSource = busqueda;
                    repListado.DataBind();
                }
                else
                {
                    panelListado.Visible = false;
                    panelSinResultado.Visible = true;
                    lblSinResultado.Text = "No se econtraron resultados de " + txtBuscar.Text;
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