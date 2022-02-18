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
    public partial class RegistroVentas : System.Web.UI.Page
    {
        public List<Ventas> listaVentas = new List<Ventas>();
        protected void Page_Load(object sender, EventArgs e)
        {
            listaVentas = VentaNegocio.getInstance().ListaVentas();
        }
    }
}