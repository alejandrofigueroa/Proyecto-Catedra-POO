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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string[] docParametros = new string[3];
                docParametros[0] = "@especialidad = " + txtEspecialidad.Text;
                docParametros[1] = "@descripcion_personal = " + txtDPersonal.Text;
                docParametros[2] = "@FK_IDUsuario = " + cboUsuario.SelectedItem.ToString();

                if (sp.pb(docParametros, "insertarDoctor"))
                {
                    MenuVertical.errores = "Tabla creada correctamente";
                    actualizarDatos();
                }
                else
                {
                    if (sp.pb(docParametros, "actualizarDoctor"))
                    {
                        MenuVertical.errores = "Tabla creada correctamente";
                        actualizarDatos();
                    }
                    else
                    {
                        MenuVertical.errores = "No se pudo crear la tabla";
                    }
                }
            }
            catch (Exception exe) {
                MenuVertical.errores = "[ERROR] -Favor revisar si los campos son correctos";

            }
        }

        private void frmDoctor_Load(object sender, EventArgs e)
        {
            string[] docParametros = new string[1];
            actualizarDatos();
           
        }

        private void actualizarDatos() {
            dvgDoctores.DataSource = sp.dt("Doctor");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string[] docParametros = new string[1];
            docParametros[0] = "@id_usuario = " + cboUsuario.SelectedItem.ToString();

            if (sp.pb(docParametros, "borrarDoctores"))
            {
                MenuVertical.errores = "Dato borrado correctamente";
                actualizarDatos();
                cboUsuario.SelectedIndex = 0;
                txtDPersonal.Text = "";
                txtEspecialidad.Text = "";
            }
            else
            {
                MenuVertical.errores = "No se pudo borrar el dato";
            }
        }

        private void cboUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] docParametros = new string[1];//creamos un string para los parametros
            docParametros[0] = "@id_usuario = " + MenuVertical.usuarioSesion + "";

            try
            {
                List<object[]> datos = sp.lt(docParametros, "verUsuario");//mandamos a llamar la clase sp con la funcion lt

                foreach (object[] usuario in datos)//cargamos los datos en nuestra lista
                {
                    lblNombre.Text =  usuario[2].ToString();
                    lblApellido.Text =  usuario[3].ToString();
                    lblClinica.Text = usuario[11].ToString();
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

            int pocision = dvgDoctores.SelectedCells[0].RowIndex;
            edit_indice = pocision;

            //Doctor doc = doctores[pocision];

            cboUsuario.SelectedItem = dvgDoctores.Rows[pocision].Cells[3].Value;
            txtEspecialidad.Text = dvgDoctores.Rows[pocision].Cells[2].Value.ToString();
            txtDPersonal.Text = txtEspecialidad.Text = dvgDoctores.Rows[pocision].Cells[1].Value.ToString(); ;
        }

        private void dvgDoctores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
