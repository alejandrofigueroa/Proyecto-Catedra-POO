using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Collections;
using System.Windows.Forms;

namespace capaDatosNegocios
{
    class Conexion
    {

        public SqlConnection cnn;

        public void leerConexion()
        {
            StreamReader objReader = new StreamReader(Path.Combine(Path.Combine(Application.StartupPath, "conexion.txt")));
            
            string sLine = "";
            ArrayList arrText = new ArrayList();
            int p = 20;
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                    arrText.Add(sLine);
            }
            objReader.Close();

            foreach (string sOutput in arrText)
            {
               cnn = new SqlConnection(sOutput);
            }
        }

        public SqlConnection AbrirConexion()
        {
            leerConexion();
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

