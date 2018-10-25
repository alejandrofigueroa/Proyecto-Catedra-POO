/*
	1- los datos dentro de cada paciente tendra la duracion de 30 dias cada uno para evitar la saturacion de datos, ya que sql server gratuito tiene un limite y la clinica hace lo mismo pero en papeleria
	2- esta base de datos esta sujeta a cambios dependiendo los requisitos de la clinica
	3- Se creará un login para evitar errores al momento de cambiar de pc y evitar errores en el sistema
	4- al ejecutar este codigo, salir de sql server management e iniciarlo de nuevo pero con login adminClinica y password admin123
	5- se crearan procedimientos almacenados para hacer las peticiones de forma mas rapida
*/
use master
go

drop database IF EXISTS GestorDeClinica --para borrar la base de datos, hay que estar en el loogin de tu pc normal
GO

create database GestorDeClinica
go

use GestorDeClinica
go

create table clinica --especificamos que tipo de clinica almacenaremos
(id_Clinica int not null identity primary key,
Tipo varchar(25), --si es odontologia, laboratorio o general
)
GO

INSERT INTO clinica Values('admin'),('General'),('Laboratorio'),('Odontologia');
GO

CREATE TABLE paciente --Registros del paciente
(id_Paciente char(6) not null primary key,
Nombre varchar (50),
Apellido varchar (50),
Direccion varchar(100),
Telefono int,
Email varchar (50),
Fecha_Nacimiento date, 
Sexo varchar(15),
dui varchar(25),
Fk_IDClinica int not null foreign key (Fk_IDClinica) references Clinica(id_Clinica) -- a que clinica pertenece el paciente
)
GO

Create table antecedente--se creó para que el doctor tenga los antecedentes del paciente y no tenga incombenientes a la hora de darle una medicina
(id_antecedentes int not null primary key,
Alergia varchar (1000),
Tipo_Sangre varchar (1000),
Peso float,
Altura float,
descripcion_Personal char(255),--informacion extra que quiera aportar el paciente
Fk_IdPaciente char(6) not null foreign key (FK_IdPaciente) references Paciente(Id_Paciente)
)
GO

CREATE TABLE empleado-- se creó para evitar redundancia de datos entre doctores y empleados, ya que comparten datos en comun
(
id_Empleado char(6) not null primary key,
Nombre varchar(50),
Apellido varchar(50),
Direccion varchar(100),
Telefono int,
Dui int,
Genero varchar (15),-- si es hombre o mujer
usuario varchar(50) not null UNIQUE, --con unique nos aseguramos que los usuarios sean diferentes
pass varchar(50) not null,
rol varchar(50),
fotografia varchar(max),
Fk_IDClinica int not null foreign key (Fk_IDClinica) references Clinica(id_Clinica) -- a que clinica pertenece el empleado
)
GO

CREATE TABLE notificacion
(
id_notificacion int identity not null primary key,
emisor char(50),
receptor char(50),
mensaje char(255),
FK_IDEmpleado char(6) not null foreign key (fk_IDEmpleado) references empleado(id_Empleado)
)
GO

create table doctor
(id_Doctor int not null identity primary key,--con identity no es necesario estarle poniendo datos en la primary key, el solo le pone datos
especialidad char(255),--especifica a que se dedica, si es odontologo, laboratirista, ginecologo, tecnologo, etc...
descripcion_Personal char(255), --informacion extra que quiera aportar el doctor
Fk_IDEmpleado char(6) not null foreign key (Fk_IDEmpleado) references empleado(id_Empleado) -- a que clinica pertenece el doc
)
GO

create table laboratorio
(id_Laboratorio char (6)not null primary key,
Fk_IDClinica int not null foreign key (Fk_IDClinica) references Clinica(id_Clinica), 
Descripcion varchar (1000)
)
GO

Create table cita
(id_Cita char(6) not null primary key,
fecha date,
Descripcion varchar(1000),
Fk_IdPaciente char(6) not null foreign key (Fk_IdPaciente) references Paciente(Id_Paciente),
Fk_IdDoctor int not null foreign key (Fk_IdDoctor) references Doctor(Id_Doctor)
)
GO

create table consulta
( Id_Consulta char(6)not null primary key,
Fk_Cita char(6) not null foreign key (Fk_Cita) references Cita(Id_Cita),
Tratamiento varchar(1000)
)
GO

create table dental
(
Id_Dental char(6) not null primary key,
Tratamiento varchar(1000),
Detalle varchar(1000),
Piezas varchar (1000),
Fk_IdClinica int not null foreign key (Fk_IdClinica) references Clinica(id_Clinica)
)
GO

