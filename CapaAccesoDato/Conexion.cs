using System;
using System.Configuration;
using System.Data.SqlClient;

namespace CapaAccesoDatos
{
    public class Conexion
    {
        #region "PATRON SINGLETON"
        private static Conexion conexion = null;
        private static string connectionString = "server=.\\SQLEXPRESS; database=Commerce; integrated security=true";
        private static string patron = "e-commerce";
        private Conexion() { }
        public static Conexion getInstance()
        {
            if (conexion == null)
            {
                conexion = new Conexion();
            }
            return conexion;
        }
        #endregion

        public SqlConnection ConexionBD()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = GetConnectionString();
            return conexion;
        }

        public String GetConnectionString()
        {
            //return ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            return connectionString;
        }

        public String GetPatron()
        {
            return patron;
        }

    }
}
