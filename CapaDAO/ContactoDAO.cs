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
    public   class ContactoDAO
    {

        #region "PATRON SINGLETON"
        private static ContactoDAO daoContacto= null;
        private ContactoDAO() { }
        public static ContactoDAO getInstance()
        {
            if (daoContacto == null)
            {
                daoContacto = new ContactoDAO();
            }
            return daoContacto;
        }
        #endregion

        public bool RegistrarConsulta(Contacto objContacto)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_RegistrarConsulta", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", objContacto.Email);
                cmd.Parameters.AddWithValue("@celular", objContacto.Celular);
                cmd.Parameters.AddWithValue("@descripcion", objContacto.DescripcionProblema);
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
