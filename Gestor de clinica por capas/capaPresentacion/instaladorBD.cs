using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capaPresentacion
{
    public partial class instaladorBD : Form
    {
        
        public string baseDeDatos = "master";
        public string security = "Integrated security = SSPI;";
        public string server = "localhost;";

        public static List<string> lista;
        public static int porcentaje;
        public static bool actualizar= false;
        public SqlConnection cnn;
        public bool bandera = false;
        public string sql;

        public string[] proc = new string[35];
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();

        

        public instaladorBD()
        {
            InitializeComponent();
            generarConexion();
        }

        public void generarConexion() {
            SetText("Generando conexion: Server = "+server+ security + "database = " + baseDeDatos);
            cnn = new SqlConnection("Server="+server + security + "database=" + baseDeDatos);
        }

        private void instaladorBD_Load(object sender, EventArgs e)
        {
            t.Interval = 1000;

            t.Tick += new EventHandler(this.t_Tick);

            t.Start();
        }

        private void t_Tick(Object sender, EventArgs e)
        {
            lblConexion.Text = cnn.ConnectionString;
            if (progressBar1.Value == 100) {
                button1.Enabled = true;
                string cnns = cnn.ConnectionString;
                escribirConneccion(cnns);
                SetPorc("0");
            }
            try
            {
                if (actualizar)
                {
                    //listBox1.Items.Clear();
                    foreach (string item in lista)
                    {
                        listBox1.Items.Add(item);
                    }
                    actualizar = false;
                }
            } catch (Exception exe)
            {
            }
        }
            private void CrearBD() {

            
            SetText("----------Creando Base de datos----------");
                sql = "CREATE DATABASE GestorDeClinicaBD";
                if (exeConexion(sql))
                {
                //exeConexion(sql);
                SetPorc("1");
                }
                else {
                var op = MessageBox.Show("Al pacerer la base de datos ya existe, ¿Desea borrarla y reescribir los datos?", "Base de datos ya existe", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (op.ToString() == "Yes")
                {
                    sql = "use master; DROP DATABASE GestorDeClinicaBD";
                    SetPorc("2");
                }
                else
                {
                    SetPorc("0");
                    Application.Exit();
                }
                if (exeConexion(sql))
                {
                    SetText("--Base de datos eliminada");
                    sql = "CREATE DATABASE GestorDeClinicaBD";
                    if (exeConexion(sql))
                    {
                        SetText("--Base de datos creada");
                        generarConexion();
                        SetPorc("3");
                    }
                    else
                    { SetText("--No se pudo crear la Base de datos"); SetPorc("0"); }
                }
                else
                {
                    SetText("--No se pudo eliminar la base de datos");
                    SetPorc("0");
                }
            }

            SetText("----------Creando Login clinicaAdmin----------");
            sql = "use GestorDeClinicaBD; Create Login adminClinica with PASSWORD = 'admin123'";
            if (exeConexion(sql))
            {
                SetText("--[BD] usuario Creado");
                SetPorc("4");
                generarConexion();
            }
            else
            {
                SetText("--[BD Error] probablemente ya esté creado el login");
                generarConexion();
                SetPorc("4");
            }
            SetText("----------Creando Usuario----------");
            sql = "use GestorDeClinicaBD; CREATE USER adminClinica FOR LOGIN adminClinica;";
            if (exeConexion(sql))
            {
                SetText("--[Permiso de usuario] Se creó con exito");
                baseDeDatos = "GestorDeClinicaBD";
                generarConexion();
                SetPorc("5");
            }
            else
            {
                SetText("--[Permiso de usuario] No se pudo crear");
                baseDeDatos = "GestorDeClinicaBD";
                generarConexion();
                SetPorc("5");
            }
            SetText("----------Creando esquema clinicas----------");
            sql = "create schema clinicas AUTHORIZATION adminClinica;";
            if (exeConexion(sql))
            {
                SetPorc("6");
            }
            else
            {
                SetText("--[BD Error] No se Encontro la base de datos");
                SetPorc("0");
            }

            SetText("----------asignando esquema a user y asignar permisos----------");
            sql = "use GestorDeClinicaBD; ALTER USER adminClinica WITH DEFAULT_SCHEMA = clinicas; GRANT SELECT ON SCHEMA :: clinicas to adminClinica with GRANT OPTION; GRANT INSERT ON SCHEMA :: clinicas to adminClinica with GRANT OPTION; GRANT UPDATE ON SCHEMA :: clinicas to adminClinica with GRANT OPTION; GRANT DELETE ON SCHEMA :: clinicas to adminClinica with GRANT OPTION; GRANT exec ON SCHEMA :: clinicas to adminClinica with GRANT OPTION;";
            if (exeConexion(sql))
            {
                SetText("--[Permiso de usuario] Se creó con exito");
                security = "Uid = adminClinica; " + "Pwd = admin123;";
                baseDeDatos = "GestorDeClinicaBD";
                SetPorc("7");
            }
            else
            {
                SetText("--[Permiso de usuario] No se pudo crear");
                security = "Uid = adminClinica; " + "Pwd = admin123;";
                baseDeDatos = "GestorDeClinicaBD";
                SetPorc("7");
            }





            SetText("----------Creando Tabla Clinica----------");
            sql = "use GestorDeClinicaBD; create table clinicas.clinica (ID_Clinica int not null identity primary key,descripcion varchar(255))";
            if (exeConexion(sql))
            {
                SetText("--[Tabla Clinica] Se creó con exito");
                SetPorc("8");
            }
            else
            {
                SetText("--[Tabla Clinica] No se pudo crear");
            }
            SetText("----------Creando Tabla paciente----------");
            sql = "use GestorDeClinicaBD; CREATE TABLE clinicas.paciente (ID_Paciente int identity not null primary key,Nombre varchar (50),Apellido varchar (50),Direccion varchar(100),Telefono int,Email varchar (50),Fecha_Nacimiento date, Sexo varchar(15),Fk_IDClinica int not null foreign key (Fk_IDClinica) references clinicas.Clinica(id_Clinica))";
            if (exeConexion(sql))
            {
                SetText("--[Tabla paciente] Se creó con exito");
                SetPorc("9");
            }
            else
            {
                SetText("--[Tabla paciente] No se pudo crear");
            }
            SetText("----------Creando Tabla rol----------");
            sql = "use GestorDeClinicaBD; create table clinicas.rol(idRol int identity not null primary key,nombreRol varchar(255))";
            if (exeConexion(sql))
            {
                SetText("--[Tabla rol] Se creó con exito");
                SetPorc("10");
            }
            else
            {
                SetText("--[Tabla rol] No se pudo crear");
            }
            SetText("----------Creando Tabla permiso----------");
            sql = "use GestorDeClinicaBD; create table clinicas.Permiso(idPermisos int identity not null primary key,formulario varchar(255),fk_rol int foreign key(fk_rol) references clinicas.rol(idRol))";
            if (exeConexion(sql))
            {
                SetText("--[Tabla permiso] Se creó con exito");
                SetPorc("11");
            }
            else
            {
                SetText("--[Tabla permiso] No se pudo crear");
            }

            SetText("----------Creando Tabla usuario----------");
            sql = "use GestorDeClinicaBD; CREATE TABLE clinicas.usuario(ID_usuario varchar(50) not null primary key,Pass varchar(50) not null,Nombre varchar(50),Apellido varchar(50),Direccion varchar(100),Telefono varchar(9),Dui varchar(14),Genero varchar (15),fotografia varchar(max),FK_Rol int not null foreign key (FK_Rol) references	clinicas.Rol(idRol),Fk_IDClinica int not null foreign key (Fk_IDClinica) references clinicas.Clinica(id_Clinica))";
            if (exeConexion(sql))
            {
                SetText("--[Tabla usuario] Se creó con exito");
                SetPorc("12");
            }
            else
            {
                SetText("--[Tabla usuario] No se pudo crear");
            }
            SetText("----------Creando Tabla notificaciones----------");
            sql = "use GestorDeClinicaBD; CREATE TABLE clinicas.notificacion(Id_Notificacion int identity not null primary key,Emisor varchar(50),Mensaje varchar(255),Fk_IDUsuario varchar(50) not null foreign key (Fk_IDUsuario) references clinicas.usuario(ID_usuario))";
            if (exeConexion(sql))
            {
                SetText("--[Tabla notificaciones] Se creó con exito");
                SetPorc("13");
            }
            else
            {
                SetText("--[Tabla notificaciones] No se pudo crear");
            }
            SetText("----------Creando Tabla doctor----------");
            sql = "use GestorDeClinicaBD; create table clinicas.doctor(Id_Doctor int not null identity primary key,especialidad varchar(255),descripcion_Personal varchar(255), Fk_IDUsuario varchar(50) unique not null foreign key (Fk_IDUsuario) references clinicas.usuario(ID_usuario))";
            if (exeConexion(sql))
            {
                SetText("--[Tabla doctor] Se creó con exito");
                SetPorc("14");
            }
            else
            {
                SetText("--[Tabla doctor] No se pudo crear");
            }
            SetText("----------Creando Tabla laboratorio----------");
            sql = "use GestorDeClinicaBD; create table clinicas.laboratorio(id_Laboratorio int identity not null primary key,Fk_IDClinica int not null foreign key (Fk_IDClinica) references clinicas.Clinica(id_Clinica), Descripcion varchar (255))";
            if (exeConexion(sql))
            {
                SetText("--[Tabla laboratorio] Se creó con exito");
                SetPorc("15");
            }
            else
            {
                SetText("--[Tabla laboratorio] No se pudo crear");
            }

            

            SetText("----------Creando Tabla cita----------");
            sql = "use GestorDeClinicaBD; Create table clinicas.cita(id_Cita int identity not null primary key,fecha date,Descripcion varchar(255),precio decimal,Fk_IdPaciente int not null foreign key (Fk_IdPaciente) references clinicas.Paciente(Id_Paciente),Fk_IdDoctor int not null foreign key (Fk_IdDoctor) references clinicas.Doctor(Id_Doctor))";
            if (exeConexion(sql))
            {
                SetText("--[Tabla cita] Se creó con exito");

                SetPorc("16");
            }
            else
            {
                SetText("--[Tabla cita] No se pudo crear");
            }
            SetText("----------Creando Tabla tipoEstudio----------");
            sql = "use GestorDeClinicaBD; Create table clinicas.tipoEstudio(IdTipo_Estudio int identity not null primary key,Fk_Laboratorio int not null foreign key (Fk_Laboratorio) references clinicas.Laboratorio(ID_Laboratorio),Nombre varchar (50),Precio decimal)";
            if (exeConexion(sql))
            {
                SetText("--[Tabla tipoEstudio] Se creó con exito");
                SetPorc("17");
            }
            else
            {
                SetText("--[Tabla tipoEstudio] No se pudo crear");
            }
            SetText("----------Creando Tabla factura----------");
            sql = "use GestorDeClinicaBD; create table clinicas.factura(Id_Factura int identity not null primary key,total decimal,descuentos decimal,impuestos decimal,FK_IDPaciente int not null foreign key (fk_IDPaciente) references clinicas.Paciente(ID_Paciente))";
            if (exeConexion(sql))
            {
                SetText("--[Tabla factura] Se creó con exito");
                SetPorc("18");
            }
            else
            {
                SetText("--[Tabla factura] No se pudo crear");
            }
            SetText("----------Insertando datos----------");
            sql = "INSERT INTO clinicas.clinica Values('admin'),('General'),('Laboratorio');";
            sql += "INSERT INTO clinicas.rol Values('admin'),('Doctores'),('Secretarios');";
            sql += "INSERT INTO clinicas.Permiso values('Doctores',1),('Pacientes',1),('Citas',1),('Estudios',1),('Usuarios',1);";
            sql += "INSERT INTO clinicas.Permiso values('Pacientes',2),('Citas',2),('Estudios',2);";
            sql += "INSERT INTO clinicas.Permiso values('Pacientes',3),('Citas',3);";
            sql += "INSERT INTO clinicas.usuario values('admin0','admin123', 'nombreAdmin','Apellidoadmin','DirAd','0','0','m',null,1,1);";
            sql += "INSERT INTO clinicas.usuario values('admin1','admin123', 'nombreAdmin','Apellidoadmin','DirAd','0','0','m',null,2,2)";
            sql += "INSERT INTO clinicas.usuario values('admin2','admin123', 'nombreAdmin','Apellidoadmin','DirAd','0','0','m',null,3,3)";

            SetPorc("19");
            if (exeConexion(sql))
            {
                SetText("--[Insertando datos] Se creó con exito");

                SetPorc("20");
            }
            else
            {
                SetText("--[Insertando datos] No se pudo crear");
            }
            SetText("----------Creando Procedimientos almacenados----------");
            proc[0] = "CREATE PROCEDURE clinicas.SPIniciarSesion( @usuario varchar(50), @pass varchar(50) ) as select * from clinicas.usuario where id_usuario=@usuario and pass = @pass; ";
            proc[1] = "CREATE PROCEDURE clinicas.verClinica( @id_Clinica int ) as --creamos la consulta que vamos a mandar a llamar desde el programa select * from clinicas.clinica where id_Clinica= @id_clinica; ";
            proc[2] = "CREATE PROCEDURE clinicas.insertarClinica( @tipo varchar(25) ) as insert into clinicas.clinica values(@tipo); ";
            proc[3] = "CREATE PROCEDURE clinicas.borrarClinica( @id_Clinica int ) as delete from clinicas.clinica where id_Clinica = @id_Clinica; ";
            proc[4] = "CREATE PROCEDURE clinicas.modificarClinica( @id_Clinica int, @descripcion varchar(255) ) as UPDATE clinicas.clinica set descripcion= @descripcion Where id_Clinica = @id_Clinica; ";
            proc[5] = "CREATE PROCEDURE Clinicas.IngresarPaciente ( @Nombre varchar (50), @Apellido varchar (50), @Direccion varchar(100), @Telefono int, @Email varchar (50), @Fecha_Nacimiento date, @Sexo varchar(15), @FK_Clinica int ) as insert into Clinicas.Paciente values (@Nombre, @Apellido, @Direccion, @Telefono, @Email, @Fecha_Nacimiento,@Sexo, @FK_Clinica); ";
            proc[6] = "CREATE PROCEDURE Clinicas.ModificarPaciente (@ID_Paciente int, @Nombre varchar(50), @Apellido varchar (50), @Direccion varchar(100), @Telefono int, @Email varchar (50), @Fecha_Nacimiento date, @Sexo varchar(15), @FK_Clinica int ) as update clinicas.Paciente set Nombre = @Nombre, Apellido = @Apellido, Direccion = @Direccion, Telefono = @Telefono, Email = @Email, Fecha_Nacimiento = @Fecha_Nacimiento, Sexo = @Sexo, Fk_IDClinica = @FK_Clinica where ID_Paciente = @ID_Paciente; ";
            proc[7] = "CREATE PROCEDURE Clinicas.EliminarPaciente (@ID_Paciente int) as delete from paciente where @ID_Paciente= ID_Paciente ";
            proc[8] = "CREATE PROCEDURE clinicas.verUsuario( @id_usuario varchar(50) ) as select * from clinicas.usuario inner join clinicas.clinica On clinicas.usuario.Fk_IDClinica = clinicas.clinica.ID_Clinica where ID_usuario = @id_usuario; ";
            proc[9] = "CREATE PROCEDURE clinicas.BuscarUsuario( @ID_Usuario varchar(50) ) as SELECT * FROM clinicas.usuario WHERE id_usuario LIKE @ID_Usuario ; ";
            proc[10] = "CREATE PROCEDURE clinicas.modificarUsuario( @id_usuario varchar(50), @Pass varchar(50) , @Nombre varchar(50), @Apellido varchar(50), @Direccion varchar(100), @Telefono varchar(9), @Dui varchar(14), @Genero varchar (15), @fotografia varchar(max) ) as UPDATE clinicas.usuario set Pass = @Pass, Nombre = @Nombre, Apellido = @Apellido,Direccion = @Direccion, Telefono = @Telefono,Dui = @Dui,Genero=@Genero, fotografia = @fotografia Where id_usuario = @id_usuario; ";
            proc[11] = "CREATE PROCEDURE clinicas.modificarUsuarioRol( @id_usuario varchar(50), @Pass varchar(50) , @Nombre varchar(50), @Apellido varchar(50), @Direccion varchar(100), @Telefono varchar(9), @Dui varchar(14), @Genero varchar (15), @fotografia varchar(max), @FK_Rol int, @Fk_IDClinica int ) as UPDATE clinicas.usuario set Pass = @Pass, Nombre = @Nombre, Apellido = @Apellido,Direccion = @Direccion, Telefono = @Telefono,Dui = @Dui,Genero=@Genero, FK_Rol= @FK_Rol, Fk_IDClinica = @Fk_IDClinica Where id_usuario = @id_usuario; ";
            proc[12] = "CREATE PROCEDURE clinicas.insertarUsuario( @id_usuario varchar(50), @Pass varchar(50) , @Nombre varchar(50), @Apellido varchar(50), @Direccion varchar(100), @Telefono varchar(9), @Dui varchar(14), @Genero varchar (15), @fotografia varchar(max), @FK_Rol int, @Fk_IDClinica int ) as INSERT INTO clinicas.usuario values(@id_usuario, @Pass, @Nombre, @Apellido,@Direccion, @Telefono,@Dui,@Genero,@fotografia,@FK_Rol, @Fk_IDClinica) ";
            proc[13] = "CREATE PROCEDURE clinicas.enviarNotificacion( @emisor varchar(50), @mensaje varchar(255), @FK_IDusuario varchar(50) ) as insert into clinicas.notificacion values(@emisor,@mensaje,@FK_IDusuario ); ";
            proc[14] = "CREATE PROCEDURE clinicas.borrarNotificacion( @id_notificacion int ) as delete from clinicas.notificacion where id_notificacion = @id_notificacion; ";
            proc[15] = "CREATE PROCEDURE clinicas.verNotificacion( @id_usuario varchar(50) ) as select * from clinicas.notificacion where FK_IDusuario = @id_usuario ";
            proc[16] = "CREATE PROCEDURE clinicas.insertarDoctor( @especialidad varchar(255), @descripcion_Personal varchar(255), @Fk_IDUsuario varchar(50) ) as insert into clinicas.doctor values(@especialidad,@descripcion_Personal,@Fk_IDUsuario); ";
            proc[17] = "CREATE PROCEDURE clinicas.verDoctores( @Fk_IDUsuario varchar(50) ) as SELECT * FROM clinicas.doctor; ";
            proc[18] = "CREATE PROCEDURE clinicas.borrarDoctores( @id_usuario varchar(50) ) as DELETE FROM clinicas.doctor WHERE Fk_IDUsuario = @id_usuario; ";
            proc[19] = "CREATE PROCEDURE clinicas.BuscarDoctor( @Fk_IDUsuario varchar(50) ) as SELECT * FROM clinicas.doctor WHERE FK_IDusuario LIKE @Fk_IDUsuario ; ";
            proc[20] = "CREATE PROCEDURE Clinicas.IngresarLaboratorio (@id_Laboratorio int, @Descripcion varchar(255) ) as insert into laboratorio values(@id_Laboratorio, @Descripcion) ";
            proc[21] = "CREATE PROCEDURE Clinicas.BorrarLaboratorio (@id_Laboratorio int) as delete from laboratorio where @id_Laboratorio=id_Laboratorio ";
            proc[22] = "CREATE PROCEDURE Clinicas.VerLaboratorio (@id_Laboratorio int) as select * from laboratorio where @id_Laboratorio= id_Laboratorio ";
            proc[23] = "CREATE PROCEDURE Clinicas.ActualizarLaboratorio (@id_Laboratorio int, @Descripcion varchar(255)) as update Clinicas.laboratorio set Descripcion = @Descripcion where @id_Laboratorio=id_Laboratorio ";
            proc[24] = "CREATE PROCEDURE Clinicas.IngresarCitas (@fecha date, @Descripcion varchar (255), @precio decimal(18,0), @Fk_IdPaciente int, @Fk_IdDoctor int ) as insert into cita values (@fecha,@Descripcion,@precio,@Fk_IdPaciente,@Fk_IdDoctor) ";
            proc[25] = "CREATE PROCEDURE Clinicas.BorrarCita (@id_Cita int) as delete from cita where @id_Cita=id_Cita ";
            proc[26] = "CREATE PROCEDURE Clinicas.VerCita (@id_Cita int) as select * from cita where @id_Cita = id_Cita ";
            proc[27] = "CREATE PROCEDURE Clinicas.ActualizarCita (@id_Cita int, @fecha date, @Descripcion varchar (255), @precio decimal(18,0), @Fk_IdPaciente int, @Fk_IdDoctor int ) as update clinicas.cita set fecha= @fecha, Descripcion = @Descripcion, precio = @precio, Fk_IdPaciente = @Fk_IdPaciente, Fk_IdDoctor = @Fk_IdDoctor where @id_Cita= id_Cita ";
            proc[28] = "CREATE PROCEDURE Clinicas.IngresarTpEstudio (@idTipo_Estudio int, @Nombre varchar(150), @precio decimal(18,0)) as insert into tipoEstudio values (@idTipo_Estudio,@Nombre,@precio) ";
            proc[29] = "CREATE PROCEDURE Clinicas.BorrarTpEstudio (@idTipo_Estudio int) as delete from tipoEstudio where @idTipo_Estudio=IdTipo_Estudio ";
            proc[30] = "CREATE PROCEDURE Clinicas.VerTpEstudio (@idTipo_Estudio int) as select * from tipoEstudio where @idTipo_Estudio = IdTipo_Estudio ";
            proc[31] = "CREATE PROCEDURE Clinicas.ActualizarTpEstudio (@idTipo_Estudio int, @precio decimal(18,0)) as update Clinicas.tipoEstudio set precio = @precio where @idTipo_Estudio=IdTipo_Estudio ";
            proc[32] = "CREATE PROCEDURE clinicas.verPermisos( @ID_rol int ) as select * from clinicas.Permiso WHERE fk_rol = @ID_rol; ";
            proc[33] = "CREATE PROCEDURE Clinicas.actualizarDoctor (@especialidad varchar(255),@descripcion_Personal varchar(255),@Fk_IDUsuario varchar(50))as update Clinicas.doctor set especialidad = @especialidad, descripcion_Personal = @descripcion_Personal where @Fk_IDUsuario= Fk_IDUsuario";
            proc[34] = "CREATE PROCEDURE Clinicas.BorrarUsuario (@id_usuario varchar(50)) as delete from clinicas.usuario where clinicas.usuario.ID_usuario = @id_usuario";


            leerProcedimientos();
        }

        private bool exeConexion(string cmd) {
            
            try
            {
                cnn.Close();
                SqlCommand cm = new SqlCommand(cmd, cnn);
                cnn.Open();
                SetText("--[Ejecutando] " + cmd);
                cm.ExecuteNonQuery();
                SetText("--[Exito]");
                cnn.Close();
                bandera = true;
                return true;

            }
            catch (Exception exe)
            {
                if (!bandera)
                {
                    try
                    {
                        cnn.Close();
                        string pcName = Environment.MachineName;
                        server = pcName+";";
                        generarConexion();
                        SqlCommand cm = new SqlCommand(cmd, cnn);
                        cnn.Open();
                        instaladorBD.actualizar = true;
                        cm.ExecuteNonQuery();
                        cnn.Close();
                        bandera = true;
                        return true;
                    }
                    catch (Exception exex)
                    {
                        try
                        {

                            try
                            {
                                string pcName = Environment.MachineName;
                                cnn.Close();
                                server = pcName + "\\SQLEXPRESS;";
                                generarConexion();
                                SqlCommand cm = new SqlCommand(cmd, cnn);

                                cnn.Open();

                                cm.ExecuteNonQuery();

                                cnn.Close();
                                bandera = true;
                                return true;
                            }
                            catch (Exception exexx)
                            {
                                string pcName = Environment.MachineName;
                                server = "(localdb)\\" + pcName + ";";
                                generarConexion();
                                SqlCommand cm = new SqlCommand(cmd, cnn);
                                cnn.Open();
                                cm.ExecuteNonQuery();
                                cnn.Close();
                                bandera = true;
                                return true;
                            }
                        }
                        catch (Exception exexxx)
                        {
                            try
                            {
                                cnn.Close();
                                string pcName = Environment.MachineName;
                                server = pcName + "\\sqlexpress;";
                                generarConexion();
                                SqlCommand cm = new SqlCommand(cmd, cnn);
                                cnn.Open();
                                cm.ExecuteNonQuery();
                                cnn.Close();
                                bandera = true;
                                return true;
                            }
                            catch (Exception exexxxx)
                            {
                                SetText("--[Error] Hubo un error al ejecutar" + cmd);
                                return false;
                            }
                        }
                    }
                }
                else {
                    
                        SetText("--[Error] "+ exe);
                        return false;
                    
                }
            }
        }

        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void StringArgReturningVoidDelegate(string text);

        public void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.listBox1.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {

                this.listBox1.Items.Add(text);
            }
        }

        public void SetPorc(string p)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.listBox1.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(SetPorc);
                this.Invoke(d, new object[] { p});
            }
            else
            {

                progressBar1.Value = (Convert.ToInt32(p) * 100) / 54;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThreadStart childref = new ThreadStart(CrearBD);
            Thread childThread = new Thread(childref);
            button2.Enabled = false;
            childThread.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void leerProcedimientos() {
            int p=20;
            
            foreach (string sOutput in proc) {
                exeConexion(sOutput);
                SetPorc(p++.ToString());
            }
        }

        public void escribirConneccion(string conexionStr) {
            try
            {
                GenerarTXT(conexionStr);
            }
            catch (Exception exe) {
                GenerarTXT(conexionStr);
            }
        }

        void GenerarTXT(string conexionStr)
        {
            string rutaCompleta = Path.Combine(Application.StartupPath, "conexion.txt");
            string texto = conexionStr;
            SetText(Path.Combine(Path.Combine(Application.StartupPath)));
            using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
            {
                mylogs.WriteLine(texto);
                mylogs.Close();
            }
        }
    }
}
