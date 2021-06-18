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
	Estado BIT DEFAULT(1)
)
GO
CREATE TABLE Dias(
	Id SMALLINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Nombre VARCHAR (15) NOT NULL
)
GO
CREATE TABLE MedicosDisponiblesxDia(
	IdMedico INT FOREIGN KEY REFERENCES Medicos (Id),
	IdDia SMALLINT FOREIGN KEY REFERENCES DIAS(Id),
	HoraEntrada SMALLINT NOT NULL,
	HoraSalida SMALLINT NOT NULL,
	PRIMARY KEY (IdMedico, IdDia)
)
GO
INSERT INTO Medicos
VALUES ('Joaquin', 'Achaval Duria', 'M116688' , '1', 'AchavalDuria@Joaquin.com', 'joacoduria', '98975462', '(387) 962-2847','1'),
('Isidoro', 'Arostegui', 'M115544', '1','Aros@Isidoro.com', 'isidorotegui', '54782136','(695) 920-0076','1'),
('Elizabeth Carolina', 'Ayala', 'M112244', '2', 'eayala@google.com', 'eliaya', '33225588', '(695) 920-0054','1'),
('Alejandro Agustin', 'Badano', 'M659878', '2', 'agustin@badano.com', 'alebadano', '40578945','(357) 874-7957','1'),
('Paola Elizabeth', 'Barrios', 'M221168', '3','pneighborhood@me.dev', 'paobarrios', '35410621','(946) 907-8987','1'),
('Lucas', 'Crucci', 'M871547', '3','lcrucci@hotmail.com.pe', 'crucelucas', '32568974','(389) 615-9729','1'),
('Emiliano', 'Del Pino', 'M789456', '4','efromthepine@notmyrealmail.com', 'emidelpi', '45678912','(368) 886-5181','1'),
('Federico Damian', 'Di Fulvio', 'M547812',  '4', 'fdifulvio@gmail.com', 'fedediful', '78956412', '(368) 886-5879','1'),
('Matias Andres', 'Fahler', 'M123265', '5', 'matifa@yahoo.com', 'fahmati', '12457896', '(186) 828-6592','1'),
('Bruno Alexis', 'Ferrante', 'M748745', '5', 'ferrante@alexis.com', 'ferralexis', '45871236', '(926) 973-5945','1'),
('Alexis Damian', 'Figueira', 'M147852', '6','afigueira@hotmail.com.uy', 'alexfigue', '37896254', '(926) 973-5978','1'),
('Cecilia Verónica', 'Galarza', 'M789147', '6', 'cgalarza@utn.edu.ar', 'cecigala', '12301478', '(926) 974-1245','1'),
('Alejandro Matias', 'Gazzo', 'M352698', '7', 'agazzo@notmyrealmail.com', 'alegazz', '32353631','(926) 547-1324','1'),
('Nahuel Alejandro', 'Godoy', 'M878984', '7', 'ngodoy@google.com', 'godona', '45625897', '(926) 589-7894','1'),
('Edgardo Simon', 'Gonzalez', 'M123456', '8', 'egonzalez@fakemail.com', 'sigon', '14774125', '(926 789-1478)','1'),
('Pablo Agustín', 'Ibazeta', 'M963258', '8', 'pibazeta@google.com', 'ibazagus', '84269357','(578) 581-0349','1'),
('Javier Agustin', 'Larroca', 'M159753', '9', 'jlarroca@hotmail.com.ar', 'javiagula', '19786247','(723) 346-3332','1'),
('Yesica Regina', 'Laurentino Goncalves', 'M756845', '9', 'ylaurentino@independiente.com', 'regilau', '65265398','(101) 716-0947','1'),
('Zair Andres', 'Mar Cardozo', 'M873214', '10', 'zmar@hotmail.com.uy', 'zamarca', '35231456','(203) 991-1918','1'),
('Jonathan Daniel', 'Martinez', 'M852258', '10', 'danimartinez@trucho.com', 'martidani', '75454789', '(328) 853-6797','1'),
('German Emanuel', 'Mena', 'M6852145', '11', 'menager@elmail.com', 'germanuel', '65124578', '(859) 564-9626','1'),
('Maximiliano Guillermo', 'Miranda', 'M897465', '11', 'mmiranda@hotmail.com.ar', 'soymaxi', '36546852','(346) 791-8453','1'),
('Bruno Mauricio', 'Molteni', 'M714724', '12', 'bmolteni@hotmail.com.uy', 'soybruno', '32313233', '(346) 741-2589','1'),
('Ignacio', 'Petrignani Castro', 'M138726', '12', 'ipetrignani@notmyrealmail.com', 'ignasoy', '12315978','(558) 813-4402','1'),
('Valentin', 'Plaza', 'M639846', '13', 'vplaza@notmyrealmail.com', 'valensoy', '45666666','(779) 742-0557','1'),
('Alexander Alberto', 'Popp', 'M157486', '13', 'apopp@google.com', 'popis', '45555444','(488) 244-5467','1'),
('Matias Joel', 'Quintana Soria', 'M111111', '14', 'mquintana@hotmail.com.pe', 'quintaso', '99888777','(669) 213-0345','1'),
('Leonardo Ezequiel', 'Alpuin Schunk', 'M116699', '14', 'AlpuinLeo@Schunk.com', 'leoezequiel', '98987879', '(387) 962-2457','1'),
('Adriel Elian', 'Rasjido', 'M221121', '15', 'arasjido@frgp.utn.edu.ar', 'adriras', '25444666', '(332) 7-4438','1'),
('Agustin Lautaro', 'Robles', 'M221111', '15', 'arobles@hotmail.com.ar', 'laurob', '25545654','(970) 885-0929','1'),
('Matias', 'Sanchez Villar', 'M223122', '16', 'msanchez@fakemail.com', 'matisanvi', '30251478','(533) 285-8591','1'),
('Leonardo Martin', 'Scalesi', 'M663355', '16', 'leomartin@outlook.ra', 'calesi', '32111333', '(806) 630-4551','1'),
('Tomas', 'Scutti', 'M161748', '17', 'tscutti@notmyrealmail.com', 'cutito', '32333444','(169) 249-0460','1'),
('Walter Emmanuel', 'Stamm', 'M888999', '17', 'wstamm@argentina.ar', 'tamwal', '35566988', '(332) 789-4438','1'),
('Mathias Leandro', 'Tejeda', 'M774411', '18', 'mtejeda@hotmail.com', 'tejelean', '45698896','(963) 306-5247','1'),
('Daniel Alejandro', 'Trunso', 'M411511', '18', 'trunso@fotolog.com', 'fotoale', '45784147', N'(977) 335-7032','1'),
('Elmer Dennis', 'Vasquez Quispe', 'M655453', '19', 'elmervas@elmail.com', 'soyelmer', '36999888', '(324) 635-0486','1'),
('Sofia Noemi', 'Vigliaccio', 'M444123', '19', 'svigliaccio@frgp.utn.edu.ar', 'sofisoy', '44321581','(564) 377-2363','1'),
('Alejandro', 'Virasoro', 'M688978', '20', 'avirasoro@hotmail.com.ar', 'virajandro', '37548788', '(789) 789-2541','1'),
('Luciano Federico', 'Yomayel', 'M111111', '20', 'lyomayel@hotmail.com', 'luchiano', '25631125','(625) 229-4746','1')
GO
CREATE TABLE Recepcionistas(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Nombre VARCHAR (60) NOT NULL,
	Apellido VARCHAR (60) NOT NULL,
	Email VARCHAR (100) NOT NULL,
	Pass VARCHAR (100) NOT NULL,
	Dni VARCHAR (15) NOT NULL,
	Telefono VARCHAR (20) NULL,
	Estado BIT DEFAULT(1)
)
GO
INSERT INTO Recepcionistas
VALUES ('Florencia', 'Rodriguez', 'flor-rodriguez@mail.com', '123456', '37059672', '1144558899','1'),
('Agustina', 'Perez', 'aguspe@mail.com', '789456', '37059678', '1155447788','1'),
('Rodrigo', 'Alsina', 'rodrial@mail.com', '159753', '35789877', '1122554477','1')
GO
CREATE TABLE Administradores(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Nombre VARCHAR (60) NOT NULL,
	Apellido VARCHAR (60) NOT NULL,
	Email VARCHAR (100) NOT NULL,
	Pass VARCHAR (100) NOT NULL,
	Dni VARCHAR (15) NOT NULL,
	Telefono VARCHAR (20) NULL,
	Estado BIT DEFAULT(1)
)
GO
INSERT INTO Administradores
VALUES ('Gastón', 'Paz', 'gastonpaz@mail.com', 'gaspaz', '38013023', '1165656565','1'),
('Maximiliano', 'Miranda','maximiranda@mail.com', 'mirama', '38014024', '1145454545','1')
GO
CREATE TABLE Pacientes(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Nombre VARCHAR (60) NOT NULL,
	Apellido VARCHAR (60) NOT NULL,
	Dni VARCHAR (15) NOT NULL,
	Email VARCHAR (100) NOT NULL,
	Telefono VARCHAR (20) NULL,
	FechaNac DATE NOT NULL,
	Estado BIT DEFAULT(1)
)
GO
CREATE TABLE EstadosTurnos(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Nombre VARCHAR (30) NOT NULL
)
GO
INSERT INTO EstadosTurnos
VALUES('Nuevo'),('Cancelado'),('Reprogramado'),('No asistió'),('Atendido')
GO
CREATE TABLE Turnos(
	Id INT PRIMARY KEY IDENTITY(1,1),
	IdPaciente INT FOREIGN KEY REFERENCES Pacientes (Id) NOT NULL,
	IdMedico INT FOREIGN KEY REFERENCES Medicos (Id) NOT NULL,
	FechaHora DATETIME NOT NULL CHECK(FechaHora >= GETDATE()),
	IdEstado INT FOREIGN KEY REFERENCES EstadosTurnos (Id) NOT NULL,
	IdEspecialidad INT FOREIGN KEY REFERENCES Especialidades (Id) NOT NULL
)