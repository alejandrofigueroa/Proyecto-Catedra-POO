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
using System.IO;

namespace capaPresentacion
{
    public partial class MenuVertical : Form
    {
        //variables Globales para el control de menuprincipal recuerden ponerle :Menuvertical despues del nombre de la clase para que su clase herede las variables

            /*con estas variables van a poder acceder a caracteristicas del menu principal*/
        public static string usuarioSesion;//pueden usar esta variable para saber el id del usuario que se ha logeado, no le asignen valores por que se le asigna desde el login
        public string nombreSesion;
        public string rolSesion;
        public string clinicasesion;
        public static string errores;// con esta variable pueden poner errores en la barra de estado del menu
        public static Image fotoPerfil;

        storedProcedure sp = new storedProcedure();

        Timer t = new Timer();
        public MenuVertical()
        {
            InitializeComponent();
            cargarVariables();
            FotoPerfil.Image = fotoPerfil;
        }

        public void cargarVariables() {
            try
            {
                string[] docParametros = new string[1];//creamos un string para los parametros
                docParametros[0] = "@id_usuario = " + MenuVertical.usuarioSesion + "";//guardamos los parametros que queremos, no le ponemos las comillas simples al parametro, dará error
                List<object[]> usuarios = sp.lt(docParametros, "verUsuario");//mandamos a llamar la clase sp con la funcion lt

                foreach (object[] usuario in usuarios)//cargamos los datos en nuestra lista
                {
                    var array = Convert.FromBase64String(usuario[8].ToString());
                    using (var ms = new MemoryStream(array))
                    {
                        fotoPerfil = Image.FromStream(ms);
                    }
                }
            }catch{

            }
        }

        private void btnSlide_Click(object sender, EventArgs e)
        {
            if (menuPrincipal.Width == 250)
            {
                menuPrincipal.Width = 80;
                panelBotonClinica.Height = 50;
                PanelBotonLaboratorio.Height = 50;
                
            }
            else
            {
                menuPrincipal.Width = 250;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (menuOpciones.Width == 250)
            {
                menuOpciones.Width = 0;
            }
            else
            {
                menuOpciones.Width = 250;
            }
            btnNotificaciones_Click(null, e);
        }

        private void MenuVertical_Load(object sender, EventArgs e)
        {
            menuOpciones.Width = 0;
            menuPrincipal.Width = 80;

            t.Interval = 1000;

            t.Tick += new EventHandler(this.t_Tick);

            t.Start();

            lblUsuarioActual.Text = usuarioSesion;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnRestaurar.Visible = true;
            btnMaximizar.Visible = false;
        }

        private void btnNotificaciones_Click(object sender, EventArgs e)
        {
            try
            {
                btnTemas.BackColor = Color.FromArgb(41, 66, 91);
                btnNotificaciones.BackColor = Color.FromArgb(50, 81, 112);
                panelContTemas.Visible = false;
                contNotificicaciones.Visible = true;

                string[] notiParametros = new string[1];
                listNotificaciones.Items.Clear();
                notiParametros[0] = "@id_usuario = " + MenuVertical.usuarioSesion + "";

                List<object[]> datos = sp.lt(notiParametros, "verNotificacion");

                foreach (object[] notificacion in datos)
                {
                    listNotificaciones.Items.Add("[" + notificacion[1].ToString() + "] -" + notificacion[2].ToString());
                }
            }catch(Exception ex)
            {

            }

            
        }

        private void btnTemas_Click(object sender, EventArgs e)
        {
            panelContTemas.Visible = true;
            contNotificicaciones.Visible = false;
            btnTemas.BackColor = Color.FromArgb(50, 81, 112);
            btnNotificaciones.BackColor = Color.FromArgb(41, 66, 91);
        }

        private void t_Tick(Object sender, EventArgs e)
        {
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int dia = DateTime.Now.Day;
            int mes = DateTime.Now.Month;
            int anio = DateTime.Now.Year;
            string fecha = "";
            string time = "";
            statusLabelErrores.Text = MenuVertical.errores;
            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                if ((12 - hh) < 0)
                {
                    time += "0" + (hh);
                }
                if ((12 - hh ) > 0)
                {
                    time += (hh);
                }
                else
                {
                    time += (hh);
                }
            }
            time += ":";

            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            if (hh < 12)
            {
                time += "  AM";
            }
            else if (hh == 12)
            {
                time += "  M";
            }
            else
            {
                time += "  PM";
            }


            if (dia < 10)
            {
                fecha += "0" + dia + "/";
            }
            else
            {
                fecha += dia + "/";
            }

            if (mes < 10)
            {
                fecha += "0" + mes + "/";
            }
            else
            {
                fecha += mes + "/";
            }

            fecha += anio;
            reloj.Text = time;
            lblFecha.Text = fecha;


            //el siguiente bucle comentado puede ser reutilizado
            //creo un objeto de tipo CNEmpleado(clase que se crea en la capa de negocios)
            Empleado objEmpleado = new Empleado();
            //mando a llamar el procedimiento almacenado
          //  SqlDataReader Logear;
            //asigno variables al objeto (getters y setters creados en la clase de negocios)
         //   objEmpleado.Usuario = txtUsuario.Text;
          //  objEmpleado.Pass = txtPass.Text;
            //de aqui en adelante juego con las variables seteadas en la capa negocios para la programacion del login




        }

        private void btnClinica_Click(object sender, EventArgs e)
        {
            
            //statusLabel.Text = Conexion.con();
        }

        private void btnMiPerfil_Click(object sender, EventArgs e)
        {

        }

        private void btn_Click(object sender, EventArgs e)
        {
            frmCitas citas = new frmCitas();
            AbrirFormInPanel(citas);
            this.panelCont.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLaboratorio_Click(object sender, EventArgs e)
        {
            if (PanelBotonLaboratorio.Height == 210)
            {
                PanelBotonLaboratorio.Height= 50;
            }
            else
            {
                PanelBotonLaboratorio.Height = 210;
                panelBotonClinica.Height = 50;
                    
                menuPrincipal.Width = 250;
            }
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void lblUsuarioActual_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnClinica_Click_1(object sender, EventArgs e)
        {
            if (panelBotonClinica.Height == 210)
            {
                panelBotonClinica.Height = 50;
            }
            else
            {
                panelBotonClinica.Height = 210;
                PanelBotonLaboratorio.Height = 50;

                menuPrincipal.Width = 250;
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void reloj_Click(object sender, EventArgs e)
        {

        }

        private void btnMiPerfil_click(object sender, EventArgs e)
        {
            frmPerfil Perfil = new frmPerfil();
            AbrirFormInPanel(Perfil);
            this.panelCont.Show();
        }



        //abre dentro del panel el frm
        private void AbrirFormInPanel(Object Formhijo)
        {
            if (this.panelCont.Controls.Count > 0)
                this.panelCont.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelCont.Controls.Add(fh);
            this.panelCont.Tag = fh;
            fh.Show();
        }

        private void btnIngresarDoctorLab_Click(object sender, EventArgs e)
        {
            frmDoctor ingresarDoctor= new frmDoctor();
            AbrirFormInPanel(ingresarDoctor);
            this.panelCont.Show();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.panelCont.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            aboutUs creditos = new aboutUs();
            AbrirFormInPanel(creditos);
            this.panelCont.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmPaciente frmPaciente = new frmPaciente();
            AbrirFormInPanel(frmPaciente);
            this.panelCont.Show();
        }
    }
}
