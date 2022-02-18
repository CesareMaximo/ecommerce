using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaDAO;
using CapaDominio;

namespace CapaNegocio
{
    public class ProductoNegocio
    {

        #region "PATRON SINGLETON"
        private static ProductoNegocio objProducto= null;
        private ProductoNegocio() { }
        public static ProductoNegocio getInstance()
        {
            if (objProducto == null)
            {
                objProducto = new ProductoNegocio();
            }
            return objProducto;
        }
        #endregion

        public bool ValidarStock(int idProducto,int cantidad)
        {
            try
            {
                return ProductoDAO.getInstance().ValidarStock(idProducto, cantidad);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool RegistrarProducto(Productoss objProducto)
        {
            try
            {
                ProductoDAO.getInstance().RegistrarProducto(objProducto);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public List<Productoss> listaProductos()
        {
            try
            {
              return  ProductoDAO.getInstance().Lista();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool ModificarProducto(Productoss objproducto)
        {
            try
            {
                return ProductoDAO.getInstance().ModificarProducto(objproducto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool EliminarProducto(int idProducto)
        {
            try
            {
                return ProductoDAO.getInstance().EliminarProducto(idProducto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool BajaStock(int idProducto)
        {
            try
            {
                return ProductoDAO.getInstance().BajaStock(idProducto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool AltaStock(int idProducto)
        {
            try
            {
                return ProductoDAO.getInstance().AltaStock(idProducto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
