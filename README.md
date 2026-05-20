<<<<<<< HEAD
# PPS-Proyecto
=======
-- Crear la base de datos
CREATE DATABASE IF NOT EXISTS ConsultorioPsicopedagogico;
-- drop database ConsultorioPsicopedagogico;
USE ConsultorioPsicopedagogico;

-- Tabla de Tutores
CREATE TABLE Tutor (
    DNI_Tutor INT PRIMARY KEY,
    Apellido VARCHAR(100) NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    Parentesco VARCHAR(50),
    Telefono VARCHAR(20),
    Email VARCHAR(100)
);

-- Tabla de Concurrentes
CREATE TABLE Concurrentes (
    DNI_C INT PRIMARY KEY,
    Apellido VARCHAR(100) NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    FechaNac DATE NOT NULL,
    Diagnostico TEXT,
    Escuela VARCHAR(255),
    AñoEscolar INT,
    NivelEscolar VARCHAR(50),
    Domicilio VARCHAR(255),
    Obrasocial VARCHAR(255),
    DNI_Tutor INT,
    FOREIGN KEY (DNI_Tutor) REFERENCES Tutor(DNI_Tutor)
);

-- Tabla de Turnos
CREATE TABLE Turnos (
    TurnoID INT AUTO_INCREMENT PRIMARY KEY,
    Fecha DATE NOT NULL,
    Hora TIME NOT NULL,
    DNI_C INT NOT NULL,
    FOREIGN KEY (DNI_C) REFERENCES Concurrentes(DNI_C)
);
---------------------------------------------------------------------------------------------------------------------------
USE ConsultorioPsicopedagogico;

-- ===============================================
-- INSERTAR REGISTROS EN LA TABLA Tutor
-- ===============================================
INSERT INTO Tutor (DNI_Tutor, Apellido, Nombre, Parentesco, Telefono, Email)
VALUES 
  (1, 'Gonzalez', 'Juan', 'Padre', '1234567890', 'juan.g@example.com'),
  (2, 'Perez', 'Maria', 'Madre', '0987654321', 'maria.p@example.com');

-- ===============================================
-- INSERTAR REGISTROS EN LA TABLA Concurrentes
-- ===============================================
INSERT INTO Concurrentes (DNI_C, Apellido, Nombre, FechaNac, Diagnostico, Escuela, AñoEscolar, NivelEscolar, Domicilio, Obrasocial, DNI_Tutor)
VALUES 
  (1, 'Rodriguez', 'Luis', '2010-03-15', 'Ansiedad', 'Escuela Primaria #1', 5, 'Primaria', 'Av. Siempre Viva 123', 'OSDE', 1),
  (2, 'Sanchez', 'Ana', '2011-07-20', 'TDAH', 'Escuela Primaria #2', 4, 'Primaria', 'Calle Falsa 456', 'OSDE', 2),
  (3, 'Lopez', 'Carlos', '2009-12-05', 'Dificultad de aprendizaje', 'Escuela Primaria #3', 6, 'Primaria', 'Pasaje Real 789', 'OSDE', 2);

-- ===============================================
-- INSERTAR REGISTROS EN LA TABLA Turnos
-- ===============================================
INSERT INTO Turnos (Fecha, Hora, DNI_C)
VALUES 
  ('2025-05-15', '09:00:00', 1),
  ('2025-05-16', '10:30:00', 2),
  ('2025-05-17', '11:15:00', 3);
-------------------------------------------------------------------------------------------------------------------------------
USE ConsultorioPsicopedagogico;

-- 1. Consultar todos los concurrentes
SELECT * FROM Concurrentes;

-- 2. Consultar todos los turnos de un concurrente específico (por DNI)
SELECT * FROM Turnos
WHERE DNI_C = 1;

-- 3. Consultar concurrentes que tienen turno en una fecha específica
SELECT c.DNI_C, c.Nombre, c.Apellido, t.Fecha, t.Hora
FROM Concurrentes c
JOIN Turnos t ON c.DNI_C = t.DNI_C
WHERE t.Fecha = '2025-05-15';

-- 4. Consultar el contacto del tutor del concurrente
SELECT c.Nombre AS Nombre_Concurrente, c.Apellido AS Apellido_Concurrente,
       t.Nombre AS Nombre_Tutor, t.Apellido AS Apellido_Tutor, t.Telefono, t.Email
