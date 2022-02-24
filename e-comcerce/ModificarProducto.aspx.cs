using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaDominio;
using CapaDAO;

namespace e_comcerce
{
    public partial class ModificarProducto : System.Web.UI.Page
    {
        public int IdProducto { get; set; }
        public List<Productoss> listaproducto { get; set; }

        public Productoss objProducto { get; set; }

        public Productoss aux { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null ||
               ((CapaDominio.Usuario)Session["usuario"]).TipoUsuario != CapaDominio.TipoUsuario.ADMIN)
            {
                Session.Add("error", "Debes loguearte para ingresar y/o tener los permisos adecuados para ingresar a esta pagina.");
                Response.Redirect("ErrorPermisos.aspx", false);
            }
            else
            {
                if (Request.QueryString["Id"] != null)
                {
                    IdProducto = Convert.ToInt32(Request.QueryString["Id"]);
                }
                listaproducto = (List<Productoss>)Session["listaproducto"];
                objProducto = listaproducto.Find(x => x.IdProducto == IdProducto);

                if (!IsPostBack)
                {
                    ddlCategoria.DataSource = CategoriaNEGOCIO.getInstance().listaCategoria();
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataValueField = "IdCategoria";
                    ddlCategoria.DataBind();

                    txtDescripcion.Text = objProducto.Descripcion;
                    txtPrecio.Text = objProducto.Precio.ToString();
                    txtStock.Text = objProducto.Stock.ToString();

                    txtURL.Text = objProducto.UrlImagen;
                }
            }                        
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            aux = new Productoss();
            aux.IdCategoria = new Categoria();
            aux.IdProducto = objProducto.IdProducto;
           aux.IdCategoria.IdCategoria = Convert.ToInt32( ddlCategoria.SelectedItem.Value);
            aux.Descripcion = txtDescripcion.Text;
            aux.Precio = Convert.ToDecimal(txtPrecio.Text);
            aux.Stock = Convert.ToInt32(txtStock.Text);
            aux.UrlImagen = txtURL.Text;
            bool ok = ProductoNegocio.getInstance().ModificarProducto(aux);

            Response.Redirect("ProductosAdmin.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductosAdmin.aspx");
        }
    }
}