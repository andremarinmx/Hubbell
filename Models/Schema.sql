CREATE DATABASE Hubbell;
USE Hubbell;
CREATE TABLE EmpleadosMes(
	Id INT PRIMARY KEY IDENTITY(1,1),
	NumReloj INT,
	Fecha VARCHAR(10)
);

CREATE TABLE FotoEmpleadosMes(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Img VARCHAR(MAX),
	Fecha VARCHAR(10)
);

CREATE TABLE Vacantes(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Img VARCHAR(MAX),
	Fecha VARCHAR(10),
	Planta VARCHAR(7),
);

CREATE TABLE Topicos(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Img VARCHAR(MAX),
	Fecha VARCHAR(10)
);

CREATE TABLE MejoraContinuaProyectos(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Titulo VARCHAR(50),
	Categoria VARCHAR(50),
	Integrantes VARCHAR(200),
	RecoleccionDatos VARCHAR(500),
	SituacionActualFoto VARCHAR(MAX),
	CausaPotencial VARCHAR(150),
	CausaRaiz VARCHAR(50),
	MedidasMejora VARCHAR(50),
	FechaInicio VARCHAR(10),
	ResultadoFoto VARCHAR(MAX),
	Beneficios VARCHAR(500),
	Comentarios VARCHAR(500),
	FechaCierre VARCHAR(10),
);