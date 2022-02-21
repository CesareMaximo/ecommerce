using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaDominio;

namespace e_comcerce
{
    public partial class EliminarAdmin : System.Web.UI.Page
    {
        public List<AdminComerce> listaAdmin = new List<AdminComerce>();
        public AdminComerce objAdmin = new AdminComerce();
        protected void Page_Load(object sender, EventArgs e)
        {
            listaAdmin = AdminNegocio.getInstance().listaAdmin();

            if (Request.QueryString["id"] != null)
            {
                int idAdmin = int.Parse(Request.QueryString["id"].ToString());

                foreach (AdminComerce item in listaAdmin)
                {
                    if(item.IdAdminCommerce == idAdmin)
                    {
                        objAdmin = item;
                    }
                }
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            bool ok = AdminNegocio.getInstance().EliminarAdmin(objAdmin.IdAdminCommerce);

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