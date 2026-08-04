# PPS-Proyecto

-------------------------------------------------------------------------------------------------------------------------------
-- ===========================================================================================================================
-- TABLA DE USUARIOS Y PREGUNTAS DE SEGURIDAD (CREACIÓN Y SEEDING DE DATOS PARA LOGIN)
-- ===========================================================================================================================
USE ConsultorioPsicopedagogico;

-- 1. Tabla Concurrente (Tabla principal)
CREATE TABLE Concurrente (
    dniConcurrente VARCHAR(20) PRIMARY KEY,
    apellido VARCHAR(100) NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    fechaNacimiento DATE,
    diagnostico TEXT,
    escuela VARCHAR(150),
    anioEscolar VARCHAR(50),
    nivelEscolar VARCHAR(50),
    domicilio VARCHAR(200),
    activo BOOLEAN DEFAULT TRUE 
);

-- 2. Tabla Tutor (Tabla principal)
CREATE TABLE Tutor (
    dniTutor VARCHAR(20) PRIMARY KEY,
    apellido VARCHAR(100) NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    telefono VARCHAR(50),
    email VARCHAR(100),
    obraSocial VARCHAR(100),
    activo BOOLEAN DEFAULT TRUE 
);

-- 3. Tabla Área (Tabla principal)
CREATE TABLE Area (
    idArea INT PRIMARY KEY,
    nombreArea VARCHAR(100) NOT NULL,
    activo BOOLEAN DEFAULT TRUE
);

-- 4. Tabla Parentesco (Relaciona Concurrente y Tutor)
CREATE TABLE Parentesco (
    dniConcurrente VARCHAR(20),
    dniTutor VARCHAR(20),
    relacion VARCHAR(50),
    PRIMARY KEY (dniConcurrente, dniTutor),
    FOREIGN KEY (dniConcurrente) REFERENCES Concurrente(dniConcurrente) 
        ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (dniTutor) REFERENCES Tutor(dniTutor) 
        ON DELETE CASCADE ON UPDATE CASCADE
);

-- 5. Tabla Turnos (Depende de Concurrente)
CREATE TABLE Turnos (
    idTurno INT PRIMARY KEY,
    dniConcurrente VARCHAR(20),
    fecha DATE,
    hora TIME,
    activo BOOLEAN DEFAULT TRUE, 
    FOREIGN KEY (dniConcurrente) REFERENCES Concurrente(dniConcurrente) 
        ON DELETE CASCADE ON UPDATE CASCADE
);

-- 6. Tabla Informe (Depende de Concurrente)
CREATE TABLE Informe (
    idInforme INT PRIMARY KEY,
    dniConcurrente VARCHAR(20),
    fechaInforme DATE,
    FOREIGN KEY (dniConcurrente) REFERENCES Concurrente(dniConcurrente) 
        ON DELETE CASCADE ON UPDATE CASCADE
);

-- 7. Tabla Informe Área (Relaciona Informe y Área)
CREATE TABLE Informe_Area (
    idInforme INT,
    idArea INT,
    descripcionArea TEXT,
    PRIMARY KEY (idInforme, idArea),
    FOREIGN KEY (idInforme) REFERENCES Informe(idInforme) 
        ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (idArea) REFERENCES Area(idArea) 
        ON DELETE CASCADE ON UPDATE CASCADE
);


-- 1. Tabla para almacenar el listado de preguntas predefinidas
CREATE TABLE IF NOT EXISTS PreguntaSeguridad (
    PreguntaID INT AUTO_INCREMENT PRIMARY KEY,
    PreguntaTexto VARCHAR(255) NOT NULL UNIQUE
);

-- 2. Modificación de la tabla Usuario para que haga referencia al ID de la pregunta
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
