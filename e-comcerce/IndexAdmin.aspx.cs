using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_comcerce
{
    public partial class IndexAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null ||
                ((CapaDominio.Usuario)Session["usuario"]).TipoUsuario != CapaDominio.TipoUsuario.ADMIN)
            {
                Session.Add("error", "Debes loguearte para ingresar y/o tener los permisos adecuados para ingresar a esta pagina.");
                Response.Redirect("ErrorLogin.aspx", false);
            }

            if (!Page.IsPostBack) {}
        }
    }
}