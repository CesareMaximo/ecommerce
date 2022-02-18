using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDAO;
using CapaDominio;

namespace CapaNegocio
{
    public class UsuarioNegocio
    {
        #region "PATRON SINGLETON"
        private static UsuarioNegocio objUsuario = null;
        private UsuarioNegocio() { }
        public static UsuarioNegocio getInstance()
        {
            if (objUsuario == null)
            {
                objUsuario = new UsuarioNegocio();
            }
            return objUsuario;
        }
        #endregion

        public Usuario AccesoSistema(String user, String pass)
        {
            try
            {
                return UsuarioDAO.getInstance().AccesoSistema(user, pass);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool BuscarSiExisteUsuarioPorEmail(String usuario)
        {
            try
            {
                return UsuarioDAO.getInstance().BuscarSiExisteUsuarioPorEmail(usuario);
            }
            catch (Exception e)
            {
                throw e;

            }
        }

        public Usuario BuscarUsuarioPorEmail(String usuario)
        {
            try
            {
                return UsuarioDAO.getInstance().BuscarUsuarioPorEmail(usuario);
            }
            catch (Exception e)
            {
                throw e;

            }
        }

        public bool RegistrarUsuario(Usuario usuario)
        {
            try
            {
                UsuarioDAO.getInstance().RegistrarUsuario(usuario);
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }
        }

        public List<Usuario> ListarUsuarios()
        {
            try
            {
                return UsuarioDAO.getInstance().ListarUsuarios();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool ActualizarDatosUsuario(Usuario objUsuario)
        {
            try
            {
                return UsuarioDAO.getInstance().ActualizarDatosUsuario(objUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EliminarUsuario(string email)
        {
            try
            {
                return UsuarioDAO.getInstance().EliminarUsuario(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}