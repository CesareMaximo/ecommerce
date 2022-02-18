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

    }
}
