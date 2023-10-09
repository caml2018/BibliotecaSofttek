use master;
CREATE DATABASE DbTestBibliotecaSofttek
ON
(
	NAME = Biblioteca_dat,
	FILENAME='C:\database\biblioteca.mdf',
	SIZE=1GB,
	MAXSIZE=UNLIMITED,
	FILEGROWTH=50MB
)
LOG ON
(
	NAME= Biblioteca_log,
	FILENAME='C:\database\biblioteca.ldf',
	SIZE=512MB,
	MAXSIZE=1GB,
	FILEGROWTH=10%
)

SELECT name, database_id, create_date
FROM sys.databases

USE [DbTestBibliotecaSofttek]
GO
CREATE USER testsoft FOR LOGIN testsoft


CREATE SCHEMA [biblioteca] AUTHORIZATION [testsoft]
GO

GRANT SELECT, UPDATE, DELETE, INSERT, CREATE SCHEMA biblioteca TO testsoft;
GO

USE [DbTestBibliotecaSofttek]
GO
--, Año, Genero, Número de páginas, Auto

DROP TABLE [biblioteca].[libro]
CREATE TABLE [biblioteca].[libro](
	id int IDENTITY(1,1) NOT NULL,
	titulo varchar(50),
	año int,
	genero varchar(50),
	numeroPaginas int,
	autorId int
	PRIMARY KEY (id)
	CONSTRAINT FK_libro_autor
	FOREIGN KEY (autorId)
	REFERENCES [biblioteca].[autor](id)
)
--Nombre completo, Fecha de nacimiento, Ciudad de procedencia, Correo electrónico
CREATE TABLE [biblioteca].[autor](
	id int IDENTITY(1,1) NOT NULL,
	nombreCompleto varchar(80),
	fechaNacimiento Date,
	ciudadProcedencia varchar(50),
	correoElectronico varchar(60)
	PRIMARY KEY (id)
)

