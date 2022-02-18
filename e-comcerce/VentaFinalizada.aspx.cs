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
    public partial class VentaFinalizada : System.Web.UI.Page
    {
       public List<Carro> carrito { get; set; }
        public int ID_Venta = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            carrito = (List<Carro>)Session["carrito"];
            carrito = new List<Carro>();
            Session.Add("carrito", carrito);


            ID_Venta = DetalleVentaNegocio.getInstance().UltimoIdVenta();
        }
    }
}