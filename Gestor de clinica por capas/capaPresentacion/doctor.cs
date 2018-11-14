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
    public partial class frmDoctor : Form
    {
        storedProcedure sp = new storedProcedure();
        private int edit_indice = -1;

        private List<Doctor> doctores = new List<Doctor>();
        public static string clinica;
        public frmDoctor()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmDoctor_Load(object sender, EventArgs e)
        {
            cboUsuario.Items.Insert(0, "Seleccione un usuario");
            cboUsuario.SelectedIndex = 0;
            string[] docParametros = new string[1];
            docParametros[0] = "@id_usuario = " + MenuVertical.usuarioSesion + "";//guardamos los parametros que queremos, no le ponemos las comillas simples al parametro, dará error

            List<object[]> datos = sp.list("usuario where Fk_IDClinica="+frmDoctor.clinica);//mandamos a llamar la clase sp con la funcion lt

            foreach (object[] usuario in datos)//cargamos los datos en nuestra lista
            {
                cboUsuario.Items.Add(usuario[0].ToString());
            }

            actualizarDatos();
           
        }

        private void actualizarDatos() {
            dvgDoctores.DataSource = sp.dt("doctor INNER JOIN clinicas.usuario ON clinicas.usuario.ID_usuario = clinicas.doctor.FK_IDUsuario; ", "clinicas.usuario.ID_usuario Usuario, clinicas.doctor.especialidad Especialidad, clinicas.doctor.descripcion_Personal Descripcion");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
        }

        private void cboUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] docParametros = new string[1];//creamos un string para los parametros
            docParametros[0] = "@id_usuario = " + cboUsuario.SelectedItem.ToString();

            try
            {
                List<object[]> datos = sp.lt(docParametros, "verUsuario");//mandamos a llamar la clase sp con la funcion lt

                foreach (object[] usuario in datos)//cargamos los datos en nuestra lista
                {
                    lblNombre.Text =  usuario[2].ToString();
                    lblApellido.Text =  usuario[3].ToString();
                    var array = Convert.FromBase64String(usuario[8].ToString());
                    using (var ms = new MemoryStream(array))
                    {
                        pbUsuario.Image = Image.FromStream(ms);
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void dvgDoctores_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dvgDoctores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                string[] docParametros = new string[3];
                docParametros[0] = "@especialidad = " + txtEspecialidad.Text;
                docParametros[1] = "@descripcion_personal = " + txtDPersonal.Text;
                docParametros[2] = "@FK_IDUsuario = " + cboUsuario.SelectedItem.ToString();

                if (sp.pb(docParametros, "insertarDoctor"))
                {
                    MenuVertical.errores = "doctor creado correctamente";
                    MenuVertical.MensajeInformacion(true);
                    actualizarDatos();
                }
                else
                {
                    if (sp.pb(docParametros, "actualizarDoctor"))
                    {
                        MenuVertical.errores = "doctor modificado correctamente";
                        MenuVertical.MensajeInformacion(true);
                        actualizarDatos();
                    }
                    else
                    {
                        MenuVertical.errores = "No se pudo crear el doctor, verifique que no tenga una cita pendiente";
                        MenuVertical.MensajeError(true);
                    }
                }
            }
            catch (Exception exe)
            {
                MenuVertical.errores = "[ERROR] Favor revisar si los campos son correctos";
                MenuVertical.MensajeAdvertencia(true);

            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            string[] docParametros = new string[1];
            docParametros[0] = "@id_usuario = " + cboUsuario.SelectedItem.ToString();

            if (sp.pb(docParametros, "borrarDoctores"))
            {
                MenuVertical.errores = "doctor borrado correctamente";
                MenuVertical.MensajeInformacion(true);
                actualizarDatos();
                cboUsuario.SelectedIndex = 0;
                txtDPersonal.Text = "";
                txtEspecialidad.Text = "";
            }
            else
            {
                MenuVertical.errores = "No se pudo borrar el doctor";
                MenuVertical.MensajeError(true);
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            string[] docParametros = new string[1];//creamos un string para los parametros
            docParametros[0] = "@Fk_IDUsuario = " + MenuVertical.usuarioSesion + "";//guardamos los parametros que queremos, no le ponemos las comillas simples al parametro, dará error

            try
            {
                List<object[]> datos = sp.lt(docParametros, "BuscarDoctor");//mandamos a llamar la clase sp con la funcion lt

                foreach (object[] notificacion in datos)//cargamos los datos en nuestra lista
                {
                    txtEspecialidad.Text = notificacion[1].ToString();
                    txtDPersonal.Text = notificacion[2].ToString();
                }
            }
            catch
            {

            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDPersonal.Text = "";
            txtEspecialidad.Text = "";
            lblApellido.Text = "";
            lblNombre.Text = "";
            pbUsuario.Image = null;
            cboUsuario.SelectedIndex = 0;
        }

        private void dvgDoctores_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            int pocision = dvgDoctores.SelectedCells[0].RowIndex;
            edit_indice = pocision;
            txtEspecialidad.Text = dvgDoctores.Rows[pocision].Cells[1].Value.ToString();
            txtDPersonal.Text = txtEspecialidad.Text = dvgDoctores.Rows[pocision].Cells[2].Value.ToString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
