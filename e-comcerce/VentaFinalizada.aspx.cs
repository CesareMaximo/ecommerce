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
            if (Session["usuario"] == null ||
               ((CapaDominio.Usuario)Session["usuario"]).TipoUsuario != CapaDominio.TipoUsuario.COMPRADOR)
            {
                Session.Add("error", "Debes loguearte para ingresar y/o tener los permisos adecuados para ingresar a esta pagina.");
                Response.Redirect("ErrorPermisos.aspx", false);
            }
            else
            {
                //if (!IsPostBack) 
                //{
                //    carrito = (List<Carro>)Session["carrito"];
                //    carrito = new List<Carro>();
                //    Session.Add("carrito", carrito);

                //    ID_Venta = DetalleVentaNegocio.getInstance().UltimoIdVenta();
                //}

                carrito = (List<Carro>)Session["carrito"];
                carrito = new List<Carro>();
                Session.Add("carrito", carrito);

                ID_Venta = DetalleVentaNegocio.getInstance().UltimoIdVenta();

                CapaNegocio.EmailService email = new CapaNegocio.EmailService();
                email.armarCorreoVenta(ID_Venta);
                email.EnviarEmail();
            }            
        }
    }
}