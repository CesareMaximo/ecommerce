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
    public partial class ComprasCliente : System.Web.UI.Page
    {
        public List<Ventas> listaVentas = new List<Ventas>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int idUsuario = int.Parse(Request.QueryString["id"].ToString());

                listaVentas = VentaNegocio.getInstance().listaVentaxUsuario(idUsuario);
            }
        }
    }
}