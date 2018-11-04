using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using capaDatosNegocios;

namespace capaPresentacion
{
    public partial class usuarios : Form
    {
        storedProcedure sp = new storedProcedure();
        private int edit_indice = -1;

        private List<Doctor> doctores = new List<Doctor>();

        public usuarios()
        {
            InitializeComponent();
        }

        private void usuarios_Load(object sender, EventArgs e)
        {
            cargarRol();
            cargarClinica();
            actualizarDatos();

            cboGenero.Items.Add("Femenino");
            cboGenero.Items.Add("Masculino");

            cboClinica.SelectedIndex = 1; ;
            cboGenero.SelectedIndex = 1;
            cboRol.SelectedIndex = 1; 

        }

        private void cargarClinica()
        {
            List<object[]> datos = sp.list("clinica");//mandamos a llamar la clase sp con la funcion lt

            foreach (object[] clinica in datos)//cargamos los datos en nuestra lista
            {
                cboClinica.Items.Add(clinica[1].ToString());
            }
        }

        private void cargarRol() {
            List<object[]> datos = sp.list("rol");//mandamos a llamar la clase sp con la funcion lt

            foreach (object[] rol in datos)//cargamos los datos en nuestra lista
            {
                cboRol.Items.Add(rol[1].ToString());
            }
        }

        private void actualizarDatos()
        {
            dvgDoctores.DataSource = sp.dt("usuario");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string[] userParametros = new string[11];
                userParametros[0] = "@id_usuario= " + txtUsuario.Text;
                userParametros[1] = "@Pass= " + txtPass.Text;
                userParametros[2] = "@Nombre= " + txtNombre.Text;
                userParametros[3] = "@Apellido= " + txtApellido.Text;
                userParametros[4] = "@Direccion= " + txtDireccion.Text;
                userParametros[5] = "@Telefono= " + txtTelefono.Text;
                userParametros[6] = "@Dui= " + txtDUI.Text;

                if (cboGenero.SelectedItem.ToString() == "Femenino") {
                    userParametros[7] = "@Genero= f";
                        }
                else
                {
                    userParametros[7] = "@Genero= m";
                }

                userParametros[8] = "@fotografia= null";
                    switch (cboRol.SelectedItem.ToString())
                {
                    case "admin":
                        userParametros[9] = "@FK_Rol= 1";
                        break;
                    case "Doctores":
                        userParametros[9] = "@FK_Rol= 2";
                        break;
                    case "Secretarios":
                        userParametros[9] = "@FK_Rol= 3";
                        break;
                }
                switch (cboClinica.SelectedItem.ToString())
                {
                    case "admin":
                        userParametros[10]  = "@FK_IDClinica= 1";
                        break;
                    case "Laboratorio":
                        userParametros[10] = "@FK_IDClinica= 2";
                        break;
                    case "General":
                        userParametros[10] = "@FK_IDClinica= 3";
                        break;
                }
                 
                
                if (sp.pb(userParametros, "insertarUsuario"))
                {
                    MenuVertical.errores = "Tabla creada correctamente";
                    actualizarDatos();
                }
                else
                {

                    if (sp.pb(userParametros, "modificarUsuarioRol"))
                    {
                        MenuVertical.errores = "Tabla modificada correctamente";
                        actualizarDatos();
                    }
                    else
                    {
                        MenuVertical.errores = "No se pudo crear la tabla";
                    }
                }
            }
            catch (Exception exe)
            {
                MenuVertical.errores = "[ERROR] -Favor revisar si los campos son correctos";

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string[] docParametros = new string[1];//creamos un string para los parametros
            docParametros[0] = "@ID_Usuario = " + txtUsuario.Text;//guardamos los parametros que queremos, no le ponemos las comillas simples al parametro, dará error

            try
            {
                List<object[]> datos = sp.lt(docParametros, "BuscarUsuario");//mandamos a llamar la clase sp con la funcion lt

                foreach (object[] dato in datos)//cargamos los datos en nuestra lista
                {
                    txtPass.Text = dato[1].ToString();
                    txtNombre.Text = dato[2].ToString();
                    txtApellido.Text = dato[3].ToString();
                    txtDireccion.Text = dato[4].ToString();
                    txtTelefono.Text  = dato[5].ToString();
                    txtDUI.Text = dato[6].ToString();
                    
                }
            }
            catch
            {

            }
        }
    }
}
