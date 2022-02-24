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
    public partial class ConfirmarEliminacion : System.Web.UI.Page
    {
        public List<Productoss> ListaProducto { get; set; }

        public Productoss objProducto { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usuario"] == null
                //|| ((CapaDominio.Usuario)Session["usuario"]).TipoUsuario != CapaDominio.TipoUsuario.ADMIN
                //|| ((CapaDominio.Usuario)Session["usuario"]).TipoUsuario != CapaDominio.TipoUsuario.COMPRADOR
                )
            {
                Session.Add("error", "Debes loguearte para ingresar y/o tener los permisos adecuados para ingresar a esta pagina.");
                Response.Redirect("ErrorPermisos.aspx", false);
            }
            else
            {
                ListaProducto = ProductoNegocio.getInstance().listaProductos();

                if (Request.QueryString["IdProducto"] != null)
                {
                    string id = Request.QueryString["IdProducto"].ToString();
                }
            }
        }
    }
}