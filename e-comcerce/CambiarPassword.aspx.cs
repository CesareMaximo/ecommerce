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
    public partial class CambiarPassword : System.Web.UI.Page
    {

        //private Usuario usuarioAGuardar { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar y/o tener los permisos adecuados para ingresar a esta pagina.");
                Response.Redirect("ErrorPermisos.aspx", false);
            }
            else
            {                
                if (!Page.IsPostBack){                    
                }
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

            if (RegisterCurrentPassword.Text == "" ||
                RegisterPassword.Text == "" ||
                RegisterRePassword.Text == "")
            {
                lblError.Text = "Ningun campo puede quedar vacio.";
                Response.Write("<script language=javascript>alert('Ningun campo puede quedar vacio.')</script>");
                Response.Redirect("CambiarPassword.aspx", false);
            }
            else 
            {
                string email = Session["userName"].ToString();
                Usuario usuarioAGuardar = UsuarioNegocio.getInstance().BuscarUsuarioPorEmail(email);                

                if (usuarioAGuardar.Clave.Equals(RegisterCurrentPassword.Text))
                {
                    Response.Write("<script language=javascript>alert('El password actual no es correcto.')</script>");                    
                }
                else if (RegisterPassword.Equals(RegisterRePassword.Text))
                {
                    Response.Write("<script language=javascript>alert('El nuevo password no coincide con el password confirmado.')</script>");                    
                }
                else
                {
                    usuarioAGuardar.Clave = RegisterPassword.Text;
                    bool passwordModificado = UsuarioNegocio.getInstance().ActualizarPasswordUsuario(usuarioAGuardar);

                    if (passwordModificado)
                    {
                        Response.Write("<script language=javascript>alert('Password Modificada Correctamente.')</script>");
                        Response.Redirect("Logout.aspx", false);
                        EmailService objEmail = new EmailService();
                        objEmail.correoCambioPass(usuarioAGuardar);
                        objEmail.EnviarEmail();
                    }
                    else
                    {
                        Response.Write("<script language=javascript>alert('Password No Modificada.')</script>");
                    }
                    Response.Redirect("Default.aspx", false);
                }
            }

            Response.Redirect("CambiarPassword.aspx", false);

        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            Response.Redirect("Default.aspx", false);
        }

        private void LimpiarCampos()
        {
            RegisterCurrentPassword.Text = "";
            RegisterPassword.Text = "";
            RegisterRePassword.Text = "";            
        }
    }
}