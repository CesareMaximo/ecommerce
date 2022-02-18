using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using System.Data.SqlClient;
using CapaAccesoDatos;

namespace CapaDAO
{
    public   class CategoriaDAO

    {
        #region "PATRON SINGLETON"
        private static CategoriaDAO daoCategoria= null;
        private CategoriaDAO() { }
        public static CategoriaDAO getInstance()
        {
            if (daoCategoria == null)
            {
                daoCategoria = new CategoriaDAO();
            }
            return daoCategoria;
        }
        #endregion

        public List<Categoria> listarCategoria()
        {

            List<Categoria> Lista = new List<Categoria>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {

                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_ListaCategoria", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Categoria obj = new Categoria();
                    obj.IdCategoria = Convert.ToInt32(dr["IdCategoria"].ToString());
                    obj.Descripcion = dr["Descripcion"].ToString();

                    Lista.Add(obj);

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

        public List<Categoria> listarCategoriaDeBaja()
        {

            List<Categoria> Lista = new List<Categoria>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {

                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_ListaCategoriaDeBaja", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Categoria obj = new Categoria();
                    obj.IdCategoria = Convert.ToInt32(dr["IdCategoria"].ToString());
                    obj.Descripcion = dr["Descripcion"].ToString();

                    Lista.Add(obj);

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

        public bool EliminarCategoria (int idCategoria)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_EliminarCategoria", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcategoria", idCategoria);
                con.Open();

                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) response = true;
            }
            catch (Exception ex)
            {
                response = false;
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return response;
        }

        public bool DarAltaCategoria(int idCategoria)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_DarDeAltaCategoria", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcategoria", idCategoria);
                con.Open();

                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) response = true;

            }
            catch (Exception ex)
            {
                response = false;

                throw ex;
            }
            finally
            {
                con.Close();
            }
            return response;
        }
        public bool AgregarCategoria (Categoria objCategoria)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_AgregarCategoria", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", objCategoria.Descripcion);
                con.Open();

                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) response = true;


            }
            catch (Exception ex)
            {
                response = false;
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return response;
        }

    }
}
