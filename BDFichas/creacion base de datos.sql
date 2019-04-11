CREATE DATABASE BDFichas
ON
  (NAME = BDFichas,    -- Primary data file
  FILENAME = 'D:\Proyecto\BDFichas.mdf',
  SIZE = 5MB,
  FILEGROWTH = 1MB
  )
  LOG ON
  (NAME = BDFichas_log,   -- Log file
  FILENAME = 'D:\Proyecto\BDFichas.ldf',
  SIZE = 5MB,
  FILEGROWTH = 1MB
  )
go
use BDFichas

/* ********************************************************************
                        CREACION DE TIPOS
   ******************************************************************** */
EXEC  sp_addtype  TCodAlunmo,	        'varchar(6)',  'not null'
EXEC  sp_addtype  TCodFicha, 	    	'varchar(6)',  'not null'
EXEC  sp_addtype  TCodVenta,    		'varchar(4)',   'not null'

go
USE BDFichas
/* ********************************************************************
                        CREACION DE TABLAS
   ******************************************************************** */
---1---Creación de la Tabla Alumno ------
IF EXISTS(SELECT * FROM SysObjects WHERE Type='U' AND Name='TAlumno')
   DROP TABLE TAlumno
GO

create table TAlumno
  (
    CodAlumno       TCodAlunmo,  
    Nombres          varchar(70)   not null,
    Primary key (CodAlumno)
  )
GO


---2---Creación de la Tabla TFicha ------
IF EXISTS(SELECT * FROM SysObjects WHERE Type='U' AND Name='TFicha')
   DROP TABLE TFicha
GO

create table TFicha
  (
    CodFicha       TCodFicha,    
    Curso       varchar(50)   not null,
	NombreGuia   Varchar(50) not null
	PRIMARY KEY(CodFicha)
  )
GO


---3---Creación de la Tabla Venta ------
IF EXISTS(SELECT * FROM SysObjects WHERE Type='U' AND Name='TVenta')
   DROP TABLE TVenta
GO

create table TVenta
  (
 
    CodVenta TCodVenta,
	FechaVenta datetime,
	Precio    decimal(10,2),
	Cantidad  varchar(2),	
	CodAlumno TCodAlunmo,
	CodFicha TCodFicha,
	PRIMARY KEY(CodVenta),	
	Foreign Key (CodAlumno)References TAlumno,
	Foreign Key (CodFicha)References TFicha
)
GO
                                                                    
