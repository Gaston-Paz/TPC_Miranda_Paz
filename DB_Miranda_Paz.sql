CREATE DATABASE DB_Miranda_Paz
GO
USE DB_Miranda_Paz
GO
CREATE TABLE Especialidades(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Nombre VARCHAR(60) NOT NULL
)
INSERT INTO Especialidades
VALUES('Alergia'),('Alergia infantíl'),('Cardiología'),('Cirugía'),('Cirugía infantíl'), ('Cirugía plástica'),('Clínica médica'), ('Dermatología'), ('Dermatología infantíl'),('Endocrinología'), 
('Endocrinología infantíl'),('Flebología'), ('Gastroenterología'),('Gastroenterología infantíl'), ('Ginecología'),('Ginecología infantíl'), ('Hematología'), ('Hepatología'), ('Infectología'),
('Medicina del deporte'),('Neurología'),('Neurología infantíl'),('Neumonología'),('Neumonología infantíl'),('Nutrición'),('Nutrición infantíl'), ('Oftalmología'), ('Oncología'),('Otorrinolaringología'),
('Pediatría'), ('Proctología'), ('Reumatología'), ('Traumatología'), ('Urología')
GO
CREATE TABLE Medicos(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Nombre VARCHAR (60) NOT NULL,
	Apellido VARCHAR (60) NOT NULL,
	Matricula VARCHAR(20) NOT NULL,
	IdEspecialidad INT FOREIGN KEY REFERENCES Especialidades (Id) NOT NULL,
	Email VARCHAR (100) NOT NULL,
	Pass VARCHAR (100) NOT NULL,
	Dni VARCHAR (15) NOT NULL,
	Telefono VARCHAR (20) NULL,
	/*AGENDA*/
)
GO
CREATE TABLE Recepcionista(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Nombre VARCHAR (60) NOT NULL,
	Apellido VARCHAR (60) NOT NULL,
	Email VARCHAR (100) NOT NULL,
	Pass VARCHAR (100) NOT NULL,
	Dni VARCHAR (15) NOT NULL,
	Telefono VARCHAR (20) NULL
)
GO
CREATE TABLE Administrador(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Nombre VARCHAR (60) NOT NULL,
	Apellido VARCHAR (60) NOT NULL,
	Email VARCHAR (100) NOT NULL,
	Pass VARCHAR (100) NOT NULL,
	Dni VARCHAR (15) NOT NULL,
	Telefono VARCHAR (20) NULL
)
GO
CREATE TABLE Pacientes(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Nombre VARCHAR (60) NOT NULL,
	Apellido VARCHAR (60) NOT NULL,
	Dni VARCHAR (15) NOT NULL,
	Email VARCHAR (100) NOT NULL,
	Telefono VARCHAR (20) NULL,
	FechaNac DATE NOT NULL
)
GO
CREATE TABLE EstadosTurnos(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Nombre VARCHAR (30) NOT NULL
)
GO
INSERT INTO EstadosTurnos
VALUES('Nuevo'), ('Cancelado'),('Reprogramado'),('No asistió'),('Atendido')
GO
CREATE TABLE Turnos(
	Id INT PRIMARY KEY IDENTITY(1,1),
	IdPaciente INT FOREIGN KEY REFERENCES Pacientes (Id) NOT NULL,
	IdMedico INT FOREIGN KEY REFERENCES Medicos (Id) NOT NULL,
	FechaHora DATETIME NOT NULL CHECK(FechaHora >= GETDATE()),
	IdEstado INT FOREIGN KEY REFERENCES EstadosTurnos (Id) NOT NULL,
	IdEspecialidad INT FOREIGN KEY REFERENCES Especialidades (Id) NOT NULL
)