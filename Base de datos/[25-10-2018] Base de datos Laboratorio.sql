/*
	1- los datos dentro de cada paciente tendra la duracion de 30 dias cada uno para evitar la saturacion de datos, ya que sql server gratuito tiene un limite y la clinica hace lo mismo pero en papeleria
	2- esta base de datos esta sujeta a cambios dependiendo los requisitos de la clinica
	3- Se creará un login para evitar errores al momento de cambiar de pc y evitar errores en el sistema
	4- al ejecutar este codigo, salir de sql server management e iniciarlo de nuevo pero con login adminClinica y password admin123
	5- se crearan procedimientos almacenados para hacer las peticiones de forma mas rapida
*/
use master
go

 --para borrar la base de datos, hay que estar en el loogin de tu pc normal
 drop database GestorDeClinica
 GO

 create database GestorDeClinica
 go

use GestorDeClinica
go

create table clinica --especificamos que tipo de clinica almacenaremos
(ID_Clinica int not null identity primary key,
descripcion varchar(255), 
)
GO

CREATE TABLE paciente --Registros del paciente
(ID_Paciente int identity not null primary key,
Nombre varchar (50),
Apellido varchar (50),
Direccion varchar(100),
Telefono int,
Email varchar (50),
Fecha_Nacimiento date, 
Sexo varchar(15),
Fk_IDClinica int not null foreign key (Fk_IDClinica) references Clinica(id_Clinica) -- a que clinica pertenece el paciente
)
GO



CREATE TABLE usuario-- se creó para evitar redundancia de datos entre doctores y empleados, ya que comparten datos en comun
(
ID_usuario varchar(50) not null primary key,
Pass varchar(50) not null,
Nombre varchar(50),
Apellido varchar(50),
Direccion varchar(100),
Telefono varchar(9),
Dui varchar(14),
Genero varchar (15),-- si es hombre o mujer
fotografia varchar(max),
Fk_IDClinica int not null foreign key (Fk_IDClinica) references Clinica(id_Clinica) -- a que clinica pertenece el empleado
)
GO



CREATE TABLE notificacion
(
Id_Notificacion int identity not null primary key,
Emisor varchar(50),
Mensaje varchar(255),
FK_IDusuario varchar(50) not null foreign key (fk_IDusuario) references usuario(ID_usuario)
)
GO

create table doctor
(Id_Doctor int not null identity primary key,--con identity no es necesario estarle poniendo datos en la primary key, el solo le pone datos
especialidad varchar(255),--especifica a que se dedica, si es odontologo, laboratirista, ginecologo, tecnologo, etc...
descripcion_Personal varchar(255), --informacion extra que quiera aportar el doctor
Fk_IDUsuario varchar(50) not null foreign key (Fk_IDUsuario) references usuario(id_usuario) -- a que clinica pertenece el doc
)
GO

create table laboratorio
(id_Laboratorio int identity not null primary key,
Fk_IDClinica int not null foreign key (Fk_IDClinica) references Clinica(id_Clinica), 
Descripcion varchar (255)
)
GO

Create table cita
(id_Cita int identity not null primary key,
fecha date,
Descripcion varchar(255),
precio decimal,
Fk_IdPaciente int not null foreign key (Fk_IdPaciente) references Paciente(Id_Paciente),
Fk_IdDoctor int not null foreign key (Fk_IdDoctor) references Doctor(Id_Doctor)
)
GO

Create table tipoEstudio
(
IdTipo_Estudio int identity not null primary key,
Fk_Laboratorio int not null foreign key (Fk_Laboratorio) references Laboratorio(ID_Laboratorio),
Nombre varchar (50),
Precio decimal
)
GO

create table factura(
Id_Factura int identity not null primary key,
total decimal,
descuentos decimal,
impuestos decimal,
FK_IDPaciente int not null foreign key (fk_IDPaciente) references Paciente(ID_Paciente)
)
GO

create table rol(
idRol int identity not null primary key,
nombreRol varchar(255),
fk_Usuario varchar(50) foreign key (fk_Usuario) references Usuario(ID_Usuario)
)
GO

create table Permiso(
idPermisos int identity not null primary key,
formulario varchar(255),
fk_rol int foreign key (fk_rol) references rol(idRol)
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
ALTER SCHEMA clinicas TRANSFER usuario;
ALTER SCHEMA clinicas TRANSFER notificacion;
ALTER SCHEMA clinicas TRANSFER doctor;
ALTER SCHEMA clinicas TRANSFER laboratorio;
ALTER SCHEMA clinicas TRANSFER cita;
ALTER SCHEMA clinicas TRANSFER tipoEstudio;
ALTER SCHEMA clinicas TRANSFER factura;
ALTER SCHEMA clinicas TRANSFER permiso;
ALTER SCHEMA clinicas TRANSFER rol;

GO
--Creando usuario administrador
--creando clinicas
INSERT INTO clinicas.clinica Values('admin'),('General'),('Laboratorio'),('Odontologia');
GO
	--Creo un usuario administrador en la base de datos, siempre debe haber alguien para ingresar datos en el programa
INSERT INTO clinicas.usuario values('admin0','admin123', 'nombreAdmin','Apellidoadmin','DirAd','0','0','m',null,1)
select * from clinicas.usuario;
GO

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


GO

-------------Procedimientos almacenados
	--Los procedimientos almacenados ayudan a hacer las peticiones mas rapidas en el programa 
	--procedimiento para iniciar sesion

create procedure clinicas.SPIniciarSesion(
	@usuario varchar(50),
	@pass varchar(50)
)
as
		select * from clinicas.usuario
		where id_usuario=@usuario and pass = @pass
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
	@descripcion varchar(255)
)
as 
	UPDATE clinicas.clinica
	set descripcion= @descripcion
	Where id_Clinica = @id_Clinica
GO



	--Creando mantenimiento Paciente

	--Creando mantenimiento antecedentes de pacientes

	--creando mantenimiento empleados

	--creando mantenimiento notificaciones

		create procedure clinicas.verNotificacion(
			@id_usuario varchar(50)--//para verificar de quien es el mensaje
		)
		as
			select * from clinicas.notificacion
			where FK_IDusuario = @id_usuario
		GO

		insert into clinicas.notificacion values('administrador','--Hola esta es una prueva de notificacion gracias!','admin0')
		GO
		insert into clinicas.notificacion values('administrador','--gracias! 2','admin0')
		GO
		insert into clinicas.notificacion values('administrador','--jeje 2','admin0')
		GO
		exec clinicas.verNotificacion @id_usuario = 'admin0'
		GO
		create procedure clinicas.enviarNotificacion(
			
			@emisor varchar(50),
			@receptor varchar(50),
			@mensaje varchar(255)
		)
		as
			insert into clinicas.notificacion
			values(@emisor,@receptor,@mensaje);
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

