using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaDatosNegocios;

namespace capaPresentacion
{
    public partial class frmPerfil : Form
    {
        Image file;
        storedProcedure sp = new storedProcedure();
        public frmPerfil()
        {
            InitializeComponent();
            txtContra.UseSystemPasswordChar = true;
            txtComprobarcontra.UseSystemPasswordChar = true;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }


        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "JPG(.JPG)|*.jpg";

            if (f.ShowDialog() == DialogResult.OK)
            {
                file = Image.FromFile(f.FileName);
                pbUsuario.Image = file;
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            frmPerfil_Load(null, null);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            btnActualizar.Cursor = Cursors.WaitCursor;
            btnActualizar.Text = "Guardando...";
            if (txtContra.Text == null || txtComprobarcontra == null || txtContra.Text == "" || txtComprobarcontra.Text == "") {
                MenuVertical.errores = "Parece que los campos de contraseña y comprobar contraseña son erroneos, Por favor verificar si los datos son validos";
                txtContra.Text = "";
                txtComprobarcontra.Text = "";
                txtContra.Focus();

            }
            else
            {


                MenuVertical.errores = "[Guardando...] Por favor espere.";
                try
                {
                    string[,] docParametros = new string[9, 2];
                    docParametros[0, 0] = "@id_usuario";
                    docParametros[0, 1] = MenuVertical.usuarioSesion;
                    if (txtContra.Text == txtComprobarcontra.Text)
                    {
                        docParametros[1, 0] = "@Pass";
                        docParametros[1, 1] = txtContra.Text;
                    }
                    else
                    {
                        MenuVertical.errores = "Contraseña y comprobar contraseña no concuerdan, intente de nuevo";
                        txtContra.Text = "";
                        txtComprobarcontra.Text = "";
                        txtContra.Focus();
                    }

                    docParametros[2, 0] = "@Nombre";
                    docParametros[2, 1] = txtNombre.Text;

                    docParametros[3, 0] = "@Apellido";
                    docParametros[3, 1] = txtApellido.Text;

                    docParametros[4, 0] = "@telefono";
                    docParametros[4, 1] = txtTelefono.Text;

                    docParametros[5, 0] = "@Dui";
                    docParametros[5, 1] = txtDui.Text;

                    docParametros[6, 0] = "@Direccion";
                    docParametros[6, 1] = txtDireccion.Text;

                    if (cboGenero.SelectedItem.ToString() == "Masculino")
                    {
                        docParametros[7, 0] = "@Genero";
                        docParametros[7, 1] = "m";

                    }
                    else
                    {
                        docParametros[7, 0] = "@Genero";
                        docParametros[7, 1] = "f";
                    }
                    Image img = pbUsuario.Image;
                    byte[] arr;
                    string im;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        arr = ms.ToArray();
                        im = Convert.ToBase64String(arr);
                    }
                    docParametros[8, 0] = "@fotografia";
                    docParametros[8, 1] = im;

                    if (sp.pb(docParametros, "modificarUsuario"))
                    {
                        MenuVertical.errores = "Usuario modificado correctamente";
                        this.Close();
                    }
                    else
                    {
                        MenuVertical.errores = "No se pudo modificar el usuario";
                        btnActualizar.Text = "Guardar";
                    }

                }
                catch (Exception exz)
                {
                    MenuVertical.errores = "[ERROR] Asegurese de que los campos sean correctos, y la fotografia sea diferente.";
                }
            }
        }

        private void frmPerfil_Load(object sender, EventArgs e)
        {
            string[] docParametros = new string[1];//creamos un string para los parametros
            docParametros[0] = "@id_usuario = " + MenuVertical.usuarioSesion + "";//guardamos los parametros que queremos, no le ponemos las comillas simples al parametro, dará error

            try
            {
                List<object[]> usuarios = sp.lt(docParametros, "verUsuario");//mandamos a llamar la clase sp con la funcion lt

                foreach (object[] usuario in usuarios)//cargamos los datos en nuestra lista
                {
                    lblID.Text = usuario[0].ToString();
                    txtNombre.Text = usuario[2].ToString();
                    txtApellido.Text = usuario[3].ToString();
                    txtDireccion.Text = usuario[4].ToString();
                    txtTelefono.Text = usuario[5].ToString();
                    txtDui.Text = usuario[6].ToString();
                    lblClinica.Text = usuario[11].ToString();
                    if (usuario[7].ToString() == "m")
                    {
                        cboGenero.SelectedItem = "Masculino";
                    }
                    else
                    {
                        cboGenero.SelectedItem = "Femenino";
                    }
                    var array = Convert.FromBase64String(usuario[8].ToString());
                    using (var ms = new MemoryStream(array))
                    {
                       pbUsuario.Image = Image.FromStream(ms);
                    }
                }
            }
            catch (Exception ex)
            {

                MenuVertical.errores = "[ERROR]: "+ex;
            }
        }
    }
}
