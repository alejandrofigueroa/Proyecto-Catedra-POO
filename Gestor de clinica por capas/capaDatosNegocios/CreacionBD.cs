using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace capaDatosNegocios
{
        public class CrearBD
        {

            public static string CadenaConexion { get; set; }

            public static bool CheckDatabaseExists(string database)
            {

                bool bRet = false;

                //string connString = "Server=localhost;Integrated security=SSPI;database=master";

                string cmdText = string.Format("select * from master.dbo.sysdatabases where name=\'{0}\'", database);

                using (SqlConnection sqlConnection = new SqlConnection(CadenaConexion))
                {

                    sqlConnection.Open();

                    using (SqlCommand sqlCmd = new SqlCommand(cmdText, sqlConnection))
                    {

                        SqlDataReader nRet = sqlCmd.ExecuteReader();

                        bRet = nRet.HasRows;

                    }

                }

                return bRet;
            }

            public static bool CheckDatabaseExists(string server, string database)
            {

                //string connString = "Data Source=" + server + ";Initial Catalog=master;Integrated Security=True;";

                string cmdText = "select * from master.dbo.sysdatabases where name=\'" + database + "\'";

                bool bRet = false;

                using (SqlConnection sqlConnection = new SqlConnection(CadenaConexion))
                {

                    sqlConnection.Open();

                    using (SqlCommand sqlCmd = new SqlCommand(cmdText, sqlConnection))
                    {

                        SqlDataReader reader = sqlCmd.ExecuteReader();

                        bRet = reader.HasRows;

                        reader.Close();

                    }

                    sqlConnection.Close();

                }

                return bRet;

            }

            public static bool CrearBasedeDatos(string server, string database)
            {

                bool exito = false;

                string connString = "Data Source=" + server + ";Initial Catalog=master;Integrated Security=True;";

                SqlConnection myConn = new SqlConnection(connString);


                string str = string.Format("CREATE DATABASE[{0}] CONTAINMENT = NONE ON PRIMARY " +
                "(NAME = N\'{0}_Data\', FILENAME = N\'C:\\Program Files\\Microsoft SQL Server\\MSSQL12.MSSQLSERVER\\MSSQL\\DATA\\{0}_Data.mdf\', SIZE = 210176KB, MAXSIZE = UNLIMITED, FILEGROWTH = 16384KB ) " +
                 "LOG ON " +
                "(NAME = \'{0}_Log\', FILENAME = N\'C:\\Program Files\\Microsoft SQL Server\\MSSQL12.MSSQLSERVER\\MSSQL\\DATA\\{0}_Log.ldf\', SIZE = 2048KB, MAXSIZE = 2048GB, FILEGROWTH = 16384KB )",
                database);

                SqlCommand myCommand = new SqlCommand(str, myConn);

                try
                {
                    myConn.Open();
                    myCommand.ExecuteNonQuery();

                    exito = true;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    if (myConn.State == ConnectionState.Open)
                    {
                        myConn.Close();
                    }
                }

                return exito;
            }

            public static bool CrearBasedeDatos(string database)
            {

                bool exito = false;

                string exeProcesoNombre = System.Diagnostics.Process.GetCurrentProcess().ProcessName;

                string ubicacion = string.Format(@"C:\{0}", exeProcesoNombre);

                // string connString = "Data Source=localhost;Initial Catalog=master;Integrated Security=True;";

                SqlConnection myConn = new SqlConnection(CadenaConexion);

                //string str = string.Format("CREATE DATABASE[{0}] CONTAINMENT = NONE ON PRIMARY " +
                //"(NAME = N\'{0}_Data\', FILENAME = N\'C:\\Program Files\\Microsoft SQL Server\\MSSQL12.MSSQLSERVER\\MSSQL\\DATA\\{0}_Data.mdf\', SIZE = 210176KB, MAXSIZE = UNLIMITED, FILEGROWTH = 16384KB ) " +
                // "LOG ON " +
                //"(NAME = \'{0}_Log\', FILENAME = N\'C:\\Program Files\\Microsoft SQL Server\\MSSQL12.MSSQLSERVER\\MSSQL\\DATA\\{0}_Log.ldf\', SIZE = 2048KB, MAXSIZE = 2048GB, FILEGROWTH = 16384KB )",
                //database);

                bool existeDirectorio = System.IO.Directory.Exists(ubicacion);
                if (existeDirectorio == false) System.IO.Directory.CreateDirectory(ubicacion);



                string str = string.Format("CREATE DATABASE[{0}] CONTAINMENT = NONE ON PRIMARY " +
                "(NAME = N\'{0}_Data\', FILENAME = N\'{1}\\{0}_Data.mdf\', SIZE = 210176KB, MAXSIZE = UNLIMITED, FILEGROWTH = 16384KB ) " +
                 "LOG ON " +
                "(NAME = \'{0}_Log\', FILENAME = N\'{1}\\{0}_Log.ldf\', SIZE = 2048KB, MAXSIZE = 2048GB, FILEGROWTH = 16384KB )",
                database, ubicacion);

                SqlCommand myCommand = new SqlCommand(str, myConn);
                try
                {
                    myConn.Open();
                    myCommand.ExecuteNonQuery();

                    exito = true;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    if (myConn.State == ConnectionState.Open)
                    {
                        myConn.Close();
                    }
                }

                return exito;
            }
        }
    }
