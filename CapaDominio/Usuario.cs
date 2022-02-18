using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public enum TipoUsuario
    {
        ADMIN = 1,
        COMPRADOR = 2
    }
    public class Usuario
    {
        public int IdUsuario { get; set; }

        public string Email { get; set; }
        public string Clave { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Documento { get; set; }

        public string Domicilio { get; set; }

        public string Celular { get; set; }

        public bool Estado { get; set; }

        public TipoUsuario TipoUsuario { get; set; }

        public Usuario() { }

        public Usuario(string email, string clave, bool estado, bool admin)
        {
            Email = email;
            Clave = clave;
            TipoUsuario = admin ? TipoUsuario.ADMIN : TipoUsuario.COMPRADOR;
        }

        public Usuario(string email, string clave, bool estado, bool admin,
            string nombre, string apellido, string documento, string domicilio, string celular)
        {
            Email = email;
            Clave = clave;
            TipoUsuario = admin ? TipoUsuario.ADMIN : TipoUsuario.COMPRADOR;
            Nombre = nombre;
            Apellido = apellido;
            Documento = documento;
            Domicilio = domicilio;
            Celular = celular;
            Estado = true;
        }

        public Usuario(string email, string nombre, string apellido, string documento, string domicilio, string celular)
        {
            Email = email;
            Nombre = nombre;
            Apellido = apellido;
            Documento = documento;
            Domicilio = domicilio;
            Celular = celular;
            Estado = true;
        }
    }
}