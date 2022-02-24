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
    public partial class SiteMaster : MasterPage
    {
        public List<Categoria> listaCategoria { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            listaCategoria = CategoriaNEGOCIO.getInstance().listaCategoria();
            if (!IsPostBack)
            {
                
/*
                dropCategoria.DataSource = listaCategoria;
                dropCategoria.DataTextField = "Descripcion";
                dropCategoria.DataValueField = "IdCategoria";
                dropCategoria.DataBind();
*/
            }

        }

        public bool EsSessionNull() {            
            if (Session["usuario"] == null) return true;
            else return false;
        }

        public bool EsUsuarioComprador() {
            if (((CapaDominio.Usuario)Session["usuario"]).TipoUsuario == CapaDominio.TipoUsuario.COMPRADOR) return true;
            else return false;
        }

        public bool EsUsuarioAdministrador()
        {
            if (((CapaDominio.Usuario)Session["usuario"]).TipoUsuario == CapaDominio.TipoUsuario.ADMIN) return true;
            else return false;
        }
    }
}