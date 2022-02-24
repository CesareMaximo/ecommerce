using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaDominio;
using System.Data.SqlClient;

namespace CapaDAO
{
   public class AdminDAO
    {
        #region "PATRON SINGLETON"
        private static AdminDAO daoAdmin= null;
        private static string Patron = "e-commerce";
        private AdminDAO() { }
        public static AdminDAO getInstance()
        {
            if (daoAdmin== null)
            {
                daoAdmin = new AdminDAO();
            }
            return daoAdmin;
        }
        #endregion

        public List<Usuario> listaAdmin()
        {
            List<Usuario> lista = new List<Usuario>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_ListaAdmin",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {                   
                    Usuario objAdmin = new Usuario();
                    objAdmin.Email = dr["Usuario"].ToString();
                    objAdmin.Nombre = dr["Nombre"].ToString();
                    objAdmin.Apellido = dr["Apellido"].ToString();
                    objAdmin.Documento = dr["Documento"].ToString();
                    objAdmin.Domicilio = dr["Domicilio"].ToString();
                    objAdmin.Celular = dr["Celular"].ToString();
                    objAdmin.IdUsuario = Convert.ToInt32(dr["IdUsuario"].ToString());
                    objAdmin.Estado = Convert.ToBoolean(dr["Estado"].ToString());

                    lista.Add(objAdmin);
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
            return lista;

        }

        public bool EliminarAdmin (int idAdmin)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool ok = false;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_EliminarAdmin", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", idAdmin);
                con.Open();


                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) ok = true;

            }
            catch (Exception ex)
            {
                ok = false;
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return ok;
        }

        public bool DarAltaAdmin(int idAdmin)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool ok = false;
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_AltaAdmin", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", idAdmin);
                con.Open();


                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) ok = true;

            }
            catch (Exception ex)
            {
                ok = false;
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return ok;

        }

    }
}
