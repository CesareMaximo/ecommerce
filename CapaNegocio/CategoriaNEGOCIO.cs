using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDAO;
using CapaDominio;

namespace CapaNegocio
{
   public class CategoriaNEGOCIO
    {
        #region "PATRON SINGLETON"
        private static CategoriaNEGOCIO obj= null;
        private CategoriaNEGOCIO() { }
        public static CategoriaNEGOCIO getInstance()
        {
            if (obj == null)
            {
                obj= new CategoriaNEGOCIO();
            }
            return obj;
        }
        #endregion


        public List<Categoria> listaCategoria()
        {
            try
            {
                return CategoriaDAO.getInstance().listarCategoria();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Categoria> listaCategoriaDeBaja()
        {
            try
            {
                return CategoriaDAO.getInstance().listarCategoriaDeBaja();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool EliminarCategoria(int idCategoria)
        {
            try
            {
                return CategoriaDAO.getInstance().EliminarCategoria(idCategoria);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool DarAltaCategoria(int idCategoria)
        {
            try
            {
                return CategoriaDAO.getInstance().DarAltaCategoria(idCategoria);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool AgregarCategoria(Categoria objCategoria)
        {
            try
            {
                return CategoriaDAO.getInstance().AgregarCategoria(objCategoria);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
