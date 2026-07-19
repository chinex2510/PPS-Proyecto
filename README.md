# PPS-Proyecto

-------------------------------------------------------------------------------------------------------------------------------
-- ===========================================================================================================================
-- TABLA DE USUARIOS Y PREGUNTAS DE SEGURIDAD (CREACIÓN Y SEEDING DE DATOS PARA LOGIN)
-- ===========================================================================================================================
USE ConsultorioPsicopedagogico;

-- 1. Tabla para almacenar el listado de preguntas predefinidas
CREATE TABLE IF NOT EXISTS PreguntaSeguridad (
    PreguntaID INT AUTO_INCREMENT PRIMARY KEY,
    PreguntaTexto VARCHAR(255) NOT NULL UNIQUE
);

-- 2. Modificación de la tabla Usuario para que haga referencia al ID de la pregunta
CREATE TABLE IF NOT EXISTS Usuario (
    DNI INT PRIMARY KEY,
    Matricula VARCHAR(50) UNIQUE NOT NULL,
    NombreApellido VARCHAR(150) NOT NULL,
    Email VARCHAR(150) NOT NULL,
    Especialidad VARCHAR(100),
    Contrasena VARCHAR(255) NOT NULL,
    PreguntaID INT NOT NULL,
    Respuesta VARCHAR(255) NOT NULL,
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
INSERT INTO Usuario (DNI, Matricula, NombreApellido, Email, Especialidad, Contrasena, PreguntaID, Respuesta)
SELECT 12345678, 'celeste', 'Celeste Rodriguez', 'celeste@example.com', 'Psicopedagoga', '123456', 1, 'Fido'
FROM dual
WHERE NOT EXISTS (SELECT 1 FROM Usuario WHERE Matricula = 'celeste');
