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
        public static int clinica;
        List<string[]> pacientes = new List<string[]>();

        public frmCitas()
        {
            InitializeComponent();
        }

        private void actualizarDatos()
        {
            dgvCitas.DataSource = sp.dt("Cita INNER JOIN clinicas.paciente ON clinicas.paciente.ID_Paciente = clinicas.cita.Fk_IdPaciente INNER JOIN clinicas.doctor on clinicas.doctor.Id_Doctor = clinicas.cita.Fk_IdDoctor INNER JOIN clinicas.usuario on clinicas.doctor.Fk_IDUsuario = clinicas.usuario.ID_usuario where clinicas.paciente.Fk_IDClinica = "+frmCitas.clinica, "clinicas.cita.id_Cita No, clinicas.paciente.Nombre Paciente, clinicas.usuario.ID_usuario Doctor, clinicas.cita.fecha, clinicas.cita.Descripcion, clinicas.cita.precio");
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


                    citParametros[3] = "@Fk_IdPaciente =" + pacientes[0][0];
                
                List<object[]> datDoctor = sp.list("doctor where Fk_IDUsuario = '" + cmbDoctor.SelectedItem+"'");
                    citParametros[4] = "@Fk_IdDoctor = " + datDoctor[0][0].ToString();
                if (sp.pb(citParametros, "IngresarCitas"))
                {
                    MenuVertical.errores = "cita creada correctamente";
                    MenuVertical.MensajeInformacion(true);
                    actualizarDatos();
                    limpiarCampos();
                }
                else
                {
                    if (sp.pb(citParametros, "ActualizarCita"))
                    {
                        MenuVertical.errores = "Cita modificada correctamente";
                        MenuVertical.MensajeInformacion(true);
                        actualizarDatos();
                        limpiarCampos();
                    }
                    else
                    {
                        MenuVertical.errores = "No se pudo crear la cita";
                        MenuVertical.MensajeError(true);
                    }
                }

            }
            catch(Exception exe)
            {
                MenuVertical.errores = "Favor revisar si los campos son correctos";
                MenuVertical.MensajeAdvertencia(true);
            }
        }

        private void frmCitas_Load(object sender, EventArgs e)
        {


            pacientes = new List<string[]>();
            string[] pc = new string[2];
            List<object[]> datosDoctor = sp.list("doctor INNER JOIN clinicas.usuario ON ID_usuario = FK_IDUsuario WHERE clinicas.usuario.FK_IDClinica =" + frmCitas.clinica, "clinicas.usuario.ID_usuario");
            List<object[]> datosPacientes = sp.list("paciente where FK_IDClinica = "+frmCitas.clinica+";");

            cmbDoctor.Items.Insert(0, "Seleccione un doctor");
            foreach (object[] doctor in datosDoctor) 
            {
                cmbDoctor.Items.Add(doctor[0].ToString());
            }
            cmbDoctor.SelectedIndex = 0;

            cmbPaciente.Items.Insert(0, "Seleccione un paciente");
            foreach (object[] paciente in datosPacientes)
            {
                pc[0] = paciente[0].ToString();
                pc[1] = paciente[1].ToString();
                pacientes.Add(pc);
                cmbPaciente.Items.Add(pc[1]);
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
                    MenuVertical.errores = "Cita borrada correctamente";
                    MenuVertical.MensajeInformacion(true);
                    actualizarDatos();
                    limpiarCampos();
                }
                else
                {
                    MenuVertical.errores = "No se pudo borrar la cita";
                    MenuVertical.MensajeError(true);
                }
            }catch(Exception exe)
            {
                MenuVertical.errores = "Seleccione una cita a eliminar en la tabla";
                MenuVertical.MensajeAdvertencia(true);
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            cmbDoctor.SelectedIndex = 0;
            cmbPaciente.SelectedIndex = 0;
            dtpFecha.ResetText();
        }

        private void dgvCitas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int pocision = dgvCitas.SelectedCells[0].RowIndex;
            edit_indice = pocision;
            lblCita.Text = dgvCitas.Rows[pocision].Cells[0].Value.ToString();
            cmbPaciente.SelectedItem = dgvCitas.Rows[pocision].Cells[1].Value.ToString();
            cmbDoctor.SelectedItem = dgvCitas.Rows[pocision].Cells[2].Value.ToString();
            if(dgvCitas.Rows[pocision].Cells[3].Value.ToString() == "" || dgvCitas.Rows[pocision].Cells[3].Value.ToString() == null){ }else{
                dtpFecha.Value = Convert.ToDateTime(dgvCitas.Rows[pocision].Cells[3].Value.ToString());
            }
            txtDescripcion.Text = dgvCitas.Rows[pocision].Cells[4].Value.ToString();
            txtPrecio.Text = dgvCitas.Rows[pocision].Cells[5].Value.ToString();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                string[] pacParametros = new string[1];
                pacParametros[0] = "@id_Cita = " + lblCita.Text;
                if (sp.pb(pacParametros, "BorrarCita"))
                {
                    MenuVertical.errores = "Cita borrada correctamente";
                    MenuVertical.MensajeInformacion(true);
                    actualizarDatos();
                    limpiarCampos();
                }
                else
                {
                    


                }
            }
            catch (Exception exe)
            {
                MenuVertical.errores = "No se pudo borrar la cita";
            }
        }
    }
}
