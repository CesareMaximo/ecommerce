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
    public  class FormaPagoDAO
    {
        #region "PATRON SINGLETON"
        private static FormaPagoDAO daoFormaPago= null;
        private FormaPagoDAO() { }
        public static FormaPagoDAO getInstance()
        {
            if (daoFormaPago== null)
            {
                daoFormaPago = new FormaPagoDAO();
            }
            return daoFormaPago;
        }
        #endregion


        public List<FormaPago> listarformapago()
        {

            List<FormaPago> Lista = new List<FormaPago>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {

                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_ListaFormaPago", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    FormaPago obj = new FormaPago();
                    obj.IdFormaPago = Convert.ToInt32(dr["IdFormaPago"].ToString());
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


    }
}
