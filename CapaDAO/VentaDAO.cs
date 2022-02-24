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
   public class VentaDAO
    {

        #region "PATRON SINGLETON"
        private static VentaDAO daoVenta = null;
        private VentaDAO() { }
        public static VentaDAO getInstance()
        {
            if (daoVenta == null)
            {
                daoVenta = new VentaDAO();
            }
            return daoVenta;
        }
        #endregion

        public bool FinalizarVenta(Ventas objVenta)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_FinalizarVenta", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idUsuario", objVenta.IdUsuario);
                cmd.Parameters.AddWithValue("@idPago", objVenta.IdFormaPago);
                cmd.Parameters.AddWithValue("@descripcion", objVenta.DescripcionVenta);
                cmd.Parameters.AddWithValue("@direccion", objVenta.DireccionEnvio);
                cmd.Parameters.AddWithValue("@estadoretiro", objVenta.EstadoRetiro);
                cmd.Parameters.AddWithValue("@estadoenvio", objVenta.EstadoEnvio);
                cmd.Parameters.AddWithValue("@total", objVenta.Total);
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

        public List<Ventas> ListaVentaDespacho()
        {
            List<Ventas> lista = new List<Ventas>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_ListaVentasDespacho", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Ventas objVenta = new Ventas();
                    objVenta.IdVenta = Convert.ToInt32(dr["IdVenta"].ToString());
                    objVenta.FechaVenta = Convert.ToDateTime(dr["Fecha"].ToString());
                    objVenta.Total = Convert.ToDecimal(dr["Total"].ToString());
                    objVenta.EstadoEnvio = Convert.ToBoolean(dr["EstadoEnvio"].ToString());
                    objVenta.EstadoRetiro = Convert.ToBoolean(dr["EstadoRetiro"].ToString());
                    objVenta.DireccionEnvio = dr["DireccionEnvio"].ToString();
                    objVenta.DescripcionVenta = dr["DescripcionVenta"].ToString();
                    lista.Add(objVenta);
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


        public bool ConcretarVenta(int idVenta)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_ConcretarVenta", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idventa", idVenta);
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

        public List<Ventas> ListaVentas()
        {
            List<Ventas> lista = new List<Ventas>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_ListaVentas", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Ventas objVenta = new Ventas();
                    objVenta.IdVenta = Convert.ToInt32(dr["IdVenta"].ToString());
                    objVenta.FechaVenta = Convert.ToDateTime(dr["Fecha"].ToString());
                    objVenta.Total = Convert.ToDecimal(dr["Total"].ToString());
                    objVenta.EstadoEnvio = Convert.ToBoolean(dr["EstadoEnvio"].ToString());
                    objVenta.EstadoRetiro = Convert.ToBoolean(dr["EstadoRetiro"].ToString());
                    objVenta.DireccionEnvio = dr["DireccionEnvio"].ToString();
                    objVenta.DescripcionVenta = dr["DescripcionVenta"].ToString();
                    objVenta.IdUsuario = Convert.ToInt32(dr["IdUsuario"].ToString());
                    objVenta.Estado = Convert.ToBoolean(dr["Estado"].ToString());
                    objVenta.IdUsuario = Convert.ToInt32(dr["IdUsuario"].ToString());
                    lista.Add(objVenta);
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
        public Ventas VentaxID(int idVenta)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            Ventas objventa = new Ventas();
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_VentaxID", con);
                cmd.Parameters.AddWithValue("@idVenta", idVenta);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    
                    objventa.Total = Convert.ToDecimal(dr["Total"].ToString());
                    objventa.IdUsuario = Convert.ToInt32(dr["IdUsuario"].ToString());
                    objventa.IdFormaPago = Convert.ToInt32(dr["IdFormaPago"].ToString());
                    objventa.DireccionEnvio = dr["DireccionEnvio"].ToString();
                    objventa.FechaVenta = Convert.ToDateTime(dr["Fecha"].ToString());
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
            return objventa;
        }
        public List<Ventas> listaVentaxUsuario(int idUsuario)
        {
            List<Ventas> lista = new List<Ventas>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_VentasxUsuario", con);
                cmd.Parameters.AddWithValue("@idusuario", idUsuario);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Ventas objVentas = new Ventas();
                    objVentas.FechaVenta = Convert.ToDateTime(dr["Fecha"].ToString());
                    objVentas.Total = Convert.ToDecimal(dr["Total"].ToString());
                    objVentas.EstadoEnvio = Convert.ToBoolean(dr["EstadoEnvio"].ToString());
                    objVentas.EstadoRetiro = Convert.ToBoolean(dr["EstadoRetiro"].ToString());
                    objVentas.IdVenta = Convert.ToInt32(dr["IdVenta"].ToString());
                    objVentas.DireccionEnvio = dr["DireccionEnvio"].ToString();
                    objVentas.DescripcionVenta = dr["DescripcionVenta"].ToString();
                    objVentas.Estado = Convert.ToBoolean(dr["Estado"].ToString());

                    lista.Add(objVentas);

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
