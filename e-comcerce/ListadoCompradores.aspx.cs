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

            if (Session["usuario"] == null ||
               ((CapaDominio.Usuario)Session["usuario"]).TipoUsuario != CapaDominio.TipoUsuario.ADMIN)
            {
                Session.Add("error", "Debes loguearte para ingresar y/o tener los permisos adecuados para ingresar a esta pagina.");
                Response.Redirect("ErrorPermisos.aspx", false);
            }
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