using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using Auxiliar;

namespace Web
{
    public partial class ListadoArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Seguridad.soyAdmin(Session["sesionIniciada"]))
                {
                    Response.Redirect("~/Error.aspx?returnUrl=ListadoArticulos", false);
                }
                if (!IsPostBack)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Session.Add("listaArticulos", negocio.listarSP());
                    dgvArticulos.DataSource = Session["listaArticulos"];
                    dgvArticulos.DataBind();

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

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var id = dgvArticulos.SelectedDataKey.Value.ToString();
                Response.Redirect("Producto.aspx?id=" + id, false);
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
                List<Articulo> busqueda = (List<Articulo>)Session["listaArticulos"];
                List<Articulo> filtrada = busqueda.FindAll(x => x.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()));
                dgvArticulos.DataSource = filtrada;
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("ERROR", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnBuscarFiltrado_Click(object sender, EventArgs e)
        {
            try
            {
                List<Articulo> listaArticulos = (List<Articulo>)Session["listaArticulos"];
                List<Articulo> articulosFiltrados = listaArticulos;

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

                dgvArticulos.DataSource = articulosFiltrados;
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("ERROR", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                ddlMarca.SelectedIndex = 0;
                ddlCategoria.SelectedIndex = 0;

                dgvArticulos.DataSource = Session["listaArticulos"];
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("ERROR", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void chekFiltrar_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                pnlFiltros.Visible = chekFiltrar.Checked;
            }
            catch (Exception ex)
            {
                Session.Add("ERROR", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnSelec_Click(object sender, EventArgs e)
        {
            try
            {
                dgvArticulos.Columns[6].Visible = !dgvArticulos.Columns[6].Visible;
                if (btnEliminar.Visible == false)
                {
                    btnEliminar.Visible = true;
                    btnEliminar.Enabled = false;
                }
                else
                {
                    btnEliminar.Visible = false;
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
                List<string> articuloSeleccionado = new List<string>();

                foreach (GridViewRow row in dgvArticulos.Rows)
                {
                    CheckBox checkSeleccionado = (CheckBox)row.FindControl("checkSeleccionado");

                    if (checkSeleccionado != null && checkSeleccionado.Checked)
                    {
                        string nombreArticulo = row.Cells[1].Text;
                        articuloSeleccionado.Add(nombreArticulo);
                    }
                }

                if (articuloSeleccionado.Count == 1)
                {
                    litModalTitulo.Text = "¿Está seguro de eliminar este artículo?";
                }
                else if (articuloSeleccionado.Count > 1)
                {
                    litModalTitulo.Text = $"¿Está seguro de eliminar estos artículos?";
                }
                else
                {
                    litModalTitulo.Text = "No hay artículos seleccionados.";
                }

                litArticulos.Text = "<ul><li>" + string.Join("</li><li>", articuloSeleccionado) + "</li></ul>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "$('#confirmEliminarModal').modal('show');", true);
            }
            catch (Exception ex)
            {
                Session.Add("ERROR", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnConfirmEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();

                foreach (GridViewRow row in dgvArticulos.Rows)
                {
                    CheckBox checkSeleccionado = (CheckBox)row.FindControl("checkSeleccionado");
                    if (checkSeleccionado != null && checkSeleccionado.Checked)
                    {
                        int articulo = Convert.ToInt32(dgvArticulos.DataKeys[row.RowIndex].Value);
                        negocio.eliminarSP(articulo);
                    }
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "HideModal", "$('#confirmEliminarModal').modal('hide'); $('.modal-backdrop').remove();", true);
                Response.Redirect("ListadoArticulos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("ERROR", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void checkSeleccionado_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                bool checkeado = false;

                foreach (GridViewRow row in dgvArticulos.Rows)
                {
                    CheckBox checkSeleccionado = (CheckBox)row.FindControl("checkSeleccionado");
                    if (checkSeleccionado != null && checkSeleccionado.Checked)
                    {
                        checkeado = true;
                        break;
                    }
                }
                btnEliminar.Enabled = checkeado;
            }
            catch (Exception ex)
            {
                Session.Add("ERROR", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}