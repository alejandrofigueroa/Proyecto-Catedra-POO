using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capaPresentacion
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                
                string[] args = Environment.GetCommandLineArgs();

                if (args.Length > 1)
                {
                    // Primera Posicion es el nombre del ejecutable.

                    //foreach (string itemParametros in args.Skip(1))
                    //{
                    //    MessageBox.Show(itemParametros);

                    //}

                    string nombreEjecutable = args[0];
                    string itemCrearBaseDatos = args[1];

                    //MessageBox.Show(itemCrearBaseDatos);

                    if (itemCrearBaseDatos == "/CrearBaseDatos")
                    {
                        Application.Run(new instaladorBD());
                    }

                }
                else
                {
                    //MostrarMenuPrincipal();
                    Application.Run(new SplashScreen());
                }


                //Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new Form1());

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            
        }
    }
}
