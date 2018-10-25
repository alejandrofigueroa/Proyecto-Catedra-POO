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

        bool crearUsuario(string nombre, string apellido, string direccion, int telefono, string dui, string genero, string usuario, string password, int FK_IDClinica, string esquema)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("InsertarEmpleado", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Apellido", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Direccion", SqlDbType.VarChar, 100);
                cmd.Parameters.Add("@Telefono", SqlDbType.Int);
                cmd.Parameters.Add("@Dui", SqlDbType.Int);
                cmd.Parameters.Add("@Genero", SqlDbType.VarChar, 15);
                cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@pass", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Fk_IDClinica", SqlDbType.Int);
                cmd.Parameters.Add("@esquema", SqlDbType.VarChar, 50);

                cmd.Parameters["@Nombre"].Value = nombre;
                cmd.Parameters["@Apellido"].Value = apellido;
                cmd.Parameters["@Direccion"].Value = direccion;
                cmd.Parameters["@Telefono"].Value = telefono;
                cmd.Parameters["@Dui"].Value = dui;
                cmd.Parameters["@Genero"].Value = genero;
                cmd.Parameters["@usuario"].Value = usuario;
                cmd.Parameters["@pass"].Value = password;
                cmd.Parameters["@FK_IDClinica"].Value = FK_IDClinica;
                cmd.Parameters["@esquema"].Value = esquema;

                AbrirConexion();
                cmd.ExecuteNonQuery();
                cerrarConexion();
                return true;
            }
            catch (Exception)
            {
                return false;
            }



        }

    }

}

