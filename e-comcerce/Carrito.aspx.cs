using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDAO;
using CapaDominio;
using CapaNegocio;

namespace e_comcerce
{
    public partial class Carrito : System.Web.UI.Page
    {
        public List<Carro> carrito { get; set; }

        public decimal total  { get; set; }

        public int aux =0;

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
                carrito = new List<Carro>();
                carrito = (List<Carro>)Session["carrito"];

                if (carrito != null)
                {
                    foreach (Carro item in carrito)
                    {
                        total += item.Producto.Precio * item.Cantidad;
                    }
                }

                if (Request.QueryString["Id"] != null)
                {
                    string id = Request.QueryString["Id"].ToString();

                    int idAux = int.Parse(id);

                    foreach (Carro pro2 in carrito)
                    {
                        if (pro2.Producto.IdProducto == Convert.ToInt32(id))
                        {
                            total = total - pro2.Producto.Precio;
                            if (pro2.Cantidad > 1)
                            {
                                pro2.Cantidad--;
                                bool ok = ProductoNegocio.getInstance().AltaStock(idAux);
                            }
                            else
                            {
                                aux = 1;
                            }

                        }
                    }

                    if (aux == 1)
                    {
                        carrito.Remove(carrito.Find(x => x.Producto.IdProducto == int.Parse(id)));

                        bool ok = ProductoNegocio.getInstance().AltaStock(idAux);
                    }

                    Session.Add("carrito", carrito);
                }
            }
        }

        protected void btnIniciarCompra_Click(object sender, EventArgs e)
        {}
    }
}