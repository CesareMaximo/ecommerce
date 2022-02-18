using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
  public  class Contacto
    {

        public int IdContacto { get; set; }

        public string Email { get; set; }

        public string Celular { get; set; }

        public string DescripcionProblema { get; set; }

        public bool Estado { get; set; }
    }
}
