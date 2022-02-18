using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
  public  class DetalleVenta
    {
        public int IdDetalleVenta { get; set; }
        public Ventas IdVenta { get; set; }

        public Productoss IdProducto { get; set; }

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }

        public bool Estado { get; set; }
    }
}
