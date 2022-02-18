using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using CapaDominio;
using CapaNegocio;

namespace e_comcerce
{
    public partial class PerfilUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            //TODO Checkear este if.
            if (!Page.IsPostBack)
            {
                string email = Session["userName"].ToString();
                Usuario usuario = UsuarioNegocio.getInstance().BuscarUsuarioPorEmail(email);

                PerfilNombre.Text = usuario.Nombre;
                PerfilApellido.Text = usuario.Apellido;
                PerfilDNI.Text = usuario.Documento;
                PerfilDomicilio.Text = usuario.Domicilio;
                PerfilCelular.Text = usuario.Celular;
                PerfilEmail.Text = usuario.Email;
            }
            lblError.Text = "";
            lblErrorContrasenia.Text = "";

        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (PerfilNombre.Text == "" ||
                PerfilApellido.Text == "" ||
                PerfilDNI.Text == "" ||
                PerfilDomicilio.Text == "" ||
                PerfilCelular.Text == "")
            {
                lblError.Text = "Ningun campo puede quedar vacio.";
            }
            else
            {
                Usuario usuarioAGuardar = new Usuario(PerfilEmail.Text, PerfilNombre.Text, PerfilApellido.Text,
                                                      PerfilDNI.Text, PerfilDomicilio.Text, PerfilCelular.Text);

                bool usuarioModificado = UsuarioNegocio.getInstance().ActualizarDatosUsuario(usuarioAGuardar);

                if (usuarioModificado)
                {
                    Response.Write("<script language=javascript>alert('Usuario Modificado Correctamente.')</script>");
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Usuario No Modificado.')</script>");
                }
                Response.Redirect("Default.aspx", false);
            }
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            Response.Redirect("Default.aspx", false);
        }

        protected void BtnEliminarCuenta_Click(object sender, EventArgs e)
        {

            Usuario usuarioAEliminar = new Usuario(PerfilEmail.Text, PerfilNombre.Text, PerfilApellido.Text,
                                                      PerfilDNI.Text, PerfilDomicilio.Text, PerfilCelular.Text);

            bool usuarioEliminado = UsuarioNegocio.getInstance().EliminarUsuario(PerfilEmail.Text);

            if (usuarioEliminado)
            {
                Response.Write("<script language=javascript>alert('Usuario Eliminado Correctamente.')</script>");
                HttpContext.Current.Session.Clear();
                HttpContext.Current.Session.Abandon();
                Response.Redirect("Login.aspx", false);
            }
            else
            {
                Response.Write("<script language=javascript>alert('Usuario No Eliminado.')</script>");
                Response.Redirect("Default.aspx", false);
            }

        }

        private void LimpiarCampos()
        {
            PerfilNombre.Text = "";
            PerfilApellido.Text = "";
            PerfilDNI.Text = "";
            PerfilDomicilio.Text = "";
            PerfilCelular.Text = "";
            PerfilEmail.Text = "";
        }
    }
}