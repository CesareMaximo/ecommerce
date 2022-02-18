using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDominio;
using CapaNegocio;
using System.Web.Services;

namespace e_comcerce
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Session.Add("error", "Debes desloguearte para registrarte un nuevo usuario.");
                Response.Redirect("Default.aspx", false);
            }

            //TODO Checkear este if.
            if (!Page.IsPostBack)
            { }
            lblError.Text = "";
            lblErrorContrasenia.Text = "";
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (RegisterNombre.Text == "" ||
                RegisterApellido.Text == "" ||
                RegisterDNI.Text == "" ||
                RegisterUsuario.Text == "" ||
                RegisterPassword.Text == "" ||
                RegisterRePassword.Text == "")
            {
                lblError.Text = "Ningun campo puede quedar vacio.";
            }
            else
            {
                if (RegisterPassword.Text != RegisterRePassword.Text)
                {
                    lblErrorContrasenia.Text = "Las contrasenias no coinciden.";
                }
                else
                {
                    bool existeUsuario = UsuarioNegocio.getInstance().BuscarSiExisteUsuarioPorEmail(RegisterUsuario.Text);

                    if (!existeUsuario)
                    {
                        Usuario usuarioAGuardar = new Usuario(RegisterUsuario.Text, RegisterPassword.Text,
                                                                true, false, RegisterNombre.Text, RegisterApellido.Text,
                                                                RegisterDNI.Text, RegisterDomicilio.Text, RegisterCelular.Text);
                        bool usuarioRegistrado = UsuarioNegocio.getInstance().RegistrarUsuario(usuarioAGuardar);
                        if (usuarioRegistrado == true)
                        {
                            Response.Write("<script>alert('Usuario registrado correctamente.')</script>");
                            Response.Redirect("Login.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('Usuario No Registrado.')</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Nombre de usuario ya registrado.')</script>");
                    }
                }
            }
        }
    }
}