using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaDatosNegocios;
using System.Text.RegularExpressions;

namespace capaPresentacion
{
    public partial class usuarios : Form
    {
        storedProcedure sp = new storedProcedure();
        private int edit_indice = -1;
        public static Regex DUIregex = new Regex("^[0-9]{8}-[0-9]?$");
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
            dvgUsuarios.DataSource = sp.dt("usuario inner join clinicas.rol on clinicas.rol.idRol = clinicas.usuario.FK_Rol inner join clinicas.clinica on clinicas.clinica.ID_Clinica = clinicas.usuario.Fk_IDClinica", "clinicas.usuario.ID_usuario Usuario, clinicas.usuario.Pass contraseña, clinicas.usuario.Nombre,clinicas.usuario.Apellido,clinicas.usuario.telefono,clinicas.usuario.Genero, clinicas.rol.nombreRol Rol,clinicas.clinica.descripcion clinica,clinicas.usuario.dui,clinicas.usuario.direccion");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtNombre.Text == "" || txtNombre.Text == null)
                {
                    MenuVertical.errores = "Favor ingrese un nombre.";
                    MenuVertical.MensajeError(true);
                    throw new Exception();
                }
                else if (txtApellido.Text == "" || txtApellido.Text == null)
                {
                    MenuVertical.errores = "Favor ingrese un Apellido.";
                    MenuVertical.MensajeError(true);
                    throw new Exception();
                }
                else if (txtUsuario.Text == "" || txtUsuario.Text == null)
                {
                    MenuVertical.errores = "Favor ingrese un Usuario.";
                    MenuVertical.MensajeError(true);
                    throw new Exception();
                }
                else if (txtPass.Text == "" || txtPass.Text == null)
                {
                    MenuVertical.errores = "Favor ingrese una Contraseña.";
                    MenuVertical.MensajeError(true);
                    throw new Exception();
                }
                else
                {
                    string[] userParametros = new string[11];
                    userParametros[0] = "@id_usuario= " + txtUsuario.Text;
                    userParametros[1] = "@Pass= " + txtPass.Text;
                    userParametros[2] = "@Nombre= " + txtNombre.Text;
                    userParametros[3] = "@Apellido= " + txtApellido.Text;
                    userParametros[4] = "@Direccion= " + txtDireccion.Text;
                    userParametros[5] = "@Telefono= " + txtTelefono.Text;

                    if (txtDUI.Text == "" || txtDUI.Text == null)
                    {
                        userParametros[6] = "@Dui=";
                    }
                    else
                    {
                        if (isDui(txtDUI.Text))
                        {
                            userParametros[6] = "@Dui= " + txtDUI.Text;

                        }
                        else
                        {
                            MenuVertical.errores = "El DUI es incorrecto, asegurese que el formato sea 00000000-0, y el dui exista.";
                            MenuVertical.MensajeError(true);
                            throw new Exception();
                        }
                    }

                    if (cboGenero.SelectedItem.ToString() == "Femenino")
                    {
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
                            userParametros[10] = "@FK_IDClinica= 1";
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
                        MenuVertical.errores = "Usuario creado correctamente";
                        actualizarDatos();
                        MenuVertical.MensajeInformacion(true);
                    }
                    else
                    {

                        if (sp.pb(userParametros, "modificarUsuarioRol"))
                        {
                            MenuVertical.errores = "Usuario  modificado correctamente";
                            actualizarDatos();
                            MenuVertical.MensajeInformacion(true);
                        }
                        else
                        {
                            MenuVertical.errores = "No se pudo crear el Usuario ";
                            MenuVertical.MensajeError(true);
                        }
                    }
                }
            }
            
            catch (Exception exe)
            {
                MenuVertical.errores = "[ERROR] Favor revisar si los campos son correctos";
                MenuVertical.MensajeError(true);
            }
        }
    
        private static Boolean isDui(String dui)
        {
            if (DUIregex.IsMatch(dui))
            {
                int digitoVerificador = Convert.ToInt32(dui.Substring(9, 1));
                int suma = 0;
                for (int i = 9; i >= 2; i--)
                {
                    int digito = Convert.ToInt32(dui.Substring(9 - i, 1));
                    suma += (i * digito);
                }
                int residuoVerificador = 10 - (suma % 10);
                if (digitoVerificador == residuoVerificador || residuoVerificador == 0)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
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

        private void button2_Click(object sender, EventArgs e)
        {
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtDUI.Text = "";
            txtNombre.Text = "";
            txtPass.Text = "";
            txtTelefono.Text = "";
            txtUsuario.Text = "";
            cboClinica.SelectedIndex = 0;
            cboGenero.SelectedIndex = 0;
            cboRol.SelectedIndex = 0;
        }

        private void dvgDoctores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int pocision = dvgUsuarios.SelectedCells[0].RowIndex;
            edit_indice = pocision;
            txtUsuario.Text = dvgUsuarios.Rows[pocision].Cells[0].Value.ToString();
            txtPass.Text = dvgUsuarios.Rows[pocision].Cells[1].Value.ToString();
            txtNombre.Text = dvgUsuarios.Rows[pocision].Cells[2].Value.ToString();
            txtApellido.Text = dvgUsuarios.Rows[pocision].Cells[3].Value.ToString();
            txtTelefono.Text = dvgUsuarios.Rows[pocision].Cells[4].Value.ToString();
            if (dvgUsuarios.Rows[pocision].Cells[5].Value.ToString() == "m")
            {
                cboGenero.SelectedIndex = 1;
            }
            else {
                cboGenero.SelectedIndex = 0;
            }
            cboRol.SelectedItem = dvgUsuarios.Rows[pocision].Cells[6].Value.ToString();
            cboClinica.SelectedItem = dvgUsuarios.Rows[pocision].Cells[7].Value.ToString();
            txtDUI.Text = dvgUsuarios.Rows[pocision].Cells[8].Value.ToString();
            txtDireccion.Text= dvgUsuarios.Rows[pocision].Cells[9].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MenuVertical.usuarioSesion == txtUsuario.Text)
                {
                    MenuVertical.errores = "El usuario que pretende eliminar es el que esta usando actualmente, si lo elimina no podrá ingresar al sistema nuevamente";
                    MenuVertical.MensajeAdvertencia(true);
                    actualizarDatos();
                }
                else if(txtUsuario.Text == "" || txtUsuario.Text == null){
                    MenuVertical.errores = "el campo de usuario está vacio, escriba un valor o de doble click sobre el campo de la tabla inferior";
                    MenuVertical.MensajeAdvertencia(true);
                }
                else
                {
                    string[] pacParametros = new string[1];
                    pacParametros[0] = "@id_usuario = " + txtUsuario.Text;
                    if (sp.pb(pacParametros, "BorrarUsuario"))
                    {
                        MenuVertical.errores = "Usuario borrado correctamente";
                        MenuVertical.MensajeInformacion(true);
                        actualizarDatos();
                    }
                    else
                    {
                        MenuVertical.errores = "No se puede borrar el Usuario o no se pudo encontrar,si este existe revise si este Usuario esta registrado como doctor en el sistema";
                        MenuVertical.MensajeAdvertencia(true);
                    }
                }
            }
            catch (Exception exe)
            {
                MenuVertical.errores = "No se pudo borrar el Usuario";
            }
        }
    }
}
