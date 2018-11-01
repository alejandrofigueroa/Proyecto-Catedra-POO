using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace capaDatosNegocios
{
    class Conexion
    {

        public SqlConnection cnn = new SqlConnection("Server=(localdb)\\UDBSS; Database=GestorDeClinica; Uid=adminClinica; Pwd=admin123"); /*conecion via IP  connetionString="Data Source=IP_ADDRESS,PORT;connetionString="Data Source=IP_ADDRESS,PORT; Network Library=DBMSSOCN;Initial Catalog=DatabaseName; User ID=UserName;Password=Password"1433 is the default port for SQL Server.*/


        public SqlConnection AbrirConexion()
        {
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            return cnn;
        }

        public SqlConnection cerrarConexion()
        {
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }
            return cnn;
        }

    }

}

