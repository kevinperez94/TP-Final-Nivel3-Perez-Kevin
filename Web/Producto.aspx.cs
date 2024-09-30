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
    public partial class Producto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.soyAdmin(Session["sesionIniciada"]))
                    {
                        panelAdmin.Visible = true;
                    }
                    string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                    if (id != "")
                    {
                        CargarArticulo(id);
                    }
                }

            }
            catch (Exception ex)
            {
                Session.Add("ERROR", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {
            try
            {
                imgArticulo.ImageUrl = txtImagen.Text;
            }
            catch (Exception ex)
            {
                Session.Add("ERROR", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        private void cargarImg(string imagen)
        {
            try
            {
                imgArticulo.ImageUrl = imagen;
            }
            catch (Exception)
            {
                imgArticulo.ImageUrl = "~/Images/image-not-found.png";
            }
        }

        private void CargarArticulo(string articuloId)
        {
            // Llama a tu método buscarId para obtener el artículo
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> articulos = negocio.buscarId(articuloId);

            if (articulos != null && articulos.Count > 0)
            {
                // Vincula la lista de artículos al Repeater
                repArticulo.DataSource = articulos;
                repArticulo.DataBind();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo modificar = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();

                if (Validacion.textoVacio(txtCodigo) && Validacion.textoVacio(txtNombre)
                    && ddlMarca.SelectedIndex < 1 && ddlCategoria.SelectedIndex < 1
                    && Validacion.textoVacio(txtPrecio))
                {
                    ddlMarca.CssClass = "form-select input-invalid";
                    lblMarca.Text = "Seleccione una marca.";
                    lblMarca.Visible = true;

                    ddlCategoria.CssClass = "form-select input-invalid";
                    lblCategoria.Text = "Seleccione una categoría.";
                    lblCategoria.Visible = true;

                    txtCodigo.CssClass = "form-control input-invalid";
                    lblCodigo.Text = "Ingrese el código del artículo.";
                    lblCodigo.Visible = true;

                    txtNombre.CssClass = "form-control input-invalid";
                    lblNombre.Text = "Ingrese un nombre para el artículo.";
                    lblNombre.Visible = true;

                    txtPrecio.CssClass = "form-control input-invalid";
                    lblPrecio.Text = "Ingrese un precio para el artículo.";
                    lblPrecio.Visible = true;
                }
                else
                {
                    modificar.ImagenUrl = txtImagen.Text;

                    modificar.Marca = new Marca();
                    modificar.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                    modificar.Marca.Descripcion = ddlMarca.SelectedValue;

                    modificar.Categoria = new Categoria();
                    modificar.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                    modificar.Categoria.Descripcion = ddlCategoria.SelectedValue;

                    modificar.CodigoArticulo = txtCodigo.Text;
                    modificar.Nombre = txtNombre.Text;
                    if (decimal.TryParse(txtPrecio.Text, out decimal precio))
                    {
                        modificar.Precio = precio;
                    }
                    modificar.Descripcion = txtDescripcion.Text;

                    if (Request.QueryString["id"] != null)
                    {
                        modificar.Id = int.Parse(txtId.Text);
                        negocio.modificarSP(modificar);
                    }

                    Response.Redirect("ListadoArticulos.aspx", false);
                    panelEditar.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Session.Add("ERROR", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", $"modalEliminar();", true);
            }
            catch (Exception ex)
            {
                Session.Add("ERROR", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnModalEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                negocio.eliminarSP(int.Parse(txtId.Text));
                Response.Redirect("Default.aspx");
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
                panelProducto.Visible = false;
                panelEditar.Visible = true;
                txtId.Enabled = false;

                MarcaNegocio marca = new MarcaNegocio();
                List<Marca> listaM = marca.listar();
                ddlMarca.DataSource = listaM;
                ddlMarca.DataValueField = "Id";
                ddlMarca.DataTextField = "Descripcion";
                ddlMarca.DataBind();

                ddlMarca.Items.Insert(0, new ListItem("", ""));
                ddlMarca.SelectedIndex = 0;

                CategoriaNegocio categoria = new CategoriaNegocio();
                List<Categoria> listaC = categoria.listar();
                ddlCategoria.DataSource = listaC;
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataBind();

                ddlCategoria.Items.Insert(0, new ListItem("", ""));
                ddlCategoria.SelectedIndex = 0;


                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "")
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Articulo seleccionado = (negocio.buscarId(id))[0];

                    txtId.Text = id;
                    txtImagen.Text = seleccionado.ImagenUrl;
                    cargarImg(seleccionado.ImagenUrl);
                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    txtCodigo.Text = seleccionado.CodigoArticulo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtPrecio.Text = seleccionado.Precio.ToString();
                    txtDescripcion.Text = seleccionado.Descripcion;
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