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
    public partial class AltaAdmin : System.Web.UI.Page
    {
        public List<Usuario> listaAdmin = new List<Usuario>();
        public Usuario objAdmin = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usuario"] == null ||
               ((CapaDominio.Usuario)Session["usuario"]).TipoUsuario != CapaDominio.TipoUsuario.ADMIN)
            {
                Session.Add("error", "Debes loguearte para ingresar y/o tener los permisos adecuados para ingresar a esta pagina.");
                Response.Redirect("ErrorLogin.aspx", false);
            }
            else
            {
                listaAdmin = AdminNegocio.getInstance().listaAdmin();

                if (Request.QueryString["id"] != null)
                {
                    int idAdmin = int.Parse(Request.QueryString["id"].ToString());

                    foreach (Usuario item in listaAdmin)
                    {
                        if (item.IdUsuario == idAdmin)
                        {
                            objAdmin = item;
                        }
                    }
                }
            }            
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            bool ok = AdminNegocio.getInstance().DarAltaAdmin(objAdmin.IdUsuario);

            if (ok == true)
            {
                Response.Redirect("Administradores.aspx");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Administradores.aspx");
        }
    }
}