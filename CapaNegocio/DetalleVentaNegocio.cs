using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using CapaDAO;

namespace CapaNegocio
{
    
    public class DetalleVentaNegocio
    {

        #region "PATRON SINGLETON"
        private static DetalleVentaNegocio objDetalle= null;
        private DetalleVentaNegocio() { }
        public static DetalleVentaNegocio getInstance()
        {
            if (objDetalle == null)
            {
                objDetalle = new DetalleVentaNegocio();
            }
            return objDetalle;
        }
        #endregion

        public int UltimoIdVenta()
        {
            try
            {
                return DetalleVentaDAO.getInstance().UltimoIdVenta();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool RegistrarDetalle(DetalleVenta objDetalle)
        {
            try
            {
                return DetalleVentaDAO.getInstance().RegistrarDetalle(objDetalle);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        } 

        public List<DetalleVenta> ListaDetalleVenta(int idVenta)
        {
            try
            {
                return DetalleVentaDAO.getInstance().listaDetalleVenta(idVenta);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
