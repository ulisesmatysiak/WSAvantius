using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WS_Avantius.Datos
{
    public class Conn
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public Conn()
        {
            conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cadenaConexion"].ConnectionString);
            comando = new SqlCommand();
        }

        public void setearProcedimiento(string sp)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }

        public void setearParametro(string nombre, object valor)
        {
            SqlParameter parametro = new SqlParameter(nombre, valor);
            comando.Parameters.Add(parametro);
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
      
        public bool siguienteResultado()
        {
            return lector.NextResult();
        }

        public void cerrarConexion()
        {
            if (lector != null)
            {
                lector.Close();
            }
            conexion.Close();
        }
    }
}