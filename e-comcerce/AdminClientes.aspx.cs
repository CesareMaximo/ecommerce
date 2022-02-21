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
    public partial class AdminClientes : System.Web.UI.Page
    {
        public List<Usuario> listaUsuario = new List<Usuario>();
        protected void Page_Load(object sender, EventArgs e)
        {
            listaUsuario = UsuarioNegocio.getInstance().ListarUsuarios();
        }
    }
}