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
    public partial class EliminarCategoria : System.Web.UI.Page
    {
        public List<Categoria> listaCategoria{ get; set; }

        public int idCat;

        public Categoria objCategoria = new Categoria();
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
                    string idCategoria = Request.QueryString["id"].ToString();
                    idCat = int.Parse(idCategoria);

                    foreach (Categoria item in listaCategoria)
                    {
                        if (idCat == item.IdCategoria)
                        {
                            objCategoria = item;
                        }
                    }
                }
            }            
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            bool ok = CategoriaNEGOCIO.getInstance().EliminarCategoria(objCategoria.IdCategoria);
            Response.Redirect("CategoriaAdmin.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoriaAdmin.aspx");
        }
    }
}