using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using CapaAccesoDatos;
using System.Data.SqlClient;

namespace CapaDAO
{
   public class ProductoDAO
    {
        #region "PATRON SINGLETON"
        private static ProductoDAO daoProducto= null;
        private ProductoDAO() { }
        public static ProductoDAO getInstance()
        {
            if (daoProducto == null)
            {
               daoProducto = new ProductoDAO();
            }
            return daoProducto;
        }
        #endregion


        


        public bool RegistrarProducto(Productoss objProducto)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_AgregarProducto", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCategoria",objProducto.IdCategoria.IdCategoria);
                cmd.Parameters.AddWithValue("@descripcion", objProducto.Descripcion);
                cmd.Parameters.AddWithValue("@stock", objProducto.Stock);
                cmd.Parameters.AddWithValue("@precio", objProducto.Precio);
                cmd.Parameters.AddWithValue("@urlImagen", objProducto.UrlImagen);
                con.Open();

                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) response = true;


            }
            catch (Exception ex)
            {
                response = false;
                throw ex ;
            }
            finally
            {
                con.Close();
            }
            return response;
        }

        /*
        public List<Productoss> ListaProducto()
        {
            List<Productoss> Lista = new List<Productoss>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_ListaProducto", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Productoss obj = new Productoss();
                    obj.ID = (int)dr["ID"];
                    
                    obj.ID_Categoria.ID = (int)dr["ID_Categoria"];
                    obj.Descripcion = (string)dr["Descripcion"];
                    obj.Stock = (int)dr["Stock"];
                    obj.Precio = (decimal)dr["Precio"];
                    obj.URLimagen = (string)dr["UrlImagen"];

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
        */



        public bool ValidarStock(int idProducto, int cantidad)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            int aux=10;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_ValidarStock", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProducto", idProducto);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);

                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    aux = Convert.ToInt32(dr["r"].ToString());
                }

               
                if (aux == 1)
                {
                    return true;
                }
                else
                if(aux==0)
                {
                    return false;
                }

                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.Close();
            }

        }


        public List<Productoss> Lista()
        {
            List<Productoss> Lista = new List<Productoss>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                con = Conexion.getInstance().ConexionBD();

                cmd = new SqlCommand("SP_ListaProducto", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                dr = cmd.ExecuteReader();

                

                    while (dr.Read())
                    {
                        Productoss obj = new Productoss();
                        obj.IdProducto = Convert.ToInt32(dr["IdProducto"].ToString()) ;
                        obj.IdCategoria = new Categoria();
                        obj.IdCategoria.IdCategoria = Convert.ToInt32( dr["IdCategoria"].ToString());

                        obj.Descripcion = dr["Descripcion"].ToString();
                        obj.Stock = Convert.ToInt32( dr["Stock"].ToString());
                        obj.Precio = Convert.ToDecimal (dr["Precio"].ToString());
                        obj.UrlImagen = dr["UrlImagen"].ToString();

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

        public bool ModificarProducto(Productoss objProducto)
        {

            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_ModificarProducto", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                
                cmd.Parameters.AddWithValue("@idProducto", objProducto.IdProducto);
                cmd.Parameters.AddWithValue("@idCategoria", objProducto.IdCategoria.IdCategoria);
                cmd.Parameters.AddWithValue("@descripcion", objProducto.Descripcion);
                cmd.Parameters.AddWithValue("@stock", objProducto.Stock);
                cmd.Parameters.AddWithValue("@precio", objProducto.Precio);
                cmd.Parameters.AddWithValue("@urlImagen", objProducto.UrlImagen);
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

        public bool EliminarProducto(int IdProducto)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_EliminarProducto", con);
                cmd.Parameters.AddWithValue("@idProducto", IdProducto);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

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

        public bool BajaStock(int idProducto)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_BajaStock", con);
                cmd.Parameters.AddWithValue("@idProducto", idProducto);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

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

        public bool AltaStock(int idProducto)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_AltaStock", con);
                cmd.Parameters.AddWithValue("@idProducto", idProducto);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

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
