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
    public partial class AgregarAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null ||
               ((CapaDominio.Usuario)Session["usuario"]).TipoUsuario != CapaDominio.TipoUsuario.ADMIN)
            {
                Session.Add("error", "Debes loguearte para ingresar y/o tener los permisos adecuados para ingresar a esta pagina.");
                Response.Redirect("ErrorPermisos.aspx", false);
            }            

            if (!Page.IsPostBack) { }
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
                                                                true, true, RegisterNombre.Text, RegisterApellido.Text,
                                                                RegisterDNI.Text, RegisterDomicilio.Text, RegisterCelular.Text);
                        bool usuarioRegistrado = UsuarioNegocio.getInstance().RegistrarUsuario(usuarioAGuardar);
                        if (usuarioRegistrado == true)
                        {
                            Response.Write("<script>alert('Usuario Administrador registrado correctamente.')</script>");
                            Response.Redirect("Administradores.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('Usuario Administrador No Registrado.')</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Nombre de usuario Administrador ya registrado.')</script>");
                    }
                }
            }
        }
    }
}