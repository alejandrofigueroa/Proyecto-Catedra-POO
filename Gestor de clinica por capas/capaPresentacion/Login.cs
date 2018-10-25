using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaDatosNegocios;

namespace capaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BtnBoton_Click(object sender, EventArgs e)
        {
            /*Bucle que hace que inicie session*/
            //el siguiente bucle comentado puede ser reutilizado
            //creo un objeto de tipo CNEmpleado(clase que se crea en la capa de negocios) para eso mando a llamar la capa (parte superior, "using capaNegocios;")
            Empleado objEmpleado = new Empleado();                //mando a llamar el procedimiento almacenado
                SqlDataReader Logear;
                //asigno variables al objeto (getters y setters creados en la clase de negocios)
                objEmpleado.Usuario1 = txtUsuario.Text;
            MenuVertical.usuarioSesion = txtUsuario.Text;
                objEmpleado.Pass = txtPass.Text;
                //de aqui en adelante juego con las variables seteadas en la capa negocios para la programacion del login
                
            if (objEmpleado.Usuario1 == txtUsuario.Text)
            {
                if (objEmpleado.Pass == txtPass.Text)
                {
                    Logear = objEmpleado.IniciarSesion();
                    if (Logear.Read() == true)
                    {
                        lblErrores.Text = "Un sistema clínico porque la tecnología\r\nes una mejor forma de hacer tu trabajo\r\nmás fácil y sencillo.\r\n\r\nUniversidad Don Bosco.";
                        lblErrores.ForeColor = Color.White;
                        MenuVertical panel = new MenuVertical();
                        this.Hide();
                        panel.Visible = true;
                    }
                    else
                    {

                        lblErrores.Text = "Usuario o contraseña invalidos";
                        txtPass.Text = "";
                        lblErrores.ForeColor = Color.Red;
                        txtPass_Leave(null, e);
                        txtUsuario.Focus();
                    }
                }
                else
                {
                    lblErrores.Text = objEmpleado.Pass;
                    lblErrores.ForeColor = Color.Red;
                }
            }
            else {
                lblErrores.Text = objEmpleado.Usuario1;
                lblErrores.ForeColor = Color.Red;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "CONTRASEÑA")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.Black;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "CONTRASEÑA";
                txtPass.ForeColor = Color.DimGray;
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnBoton_Click(null, e);
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnBoton_Click(null, e);
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnBoton_Click(null, e);
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
