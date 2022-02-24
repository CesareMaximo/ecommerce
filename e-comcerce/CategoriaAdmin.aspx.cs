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
    public partial class CategoriaAdmin : System.Web.UI.Page
    {
        public List<Categoria> listaCategoria{ get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usuario"] == null ||
               ((CapaDominio.Usuario)Session["usuario"]).TipoUsuario != CapaDominio.TipoUsuario.ADMIN)
            {
                Session.Add("error", "Debes loguearte para ingresar y/o tener los permisos adecuados para ingresar a esta pagina.");
                Response.Redirect("ErrorLogin.aspx", false);
            }
            else
            {
                listaCategoria = CategoriaNEGOCIO.getInstance().listaCategoria();

                if (Request.QueryString["id"] != null)
                {
                    int idAlta = int.Parse(Request.QueryString["id"].ToString());

                    bool ok = CategoriaNEGOCIO.getInstance().DarAltaCategoria(idAlta);

                    if (ok == true)
                    {
                        Response.Redirect("CategoriaAdmin.aspx");
                    }
                }
            }            
        }
    }
}