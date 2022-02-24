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
    public partial class DetalleVentaRegistro : System.Web.UI.Page
    {
        public List<DetalleVenta> listaDetalle = new List<DetalleVenta>();

        public decimal Total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null
                //|| ((CapaDominio.Usuario)Session["usuario"]).TipoUsuario != CapaDominio.TipoUsuario.ADMIN
                )
            {
                Session.Add("error", "Debes loguearte para ingresar y/o tener los permisos adecuados para ingresar a esta pagina.");
                Response.Redirect("ErrorLogin.aspx", false);
            }
            else
            {
                if (Request.QueryString["id"] != null)
                {
                    int idVenta = int.Parse(Request.QueryString["id"].ToString());

                    listaDetalle = DetalleVentaNegocio.getInstance().ListaDetalleVenta(idVenta);
                }
                foreach (DetalleVenta item in listaDetalle)
                {
                    Total += item.Precio * item.Cantidad;
                }
            }            
        }
    }
}