using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDominio;
using CapaAccesoDatos;

namespace CapaDAO
{
    public class UsuarioDAO
    {

        #region "PATRON SINGLETON"
        private static UsuarioDAO daoUsuario = null;
        private static string Patron = "e-commerce";
        private UsuarioDAO() { }
        public static UsuarioDAO getInstance()
        {
            if (daoUsuario == null)
            {
                daoUsuario = new UsuarioDAO();
            }
            return daoUsuario;
        }
        #endregion

        public Usuario AccesoSistema(String user, String pass)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            Usuario objUsuario = null;
            SqlDataReader dr = null;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_ValidarUsuario", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", user);
                cmd.Parameters.AddWithValue("@clave", pass);
                cmd.Parameters.AddWithValue("@patron", Patron);
                conexion.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    objUsuario = new Usuario();
                    objUsuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"].ToString());
                    objUsuario.Email = dr["Usuario"].ToString();
                    objUsuario.Clave = dr["Clave"].ToString();
                    objUsuario.Estado = Convert.ToBoolean(dr["Estado"]);
                    objUsuario.TipoUsuario = (int)(dr["TipoUsuario"]) == 1 ? TipoUsuario.ADMIN : TipoUsuario.COMPRADOR;
                }
            }
            catch (Exception ex)
            {
                objUsuario = null;
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return objUsuario;
        }

        public Usuario BuscarUsuarioPorEmail(String email)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            Usuario objUsuario = new Usuario();

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_BuscarUsuarioPorEmail", con);
                cmd.Parameters.AddWithValue("@prmUsuario", email);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    objUsuario = new Usuario();
                    objUsuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"].ToString());
                    objUsuario.Email = dr["Usuario"].ToString();
                    objUsuario.Clave = dr["Clave"].ToString();
                    objUsuario.Nombre = dr["Nombre"].ToString();
                    objUsuario.Apellido = dr["Apellido"].ToString();
                    objUsuario.Documento = dr["Documento"].ToString();
                    objUsuario.Domicilio = dr["Domicilio"].ToString();
                    objUsuario.Celular = dr["Celular"].ToString();
                    objUsuario.Estado = Convert.ToBoolean(dr["Estado"]);
                    objUsuario.TipoUsuario = (int)(dr["TipoUsuario"]) == 1 ? TipoUsuario.ADMIN : TipoUsuario.COMPRADOR;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }

            return objUsuario;
        }

        public bool BuscarSiExisteUsuarioPorEmail(String email)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            Usuario objUsuario = new Usuario();
            int nResult = 0;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_BuscarSiExisteUsuarioPorEmail", con);
                cmd.Parameters.AddWithValue("@prmUsuario", email);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                nResult = (int)cmd.ExecuteScalar();
                if (nResult == 1) { return true; }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }

            return false;
        }

        public bool RegistrarUsuario(Usuario usuario)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_AgregarUsuario", con);
                cmd.Parameters.AddWithValue("@idTipoUsuario", usuario.TipoUsuario);
                cmd.Parameters.AddWithValue("@usuario", usuario.Email);
                cmd.Parameters.AddWithValue("@clave", usuario.Clave);
                cmd.Parameters.AddWithValue("@estado", usuario.Estado);
                cmd.Parameters.AddWithValue("@patron", Patron);

                cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@documento", usuario.Documento);
                cmd.Parameters.AddWithValue("@domicilio", usuario.Domicilio);
                cmd.Parameters.AddWithValue("@celular", usuario.Celular);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) response = true;

            }
            catch (Exception e)
            {
                response = false;
                throw e;
            }
            finally
            {
                con.Close();
            }

            return response;
        }

        //TODO listar, actualizar y eliminar Usuario SP.

        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> Lista = new List<Usuario>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_ListarUsuarios", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Usuario objUsuario = new Usuario();
                    objUsuario.Email = dr["Usuario"].ToString();
                    objUsuario.Nombre = dr["Nombre"].ToString();
                    objUsuario.Apellido = dr["Apellido"].ToString();
                    objUsuario.Documento = dr["Documento"].ToString();
                    objUsuario.Domicilio = dr["Domicilio"].ToString();
                    objUsuario.Celular = dr["Celular"].ToString();

                    Lista.Add(objUsuario);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.Close();
            }
            return Lista;
        }

        public bool ActualizarDatosUsuario(Usuario objUsuario)
        {
            bool ok = false;
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_ActualizarDatosUsuario", conexion);

                cmd.Parameters.AddWithValue("@prmUsuario", objUsuario.Email);
                cmd.Parameters.AddWithValue("@prmNombre", objUsuario.Nombre);
                cmd.Parameters.AddWithValue("@prmApellido", objUsuario.Apellido);
                cmd.Parameters.AddWithValue("@prmDocumento", objUsuario.Documento);
                cmd.Parameters.AddWithValue("@prmDomicilio", objUsuario.Domicilio);
                cmd.Parameters.AddWithValue("@prmCelular", objUsuario.Celular);

                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) ok = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return ok;
        }

        public bool EliminarUsuario(string email)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            bool ok = false;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_EliminarUsuario", conexion);
                cmd.Parameters.AddWithValue("@prmUsuario", email);

                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                cmd.ExecuteNonQuery();

                ok = true;

            }
            catch (Exception ex)
            {
                ok = false;
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return ok;
        }
    }
}