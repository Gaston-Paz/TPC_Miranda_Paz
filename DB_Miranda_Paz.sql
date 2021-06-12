CREATE DATABASE DB_Miranda_Paz
GO
USE DB_Miranda_Paz
GO
CREATE TABLE Especialidades(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Nombre VARCHAR(60) NOT NULL
)
INSERT INTO Especialidades
VALUES('Alergia'),('Alergia infant�l'),('Cardiolog�a'),('Cirug�a'),('Cirug�a infant�l'), ('Cirug�a pl�stica'),('Cl�nica m�dica'), ('Dermatolog�a'), ('Dermatolog�a infant�l'),('Endocrinolog�a'), 
('Endocrinolog�a infant�l'),('Flebolog�a'), ('Gastroenterolog�a'),('Gastroenterolog�a infant�l'), ('Ginecolog�a'),('Ginecolog�a infant�l'), ('Hematolog�a'), ('Hepatolog�a'), ('Infectolog�a'),
('Medicina del deporte'),('Neurolog�a'),('Neurolog�a infant�l'),('Neumonolog�a'),('Neumonolog�a infant�l'),('Nutrici�n'),('Nutrici�n infant�l'), ('Oftalmolog�a'), ('Oncolog�a'),('Otorrinolaringolog�a'),
('Pediatr�a'), ('Proctolog�a'), ('Reumatolog�a'), ('Traumatolog�a'), ('Urolog�a')
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
VALUES('Nuevo'), ('Cancelado'),('Reprogramado'),('No asisti�'),('Atendido')
GO
CREATE TABLE Turnos(
	Id INT PRIMARY KEY IDENTITY(1,1),
	IdPaciente INT FOREIGN KEY REFERENCES Pacientes (Id) NOT NULL,
	IdMedico INT FOREIGN KEY REFERENCES Medicos (Id) NOT NULL,
	FechaHora DATETIME NOT NULL CHECK(FechaHora >= GETDATE()),
	IdEstado INT FOREIGN KEY REFERENCES EstadosTurnos (Id) NOT NULL,
	IdEspecialidad INT FOREIGN KEY REFERENCES Especialidades (Id) NOT NULL
)