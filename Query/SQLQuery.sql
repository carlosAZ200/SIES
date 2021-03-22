CREATE DATABASE SIES
On Primary
(Name = SIESdatos, 
Filename = 'C:\sqlserver\SIES\SIES.MDF',
Size = 5MB,
MaxSize = 10MB,
Filegrowth = 20%)
Log on
(Name = SIESLog,
Filename = 'C:\sqlserver\SIES\SIESLog.ldf',
size = 5MB,
Maxsize = 10MB,
Filegrowth = 1MB)



use SIES;


create table es_usuarios(
	USU_id int identity(1,1),
	USU_documento varchar(20) primary key,
	USU_tipodoc varchar(50),
	USU_nombre varchar(50),
	USU_celular varchar(20),
	USU_email varchar(50),
	USU_genero varchar(50),
	USU_aprendiz bit null,
	USU_egresado bit null,
	USU_areaformacion varchar(100) null,
	USU_fechaegresado date null,
	USU_direccion varchar(50),
	USU_barrio varchar(50),
	USU_ciudad varchar(50),
	USU_departamento varchar(50),
	USU_fecharegistro date
); 

insert into es_usuarios (
	USU_documento ,
	USU_tipodoc ,
	USU_nombre ,
	USU_celular ,
	USU_email ,
	USU_genero ,
	USU_aprendiz ,
	USU_egresado ,
	USU_areaformacion ,
	USU_fechaegresado ,
	USU_direccion ,
	USU_barrio ,
	USU_ciudad ,
	USU_departamento,
	USU_fecharegistro
) values 

	('1023', 'CC', 'Carlos', '129213', '@email', 'M', 1, 1, 'asd', GETDATE(), 'asdk', 'asd', 'dos', 'tres', GETDATE()),
	('1024', 'CC', 'Carlos', '129213', '@email', 'M', 0, 0, 'asd', GETDATE(), 'asdk', 'asd', 'dos', 'tres', GETDATE()),
	('1025', 'CC', 'Carlos', '129213', '@email', 'M', 0, 0, 'asd', GETDATE(), 'asdk', 'asd', 'dos', 'tres', '13-01-2021'),
	('1026', 'CC', 'Carlos', '129213', '@email', 'M', 0, 0, 'asd', GETDATE(), 'asdk', 'asd', 'dos', 'tres', '13-01-2021')
;

select * from es_usuarios;

delete from es_usuarios
	--where USU_id = 3;


alter table es_usuarios alter column USU_celular varchar(20) 

SELECT 
*
FROM 
es_usuarios
WHERE USU_fecharegistro > '13-01-2021'
