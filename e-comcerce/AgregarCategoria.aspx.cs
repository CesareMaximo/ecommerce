using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using CapaDominio;
using CapaNegocio;
using System.Web.UI.WebControls;

namespace e_comcerce
{
    public partial class AgregarCategoria : System.Web.UI.Page
    {
        public Categoria objCategoria = new Categoria();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

         
            objCategoria.Descripcion = txtDescripcion.Text;

           
            bool ok = CategoriaNEGOCIO.getInstance().AgregarCategoria(objCategoria);
            if (ok == true)
            {
                Response.Redirect("CategoriaAdmin.aspx");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoriaAdmin.aspx");
        }
    }
}