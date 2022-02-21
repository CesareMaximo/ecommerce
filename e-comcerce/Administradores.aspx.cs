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
    public partial class Administradores : System.Web.UI.Page
    {
        public List<AdminComerce> listaAdmin = new List<AdminComerce>();
        protected void Page_Load(object sender, EventArgs e)
        {
            listaAdmin = AdminNegocio.getInstance().listaAdmin();
        }
    }
}