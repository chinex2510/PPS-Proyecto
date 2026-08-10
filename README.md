# PPS-Proyecto

-------------------------------------------------------------------------------------------------------------------------------
-- ===========================================================================================================================
-- TABLA DE USUARIOS Y PREGUNTAS DE SEGURIDAD (CREACIÓN Y SEEDING DE DATOS PARA LOGIN)
-- ===========================================================================================================================
create database BD_Final;
use BD_Final;

-- 1. Tabla Concurrente (Tabla principal)
select * from concurrente;
CREATE TABLE Concurrente (
    idConcurrente INT AUTO_INCREMENT PRIMARY KEY,
    dniConcurrente VARCHAR(20) UNIQUE NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    fechaNacimiento DATE,
    diagnostico TEXT,
    escuela VARCHAR(150),
    anioEscolar VARCHAR(50),
    nivelEscolar VARCHAR(50),
    domicilio VARCHAR(200),
    activo BOOLEAN DEFAULT TRUE -- <-- CAMPO PARA BAJA LÓGICA
);

-- 2. Tabla Tutor (Tabla principal)
select * from tutor;
CREATE TABLE Tutor (
    idTutor INT AUTO_INCREMENT PRIMARY KEY,
    dniTutor VARCHAR(20) UNIQUE NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    telefono VARCHAR(50),
    email VARCHAR(100),
    obraSocial VARCHAR(100),
    activo BOOLEAN DEFAULT TRUE -- <-- CAMPO PARA BAJA LÓGICA
);

-- 4. Tabla Parentesco (Relaciona Concurrente y Tutor)
select * from parentesco;
CREATE TABLE Parentesco (
    idConcurrente INT,
    idTutor INT,
    relacion VARCHAR(50),
    PRIMARY KEY (idConcurrente, idTutor),
    FOREIGN KEY (idConcurrente) REFERENCES Concurrente(idConcurrente) 
        ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (idTutor) REFERENCES Tutor(idTutor) 
        ON DELETE CASCADE ON UPDATE CASCADE
);

-- 5. Tabla Turnos (Depende de Concurrente y Usuario)
select * from turnos;
CREATE TABLE Turnos (
    idTurno INT AUTO_INCREMENT PRIMARY KEY,
    dniConcurrente VARCHAR(20) NOT NULL,
    nombreConcurrente VARCHAR(150) NOT NULL,    -- Nombre del paciente (independiente de Concurrente)
    dniUsuario INT NOT NULL,                 -- Relación con el Especialista (Usuario)
    fecha DATE NOT NULL,
    hora TIME NOT NULL,
    estado VARCHAR(20) DEFAULT 'Confirmado',
    activo BOOLEAN DEFAULT TRUE,             -- Para borrado lógico
    CONSTRAINT FK_Turnos_Usuario 
        FOREIGN KEY (dniUsuario) 
        REFERENCES Usuario(DNI) 
        ON DELETE CASCADE ON UPDATE CASCADE,
    -- Evita que un especialista tenga dos turnos a la misma hora en la misma fecha
    CONSTRAINT UQ_Turno_EspecialistaFechaHora UNIQUE (dniUsuario, fecha, hora),
    -- Evita que un paciente tenga dos turnos a la misma hora en la misma fecha
    CONSTRAINT UQ_Turno_PacienteFechaHora UNIQUE (dniConcurrente, fecha, hora)
);

-- 6. Tabla Informe (Depende de Concurrente)
select * from informe;
CREATE TABLE Informe (
    idInforme INT AUTO_INCREMENT PRIMARY KEY,
    idConcurrente INT NOT NULL,
    fechaInforme DATE,
    titulo VARCHAR(150),
    rutaWord VARCHAR(255),
    FOREIGN KEY (idConcurrente) REFERENCES Concurrente(idConcurrente) 
        ON DELETE CASCADE ON UPDATE CASCADE
);

-- 1. Tabla para almacenar el listado de preguntas predefinidas
select * from PreguntaSeguridad;
CREATE TABLE IF NOT EXISTS PreguntaSeguridad (
    PreguntaID INT AUTO_INCREMENT PRIMARY KEY,
    PreguntaTexto VARCHAR(255) NOT NULL UNIQUE
);

-- 2. Modificación de la tabla Usuario para que haga referencia al ID de la pregunta
select * from usuario;
CREATE TABLE IF NOT EXISTS Usuario (
    DNI INT PRIMARY KEY,
    Usuario VARCHAR(50) UNIQUE NOT NULL,
    NombreApellido VARCHAR(150) NOT NULL,
    Email VARCHAR(150) NOT NULL,
    Contrasena VARCHAR(255) NOT NULL,
    PreguntaID INT NOT NULL,
    Respuesta VARCHAR(255) NOT NULL,
    Rol VARCHAR(50) NOT NULL,
    FOREIGN KEY (PreguntaID) REFERENCES PreguntaSeguridad(PreguntaID)
);

-- 3. Cargar las preguntas de seguridad por defecto
INSERT INTO PreguntaSeguridad (PreguntaTexto) 
VALUES 
('¿Cuál fue el nombre de tu primera mascota?'),
('¿Cuál es el nombre de tu escuela primaria?'),
('¿Cuál es tu comida favorita?'),
('¿Cuál es tu película favorita?')
ON DUPLICATE KEY UPDATE PreguntaTexto=VALUES(PreguntaTexto);

-- 4. Insertar el usuario de prueba por defecto si no existe (con pregunta ID 1)
INSERT INTO Usuario (DNI, Usuario, NombreApellido, Email, Contrasena, PreguntaID, Respuesta, Rol)
SELECT 12345678, 'celeste', 'Celeste Rodriguez', 'celeste@example.com', '123456', 1, 'Fido', 'Medico/a'
FROM dual
WHERE NOT EXISTS (SELECT 1 FROM Usuario WHERE Usuario = 'celeste');

