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
    public partial class frmDoctor : Form
    {
        storedProcedure sp = new storedProcedure();
        Doctor doc = new Doctor();

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
            doc.Fk_empleado1 = "admin0";//cboUsuario.SelectedItem.ToString();
            doc.Especialidad = textBox1.Text;
            doc.Descripcion = textBox2.Text; 
            foreach(var datos)
            sp.insertar(doc,"insertarDoctor");
        }
    }
}
