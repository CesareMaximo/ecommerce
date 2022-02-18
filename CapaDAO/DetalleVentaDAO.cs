using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CapaDominio;
using CapaAccesoDatos;


namespace CapaDAO
{
   public class DetalleVentaDAO
    {
        #region "PATRON SINGLETON"
        private static DetalleVentaDAO daoDetalleVenta = null;
        private DetalleVentaDAO() { }
        public static DetalleVentaDAO getInstance()
        {
            if (daoDetalleVenta == null)
            {
                daoDetalleVenta = new DetalleVentaDAO();
            }
            return daoDetalleVenta;
        }
        #endregion

        public int UltimoIdVenta()
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            int ID=0;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_UltimoIdVenta", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    ID = Convert.ToInt32(dr["IdVenta"].ToString()); //IdVenta
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
            return ID;
        }

        public bool RegistrarDetalle(DetalleVenta objDetalle)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;
            
                try
                {
                    con = Conexion.getInstance().ConexionBD();
                    cmd = new SqlCommand("SP_RegistrarDetalle", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idVenta", objDetalle.IdVenta.IdVenta);
                    cmd.Parameters.AddWithValue("@idProducto", objDetalle.IdProducto.IdProducto);
                    cmd.Parameters.AddWithValue("@precio", objDetalle.Precio);
                    cmd.Parameters.AddWithValue("@cantidad", objDetalle.Cantidad);


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

        public List<DetalleVenta> listaDetalleVenta(int idVenta )
        {
            List<DetalleVenta> lista = new List<DetalleVenta>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_DetalleVenta", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idventa", idVenta);
                con.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    DetalleVenta objDetalle = new DetalleVenta();
                    objDetalle.IdProducto = new Productoss();
                    objDetalle.IdProducto.IdProducto = Convert.ToInt32(dr["IdProducto"].ToString());
                    objDetalle.IdProducto.Descripcion = dr["Descripcion"].ToString();
                    objDetalle.IdProducto.UrlImagen = dr["UrlImagen"].ToString();
                    objDetalle.Precio = Convert.ToDecimal(dr["Precio"].ToString());
                    objDetalle.Cantidad = Convert.ToInt32(dr["Cantidad"].ToString());
                    objDetalle.IdDetalleVenta = Convert.ToInt32(dr["IdDetalleVenta"].ToString());

                    lista.Add(objDetalle);
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
    }
}