FROM Concurrentes c
JOIN Tutor t ON c.DNI_Tutor = t.DNI_Tutor
WHERE c.DNI_C = 1;

-- 5. Consultar la cantidad de turnos que tiene un concurrente
SELECT c.DNI_C, c.Nombre, c.Apellido, COUNT(t.TurnoID) AS Total_Turnos
FROM Concurrentes c
LEFT JOIN Turnos t ON c.DNI_C = t.DNI_C
WHERE c.DNI_C = 1
GROUP BY c.DNI_C;

-- 6. Consultar número de concurrentes por obra social
SELECT Obrasocial, COUNT(*) AS Total_Concurrentes
FROM Concurrentes
GROUP BY Obrasocial;

-- 7. Búsqueda avanzada filtrando por varios atributos (ejemplo: por nombre, escuela y año escolar)
SELECT *
FROM Concurrentes
WHERE Nombre LIKE '%Ana%'
  AND Escuela LIKE '%Primaria%'
  AND AñoEscolar = 4;

-- 8. Listar los turnos próximos a partir de hoy
SELECT c.Nombre, c.Apellido, t.Fecha, t.Hora
FROM Turnos t
JOIN Concurrentes c ON t.DNI_C = c.DNI_C
WHERE t.Fecha >= CURDATE()
ORDER BY t.Fecha, t.Hora;

-- 9. Mostrar concurrentes que no tienen turnos asignados
SELECT c.DNI_C, c.Nombre, c.Apellido
FROM Concurrentes c
LEFT JOIN Turnos t ON c.DNI_C = t.DNI_C
WHERE t.TurnoID IS NULL;

-- 10. Cantidad total de turnos por día
SELECT Fecha, COUNT(*) AS Total_Turnos
FROM Turnos
GROUP BY Fecha
ORDER BY Fecha;

-- 11. Obtener todos los turnos con nombre y obra social del concurrente
 SELECT 
                    t.Fecha, 
                    t.Hora, 
                    c.Nombre AS Nombre_Concurrente, 
                    c.Apellido AS Apellido_Concurrente, 
                    c.Obrasocial, 
                    tu.Nombre AS Nombre_Tutor, 
                    tu.Apellido AS Apellido_Tutor, 
                    tu.Telefono 
                FROM Turnos t
                JOIN Concurrentes c ON t.DNI_C = c.DNI_C
                JOIN Tutor tu ON c.DNI_Tutor = tu.DNI_Tutor;

-- 12. Listar concurrentes ordenados por edad (de mayor a menor)
SELECT DNI_C, Nombre, Apellido, FechaNac, TIMESTAMPDIFF(YEAR, FechaNac, CURDATE()) AS Edad
FROM Concurrentes
ORDER BY Edad DESC;

-- 13. Buscar tutores por apellido o nombre
SELECT * FROM Tutor
WHERE Apellido LIKE '%Perez%' OR Nombre LIKE '%Juan%';

-- 14. Listar concurrentes con un diagnóstico específico
SELECT DNI_C, Nombre, Apellido, Diagnostico
FROM Concurrentes
WHERE Diagnostico LIKE '%TDAH%';

-- 15. Listar todos los turnos con información del concurrente y su tutor
SELECT t.Fecha, t.Hora,
       c.Nombre AS Nombre_Concurrente, c.Apellido AS Apellido_Concurrente,
       tu.Nombre AS Nombre_Tutor, tu.Apellido AS Apellido_Tutor
FROM Turnos t
JOIN Concurrentes c ON t.DNI_C = c.DNI_C
JOIN Tutor tu ON c.DNI_Tutor = tu.DNI_Tutor;

-- 16. Cantidad de concurrentes por escuela
SELECT Escuela, COUNT(*) AS Total_Concurrentes
FROM Concurrentes
GROUP BY Escuela;

-- 17. Turnos por nivel escolar
SELECT c.NivelEscolar, COUNT(t.TurnoID) AS Total_Turnos
FROM Concurrentes c
JOIN Turnos t ON c.DNI_C = t.DNI_C
GROUP BY c.NivelEscolar;
>>>>>>> developments
