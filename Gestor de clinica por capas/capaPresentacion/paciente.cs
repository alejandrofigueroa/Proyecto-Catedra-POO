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

namespace capaPresentacion
{
    public partial class frmPaciente : Form
    {
        storedProcedure sp = new storedProcedure();
        private int edit_indice = -1;
        public static int clinica;
        private List<Paciente> paciente = new List<Paciente>();
        public frmPaciente()
        {
            InitializeComponent();
        }

        private void actualizarDatos()
        {
            dgvPaciente.DataSource = sp.dt("Paciente  where FK_IDClinica = "+clinica);
        }

        private void limpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            dtpFecha.ResetText();
            cmbSexo.SelectedIndex = 0;
        }

        private void frmPaciente_Load(object sender, EventArgs e)
        {
            List<object[]> datos = sp.list("clinica");

            cmbSexo.Items.Clear();
            cmbSexo.Items.Add("Masculino");
            cmbSexo.Items.Add("Femenino");
            cmbSexo.SelectedIndex = 0;

            if (clinica == 2)
            {
                lblClinica.Text = "General";
            }
            else {
                lblClinica.Text = "Laboratorio";
            }

            actualizarDatos();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string[] pacParametros = new string[8];
                pacParametros[0] = "@Nombre =" + txtNombre.Text;
                pacParametros[1] = "@Apellido =" + txtApellido.Text;
                pacParametros[2] = "@Direccion =" + txtDireccion.Text;
                pacParametros[3] = "@Telefono =" + Convert.ToInt32(txtTelefono.Text);
                pacParametros[4] = "@Email =" + txtEmail.Text;
                pacParametros[5] = "@Fecha_Nacimiento =" + dtpFecha.Value.ToString("yyyy-MM-dd");
                pacParametros[6] = "@Sexo =" + cmbSexo.SelectedItem.ToString();
                pacParametros[7] = "@FK_Clinica =" + clinica;
                if (sp.pb(pacParametros, "IngresarPaciente"))
                {
                    MenuVertical.errores = "Tabla creada correctamente";
                    actualizarDatos();
                    limpiarCampos();
                }
                else
                {
                    if (sp.pb(pacParametros, "ModificarPaciente"))
                    {
                        MenuVertical.errores = "Tabla actualizada correctamente";
                        actualizarDatos();
                        limpiarCampos();
                    }
                    else
                    {
                        MenuVertical.errores = "No se pudo crear la tabla";
                    }
                }
            }catch(Exception exe)
            {
                MenuVertical.errores = "[ERROR] -Favor revisar si los campos son correctos";
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string[] pacParametros = new string[1];
                pacParametros[0] = "@ID_Paciente =" + Convert.ToInt32(lblPaciente.Text);
                if (sp.pb(pacParametros, "EliminarPaciente"))
                {
                    MenuVertical.errores = "Dato borrado correctamente";
                    actualizarDatos();
                    limpiarCampos();
                }
                else
                {
                    MenuVertical.errores = "No se pudo borrar el dato";
                }
            }
            catch (Exception exe)
            {
                MenuVertical.errores = "[ERROR] - " + exe.ToString();
            }
        }

        private void dgvPaciente_DoubleClick(object sender, EventArgs e)
        {
            int posicion = dgvPaciente.SelectedCells[0].RowIndex;
            edit_indice = posicion;

            lblPaciente.Text = dgvPaciente.Rows[posicion].Cells[0].Value.ToString();
            txtNombre.Text = dgvPaciente.Rows[posicion].Cells[1].Value.ToString();
            txtApellido.Text = dgvPaciente.Rows[posicion].Cells[2].Value.ToString();
            txtDireccion.Text = dgvPaciente.Rows[posicion].Cells[3].Value.ToString();
            txtTelefono.Text = dgvPaciente.Rows[posicion].Cells[4].Value.ToString();
            txtEmail.Text = dgvPaciente.Rows[posicion].Cells[5].Value.ToString();
            dtpFecha.Value = Convert.ToDateTime(dgvPaciente.Rows[posicion].Cells[6].Value);
            cmbSexo.SelectedItem = dgvPaciente.Rows[posicion].Cells[7].Value.ToString();
        }

        private void dgvPaciente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
