using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDominio;
using CapaNegocio;

namespace e_comcerce
{
    public partial class RegistrarFormaPago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null ||
               ((CapaDominio.Usuario)Session["usuario"]).TipoUsuario != CapaDominio.TipoUsuario.ADMIN)
            {
                Session.Add("error", "Debes loguearte para ingresar y/o tener los permisos adecuados para ingresar a esta pagina.");
                Response.Redirect("ErrorPermisos.aspx", false);
            }
           
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            bool ok = FormaPagoNegocio.getInstance().RegistrarFormaPago(txtDescripcion.Text);

            if (ok == true)
            {
                Response.Redirect("AdminFormaPago");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminFormaPago");
        }
    }
}