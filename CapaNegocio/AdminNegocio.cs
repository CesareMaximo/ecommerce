using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using CapaDAO;

namespace CapaNegocio
{
    public class AdminNegocio
    {
        #region "PATRON SINGLETON"
        private static AdminNegocio objAdmin= null;
        private AdminNegocio() { }
        public static AdminNegocio getInstance()
        {
            if (objAdmin == null)
            {
                objAdmin = new AdminNegocio();
            }
            return objAdmin;
        }
        #endregion


        public List<AdminComerce> listaAdmin()
        {
            try
            {
                return AdminDAO.getInstance().listaAdmin();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool EliminarAdmin(int idAdmin)
        {
            try
            {
                return AdminDAO.getInstance().EliminarAdmin(idAdmin);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool DarAltaAdmin(int idAdmin)
        {
            try
            {
                return AdminDAO.getInstance().DarAltaAdmin(idAdmin);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
