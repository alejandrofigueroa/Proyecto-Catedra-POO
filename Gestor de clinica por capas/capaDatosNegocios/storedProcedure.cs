using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace capaDatosNegocios
{
    public class storedProcedure
    {
        private Conexion Conexion = new Conexion();
        private SqlDataReader leer;

        public int insertar( obj, string nsp)
        {
            try
            {
                SqlCommand comando = new SqlCommand(nsp, Conexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                
                leer = comando.ExecuteReader();
                return 1;
            }
            catch (Exception e) {
                
                return 0;
            }
        }
    }
}
