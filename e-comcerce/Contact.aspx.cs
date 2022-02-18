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
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            Contacto objContacto = new Contacto();

            objContacto.Email = txtEmail.Text;
            objContacto.Celular = txtCelular.Text;
            objContacto.DescripcionProblema = txtDescripcion.Text;

            bool ok = ContactoNegocio.getInstance().RegistrarConsulta(objContacto);

            if (ok == true)
            {
                Response.Redirect("Productos.aspx");
            }

        }
    }
}