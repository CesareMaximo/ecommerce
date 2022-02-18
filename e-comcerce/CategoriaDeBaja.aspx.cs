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
    public partial class CategoriaDeBaja : System.Web.UI.Page
    {
        public List<Categoria> listaCategoriaBaja  { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listaCategoriaBaja = CategoriaNEGOCIO.getInstance().listaCategoriaDeBaja();
            }
            



        }
    }
}