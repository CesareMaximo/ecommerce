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
    public partial class EliminarFormaPago : System.Web.UI.Page
    {
        public FormaPago objFormaPago = new FormaPago();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usuario"] == null ||
               ((CapaDominio.Usuario)Session["usuario"]).TipoUsuario != CapaDominio.TipoUsuario.ADMIN)
            {
                Session.Add("error", "Debes loguearte para ingresar y/o tener los permisos adecuados para ingresar a esta pagina.");
                Response.Redirect("ErrorPermisos.aspx", false);
            }
            else
            {
                if (Request.QueryString["id"] != null)
                {
                    int idFP = int.Parse(Request.QueryString["id"].ToString());
                    List<FormaPago> listaForma = new List<FormaPago>();
                    listaForma = FormaPagoNegocio.getInstance().listarFormaPagoGeneral();

                    foreach (FormaPago item in listaForma)
                    {
                        if (item.IdFormaPago == idFP)
                        {
                            objFormaPago = item;
                        }
                    }
                }

            }

           
            

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            bool ok = FormaPagoNegocio.getInstance().EliminarFormaPago(objFormaPago.IdFormaPago);
            if (ok == true)
            {
                Response.Redirect("AdminFormaPago.aspx");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminFormaPago.aspx");
        }
    }
}