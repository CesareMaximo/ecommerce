using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDAO;
using CapaDominio;
namespace CapaNegocio
{
   public class FormaPagoNegocio
    {

        #region "PATRON SINGLETON"
        private static FormaPagoNegocio objFormaPago= null;
        private FormaPagoNegocio() { }
        public static FormaPagoNegocio getInstance()
        {
            if (objFormaPago == null)
            {
                objFormaPago = new FormaPagoNegocio();
            }
            return objFormaPago;
        }
        #endregion

        public List<FormaPago> listarFormaPago()
        {
            try
            {
                return FormaPagoDAO.getInstance().listarformapago();
            }
            catch (Exception ex )
            {

                throw ex;
            }
        }

        public List<FormaPago> listarFormaPagoGeneral()
        {
            try
            {
                return FormaPagoDAO.getInstance().listarformapagoGeneral();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool EliminarFormaPago(int idFP)
        {
            try
            {
                return FormaPagoDAO.getInstance().EliminarFormaPago(idFP);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool AltaFormaPago(int idFP)
        {
            try
            {
                return FormaPagoDAO.getInstance().AltaFormaPago(idFP);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool RegistrarFormaPago(string Descripcion)
        {
            try
            {
                return FormaPagoDAO.getInstance().RegistrarFormaPago(Descripcion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
