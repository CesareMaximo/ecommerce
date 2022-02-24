using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using CapaDAO;

namespace CapaNegocio
{
 public   class VentaNegocio
    {

        #region "PATRON SINGLETON"
        private static VentaNegocio objVenta= null;
        private VentaNegocio() { }
        public static VentaNegocio getInstance()
        {
            if (objVenta== null)
            {
                objVenta = new VentaNegocio();
            }
            return objVenta;
        }
        #endregion

        public bool FinalizarVenta(Ventas objVenta)
        {
            try
            {
                return VentaDAO.getInstance().FinalizarVenta(objVenta); 
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Ventas> ListaVentaDespacho()
        {
            try
            {
                return VentaDAO.getInstance().ListaVentaDespacho();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool ConcretarVenta(int idVenta)
        {
            try
            {
                return VentaDAO.getInstance().ConcretarVenta(idVenta);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Ventas> ListaVentas()
        {
            try
            {
                return VentaDAO.getInstance().ListaVentas();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Ventas> listaVentaxUsuario(int idUsuario)
        {
            try
            {
                return VentaDAO.getInstance().listaVentaxUsuario(idUsuario);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Ventas VentaxID(int idVenta)
        {
            try
            {
                return VentaDAO.getInstance().VentaxID(idVenta);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