Create table tipoEstudio
(
IdTipo_Estudio char(6) not null primary key,
Fk_Laboratorio char(6) not null foreign key (Fk_Laboratorio) references Laboratorio(ID_Laboratorio),
Nombre varchar (50),
Precio float
)
GO


--creando Login administrador
	--el administrador nos servirá para logearnos en la base de datos y no nos de error al conectarnos en el programa
Create Login adminClinica
with PASSWORD = 'admin123'
GO

--creamos un esquema para que el usuario que crearemos pueda acceder
create schema clinicas
GO
--agregamos las tablas dentro del esquema
ALTER SCHEMA clinicas TRANSFER clinica;
Alter SCHEMA clinicas TRANSFER paciente;
ALTER SCHEMA clinicas TRANSFER antecedente;
ALTER SCHEMA clinicas TRANSFER empleado;
ALTER SCHEMA clinicas TRANSFER notificacion;
ALTER SCHEMA clinicas TRANSFER doctor;
ALTER SCHEMA clinicas TRANSFER laboratorio;
ALTER SCHEMA clinicas TRANSFER cita;
ALTER SCHEMA clinicas TRANSFER consulta;
ALTER SCHEMA clinicas TRANSFER tipoEstudio;
ALTER SCHEMA clinicas TRANSFER dental;
GO
--Creando usuario administrador
--creamos un usuario para tener derecho a interactuar con la base de datos
CREATE USER adminClinica FOR LOGIN adminClinica
WITH DEFAULT_SCHEMA = clinicas
GO
--creamos los permisos del usuario para el esquema
GRANT SELECT ON SCHEMA :: clinicas to adminClinica with GRANT OPTION;--con esto le decimos a la base de datos que adminClinicas tiene permiso de hacer select a las tablas dentro del esquema
GRANT INSERT ON SCHEMA :: clinicas to adminClinica with GRANT OPTION;
GRANT UPDATE ON SCHEMA :: clinicas to adminClinica with GRANT OPTION;
GRANT DELETE ON SCHEMA :: clinicas to adminClinica with GRANT OPTION;
GRANT exec ON SCHEMA :: clinicas to adminClinica with GRANT OPTION;

	--Creo un usuario administrador en la base de datos, siempre debe haber alguien para ingresar datos en el programa
INSERT INTO clinicas.empleado values('admin0','admin', '','',0,0,'','AdminCL','admin123','admin',null,1)
select * from clinicas.empleado;
GO

-------------Procedimientos almacenados
	--Los procedimientos almacenados ayudan a hacer las peticiones mas rapidas en el programa 
	--procedimiento para iniciar sesion
create procedure clinicas.SPIniciarSesion(
	@usuario varchar(50),
	@pass varchar(50)
)
as
		select * from empleado
		where usuario=@usuario and pass = @pass;
GO

	--creando mantenimiento para clinica


create procedure clinicas.verClinica(
	@id_Clinica int--//el tipo de dato tiene que ser igual al de la tabla creada, en este caso el de id clinica
)
as
	--creamos la consulta que vamos a mandar a llamar desde el programa
		select * from clinicas.clinica
		where id_Clinica= @id_clinica;
GO

create procedure clinicas.insertarClinica(
	@tipo varchar(25)
)
as
	insert into clinicas.clinica
	values(@tipo)
GO


create procedure clinicas.borrarClinica(
	@id_Clinica int
)
as
		delete from clinicas.clinica
		where id_Clinica = @id_Clinica
GO

create procedure clinicas.modificarClinica(
	@id_Clinica int,
	@tipo varchar(25)
)
as 
	UPDATE clinicas.clinica
	set Tipo= @tipo
	Where id_Clinica = @id_Clinica
GO



	--Creando mantenimiento Paciente

	--Creando mantenimiento antecedentes de pacientes

	--creando mantenimiento empleados

	--creando mantenimiento notificaciones

		create procedure clinicas.verNotificacion(
			@id_empleado int--//para verificar de quien es el mensaje
		)
		as
			select * from clinicas.notificacion
			where FK_IDEmpleado = @id_empleado
		GO

		create procedure clinicas.enviarNotificacion(
			@Id_receptor char(6),
			@emisor varchar(50),
			@receptor varchar(50),
			@mensaje varchar(255)
		)
		as
			insert into clinicas.notificacion
			values(@emisor,@receptor,@mensaje,@ID_receptor);
		GO


		create procedure clinicas.borrarNotificacion(
			@id_notificacion int
		)
		as
			delete from clinicas.notificacion
			where id_notificacion = @id_notificacion;
		GO

	--creando mantenimiento doctor

	--creando mantenimiento laboratorio

	--creando mantenimiento citas

	--creando mantenimiento consulta

	--creando mantenimiento dental

	--creando mantenimiento tipo de estudios

