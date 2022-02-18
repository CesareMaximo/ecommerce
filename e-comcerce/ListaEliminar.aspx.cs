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
    public partial class ListaEliminar : System.Web.UI.Page
    {
        public List<Productoss> ListaProducto { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ListaProducto = ProductoNegocio.getInstance().listaProductos();
        }
    }
}