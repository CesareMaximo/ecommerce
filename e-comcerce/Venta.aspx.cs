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
    public partial class Venta : System.Web.UI.Page
    {
        public List<Carro> carrito { get; set; }

        public decimal total { get; set; }

        public List<FormaPago> listaFormaPago { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            carrito = new List<Carro>();
            carrito = (List<Carro>)Session["carrito"];

            total = 0;

            foreach (Carro pro in carrito)
            {
                total += pro.Producto.Precio * pro.Cantidad;
            }
            if (!IsPostBack)
            {
                listaFormaPago = FormaPagoNegocio.getInstance().listarFormaPago();

                dropFormaPago.DataSource = listaFormaPago;
                dropFormaPago.DataTextField = "Descripcion";
                dropFormaPago.DataValueField = "IdFormaPago";
                dropFormaPago.DataBind();
            }
           



        }


        protected void btnFinalizarVenta_Click(object sender, EventArgs e)
        {
            //Para Detalle de Venta
            int ID_Venta = 0;
            List<DetalleVenta> listaDetalle = new List<DetalleVenta>();
            DetalleVenta objDetalle = new DetalleVenta();
           
            //Para la venta
            Ventas objVenta = new Ventas();

            //  Este tiene que sacar del session el usuario NICOLAS LOPEZ 
            objVenta.IdUsuario = 1;
            //
            objVenta.IdFormaPago = int.Parse(dropFormaPago.SelectedItem.Value);
            objVenta.DescripcionVenta = txtAclaracion.Text;
            objVenta.DireccionEnvio = txtDireccionEnvio.Text;

            if (int.Parse(dplEnvio.SelectedItem.Value) == 1)
            {
                total = total + 1000;
                objVenta.EstadoEnvio = true;
                objVenta.EstadoRetiro = false;
            }
            else
            {
                if(int.Parse(dplEnvio.SelectedItem.Value) == 2)
                objVenta.EstadoEnvio = false;
                objVenta.EstadoRetiro = true;

            }

            objVenta.Total = total;

            bool ok = VentaNegocio.getInstance().FinalizarVenta(objVenta);

           

            ID_Venta = DetalleVentaNegocio.getInstance().UltimoIdVenta();

            foreach (Carro pro in carrito)
            {
                objDetalle.IdVenta = new Ventas();
                objDetalle.IdVenta.IdVenta = ID_Venta;
                objDetalle.IdProducto = new Productoss();
                objDetalle.IdProducto.IdProducto = pro.Producto.IdProducto;
                objDetalle.Precio = pro.Producto.Precio;

                objDetalle.Cantidad = pro.Cantidad;

                
                bool aux = DetalleVentaNegocio.getInstance().RegistrarDetalle(objDetalle);

            }

           

            Response.Redirect("VentaFinalizada.aspx");

        }
    }
}