using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Error1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
                if (Request.QueryString["returnUrl"] == "ListadoArticulos" || Request.QueryString["returnUrl"] == "AgregarArticulo")
                {
                    lblError.Text = "Debes tener permisos admin para acceder a este sitio...";
                    lblError.Visible = true;
                }

                lblError.Text = Session["ERROR"].ToString();
                lblError.Visible = true;
            }
			catch (Exception ex)
			{
                Session.Add("ERROR", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}