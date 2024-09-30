using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Auxiliar;
using Dominio;
using Negocio;

namespace Web
{
    public partial class AgregarArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            try
            {
                if (!Seguridad.soyAdmin(Session["sesionIniciada"]))
                {
                    Response.Redirect("~/Error.aspx?returnUrl=AgregarArticulo", false);
                }
                if (!IsPostBack)
                {
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
                }
            }
            catch (Exception ex)
            {
                Session.Add("ERROR", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void txtImg_TextChanged(object sender, EventArgs e)
        {
            try
            {
                imagenArticulo.ImageUrl = txtImg.Text;
            }
            catch (Exception ex)
            {
                Session.Add("ERROR", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnSubir_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo nuevo = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();
                nuevo.Marca = new Marca();
                nuevo.Categoria = new Categoria();
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
                    nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                    nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                    nuevo.CodigoArticulo = txtCodigo.Text;
                    nuevo.Nombre = txtNombre.Text;
                    if (decimal.TryParse(txtPrecio.Text, out decimal precio))
                    {
                        nuevo.Precio = precio;
                    }
                    else
                    {
                        lblPrecio.Text = "Ingrese correctamente el precio";
                    }
                    if (string.IsNullOrEmpty(txtImg.Text))
                    {
                        nuevo.ImagenUrl = "~/Images/image-not-found.png";
                    }
                    else
                    {
                        nuevo.ImagenUrl = txtImg.Text;
                    }
                    nuevo.Descripcion = txtDescripcion.Text;

                    negocio.agregarSP(nuevo);
                    Response.Redirect("ListadoArticulos.aspx", false);
                }

            }
            catch (Exception ex)
            {
                Session.Add("ERROR", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text.Length > 50)
                {
                    txtCodigo.CssClass = "form-control input-invalid";
                    lblCodigo.Text = "El código de artículo debe tener menos de 50 caracteres!.";
                    lblCodigo.Visible = true;
                }
                else
                {
                    txtCodigo.CssClass = "form-control input-valid";
                    lblCodigo.Visible = false;
                }
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
                    lblNombre.Text = "El nombre del artículo debe tener menos de 50 caracteres!.";
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

        protected void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPrecio.Text.Length > 0)
                {
                    txtPrecio.CssClass = "form-control input-valid";
                    lblPrecio.Visible = false;
                }
                else
                {
                    txtPrecio.CssClass = "form-control input-invalid";
                }
            }
            catch (Exception ex)
            {
                Session.Add("ERROR", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDescripcion.Text.Length > 150)
                {
                    txtDescripcion.CssClass = "form-control input-invalid";
                    lblDescrip.Text = "La descripción del artículo debe tener menos de 150 caracteres!.";
                    lblDescrip.Visible = true;
                }
                else
                {
                    txtDescripcion.CssClass = "form-control input-valid";
                    lblDescrip.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Session.Add("ERROR", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlCategoria.SelectedIndex > 0)
                {
                    ddlCategoria.CssClass = "form-select input-valid";
                    lblCategoria.Visible = false;
                }
                else
                {
                    ddlCategoria.CssClass = "form-select input-invalid";
                    lblCategoria.Text = "Seleccione una categoría.";
                    lblCategoria.Visible = true;
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
                    ddlMarca.CssClass = "form-select input-valid";
                    lblMarca.Visible = false;
                }
                else
                {
                    ddlMarca.CssClass = "form-select input-invalid";
                    lblMarca.Text = "Seleccione una categoría.";
                    lblMarca.Visible = true;
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