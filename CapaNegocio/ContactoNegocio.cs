using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDAO;
using CapaDominio;

namespace CapaNegocio
{
    public class ContactoNegocio
    {

        #region "PATRON SINGLETON"
        private static ContactoNegocio objContacto= null;
        private ContactoNegocio() { }
        public static ContactoNegocio getInstance()
        {
            if (objContacto== null)
            {
                objContacto = new ContactoNegocio();
            }
            return objContacto;
        }
        #endregion

        public bool RegistrarConsulta(Contacto objContacto)
        {
            try
            {
                return ContactoDAO.getInstance().RegistrarConsulta(objContacto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
