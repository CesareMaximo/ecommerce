using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using CapaNegocio;
using CapaDominio;

namespace e_comcerce
{
    public partial class ListadoCompradores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("Error.aspx", false);
            }

            if (!(Session["usuario"] != null &&
                ((Usuario)Session["usuario"]).TipoUsuario == TipoUsuario.ADMIN))
            {
                Session.Add("error", "No tienes permisos para ingresar a esta pantalla. Necesitas nivel ADMIN.");
                Response.Redirect("Error.aspx", false);
            }

            if (!Page.IsPostBack) { }
        }

        [WebMethod]
        public static List<Usuario> ListarUsuarios()
        {
            List<Usuario> ListaUsuarios = null;
            try
            {
                ListaUsuarios = UsuarioNegocio.getInstance().ListarUsuarios();
            }
            catch (Exception ex)
            {
                ListaUsuarios = new List<Usuario>();
            }
            return ListaUsuarios;
        }
    }
}