using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using CapaDominio;

namespace CapaNegocio
{
  public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("tiendaberreta@gmail.com", "tiendaberreta123");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        public void armarCorreoVenta(int idVenta)
        {
            Ventas objVenta = new Ventas();
            objVenta = VentaNegocio.getInstance().VentaxID(idVenta);
            Usuario objUsuario = new Usuario();
            objUsuario = UsuarioNegocio.getInstance().UsuarioxID(objVenta.IdUsuario);

            email = new MailMessage();
            email.From = new MailAddress("noresponder@tiendaberreta.com");
            email.To.Add(objUsuario.Email);

            email.Subject = "COMPRA NUMERO N°" + idVenta;
            email.IsBodyHtml = true;
            email.Body = "<h1> El numero de su compra es #" + idVenta + "</h1>" +
                "<hr/>" +
                "<h2>¡Hola " + objUsuario.Apellido+ " "+ objUsuario.Nombre + ", gracias por tu compra! </h2>" +
                "<h4>DETALLE DEL PEDIDO</h4>" +
                   "Fecha de la compra: " + objVenta.FechaVenta + "<br/>" +
                 "Total: $" + objVenta.Total + "<br/>" +
                  "Su direccion donde llegará el pedido (si corresponde): " + objVenta.DireccionEnvio + "<br/>" +
                " Podes ver todos los detalles de esta compra, ingresando al e-commerce, haciendo click en el boton Mis Compras y busca el numero "+ idVenta+ ". <br/> <br/>" +
                " <img src=\"https://vilmanunez.com/wp-content/uploads/2018/06/tiendas-online.png\" width =\"200\" > ";




        }
        public void correoContacto(Contacto objContacto)
        {
            Usuario objusuario = new Usuario();
            objusuario = UsuarioNegocio.getInstance().BuscarUsuarioPorEmail(objContacto.Email);
            email = new MailMessage();
            email.From = new MailAddress("noresponder@tiendaberreta.com");
            email.To.Add(objContacto.Email);

            email.Subject = "CONTACTO TIENDABERRETA.COM" ;
            email.IsBodyHtml = true;
            email.Body = "<h1>¡Hola " + objusuario.Nombre +  ", hemos recibido su reclamo! </h1>" +
                "<hr/>" +
                "<h2>En las proximas 24 horas se contactaran contigo a travez de WhatsApp por el numero: "+ objContacto.Celular + "</h2>" +
                "<h4>SU RECLAMO: </h4>" +
                   ""+objContacto.DescripcionProblema +" ";

        }
        public void correoCambioPass(Usuario objUsuario)
        {
           
            email = new MailMessage();
            email.From = new MailAddress("noresponder@tiendaberreta.com");
            email.To.Add(objUsuario.Email);

            email.Subject = "SU CONTRASEÑA FUE CAMBIADA EXITOSAMENTE";
            email.IsBodyHtml = true;
            email.Body = "<h1>¡Hola " + objUsuario.Apellido+" "+ objUsuario.Nombre + ", su contraseña a sido cambiada! </h1>" +
                "<hr/>" +
                "<h2>Si usted no cambió su contraseña recientemente, por favor comuniquese a este mail con todos sus datos: tiendaberreta@gmail.com </h2>" +
                "<h4>Ningun representante va a pedir su email y contraseña, por favor no pasar su usuario a personas desconocidas  </h4>" +
                   " ";

        }
        public void EnviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
