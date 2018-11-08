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
    public partial class frmCitas : Form
    {
        storedProcedure sp = new storedProcedure();
        private int edit_indice = -1;
        private List<Citas> citas = new List<Citas>();


        public frmCitas()
        {
            InitializeComponent();
        }

        private void actualizarDatos()
        {
            dgvCitas.DataSource = sp.dt("Cita");
        }

        private void limpiarCampos()
        {
            txtDescripcion.Clear();
            txtPrecio.Clear();
            dtpFecha.ResetText();
            cmbDoctor.SelectedIndex = 0;
            cmbPaciente.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string[] citParametros = new string[5];
                citParametros[0] = "@fecha =" + dtpFecha.Value.ToString("yyyy-MM-dd");
                citParametros[1] = "@Descripcion =" + txtDescripcion.Text;
                citParametros[2] = "@precio =" + Convert.ToDecimal(txtPrecio.Text);
                citParametros[3] = "@Fk_IdPaciente =" + cmbPaciente.SelectedIndex;
                citParametros[4] = "@Fk_IdDoctor =" + cmbDoctor.SelectedIndex;
                if (sp.pb(citParametros, "IngresarCitas"))
                {
                    MenuVertical.errores = "Tabla creada correctamente";
                    actualizarDatos();
                    limpiarCampos();
                }
                else
                {
                    if (sp.pb(citParametros, "ActualizarCita"))
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

            }
            catch(Exception exe)
            {
                MenuVertical.errores = "[ERROR] -Favor revisar si los campos son correctos";
            }
        }

        private void frmCitas_Load(object sender, EventArgs e)
        {
            
            

            List<object[]> datosDoctor = sp.list("doctor");
            List<object[]> datosPacientes = sp.list("paciente");

            cmbDoctor.Items.Insert(0, "Seleccione un doctor");
            foreach (object[] doctor in datosDoctor) 
            {
                cmbDoctor.Items.Insert(Convert.ToInt32(doctor[0]), doctor[1].ToString());
            }
            cmbDoctor.SelectedIndex = 0;

            cmbPaciente.Items.Insert(0, "Seleccione un paciente");
            foreach (object[] paciente in datosPacientes)
            {
                
                cmbPaciente.Items.Insert(Convert.ToInt32(paciente[0]), paciente[1].ToString());
            }

            
            cmbPaciente.SelectedIndex = 0;
            actualizarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string[] citParametros = new string[1];
                citParametros[0] = "@id_Cita =" + Convert.ToInt32(lblCita.Text);
                if (sp.pb(citParametros, "BorrarCita"))
                {
                    MenuVertical.errores = "Dato borrado correctamente";
                    actualizarDatos();
                    limpiarCampos();
                }
                else
                {
                    MenuVertical.errores = "No se pudo borrar el dato";
                }
            }catch(Exception exe)
            {
                MenuVertical.errores = "[ERROR] - " + exe.ToString();
            }
        }

        private void dgvCitas_DoubleClick(object sender, EventArgs e)
        {
            int posicion = dgvCitas.SelectedCells[0].RowIndex;
            edit_indice = posicion;

            lblCita.Text = dgvCitas.Rows[posicion].Cells[0].Value.ToString();
            dtpFecha.Value = Convert.ToDateTime(dgvCitas.Rows[posicion].Cells[1].Value.ToString());
            txtDescripcion.Text = dgvCitas.Rows[posicion].Cells[2].Value.ToString();
            txtPrecio.Text = dgvCitas.Rows[posicion].Cells[3].Value.ToString();
            cmbPaciente.SelectedIndex = Convert.ToInt32(dgvCitas.Rows[posicion].Cells[4].Value.ToString());
            cmbDoctor.SelectedIndex = Convert.ToInt32(dgvCitas.Rows[posicion].Cells[4].Value.ToString());
        }

        private void dgvCitas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
