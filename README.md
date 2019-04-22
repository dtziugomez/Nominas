# Nominas
prueba tecnica
El proyecto trabaja con los siguiente script sql:


USE master
GO
CREATE DATABASE BDNOMINA20199
ON
(NAME='BDNOMINA20199_dat',
FILENAME='c:\BDNOMINA20199_dat.mdf',
SIZE=10,
MAXSIZE=50,
FILEGROWTH=5MB)
LOG ON
(NAME='BDNOMINA20199_log',
FILENAME='c:\BDNOMINA20199_log.ldf',
SIZE=5MB,
MAXSIZE=25MB,
FILEGROWTH=5MB)
GO
use BDNOMINA20199
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE name='Departamentos')
BEGIN
create table Departamentos(
 idDepartamento int not null identity(1,1),
 Descripcion varchar(200) not null,
 Eliminado bit default(0)
)
END 
GO
alter table Departamentos
add constraint pk_Departamentos
primary key(idDepartamento)

insert into Departamentos(Descripcion) values('ti');
insert into Departamentos(Descripcion) values('rh');


IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE name='Empleados')
BEGIN
create table Empleados(
 idEmpleado int not null identity(1,1),
 Nombre varchar(200) not null,
 Apellidos varchar(300) not null,
 Telefono varchar(50),
 Direccion varchar(100) not null,
 FechaIngreso datetime not null,
 SueldoBase money not null,
 idDepartamento int not null,
 Eliminado bit default(0)
)
END 
GO
alter table Empleados
add constraint pk_Empleados
primary key(idEmpleado)

alter table Empleados
add constraint FK_EmpleadosidEmpleado_DepartamentosidDepartamento  
foreign key(idDepartamento) references Departamentos(idDepartamento)



IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE name='Nominas')
BEGIN
create table Nominas(
 idNomina int not null identity(1,1),
 idEmpleado int not null,
 diasTrabajados int not null,
 horasExtras int not null,
 periodoDesde datetime not null,
 periodoHasta datetime not null,
 fechaCreacion datetime not null,
 Eliminado bit default(0)
)
END 
GO

alter table Nominas
add constraint pk_Nominas
primary key(idNomina)

alter table Nominas
add constraint FK_NominasidNomina_EmpleadosidEmpleado  
foreign key(idEmpleado) references Empleados(idEmpleado)



--consultar información por departamento o por empleado de cada periodo pago quincenal.
use BDNOMINA20199
IF OBJECT_ID ('[usp_spConsultarNominasEmpleado]') IS NOT NULL
	DROP PROCEDURE [usp_spConsultarNominasEmpleado]
  
GO
CREATE procedure [dbo].[usp_spConsultarNominasEmpleado](@claveEmpleado as int)
as
select Nombre,Apellidos,Telefono,Direccion,FechaIngreso,SueldoBase,Nominas.diasTrabajados,Nominas.horasExtras,
Nominas.periodoDesde,Nominas.periodoHasta
from Empleados inner join Nominas
on Empleados.idEmpleado=Nominas.idEmpleado
where Nominas.idEmpleado=@claveEmpleado


--*********************************************************
--procedimiento almacenado para realizar busquedas por empleado:

USE [BDNOMINA20199]
GO
/****** Object:  StoredProcedure [dbo].[usp_spConsultarNominasEmpleado]    Script Date: 04/05/2019 19:46:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_spConsultarNominas](@clave int,@tipoBusqueda int)
as
declare @datos table(
Nombre varchar(100),
Apellidos varchar(100),
Telefono varchar(50),
Direccion varchar(150),
FechaIngreso datetime,
SueldoBase money,
DiasTrabajados int,
horasExtras int,
periodoDesde datetime,
periodoHasta datetime,
CantidadPagada money
)
Declare @output TABLE(
Nombre varchar(100),
Apellidos varchar(100),
Telefono varchar(50),
Direccion varchar(150),
FechaIngreso datetime,
SueldoBase money,
DiasTrabajados int,
horasExtras int,
periodoDesde datetime,
periodoHasta datetime
)

declare @Nombre varchar(200)
declare @Apellidos varchar(300)
declare @Telefono varchar(50)
declare @Direccion varchar(100)
declare @FechaIngreso datetime
declare @SueldoBase money
declare @diasTrabajados int
declare @horasExtra int
declare @periodoDesde datetime
declare @periodoHasta datetime
declare @cantidadPagada money
if @tipoBusqueda=1
begin
insert into @output(Nombre,Apellidos,Telefono,Direccion,FechaIngreso,SueldoBase,DiasTrabajados,horasExtras,periodoDesde,periodoHasta)
select Nombre,Apellidos,Telefono,Direccion,FechaIngreso,SueldoBase,diasTrabajados,horasExtras,
	periodoDesde,periodoHasta from Empleados inner join Nominas
	on Empleados.idEmpleado=Nominas.idEmpleado
	where Empleados.idEmpleado=@clave	 
end
else if @tipoBusqueda=2
begin
insert into @output(Nombre,Apellidos,Telefono,Direccion,FechaIngreso,SueldoBase,DiasTrabajados,horasExtras,periodoDesde,periodoHasta)
select Nombre,Apellidos,Telefono,Direccion,FechaIngreso,SueldoBase,diasTrabajados,horasExtras,
	periodoDesde,periodoHasta from Empleados inner join Nominas
	on Empleados.idEmpleado=Nominas.idEmpleado
	where Empleados.idDepartamento=@clave	  
 
end

	
DECLARE contact_cursor CURSOR FOR
SELECT Nombre,Apellidos,Telefono,Direccion,FechaIngreso,SueldoBase,diasTrabajados,horasExtras,
	periodoDesde,periodoHasta FROM @output
OPEN contact_cursor;
FETCH NEXT FROM contact_cursor into @Nombre,@Apellidos,@Telefono,@Direccion,@FechaIngreso,@SueldoBase,
@diasTrabajados,@horasExtra,@periodoDesde,@periodoHasta
WHILE @@FETCH_STATUS = 0
	BEGIN
		insert into
		@datos([Nombre],[Apellidos], [Telefono],[Direccion],[FechaIngreso],[SueldoBase],[diasTrabajados],[horasExtras],[periodoDesde],[periodoHasta],[CantidadPagada])      
	    values (@Nombre,@Apellidos,@Telefono,@Direccion,@FechaIngreso,@SueldoBase,@diasTrabajados,@horasExtra,@periodoDesde,@periodoHasta,(@diasTrabajados*200)+(@horasExtra*50))

		FETCH NEXT FROM contact_cursor into @Nombre,@Apellidos,@Telefono,@Direccion,@FechaIngreso,@SueldoBase,
        @diasTrabajados,@horasExtra,@periodoDesde,@periodoHasta
	END
CLOSE contact_cursor;
DEALLOCATE contact_cursor;
select * from @datos



