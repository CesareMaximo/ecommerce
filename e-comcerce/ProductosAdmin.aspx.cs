using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDAO;
using CapaDominio;
using CapaNegocio;

namespace e_comcerce
{
    public partial class ProductosAdmin : System.Web.UI.Page
    {
     public   List<Productoss> ListaProducto { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListaProducto = ProductoNegocio.getInstance().listaProductos();
                Session.Add("listaproducto", ListaProducto);

            }
        }
    }
}