﻿using System;
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
    public partial class PagMedia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                if (!IsPostBack)
                {
                    txtBuscar.Enabled = false;
                    Session.Add("listaMedia", negocio.listaMediaSP());
                    repRepetidor.DataSource = Session["listaMedia"];
                    repRepetidor.DataBind();

                    CategoriaNegocio categoria = new CategoriaNegocio();
                    List<Categoria> listaC = categoria.listarMedia();
                    ddlCategoria.DataSource = listaC;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                    MarcaNegocio marca = new MarcaNegocio();
                    List<Marca> listaM = marca.listar();
                    ddlMarca.DataSource = listaM;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                    ddlMarca.Items.Insert(0, new ListItem("Todas las marcas", ""));
                    ddlMarca.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Session.Add("ERROR", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlMarca.SelectedIndex > 0)
                {
                    txtBuscar.Enabled = true;
                }
                else
                {
                    txtBuscar.Enabled = false;
                    repRepetidor.DataSource = Session["listaMedia"];
                    repRepetidor.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("ERROR", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Articulo> busqueda = (List<Articulo>)Session["listaMedia"];
                List<Articulo> filtrada = busqueda.FindAll(x => x.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()));
                repRepetidor.DataSource = filtrada;
                repRepetidor.DataBind();
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
                List<Articulo> listaApple = (List<Articulo>)Session["listaMedia"];
                List<Articulo> articulosFiltrados = listaApple;

                if (!string.IsNullOrEmpty(txtBuscar.Text))
                {
                    articulosFiltrados = articulosFiltrados.Where(x => x.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper())).ToList();
                }

                if (!string.IsNullOrEmpty(ddlMarca.SelectedValue))
                {
                    int idMarcaSeleccionada = int.Parse(ddlMarca.SelectedValue);
                    articulosFiltrados = articulosFiltrados.Where(x => x.Marca.Id == idMarcaSeleccionada).ToList();
                }

                if (!string.IsNullOrEmpty(ddlCategoria.SelectedValue))
                {
                    int idCategoriaSeleccionada = int.Parse(ddlCategoria.SelectedValue);
                    articulosFiltrados = articulosFiltrados.Where(x => x.Categoria.Id == idCategoriaSeleccionada).ToList();
                }

                repRepetidor.DataSource = articulosFiltrados;
                repRepetidor.DataBind();
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