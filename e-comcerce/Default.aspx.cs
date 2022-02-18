using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDominio;

namespace e_comcerce
{
    public partial class _Default : Page
    {
        public string aux { get; set; }
        public string urlimagen { get; set; }
        public string contacto { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            aux = "Productos.aspx";
            urlimagen = "https://www.diariodesevilla.es/2021/10/13/wappissima/actualidad/Peninsula-Vintage-Clothing-tiendas-vintage_1619548404_145419545_1200x675.png";
            contacto = "Contact.aspx";

            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("ErrorLogin.aspx", false);
            }            

            if (!Page.IsPostBack) { }
        }
    }
}