using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using CapaDominio;
using CapaNegocio;
using System.Web.Security;
using System.Web.SessionState;

namespace e_comcerce
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.User.Identity.IsAuthenticated)
            {
                Response.Redirect(FormsAuthentication.DefaultUrl);
            }
        }

        protected void LoginUser_Authenticate(object sender, EventArgs e)
        {

            Usuario usuario = UsuarioNegocio.getInstance().AccesoSistema(frmLogin.UserName, frmLogin.Password);

            if (usuario != null)
            {
                Session.Add("usuario", usuario);
                Session.Add("userName", usuario.Email);
                Response.Redirect("Default.aspx", false);
            }
            else
            {
                //Response.Write("<script>alert('Usuario y/o Contraseña incorrecto.')</script>");
                Response.Write("<script language='javascript'>alert('Usuario y/o Contraseña incorrectos.');</script>");
                Session.Add("error", "user o pass incorrectos");
                Response.Redirect("ErrorLogin.aspx", false);
            }
        }
    }
}